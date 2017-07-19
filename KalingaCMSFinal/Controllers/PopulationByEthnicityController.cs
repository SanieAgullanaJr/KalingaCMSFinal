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
    public class PopulationByEthnicityController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PopulationByEthnicity
        public ActionResult Index()
        {
            return View(db.PopulationByEthnicities.ToList());
        }

        // GET: PopulationByEthnicity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByEthnicity populationByEthnicity = db.PopulationByEthnicities.Find(id);
            if (populationByEthnicity == null)
            {
                return HttpNotFound();
            }
            return View(populationByEthnicity);
        }
        //Ethnicity Dropdown
        public ActionResult EthnicityDD()
        {
            List<ref_Ethnicity> Ethnicities = db.ref_Ethnicity.ToList();
            ViewBag.Ethnicities = new SelectList(Ethnicities, "EthnicityID", "EthnicityDesc");
            return View();
        }
        // GET: PopulationByEthnicity/Create
        public ActionResult Create()
        {
            EthnicityDD();
            return View(Tuple.Create<PopulationByEthnicity, IEnumerable<vw_PopulationByEthnicity>>(new PopulationByEthnicity(), db.vw_PopulationByEthnicity.ToList()));
        }

        // POST: PopulationByEthnicity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "PopEthnicityID,EthnicityID,NumberofPopulation,YearTaken")] PopulationByEthnicity populationByEthnicity)
        {
            if (ModelState.IsValid)
            {
                db.PopulationByEthnicities.Add(populationByEthnicity);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationByEthnicity);
        }

        // GET: PopulationByEthnicity/Edit/5
        public ActionResult Edit(int? id)
        {
            EthnicityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByEthnicity populationByEthnicity = db.PopulationByEthnicities.Find(id);
            if (populationByEthnicity == null)
            {
                return HttpNotFound();
            }
            return View(populationByEthnicity);
        }

        // POST: PopulationByEthnicity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopEthnicityID,EthnicityID,NumberofPopulation,YearTaken")] PopulationByEthnicity populationByEthnicity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationByEthnicity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationByEthnicity);
        }

        // GET: PopulationByEthnicity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByEthnicity populationByEthnicity = db.PopulationByEthnicities.Find(id);
            if (populationByEthnicity == null)
            {
                return HttpNotFound();
            }
            return View(populationByEthnicity);
        }

        // POST: PopulationByEthnicity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationByEthnicity populationByEthnicity = db.PopulationByEthnicities.Find(id);
            db.PopulationByEthnicities.Remove(populationByEthnicity);
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
