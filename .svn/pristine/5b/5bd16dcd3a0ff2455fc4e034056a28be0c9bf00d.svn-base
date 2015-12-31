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
    public interface ICUDao : IGenericDao<Domain.CU>
    {
        List<Domain.CU> GetAllCU(string loginId);
        List<Domain.PC> GetAllPC(string cuCode);
    }

    public class CUDao : HibernateGenericDao<Domain.CU>, ICUDao
    {
        public List<Domain.CU> GetAllCU(string loginId)
        {
            var result = Session.GetNamedQuery("NRSM_CUMst_R01")
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.CU)))
                .List<Domain.CU>();

            return result as List<Domain.CU>;
        }

        public List<Domain.PC> GetAllPC(string cuCode)
        {
            var result = Session.GetNamedQuery("NRSM_CUPCMst_R01")
                .SetParameter("CUCode", cuCode)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.PC)))
                .List<Domain.PC>();

            return result as List<Domain.PC>;
        }

    }
}
