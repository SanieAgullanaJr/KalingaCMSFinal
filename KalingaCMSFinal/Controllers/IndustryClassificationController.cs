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

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SocioEconAdmin")]
    public class IndustryClassificationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: IndustryClassification
        public ActionResult Index()
        {
            return View(db.ref_IndustryClassification.ToList());
        }

        // GET: IndustryClassification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_IndustryClassification ref_IndustryClassification = db.ref_IndustryClassification.Find(id);
            if (ref_IndustryClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_IndustryClassification);
        }

        // GET: IndustryClassification/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_IndustryClassification, IEnumerable<ref_IndustryClassification>>(new ref_IndustryClassification(), db.ref_IndustryClassification.ToList()));
        }

        // POST: IndustryClassification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "IndustryClassID,IndustryClassification")] ref_IndustryClassification ref_IndustryClassification)
        {
            if (ModelState.IsValid)
            {
                db.ref_IndustryClassification.Add(ref_IndustryClassification);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_IndustryClassification);
        }

        // GET: IndustryClassification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_IndustryClassification ref_IndustryClassification = db.ref_IndustryClassification.Find(id);
            if (ref_IndustryClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_IndustryClassification);
        }

        // POST: IndustryClassification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndustryClassID,IndustryClassification")] ref_IndustryClassification ref_IndustryClassification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_IndustryClassification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_IndustryClassification);
        }

        // GET: IndustryClassification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_IndustryClassification ref_IndustryClassification = db.ref_IndustryClassification.Find(id);
            if (ref_IndustryClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_IndustryClassification);
        }

        // POST: IndustryClassification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_IndustryClassification ref_IndustryClassification = db.ref_IndustryClassification.Find(id);
            db.ref_IndustryClassification.Remove(ref_IndustryClassification);
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
