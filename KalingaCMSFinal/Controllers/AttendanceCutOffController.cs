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
    public class AttendanceCutOffController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        //AttendanceNo Dropdown
        public ActionResult AttendanceNoDD()
        {
            List<EmpAttendanceMain> AttendanceNumbers = db.EmpAttendanceMains.ToList();
            ViewBag.AttendanceNumbers = new SelectList(AttendanceNumbers, "empAttendanceMainID", "empAttendanceMainID");
            return View();
        }

        // GET: AttendanceCutOff
        public ActionResult Index()
        {
            return View(db.EmpAttendanceMains.ToList());
        }

        // GET: AttendanceCutOff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAttendanceMain empAttendanceMain = db.EmpAttendanceMains.Find(id);
            if (empAttendanceMain == null)
            {
                return HttpNotFound();
            }
            return View(empAttendanceMain);
        }

        // GET: AttendanceCutOff/Create
        public ActionResult Create()
        {
            AttendanceNoDD();
            return View();
        }

        // POST: AttendanceCutOff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empAttendanceMainID,StartDate,EndDate,IsPosted")] EmpAttendanceMain empAttendanceMain)
        {
            empAttendanceMain.IsPosted = true;
            if (ModelState.IsValid)
            {
                db.EmpAttendanceMains.Add(empAttendanceMain);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(empAttendanceMain);
        }

        // GET: AttendanceCutOff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAttendanceMain empAttendanceMain = db.EmpAttendanceMains.Find(id);
            if (empAttendanceMain == null)
            {
                return HttpNotFound();
            }
            return View(empAttendanceMain);
        }

        // POST: AttendanceCutOff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empAttendanceMainID,StartDate,EndDate,IsPosted")] EmpAttendanceMain empAttendanceMain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empAttendanceMain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empAttendanceMain);
        }

        // GET: AttendanceCutOff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpAttendanceMain empAttendanceMain = db.EmpAttendanceMains.Find(id);
            if (empAttendanceMain == null)
            {
                return HttpNotFound();
            }
            return View(empAttendanceMain);
        }

        // POST: AttendanceCutOff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpAttendanceMain empAttendanceMain = db.EmpAttendanceMains.Find(id);
            db.EmpAttendanceMains.Remove(empAttendanceMain);
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
