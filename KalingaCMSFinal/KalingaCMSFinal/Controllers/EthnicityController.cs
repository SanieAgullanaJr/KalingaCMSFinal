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
    public class EthnicityController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Ethnicity
        public ActionResult Index()
        {
            return View(db.ref_Ethnicity.ToList());
        }

        // GET: Ethnicity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Ethnicity ref_Ethnicity = db.ref_Ethnicity.Find(id);
            if (ref_Ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ref_Ethnicity);
        }

        // GET: Ethnicity/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_Ethnicity, IEnumerable<ref_Ethnicity>>(new ref_Ethnicity(), db.ref_Ethnicity.ToList()));
        }

        // POST: Ethnicity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EthnicityID,EthnicityDesc")] ref_Ethnicity ref_Ethnicity)
        {
            if (ModelState.IsValid)
            {
                db.ref_Ethnicity.Add(ref_Ethnicity);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_Ethnicity);
        }

        // GET: Ethnicity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Ethnicity ref_Ethnicity = db.ref_Ethnicity.Find(id);
            if (ref_Ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ref_Ethnicity);
        }

        // POST: Ethnicity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EthnicityID,EthnicityDesc")] ref_Ethnicity ref_Ethnicity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Ethnicity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_Ethnicity);
        }

        // GET: Ethnicity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Ethnicity ref_Ethnicity = db.ref_Ethnicity.Find(id);
            if (ref_Ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ref_Ethnicity);
        }

        // POST: Ethnicity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Ethnicity ref_Ethnicity = db.ref_Ethnicity.Find(id);
            db.ref_Ethnicity.Remove(ref_Ethnicity);
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
