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
    public class CoffeeAreaAndProductionController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: CoffeeAreaAndProduction
        public ActionResult Index()
        {
            return View(db.CoffeeProductions.ToList());
        }

        // GET: CoffeeAreaAndProduction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeProduction coffeeProduction = db.CoffeeProductions.Find(id);
            if (coffeeProduction == null)
            {
                return HttpNotFound();
            }
            return View(coffeeProduction);
        }

        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }

        //Coffee Dropdown
        public ActionResult CoffeeDD()
        {
            List<ref_CoffeeType> Coffees = db.ref_CoffeeType.ToList();
            ViewBag.Coffees = new SelectList(Coffees, "CoffeeID", "Coffee");
            return View();
        }

        // GET: CoffeeAreaAndProduction/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            CoffeeDD();
            return View(Tuple.Create<CoffeeProduction, IEnumerable<CoffeeProduction>>(new CoffeeProduction(), db.CoffeeProductions.ToList()));
        }

        // POST: CoffeeAreaAndProduction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "CoffeeProdID,MunicipalityID,CoffeeID,AreaHectares,TotalProd,YearTaken")] CoffeeProduction coffeeProduction)
        {
            if (ModelState.IsValid)
            {
                db.CoffeeProductions.Add(coffeeProduction);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(coffeeProduction);
        }

        // GET: CoffeeAreaAndProduction/Edit/5
        public ActionResult Edit(int? id)
        {
            MunicipalityDD();
            CoffeeDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeProduction coffeeProduction = db.CoffeeProductions.Find(id);
            if (coffeeProduction == null)
            {
                return HttpNotFound();
            }
            return View(coffeeProduction);
        }

        // POST: CoffeeAreaAndProduction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoffeeProdID,MunicipalityID,CoffeeID,AreaHectares,TotalProd,YearTaken")] CoffeeProduction coffeeProduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeProduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(coffeeProduction);
        }

        // GET: CoffeeAreaAndProduction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeProduction coffeeProduction = db.CoffeeProductions.Find(id);
            if (coffeeProduction == null)
            {
                return HttpNotFound();
            }
            return View(coffeeProduction);
        }

        // POST: CoffeeAreaAndProduction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeProduction coffeeProduction = db.CoffeeProductions.Find(id);
            db.CoffeeProductions.Remove(coffeeProduction);
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
