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
    public class MunicipalitiesController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Municipalities
        public ActionResult Index()
        {
            return View(db.ref_Municipality.ToList());
        }

        // GET: Municipalities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Municipality ref_Municipality = db.ref_Municipality.Find(id);
            if (ref_Municipality == null)
            {
                return HttpNotFound();
            }
            return View(ref_Municipality);
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

        public JsonResult Locations(int LocationsID)
        {
            List<Locations> t = new List<Locations>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_MunicipalityList where MunicipalityID = @LocationsID";
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
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MunicipalityTable(int ProvinceID)
        {
            List<TableData> t = new List<TableData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_MunicipalityList where provinceID= @ProvinceID";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@ProvinceID", ProvinceID);
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
                            MunicipalityID = dr["MunicipalityID"].ToString(),
                            ZipCode = dr["zipCode"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: Municipalities/Create
        public ActionResult Create()
        {
            CountryDD();
            return View(Tuple.Create<ref_Municipality, IEnumerable<vw_MunicipalityList>>(new ref_Municipality(), db.vw_MunicipalityList.ToList()));
        }

        // POST: Municipalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "MunicipalityID,countryID,regionID,provinceID,Municipality,zipcode")] ref_Municipality ref_Municipality)
        {
            if (ModelState.IsValid)
            {
                db.ref_Municipality.Add(ref_Municipality);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_Municipality);
        }

        // GET: Municipalities/Edit/5
        public ActionResult Edit(int? id)
        {
            CountryDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Municipality ref_Municipality = db.ref_Municipality.Find(id);
            if (ref_Municipality == null)
            {
                return HttpNotFound();
            }
            return View(ref_Municipality);
        }

        // POST: Municipalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MunicipalityID,countryID,regionID,provinceID,Municipality,zipcode")] ref_Municipality ref_Municipality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Municipality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_Municipality);
        }

        // GET: Municipalities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Municipality ref_Municipality = db.ref_Municipality.Find(id);
            if (ref_Municipality == null)
            {
                return HttpNotFound();
            }
            return View(ref_Municipality);
        }

        // POST: Municipalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Municipality ref_Municipality = db.ref_Municipality.Find(id);
            db.ref_Municipality.Remove(ref_Municipality);
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
