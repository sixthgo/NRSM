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
    public class QueryPreSameDateController : ApiController
    {
        IQueryPreSameDateService QueryPreSameDateService { get; set; }

        public Message Get(DateTime dt)
        {
            var result = QueryPreSameDateService.GetPreSameDate(dt);
            Message returnMessage = new Message();

            returnMessage.Flag = "S";
            returnMessage.ReturnMessage = result == null ? DateTime.Now.ToString("yyyy-MM-dd") : result.ToString("yyyy-MM-dd");

            return returnMessage;
        }
    }
}
