using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KalingaCMSFinal.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Errors
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }
    }
}