using Eland.NRSM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Eland.NRSM.Ap.Controllers
{
    public class HomeController : Controller
    {
        public ITemplateService templateService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            List<Core.Domain.Template> list = templateService.Test("ju_minho");

            return View();
        }
    }
}