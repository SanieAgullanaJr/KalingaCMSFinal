using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace KalingaCMSFinal.Controllers
{
    public class LeaveCreditsMonitoringController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        public ActionResult EmployeeListDD()
        {
            List<DropDown_EmpployeeList> Employees = db.DropDown_EmpployeeList.ToList();
            ViewBag.Employees = new SelectList(Employees, "empID", "FullName");
            return View();
        }

        // GET: LeaveCreditsMonitoring
        public ActionResult Index()
        {
            EmployeeListDD();
            return View();
        }

        // GET: LeaveCreditsMonitoring/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rep_EmpOffsetReport rep_EmpOffsetReport = db.rep_EmpOffsetReport.Find(id);
            if (rep_EmpOffsetReport == null)
            {
                return HttpNotFound();
            }
            return View(rep_EmpOffsetReport);
        }

        public JsonResult LeaveCreditsMonitoringData(int? EmployeeID)
        {
            List<LeaveCreditsData> t = new List<LeaveCreditsData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "SELECT Offset.empOTID, Offset.EarnedHours, Offset.DateAcquired, SickLeave.LeaveCreditID, SickLeave.LeaveHrs, SickLeave.AcquiredDate, VacationLeave.LeaveHrs, VacationLeave.AcquiredDate FROM rep_EmpOffsetReport Offset " +
                                  "INNER JOIN rep_EmpSickLeaveReport SickLeave on SickLeave.empID = Offset.empID " +
                                  "INNER JOIN rep_EmpVacationLeaveReport VacationLeave on VacationLeave.empID = SickLeave.empID " +
                                  "WHERE Offset.empID = @EmployeeID";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        LeaveCreditsData tsData = new LeaveCreditsData()
                        {
                            OSID = dr[0].ToString(),
                            OSEarnedHours = dr[1].ToString(),
                            OSDateAcquired = dr[2].ToString(),
                            SLEarnedHours = dr[4].ToString(),
                            SLDateAcquired = dr[5].ToString(),
                            VLEarnedHours = dr[6].ToString(),
                            VLDateAcquired = dr[7].ToString(),
                            SLID = dr[3].ToString(),
                            VLID = dr[3].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: LeaveCreditsMonitoring/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveCreditsMonitoring/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empOTID,empID,AttendanceDetailDTRId,EarnedHours,DateAcquired")] rep_EmpOffsetReport rep_EmpOffsetReport)
        {
            if (ModelState.IsValid)
            {
                db.rep_EmpOffsetReport.Add(rep_EmpOffsetReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rep_EmpOffsetReport);
        }

        // GET: LeaveCreditsMonitoring/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rep_EmpOffsetReport rep_EmpOffsetReport = db.rep_EmpOffsetReport.Find(id);
            if (rep_EmpOffsetReport == null)
            {
                return HttpNotFound();
            }
            return View(rep_EmpOffsetReport);
        }

        // POST: LeaveCreditsMonitoring/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empOTID,empID,AttendanceDetailDTRId,EarnedHours,DateAcquired")] rep_EmpOffsetReport rep_EmpOffsetReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rep_EmpOffsetReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rep_EmpOffsetReport);
        }

        // GET: LeaveCreditsMonitoring/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rep_EmpOffsetReport rep_EmpOffsetReport = db.rep_EmpOffsetReport.Find(id);
            if (rep_EmpOffsetReport == null)
            {
                return HttpNotFound();
            }
            return View(rep_EmpOffsetReport);
        }

        // POST: LeaveCreditsMonitoring/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep_EmpOffsetReport rep_EmpOffsetReport = db.rep_EmpOffsetReport.Find(id);
            db.rep_EmpOffsetReport.Remove(rep_EmpOffsetReport);
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
