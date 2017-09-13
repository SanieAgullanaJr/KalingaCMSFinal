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
    public class SectionController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Section
        public ActionResult Index()
        {
            return View(db.ref_DepartmentUnit.ToList());
        }

        // GET: Section/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_DepartmentUnit ref_DepartmentUnit = db.ref_DepartmentUnit.Find(id);
            if (ref_DepartmentUnit == null)
            {
                return HttpNotFound();
            }
            return View(ref_DepartmentUnit);
        }

        //Department Dropdown
        public ActionResult DepartmentDD()
        {
            List<ref_Department> Departments = db.ref_Department.ToList();
            ViewBag.Departments = new SelectList(Departments, "DeptID", "DeptDescription");
            return View();
        }

        // GET: Section/Create
        public ActionResult Create()
        {
            DepartmentDD();
            return View(Tuple.Create<ref_DepartmentUnit, IEnumerable<vw_DepartmentUnitsList>>(new ref_DepartmentUnit(), db.vw_DepartmentUnitsList.ToList()));
        }

        // POST: Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "DepartmentUnitID,DeptID,DepartmentUnitCode,DepartmentUnitDescription")] ref_DepartmentUnit ref_DepartmentUnit)
        {
            if (ModelState.IsValid)
            {
                db.ref_DepartmentUnit.Add(ref_DepartmentUnit);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_DepartmentUnit);
        }

        // GET: Section/Edit/5
        public ActionResult Edit(int? id)
        {
            DepartmentDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_DepartmentUnit ref_DepartmentUnit = db.ref_DepartmentUnit.Find(id);
            if (ref_DepartmentUnit == null)
            {
                return HttpNotFound();
            }
            return View(ref_DepartmentUnit);
        }

        // POST: Section/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentUnitID,DeptID,DepartmentUnitCode,DepartmentUnitDescription")] ref_DepartmentUnit ref_DepartmentUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_DepartmentUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_DepartmentUnit);
        }

        // GET: Section/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_DepartmentUnit ref_DepartmentUnit = db.ref_DepartmentUnit.Find(id);
            if (ref_DepartmentUnit == null)
            {
                return HttpNotFound();
            }
            return View(ref_DepartmentUnit);
        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_DepartmentUnit ref_DepartmentUnit = db.ref_DepartmentUnit.Find(id);
            db.ref_DepartmentUnit.Remove(ref_DepartmentUnit);
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
