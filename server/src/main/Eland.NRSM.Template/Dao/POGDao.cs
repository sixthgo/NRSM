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
    public interface IPOGFirstCategoryDao : IGenericDao <Domain.POGFirstCategory>
    {
        List<Domain.POGFirstCategory> GetFirstCategory(string plantCode);
    }

    public interface IPOGThirdCategoryDao : IGenericDao<Domain.POGThirdCategory>
    {
        List<Domain.POGThirdCategory> GetThirdCategory(string plantCode, string firstCategory);
    }

    public interface IPOGColumnDao : IGenericDao<Domain.POGColumn>
    {
        List<Domain.POGColumn> GetColumn(string plantCode, string firstCategory, string thirdCategory);
    }

    public class POGFirstCategoryDao : HibernateGenericDao<Domain.POGFirstCategory>, IPOGFirstCategoryDao
    {
        public List<Domain.POGFirstCategory> GetFirstCategory(string plantCode)
        {
            var result = Session.GetNamedQuery("NRSM_POGMst_1st_R01")
                .SetParameter("PLANT", plantCode)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.POGFirstCategory)))
                .List<Domain.POGFirstCategory>();

            return result as List<Domain.POGFirstCategory>;
        }
    }

    public class POGThirdCategoryDao : HibernateGenericDao<Domain.POGThirdCategory>, IPOGThirdCategoryDao
    {
        public List<Domain.POGThirdCategory> GetThirdCategory(string plantCode, string firstCategory)
        {
            var result = Session.GetNamedQuery("NRSM_POGMst_3rd_R01")
                .SetParameter("PLANT", plantCode)
                .SetParameter("FIRCG", firstCategory)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.POGThirdCategory)))
                .List<Domain.POGThirdCategory>();

            return result as List<Domain.POGThirdCategory>;
        }
    }

    public class POGColumnDao : HibernateGenericDao<Domain.POGColumn>, IPOGColumnDao
    {
        public List<Domain.POGColumn> GetColumn(string plantCode, string firstCategory, string thirdCategory)
        {
            var result = Session.GetNamedQuery("NRSM_POGMst_col_R01")
                .SetParameter("PLANT", plantCode)
                .SetParameter("FIRCG", firstCategory)
                .SetParameter("THICG", thirdCategory)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.POGColumn)))
                .List<Domain.POGColumn>();

            return result as List<Domain.POGColumn>;
        }
    }
}
