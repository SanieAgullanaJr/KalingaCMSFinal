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
    public class PopulationByReligiousAffiliationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PopulationByReligiousAffiliation
        public ActionResult Index()
        {
            return View(db.PopulationByReligiousAffiliations.ToList());
        }

        // GET: PopulationByReligiousAffiliation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByReligiousAffiliation populationByReligiousAffiliation = db.PopulationByReligiousAffiliations.Find(id);
            if (populationByReligiousAffiliation == null)
            {
                return HttpNotFound();
            }
            return View(populationByReligiousAffiliation);
        }
        //Religion Dropdown
        public ActionResult ReligionDD()
        {
            List<ref_Religion> Religions = db.ref_Religion.ToList();
            ViewBag.Religions = new SelectList(Religions, "ReligionID", "religionDescription");
            return View();
        }
        // GET: PopulationByReligiousAffiliation/Create
        public ActionResult Create()
        {
            ReligionDD();
            return View(Tuple.Create<PopulationByReligiousAffiliation, IEnumerable<vw_ReligiousAffiliation>>(new PopulationByReligiousAffiliation(), db.vw_ReligiousAffiliation.ToList()));
        }

        // POST: PopulationByReligiousAffiliation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "PopReligionID,ReligionID,NumberofHouseholds,YearTaken")] PopulationByReligiousAffiliation populationByReligiousAffiliation)
        {
            if (ModelState.IsValid)
            {
                db.PopulationByReligiousAffiliations.Add(populationByReligiousAffiliation);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationByReligiousAffiliation);
        }

        // GET: PopulationByReligiousAffiliation/Edit/5
        public ActionResult Edit(int? id)
        {
            ReligionDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByReligiousAffiliation populationByReligiousAffiliation = db.PopulationByReligiousAffiliations.Find(id);
            if (populationByReligiousAffiliation == null)
            {
                return HttpNotFound();
            }
            return View(populationByReligiousAffiliation);
        }

        // POST: PopulationByReligiousAffiliation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopReligionID,ReligionID,NumberofHouseholds,YearTaken")] PopulationByReligiousAffiliation populationByReligiousAffiliation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationByReligiousAffiliation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationByReligiousAffiliation);
        }

        // GET: PopulationByReligiousAffiliation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByReligiousAffiliation populationByReligiousAffiliation = db.PopulationByReligiousAffiliations.Find(id);
            if (populationByReligiousAffiliation == null)
            {
                return HttpNotFound();
            }
            return View(populationByReligiousAffiliation);
        }

        // POST: PopulationByReligiousAffiliation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationByReligiousAffiliation populationByReligiousAffiliation = db.PopulationByReligiousAffiliations.Find(id);
            db.PopulationByReligiousAffiliations.Remove(populationByReligiousAffiliation);
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
