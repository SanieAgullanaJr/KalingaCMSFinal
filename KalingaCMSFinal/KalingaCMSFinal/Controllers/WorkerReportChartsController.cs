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
    public class WorkerReportChartsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: WorkerReportCharts
        public ActionResult Index()
        {
            YearTakenByMajorIndustryDD();
            YearTakenByOccupationGroupDD();
            return View(Tuple.Create<vw_ByMajorOccupationGroup, vw_ByMajorBusinessOrIndustry>(new vw_ByMajorOccupationGroup(), new vw_ByMajorBusinessOrIndustry()));
        }

        //Year Taken Dropdown
        public ActionResult YearTakenByMajorIndustryDD()
        {
            var result = db.vw_ByMajorBusinessOrIndustry.ToList();
            List<vw_ByMajorBusinessOrIndustry> YearTakenByMajorIndustry = result;
            ViewBag.YearTakenByMajorIndustry = new SelectList(YearTakenByMajorIndustry.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenByOccupationGroupDD()
        {
            var result = db.vw_ByMajorOccupationGroup.ToList();
            List<vw_ByMajorOccupationGroup> YearTakenByOccupationGroup = result;
            ViewBag.YearTakenByOccupationGroup = new SelectList(YearTakenByOccupationGroup.Select(m => m.YearTaken).Distinct());
            return View();
        }

        public JsonResult GetDescription(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var result = db.vw_ByMajorOccupationGroup.Where(x => x.YearTaken == YearTaken).ToList();
            List<vw_ByMajorOccupationGroup> OcuupationDescription = result;
            return Json(OcuupationDescription, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData(string YearTaken, string Description)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ByMajorOccupationGroup where YearTaken = @year AND MajorOccupationID = @Desc AND genderDescription= 'Male' ";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@Desc", Description);
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
                            data = dr["NumberofPopulation"].ToString(),
                            label = dr["AgeGroup"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData1(string YearTaken, string Description)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ByMajorOccupationGroup where YearTaken = @year AND MajorOccupationID = @Desc AND genderDescription= 'Female' ";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@Desc", Description);
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
                            data = dr["NumberofPopulation"].ToString(),
                            label = dr["AgeGroup"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetIndustry(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var result = db.vw_ByMajorBusinessOrIndustry.Where(x => x.YearTaken == YearTaken).ToList();
            List<vw_ByMajorBusinessOrIndustry> BusinessDescription = result;
            return Json(BusinessDescription, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData2(string YearTaken, string Description)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ByMajorBusinessOrIndustry where YearTaken = @year AND MajorBusinessIndustryID = @Desc AND genderDescription= 'Male' ";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@Desc", Description);
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
                            data = dr["NumberofPopulation"].ToString(),
                            label = dr["AgeGroup"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData3(string YearTaken, string Description)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ByMajorBusinessOrIndustry where YearTaken = @year AND MajorBusinessIndustryID = @Desc AND genderDescription= 'Female' ";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@Desc", Description);
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
                            data = dr["NumberofPopulation"].ToString(),
                            label = dr["AgeGroup"].ToString()
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
