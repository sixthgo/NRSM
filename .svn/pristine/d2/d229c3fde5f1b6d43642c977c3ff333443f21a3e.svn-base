using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Domain;
using Eland.NRSM.Template.ZQUERYHISTORYIN;

namespace Eland.NRSM.Template.Services
{
    public class FloorPlanCompareService : IFloorPlanCompareService
    {
        public List<FloorPlanHistoryCompare> QueryHistoryIn(string werks, string floor, string firstDate, string secondDate)
        {
            QueryHistoryInClient soapClient = new QueryHistoryInClient();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            firstDate = firstDate.Insert(4, "-");
            firstDate = firstDate.Insert(7, "-");

            secondDate = secondDate.Insert(4, "-");
            secondDate = secondDate.Insert(7, "-");

            HistoryByStoreComparisonElementsQueryMessage_sync param = new HistoryByStoreComparisonElementsQueryMessage_sync()
            {
                PlantCode = werks,
                Floor = floor,
                StartDate1 = Convert.ToDateTime(firstDate),
                StartDate1Specified = true,
                StartDate2 = Convert.ToDateTime(secondDate),
                StartDate2Specified = true
            };

            List<FloorPlanHistoryCompare> compareResult = new List<FloorPlanHistoryCompare>();

            HistoryByStoreComparisonElementsResponseMessage_sync result = soapClient.HistoryByStoreComparisonElementsQueryResponse_In(param);

            foreach (PlanList firstList in result.PlanList1)
            {
                compareResult.Add(new FloorPlanHistoryCompare()
                {
                    FirstFloorPlan = new FloorPlanFirst()
                    {
                        Gubun = firstList.Gubun,
                        LayoutCode = firstList.LayoutCode,
                        LayoutName = firstList.LayoutName,
                        GSpaceSize = firstList.GSpaceSize,
                        NSpaceSize = firstList.NSpaceSize
                    }
                });
            }

            foreach (PlanList secondList in result.PlanList2)
            {
                compareResult.Add(new FloorPlanHistoryCompare()
                {
                    SeondFloorPlan = new FloorPlanSecond()
                    {
                        Gubun = secondList.Gubun,
                        LayoutCode = secondList.LayoutCode,
                        LayoutName = secondList.LayoutName,
                        GSpaceSize = secondList.GSpaceSize,
                        NSpaceSize = secondList.NSpaceSize
                    }
                });
            }
            if (result.CompareList != null)
            {
                foreach (CompareList compareList in result.CompareList)
                {
                    compareResult.Add(new FloorPlanHistoryCompare()
                    {
                        CompareFloorPlan = new FloorPlanCompare()
                        {
                            Gubun = compareList.Gubun,
                            LayoutCode = compareList.LayoutCode,
                            Color = compareList.Color,
                            Value = compareList.Amount
                        }
                    });
                }
            }
            else
            {
                compareResult.Add(new FloorPlanHistoryCompare()
                {
                    CompareFloorPlan = new FloorPlanCompare()
                    {
                        Gubun = "",
                        LayoutCode = "",
                        Color = "",
                        Value = 0
                    }
                });
            }


            return compareResult;
        }
    }
}
