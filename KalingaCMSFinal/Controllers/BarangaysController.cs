﻿using System;
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
    public class BarangaysController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Barangays
        public ActionResult Index()
        {
            return View(db.ref_Barangay.ToList());
        }

        // GET: Barangays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            if (ref_Barangay == null)
            {
                return HttpNotFound();
            }
            return View(ref_Barangay);
        }

        // GET: Barangays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barangays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "barangayID,countryID,regionID,provinceID,municipalityID,Barangay")] ref_Barangay ref_Barangay)
        {
            if (ModelState.IsValid)
            {
                db.ref_Barangay.Add(ref_Barangay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Barangay);
        }

        // GET: Barangays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            if (ref_Barangay == null)
            {
                return HttpNotFound();
            }
            return View(ref_Barangay);
        }

        // POST: Barangays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "barangayID,countryID,regionID,provinceID,municipalityID,Barangay")] ref_Barangay ref_Barangay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Barangay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Barangay);
        }

        // GET: Barangays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            if (ref_Barangay == null)
            {
                return HttpNotFound();
            }
            return View(ref_Barangay);
        }

        // POST: Barangays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Barangay ref_Barangay = db.ref_Barangay.Find(id);
            db.ref_Barangay.Remove(ref_Barangay);
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