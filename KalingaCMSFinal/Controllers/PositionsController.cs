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
    public class PositionsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Positions
        public ActionResult Index()
        {
            return View(db.ref_Position.ToList());
        }

        // GET: Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Position ref_Position = db.ref_Position.Find(id);
            if (ref_Position == null)
            {
                return HttpNotFound();
            }
            return View(ref_Position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionID,PositionDescription")] ref_Position ref_Position)
        {
            if (ModelState.IsValid)
            {
                db.ref_Position.Add(ref_Position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Position ref_Position = db.ref_Position.Find(id);
            if (ref_Position == null)
            {
                return HttpNotFound();
            }
            return View(ref_Position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionID,PositionDescription")] ref_Position ref_Position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Position ref_Position = db.ref_Position.Find(id);
            if (ref_Position == null)
            {
                return HttpNotFound();
            }
            return View(ref_Position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Position ref_Position = db.ref_Position.Find(id);
            db.ref_Position.Remove(ref_Position);
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
