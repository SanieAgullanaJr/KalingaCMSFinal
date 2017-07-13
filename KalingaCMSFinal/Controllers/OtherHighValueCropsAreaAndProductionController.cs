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
    public class OtherHighValueCropsAreaAndProductionController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: OtherHighValueCropsAreaAndProduction
        public ActionResult Index()
        {
            return View(db.OtherCropsProductions.ToList());
        }

        // GET: OtherHighValueCropsAreaAndProduction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherCropsProduction otherCropsProduction = db.OtherCropsProductions.Find(id);
            if (otherCropsProduction == null)
            {
                return HttpNotFound();
            }
            return View(otherCropsProduction);
        }

        //OtherCrops Dropdown
        public ActionResult OtherCropsDD()
        {
            List<ref_HighValueCrop> OtherCrops = db.ref_HighValueCrop.ToList();
            ViewBag.OtherCrops = new SelectList(OtherCrops, "HighValueCropID", "HighValueCrop");
            return View();
        }

        // GET: OtherHighValueCropsAreaAndProduction/Create
        public ActionResult Create()
        {
            OtherCropsDD();
            return View(Tuple.Create<OtherCropsProduction, IEnumerable<vw_OtherHighValueCropsAreaAndProduction>>(new OtherCropsProduction(), db.vw_OtherHighValueCropsAreaAndProduction.ToList()));
        }

        // POST: OtherHighValueCropsAreaAndProduction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "OtherCropsProdID,HighValueCropID,AreaHectares,ProdMetricTons,YearTaken")] OtherCropsProduction otherCropsProduction)
        {
            if (ModelState.IsValid)
            {
                db.OtherCropsProductions.Add(otherCropsProduction);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(otherCropsProduction);
        }

        // GET: OtherHighValueCropsAreaAndProduction/Edit/5
        public ActionResult Edit(int? id)
        {
            OtherCropsDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherCropsProduction otherCropsProduction = db.OtherCropsProductions.Find(id);
            if (otherCropsProduction == null)
            {
                return HttpNotFound();
            }
            return View(otherCropsProduction);
        }

        // POST: OtherHighValueCropsAreaAndProduction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OtherCropsProdID,HighValueCropID,AreaHectares,ProdMetricTons,YearTaken")] OtherCropsProduction otherCropsProduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherCropsProduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(otherCropsProduction);
        }

        // GET: OtherHighValueCropsAreaAndProduction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherCropsProduction otherCropsProduction = db.OtherCropsProductions.Find(id);
            if (otherCropsProduction == null)
            {
                return HttpNotFound();
            }
            return View(otherCropsProduction);
        }

        // POST: OtherHighValueCropsAreaAndProduction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherCropsProduction otherCropsProduction = db.OtherCropsProductions.Find(id);
            db.OtherCropsProductions.Remove(otherCropsProduction);
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
