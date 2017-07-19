using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Collections;
using System.Web.Helpers;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using KalingaCMSFinal.Security;

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SocioEconAdmin")]
    public class PopulationReportChartsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PopulationReportCharts
        public ActionResult Index()
        {
            YearTakenDensityDD();
            YearTakenHouseholdMigrationDD();
            YearTakenPopulationDistributionDD();
            YearTakenGrowthRateDD();
            YearTakenReligionDD();
            YearTakenCitizenshipDD();
            return View();
        }


        //Year Taken Dropdown
        public ActionResult YearTakenPopulationDistributionDD()
        {
            var result = db.rep_PopulationDistributionByYearByMunicipality.ToList();
            List <rep_PopulationDistributionByYearByMunicipality> YearTakenPopulationDistribution = result;
            ViewBag.YearTakenPopulationDistribution = new SelectList(YearTakenPopulationDistribution.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenGrowthRateDD()
        {
            var result = db.vw_GrowthRateByMunicipalityByYear.ToList();
            List<vw_GrowthRateByMunicipalityByYear> YearTakenGrowthRate = result;
            ViewBag.YearTakenGrowthRate = new SelectList(YearTakenGrowthRate.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenDensityDD()
        {
            var result = db.vw_PopulationDensityByMunicipalityByYear.ToList();
            List<vw_PopulationDensityByMunicipalityByYear> YearTakenDensity = result;
            ViewBag.YearTakenDensity = new SelectList(YearTakenDensity.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenHouseholdMigrationDD()
        {
            var result = db.vw_HouseholdMigrationByYear.ToList();
            List<vw_HouseholdMigrationByYear> YearTakenHouseholdMigration = result;
            ViewBag.YearTakenHouseholdMigration = new SelectList(YearTakenHouseholdMigration.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenReligionDD()
        {
            var result = db.vw_ReligiousAffiliation.ToList();
            List<vw_ReligiousAffiliation> YearTakenReligion = result;
            ViewBag.YearTakenReligion = new SelectList(YearTakenReligion.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Year Taken Dropdown
        public ActionResult YearTakenCitizenshipDD()
        {
            var result = db.vw_HouseholdPopulationByCitizenshipAndSex.ToList();
            List<vw_HouseholdPopulationByCitizenshipAndSex> YearTakenCitizenship = result;
            ViewBag.YearTakenCitizenship = new SelectList(YearTakenCitizenship.Select(m => m.YearTaken).Distinct());
            return View();
        }

        public JsonResult GetMunicipalityList(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_HouseholdMigrationByYear> Barangays = db.vw_HouseholdMigrationByYear.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(Barangays, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ChartData(int YearTaken)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from rep_PopulationDistributionByYearByMunicipality where YearTaken = @year";
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
                            data = dr["PopulationDistribution"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData1(int YearTaken)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_GrowthRateByMunicipalityByYear where YearTaken = @year";
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
                            data = dr["GrowthRate"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData2(int YearTaken)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_PopulationDensityByMunicipalityByYear where YearTaken = @year";
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
                            data = dr["PopulationPerArea"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData3(string YearTaken, string Municipality)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_HouseholdMigrationByYear where YearTaken = @year AND Municipality = @Municipality";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@Municipality", Municipality);
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
                            data = dr["MigratingINPer"].ToString(),
                            data2 = dr["MigratingOUTPer"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData4(string YearTaken)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ReligiousAffiliation where YearTaken = @year";
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
                            data = dr["NumberofHouseholds"].ToString(),
                            label = dr["religionDescription"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData5(string YearTaken)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_HouseholdPopulationByCitizenshipAndSex where YearTaken = @year AND genderDescription = 'Male'";
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
                            data = dr["NumberofHousehold"].ToString(),
                            label = dr["Nationality"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChartData6(string YearTaken)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_HouseholdPopulationByCitizenshipAndSex where YearTaken = @year AND genderDescription = 'Female'";
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
                            data = dr["NumberofHousehold"].ToString(),
                            label = dr["Nationality"].ToString()
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
