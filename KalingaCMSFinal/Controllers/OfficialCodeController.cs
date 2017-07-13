using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Controllers.AIP.ManageModule
{
    [Authorize]
    public class OfficialCodeController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: OfficialCode
        public ActionResult Index()
        {
            return View(db.ref_OfficialCode.ToList());
        }

        // GET: OfficialCode/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_OfficialCode ref_OfficialCode = db.ref_OfficialCode.Find(id);
            if (ref_OfficialCode == null)
            {
                return HttpNotFound();
            }
            return View(ref_OfficialCode);
        }

        // GET: OfficialCode/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_OfficialCode, IEnumerable<ref_OfficialCode>>(new ref_OfficialCode(), db.ref_OfficialCode.ToList()));
        }

        // POST: OfficialCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "OfficialCodeID,OfficialCode,OfficialCodeDescription")] ref_OfficialCode ref_OfficialCode)
        {
            if (ModelState.IsValid)
            {
                db.ref_OfficialCode.Add(ref_OfficialCode);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_OfficialCode);
        }

        // GET: OfficialCode/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_OfficialCode ref_OfficialCode = db.ref_OfficialCode.Find(id);
            if (ref_OfficialCode == null)
            {
                return HttpNotFound();
            }
            return View(ref_OfficialCode);
        }

        // POST: OfficialCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfficialCodeID,OfficialCode,OfficialCodeDescription")] ref_OfficialCode ref_OfficialCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_OfficialCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_OfficialCode);
        }

        // GET: OfficialCode/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_OfficialCode ref_OfficialCode = db.ref_OfficialCode.Find(id);
            if (ref_OfficialCode == null)
            {
                return HttpNotFound();
            }
            return View(ref_OfficialCode);
        }

        // POST: OfficialCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_OfficialCode ref_OfficialCode = db.ref_OfficialCode.Find(id);
            db.ref_OfficialCode.Remove(ref_OfficialCode);
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
