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
    public class SaleAmountAndStockController : ApiController
    {
        ISaleAmountAndStockService SaleAmountAndStockService { get; set; }

        public SaleAmountAndStock Get(string gubun, string werks, string floor, string cu, string pu, string matnr, string wstaw, string pernr, string date)
        {
            int year;
            int month;
            int day;

            int.TryParse(date.Substring(0, 4), out year);
            int.TryParse(date.Substring(4, 2), out month);
            int.TryParse(date.Substring(6, 2), out day);

            DateTime dt = new DateTime(year, month, day);

            SaleAmountAndStock result = SaleAmountAndStockService.GetSaleAmountAndStock(gubun, werks, floor, cu, pu, matnr, wstaw, pernr, dt);

            return result;
        }
    }
}
