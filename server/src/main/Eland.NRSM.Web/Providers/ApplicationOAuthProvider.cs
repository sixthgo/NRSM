using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Eland.NRSM.Web.Models;
using Formular.BaaS.Service;
using Spring.Context.Support;

namespace Eland.NRSM.Web.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private readonly Func<UserManager<ApplicationUser, int>> _userManagerFactory;
        IAuthService _authService = null;
        IUserService _userService = null;
        private IAuthService AuthService
        {
            get
            {
                if (_authService == null)
                    _authService = ContextRegistry.GetContext().GetObject("AuthService") as IAuthService;
                return _authService;
            }
        }

        private IUserService UserService
        {
            get
            {
                if (_userService == null)
                    _userService = ContextRegistry.GetContext().GetObject("UserService") as IUserService;
                return _userService;
            }
        }

        public ApplicationOAuthProvider(string publicClientId, Func<UserManager<ApplicationUser, int>> userManagerFactory)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            if (userManagerFactory == null)
            {
                throw new ArgumentNullException("userManagerFactory");
            }

            _publicClientId = publicClientId;
            _userManagerFactory = userManagerFactory;

        }


        /// <summary>
        /// GrantCustomExtension
        /// </summary>
        /// <param name="context">
        ///     - grant_type: "mdm"
        ///     - deviceId: "deviceId"
        ///     - appId: "appId"
        ///     - userName: "userName"
        /// </param>
        /// <returns></returns>
        public async override Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            if (context.GrantType.ToLower() == "mdm")
            {
                string deviceId = context.Parameters["deviceId"];
                string appId = context.Parameters["appId"];
                string userName = context.Parameters["userName"];

                if (ValidateMDMAuthentication(userName: userName, deviceId: deviceId, appId: appId))
                {
                    var baasUser = UserService.GetByUserName(userName);
                    if (baasUser != null)
                        await CreateAuthenticationSignInInfo(context, baasUser);
                }
            }
            await base.GrantCustomExtension(context);
        }
        private bool ValidateMDMAuthentication(string userName, string deviceId, string appId)
        {
            /// TO-DO: MDM을 통해 인증하는 부분 적용 필요.
            return string.IsNullOrWhiteSpace(userName) == false
                && string.IsNullOrWhiteSpace(deviceId) == false
                && string.IsNullOrWhiteSpace(appId) == false;
        }

        private async Task CreateAuthenticationSignInInfo(BaseValidatingTicketContext<OAuthAuthorizationServerOptions> context, Formular.BaaS.Domain.User baasUser)
        {
            using (UserManager<ApplicationUser, int> userManager = _userManagerFactory())
            {
                var user = new ApplicationUser(baasUser);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                ClaimsIdentity oAuthIdentity = await userManager.CreateIdentityAsync(user,
                    context.Options.AuthenticationType);
                ClaimsIdentity cookiesIdentity = await userManager.CreateIdentityAsync(user,
                    CookieAuthenticationDefaults.AuthenticationType);
                AuthenticationProperties properties = CreateProperties(user.UserName);
                AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesIdentity);
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var baasUser = AuthService.Login(context.UserName, context.Password);
            if (baasUser != null)
                await CreateAuthenticationSignInInfo(context, baasUser);
            else
                context.SetError("invalid_grant", "The user name or password is incorrect.");
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}