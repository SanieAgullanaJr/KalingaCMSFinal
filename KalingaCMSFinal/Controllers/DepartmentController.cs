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
    public class DepartmentController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.ref_Department.ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Department ref_Department = db.ref_Department.Find(id);
            if (ref_Department == null)
            {
                return HttpNotFound();
            }
            return View(ref_Department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_Department, IEnumerable<ref_Department>>(new ref_Department(), db.ref_Department.ToList()));
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "DeptID,DeptCode,DeptDescription")] ref_Department ref_Department)
        {
            if (ModelState.IsValid)
            {
                db.ref_Department.Add(ref_Department);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_Department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Department ref_Department = db.ref_Department.Find(id);
            if (ref_Department == null)
            {
                return HttpNotFound();
            }
            return View(ref_Department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptID,DeptCode,DeptDescription")] ref_Department ref_Department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_Department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Department ref_Department = db.ref_Department.Find(id);
            if (ref_Department == null)
            {
                return HttpNotFound();
            }
            return View(ref_Department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Department ref_Department = db.ref_Department.Find(id);
            db.ref_Department.Remove(ref_Department);
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
