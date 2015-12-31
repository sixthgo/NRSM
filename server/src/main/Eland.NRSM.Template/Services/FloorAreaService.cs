using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.ZMANAGEFLOORCODEIN;
using Eland.NRSM.Template.ZQUERYREVENUEIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class FloorAreaService : IFloorAreaService
    {
        public List<FloorArea> ManageFloorCodeIn(string werks, string floor)
        {
            ManageFloorCodeInClient soapClient = new ManageFloorCodeInClient();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            DateTime nowDate = DateTime.Now;
            string nowFormat = nowDate.ToString("yyyy-MM-dd");
            FloorCodeSizeByIDQueryMassage_sync param = new FloorCodeSizeByIDQueryMassage_sync()
            {
                CompanyCode = "8000",
                PlantID = new PlantID { Value = werks },
                Floor = floor,
                Date = Convert.ToDateTime(nowFormat),
                DateSpecified = true
            };

            FloorCodeSizeByIDResponseMessage_sync result = soapClient.FloorCodeSizeByIDQueryResponse_In(param);

            List<FloorArea> areas = new List<FloorArea>();


            areas.Add(new FloorArea()
            {
                Area = result.SpaceSize
            });


            return areas;

        }

        public List<SumCurrentTimeSales> QueryRevenueIn(string werks, string floor)
        {
            QueryRevenueInClient soapClient = new QueryRevenueInClient();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];
            DateTime nowTime = DateTime.Now;
            int hour = nowTime.Hour;
            int minute = nowTime.Minute;

            DateTime nowDate = DateTime.Now;
            string nowFormat = nowDate.ToString("yyyy-MM-dd");

            RevenueByCurrentIfElementsQueryMessage_sync param = new RevenueByCurrentIfElementsQueryMessage_sync()
            {
                CompanyCode = "8000",
                PlantCode = werks,
                Floor = floor,
                Date = Convert.ToDateTime(nowFormat),
                DateSpecified = true
            };

            List<SumCurrentTimeSales> currentTimeSales = new List<SumCurrentTimeSales>();

            RevenueByCurrentIfElementsResponseMessage_sync result = soapClient.RevenueByCurrentIfElementsQueryResponse_In(param);

            foreach (RevenueCurrentList currentList in result.RevenueCurrentList)
            {
                currentTimeSales.Add(new SumCurrentTimeSales()
                {
                    CurrentList = new CurrentList()
                    {
                        LayoutCode = currentList.LayoutCode,
                        ShapeID = currentList.ShapeID,
                        GSpaceSize = currentList.GSpaceSize,
                        NSpaceSize = currentList.NSpaceSize,
                        GoalSum = currentList.GoalSum,
                        LayoutModuleName = currentList.LayoutModuleName,
                        SalesSum = currentList.SaleSum,
                        ProfitSum = currentList.ProfitSum,
                        ProfitPercent = currentList.ProfitPercent
                    }
                });
            }

            foreach (RevenueStoreInfoList storeInfoList in result.RevenueStoreInfoList)
            {
                currentTimeSales.Add(new SumCurrentTimeSales()
                {
                    StoreInfoList = new SumStoreInfoList()
                    {
                        LayoutCode = storeInfoList.LayoutCode,
                        ShapeID = storeInfoList.ShapeID,
                        AreaType = storeInfoList.AreaType,
                        ReportCode = storeInfoList.ReportCode,
                        CalcType = storeInfoList.CalcType,
                        Value = storeInfoList.Value,
                        Color = storeInfoList.Color
                    }
                });
            }

            foreach (RevenueIFList IFList in result.RevenueIFList)
            {
                currentTimeSales.Add(new SumCurrentTimeSales()
                {
                    IFList = new IFList()
                    {
                        CalcType = IFList.CalcType,
                        ReportCode = IFList.ReportCode,
                        Grade = IFList.Grade,
                        ValueFrom = IFList.ValueFrom,
                        ValueTo = IFList.ValueTo,
                        Color = IFList.Color,
                        Quantity = IFList.Quantity,
                        Percent = IFList.Percent,
                        Sequence = IFList.Sequence,
                        VisioText = IFList.Text
                    }
                });
            }

            return currentTimeSales;
        }
    }
}
