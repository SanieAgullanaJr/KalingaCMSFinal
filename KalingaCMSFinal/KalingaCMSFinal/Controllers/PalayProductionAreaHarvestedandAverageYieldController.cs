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
    public class PalayProductionAreaHarvestedandAverageYieldController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PalayProductionAreaHarvestedandAverageYield
        public ActionResult Index()
        {
            return View(db.PalayProductions.ToList());
        }

        // GET: PalayProductionAreaHarvestedandAverageYield/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PalayProduction palayProduction = db.PalayProductions.Find(id);
            if (palayProduction == null)
            {
                return HttpNotFound();
            }
            return View(palayProduction);
        }
        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }

        //Method Dropdown
        public ActionResult MethodDD()
        {
            List<ref_Method> Methods = db.ref_Method.ToList();
            ViewBag.Methods = new SelectList(Methods, "MethodID", "Method");
            return View();
        }

        // GET: PalayProductionAreaHarvestedandAverageYield/Create
        public ActionResult Create()
        {
            MethodDD();
            MunicipalityDD();
            return View(Tuple.Create<PalayProduction, IEnumerable<vw_PalayProductionIrrigatedRainfedUpland>>(new PalayProduction(), db.vw_PalayProductionIrrigatedRainfedUpland.ToList()));
        }

        // POST: PalayProductionAreaHarvestedandAverageYield/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "PalayProdID,MunicipalityID,MethodID,AreaHectares,Production,ProdYield,YearTaken")] PalayProduction palayProduction)
        {
            if (ModelState.IsValid)
            {
                db.PalayProductions.Add(palayProduction);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(palayProduction);
        }

        // GET: PalayProductionAreaHarvestedandAverageYield/Edit/5
        public ActionResult Edit(int? id)
        {
            MethodDD();
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PalayProduction palayProduction = db.PalayProductions.Find(id);
            if (palayProduction == null)
            {
                return HttpNotFound();
            }
            return View(palayProduction);
        }

        // POST: PalayProductionAreaHarvestedandAverageYield/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PalayProdID,MunicipalityID,MethodID,AreaHectares,Production,ProdYield,YearTaken")] PalayProduction palayProduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palayProduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(palayProduction);
        }

        // GET: PalayProductionAreaHarvestedandAverageYield/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PalayProduction palayProduction = db.PalayProductions.Find(id);
            if (palayProduction == null)
            {
                return HttpNotFound();
            }
            return View(palayProduction);
        }

        // POST: PalayProductionAreaHarvestedandAverageYield/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PalayProduction palayProduction = db.PalayProductions.Find(id);
            db.PalayProductions.Remove(palayProduction);
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
