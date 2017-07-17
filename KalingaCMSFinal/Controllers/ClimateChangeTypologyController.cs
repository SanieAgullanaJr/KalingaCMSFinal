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

namespace KalingaCMSFinal.Controllers.AIP_Controllers
{
    [CustomAuthorize(Roles = "AIPAdmin")]
    public class ClimateChangeTypologyController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: CliimateChangeTypology
        public ActionResult Index()
        {
            return View(db.ref_ClimateChangeTypology.ToList());
        }

        // GET: CliimateChangeTypology/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ClimateChangeTypology ref_ClimateChangeTypology = db.ref_ClimateChangeTypology.Find(id);
            if (ref_ClimateChangeTypology == null)
            {
                return HttpNotFound();
            }
            return View(ref_ClimateChangeTypology);
        }

        //Typology Code Dropdown
        public ActionResult TypologyCodeDD()
        {
            List<DropDown_TypologyCode> TypologyCodes = db.DropDown_TypologyCode.ToList();
            ViewBag.TypologyCodes = new SelectList(TypologyCodes, "StrategicPriorityId", "Typology");
            return View();
        }
        //Priority Area Dropdown
        public ActionResult PriorityAreaDD()
        {
            List<Dropdown_PriorityArea> PriorityAreas = db.Dropdown_PriorityArea.ToList();
            ViewBag.PriorityAreas = new SelectList(PriorityAreas, "StrategicPriorityAreaId", "StrategicPriorityArea");
            return View();
        }
        //Priority Class Dropdown
        public ActionResult PriorityClassDD()
        {
            List<ref_StrategicPriorityClassification> PriorityClassifications = db.ref_StrategicPriorityClassification.ToList();
            ViewBag.PriorityClassifications = new SelectList(PriorityClassifications, "StratPriorityClassID", "StrategicPriorityClassification");
            return View();
        }
        //Priority Group Dropdown
        public ActionResult PriorityGroupDD()
        {
            List<ref_StrategicPriorityGroup> PriorityGroup = db.ref_StrategicPriorityGroup.ToList();
            ViewBag.PriorityGroup = new SelectList(PriorityGroup, "StrategicPriorityGrpID", "StrategicPriorityGrpDescription");
            return View();
        }
        // GET: ClimateChangeTypology/Create
        public ActionResult Create()
        {
            TypologyCodeDD();
            PriorityAreaDD();
            PriorityClassDD();
            PriorityGroupDD();
            return View(Tuple.Create<ref_ClimateChangeTypology, IEnumerable<vw_ClimateChangeTypology>>(new ref_ClimateChangeTypology(), db.vw_ClimateChangeTypology.ToList()));
        }

        // POST: CliimateChangeTypology/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "TypologyID,StrategicPriorityID,StrategicPriorityAreaID,StratPriorityClassID,StrategicPriorityGrpID,TypologyCode,TypologyDescription")] ref_ClimateChangeTypology ref_ClimateChangeTypology)
        {
            if (ModelState.IsValid)
            {
                db.ref_ClimateChangeTypology.Add(ref_ClimateChangeTypology);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ref_ClimateChangeTypology);
        }

        // GET: CliimateChangeTypology/Edit/5
        public ActionResult Edit(int? id)
        {
            TypologyCodeDD();
            PriorityAreaDD();
            PriorityClassDD();
            PriorityGroupDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ClimateChangeTypology ref_ClimateChangeTypology = db.ref_ClimateChangeTypology.Find(id);
            if (ref_ClimateChangeTypology == null)
            {
                return HttpNotFound();
            }
            return View(ref_ClimateChangeTypology);
        }

        // POST: CliimateChangeTypology/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypologyID,StrategicPriorityID,StrategicPriorityAreaID,StratPriorityClassID,StrategicPriorityGrpID,TypologyCode,TypologyDescription")] ref_ClimateChangeTypology ref_ClimateChangeTypology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ref_ClimateChangeTypology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(ref_ClimateChangeTypology);
        }

        // GET: CliimateChangeTypology/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ref_ClimateChangeTypology ref_ClimateChangeTypology = db.ref_ClimateChangeTypology.Find(id);
            if (ref_ClimateChangeTypology == null)
            {
                return HttpNotFound();
            }
            return View(ref_ClimateChangeTypology);
        }

        // POST: CliimateChangeTypology/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ref_ClimateChangeTypology ref_ClimateChangeTypology = db.ref_ClimateChangeTypology.Find(id);
            db.ref_ClimateChangeTypology.Remove(ref_ClimateChangeTypology);
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
