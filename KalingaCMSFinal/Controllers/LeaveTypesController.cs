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
    public class LeaveTypesController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: LeaveTypes
        public ActionResult Index()
        {
            return View(db.ref_LeaveType.ToList());
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LeaveType ref_LeaveType = db.ref_LeaveType.Find(id);
            if (ref_LeaveType == null)
            {
                return HttpNotFound();
            }
            return View(ref_LeaveType);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveTypeID,LeaveTypeCode,LeaveTypeDescription")] ref_LeaveType ref_LeaveType)
        {
            if (ModelState.IsValid)
            {
                db.ref_LeaveType.Add(ref_LeaveType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_LeaveType);
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LeaveType ref_LeaveType = db.ref_LeaveType.Find(id);
            if (ref_LeaveType == null)
            {
                return HttpNotFound();
            }
            return View(ref_LeaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveTypeID,LeaveTypeCode,LeaveTypeDescription")] ref_LeaveType ref_LeaveType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_LeaveType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_LeaveType);
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LeaveType ref_LeaveType = db.ref_LeaveType.Find(id);
            if (ref_LeaveType == null)
            {
                return HttpNotFound();
            }
            return View(ref_LeaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_LeaveType ref_LeaveType = db.ref_LeaveType.Find(id);
            db.ref_LeaveType.Remove(ref_LeaveType);
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
