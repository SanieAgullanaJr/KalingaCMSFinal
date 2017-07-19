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
    public class GainfulWorkersByMajorBusinessOrIndustryController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: GainfulWorkersByMajorBusinessOrIndustry
        public ActionResult Index()
        {
            return View(db.WorkersByMajorIndustries.ToList());
        }

        // GET: GainfulWorkersByMajorBusinessOrIndustry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByMajorIndustry workersByMajorIndustry = db.WorkersByMajorIndustries.Find(id);
            if (workersByMajorIndustry == null)
            {
                return HttpNotFound();
            }
            return View(workersByMajorIndustry);
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

        //MajorBusinesses Dropdown
        public ActionResult MajorBusinessesDD()
        {
            List<ref_MajorBusinessIndustryGroup> MajorBusinesses = db.ref_MajorBusinessIndustryGroup.ToList();
            ViewBag.MajorBusinesses = new SelectList(MajorBusinesses, "MajorBusinessIndustryID", "MajorBusinessIndustryDesc");
            return View();
        }

        // GET: GainfulWorkersByMajorBusinessOrIndustry/Create
        public ActionResult Create()
        {
            AgeGroupDD();
            MajorBusinessesDD();
            GenderDD();
            return View(Tuple.Create<WorkersByMajorIndustry, IEnumerable<vw_ByMajorBusinessOrIndustry>>(new WorkersByMajorIndustry(), db.vw_ByMajorBusinessOrIndustry.ToList()));
        }

        // POST: GainfulWorkersByMajorBusinessOrIndustry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "WorkersMajorIndustryID,MajorBusinessIndustryID,AgeGroupID,GenderID,NumberofPopulation,YearTaken")] WorkersByMajorIndustry workersByMajorIndustry)
        {
            if (ModelState.IsValid)
            {
                db.WorkersByMajorIndustries.Add(workersByMajorIndustry);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(workersByMajorIndustry);
        }

        // GET: GainfulWorkersByMajorBusinessOrIndustry/Edit/5
        public ActionResult Edit(int? id)
        {
            AgeGroupDD();
            MajorBusinessesDD();
            GenderDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByMajorIndustry workersByMajorIndustry = db.WorkersByMajorIndustries.Find(id);
            if (workersByMajorIndustry == null)
            {
                return HttpNotFound();
            }
            return View(workersByMajorIndustry);
        }

        // POST: GainfulWorkersByMajorBusinessOrIndustry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkersMajorIndustryID,MajorBusinessIndustryID,AgeGroupID,GenderID,NumberofPopulation,YearTaken")] WorkersByMajorIndustry workersByMajorIndustry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workersByMajorIndustry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(workersByMajorIndustry);
        }

        // GET: GainfulWorkersByMajorBusinessOrIndustry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersByMajorIndustry workersByMajorIndustry = db.WorkersByMajorIndustries.Find(id);
            if (workersByMajorIndustry == null)
            {
                return HttpNotFound();
            }
            return View(workersByMajorIndustry);
        }

        // POST: GainfulWorkersByMajorBusinessOrIndustry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkersByMajorIndustry workersByMajorIndustry = db.WorkersByMajorIndustries.Find(id);
            db.WorkersByMajorIndustries.Remove(workersByMajorIndustry);
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
