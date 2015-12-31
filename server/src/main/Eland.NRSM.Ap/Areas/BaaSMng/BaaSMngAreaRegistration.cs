using System.Web.Mvc;

namespace Eland.NRSM.Ap.Areas.BaaSMng
{
    public class BaaSMngAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BaaSMng";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BaaSMng_default",
                "BaaSMng/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}