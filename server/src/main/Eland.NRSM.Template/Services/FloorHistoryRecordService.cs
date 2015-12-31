using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.ZQUERYFLOORREVENUEIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class FloorHistoryRecordService : IFloorHistoryRecordService
    {
        public List<FloorHistoryRecord> QueryFloorRevenueIn(string werks, string floor, string selectDate)
        {
            QueryFloorRevenueInClient soapClient = new QueryFloorRevenueInClient();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            FloorRevenueByResultElementsQueryMessage_sync param = new FloorRevenueByResultElementsQueryMessage_sync()
            {
                PlantCode = werks,
                Floor = floor,
                YearMonth = selectDate
            };

            List<FloorHistoryRecord> recordResult = new List<FloorHistoryRecord>();

            FloorRevenueByResultElementsResponseMessage_sync result = soapClient.FloorRevenueByResultElementsQueryResponse_In(param);

            foreach (RevenueCurrentList currentList in result.RevenueCurrentList)
            {
                recordResult.Add(new FloorHistoryRecord()
                {
                    HistoryCurrentList = new RecordCurrentList()
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
                recordResult.Add(new FloorHistoryRecord()
                {
                    HistoryStoreInfoList = new RecordStoreInfoList()
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

            foreach (RevenueIFList ifList in result.RevenueIfList)
            {
                recordResult.Add(new FloorHistoryRecord()
                {
                    HistoryIFList = new RecordIFList()
                    {
                        CalcType = ifList.CalcType,
                        ReportCode = ifList.ReportCode,
                        Grade = ifList.Grade,
                        ValueFrom = ifList.ValueFrom,
                        ValueTo = ifList.ValueTo,
                        Color = ifList.Color,
                        Quantity = ifList.Quantity,
                        Percent = ifList.Percent,
                        Sequence = ifList.Sequence,
                        VisioText = ifList.Text
                    }
                });
            }

            return recordResult;
        }
    }
}
