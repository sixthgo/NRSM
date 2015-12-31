﻿using System;
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
    public class PlantController : ApiController
    {
         IPlantService PlantService { get; set; }
         IMembershipService MembershipService { get; set; }

         // GET api/storefloor
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         public IEnumerable<Plant> Get(string loginId)
         {
             Member member = MembershipService.GetUserByUserName(loginId).MemberDetail;
             string pernr = member.Empno;

             var result = PlantService.GetAllPlant(loginId, pernr);

             return result;
         }


         public UserInfor Get(string loginId, string x)
         {
             Member member = MembershipService.GetUserByUserName(loginId).MemberDetail;
             string pernr = member.Empno;

             UserInfor user = new UserInfor();

             user.EMPNO = pernr;
             user.WERKS = PlantService.GetWERKS(pernr);

             return user;
         }

         public IEnumerable<UserLinkButton> Get(string loginId, string x, string y)
         {
             var result = PlantService.GetUserLinkButton(loginId);

             return result;
         }

         public IEnumerable<Purg> Get(string purgCode, string x, string y, string z)
         {
             var result = PlantService.GetUserPurgCode(purgCode);

             return result;
         }
    }
}