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
    public class VoluntaryWorkInvolvementController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: VoluntaryWorkInvolvement
        public ActionResult Index()
        {
            return View(db.EmpVolunteers.ToList());
        }

        // GET: VoluntaryWorkInvolvement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            if (empVolunteer == null)
            {
                return HttpNotFound();
            }
            return View(empVolunteer);
        }

        // GET: VoluntaryWorkInvolvement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoluntaryWorkInvolvement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empVolID,empID,OrganizationName,OrganizationAddress,StartDate,EndDate,HoursVolunteered,InvolveTypeID,OrganizationNature")] EmpVolunteer empVolunteer)
        {
            if (ModelState.IsValid)
            {
                db.EmpVolunteers.Add(empVolunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empVolunteer);
        }

        // GET: VoluntaryWorkInvolvement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            if (empVolunteer == null)
            {
                return HttpNotFound();
            }
            return View(empVolunteer);
        }

        // POST: VoluntaryWorkInvolvement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empVolID,empID,OrganizationName,OrganizationAddress,StartDate,EndDate,HoursVolunteered,InvolveTypeID,OrganizationNature")] EmpVolunteer empVolunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empVolunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empVolunteer);
        }

        // GET: VoluntaryWorkInvolvement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            if (empVolunteer == null)
            {
                return HttpNotFound();
            }
            return View(empVolunteer);
        }

        // POST: VoluntaryWorkInvolvement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            db.EmpVolunteers.Remove(empVolunteer);
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
