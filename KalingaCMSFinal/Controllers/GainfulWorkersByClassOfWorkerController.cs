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
    public class GainfulWorkersByClassOfWorkerController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: GainfulWorkersByClassOfWorker
        public ActionResult Index()
        {
            return View(db.WorkersByClasses.ToList());
        }

        // GET: GainfulWorkersByClassOfWorker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByClass workersByClass = db.WorkersByClasses.Find(id);
            if (workersByClass == null)
            {
                return HttpNotFound();
            }
            return View(workersByClass);
        }

        //Age Group Dropdown
        public ActionResult AgeGroupDD()
        {
            List<ref_AgeGroup> AgeGroups = db.ref_AgeGroup.ToList();
            ViewBag.AgeGroups = new SelectList(AgeGroups, "AgeGroupID", "AgeGroup");
            return View();
        }

        //Class of Worker Dropdown
        public ActionResult ClassOfWorkerDD()
        {
            List<ref_ClassWorker> ClassOfWorkers = db.ref_ClassWorker.ToList();
            ViewBag.ClassOfWorkers = new SelectList(ClassOfWorkers, "ClassWorkerID", "ClassWorkerDesc");
            return View();
        }

        //Gender Dropdown
        public ActionResult GenderDD()
        {
            List<ref_Gender> Genders = db.ref_Gender.ToList();
            ViewBag.Genders = new SelectList(Genders, "GenderID", "genderDescription");
            return View();
        }

        // GET: GainfulWorkersByClassOfWorker/Create
        public ActionResult Create()
        {
            ClassOfWorkerDD();
            AgeGroupDD();
            GenderDD();
            return View(Tuple.Create<WorkersByClass, IEnumerable<vw_ClassOfWorker>>(new WorkersByClass(), db.vw_ClassOfWorker.ToList()));
        }

        // POST: GainfulWorkersByClassOfWorker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "WorkersByClassID,ClassWorkerID,AgeGroupID,GenderID,NumberofPopulation,YearTaken")] WorkersByClass workersByClass)
        {
            if (ModelState.IsValid)
            {
                db.WorkersByClasses.Add(workersByClass);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(workersByClass);
        }

        // GET: GainfulWorkersByClassOfWorker/Edit/5
        public ActionResult Edit(int? id)
        {
            ClassOfWorkerDD();
            GenderDD();
            AgeGroupDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByClass workersByClass = db.WorkersByClasses.Find(id);
            if (workersByClass == null)
            {
                return HttpNotFound();
            }
            return View(workersByClass);
        }

        // POST: GainfulWorkersByClassOfWorker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkersByClassID,ClassWorkerID,AgeGroupID,GenderID,NumberofPopulation,YearTaken")] WorkersByClass workersByClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workersByClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(workersByClass);
        }

        // GET: GainfulWorkersByClassOfWorker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByClass workersByClass = db.WorkersByClasses.Find(id);
            if (workersByClass == null)
            {
                return HttpNotFound();
            }
            return View(workersByClass);
        }

        // POST: GainfulWorkersByClassOfWorker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkersByClass workersByClass = db.WorkersByClasses.Find(id);
            db.WorkersByClasses.Remove(workersByClass);
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
