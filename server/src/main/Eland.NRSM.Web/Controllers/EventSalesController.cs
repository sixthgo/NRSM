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

namespace Eland.NRSM.Web.Controllers
{
    public class EventSalesController : ApiController
    {
        IEventSalesService EventSalesService { get; set; }
        IMembershipService MembershipService { get; set; }
        // GET api/currenttimesales
        //public IEnumerable<CurrentTimeSales> Get()
        //public IEnumerable<CurrentBaseType> Get()
        //{
        //return CurrentTimeSalesService.QuerySalesRevenueIn("1", "", "", "", "", "", "10151795");
        //    return CurrentTimeSalesService.QuerySalesRevenueInIdByResultCurrentList("1", "", "", "", "", "", "10151795").Salesdata;
        //}

        // GET api/currenttimesales/5
        public ResultEventList /* IEnumerable<EventBaseType>*/ Get(string input, string gubun, DateTime date, string plantCode, string layoutCode, string floor, string categoryUnit, string purchaseGroup, string brandCode, string personNumber)
        {
            string inputField;
            if (input == "pda")
                inputField = "A";
            else
                inputField = "B";

            if (gubun != "5")
            {
                categoryUnit = "";
                purchaseGroup = "";
            }

            string loginId = personNumber;
            Member member = MembershipService.GetUserByUserName(loginId).MemberDetail;

            return EventSalesService.QuerySalesRevenueInIdByResultEventList(inputField, gubun, date, plantCode, layoutCode, floor, categoryUnit, purchaseGroup, brandCode, member.Empno);
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
