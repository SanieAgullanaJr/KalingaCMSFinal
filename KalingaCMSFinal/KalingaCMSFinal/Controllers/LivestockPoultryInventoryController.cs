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
    public class LivestockPoultryInventoryController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: LivestockPoultryInventory
        public ActionResult Index()
        {
            return View(db.LivestockPoultryInventories.ToList());
        }

        // GET: LivestockPoultryInventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivestockPoultryInventory livestockPoultryInventory = db.LivestockPoultryInventories.Find(id);
            if (livestockPoultryInventory == null)
            {
                return HttpNotFound();
            }
            return View(livestockPoultryInventory);
        }

        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }

        //Livestock Poultry Dropdown
        public ActionResult LivestockPoultryDD()
        {
            List<ref_LivestockPoultry> LivestockPoultry = db.ref_LivestockPoultry.ToList();
            ViewBag.LivestockPoultry = new SelectList(LivestockPoultry, "LivestockPoultryID", "LivestockPoultry");
            return View();
        }

        // GET: LivestockPoultryInventory/Create
        public ActionResult Create()
        {
            LivestockPoultryDD();
            MunicipalityDD();
            return View(Tuple.Create<LivestockPoultryInventory, IEnumerable<vw_LivestockAndPoultryInventoryByMunicipalityByYear>>(new LivestockPoultryInventory(), db.vw_LivestockAndPoultryInventoryByMunicipalityByYear.ToList()));
        }

        // POST: LivestockPoultryInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "LivestockInvID,MunicipalityID,LivestockPoultryID,NumberofLivestock,YearTaken")] LivestockPoultryInventory livestockPoultryInventory)
        {
            if (ModelState.IsValid)
            {
                db.LivestockPoultryInventories.Add(livestockPoultryInventory);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(livestockPoultryInventory);
        }

        // GET: LivestockPoultryInventory/Edit/5
        public ActionResult Edit(int? id)
        {
            LivestockPoultryDD();
            MunicipalityDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivestockPoultryInventory livestockPoultryInventory = db.LivestockPoultryInventories.Find(id);
            if (livestockPoultryInventory == null)
            {
                return HttpNotFound();
            }
            return View(livestockPoultryInventory);
        }

        // POST: LivestockPoultryInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivestockInvID,MunicipalityID,LivestockPoultryID,NumberofLivestock,YearTaken")] LivestockPoultryInventory livestockPoultryInventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livestockPoultryInventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(livestockPoultryInventory);
        }

        // GET: LivestockPoultryInventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LivestockPoultryInventory livestockPoultryInventory = db.LivestockPoultryInventories.Find(id);
            if (livestockPoultryInventory == null)
            {
                return HttpNotFound();
            }
            return View(livestockPoultryInventory);
        }

        // POST: LivestockPoultryInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LivestockPoultryInventory livestockPoultryInventory = db.LivestockPoultryInventories.Find(id);
            db.LivestockPoultryInventories.Remove(livestockPoultryInventory);
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
