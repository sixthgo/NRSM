using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuerySaleApiController : ApiController
    {
        IQueryDailySalePredictionInService QueryDailySalePredictionInService { get; set; }


        public IEnumerable<DailySalePredition> Get(DateTime day1, DateTime day2, string dmchk, string sabun, string werks)
        {
            var result = QueryDailySalePredictionInService.GetAllDailySalePredition(day1, day2, dmchk, sabun, werks);

            return result;
        }
    }
}
