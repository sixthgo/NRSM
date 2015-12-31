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
    public class FavoriteController : ApiController
    {
        IFavoriteService FavoriteService { get; set; }

        // GET api/storefloor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<Favorite> Get(string loginId)
        {
            var result = FavoriteService.GetUserFavorite(loginId);
            return result;
        }

        public string Get(int id)
        {
            return "value";
        }

        // POST api/storefloor
        //public void Post([FromBody]string value)
        public void Post(string loginId, Favorite f)
        {
            FavoriteService.AddNewFavorite(loginId, f);
            return;
        }

        // PUT api/storefloor/5
        //public void Put(int id, [FromBody]string value)
        public void Put(string loginId, [FromBody]Favorite f)
        {
            FavoriteService.DeleteFavorite(loginId, f.ProgramCode);
            return;
        }

        // DELETE api/storefloor/5
        //public void Delete(int id)
        public void Delete(string loginId, [FromBody] Favorite f)
        {
            FavoriteService.DeleteFavorite(loginId, f.ProgramCode);
            return;
        }

    }
}
