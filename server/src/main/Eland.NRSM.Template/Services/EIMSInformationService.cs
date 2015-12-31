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
    public class EIMSInformationService : GenericService<Domain.EIMSInformation>, IEIMSInformationService
    {
        IEIMSInformationDao eimsInformationDao { get { return genericDao as IEIMSInformationDao; } }

        public void InsertMethod()
        {

        }

        public List<Domain.EIMSInformation> GetEIMSInformationDtoList(string PLANT, string BUDAT)
        {
            return eimsInformationDao.GetEIMSInformationDtoList(PLANT, BUDAT);
        }
    }
}
