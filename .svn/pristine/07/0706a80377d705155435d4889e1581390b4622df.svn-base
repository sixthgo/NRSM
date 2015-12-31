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
    public class PurchaseGroupController : ApiController
    {
        IPurchaseGroupService PurchaseGroupService { get; set; }

        public IEnumerable<PurchaseGroup> Get()
        {
            var result = PurchaseGroupService.GetPurchaseGroup();
            return result;
        }
    }
}
