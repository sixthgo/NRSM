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
    public class FloorHistoryRecordDetailController : ApiController
    {
        IFloorHistoryRecordDetailService FloorHistoryRecordDetailService;
        // GET api/floorhistoryrecorddetail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<FloorHistoryRecordDetail> Get(string werks, string floor, string layoutCode, string selectDate)
        {
            return FloorHistoryRecordDetailService.QueryMonthResultIn(werks, floor, layoutCode, selectDate);
        }

        // GET api/floorhistoryrecorddetail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/floorhistoryrecorddetail
        public void Post([FromBody]string value)
        {
        }

        // PUT api/floorhistoryrecorddetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/floorhistoryrecorddetail/5
        public void Delete(int id)
        {
        }
    }
}
