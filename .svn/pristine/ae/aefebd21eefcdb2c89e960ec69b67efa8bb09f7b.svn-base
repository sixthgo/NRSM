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
    public class SpaceProfitController : ApiController
    {
        ISpaceProfitService SpaceProfitService { get; set; }

        // GET api/spaceprofit
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<SpaceProfit> Get(string werks, string layoutCode, string gubun)
        {
            return SpaceProfitService.ManageSpaceProfitIn(werks, layoutCode, gubun);
        }

        // GET api/spaceprofit/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/spaceprofit
        public void Post([FromBody]string value)
        {
        }

        // PUT api/spaceprofit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/spaceprofit/5
        public void Delete(int id)
        {
        }
    }
}
