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

namespace KalingaCMSFinal.Controllers.AIP.ManageModule
{
    [CustomAuthorize(Roles = "AIPAdmin")]
    public class SectorTypeController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: SectorType
        public ActionResult Index()
        {
            return View("~/Views/Dashboard/AIP/SectorType/Create.cshtml");
        }

        // GET: SectorType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Sector ref_Sector = db.ref_Sector.Find(id);
            if (ref_Sector == null)
            {
                return HttpNotFound();
            }
            return View(ref_Sector);
        }

        // GET: SectorType/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_Sector, IEnumerable<ref_Sector>>(new ref_Sector(), db.ref_Sector.ToList()));
        }

        // POST: SectorType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "SectorID,SectorCode,SectorDescription")] ref_Sector ref_Sector)
        {
            if (ModelState.IsValid)
            {
                db.ref_Sector.Add(ref_Sector);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_Sector);
        }

        // GET: SectorType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Sector ref_Sector = db.ref_Sector.Find(id);
            if (ref_Sector == null)
            {
                return HttpNotFound();
            }
            return View(ref_Sector);
        }

        // POST: SectorType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SectorID,SectorCode,SectorDescription")] ref_Sector ref_Sector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Sector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_Sector);
        }

        // GET: SectorType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Sector ref_Sector = db.ref_Sector.Find(id);
            if (ref_Sector == null)
            {
                return HttpNotFound();
            }
            return View(ref_Sector);
        }

        // POST: SectorType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Sector ref_Sector = db.ref_Sector.Find(id);
            db.ref_Sector.Remove(ref_Sector);
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
