using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
//using Eland.NRSM.Template.ZQUERYMATERIALPRICEINFO;
using Eland.NRSM.Template.ZQUERYUSERAUTHIN;

namespace Eland.NRSM.Template.Services
{
    public class CUService : GenericService<Domain.CU>, ICUService
    {
        ICUDao cuDao { get { return genericDao as ICUDao; } }

        public List<Domain.CU> GetAllCU(string loginId, string pernr)
        {
            // RFC 
            QueryUserAuthInClient client = new QueryUserAuthInClient();
            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            UserAuthQuery_sync param = new UserAuthQuery_sync();
            param.PERNR = pernr;

            UserAuthResponse_sync response = client.UserAuthQueryResponse_In(param);
            string temp = string.Empty;

            List<Domain.CU> sapCUList = new List<Domain.CU>();
            foreach (UserAuthList p in response.CUUserAuthList)
            {
                sapCUList.Add(new Domain.CU() { CUCode = p.VALUE, CUName = p.BNAME });
            }

            // DB
            List<Domain.CU> dbCUList = new List<Domain.CU>();
            dbCUList = cuDao.GetAllCU(loginId);

            // composition
            List<Domain.CU> resultList = new List<Domain.CU>();
            resultList.Add(new Domain.CU { CUCode = "-1", CUName = "모든CU" });

            string star = "*";

            foreach (Domain.CU p in sapCUList)
            {
                if (p.CUCode == star) // [ * ]
                {                    
                    resultList.AddRange(dbCUList);
                }
                else // [ a-z ]
                {
                    resultList.AddRange(dbCUList.Where(t => t.CUCode == p.CUCode));
                }
            }

            IEnumerable<Domain.CU> identifiedList = resultList.Distinct();
            return identifiedList.ToList<Domain.CU>();
        }


        public List<Domain.PC> GetAllPC(string cuCode)
        {
            // DB
            if (string.IsNullOrEmpty(cuCode) == true)
                cuCode = null;

            List<Domain.PC> dbPCList = new List<Domain.PC>();
            ////dbPCList = cuDao.GetAllPC(cuCode);
            dbPCList.Add(new Domain.PC { CUCode = "-1", CUName = "모든CU", PCCode = "-1", PCName = "모든PC" });
            dbPCList.AddRange(cuDao.GetAllPC(cuCode));

            return dbPCList;
        }

    }
}
