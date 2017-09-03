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
    public class DayTypesController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: DayTypes
        public ActionResult Index()
        {
            return View(db.ref_DayType.ToList());
        }

        // GET: DayTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_DayType ref_DayType = db.ref_DayType.Find(id);
            if (ref_DayType == null)
            {
                return HttpNotFound();
            }
            return View(ref_DayType);
        }

        // GET: DayTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DayTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DayTypeID,DayTypeCode,DayTypeDescription")] ref_DayType ref_DayType)
        {
            if (ModelState.IsValid)
            {
                db.ref_DayType.Add(ref_DayType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_DayType);
        }

        // GET: DayTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_DayType ref_DayType = db.ref_DayType.Find(id);
            if (ref_DayType == null)
            {
                return HttpNotFound();
            }
            return View(ref_DayType);
        }

        // POST: DayTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DayTypeID,DayTypeCode,DayTypeDescription")] ref_DayType ref_DayType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_DayType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_DayType);
        }

        // GET: DayTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_DayType ref_DayType = db.ref_DayType.Find(id);
            if (ref_DayType == null)
            {
                return HttpNotFound();
            }
            return View(ref_DayType);
        }

        // POST: DayTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_DayType ref_DayType = db.ref_DayType.Find(id);
            db.ref_DayType.Remove(ref_DayType);
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
