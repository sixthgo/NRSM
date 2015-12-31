using Eland.NRSM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Web.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EIMSInformationApiController : ApiController
    {
        IEIMSInformationService EIMSInformationService { get; set; }

        public IEnumerable<Domain.EIMSInformation> Get(string plant, string budate) 
        {
            var result = EIMSInformationService.GetEIMSInformationDtoList(plant, budate);

            return result;
        }
    }
}
