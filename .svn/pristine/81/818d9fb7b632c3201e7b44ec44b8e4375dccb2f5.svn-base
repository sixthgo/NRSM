using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eland.NRSM.Web.Controllers
{
    public class FloorHistoryRecordController : ApiController
    {
        IFloorHistoryRecordService FloorHistoryRecordService;

        // GET api/floorhistoryrecord
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<FloorHistoryRecord> Get(string werks, string floor, string selectDate)
        {
            return FloorHistoryRecordService.QueryFloorRevenueIn(werks, floor, selectDate);
        }


        // GET api/floorhistoryrecord/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/floorhistoryrecord
        public void Post([FromBody]string value)
        {
        }

        // PUT api/floorhistoryrecord/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/floorhistoryrecord/5
        public void Delete(int id)
        {
        }
    }
}
