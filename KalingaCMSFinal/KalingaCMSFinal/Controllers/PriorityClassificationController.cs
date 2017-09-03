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

namespace KalingaCMSFinal.Controllers.AIP.ManageModule
{
    [CustomAuthorize(Roles = "SuperAdmin,AIPAdmin")]
    public class PriorityClassificationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PriorityClassification
        public ActionResult Index()
        {
            return View(db.ref_StrategicPriorityClassification.ToList());
        }

        // GET: PriorityClassification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriorityClassification ref_StrategicPriorityClassification = db.ref_StrategicPriorityClassification.Find(id);
            if (ref_StrategicPriorityClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriorityClassification);
        }

        // GET: PriorityClassification/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_StrategicPriorityClassification, IEnumerable<ref_StrategicPriorityClassification>>(new ref_StrategicPriorityClassification(), db.ref_StrategicPriorityClassification.ToList()));
        }

        // POST: PriorityClassification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "StratPriorityClassID,StrategicPriorityClassification")] ref_StrategicPriorityClassification ref_StrategicPriorityClassification)
        {
            if (ModelState.IsValid)
            {
                db.ref_StrategicPriorityClassification.Add(ref_StrategicPriorityClassification);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_StrategicPriorityClassification);
        }

        // GET: PriorityClassification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriorityClassification ref_StrategicPriorityClassification = db.ref_StrategicPriorityClassification.Find(id);
            if (ref_StrategicPriorityClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriorityClassification);
        }

        // POST: PriorityClassification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StratPriorityClassID,StrategicPriorityClassification")] ref_StrategicPriorityClassification ref_StrategicPriorityClassification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_StrategicPriorityClassification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_StrategicPriorityClassification);
        }

        // GET: PriorityClassification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriorityClassification ref_StrategicPriorityClassification = db.ref_StrategicPriorityClassification.Find(id);
            if (ref_StrategicPriorityClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriorityClassification);
        }

        // POST: PriorityClassification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_StrategicPriorityClassification ref_StrategicPriorityClassification = db.ref_StrategicPriorityClassification.Find(id);
            db.ref_StrategicPriorityClassification.Remove(ref_StrategicPriorityClassification);
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
