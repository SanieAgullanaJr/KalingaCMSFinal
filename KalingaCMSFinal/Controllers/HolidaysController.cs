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
    public class HolidaysController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Holidays
        public ActionResult Index()
        {
            return View(db.ref_Holiday.ToList());
        }

        // GET: Holidays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Holiday ref_Holiday = db.ref_Holiday.Find(id);
            if (ref_Holiday == null)
            {
                return HttpNotFound();
            }
            return View(ref_Holiday);
        }

        // GET: Holidays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Holidays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HolidayID,HolidayDescription,HolidayDate,DayTypeID,NoOfHours")] ref_Holiday ref_Holiday)
        {
            if (ModelState.IsValid)
            {
                db.ref_Holiday.Add(ref_Holiday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ref_Holiday);
        }

        // GET: Holidays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Holiday ref_Holiday = db.ref_Holiday.Find(id);
            if (ref_Holiday == null)
            {
                return HttpNotFound();
            }
            return View(ref_Holiday);
        }

        // POST: Holidays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HolidayID,HolidayDescription,HolidayDate,DayTypeID,NoOfHours")] ref_Holiday ref_Holiday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_Holiday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ref_Holiday);
        }

        // GET: Holidays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_Holiday ref_Holiday = db.ref_Holiday.Find(id);
            if (ref_Holiday == null)
            {
                return HttpNotFound();
            }
            return View(ref_Holiday);
        }

        // POST: Holidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_Holiday ref_Holiday = db.ref_Holiday.Find(id);
            db.ref_Holiday.Remove(ref_Holiday);
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
