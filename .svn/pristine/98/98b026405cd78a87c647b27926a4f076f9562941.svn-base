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
    public class ManageSalePriceSendApiController : ApiController
    {
        IManageSalePriceSendInService ManageSalePriceSendInService { get; set; }

        public Message Get(string plantCode, string barCode, string ztype)
        {
            var result = ManageSalePriceSendInService.SaveBarCode(plantCode, barCode, ztype);

            return result;
        }
    }
}
