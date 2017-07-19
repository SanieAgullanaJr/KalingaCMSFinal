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
    public class CornAreaProductionsAndYieldController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: CornAreaProductionsAndYield
        public ActionResult Index()
        {
            return View(db.CornProductions.ToList());
        }

        // GET: CornAreaProductionsAndYield/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CornProduction cornProduction = db.CornProductions.Find(id);
            if (cornProduction == null)
            {
                return HttpNotFound();
            }
            return View(cornProduction);
        }

        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }

        //TypeOfCorn Dropdown
        public ActionResult CornTypeDD()
        {
            List<ref_CornType> Corns = db.ref_CornType.ToList();
            ViewBag.Corns = new SelectList(Corns, "CornID", "Corn");
            return View();
        }

        // GET: CornAreaProductionsAndYield/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            CornTypeDD();
            return View(Tuple.Create<CornProduction, IEnumerable<vw_CornAreaProductionYield>>(new CornProduction(), db.vw_CornAreaProductionYield.ToList()));
        }

        // POST: CornAreaProductionsAndYield/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "CornProdID,MunicipalityID,CornID,AreaHectares,Production,ProdYield,YearTaken")] CornProduction cornProduction)
        {
            if (ModelState.IsValid)
            {
                db.CornProductions.Add(cornProduction);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(cornProduction);
        }

        // GET: CornAreaProductionsAndYield/Edit/5
        public ActionResult Edit(int? id)
        {
            CornTypeDD();
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CornProduction cornProduction = db.CornProductions.Find(id);
            if (cornProduction == null)
            {
                return HttpNotFound();
            }
            return View(cornProduction);
        }

        // POST: CornAreaProductionsAndYield/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CornProdID,MunicipalityID,CornID,AreaHectares,Production,ProdYield,YearTaken")] CornProduction cornProduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cornProduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(cornProduction);
        }

        // GET: CornAreaProductionsAndYield/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CornProduction cornProduction = db.CornProductions.Find(id);
            if (cornProduction == null)
            {
                return HttpNotFound();
            }
            return View(cornProduction);
        }

        // POST: CornAreaProductionsAndYield/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CornProduction cornProduction = db.CornProductions.Find(id);
            db.CornProductions.Remove(cornProduction);
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
