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

        // GET: Provinces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "provinceID,CountryID,RegionID,ProvinceDistrict,Capital")] ref_Province ref_Province)
        {
            if (ModelState.IsValid)
            {
                db.ref_Province.Add(ref_Province);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Province);
        }

        // GET: Provinces/Edit/5
        public ActionResult Edit(int? id)
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
                return RedirectToAction("Index");
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
