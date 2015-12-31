using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Eland.NRSM.Web.Models;
using Formular.BaaS.Domain;
using Formular.BaaS.Service;
using Spring.Context;
using System.Web.Http.Cors;
using Eland.NRSM.Core.Services;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminApiController : ApiController
    {
        IAdminService AdminService { get; set; }

        // GET api/values/5
        public string Get([FromUri]string loginId)
        {
            string result = string.Empty;
            result = AdminService.CheckIsAdmin(loginId);

            return result;
        }
    }
}
