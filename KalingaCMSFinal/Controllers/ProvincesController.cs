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
    public class ProvincesController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Provinces
        public ActionResult Index()
        {
            return View(db.ref_Province.ToList());
        }

        // GET: Provinces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Province ref_Province = db.ref_Province.Find(id);
            if (ref_Province == null)
            {
                return HttpNotFound();
            }
            return View(ref_Province);
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
            List<vw_RegionList> Barangays = db.vw_RegionList.Where(x => x.CountryID == CountryID).ToList();
            return Json(Barangays, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Locations(int LocationsID)
        {
            List<Locations> t = new List<Locations>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ProvinceList where provinceID = @LocationsID";
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
                            RegionID = dr["RegionID"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: Provinces/Create
        public ActionResult Create()
        {
            CountryDD();
            return View(Tuple.Create<ref_Province, IEnumerable<vw_ProvinceList>>(new ref_Province(), db.vw_ProvinceList.ToList()));
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "provinceID,CountryID,RegionID,ProvinceDistrict,Capital")] ref_Province ref_Province)
        {
            if (ModelState.IsValid)
            {
                db.ref_Province.Add(ref_Province);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_Province);
        }

        // GET: Provinces/Edit/5
        public ActionResult Edit(int? id)
        {
            CountryDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Province ref_Province = db.ref_Province.Find(id);
            if (ref_Province == null)
            {
                return HttpNotFound();
            }
            return View(ref_Province);
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "provinceID,CountryID,RegionID,ProvinceDistrict,Capital")] ref_Province ref_Province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Province).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_Province);
        }

        // GET: Provinces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Province ref_Province = db.ref_Province.Find(id);
            if (ref_Province == null)
            {
                return HttpNotFound();
            }
            return View(ref_Province);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Province ref_Province = db.ref_Province.Find(id);
            db.ref_Province.Remove(ref_Province);
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
