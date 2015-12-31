using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.ZQUERYEVENTREVENUEIN_V1100;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class EventSalesService : IEventSalesService
    {
        public void FillResultData<T>(IEnumerable<T> skeltonDatas, List<EventBaseType> target, Func<T, EventBaseType> init)
        {
            if (skeltonDatas == null || skeltonDatas.Count() <= 0)
                return;

            if (target.Count > 0)
                return;
            foreach (T data in skeltonDatas)
            {
                target.Add(init(data));
            }
            //skeltonDatas.ForEach( data => target.Add(init( data )));
        }


        public ResultEventList QuerySalesRevenueInIdByResultEventList(string inputField, string gubunField, DateTime dateField, string plantCodeField, string layoutCodeField, string floorField, string categoryUnitField, string purchaseGroupField, string brandCodeField, string personNumberField)
        {
            DateTime requesttime = DateTime.Now;


            QueryEventRevenueIn_V1100Client soapClient = new QueryEventRevenueIn_V1100Client();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            //string nowFormat = dateField.ToString("yyyy-MM-dd");

            EventRevenueByCurrentAmountQueryMessage_sync_V1100 param = new EventRevenueByCurrentAmountQueryMessage_sync_V1100()
            {
                Input = inputField,
                Gubun = gubunField,
                Date = dateField,
                DateSpecified = true,
                PlantCode = plantCodeField,
                LayoutCode = layoutCodeField,
                Floor = floorField,
                CategoryUnit = categoryUnitField,
                PurchaseGroup = purchaseGroupField,
                BrandCode = brandCodeField,
                PersonNumber = personNumberField
            };

            EventRevenueByCurrentAmountResponseMessage_sync_V1100 result = soapClient.EventRevenueByCurrentAmountElementsQueryResponse_In_V1100(param);

            List<EventSales> storeSales = new List<EventSales>();

            // Error 발생의 경우
            if (result.Result != null && result.Result.Equals("E"))
                return new ResultEventList() { Result = result.Result, Message = result.Message };


            List<EventBaseType> resultSoap = new List<EventBaseType>();


            FillResultData<RevenueLaygrList>(result.RevenueLaygrList, resultSoap, delegate(RevenueLaygrList data)
            {
                EventLaygrList funcresult = new EventLaygrList()
                {
                    LayoutName = data.LayoutName,
                    LayoutCode = data.LayoutCode,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            FillResultData<RevenueWerksList>(result.RevenueWerksList, resultSoap, delegate(RevenueWerksList data)
            {
                EventWerkisList funcresult = new EventWerkisList()
                {
                    PlantName = data.PlantName,
                    PlantCode = data.PlantCode,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            FillResultData<RevenueWerksList>(result.RevenueBrandPlantList, resultSoap, delegate(RevenueWerksList data)
            {
                EventBrandPlantList funcresult = new EventBrandPlantList()
                {
                    PlantName = data.PlantName,
                    PlantCode = data.PlantCode,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            FillResultData<RevenueBrandList>(result.RevenueBrandList, resultSoap, delegate(RevenueBrandList data)
            {
                EventBrandList funcresult = new EventBrandList()
                {
                    BrandName = data.BrandName,
                    BrandCode = data.BrandCode,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            FillResultData<RevenueFloorList>(result.RevenueFloorList, resultSoap, delegate(RevenueFloorList data)
            {
                EventFloorList funcresult = new EventFloorList()
                {
                    Floor = data.Floor,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            FillResultData<RevenueTimeList>(result.RevenueTimeList, resultSoap, delegate(RevenueTimeList data)
            {
                EventTimeList funcresult = new EventTimeList()
                {
                    Time = data.Time,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            FillResultData<RevenueLTimeList>(result.RevenueLaygrTimeList, resultSoap, delegate(RevenueLTimeList data)
            {
                EventLaygrTimeList funcresult = new EventLaygrTimeList()
                {
                    BrandName = data.BrandName,
                    BrandCode = data.BrandCode,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            FillResultData<RevenueTimeList>(result.RevenueFloorTimeList, resultSoap, delegate(RevenueTimeList data)
            {
                EventFloorTimeList funcresult = new EventFloorTimeList()
                {
                    Time = data.Time,
                    Amount = data.Amount,
                    Rate = data.Rate,
                    PerSum = data.PerSum,
                    Count = data.Count,
                    SpaceSum = data.SpaceSum,
                    Total = data.Total
                };
                return funcresult;
            });

            DateTime functionCallend = DateTime.Now;
            TimeSpan processingTime = functionCallend - requesttime;


            string realPath = System.Web.HttpContext.Current.Server.MapPath("~") + "RbmsProcessing.log";

            using (FileStream fs = new FileStream(realPath, FileMode.Append, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("[{0}] Request Service Name : {1} : {2} : {3} , Processing Time : {4} ", requesttime.ToString("yyyy-MM-dd HH:mm:ss"), this.GetType().Name, inputField, gubunField, processingTime.Milliseconds);
                sw.Close();
            }

            return new ResultEventList() { Result = result.Result, Message = result.Message, Total = resultSoap.Count == 0 ? 0 : resultSoap[0].Total, Salesdata = resultSoap };
        }

    }
}
