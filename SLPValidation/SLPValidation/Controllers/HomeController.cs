using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLPValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["LoginUser"] = AccountController.GetLoginUser(this);

            return View();
        }

        public ActionResult About()
        {
            ViewData["LoginUser"] = AccountController.GetLoginUser(this);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["LoginUser"] = AccountController.GetLoginUser(this);
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}