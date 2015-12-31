using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.ZQUERYMONTHRESULTIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class FloorHistoryRecordDetailService : IFloorHistoryRecordDetailService
    {
        public List<FloorHistoryRecordDetail> QueryMonthResultIn(string werks, string floor, string layoutCode, string selectDate)
        {
            QueryMonthResultInClient soapClient = new QueryMonthResultInClient();
            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            MonthResultByAccumulateElementsQueryMessage_sync param = new MonthResultByAccumulateElementsQueryMessage_sync()
            {
                PlantCode = werks,
                Floor = floor,
                LayoutCode = layoutCode,
                YearMonth = selectDate
            };

            List<FloorHistoryRecordDetail> detailResult = new List<FloorHistoryRecordDetail>();

            MonthResultByAccumulateElementsResponseMessage_sync result = soapClient.MonthResultByAccumulateElementsQueryResponse_In(param);

            foreach (RevenueMonthList achieveList in result.RevenueMonthList)
            {
                detailResult.Add(new FloorHistoryRecordDetail()
                {
                    PastRevenue = achieveList.PastRevenue,
                    GrowthRate = achieveList.GrowthRate,
                    GoalSum = achieveList.GoalSum,
                    AchieveRate = achieveList.AchieveRate
                });
            }

            return detailResult;
        }
    }
}
