using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.QUERYDAILYSALEPREDICTIONIN;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class QueryDailySalePredictionInService : GenericService<Domain.DailySalePredition>, IQueryDailySalePredictionInService
    {

        public List<Domain.DailySalePredition> GetAllDailySalePredition(DateTime day1, DateTime day2, string dmchk, string sabun, string werks)
        {
            QueryDailySalePredictionInClient client = new QueryDailySalePredictionInClient();

            client.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            client.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            DailySalePredictionQuery_sync param = new DailySalePredictionQuery_sync();

            param.DAY1 = day1;
            param.DAY1Specified = true;
            param.DAY2 = day2;
            param.DAY2Specified = true;
            param.DMCHK = dmchk;
            param.SABUN = sabun;
            param.WERKS = werks;

            DailySalePredictionResponse_sync respone = client.DailySalePredictionQueryResponse_In(param);

            List<Domain.DailySalePredition> dailySalePreditionList = new List<Domain.DailySalePredition>();

            List<Domain.DailySalePredictionFloor> floorList = new List<Domain.DailySalePredictionFloor>();

            List<Domain.DailySalePredictionTime> timeList = new List<Domain.DailySalePredictionTime>();

            if (respone.DailySalePredictionFloorList != null)
            {
                foreach (DailySalePredictionFloorList d in respone.DailySalePredictionFloorList)
                {

                    floorList.Add(new Domain.DailySalePredictionFloor()
                    {
                        WERK = d.WERK,
                        ZAMT = d.ZAMT,
                        ZAMT2 = d.ZAMT2,
                        ZAMT3 = d.ZAMT3,
                        ZAMT4 = d.ZAMT4,
                        ZFL = d.ZFL,
                        ZYUL = d.ZYUL,
                        ZYUL2 = d.ZYUL2
                    });
                }
            }

            if (respone.DailySalePredictionTimeList != null)
            {
                foreach (DailySalePredictionTimeList d in respone.DailySalePredictionTimeList)
                {
                    timeList.Add(new Domain.DailySalePredictionTime()
                    {
                        NAME1 = d.NAME1,
                        WERK = d.WERK,
                        ZAMT = d.ZAMT,
                        ZAMT2 = d.ZAMT2,
                        ZAMT3 = d.ZAMT3,
                        ZAMT4 = d.ZAMT4,
                        ZYUL = d.ZYUL,
                        ZYUL2 = d.ZYUL2
                    });
                }
            }

            dailySalePreditionList.Add(new Domain.DailySalePredition()
            {
                DailySalePreditionFloor = floorList,
                DailySalePreditionTime = timeList,
                Flag = respone.Flag,
                ReturnMessage = respone.ReturnMessage
            });
           

            return dailySalePreditionList;
        }
    }
}

