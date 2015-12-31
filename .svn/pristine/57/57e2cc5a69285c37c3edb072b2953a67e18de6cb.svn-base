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
    public interface IPurchaseGroupDao : IGenericDao<Domain.PurchaseGroup>
    {
        List<Domain.PurchaseGroup> GetAll();
    }

    public class PurchaseGroupDao : HibernateGenericDao<Domain.PurchaseGroup>, IPurchaseGroupDao
    {
        public List<Domain.PurchaseGroup> GetAll()
        {
            var result = Session.GetNamedQuery("NRSM_Fresh_PURGMst_R01")
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.PurchaseGroup)))
                .List<Domain.PurchaseGroup>();

            return result as List<Domain.PurchaseGroup>;
        }
    }
}
