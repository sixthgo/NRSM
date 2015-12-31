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
    public class StoreDetailController : ApiController
    {
        IStoreDetailService StoreDetailService { get; set; }

        // GET api/storedetail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<StoreDetail> Get(string werks, string floor, string layoutCode)
        {
            return StoreDetailService.QueryStoreDetailInfoIn(werks, floor, layoutCode);
        }

        public IEnumerable<StoreDetail> Get(string werks, string floor, string layoutCode, string selectDate)
        {
            return StoreDetailService.QueryStoreDetail2InfoIn(werks, floor, layoutCode, selectDate);
        }

        // GET api/storedetail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/storedetail
        public void Post([FromBody]string value)
        {
        }

        // PUT api/storedetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/storedetail/5
        public void Delete(int id)
        {
        }
    }
}
