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
    public class LandCoverClassificationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: LandCoverClassification
        public ActionResult Index()
        {
            return View(db.ref_LandCoverClassification.ToList());
        }

        // GET: LandCoverClassification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LandCoverClassification ref_LandCoverClassification = db.ref_LandCoverClassification.Find(id);
            if (ref_LandCoverClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_LandCoverClassification);
        }

        //Land Cover Classification Dropdown
        public ActionResult MunicipalityDD()
        {
            List<ref_LandCoverClassification> LandCoverClassifications = db.ref_LandCoverClassification.ToList();
            ViewBag.LandCoverClassifications = new SelectList(LandCoverClassifications, "LandCoverClassificationID", "LandCoverClassification");
            return View();
        }

        // GET: LandCoverClassification/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_LandCoverClassification, IEnumerable<ref_LandCoverClassification>>(new ref_LandCoverClassification(), db.ref_LandCoverClassification.ToList()));
        }

        // POST: LandCoverClassification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "LandCoverClassID,LandCoverClassificationDescription")] ref_LandCoverClassification ref_LandCoverClassification)
        {
            if (ModelState.IsValid)
            {
                db.ref_LandCoverClassification.Add(ref_LandCoverClassification);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_LandCoverClassification);
        }

        // GET: LandCoverClassification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LandCoverClassification ref_LandCoverClassification = db.ref_LandCoverClassification.Find(id);
            if (ref_LandCoverClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_LandCoverClassification);
        }

        // POST: LandCoverClassification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LandCoverClassID,LandCoverClassificationDescription")] ref_LandCoverClassification ref_LandCoverClassification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_LandCoverClassification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_LandCoverClassification);
        }

        // GET: LandCoverClassification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LandCoverClassification ref_LandCoverClassification = db.ref_LandCoverClassification.Find(id);
            if (ref_LandCoverClassification == null)
            {
                return HttpNotFound();
            }
            return View(ref_LandCoverClassification);
        }

        // POST: LandCoverClassification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_LandCoverClassification ref_LandCoverClassification = db.ref_LandCoverClassification.Find(id);
            db.ref_LandCoverClassification.Remove(ref_LandCoverClassification);
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
