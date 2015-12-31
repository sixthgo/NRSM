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
    public class FloorAreaController : ApiController
    {
        IFloorAreaService FloorAreaService;
        // GET api/floorarea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<FloorArea> Get(string werks, string floor)
        {
            return FloorAreaService.ManageFloorCodeIn(werks, floor);
        }

        public IEnumerable<SumCurrentTimeSales> Get(string werks, string floor, string date)
        {
            return FloorAreaService.QueryRevenueIn(werks, floor);
        }

        // GET api/floorarea/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/floorarea
        public void Post([FromBody]string value)
        {
        }

        // PUT api/floorarea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/floorarea/5
        public void Delete(int id)
        {
        }
    }
}
