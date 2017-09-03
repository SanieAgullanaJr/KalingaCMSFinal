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
    public class EstablishmentByIndustryController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: EstablishmentByIndustry
        public ActionResult Index()
        {
            return View(db.EstablishmentByIndustries.ToList());
        }

        // GET: EstablishmentByIndustry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstablishmentByIndustry establishmentByIndustry = db.EstablishmentByIndustries.Find(id);
            if (establishmentByIndustry == null)
            {
                return HttpNotFound();
            }
            return View(establishmentByIndustry);
        }

        //Industry Classification Dropdown
        public ActionResult IndustryClassificationDD()
        {
            List<ref_IndustryClassification> Industries = db.ref_IndustryClassification.ToList();
            ViewBag.Industries = new SelectList(Industries, "IndustryClassID", "IndustryClassification");
            return View();
        }

        // GET: EstablishmentByIndustry/Create
        public ActionResult Create()
        {
            IndustryClassificationDD();
            return View(Tuple.Create<EstablishmentByIndustry, IEnumerable<vw_EstablishmentByIndustryByYear>>(new EstablishmentByIndustry(), db.vw_EstablishmentByIndustryByYear.ToList()));
        }

        // POST: EstablishmentByIndustry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1",Include = "EstablishID,IndustryClassID,NumberofFirms,PercentFirms,Investment,PercentInvest,NumberofEmployee,Distribution,YearTaken")] EstablishmentByIndustry establishmentByIndustry)
        {
            if (ModelState.IsValid)
            {
                db.EstablishmentByIndustries.Add(establishmentByIndustry);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(establishmentByIndustry);
        }

        // GET: EstablishmentByIndustry/Edit/5
        public ActionResult Edit(int? id)
        {
            IndustryClassificationDD();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstablishmentByIndustry establishmentByIndustry = db.EstablishmentByIndustries.Find(id);
            if (establishmentByIndustry == null)
            {
                return HttpNotFound();
            }
            return View(establishmentByIndustry);
        }

        // POST: EstablishmentByIndustry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstablishID,IndustryClassID,NumberofFirms,PercentFirms,Investment,PercentInvest,NumberofEmployee,Distribution,YearTaken")] EstablishmentByIndustry establishmentByIndustry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establishmentByIndustry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(establishmentByIndustry);
        }

        // GET: EstablishmentByIndustry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstablishmentByIndustry establishmentByIndustry = db.EstablishmentByIndustries.Find(id);
            if (establishmentByIndustry == null)
            {
                return HttpNotFound();
            }
            return View(establishmentByIndustry);
        }

        // POST: EstablishmentByIndustry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstablishmentByIndustry establishmentByIndustry = db.EstablishmentByIndustries.Find(id);
            db.EstablishmentByIndustries.Remove(establishmentByIndustry);
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
