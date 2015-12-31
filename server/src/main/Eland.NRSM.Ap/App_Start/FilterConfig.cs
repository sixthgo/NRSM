using System.Web;
using System.Web.Mvc;

namespace Eland.NRSM.Ap
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
