using System.Web.Mvc;
using System.Web.Optimization;

namespace Eland.NRSM.Web.Areas.BaaSMng
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
                new { 
                    action = "Index", 
                    id = UrlParameter.Optional
                },
                new string[]{ 
                    "Formular.BaaS.Web.Areas.BaaSMng.Controllers"
                }
            );
            BaaSMngBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}