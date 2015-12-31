using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class AdminService : GenericService<Domain.Admin>, IAdminService
    {
        IAdminDao adminDao { get { return genericDao as IAdminDao; } }

        public string CheckIsAdmin(string loginId)
        {
            string result = string.Empty;
            result = adminDao.CheckIsAdmin(loginId);

            return result;
        }
    }
}
