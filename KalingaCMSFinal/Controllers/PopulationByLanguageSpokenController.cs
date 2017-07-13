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
    public class PopulationByLanguageSpokenController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PopulationByLanguageSpoken
        public ActionResult Index()
        {
            return View(db.PopulationByLanguageSpokens.ToList());
        }

        // GET: PopulationByLanguageSpoken/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByLanguageSpoken populationByLanguageSpoken = db.PopulationByLanguageSpokens.Find(id);
            if (populationByLanguageSpoken == null)
            {
                return HttpNotFound();
            }
            return View(populationByLanguageSpoken);
        }
        //Language Dropdown
        public ActionResult LanguageDD()
        {
            List<ref_LanguageSpoken> Languages = db.ref_LanguageSpoken.ToList();
            ViewBag.Languages = new SelectList(Languages, "LanguageID", "Language");
            return View();
        }
        // GET: PopulationByLanguageSpoken/Create
        public ActionResult Create()
        {
            LanguageDD();
            return View(Tuple.Create<PopulationByLanguageSpoken, IEnumerable<vw_PopulationByLanguageSpokenByYear>>(new PopulationByLanguageSpoken(), db.vw_PopulationByLanguageSpokenByYear.ToList()));
        }

        // POST: PopulationByLanguageSpoken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "PopLanguageID,LanguageID,NumberHousehold,YearTaken")] PopulationByLanguageSpoken populationByLanguageSpoken)
        {
            if (ModelState.IsValid)
            {
                db.PopulationByLanguageSpokens.Add(populationByLanguageSpoken);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(populationByLanguageSpoken);
        }

        // GET: PopulationByLanguageSpoken/Edit/5
        public ActionResult Edit(int? id)
        {
            LanguageDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByLanguageSpoken populationByLanguageSpoken = db.PopulationByLanguageSpokens.Find(id);
            if (populationByLanguageSpoken == null)
            {
                return HttpNotFound();
            }
            return View(populationByLanguageSpoken);
        }

        // POST: PopulationByLanguageSpoken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PopLanguageID,LanguageID,NumberHousehold,YearTaken")] PopulationByLanguageSpoken populationByLanguageSpoken)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populationByLanguageSpoken).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(populationByLanguageSpoken);
        }

        // GET: PopulationByLanguageSpoken/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopulationByLanguageSpoken populationByLanguageSpoken = db.PopulationByLanguageSpokens.Find(id);
            if (populationByLanguageSpoken == null)
            {
                return HttpNotFound();
            }
            return View(populationByLanguageSpoken);
        }

        // POST: PopulationByLanguageSpoken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulationByLanguageSpoken populationByLanguageSpoken = db.PopulationByLanguageSpokens.Find(id);
            db.PopulationByLanguageSpokens.Remove(populationByLanguageSpoken);
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
