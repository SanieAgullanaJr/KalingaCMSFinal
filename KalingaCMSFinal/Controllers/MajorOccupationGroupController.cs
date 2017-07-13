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
    public class MajorOccupationGroupController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: MajorOccupationGroup
        public ActionResult Index()
        {
            return View(db.ref_MajorOccupationGroup.ToList());
        }

        // GET: MajorOccupationGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_MajorOccupationGroup ref_MajorOccupationGroup = db.ref_MajorOccupationGroup.Find(id);
            if (ref_MajorOccupationGroup == null)
            {
                return HttpNotFound();
            }
            return View(ref_MajorOccupationGroup);
        }

        // GET: MajorOccupationGroup/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_MajorOccupationGroup, IEnumerable<ref_MajorOccupationGroup>>(new ref_MajorOccupationGroup(), db.ref_MajorOccupationGroup.ToList()));
        }

        // POST: MajorOccupationGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "MajorOccupationID,MajorOccupationDesc")] ref_MajorOccupationGroup ref_MajorOccupationGroup)
        {
            if (ModelState.IsValid)
            {
                db.ref_MajorOccupationGroup.Add(ref_MajorOccupationGroup);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_MajorOccupationGroup);
        }

        // GET: MajorOccupationGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_MajorOccupationGroup ref_MajorOccupationGroup = db.ref_MajorOccupationGroup.Find(id);
            if (ref_MajorOccupationGroup == null)
            {
                return HttpNotFound();
            }
            return View(ref_MajorOccupationGroup);
        }

        // POST: MajorOccupationGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Prefix="Item1",Include = "MajorOccupationID,MajorOccupationDesc")] ref_MajorOccupationGroup ref_MajorOccupationGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_MajorOccupationGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_MajorOccupationGroup);
        }

        // GET: MajorOccupationGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_MajorOccupationGroup ref_MajorOccupationGroup = db.ref_MajorOccupationGroup.Find(id);
            if (ref_MajorOccupationGroup == null)
            {
                return HttpNotFound();
            }
            return View(ref_MajorOccupationGroup);
        }

        // POST: MajorOccupationGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_MajorOccupationGroup ref_MajorOccupationGroup = db.ref_MajorOccupationGroup.Find(id);
            db.ref_MajorOccupationGroup.Remove(ref_MajorOccupationGroup);
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
