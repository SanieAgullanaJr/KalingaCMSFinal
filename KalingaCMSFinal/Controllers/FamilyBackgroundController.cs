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
    public class FamilyBackgroundController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: FamilyBackground
        public ActionResult Index()
        {
            return View(db.EmpFamilyBackGrounds.ToList());
        }

        // GET: FamilyBackground/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpFamilyBackGround empFamilyBackGround = db.EmpFamilyBackGrounds.Find(id);
            if (empFamilyBackGround == null)
            {
                return HttpNotFound();
            }
            return View(empFamilyBackGround);
        }

        public ActionResult RelationshipDD()
        {
            List<ref_Relationship> Relationships = db.ref_Relationship.ToList();
            ViewBag.Relationships = new SelectList(Relationships, "relationshipID", "relationshipDescription");
            return View();
        }

        // GET: FamilyBackground/Create
        public ActionResult Create()
        {
            RelationshipDD();
            return View(Tuple.Create<EmpFamilyBackGround, IEnumerable<vw_FamilyBackground>>(new EmpFamilyBackGround(), db.vw_FamilyBackground.ToList()));
        }

        // POST: FamilyBackground/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "empFamBGID,empID,RelationshipID,LastName,MiddleName,FirstName,BirthDate,Occupation,CompanyName,CompanyAddress,CompanyPhone")] EmpFamilyBackGround empFamilyBackGround)
        {
            if (ModelState.IsValid)
            {
                db.EmpFamilyBackGrounds.Add(empFamilyBackGround);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(empFamilyBackGround);
        }

        // GET: FamilyBackground/Edit/5
        public ActionResult Edit(int? id)
        {
            RelationshipDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpFamilyBackGround empFamilyBackGround = db.EmpFamilyBackGrounds.Find(id);
            if (empFamilyBackGround == null)
            {
                return HttpNotFound();
            }
            return View(empFamilyBackGround);
        }

        // POST: FamilyBackground/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empFamBGID,empID,RelationshipID,LastName,MiddleName,FirstName,BirthDate,Occupation,CompanyName,CompanyAddress,CompanyPhone")] EmpFamilyBackGround empFamilyBackGround)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empFamilyBackGround).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empFamilyBackGround);
        }

        // GET: FamilyBackground/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpFamilyBackGround empFamilyBackGround = db.EmpFamilyBackGrounds.Find(id);
            if (empFamilyBackGround == null)
            {
                return HttpNotFound();
            }
            return View(empFamilyBackGround);
        }

        // POST: FamilyBackground/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpFamilyBackGround empFamilyBackGround = db.EmpFamilyBackGrounds.Find(id);
            db.EmpFamilyBackGrounds.Remove(empFamilyBackGround);
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
