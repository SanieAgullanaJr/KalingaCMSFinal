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
    public class GrowthRateController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: GrowthRate
        public ActionResult Index()
        {
            return View(db.PopulationGrowthRates.ToList());
        }

        // GET: GrowthRate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationGrowthRate populationGrowthRate = db.PopulationGrowthRates.Find(id);
            if (populationGrowthRate == null)
            {
                return HttpNotFound();
            }
            return View(populationGrowthRate);
        }
        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }
        // GET: GrowthRate/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            return View(Tuple.Create<PopulationGrowthRate, IEnumerable<vw_GrowthRateByMunicipalityByYear>>(new PopulationGrowthRate(), db.vw_GrowthRateByMunicipalityByYear.ToList()));
        }

        // POST: GrowthRate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "PopGrowthRateID,MunicipalityID,GrowthRate,YearTaken")] PopulationGrowthRate populationGrowthRate)
        {
            if (ModelState.IsValid)
            {
                db.PopulationGrowthRates.Add(populationGrowthRate);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationGrowthRate);
        }

        // GET: GrowthRate/Edit/5
        public ActionResult Edit(int? id)
        {
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationGrowthRate populationGrowthRate = db.PopulationGrowthRates.Find(id);
            if (populationGrowthRate == null)
            {
                return HttpNotFound();
            }
            return View(populationGrowthRate);
        }

        // POST: GrowthRate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopGrowthRateID,MunicipalityID,GrowthRate,YearTaken")] PopulationGrowthRate populationGrowthRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationGrowthRate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationGrowthRate);
        }

        // GET: GrowthRate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationGrowthRate populationGrowthRate = db.PopulationGrowthRates.Find(id);
            if (populationGrowthRate == null)
            {
                return HttpNotFound();
            }
            return View(populationGrowthRate);
        }

        // POST: GrowthRate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationGrowthRate populationGrowthRate = db.PopulationGrowthRates.Find(id);
            db.PopulationGrowthRates.Remove(populationGrowthRate);
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
