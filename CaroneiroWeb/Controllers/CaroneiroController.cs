using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaroneiroWeb.Controllers
{
    public class CaroneiroController : Controller
    {
        // GET: Caroneiro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teste()
        {
            return View();
        }
    }
}