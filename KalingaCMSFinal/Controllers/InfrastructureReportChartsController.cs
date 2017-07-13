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

namespace KalingaCMSFinal.Controllers
{
    public class InfrastructureReportChartsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        //Year Taken Dropdown
        public ActionResult YearTakenIndustry()
        {
            var result = db.vw_EstablishmentByIndustryByYear.ToList();
            List<vw_EstablishmentByIndustryByYear> YearTakenIndustry = result;
            ViewBag.YearTakenIndustry = new SelectList(YearTakenIndustry.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenIrrigation()
        {
            var result = db.vw_StatusOfIrrigationSystemByMunicipalityByYear.ToList();
            List<vw_StatusOfIrrigationSystemByMunicipalityByYear> YearTakenIrrigation = result;
            ViewBag.YearTakenIrrigation = new SelectList(YearTakenIrrigation.Select(m => m.YearTaken).Distinct());
            return View();
        }

        public JsonResult GetMunicipalityList(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_StatusOfIrrigationSystemByMunicipalityByYear> Municipalities = db.vw_StatusOfIrrigationSystemByMunicipalityByYear.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(Municipalities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIndustry(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_EstablishmentByIndustryByYear> Industries = db.vw_EstablishmentByIndustryByYear.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(Industries, JsonRequestBehavior.AllowGet);
        }

        // GET: InfrastructureReportCharts
        public ActionResult Index()
        {
            YearTakenIndustry();
            YearTakenIrrigation();
            return View(Tuple.Create<vw_EstablishmentByIndustryByYear, vw_StatusOfIrrigationSystemByMunicipalityByYear>(new vw_EstablishmentByIndustryByYear(), new vw_StatusOfIrrigationSystemByMunicipalityByYear()));
        }

        public JsonResult ChartData(int YearTaken, string Industry)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_EstablishmentByIndustryByYear where YearTaken = @year and IndustryClassification = @Industry";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@Industry", Industry);
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
                            data = dr["NumberofFirms"].ToString(),
                            data2 = dr["PercentFirms"].ToString(),
                            data3 = dr["Investment"].ToString(),
                            data4 = dr["PercentInvest"].ToString(),
                            data5 = dr["NumberofEmployee"].ToString(),
                            data6 = dr["Distribution"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData1(int YearTaken, string Municipality)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_StatusOfIrrigationSystemByMunicipalityByYear where YearTaken = @year and Municipality = @municipality";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@municipality", Municipality);
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
                            data = dr["AreasIrrigable"].ToString(),
                            data2 = dr["NatlIrrigationSys"].ToString(),
                            data3 = dr["NIAAssisted"].ToString(),
                            data4 = dr["OtherAgency"].ToString(),
                            data5 = dr["PrivateIrrigation"].ToString(),
                            data6 = dr["PumpSystem"].ToString(),
                            data7 = dr["IrrigationDev"].ToString(),
                            data8 = dr["RemainingAreas"].ToString()
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
