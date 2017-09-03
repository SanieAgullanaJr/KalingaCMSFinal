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

        // GET: Municipalities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Municipalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MunicipalityID,countryID,regionID,provinceID,Municipality,zipcode")] ref_Municipality ref_Municipality)
        {
            if (ModelState.IsValid)
            {
                db.ref_Municipality.Add(ref_Municipality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Municipality);
        }

        // GET: Municipalities/Edit/5
        public ActionResult Edit(int? id)
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
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
