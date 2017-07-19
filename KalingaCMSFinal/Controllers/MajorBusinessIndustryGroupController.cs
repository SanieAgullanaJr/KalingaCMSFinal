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
    public class MajorBusinessIndustryGroupController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: MajorBusinessIndustryGroup
        public ActionResult Index()
        {
            return View(db.ref_MajorBusinessIndustryGroup.ToList());
        }

        // GET: MajorBusinessIndustryGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_MajorBusinessIndustryGroup ref_MajorBusinessIndustryGroup = db.ref_MajorBusinessIndustryGroup.Find(id);
            if (ref_MajorBusinessIndustryGroup == null)
            {
                return HttpNotFound();
            }
            return View(ref_MajorBusinessIndustryGroup);
        }

        // GET: MajorBusinessIndustryGroup/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_MajorBusinessIndustryGroup, IEnumerable<ref_MajorBusinessIndustryGroup>>(new ref_MajorBusinessIndustryGroup(), db.ref_MajorBusinessIndustryGroup.ToList())); ;
        }

        // POST: MajorBusinessIndustryGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "MajorBusinessIndustryID,MajorBusinessIndustryDesc")] ref_MajorBusinessIndustryGroup ref_MajorBusinessIndustryGroup)
        {
            if (ModelState.IsValid)
            {
                db.ref_MajorBusinessIndustryGroup.Add(ref_MajorBusinessIndustryGroup);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_MajorBusinessIndustryGroup);
        }

        // GET: MajorBusinessIndustryGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_MajorBusinessIndustryGroup ref_MajorBusinessIndustryGroup = db.ref_MajorBusinessIndustryGroup.Find(id);
            if (ref_MajorBusinessIndustryGroup == null)
            {
                return HttpNotFound();
            }
            return View(ref_MajorBusinessIndustryGroup);
        }

        // POST: MajorBusinessIndustryGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MajorBusinessIndustryID,MajorBusinessIndustryDesc")] ref_MajorBusinessIndustryGroup ref_MajorBusinessIndustryGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_MajorBusinessIndustryGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_MajorBusinessIndustryGroup);
        }

        // GET: MajorBusinessIndustryGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_MajorBusinessIndustryGroup ref_MajorBusinessIndustryGroup = db.ref_MajorBusinessIndustryGroup.Find(id);
            if (ref_MajorBusinessIndustryGroup == null)
            {
                return HttpNotFound();
            }
            return View(ref_MajorBusinessIndustryGroup);
        }

        // POST: MajorBusinessIndustryGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_MajorBusinessIndustryGroup ref_MajorBusinessIndustryGroup = db.ref_MajorBusinessIndustryGroup.Find(id);
            db.ref_MajorBusinessIndustryGroup.Remove(ref_MajorBusinessIndustryGroup);
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
