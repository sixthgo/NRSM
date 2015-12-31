using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Formular.BaaS.Domain;
using Formular.BaaS.Service;
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
    public class AccumulateSalesController : ApiController
    {
        IAccumulateSalesService AccumulateSalesService { get; set; }
        IMembershipService MembershipService { get; set; }
        // GET api/currenttimesales
        //public IEnumerable<CurrentTimeSales> Get()
        //public IEnumerable<CurrentBaseType> Get()
        //{
        //return CurrentTimeSalesService.QuerySalesRevenueIn("1", "", "", "", "", "", "10151795");
        //    return CurrentTimeSalesService.QuerySalesRevenueInIdByResultCurrentList("1", "", "", "", "", "", "10151795").Salesdata;
        //}

        // GET api/currenttimesales/5
        public ResultAccumulateList /* IEnumerable<EventBaseType>*/ Get([FromUri]string gubun = "", [FromUri]string plantCode = "", [FromUri]string yearMonth = "", [FromUri]string categoryUnit = "", [FromUri]string purchaseGroup = "", [FromUri]string brandCode = "", [FromUri]string personNumber = "")
        {
            ////string gubunField;

            ////if (gubun == "total")
            ////    gubunField = "1";
            ////else if (gubun == "real")
            ////    gubunField = "2";
            ////else
            ////    gubunField = "3";

            //string yearMonthField = DateTime.Now.ToString("yyyy") + Int32.Parse(yearMonth).ToString("D2");

            string loginId = personNumber;
            Member member = MembershipService.GetUserByUserName(loginId).MemberDetail;

            string newYearMonth = String.IsNullOrEmpty(yearMonth) ? DateTime.Today.AddDays(-1).ToString("yyyyMM") : yearMonth;

            //yearMonth = DateTime.Today.AddDays(-1).ToString("yyyyMM");

            return AccumulateSalesService.QuerySalesResultIn(gubun, plantCode, newYearMonth, categoryUnit, purchaseGroup, brandCode, member.Empno);
        }

        // POST api/currenttimesales
        public void Post([FromBody]string value)
        {
        }

        // PUT api/currenttimesales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/currenttimesales/5
        public void Delete(int id)
        {
        }
    }
}
