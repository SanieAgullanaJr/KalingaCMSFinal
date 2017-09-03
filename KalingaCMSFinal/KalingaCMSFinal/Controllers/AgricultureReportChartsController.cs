using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using KalingaCMSFinal.Security;
using System.Configuration;
using System.Data.SqlClient;

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SocioEconAdmin,ChartsOnly")]
    public class AgricultureReportChartsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: AgricultureReportCharts
        public ActionResult Index()
        {
            YearTakenPalayProdDD();
            YearTakenCornProdDD();
            YearTakenLivestockDD();
            YearTakenOtherCropsDD();
            YearTakenForestDD();
            return View();
        }

        //Year Taken PalayProd
        public ActionResult YearTakenPalayProdDD()
        {
            var result = db.vw_PalayProductionIrrigatedRainfedUpland.ToList();
            List<vw_PalayProductionIrrigatedRainfedUpland> YearTakenPalayProd = result;
            ViewBag.YearTakenPalayProd = new SelectList(YearTakenPalayProd.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Methods PalayProd
        public JsonResult PalayProdMethods(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_PalayProductionIrrigatedRainfedUpland> Methods = db.vw_PalayProductionIrrigatedRainfedUpland.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(Methods, JsonRequestBehavior.AllowGet);
        }

        //Year Taken CornProd
        public ActionResult YearTakenCornProdDD()
        {
            var result = db.vw_CornAreaProductionYield.ToList();
            List<vw_CornAreaProductionYield> YearTakenCornProd = result;
            ViewBag.YearTakenCornProd = new SelectList(YearTakenCornProd.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Corn Type CornProd
        public JsonResult CornProdCornType(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_CornAreaProductionYield> CornTypes = db.vw_CornAreaProductionYield.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(CornTypes, JsonRequestBehavior.AllowGet);
        }

        //Year Taken Livestock
        public ActionResult YearTakenLivestockDD()
        {
            var result = db.vw_LivestockAndPoultryInventoryByMunicipalityByYear.ToList();
            List<vw_LivestockAndPoultryInventoryByMunicipalityByYear> YearTakenLivestock = result;
            ViewBag.YearTakenLivestock = new SelectList(YearTakenLivestock.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Livestock Municipalities
        public JsonResult LivestockMunicipalities(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_LivestockAndPoultryInventoryByMunicipalityByYear> Municipalities = db.vw_LivestockAndPoultryInventoryByMunicipalityByYear.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(Municipalities, JsonRequestBehavior.AllowGet);
        }

        //Year Taken OtherCrops
        public ActionResult YearTakenOtherCropsDD()
        {
            var result = db.vw_OtherHighValueCropsAreaAndProduction.ToList();
            List<vw_OtherHighValueCropsAreaAndProduction> YearTakenOtherCrops = result;
            ViewBag.YearTakenOtherCrops = new SelectList(YearTakenOtherCrops.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Livestock OtherCrops
        public JsonResult OtherCropsTypeOfCrop(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_OtherHighValueCropsAreaAndProduction> TypeOfCrops = db.vw_OtherHighValueCropsAreaAndProduction.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(TypeOfCrops, JsonRequestBehavior.AllowGet);
        }

        //Year Taken Forest
        public ActionResult YearTakenForestDD()
        {
            var result = db.vw_ForestCoverByVegetationByYear.ToList();
            List<vw_ForestCoverByVegetationByYear> YearTakenForest = result;
            ViewBag.YearTakenForest = new SelectList(YearTakenForest.Select(m => m.YearTaken).Distinct());
            return View();
        }

        //Forest
        public JsonResult LandCover(string YearTaken)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_ForestCoverByVegetationByYear> ForestCover = db.vw_ForestCoverByVegetationByYear.Where(x => x.YearTaken == YearTaken).ToList();
            return Json(ForestCover, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData(string YearTaken, string Method, string SortBy)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_PalayProductionIrrigatedRainfedUpland where YearTaken = @year AND Method = @Method";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@Method", Method);
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
                            label = dr["Municipality"].ToString(),
                            data = dr[SortBy].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData0(string YearTaken, string SortBy, string CornType)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_CornAreaProductionYield where YearTaken = @year AND Corn = @CornType";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@CornType", CornType);
                cmd.Parameters.AddWithValue("@SortBy", SortBy);
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
                            label = dr["Municipality"].ToString(),
                            data = dr[SortBy].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData1(string YearTaken, string Municipality)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_LivestockAndPoultryInventoryByMunicipalityByYear where YearTaken = @year AND Municipality = @Municipality";
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
                            label = dr["LivestockPoultry"].ToString(),
                            data = dr["NumberofLivestock"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData2(string YearTaken, string CropType)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_OtherHighValueCropsAreaAndProduction where YearTaken = @year AND HighValueCrop = @HighValueCrop";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@HighValueCrop", CropType);
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
                            label = dr["HighValueCrop"].ToString(),
                            data = dr["AreaHectares"].ToString(),
                            data2 = dr["ProdMetricTons"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartData3(string YearTaken, string LandCoverClass)
        {
            List<trafficSourceData> t = new List<trafficSourceData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ForestCoverByVegetationByYear where YearTaken = @year AND LandCoverClassificationDescription = @LandCoverClass";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@year", YearTaken);
                cmd.Parameters.AddWithValue("@LandCoverClass", LandCoverClass);
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
                            data = dr["AreaHectares"].ToString(),
                            data2 = dr["Distribution"].ToString()
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
