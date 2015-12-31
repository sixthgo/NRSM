using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.ZMANAGESPACEPROFITIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class SpaceProfitService : ISpaceProfitService
    {
        public List<SpaceProfit> ManageSpaceProfitIn(string werks, string layoutCode, string gubun)
        {

            ManageSpaceProfitInClient soapClient = new ManageSpaceProfitInClient();
            //soapClient.ClientCredentials.UserName.UserName = "ceuser";
            //soapClient.ClientCredentials.UserName.Password = "ceuser";
            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            SpaceProfitByCurrentIDQueryMessage_sync param = new SpaceProfitByCurrentIDQueryMessage_sync()
            {
                PlantCode = werks,
                LayoutCode = layoutCode,
                Gubun = gubun
            };

            SpaceProfitByCurrentIDResponseMessage_sync result = soapClient.SpaceProfitByCurrentIDQueryResponse_In(param);
            List<SpaceProfit> profitResult = new List<SpaceProfit>();

            profitResult.Add(new SpaceProfit()
            {
                Result = result.Result,
                Message = result.ResultMessage,
                Area = result.Area,
                Profit = result.SpaceProfit
            });

            return profitResult;
        }
    }
}
