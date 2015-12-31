using Eland.NRSM.Web.Models;
using Formular.BaaS.Domain;
using Formular.BaaS.Service;
using Microsoft.AspNet.Identity;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eland.NRSM.Web.Controllers
{
    public class UsersController : ApiController
    {
        IUserService _userService = null;
        IRoleService _roleService = null;
        public UsersController() : this(Startup.UserManagerFactory()) { }
        public UsersController(UserManager<ApplicationUser, int> userManager)
        {
            UserManager = userManager;
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

        private IRoleService RoleService
        {
            get
            {
                if (_roleService == null)
                    _roleService = ContextRegistry.GetContext().GetObject("RoleService") as IRoleService;
                return _roleService;
            }
        }
        public IHttpActionResult Get(int roleId = -1)
        {
            IEnumerable<User> users = null;
            if (roleId > 0)
            {
                users = RoleService.SearchUserByRoleId(roleId).Select<Member, User>(m => m.User);
            }
            else
            {
                users = UserService.GetAll();
            }

            return Ok(users);
        }

        public IHttpActionResult Get(int id, [FromUri]int roleId = -1)
        {
            User user = null;
            if (roleId > 0)
            {
                var users = RoleService.SearchUserByRoleId(roleId).Select<Member, User>(m => m.User);
                user = users.Where(u => u.Id == id).FirstOrDefault();
            }
            else
            {
                user = UserService.Get(id);
            }

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        public IHttpActionResult AddRole([FromUri]int roleId, IEnumerable<User> users)
        {
            var role = RoleService.Get(roleId);
            if (role == null)
                return NotFound();

            users.ToList().ForEach(u =>
            {
                var user = UserService.Get(u.Id);
                user.AddRole(role);
                UserService.Update(user);
            });

            return Ok();
        }


        public UserManager<ApplicationUser, int> UserManager { get; set; }
    }
}
