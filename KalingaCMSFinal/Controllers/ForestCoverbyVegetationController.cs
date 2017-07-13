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
    public class ForestCoverbyVegetationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: ForestCoverbyVegetation
        public ActionResult Index()
        {
            return View(db.ForestCoverVegetations.ToList());
        }

        // GET: ForestCoverbyVegetation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForestCoverVegetation forestCoverVegetation = db.ForestCoverVegetations.Find(id);
            if (forestCoverVegetation == null)
            {
                return HttpNotFound();
            }
            return View(forestCoverVegetation);
        }

        //LandCover Dropdown
        public ActionResult LandCoverDD()
        {
            List<ref_LandCoverClassification> LandClassifications = db.ref_LandCoverClassification.ToList();
            ViewBag.LandClassifications = new SelectList(LandClassifications, "LandCoverClassID", "LandCoverClassificationDescription");
            return View();
        }

        // GET: ForestCoverbyVegetation/Create
        public ActionResult Create()
        {
            LandCoverDD();
            return View(Tuple.Create<ForestCoverVegetation, IEnumerable<vw_ForestCoverByVegetationByYear>>(new ForestCoverVegetation(), db.vw_ForestCoverByVegetationByYear.ToList()));
        }

        // POST: ForestCoverbyVegetation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "VegetationID,LandCoverClassID,AreaHectares,Distribution,YearTaken")] ForestCoverVegetation forestCoverVegetation)
        {
            if (ModelState.IsValid)
            {
                db.ForestCoverVegetations.Add(forestCoverVegetation);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(forestCoverVegetation);
        }

        // GET: ForestCoverbyVegetation/Edit/5
        public ActionResult Edit(int? id)
        {
            LandCoverDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForestCoverVegetation forestCoverVegetation = db.ForestCoverVegetations.Find(id);
            if (forestCoverVegetation == null)
            {
                return HttpNotFound();
            }
            return View(forestCoverVegetation);
        }

        // POST: ForestCoverbyVegetation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VegetationID,LandCoverClassID,AreaHectares,Distribution,YearTaken")] ForestCoverVegetation forestCoverVegetation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forestCoverVegetation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(forestCoverVegetation);
        }

        // GET: ForestCoverbyVegetation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForestCoverVegetation forestCoverVegetation = db.ForestCoverVegetations.Find(id);
            if (forestCoverVegetation == null)
            {
                return HttpNotFound();
            }
            return View(forestCoverVegetation);
        }

        // POST: ForestCoverbyVegetation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForestCoverVegetation forestCoverVegetation = db.ForestCoverVegetations.Find(id);
            db.ForestCoverVegetations.Remove(forestCoverVegetation);
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
