using Formular.BaaS.Service;
using Microsoft.AspNet.Identity;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Eland.NRSM.Web.Models
{
    public class BaasUserStore : IUserStore<ApplicationUser, int>, IUserPasswordStore<ApplicationUser, int>
    {
        IUserService _userService = null;
        IRoleService _roleService = null;

        private IUserService UserService
        {
            get
            {
                if (_userService == null)
                    _userService = ContextRegistry.GetContext().GetObject("UserService") as IUserService;
                return _userService;
            }
        }

        private IRoleService RoleService
        {
            get
            {
                if (_roleService == null)
                    _roleService = ContextRegistry.GetContext().GetObject("RoleService") as IRoleService;
                return _roleService;
            }
        }

        public Task CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(int userId)
        {
            return Task<ApplicationUser>.Run(() =>
            {
                var user = UserService.Get(userId);
                return new ApplicationUser(user);
            });
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return Task<ApplicationUser>.Run(() =>
            {
                var user = UserService.GetByUserName(userName);
                return new ApplicationUser(user);
            });
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task<string>.Run(() => user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}