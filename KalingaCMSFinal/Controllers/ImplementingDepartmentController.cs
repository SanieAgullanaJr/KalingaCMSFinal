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
    public class ImplementingDepartmentController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: ImplementingDepartment
        public ActionResult Index()
        {
            return View(db.ref_ImplementingDepartment.ToList());
        }

        // GET: ImplementingDepartment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ImplementingDepartment ref_ImplementingDepartment = db.ref_ImplementingDepartment.Find(id);
            if (ref_ImplementingDepartment == null)
            {
                return HttpNotFound();
            }
            return View(ref_ImplementingDepartment);
        }

        // GET: ImplementingDepartment/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_ImplementingDepartment, IEnumerable<ref_ImplementingDepartment>>(new ref_ImplementingDepartment(), db.ref_ImplementingDepartment.ToList()));
        }

        // POST: ImplementingDepartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "ImpDeptID,ImpDeptCode,ImpDeptDescription")] ref_ImplementingDepartment ref_ImplementingDepartment)
        {
            if (ModelState.IsValid)
            {
                db.ref_ImplementingDepartment.Add(ref_ImplementingDepartment);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_ImplementingDepartment);
        }

        // GET: ImplementingDepartment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ImplementingDepartment ref_ImplementingDepartment = db.ref_ImplementingDepartment.Find(id);
            if (ref_ImplementingDepartment == null)
            {
                return HttpNotFound();
            }
            return View(ref_ImplementingDepartment);
        }

        // POST: ImplementingDepartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImpDeptID,ImpDeptCode,ImpDeptDescription")] ref_ImplementingDepartment ref_ImplementingDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_ImplementingDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_ImplementingDepartment);
        }

        // GET: ImplementingDepartment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ImplementingDepartment ref_ImplementingDepartment = db.ref_ImplementingDepartment.Find(id);
            if (ref_ImplementingDepartment == null)
            {
                return HttpNotFound();
            }
            return View(ref_ImplementingDepartment);
        }

        // POST: ImplementingDepartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_ImplementingDepartment ref_ImplementingDepartment = db.ref_ImplementingDepartment.Find(id);
            db.ref_ImplementingDepartment.Remove(ref_ImplementingDepartment);
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
