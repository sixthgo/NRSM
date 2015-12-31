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
    public class ManageStockInspectionCreateApiController : ApiController
    {
        IManageStockInspectionCreateInService ManageStockInspectionCreateInService { get; set; }

        public Message Get(string MATNR, string WERKS)
        {
            string maktx = ManageStockInspectionCreateInService.GetSaveStock(MATNR, WERKS);

            Message dto = new Message();

            dto.Flag = "S";
            dto.ReturnMessage = maktx;

            return dto;
        }

        [HttpPost]
        public Message Post([FromBody]SaveStock dto)
        {
            Message returnDto = ManageStockInspectionCreateInService.SaveStock(dto);

            return returnDto;
        }
    }
}
