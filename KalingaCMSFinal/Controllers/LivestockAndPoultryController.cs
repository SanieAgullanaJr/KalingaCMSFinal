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
    public class LivestockAndPoultryController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: LivestockAndPoultry
        public ActionResult Index()
        {
            return View(db.ref_LivestockPoultry.ToList());
        }

        // GET: LivestockAndPoultry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LivestockPoultry ref_LivestockPoultry = db.ref_LivestockPoultry.Find(id);
            if (ref_LivestockPoultry == null)
            {
                return HttpNotFound();
            }
            return View(ref_LivestockPoultry);
        }

        // GET: LivestockAndPoultry/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_LivestockPoultry, IEnumerable<ref_LivestockPoultry>>(new ref_LivestockPoultry(), db.ref_LivestockPoultry.ToList()));
        }

        // POST: LivestockAndPoultry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "LivestockPoultryID,LivestockPoultry")] ref_LivestockPoultry ref_LivestockPoultry)
        {
            if (ModelState.IsValid)
            {
                db.ref_LivestockPoultry.Add(ref_LivestockPoultry);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_LivestockPoultry);
        }

        // GET: LivestockAndPoultry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LivestockPoultry ref_LivestockPoultry = db.ref_LivestockPoultry.Find(id);
            if (ref_LivestockPoultry == null)
            {
                return HttpNotFound();
            }
            return View(ref_LivestockPoultry);
        }

        // POST: LivestockAndPoultry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivestockPoultryID,LivestockPoultry")] ref_LivestockPoultry ref_LivestockPoultry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_LivestockPoultry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_LivestockPoultry);
        }

        // GET: LivestockAndPoultry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LivestockPoultry ref_LivestockPoultry = db.ref_LivestockPoultry.Find(id);
            if (ref_LivestockPoultry == null)
            {
                return HttpNotFound();
            }
            return View(ref_LivestockPoultry);
        }

        // POST: LivestockAndPoultry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_LivestockPoultry ref_LivestockPoultry = db.ref_LivestockPoultry.Find(id);
            db.ref_LivestockPoultry.Remove(ref_LivestockPoultry);
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
