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

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SocioEconAdmin")]
    public class ClassOfWorkerController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: ClassOfWorker
        public ActionResult Index()
        {
            return View(db.ref_ClassWorker.ToList());
        }

        // GET: ClassOfWorker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ClassWorker ref_ClassWorker = db.ref_ClassWorker.Find(id);
            if (ref_ClassWorker == null)
            {
                return HttpNotFound();
            }
            return View(ref_ClassWorker);
        }

        // GET: ClassOfWorker/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_ClassWorker, IEnumerable<ref_ClassWorker>>(new ref_ClassWorker(), db.ref_ClassWorker.ToList()));
        }

        // POST: ClassOfWorker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "ClassWorkerID,ClassWorkerDesc")] ref_ClassWorker ref_ClassWorker)
        {
            if (ModelState.IsValid)
            {
                db.ref_ClassWorker.Add(ref_ClassWorker);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_ClassWorker);
        }

        // GET: ClassOfWorker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ClassWorker ref_ClassWorker = db.ref_ClassWorker.Find(id);
            if (ref_ClassWorker == null)
            {
                return HttpNotFound();
            }
            return View(ref_ClassWorker);
        }

        // POST: ClassOfWorker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassWorkerID,ClassWorkerDesc")] ref_ClassWorker ref_ClassWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_ClassWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_ClassWorker);
        }

        // GET: ClassOfWorker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ClassWorker ref_ClassWorker = db.ref_ClassWorker.Find(id);
            if (ref_ClassWorker == null)
            {
                return HttpNotFound();
            }
            return View(ref_ClassWorker);
        }

        // POST: ClassOfWorker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_ClassWorker ref_ClassWorker = db.ref_ClassWorker.Find(id);
            db.ref_ClassWorker.Remove(ref_ClassWorker);
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
