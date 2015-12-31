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
    public class MaterialSaveLabelApiController : ApiController
    {
        IMaterialSaveLabelService MaterialSaveLabelService { get; set; }

        public Message Post(MaterialSaveLabel materilsavelabel)
        {
            Message message = new Message();

            message = MaterialSaveLabelService.SaveMaterialLabel(materilsavelabel);

            return message;
        }
    }
}
