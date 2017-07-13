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
    public class GainfulWorkersByMajorOCcupationGroupController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: GainfulWorkersByMajorOCcupationGroup
        public ActionResult Index()
        {
            return View(db.WorkersByMajorOCcupations.ToList());
        }

        // GET: GainfulWorkersByMajorOCcupationGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByMajorOCcupation workersByMajorOCcupation = db.WorkersByMajorOCcupations.Find(id);
            if (workersByMajorOCcupation == null)
            {
                return HttpNotFound();
            }
            return View(workersByMajorOCcupation);
        }
        //Age Group Dropdown
        public ActionResult AgeGroupDD()
        {
            List<ref_AgeGroup> AgeGroups = db.ref_AgeGroup.ToList();
            ViewBag.AgeGroups = new SelectList(AgeGroups, "AgeGroupID", "AgeGroup");
            return View();
        }

        //Gender Dropdown
        public ActionResult GenderDD()
        {
            List<ref_Gender> Genders = db.ref_Gender.ToList();
            ViewBag.Genders = new SelectList(Genders, "GenderID", "genderDescription");
            return View();
        }

        //MajorOccupationGroup Dropdown
        public ActionResult MajorOccupationGroupDD()
        {
            List<ref_MajorOccupationGroup> MajorOccupationGroups = db.ref_MajorOccupationGroup.ToList();
            ViewBag.MajorOccupationGroups = new SelectList(MajorOccupationGroups, "MajorOccupationID", "MajorOccupationDesc");
            return View();
        }
        // GET: GainfulWorkersByMajorOCcupationGroup/Create
        public ActionResult Create()
        {
            MajorOccupationGroupDD();
            AgeGroupDD();
            GenderDD();
            return View(Tuple.Create<WorkersByMajorOCcupation, IEnumerable<vw_ByMajorOccupationGroup>>(new WorkersByMajorOCcupation(), db.vw_ByMajorOccupationGroup.ToList()));
        }

        // POST: GainfulWorkersByMajorOCcupationGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "WorkersMajorOccupationID,MajorOccupationID,AgeGroupID,GenderID,NumberofPopulation,YearTaken")] WorkersByMajorOCcupation workersByMajorOCcupation)
        {
            if (ModelState.IsValid)
            {
                db.WorkersByMajorOCcupations.Add(workersByMajorOCcupation);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(workersByMajorOCcupation);
        }

        // GET: GainfulWorkersByMajorOCcupationGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            MajorOccupationGroupDD();
            AgeGroupDD();
            GenderDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByMajorOCcupation workersByMajorOCcupation = db.WorkersByMajorOCcupations.Find(id);
            if (workersByMajorOCcupation == null)
            {
                return HttpNotFound();
            }
            return View(workersByMajorOCcupation);
        }

        // POST: GainfulWorkersByMajorOCcupationGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkersMajorOccupationID,MajorOccupationID,AgeGroupID,GenderID,NumberofPopulation,YearTaken")] WorkersByMajorOCcupation workersByMajorOCcupation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workersByMajorOCcupation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(workersByMajorOCcupation);
        }

        // GET: GainfulWorkersByMajorOCcupationGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByMajorOCcupation workersByMajorOCcupation = db.WorkersByMajorOCcupations.Find(id);
            if (workersByMajorOCcupation == null)
            {
                return HttpNotFound();
            }
            return View(workersByMajorOCcupation);
        }

        // POST: GainfulWorkersByMajorOCcupationGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkersByMajorOCcupation workersByMajorOCcupation = db.WorkersByMajorOCcupations.Find(id);
            db.WorkersByMajorOCcupations.Remove(workersByMajorOCcupation);
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
