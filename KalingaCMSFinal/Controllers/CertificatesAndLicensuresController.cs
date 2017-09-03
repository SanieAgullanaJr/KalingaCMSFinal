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
    public class CertificatesAndLicensuresController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: CertificatesAndLicensures
        public ActionResult Index()
        {
            return View(db.EmpCertificates.ToList());
        }

        // GET: CertificatesAndLicensures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            if (empCertificate == null)
            {
                return HttpNotFound();
            }
            return View(empCertificate);
        }

        // GET: CertificatesAndLicensures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CertificatesAndLicensures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empCertID,empID,ExamName,Rating,ExamDate,ExamVenue,LicenseNumber,ReleaseDate")] EmpCertificate empCertificate)
        {
            if (ModelState.IsValid)
            {
                db.EmpCertificates.Add(empCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empCertificate);
        }

        // GET: CertificatesAndLicensures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            if (empCertificate == null)
            {
                return HttpNotFound();
            }
            return View(empCertificate);
        }

        // POST: CertificatesAndLicensures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empCertID,empID,ExamName,Rating,ExamDate,ExamVenue,LicenseNumber,ReleaseDate")] EmpCertificate empCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empCertificate);
        }

        // GET: CertificatesAndLicensures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            if (empCertificate == null)
            {
                return HttpNotFound();
            }
            return View(empCertificate);
        }

        // POST: CertificatesAndLicensures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            db.EmpCertificates.Remove(empCertificate);
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
