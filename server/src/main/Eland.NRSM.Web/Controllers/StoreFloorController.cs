using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Formular.BaaS.Service;
using Formular.BaaS.Domain;
using System.Web.Http.Cors;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StoreFloorController : ApiController
    {
        IStoreFloorService StoreFloorService { get; set; }
        IMembershipService MembershipService { get; set; }

        public IEnumerable<StoreAndFloor> Get(string menu, string werks, string floor, string loginId)
        {
            Member member = MembershipService.GetUserByUserName(loginId).MemberDetail;
            string pernr = member.Empno;
            List<StoreFloor> result = StoreFloorService.QueryStoreFloorCodeIn(pernr);

            Dictionary<string, StoreAndFloor> ccc = new Dictionary<string, StoreAndFloor>();
            int storeIndexing = 0;

            result.ForEach(c =>
            {
                if (!ccc.ContainsKey(c.PlantCode))
                {
                    StoreAndFloor storeAndFloor = new StoreAndFloor()
                    {
                        Id = storeIndexing++,
                        SectionCode = c.PlantCode,
                        SectionName = c.PlantCodeName,
                        Floors = new List<Floor>()
                    };
                    ccc.Add(c.PlantCode, storeAndFloor);
                }
                StoreAndFloor value = ccc[c.PlantCode];
                value.Floors.Add(new Floor() { Id = value.floorIndex++, Code = c.Floor, Name = c.FloorDesc });
            });
            Dictionary<string, StoreAndFloor>.ValueCollection storeAndFloorsValue = ccc.Values;

            return storeAndFloorsValue.ToList();
        }
    }
}
