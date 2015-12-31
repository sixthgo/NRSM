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
    public class CEOReportController : ApiController
    {
        ICEOReportService CEOReportService { get; set; }

        public IEnumerable<CEOReport> Get(string gubun, string group)
        {
            var result = CEOReportService.GetCEOReportPlan(gubun, group);

            return result;
        }

    }
}
