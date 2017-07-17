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
    [CustomAuthorize(Roles = "AIPAdmin")]
    public class BDIPperMunicipalityController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }
        // GET: BDIPperMunicipality/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            return View(Tuple.Create<ref_BDIPperMunicipality, IEnumerable<vw_BDIPperMunicipality>>(new ref_BDIPperMunicipality(), db.vw_BDIPperMunicipality.ToList()));
        }

        // POST: BDIPperMunicipality/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "BDIPID,MunicipalityID,BDIPMunicipalityCode,BDIPMunicipality")] ref_BDIPperMunicipality ref_BDIPperMunicipality)
        {
            if (ModelState.IsValid)
            {
                db.ref_BDIPperMunicipality.Add(ref_BDIPperMunicipality);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_BDIPperMunicipality);
        }

        // GET: BDIPperMunicipality/Edit/5
        public ActionResult Edit(int? id)
        {
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_BDIPperMunicipality ref_BDIPperMunicipality = db.ref_BDIPperMunicipality.Find(id);
            if (ref_BDIPperMunicipality == null)
            {
                return HttpNotFound();
            }
            return View(ref_BDIPperMunicipality);
        }

        // POST: BDIPperMunicipality/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BDIPID,MunicipalityID,BDIPMunicipalityCode,BDIPMunicipality")] ref_BDIPperMunicipality ref_BDIPperMunicipality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_BDIPperMunicipality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_BDIPperMunicipality);
        }

        // GET: BDIPperMunicipality/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_BDIPperMunicipality ref_BDIPperMunicipality = db.ref_BDIPperMunicipality.Find(id);
            if (ref_BDIPperMunicipality == null)
            {
                return HttpNotFound();
            }
            return View(ref_BDIPperMunicipality);
        }

        // POST: BDIPperMunicipality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_BDIPperMunicipality ref_BDIPperMunicipality = db.ref_BDIPperMunicipality.Find(id);
            db.ref_BDIPperMunicipality.Remove(ref_BDIPperMunicipality);
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
