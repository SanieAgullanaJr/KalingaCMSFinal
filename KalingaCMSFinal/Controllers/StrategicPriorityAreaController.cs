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
    public class StrategicPriorityAreaController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: StrategicPriorityArea
        public ActionResult Index()
        {
            return View(db.ref_StrategicPriorityArea.ToList());
        }

        // GET: StrategicPriorityArea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriorityArea ref_StrategicPriorityArea = db.ref_StrategicPriorityArea.Find(id);
            if (ref_StrategicPriorityArea == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriorityArea);
        }

        //Priority Area Dropdown
        public ActionResult PriorityDD()
        {
            List<ref_StrategicPriority> Priority = db.ref_StrategicPriority.ToList();
            ViewBag.Priority = new SelectList(Priority, "StrategicPriorityID", "StrategicPriorityDescription");
            return View();
        }

        // GET: StrategicPriorityArea/Create
        public ActionResult Create()
        {
            PriorityDD();
            return View(Tuple.Create<ref_StrategicPriorityArea, IEnumerable<vw_StrategicPriorityArea>>(new ref_StrategicPriorityArea(), db.vw_StrategicPriorityArea .ToList()));
        }

        // POST: StrategicPriorityArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix= "Item1", Include = "StrategicPriorityAreaID,StrategicPriorityID,StrategicPriorityAreaNo,StrategicPriorityAreaDescription")] ref_StrategicPriorityArea ref_StrategicPriorityArea)
        {
            if (ModelState.IsValid)
            {
                db.ref_StrategicPriorityArea.Add(ref_StrategicPriorityArea);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_StrategicPriorityArea);
        }

        // GET: StrategicPriorityArea/Edit/5
        public ActionResult Edit(int? id)
        {
            PriorityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriorityArea ref_StrategicPriorityArea = db.ref_StrategicPriorityArea.Find(id);
            if (ref_StrategicPriorityArea == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriorityArea);
        }

        // POST: StrategicPriorityArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StrategicPriorityAreaID,StrategicPriorityID,StrategicPriorityAreaNo,StrategicPriorityAreaDescription")] ref_StrategicPriorityArea ref_StrategicPriorityArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_StrategicPriorityArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_StrategicPriorityArea);
        }

        // GET: StrategicPriorityArea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_StrategicPriorityArea ref_StrategicPriorityArea = db.ref_StrategicPriorityArea.Find(id);
            if (ref_StrategicPriorityArea == null)
            {
                return HttpNotFound();
            }
            return View(ref_StrategicPriorityArea);
        }

        // POST: StrategicPriorityArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_StrategicPriorityArea ref_StrategicPriorityArea = db.ref_StrategicPriorityArea.Find(id);
            db.ref_StrategicPriorityArea.Remove(ref_StrategicPriorityArea);
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
