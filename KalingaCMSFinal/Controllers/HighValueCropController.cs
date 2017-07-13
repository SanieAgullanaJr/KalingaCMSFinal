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
    public class HighValueCropController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: HighValueCrop
        public ActionResult Index()
        {
            return View(db.ref_HighValueCrop.ToList());
        }

        // GET: HighValueCrop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_HighValueCrop ref_HighValueCrop = db.ref_HighValueCrop.Find(id);
            if (ref_HighValueCrop == null)
            {
                return HttpNotFound();
            }
            return View(ref_HighValueCrop);
        }

        // GET: HighValueCrop/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_HighValueCrop, IEnumerable<ref_HighValueCrop>>(new ref_HighValueCrop(), db.ref_HighValueCrop.ToList()));
        }

        // POST: HighValueCrop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "HighValueCropID,HighValueCrop,CropCommodityID")] ref_HighValueCrop ref_HighValueCrop)
        {
            if (ModelState.IsValid)
            {
                db.ref_HighValueCrop.Add(ref_HighValueCrop);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_HighValueCrop);
        }

        // GET: HighValueCrop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_HighValueCrop ref_HighValueCrop = db.ref_HighValueCrop.Find(id);
            if (ref_HighValueCrop == null)
            {
                return HttpNotFound();
            }
            return View(ref_HighValueCrop);
        }

        // POST: HighValueCrop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HighValueCropID,HighValueCrop,CropCommodityID")] ref_HighValueCrop ref_HighValueCrop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_HighValueCrop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_HighValueCrop);
        }

        // GET: HighValueCrop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_HighValueCrop ref_HighValueCrop = db.ref_HighValueCrop.Find(id);
            if (ref_HighValueCrop == null)
            {
                return HttpNotFound();
            }
            return View(ref_HighValueCrop);
        }

        // POST: HighValueCrop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_HighValueCrop ref_HighValueCrop = db.ref_HighValueCrop.Find(id);
            db.ref_HighValueCrop.Remove(ref_HighValueCrop);
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
