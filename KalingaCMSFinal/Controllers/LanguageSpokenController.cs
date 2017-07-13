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
    public class LanguageSpokenController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: LanguageSpoken
        public ActionResult Index()
        {
            return View(db.ref_LanguageSpoken.ToList());
        }

        // GET: LanguageSpoken/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LanguageSpoken ref_LanguageSpoken = db.ref_LanguageSpoken.Find(id);
            if (ref_LanguageSpoken == null)
            {
                return HttpNotFound();
            }
            return View(ref_LanguageSpoken);
        }

        // GET: LanguageSpoken/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_LanguageSpoken, IEnumerable<ref_LanguageSpoken>>(new ref_LanguageSpoken(), db.ref_LanguageSpoken.ToList()));
        }

        // POST: LanguageSpoken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "LanguageID,Language")] ref_LanguageSpoken ref_LanguageSpoken)
        {
            if (ModelState.IsValid)
            {
                db.ref_LanguageSpoken.Add(ref_LanguageSpoken);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_LanguageSpoken);
        }

        // GET: LanguageSpoken/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LanguageSpoken ref_LanguageSpoken = db.ref_LanguageSpoken.Find(id);
            if (ref_LanguageSpoken == null)
            {
                return HttpNotFound();
            }
            return View(ref_LanguageSpoken);
        }

        // POST: LanguageSpoken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageID,Language")] ref_LanguageSpoken ref_LanguageSpoken)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_LanguageSpoken).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_LanguageSpoken);
        }

        // GET: LanguageSpoken/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_LanguageSpoken ref_LanguageSpoken = db.ref_LanguageSpoken.Find(id);
            if (ref_LanguageSpoken == null)
            {
                return HttpNotFound();
            }
            return View(ref_LanguageSpoken);
        }

        // POST: LanguageSpoken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_LanguageSpoken ref_LanguageSpoken = db.ref_LanguageSpoken.Find(id);
            db.ref_LanguageSpoken.Remove(ref_LanguageSpoken);
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
