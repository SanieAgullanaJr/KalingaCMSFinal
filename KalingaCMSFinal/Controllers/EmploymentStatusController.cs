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
    public class EmploymentStatusController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: EmploymentStatus
        public ActionResult Index()
        {
            return View(db.ref_AppointmentStatus.ToList());
        }

        // GET: EmploymentStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_AppointmentStatus ref_AppointmentStatus = db.ref_AppointmentStatus.Find(id);
            if (ref_AppointmentStatus == null)
            {
                return HttpNotFound();
            }
            return View(ref_AppointmentStatus);
        }

        // GET: EmploymentStatus/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_AppointmentStatus, IEnumerable<ref_AppointmentStatus>>(new ref_AppointmentStatus(), db.ref_AppointmentStatus.ToList()));
        }

        // POST: EmploymentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "AppointmentStatusID,EmpStatusCode,EmpStatusDescription")] ref_AppointmentStatus ref_AppointmentStatus)
        {
            if (ModelState.IsValid)
            {
                db.ref_AppointmentStatus.Add(ref_AppointmentStatus);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_AppointmentStatus);
        }

        // GET: EmploymentStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_AppointmentStatus ref_AppointmentStatus = db.ref_AppointmentStatus.Find(id);
            if (ref_AppointmentStatus == null)
            {
                return HttpNotFound();
            }
            return View(ref_AppointmentStatus);
        }

        // POST: EmploymentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentStatusID,EmpStatusCode,EmpStatusDescription")] ref_AppointmentStatus ref_AppointmentStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_AppointmentStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_AppointmentStatus);
        }

        // GET: EmploymentStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_AppointmentStatus ref_AppointmentStatus = db.ref_AppointmentStatus.Find(id);
            if (ref_AppointmentStatus == null)
            {
                return HttpNotFound();
            }
            return View(ref_AppointmentStatus);
        }

        // POST: EmploymentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_AppointmentStatus ref_AppointmentStatus = db.ref_AppointmentStatus.Find(id);
            db.ref_AppointmentStatus.Remove(ref_AppointmentStatus);
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
