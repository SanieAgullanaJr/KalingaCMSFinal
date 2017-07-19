using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Web.Security;
using KalingaCMSFinal.Security;

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SocioEconAdmin")]
    public class PopulationDensityController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PopulationDensity
        public ActionResult Index()
        {
            return View(db.PopulationDensities.ToList());
        }

        // GET: PopulationDensity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationDensity populationDensity = db.PopulationDensities.Find(id);
            if (populationDensity == null)
            {
                return HttpNotFound();
            }
            return View(populationDensity);
        }
        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }
        // GET: PopulationDensity/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            return View(Tuple.Create<PopulationDensity, IEnumerable<vw_PopulationDensityByMunicipalityByYear>>(new PopulationDensity(), db.vw_PopulationDensityByMunicipalityByYear.ToList()));
        }

        // POST: PopulationDensity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "PopDensityID,MunicipalityID,LandArea,PopulationPerArea,YearTaken")] PopulationDensity populationDensity)
        {
            if (ModelState.IsValid)
            {
                db.PopulationDensities.Add(populationDensity);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationDensity);
        }

        // GET: PopulationDensity/Edit/5
        public ActionResult Edit(int? id)
        {
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationDensity populationDensity = db.PopulationDensities.Find(id);
            if (populationDensity == null)
            {
                return HttpNotFound();
            }
            return View(populationDensity);
        }

        // POST: PopulationDensity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopDensityID,MunicipalityID,LandArea,PopulationPerArea,YearTaken")] PopulationDensity populationDensity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationDensity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationDensity);
        }

        // GET: PopulationDensity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationDensity populationDensity = db.PopulationDensities.Find(id);
            if (populationDensity == null)
            {
                return HttpNotFound();
            }
            return View(populationDensity);
        }

        // POST: PopulationDensity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationDensity populationDensity = db.PopulationDensities.Find(id);
            db.PopulationDensities.Remove(populationDensity);
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
