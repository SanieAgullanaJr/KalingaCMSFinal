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
    public class PopulationByCitizenshipAndSexController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PopulationByCitizenshipAndSex
        public ActionResult Index()
        {
            return View(db.PopulationByCitizenshipGenders.ToList());
        }

        // GET: PopulationByCitizenshipAndSex/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByCitizenshipGender populationByCitizenshipGender = db.PopulationByCitizenshipGenders.Find(id);
            if (populationByCitizenshipGender == null)
            {
                return HttpNotFound();
            }
            return View(populationByCitizenshipGender);
        }

        //Gender Dropdown
        public ActionResult GenderDD()
        {
            List<ref_Gender> Genders = db.ref_Gender.ToList();
            ViewBag.Genders = new SelectList(Genders, "GenderID", "genderDescription");
            return View();
        }

        //Citizenship Dropdown
        public ActionResult NationalitiesDD()
        {
            List<ref_Origins> Nationalities = db.ref_Origins.ToList();
            ViewBag.Nationalities = new SelectList(Nationalities, "CountryID", "Nationality");
            return View();
        }

        // GET: PopulationByCitizenshipAndSex/Create
        public ActionResult Create()
        {
            NationalitiesDD();
            GenderDD();
            return View(Tuple.Create<PopulationByCitizenshipGender, IEnumerable<vw_HouseholdPopulationByCitizenshipAndSex>>(new PopulationByCitizenshipGender(), db.vw_HouseholdPopulationByCitizenshipAndSex.ToList()));
        }

        // POST: PopulationByCitizenshipAndSex/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "PopCitizenSexID,CountryID,GenderID,NumberofHousehold,YearTaken")] PopulationByCitizenshipGender populationByCitizenshipGender)
        {
            if (ModelState.IsValid)
            {
                db.PopulationByCitizenshipGenders.Add(populationByCitizenshipGender);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationByCitizenshipGender);
        }

        // GET: PopulationByCitizenshipAndSex/Edit/5
        public ActionResult Edit(int? id)
        {
            NationalitiesDD();
            GenderDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByCitizenshipGender populationByCitizenshipGender = db.PopulationByCitizenshipGenders.Find(id);
            if (populationByCitizenshipGender == null)
            {
                return HttpNotFound();
            }
            return View(populationByCitizenshipGender);
        }

        // POST: PopulationByCitizenshipAndSex/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopCitizenSexID,CountryID,GenderID,NumberofHousehold,YearTaken")] PopulationByCitizenshipGender populationByCitizenshipGender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationByCitizenshipGender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationByCitizenshipGender);
        }

        // GET: PopulationByCitizenshipAndSex/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByCitizenshipGender populationByCitizenshipGender = db.PopulationByCitizenshipGenders.Find(id);
            if (populationByCitizenshipGender == null)
            {
                return HttpNotFound();
            }
            return View(populationByCitizenshipGender);
        }

        // POST: PopulationByCitizenshipAndSex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationByCitizenshipGender populationByCitizenshipGender = db.PopulationByCitizenshipGenders.Find(id);
            db.PopulationByCitizenshipGenders.Remove(populationByCitizenshipGender);
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
