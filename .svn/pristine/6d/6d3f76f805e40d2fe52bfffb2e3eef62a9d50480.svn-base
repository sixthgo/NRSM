using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.QUERYPREVSAMEDATEIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class QueryPreSameDateService : IQueryPreSameDateService
    {
        public DateTime GetPreSameDate(DateTime dt)
        {
            QueryPrevSameDateInClient client = new QueryPrevSameDateInClient();
            DateTime returnDate = new DateTime();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            PrevSameDateQuery_sync param = new PrevSameDateQuery_sync();

            param.InDAY = dt;
            param.InDAYSpecified = true;

            PrevSameDateResponse_sync respone = client.PrevSameDateQueryResponse_In(param);

            if (respone != null && respone.OutDAY != null)
            {
                returnDate = respone.OutDAY;
            }

            return returnDate;
        }
    }
}
