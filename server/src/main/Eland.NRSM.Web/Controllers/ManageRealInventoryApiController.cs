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
    public class ManageRealInventoryApiController : ApiController
    {
        IManageRealInventoryInService ManageRealInventoryInService { get; set; }

        public RealInventory Get(decimal lbst, string matrn, string mode, decimal rlabst, string uname, string werks)
        {
            var result = ManageRealInventoryInService.GetRealInvertory(lbst, matrn, mode, rlabst, uname, werks);

            return result.FirstOrDefault();
        }
    }
}
