using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Formular.Data;
using Domain = Eland.NRSM.Core.Domain;
using NHibernate.Transform;

namespace Eland.NRSM.Template.Dao
{
    public interface IAdminDao : IGenericDao<Domain.Admin>
    {
        string CheckIsAdmin(string loginId);
    }


    public class AdminDao : HibernateGenericDao<Domain.Admin>, IAdminDao
    {
        public string CheckIsAdmin(string loginId)
        {
            var result = Session.GetNamedQuery("NRSM_ManagerCheck_R01")
                .SetParameter("LoginId", loginId)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.Admin)))
                .UniqueResult();

            return (result as Domain.Admin).Chk;
        }
    }
}
