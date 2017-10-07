using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace KalingaCMSFinal.Controllers
{
    public class LeaveApplicationsSummaryReportController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        public ActionResult YearDD()
        {
            var result = db.DropDown_AttendanceYear.ToList();
            List<DropDown_AttendanceYear> Years = result;
            ViewBag.Years = new SelectList(Years.Select(m => m.Year).Distinct());
            return View();
        }

        public JsonResult GetMonth(int Year)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<DropDown_AttendanceMonth> Regions = db.DropDown_AttendanceMonth.Where(x => x.Year == Year).ToList();
            return Json(Regions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCutOff(string Month, string Year)
        {
            List<SummaryReportSelector> t = new List<SummaryReportSelector>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "SELECT * FROM Dropdown_AttendanceCutOff WHERE CutOff LIKE @Month AND CutOff LIKE @Year";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@Year", "%" +  Year + "%");
                cmd.Parameters.AddWithValue("@Month", "%" + Month + "%");
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        SummaryReportSelector tsData = new SummaryReportSelector()
                        {
                            empAttendanceMainID = dr["empAttendanceMainID"].ToString(),
                            CutoffDate = dr["CutOff"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LeaveSummary(int AttendanceID, string Status)
        {
            List<SummaryReport> t = new List<SummaryReport>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "SELECT * from rep_EmpLeaveApplication where empAttendanceMainID = @AttendanceID AND IsApproved = @Status";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        SummaryReport tsData = new SummaryReport()
                        {
                            empAttendanceMainID = dr["empAttendanceMainID"].ToString(),
                            Name = dr["Fullname"].ToString(),
                            LeaveType = dr["LeaveTypeDescription"].ToString(),
                            DateFiled = dr["DateFiled"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            AppliedHours = dr["AppliedHours"].ToString(),
                            Status = dr["IsApproved"].ToString(),
                            Approver = dr["Supervisor"].ToString(),
                            DateofAction = dr["DateAction"].ToString(),
                            Reason = dr["LeaveReason"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: LeaveApplicationsSummaryReport
        public ActionResult Index()
        {
            YearDD();
            return View();
        }

        // GET: LeaveApplicationsSummaryReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rep_EmpLeaveApplication rep_EmpLeaveApplication = db.Rep_EmpLeaveApplication.Find(id);
            if (rep_EmpLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(rep_EmpLeaveApplication);
        }

        // GET: LeaveApplicationsSummaryReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveApplicationsSummaryReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empLeaveAppID,empID,Fullname,LeaveTypeDescription,DateFiled,StartDate,EndDate,AppliedHours,IsApproved,IsCancelled,Supervisor,DateAction,empAttendanceMainID,LeaveReason")] Rep_EmpLeaveApplication rep_EmpLeaveApplication)
        {
            if (ModelState.IsValid)
            {
                db.Rep_EmpLeaveApplication.Add(rep_EmpLeaveApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rep_EmpLeaveApplication);
        }

        // GET: LeaveApplicationsSummaryReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rep_EmpLeaveApplication rep_EmpLeaveApplication = db.Rep_EmpLeaveApplication.Find(id);
            if (rep_EmpLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(rep_EmpLeaveApplication);
        }

        // POST: LeaveApplicationsSummaryReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empLeaveAppID,empID,Fullname,LeaveTypeDescription,DateFiled,StartDate,EndDate,AppliedHours,IsApproved,IsCancelled,Supervisor,DateAction,empAttendanceMainID,LeaveReason")] Rep_EmpLeaveApplication rep_EmpLeaveApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rep_EmpLeaveApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rep_EmpLeaveApplication);
        }

        // GET: LeaveApplicationsSummaryReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rep_EmpLeaveApplication rep_EmpLeaveApplication = db.Rep_EmpLeaveApplication.Find(id);
            if (rep_EmpLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(rep_EmpLeaveApplication);
        }

        // POST: LeaveApplicationsSummaryReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rep_EmpLeaveApplication rep_EmpLeaveApplication = db.Rep_EmpLeaveApplication.Find(id);
            db.Rep_EmpLeaveApplication.Remove(rep_EmpLeaveApplication);
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
