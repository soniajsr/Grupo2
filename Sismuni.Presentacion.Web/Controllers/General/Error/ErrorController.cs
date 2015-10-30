using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Controllers.General
{
    public class ErrorController : Controller
    {
        private static string msg;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ErrorSistema(string mensaje)
        {

            ViewBag.Exception = mensaje;
            return View("_Error");

        }
    }
}