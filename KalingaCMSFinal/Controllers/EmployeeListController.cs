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
    public class EmployeeListController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: EmployeeList
        public ActionResult Index()
        {
            return View(db.vw_EmployeeList.ToList());
        }

        // GET: EmployeeList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_EmployeeList vw_EmployeeList = db.vw_EmployeeList.Find(id);
            if (vw_EmployeeList == null)
            {
                return HttpNotFound();
            }
            return View(vw_EmployeeList);
        }

        // GET: EmployeeList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empid,EmployeeName,empNo,PositionDescription,DateHired,EmpStatusDescription,DeptDescription,CivilStatusDescription")] vw_EmployeeList vw_EmployeeList)
        {
            if (ModelState.IsValid)
            {
                db.vw_EmployeeList.Add(vw_EmployeeList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_EmployeeList);
        }

        // GET: EmployeeList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_EmployeeList vw_EmployeeList = db.vw_EmployeeList.Find(id);
            if (vw_EmployeeList == null)
            {
                return HttpNotFound();
            }
            return View(vw_EmployeeList);
        }

        // POST: EmployeeList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empid,EmployeeName,empNo,PositionDescription,DateHired,EmpStatusDescription,DeptDescription,CivilStatusDescription")] vw_EmployeeList vw_EmployeeList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_EmployeeList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_EmployeeList);
        }

        // GET: EmployeeList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_EmployeeList vw_EmployeeList = db.vw_EmployeeList.Find(id);
            if (vw_EmployeeList == null)
            {
                return HttpNotFound();
            }
            return View(vw_EmployeeList);
        }

        // POST: EmployeeList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vw_EmployeeList vw_EmployeeList = db.vw_EmployeeList.Find(id);
            db.vw_EmployeeList.Remove(vw_EmployeeList);
            db.SaveChanges();
            return RedirectToAction("Index");
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
