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
    public class TrainingsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Trainings
        public ActionResult Index()
        {
            return View(db.EmpTrainings.ToList());
        }

        // GET: Trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            if (empTraining == null)
            {
                return HttpNotFound();
            }
            return View(empTraining);
        }

        // GET: Trainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empTrainID,empID,TrainingTitle,StartDate,EndDate,DurationHours,EventSponsor,EventVenue")] EmpTraining empTraining)
        {
            if (ModelState.IsValid)
            {
                db.EmpTrainings.Add(empTraining);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empTraining);
        }

        // GET: Trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            if (empTraining == null)
            {
                return HttpNotFound();
            }
            return View(empTraining);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empTrainID,empID,TrainingTitle,StartDate,EndDate,DurationHours,EventSponsor,EventVenue")] EmpTraining empTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empTraining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empTraining);
        }

        // GET: Trainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            if (empTraining == null)
            {
                return HttpNotFound();
            }
            return View(empTraining);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            db.EmpTrainings.Remove(empTraining);
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
