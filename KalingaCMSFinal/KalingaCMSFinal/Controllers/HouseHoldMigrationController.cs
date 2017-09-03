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
    public class HouseHoldMigrationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: HouseHoldMigration
        public ActionResult Index()
        {
            return View(db.PopulationMigrationRates.ToList());
        }

        // GET: HouseHoldMigration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationMigrationRate populationMigrationRate = db.PopulationMigrationRates.Find(id);
            if (populationMigrationRate == null)
            {
                return HttpNotFound();
            }
            return View(populationMigrationRate);
        }
        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }
        // GET: HouseHoldMigration/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            return View(Tuple.Create<PopulationMigrationRate, IEnumerable<vw_HouseholdMigrationByYear>>(new PopulationMigrationRate(), db.vw_HouseholdMigrationByYear.ToList()));
        }

        // POST: HouseHoldMigration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "PopMigrationID,MunicipalityID,MigratingIN,MigratingINPer,MigratingOUT,MigratingOUTPer,YearTaken")] PopulationMigrationRate populationMigrationRate)
        {
            if (ModelState.IsValid)
            {
                db.PopulationMigrationRates.Add(populationMigrationRate);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationMigrationRate);
        }

        // GET: HouseHoldMigration/Edit/5
        public ActionResult Edit(int? id)
        {
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationMigrationRate populationMigrationRate = db.PopulationMigrationRates.Find(id);
            if (populationMigrationRate == null)
            {
                return HttpNotFound();
            }
            return View(populationMigrationRate);
        }

        // POST: HouseHoldMigration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopMigrationID,MunicipalityID,MigratingIN,MigratingINPer,MigratingOUT,MigratingOUTPer,YearTaken")] PopulationMigrationRate populationMigrationRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationMigrationRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationMigrationRate);
        }

        // GET: HouseHoldMigration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationMigrationRate populationMigrationRate = db.PopulationMigrationRates.Find(id);
            if (populationMigrationRate == null)
            {
                return HttpNotFound();
            }
            return View(populationMigrationRate);
        }

        // POST: HouseHoldMigration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationMigrationRate populationMigrationRate = db.PopulationMigrationRates.Find(id);
            db.PopulationMigrationRates.Remove(populationMigrationRate);
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
