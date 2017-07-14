using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Controllers
{
    public class AgricultureReportChartsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: AgricultureReportCharts
        public ActionResult Index()
        {
            return View();
        }
    }
}
