using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Controllers.AIP.ManageModule
{
    public class StrategicPriorityController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: StrategicPriority
        public ActionResult Index()
        {
            return View(db.ref_StrategicPriority.ToList());
        }

        // GET: StrategicPriority/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriority ref_StrategicPriority = db.ref_StrategicPriority.Find(id);
            if (ref_StrategicPriority == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriority);
        }

        // GET: StrategicPriority/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_StrategicPriority, IEnumerable<ref_StrategicPriority>>(new ref_StrategicPriority(), db.ref_StrategicPriority.ToList()));
        }

        // POST: StrategicPriority/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "StrategicPriorityID,StrategicPriorityNo,StrategicPriorityDescription")] ref_StrategicPriority ref_StrategicPriority)
        {
            if (ModelState.IsValid)
            {
                db.ref_StrategicPriority.Add(ref_StrategicPriority);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_StrategicPriority);
        }

        // GET: StrategicPriority/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriority ref_StrategicPriority = db.ref_StrategicPriority.Find(id);
            if (ref_StrategicPriority == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriority);
        }

        // POST: StrategicPriority/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StrategicPriorityID,StrategicPriorityNo,StrategicPriorityDescription")] ref_StrategicPriority ref_StrategicPriority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_StrategicPriority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_StrategicPriority);
        }

        // GET: StrategicPriority/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriority ref_StrategicPriority = db.ref_StrategicPriority.Find(id);
            if (ref_StrategicPriority == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriority);
        }

        // POST: StrategicPriority/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_StrategicPriority ref_StrategicPriority = db.ref_StrategicPriority.Find(id);
            db.ref_StrategicPriority.Remove(ref_StrategicPriority);
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
