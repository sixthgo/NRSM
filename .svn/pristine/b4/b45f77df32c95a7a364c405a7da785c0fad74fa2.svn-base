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
    public class CUController : ApiController
    {
        ICUService CUService { get; set; }
        IMembershipService MembershipService { get; set; }

        // GET api/storefloor
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public IHttpActionResult Get([FromUri]string loginId = "", [FromUri] string type = "", [FromUri]  string cuCode = "")
        {
            dynamic result;
            if (type == "cu")
            {
                Member member = MembershipService.GetUserByUserName(loginId).MemberDetail;
                string pernr = member.Empno;
                result = CUService.GetAllCU(loginId, pernr);
            }
            else
                result = CUService.GetAllPC(cuCode);

            return Ok(result);
        }
    }
}
