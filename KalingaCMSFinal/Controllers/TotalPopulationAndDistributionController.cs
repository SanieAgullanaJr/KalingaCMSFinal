using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Collections;
using System.Web.Helpers;
using KalingaCMSFinal.Security;

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SocioEconAdmin")]
    public class TotalPopulationAndDistributionController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: TotalPopulationAndDistribution
        public ActionResult Index()
        {
            return View(db.PopulationDistributions.ToList());
        }
        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }
        // GET: TotalPopulationAndDistribution/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationDistribution populationDistribution = db.PopulationDistributions.Find(id);
            if (populationDistribution == null)
            {
                return HttpNotFound();
            }
            return View(populationDistribution);
        }

        // GET: TotalPopulationAndDistribution/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            return View(Tuple.Create<PopulationDistribution, IEnumerable<rep_PopulationDistributionByYearByMunicipality>>(new PopulationDistribution(), db.rep_PopulationDistributionByYearByMunicipality.ToList()));
        }

        // POST: TotalPopulationAndDistribution/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "PopDistributionID,MunicipalityID,Population,YearTaken")] PopulationDistribution populationDistribution)
        {
            if (ModelState.IsValid)
            {
                db.PopulationDistributions.Add(populationDistribution);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationDistribution);
        }

        // GET: TotalPopulationAndDistribution/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationDistribution populationDistribution = db.PopulationDistributions.Find(id);
            if (populationDistribution == null)
            {
                return HttpNotFound();
            }
            return View(populationDistribution);
        }

        // POST: TotalPopulationAndDistribution/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopDistributionID,MunicipalityID,Population,YearTaken")] PopulationDistribution populationDistribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationDistribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationDistribution);
        }

        // GET: TotalPopulationAndDistribution/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationDistribution populationDistribution = db.PopulationDistributions.Find(id);
            if (populationDistribution == null)
            {
                return HttpNotFound();
            }
            return View(populationDistribution);
        }

        // POST: TotalPopulationAndDistribution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationDistribution populationDistribution = db.PopulationDistributions.Find(id);
            db.PopulationDistributions.Remove(populationDistribution);
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
