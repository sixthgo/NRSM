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
    public interface ITemplateDao : IGenericDao<Domain.Template>
    {
        List<Domain.Template> SearchTemplate(string loginId);
    }

    public class TemplateDao : HibernateGenericDao<Domain.Template>, ITemplateDao
    {
        public List<Domain.Template> SearchTemplate(string loginId)
        {            
            //var result = Session
            //        .GetNamedQuery("NRSM_FavoriteMenu_R01")
            //        .SetParameter("LoginId", loginId)
            //        .List();

            var result = Session.GetNamedQuery("NRSM_FavoriteMenu_R01")
                .SetParameter("LoginId", loginId)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.Template)))
                .List<Domain.Template>();

            return result as List<Domain.Template>;
        }
    }
}
