using Formular.Data;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Dao
{
    public interface IEIMSInformationDao : IGenericDao<Domain.EIMSInformation>
    {
        List<Domain.EIMSInformation> GetEIMSInformationDtoList(string PLANT, string BUDAT);
    }


    public class EIMSInformationDao : HibernateGenericDao<Domain.EIMSInformation>, IEIMSInformationDao
    {
        public List<Domain.EIMSInformation> GetEIMSInformationDtoList(string PLANT, string BUDAT)
        {
            return Session.GetNamedQuery("NRSM_EIMSInformation_R01")
                .SetParameter("PLANT", PLANT)
                .SetParameter("BUDAT", BUDAT)
                .SetResultTransformer(Transformers.AliasToBean(typeof(Domain.EIMSInformation)))
                .List<Domain.EIMSInformation>() as List<Domain.EIMSInformation>;

        }
    }
}
