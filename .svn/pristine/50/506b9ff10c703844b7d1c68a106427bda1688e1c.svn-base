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
    public interface IPlantDao : IGenericDao<Domain.Plant>
    {
        List<Domain.Plant> GetAllPlant(string loginId);

        List<Domain.UserLinkButton> GetUserLinkButton(string loginId);

        List<Domain.Purg> GetUserPurgCode(string purgCode);
    }

    public class PlantDao : HibernateGenericDao<Domain.Plant>, IPlantDao
    {
        public List<Domain.Plant> GetAllPlant(string loginId)
        {
            var result = Session.GetNamedQuery("NRSM_PlantMst_R01")
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.Plant)))
                .List<Domain.Plant>();

            return result as List<Domain.Plant>;
        }

        public List<Domain.UserLinkButton> GetUserLinkButton(string loginId)
        {
            var result = Session.GetNamedQuery("sp_HyperAuth_R01")
                    .SetParameter("LoginID", loginId)
                    .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.UserLinkButton)))
                    .List<Domain.UserLinkButton>();

            return result as List<Domain.UserLinkButton>;
        }

        public List<Domain.Purg> GetUserPurgCode(string purgCode)
        {
            var result = Session.GetNamedQuery("sp_MaterialType_R01")
                        .SetParameter("PurgCode", purgCode)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.Purg)))
                        .List<Domain.Purg>();

            return result as List<Domain.Purg>;
        }

    }
}
