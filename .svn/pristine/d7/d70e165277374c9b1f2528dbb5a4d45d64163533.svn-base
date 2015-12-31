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
using Newtonsoft.Json.Linq;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderProposalController : ApiController
    {
        IFreshFoodOrderService FreshFoodOrderService { get; set; }

        public OrderGoodsResult Get(string ekOrg, string ekGrp, string werks, string buDat, string perNo)
        {
            OrderGoodsResult freshFoodOrder = FreshFoodOrderService.GetFreshFoods(ekOrg, ekGrp, werks, buDat, perNo);

            return freshFoodOrder;
        }

        public OrderGoodsOrderResult Save(string werks, string buDat, [FromBody]OrderGoodsParam orderGoods)
        {
            OrderGoodsOrderResult result = FreshFoodOrderService.SaveFreshFoods(werks, buDat, orderGoods.orderGoods);
            return result;
        }
    }
}
