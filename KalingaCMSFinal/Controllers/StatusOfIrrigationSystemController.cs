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
    public class StatusOfIrrigationSystemController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: StatusOfIrrigationSystem
        public ActionResult Index()
        {
            return View(db.IrrigationSystems.ToList());
        }

        // GET: StatusOfIrrigationSystem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IrrigationSystem irrigationSystem = db.IrrigationSystems.Find(id);
            if (irrigationSystem == null)
            {
                return HttpNotFound();
            }
            return View(irrigationSystem);
        }

        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }

        // GET: StatusOfIrrigationSystem/Create
        public ActionResult Create()
        {
            MunicipalityDD();
            return View(Tuple.Create<IrrigationSystem, IEnumerable<vw_StatusOfIrrigationSystemByMunicipalityByYear>>(new IrrigationSystem(), db.vw_StatusOfIrrigationSystemByMunicipalityByYear.ToList()));
        }

        // POST: StatusOfIrrigationSystem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "IrrigationSysID,MunicipalityID,AreasIrrigable,NatlIrrigationSys,NIAAssisted,OtherAgency,PrivateIrrigation,PumpSystem,IrrigationDev,RemainingAreas,YearTaken")] IrrigationSystem irrigationSystem)
        {
            if (ModelState.IsValid)
            {
                db.IrrigationSystems.Add(irrigationSystem);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(irrigationSystem);
        }

        // GET: StatusOfIrrigationSystem/Edit/5
        public ActionResult Edit(int? id)
        {
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IrrigationSystem irrigationSystem = db.IrrigationSystems.Find(id);
            if (irrigationSystem == null)
            {
                return HttpNotFound();
            }
            return View(irrigationSystem);
        }

        // POST: StatusOfIrrigationSystem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IrrigationSysID,MunicipalityID,AreasIrrigable,NatlIrrigationSys,NIAAssisted,OtherAgency,PrivateIrrigation,PumpSystem,IrrigationDev,RemainingAreas,YearTaken")] IrrigationSystem irrigationSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(irrigationSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(irrigationSystem);
        }

        // GET: StatusOfIrrigationSystem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IrrigationSystem irrigationSystem = db.IrrigationSystems.Find(id);
            if (irrigationSystem == null)
            {
                return HttpNotFound();
            }
            return View(irrigationSystem);
        }

        // POST: StatusOfIrrigationSystem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IrrigationSystem irrigationSystem = db.IrrigationSystems.Find(id);
            db.IrrigationSystems.Remove(irrigationSystem);
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
