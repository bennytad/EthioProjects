using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRS.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password = "cake")
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            return View();
        }

    }
}
