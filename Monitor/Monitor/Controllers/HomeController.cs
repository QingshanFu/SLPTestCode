using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monitor.Models.ActionFilters;

namespace Monitor.Controllers
{
   
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            //throw new Exception("")
            //int i = Convert.ToInt32("s");
            return View();
        }


    }
}
