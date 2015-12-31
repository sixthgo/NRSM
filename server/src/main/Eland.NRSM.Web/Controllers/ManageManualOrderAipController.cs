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
    public class ManageManualOrderAipController : ApiController
    {
        IManageManualOrderInService ManageManualOrderInService { get; set; }


        public IEnumerable<ManualOrderMatInfo> Get(string matnr, string werks)
        {
            var result = ManageManualOrderInService.GetManualOrderMathInfo(matnr, werks);

            return result;
        }

        [HttpPost]
        public Message POST([FromBody]ManualOrderMatInfo dto)
        {
            Message returnDto = ManageManualOrderInService.SaveManualOrderMathInfo(dto);

            return returnDto;
        }
    }
}
