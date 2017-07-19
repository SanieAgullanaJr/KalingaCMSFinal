using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Configuration;
using System.Data.SqlClient;
using KalingaCMSFinal.Security;

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SocioEconAdmin,ChartsOnly")]
    public class LiteracyReportChartsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: LiteracyReportCharts
        public ActionResult Index()
        {
            YearTakenHighestEducDD();
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenHighestEducDD()
        {
            var result = db.vw_HouseholdHighestEducationAttained.ToList();
            List<vw_HouseholdHighestEducationAttained> YearTakenHighestEduc = result;
            ViewBag.YearTakenHighestEduc = new SelectList(YearTakenHighestEduc.Select(m => m.YearTaken).Distinct());
            return View();
        }

        public JsonResult ChartData(string YearTaken)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_HouseholdHighestEducationAttained where YearTaken = @year";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        trafficSourceData tsData = new trafficSourceData()
                        {
                            data = dr["MalePopulation"].ToString(),
                            data2 = dr["FemalePopulation"].ToString(),
                            label = dr["HighestEducAttainedDesc"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }
    }
}
