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
    public class HouseHoldPopulation10YearsAndAboveController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: HouseHoldPopulation10YearsAndAbove
        public ActionResult Index()
        {
            return View(db.PopulationLiteracy10YrsAbove.ToList());
        }

        // GET: HouseHoldPopulation10YearsAndAbove/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationLiteracy10YrsAbove populationLiteracy10YrsAbove = db.PopulationLiteracy10YrsAbove.Find(id);
            if (populationLiteracy10YrsAbove == null)
            {
                return HttpNotFound();
            }
            return View(populationLiteracy10YrsAbove);
        }

        //Age Group Dropdown
        public ActionResult AgeGroupDD()
        {
            List<ref_AgeGroup> AgeGroups = db.ref_AgeGroup.ToList();
            ViewBag.AgeGroups = new SelectList(AgeGroups, "AgeGroupID", "AgeGroup");
            return View();
        }

        //Gender Dropdown
        public ActionResult GenderDD()
        {
            List<ref_Gender> Genders = db.ref_Gender.ToList();
            ViewBag.Genders = new SelectList(Genders, "GenderID", "genderDescription");
            return View();
        }

        //Literacy Dropdown
        public ActionResult LiteracyDD()
        {
            List<ref_Literacy> Literacies = db.ref_Literacy.ToList();
            ViewBag.Literacies = new SelectList(Literacies, "LiteracyID", "LiteracyValue");
            return View();
        }

        // GET: HouseHoldPopulation10YearsAndAbove/Create
        public ActionResult Create()
        {
            AgeGroupDD();
            GenderDD();
            LiteracyDD();
            return View(Tuple.Create<PopulationLiteracy10YrsAbove, IEnumerable<vw_HouseholdPopulation10YearsAbove>>(new PopulationLiteracy10YrsAbove(), db.vw_HouseholdPopulation10YearsAbove.ToList()));
        }

        // POST: HouseHoldPopulation10YearsAndAbove/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "PopLiteracyID,AgeGroupID,LiteracyID,GenderID,NumberofPopulation,YearTaken")] PopulationLiteracy10YrsAbove populationLiteracy10YrsAbove)
        {
            if (ModelState.IsValid)
            {
                db.PopulationLiteracy10YrsAbove.Add(populationLiteracy10YrsAbove);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationLiteracy10YrsAbove);
        }

        // GET: HouseHoldPopulation10YearsAndAbove/Edit/5
        public ActionResult Edit(int? id)
        {
            AgeGroupDD();
            GenderDD();
            LiteracyDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationLiteracy10YrsAbove populationLiteracy10YrsAbove = db.PopulationLiteracy10YrsAbove.Find(id);
            if (populationLiteracy10YrsAbove == null)
            {
                return HttpNotFound();
            }
            return View(populationLiteracy10YrsAbove);
        }

        // POST: HouseHoldPopulation10YearsAndAbove/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopLiteracyID,AgeGroupID,LiteracyID,GenderID,NumberofPopulation,YearTaken")] PopulationLiteracy10YrsAbove populationLiteracy10YrsAbove)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationLiteracy10YrsAbove).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationLiteracy10YrsAbove);
        }

        // GET: HouseHoldPopulation10YearsAndAbove/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationLiteracy10YrsAbove populationLiteracy10YrsAbove = db.PopulationLiteracy10YrsAbove.Find(id);
            if (populationLiteracy10YrsAbove == null)
            {
                return HttpNotFound();
            }
            return View(populationLiteracy10YrsAbove);
        }

        // POST: HouseHoldPopulation10YearsAndAbove/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationLiteracy10YrsAbove populationLiteracy10YrsAbove = db.PopulationLiteracy10YrsAbove.Find(id);
            db.PopulationLiteracy10YrsAbove.Remove(populationLiteracy10YrsAbove);
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
