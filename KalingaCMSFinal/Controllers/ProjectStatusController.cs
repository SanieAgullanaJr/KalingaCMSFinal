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
    public class ProjectStatusController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: ProjectStatus
        public ActionResult Index()
        {
            return View(db.ref_ProjectStatus.ToList());
        }

        // GET: ProjectStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ProjectStatus ref_ProjectStatus = db.ref_ProjectStatus.Find(id);
            if (ref_ProjectStatus == null)
            {
                return HttpNotFound();
            }
            return View(ref_ProjectStatus);
        }

        // GET: ProjectStatus/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_ProjectStatus, IEnumerable<ref_ProjectStatus>>(new ref_ProjectStatus(), db.ref_ProjectStatus.ToList()));
        }

        // POST: ProjectStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix ="Item1", Include = "ProjStatusID,ProjStatusCode,ProjStatusDescription")] ref_ProjectStatus ref_ProjectStatus)
        {
            if (ModelState.IsValid)
            {
                db.ref_ProjectStatus.Add(ref_ProjectStatus);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_ProjectStatus);
        }

        // GET: ProjectStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ProjectStatus ref_ProjectStatus = db.ref_ProjectStatus.Find(id);
            if (ref_ProjectStatus == null)
            {
                return HttpNotFound();
            }
            return View(ref_ProjectStatus);
        }

        // POST: ProjectStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjStatusID,ProjStatusCode,ProjStatusDescription")] ref_ProjectStatus ref_ProjectStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_ProjectStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_ProjectStatus);
        }

        // GET: ProjectStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ProjectStatus ref_ProjectStatus = db.ref_ProjectStatus.Find(id);
            if (ref_ProjectStatus == null)
            {
                return HttpNotFound();
            }
            return View(ref_ProjectStatus);
        }

        // POST: ProjectStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_ProjectStatus ref_ProjectStatus = db.ref_ProjectStatus.Find(id);
            db.ref_ProjectStatus.Remove(ref_ProjectStatus);
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
