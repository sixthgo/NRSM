﻿using Eland.NRSM.Core.Services;
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
    public class PlantService : GenericService<Domain.Plant>, IPlantService
    {
        IPlantDao plantDao { get { return genericDao as IPlantDao; } }

        public List<Domain.Plant> GetAllPlant(string loginId, string pernr)
        {
            // RFC 
            QueryUserAuthInClient client = new QueryUserAuthInClient();
            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            UserAuthQuery_sync param = new UserAuthQuery_sync();
            param.PERNR = pernr;

            UserAuthResponse_sync response = client.UserAuthQueryResponse_In(param);
            string temp = string.Empty;

            List<Domain.Plant> sapPlantList = new List<Domain.Plant>();
            foreach (UserAuthList p in response.PLANTUserAuthList)
            {
                sapPlantList.Add(new Domain.Plant() { PlantCode = p.VALUE, PlantName = p.BNAME });
            }

            // DB
            List<Domain.Plant> dbPlantList = new List<Domain.Plant>();
            dbPlantList = plantDao.GetAllPlant(loginId);

            // composition
            List<Domain.Plant> resultList = new List<Domain.Plant>();
            resultList.Add(new Domain.Plant { PlantCode = "-1", PlantName = "전지점" });

            string prefix = string.Empty;
            string star = "*";

            foreach (Domain.Plant p in sapPlantList)
            {
                prefix = string.Empty;
                if (p.PlantCode == star) // [ * ]
                {                    
                    resultList.AddRange(dbPlantList);
                }
                else if (p.PlantCode.Contains(star) == true) // [ 7* , 8*, 5* ]
                {
                    prefix = p.PlantCode.Split(star.ToCharArray())[0];
                    resultList.AddRange(dbPlantList.Where(t => t.PlantCode.StartsWith(prefix)));
                }
                else // [ nnnn ]
                {
                    ////resultList.Add(p);
                    prefix = p.PlantCode;
                    resultList.AddRange(dbPlantList.Where(t => t.PlantCode.Equals(prefix)));
                }
            }
            //resultList.AddRange(dbPlantList);

            IEnumerable<Domain.Plant> identifiedList = resultList.Distinct();
            return identifiedList.ToList<Domain.Plant>();
        }

        public String GetWERKS(string pernr)
        {

            QueryUserAuthInClient client = new QueryUserAuthInClient();
            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            UserAuthQuery_sync param = new UserAuthQuery_sync();
            param.PERNR = pernr;

            String werks = string.Empty;
            UserAuthResponse_sync response = client.UserAuthQueryResponse_In(param);

            werks = response.WERKS;
            string some = response.BNAME;

            return werks;
        }


        public List<Domain.UserLinkButton> GetUserLinkButton(string loginId)
        {
            List<Domain.UserLinkButton> list = new List<Domain.UserLinkButton>();

            list = plantDao.GetUserLinkButton(loginId);

            return list;
        }

        public List<Domain.Purg> GetUserPurgCode(string purgCode)
        {
            List<Domain.Purg> list = new List<Domain.Purg>();

            list = plantDao.GetUserPurgCode(purgCode);

            return list;
        }
    }
}
