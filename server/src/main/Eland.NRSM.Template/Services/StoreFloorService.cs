using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
using Eland.NRSM.Template.ZQUERYSTOREFLOORCODEIN_V1000;
using Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class StoreFloorService : IStoreFloorService
    {
        public List<StoreFloor> QueryStoreFloorCodeIn(string personNumber)
        {
            QueryStoreFloorCodeIn_V1000Client soapClient = new QueryStoreFloorCodeIn_V1000Client();

            soapClient.ClientCredentials.UserName.UserName = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_USERNAME"];
            soapClient.ClientCredentials.UserName.Password = System.Configuration.ConfigurationManager.AppSettings["SAP_WEBSERVICE_PASSWORD"];

            StoreFloorCodeByListQueryMessage_sync param = new StoreFloorCodeByListQueryMessage_sync()
            {
                PersonNumber = personNumber
            };

            StoreFloorCodeByListResponseMessage_sync result = soapClient.StoreFloorCodeByListElementsQueryResponse_In_V1000(param);

            List<StoreFloor> floorResult = new List<StoreFloor>();

            foreach (var floorList in result.StoreFloorList)
            {
                floorResult.Add(new StoreFloor()
                {
                    PlantCode = floorList.PlantCode,
                    PlantCodeName = floorList.PlantCodeName,
                    Floor = floorList.Floor,
                    FloorDesc = floorList.FloorDesc
                });
            }
            return floorResult;
        }
    }
}
