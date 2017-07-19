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
    public class AccountCodeController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: AccountCode
        public ActionResult Index()
        {
            return View(db.vw_AccountCodes.ToList());
        }
        //Sectoral Code Dropdown
        public ActionResult SectoralCodeDD()
        {
            List<DropDown_SectoralCode> SectoralCodes = db.DropDown_SectoralCode.ToList();
            ViewBag.SectoralCodes = new SelectList(SectoralCodes, "FunctionId", "SectoralCode");
            return View();
        }
        //Program Code Dropdown
        public ActionResult ProgramCodeDD()
        {
            List<DropDown_ProgramCode> ProgramCodes = db.DropDown_ProgramCode.ToList();
            ViewBag.ProgramCodes = new SelectList(ProgramCodes, "ProgramId", "ProgramCode");
            return View();
        }
        // GET: AccountCode/Create
        public ActionResult Create()
        {
            SectoralCodeDD();
            ProgramCodeDD();
            return View(Tuple.Create<ref_AccountCode, IEnumerable<vw_AccountCodes>>(new ref_AccountCode(), db.vw_AccountCodes.ToList()));
        }

        // POST: AccountCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "AccountCodeID,FunctionID,ProgramID,AccountCode,AccountDescription")] ref_AccountCode ref_AccountCode)
        {
            if (ModelState.IsValid)
            {
                db.ref_AccountCode.Add(ref_AccountCode);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_AccountCode);
        }

        // GET: AccountCode/Edit/5
        public ActionResult Edit(int? id)
        {
            SectoralCodeDD();
            ProgramCodeDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_AccountCode ref_AccountCode = db.ref_AccountCode.Find(id);
            if (ref_AccountCode == null)
            {
                return HttpNotFound();
            }
            return View(ref_AccountCode);
        }

        // POST: AccountCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountCodeID,FunctionID,ProgramID,AccountCode,AccountDescription")] ref_AccountCode ref_AccountCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_AccountCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_AccountCode);
        }

        // GET: AccountCode/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_AccountCode ref_AccountCode = db.ref_AccountCode.Find(id);
            if (ref_AccountCode == null)
            {
                return HttpNotFound();
            }
            return View(ref_AccountCode);
        }

        // POST: AccountCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_AccountCode ref_AccountCode = db.ref_AccountCode.Find(id);
            db.ref_AccountCode.Remove(ref_AccountCode);
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
