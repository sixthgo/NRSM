using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ManageScPoPalletItemInApiController : ApiController
    {
         IManageScPoPalletItemInService ManageScPoPalletItemInService { get; set; }


        public IEnumerable<ScPoItem> Get(string EBELN, string WERKS)
        {
            var result=ManageScPoPalletItemInService.GetScPoItemList(EBELN, WERKS);

            return result;
        }

        public IEnumerable<ScPalletItem> Get(string PALET, string WERKS, string BUDAT)
        {
            var result = ManageScPoPalletItemInService.GetScPalletItemList(PALET, WERKS, DateTime.ParseExact(BUDAT, "yyyy-M-d", null));

            return result;
        }



        public Message POST([FromBody]List<ScPoItem> scPoItemList)
        {
            ScPoItem item=scPoItemList[0];
            string[] pars = item.Params.Split(',');
            var result = ManageScPoPalletItemInService.savescPoItemList(pars[0], pars[1], DateTime.ParseExact(pars[2], "yyyy-M-d", null), scPoItemList);
            return result;
        }
        public Message POST([FromBody]List<ScPalletItem> ScPalletItemList, int temp)
        {
            ScPalletItem item = ScPalletItemList[0];
            string[] pars = item.Params.Split(',');
            var result = ManageScPoPalletItemInService.saveScPalletItemList(pars[0], pars[1], DateTime.ParseExact(pars[2], "yyyy-M-d", null), ScPalletItemList);

            return result;
        }
    }
}