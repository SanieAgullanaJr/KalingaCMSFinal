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
    public class SourceOfFundController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: SourceOfFund
        public ActionResult Index()
        {
            return View(db.ref_SourceOfFund.ToList());
        }

        // GET: SourceOfFund/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_SourceOfFund ref_SourceOfFund = db.ref_SourceOfFund.Find(id);
            if (ref_SourceOfFund == null)
            {
                return HttpNotFound();
            }
            return View(ref_SourceOfFund);
        }

        // GET: SourceOfFund/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<ref_SourceOfFund, IEnumerable<ref_SourceOfFund>>(new ref_SourceOfFund(), db.ref_SourceOfFund.ToList()));
        }

        // POST: SourceOfFund/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "SourceFundID,SourceFundCode,SourceFundDescription")] ref_SourceOfFund ref_SourceOfFund)
        {
            if (ModelState.IsValid)
            {
                db.ref_SourceOfFund.Add(ref_SourceOfFund);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_SourceOfFund);
        }

        // GET: SourceOfFund/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_SourceOfFund ref_SourceOfFund = db.ref_SourceOfFund.Find(id);
            if (ref_SourceOfFund == null)
            {
                return HttpNotFound();
            }
            return View(ref_SourceOfFund);
        }

        // POST: SourceOfFund/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SourceFundID,SourceFundCode,SourceFundDescription")] ref_SourceOfFund ref_SourceOfFund)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_SourceOfFund).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_SourceOfFund);
        }

        // GET: SourceOfFund/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_SourceOfFund ref_SourceOfFund = db.ref_SourceOfFund.Find(id);
            if (ref_SourceOfFund == null)
            {
                return HttpNotFound();
            }
            return View(ref_SourceOfFund);
        }

        // POST: SourceOfFund/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_SourceOfFund ref_SourceOfFund = db.ref_SourceOfFund.Find(id);
            db.ref_SourceOfFund.Remove(ref_SourceOfFund);
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
