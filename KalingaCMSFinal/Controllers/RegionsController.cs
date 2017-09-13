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
    public class RegionsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Regions
        public ActionResult Index()
        {
            return View(db.ref_Regions.ToList());
        }

        // GET: Regions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Regions ref_Regions = db.ref_Regions.Find(id);
            if (ref_Regions == null)
            {
                return HttpNotFound();
            }
            return View(ref_Regions);
        }

        //Country Dropdown
        public ActionResult CountryDD()
        {
            List<ref_Origins> Countries = db.ref_Origins.ToList();
            ViewBag.Countries = new SelectList(Countries, "countryID", "Country");
            return View();
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            CountryDD();
            return View(Tuple.Create<ref_Regions, IEnumerable<vw_RegionList>>(new ref_Regions(), db.vw_RegionList.ToList()));
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "regionID,CountryID,RegionName,RegionalDesignation")] ref_Regions ref_Regions)
        {
            if (ModelState.IsValid)
            {
                db.ref_Regions.Add(ref_Regions);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_Regions);
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(int? id)
        {
            CountryDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Regions ref_Regions = db.ref_Regions.Find(id);
            if (ref_Regions == null)
            {
                return HttpNotFound();
            }
            return View(ref_Regions);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "regionID,CountryID,RegionName,RegionalDesignation")] ref_Regions ref_Regions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Regions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_Regions);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Regions ref_Regions = db.ref_Regions.Find(id);
            if (ref_Regions == null)
            {
                return HttpNotFound();
            }
            return View(ref_Regions);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Regions ref_Regions = db.ref_Regions.Find(id);
            db.ref_Regions.Remove(ref_Regions);
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
