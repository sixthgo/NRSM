using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.ZQUERYSALESRESULTIN_V1000;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Template.Services
{
    public class AccumulateSalesService : IAccumulateSalesService
    {
        public void FillResultData<T>(IEnumerable<T> skeltonDatas, List<AccumulateBaseType> target, Func<T, AccumulateBaseType> init)
        {
            if (skeltonDatas == null || skeltonDatas.Count() <= 0)
                return;

            if (target.Count > 0)
                return;
            foreach (T data in skeltonDatas)
            {
                target.Add(init(data));
            }
        }

        public ResultAccumulateList QuerySalesResultIn(string gubunField, string plantCodeField, string yearMonthField, string categoryUnitField, string purchaseGroupField, string brandCodeField, string personNumberField)
        {
            QuerySalesResultIn_V1000Client soapClient = new QuerySalesResultIn_V1000Client();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            SalesResultByResultInfoQueryMessage_sync param = new SalesResultByResultInfoQueryMessage_sync()
            {
                Gubun = gubunField,
                PlantCode = plantCodeField,
                CategoryUnit = categoryUnitField,
                PurchaseGroup = purchaseGroupField,
                BrandCode = brandCodeField,
                YearMonth = yearMonthField,
                PersonNumber = personNumberField
            };

            SalesResultByResultInfoResponseMessage_sync result = soapClient.SalesResultByResultInfoElementsQueryResponse_In_V1000(param);

            List<AccumulateSales> storeSales = new List<AccumulateSales>();

            // Error 발생의 경우
            if (result.Result != null && result.Result.Equals("E"))
                return new ResultAccumulateList() { Result = result.Result, Message = result.Message };


            List<AccumulateBaseType> resultSoap = new List<AccumulateBaseType>();


            FillResultData<RevenueResultList>(result.RevenueResultList, resultSoap, delegate(RevenueResultList data)
            {
                AccumulateList funcresult = new AccumulateList()
                {
                    PlantName = data.PlantName,
                    PlantCode = data.PlantCode,
                    CategoryUnitName = data.CategoryUnitName,
                    CategoryUnit = data.CategoryUnit,
                    PurchaseGroupName = data.PurchaseGroupName,
                    PurchaseGroup = data.PurchaseGroup,
                    BrandName = data.BrandName,
                    BrandCode = data.BrandCode,

                    Total = data.Total,
                    Amount = data.Amount,
                    GoalAmount = data.GoalAmount,
                    Rate = data.Rate,
                    PastAmount = data.PastAmount,
                    GrowthRate = data.GrowthRate,
                    SpaceSum = data.SpaceSum,
                    SpaceProfit = data.SpaceProfit
                };
                return funcresult;
            });


            return new ResultAccumulateList() { Result = result.Result, Message = result.Message, Total = resultSoap.Count == 0 ? 0 : resultSoap[0].Total, Salesdata = resultSoap };
        }

    }
}

