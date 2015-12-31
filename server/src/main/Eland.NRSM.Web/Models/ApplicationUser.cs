using Formular.BaaS.Domain;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eland.NRSM.Web.Models
{
    public class ApplicationUser : Formular.BaaS.Domain.User, IUser<int>
    {
        private Formular.BaaS.Domain.User _baasUser = null;

        private ApplicationUser() { }

        public ApplicationUser(Formular.BaaS.Domain.User user)
        {
            this._baasUser = user;
        }

        public User BaasUser
        {
            get
            {
                return _baasUser;
            }
        }


        public int Id
        {
            get { return _baasUser.Id; }
        }

        public string UserName
        {
            get
            {
                return _baasUser.UserName;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual IList<string> Roles
        {
            get
            {
                return new string[] { "admin" };
                //return _baasUser.Roles.Select<Role, string>(r => r.Name).ToList();
            }
        }

        public virtual string PasswordHash
        {
            get
            {
                return _baasUser.MemberDetail.Password;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

    public static class UserManagerExtensions
    {
        public static ApplicationUser FindByUserId(this UserManager<ApplicationUser, int> manager, string userId)
        {
            return manager.FindById(int.Parse(userId));
        }
    }
}