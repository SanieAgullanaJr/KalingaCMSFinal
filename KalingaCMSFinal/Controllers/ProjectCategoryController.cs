using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Controllers.ManageModule
{
    public class ProjectCategoryController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: ProjectCategory
        public ActionResult Index()
        {
            return View(db.ref_ProjectCategory.ToList());
        }

        // GET: ProjectCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ProjectCategory ref_ProjectCategory = db.ref_ProjectCategory.Find(id);
            if (ref_ProjectCategory == null)
            {
                return HttpNotFound();
            }
            return View(ref_ProjectCategory);
        }

        // GET: ProjectCategory/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_ProjectCategory, IEnumerable<ref_ProjectCategory>>(new ref_ProjectCategory(), db.ref_ProjectCategory.ToList()));
        }

        // POST: ProjectCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "ProjCatID,ProjCategoryCode,ProjCategoryDescription")] ref_ProjectCategory ref_ProjectCategory)
        {
            if (ModelState.IsValid)
            {
                db.ref_ProjectCategory.Add(ref_ProjectCategory);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_ProjectCategory);
        }

        // GET: ProjectCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ProjectCategory ref_ProjectCategory = db.ref_ProjectCategory.Find(id);
            if (ref_ProjectCategory == null)
            {
                return HttpNotFound();
            }
            return View(ref_ProjectCategory);
        }

        // POST: ProjectCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind( Include = "ProjCatID,ProjCategoryCode,ProjCategoryDescription")] ref_ProjectCategory ref_ProjectCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_ProjectCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_ProjectCategory);
        }

        // GET: ProjectCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ProjectCategory ref_ProjectCategory = db.ref_ProjectCategory.Find(id);
            if (ref_ProjectCategory == null)
            {
                return HttpNotFound();
            }
            return View(ref_ProjectCategory);
        }

        // POST: ProjectCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_ProjectCategory ref_ProjectCategory = db.ref_ProjectCategory.Find(id);
            db.ref_ProjectCategory.Remove(ref_ProjectCategory);
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
