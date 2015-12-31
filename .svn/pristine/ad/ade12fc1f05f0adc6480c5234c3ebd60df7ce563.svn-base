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
    public class POGController : ApiController
    {
        IPOGFirstCategoryService POGFirstCategoryService { get; set; }
        IPOGThirdCategoryService POGThirdCategoryService { get; set; }
        IPOGColumnService POGColumnService { get; set; }
        IPOGGoodsService POGGoodsService { get; set; }

        public IEnumerable<POGFirstCategory> Get(string plantCode)
        {
            var result = POGFirstCategoryService.GetFirstCategory(plantCode);
            return result;
        }

        public IEnumerable<POGThirdCategory> Get(string plantCode, string firstCategory)
        {
            var result = POGThirdCategoryService.GetThirdCategory(plantCode, firstCategory);
            return result;
        }

        public IEnumerable<POGColumn> Get(string plantCode, string firstCategory, string thirdCategory)
        {
            var result = POGColumnService.GetColumn(plantCode, firstCategory, thirdCategory);
            return result;
        }

        public POGGoods Get(string plantCode, string firstCategory, string thirdCategory, string column, string userName, string goodsCode)
        {
            POGGoods result = POGGoodsService.GetGoods(plantCode, goodsCode, firstCategory, thirdCategory, column, string.Empty);

            // sort
            result.POGGoodsData.Sort((x, y)
                => string.Compare((x.ZROW + x.ZSEQ), (y.ZROW + y.ZSEQ)));

            // remove same zcol / zrow 
            for (int i = result.POGGoodsData.Count - 1; i >= 1; i--)
            {
                if (result.POGGoodsData[i].ZCOL == result.POGGoodsData[i - 1].ZCOL
                    && result.POGGoodsData[i].ZROW == result.POGGoodsData[i - 1].ZROW)
                {
                    result.POGGoodsData[i].ZCOL = string.Empty;
                    result.POGGoodsData[i].ZROW = string.Empty;
                }
            }

            return result;
        }
    }
}
