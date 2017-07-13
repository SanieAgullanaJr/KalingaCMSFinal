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
    public class HouseholdHighestEducationAttainedController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: HouseholdHighestEducationAttained
        public ActionResult Index()
        {
            return View(db.PopulationHighestEducationAttaineds.ToList());
        }

        // GET: HouseholdHighestEducationAttained/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationHighestEducationAttained populationHighestEducationAttained = db.PopulationHighestEducationAttaineds.Find(id);
            if (populationHighestEducationAttained == null)
            {
                return HttpNotFound();
            }
            return View(populationHighestEducationAttained);
        }

        //HighestEducationAttained Dropdown
        public ActionResult HighestEducationAttainedDD()
        {
            List<ref_HighestEducationAttained> Educations = db.ref_HighestEducationAttained.ToList();
            ViewBag.Educations = new SelectList(Educations, "HighestEducAttainedID", "HighestEducAttainedDesc");
            return View();
        }

        // GET: HouseholdHighestEducationAttained/Create
        public ActionResult Create()
        {
            HighestEducationAttainedDD();
            return View(Tuple.Create<PopulationHighestEducationAttained, IEnumerable<vw_HouseholdHighestEducationAttained>>(new PopulationHighestEducationAttained(), db.vw_HouseholdHighestEducationAttained.ToList()));
        }

        // POST: HouseholdHighestEducationAttained/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "PopEducationAttainedID,HighestEducAttainedID,MalePopulation,FemalePopulation,YearTaken")] PopulationHighestEducationAttained populationHighestEducationAttained)
        {
            if (ModelState.IsValid)
            {
                db.PopulationHighestEducationAttaineds.Add(populationHighestEducationAttained);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationHighestEducationAttained);
        }

        // GET: HouseholdHighestEducationAttained/Edit/5
        public ActionResult Edit(int? id)
        {
            HighestEducationAttainedDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationHighestEducationAttained populationHighestEducationAttained = db.PopulationHighestEducationAttaineds.Find(id);
            if (populationHighestEducationAttained == null)
            {
                return HttpNotFound();
            }
            return View(populationHighestEducationAttained);
        }

        // POST: HouseholdHighestEducationAttained/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopEducationAttainedID,HighestEducAttainedID,MalePopulation,FemalePopulation,YearTaken")] PopulationHighestEducationAttained populationHighestEducationAttained)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationHighestEducationAttained).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationHighestEducationAttained);
        }

        // GET: HouseholdHighestEducationAttained/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationHighestEducationAttained populationHighestEducationAttained = db.PopulationHighestEducationAttaineds.Find(id);
            if (populationHighestEducationAttained == null)
            {
                return HttpNotFound();
            }
            return View(populationHighestEducationAttained);
        }

        // POST: HouseholdHighestEducationAttained/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationHighestEducationAttained populationHighestEducationAttained = db.PopulationHighestEducationAttaineds.Find(id);
            db.PopulationHighestEducationAttaineds.Remove(populationHighestEducationAttained);
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
