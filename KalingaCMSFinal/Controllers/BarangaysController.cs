using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace KalingaCMSFinal.Controllers
{
    public class BarangaysController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Barangays
        public ActionResult Index()
        {
            return View(db.ref_Barangay.ToList());
        }

        // GET: Barangays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            if (ref_Barangay == null)
            {
                return HttpNotFound();
            }
            return View(ref_Barangay);
        }

        //Country Dropdown
        public ActionResult CountryDD()
        {
            List<ref_Origins> Countries = db.ref_Origins.ToList();
            ViewBag.Countries = new SelectList(Countries, "countryID", "Country");
            return View();
        }

        public JsonResult GetRegionsList(int CountryID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_RegionList> Regions = db.vw_RegionList.Where(x => x.CountryID == CountryID).ToList();
            return Json(Regions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProvinceList(int RegionID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_ProvinceList> Provinces = db.vw_ProvinceList.Where(x => x.RegionID == RegionID).ToList();
            return Json(Provinces, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipalityList(int ProvinceID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_MunicipalityList> Municipalities = db.vw_MunicipalityList.Where(x => x.provinceID == ProvinceID).ToList();
            return Json(Municipalities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Locations(int LocationsID)
        {
            List<Locations> t = new List<Locations>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from ref_Barangay where barangayID = @LocationsID";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@LocationsID", LocationsID);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        Locations tsData = new Locations()
                        {
                            CountryID = dr["countryID"].ToString(),
                            RegionID = dr["RegionID"].ToString(),
                            ProvinceID = dr["provinceID"].ToString(),
                            MunicipalityID = dr["municipalityID"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BarangayTable(int MunicipalityID)
        {
            List<TableData> t = new List<TableData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_BarangayList where MunicipalityID= @MunicipalityID";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@MunicipalityID", MunicipalityID);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        TableData tsData = new TableData()
                        {
                            Region = dr["RegionalDesignation"].ToString(),
                            Province = dr["ProvinceDistrict"].ToString(),
                            Municipality = dr["Municipality"].ToString(),
                            Barangay = dr["Barangay"].ToString(),
                            BarangayID = dr["barangayID"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: Barangays/Create
        public ActionResult Create()
        {
            CountryDD();
            return View(Tuple.Create<ref_Barangay, IEnumerable<vw_BarangayList>>(new ref_Barangay(), db.vw_BarangayList.ToList()));
        }

        // POST: Barangays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "barangayID,countryID,regionID,provinceID,municipalityID,Barangay")] ref_Barangay ref_Barangay)
        {
            if (ModelState.IsValid)
            {
                db.ref_Barangay.Add(ref_Barangay);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_Barangay);
        }

        // GET: Barangays/Edit/5
        public ActionResult Edit(int? id)
        {
            CountryDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            if (ref_Barangay == null)
            {
                return HttpNotFound();
            }
            return View(ref_Barangay);
        }

        // POST: Barangays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "barangayID,countryID,regionID,provinceID,municipalityID,Barangay")] ref_Barangay ref_Barangay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Barangay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_Barangay);
        }

        // GET: Barangays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            if (ref_Barangay == null)
            {
                return HttpNotFound();
            }
            return View(ref_Barangay);
        }

        // POST: Barangays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            db.ref_Barangay.Remove(ref_Barangay);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
