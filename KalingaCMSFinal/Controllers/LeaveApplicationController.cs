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
using System.Data.Entity.Migrations;

namespace KalingaCMSFinal.Controllers
{
    public class LeaveApplicationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        //Employees Dropdown
        public ActionResult EmployeeDD()
        {
            List<DropDown_EmpployeeList> Employees = db.DropDown_EmpployeeList.ToList();
            ViewBag.Employees = new SelectList(Employees, "empid", "Fullname");
            return View();
        }

        //LeaveTypes Dropdown
        public ActionResult LeaveTypeDD()
        {
            List<DropDown_LeaveType> LeaveTypes = db.DropDown_LeaveType.ToList();
            ViewBag.LeaveTypes = new SelectList(LeaveTypes, "LeaveTypeID", "LeaveTypeDescription");
            return View();
        }

        //Supervisors Dropdown
        public ActionResult SupervisorDD()
        {
            List<DropDown_SupervisorList> Supervisors = db.DropDown_SupervisorList.ToList();
            ViewBag.Supervisors = new SelectList(Supervisors, "empid", "Supervisor");
            return View();
        }

        public JsonResult LeaveApplicationData(int? empLeaveAppID)
        {
            List<LeaveApplicationData> t = new List<LeaveApplicationData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from EmpLeaveApplication where empLeaveAppID = @empLeaveAppID";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@empLeaveAppID", empLeaveAppID);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        LeaveApplicationData tsData = new LeaveApplicationData()
                        {
                            empLeaveAppID = dr["empLeaveAppID"].ToString(),
                            LeaveType = dr["LeaveTypeID"].ToString(),
                            LeaveReason = dr["LeaveReason"].ToString(),
                            DateFiled = dr["DateFiled"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            AppliedHours = dr["AppliedHours"].ToString(),
                            ApprovedDate = dr["ApprovedDate"].ToString(),
                            ApprovedBy = dr["ApprovedBy"].ToString(),
                            IsApproved = dr["IsApproved"].ToString(),
                            IsWithPay = dr["IsWithPay"].ToString(),
                            IsCancelled = dr["IsCancelled"].ToString(),
                            Remarks = dr["Remarks"].ToString(),
                            StampTime = dr["StampTime"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LeaveHistory(int? EmployeeID)
        {
            List<LeaveApplicationHistory> t = new List<LeaveApplicationHistory>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from Rep_EmpLeaveApplication where empid = @EmployeeID";
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
                        LeaveApplicationHistory tsData = new LeaveApplicationHistory()
                        {
                            empLeaveAppID = dr["empLeaveAppID"].ToString(),
                            empID = dr["empID"].ToString(),
                            empAttendanceMainID = dr["empAttendanceMainID"].ToString(),
                            Fullname = dr["Fullname"].ToString(),
                            LeaveTypeDescription = dr["LeaveTypeDescription"].ToString(),
                            DateFiled = dr["DateFiled"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            Supervisor = dr["Supervisor"].ToString(),
                            IsApproved = dr["IsApproved"].ToString(),
                            IsWithPay = dr["IsWithPay"].ToString(),
                            IsCancelled = dr["IsCancelled"].ToString(),
                            AppliedHours = dr["AppliedHours"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LeaveBalance(int? EmployeeID)
        {
            List<LeaveBalance> t = new List<LeaveBalance>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from rep_EmpLeaveBalance where empID = @EmployeeID";
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
                        LeaveBalance tsData = new LeaveBalance()
                        {
                            Days = dr["BalanceDays"].ToString(),
                            Hours = dr["BalanceHours"].ToString(),
                            LeaveType = dr["LeaveTypeCode"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OffsetBalance(int? EmployeeID)
        {
            List<OffsetBalance> t = new List<OffsetBalance>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from rep_EmpOffsetBalance where empID = @EmployeeID";
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
                        OffsetBalance tsData = new OffsetBalance()
                        {
                            Hours = dr["OffsetHours"].ToString(),
                            Days = dr["OffsetDays"].ToString(),
                            ExpirationDate = dr["ExpirationDate"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: LeaveApplication
        public ActionResult Index()
        {
            return View(db.EmpLeaveApplications.ToList());
        }

        // GET: LeaveApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpLeaveApplication empLeaveApplication = db.EmpLeaveApplications.Find(id);
            if (empLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(empLeaveApplication);
        }

        // GET: LeaveApplication/Create
        public ActionResult Create()
        {
            EmployeeDD();
            LeaveTypeDD();
            SupervisorDD();
            return View("Create", new EmpLeaveApplication());
        }

        // POST: LeaveApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empLeaveAppID,empID,LeaveTypeID,LeaveReason,DateFiled,StartDate,EndDate,AppliedHours,ApprovedDate,ApprovedBy,IsApproved,IsWithPay,IsCancelled,Remarks,StampTime")] EmpLeaveApplication empLeaveApplication, string Create, string Edit)
        {
            EmployeeDD();
            LeaveTypeDD();
            SupervisorDD();
            var check = empLeaveApplication.empLeaveAppID;
            var CheckAttendance = db.EmpLeaveApplications.FirstOrDefault(id => id.empLeaveAppID == empLeaveApplication.empLeaveAppID);
            if (ModelState.IsValid)
            {
                if (Create != null)
                {
                    if(CheckAttendance == null)
                    { 
                        string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
                        using (SqlConnection cn = new SqlConnection(conn))
                        {
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandText = "Execute sp_InsertEmpLeave @empID, @empAttendanceMainID, @LeaveTypeID, @LeaveReason, @DateFiled, @StartDate, @EndDate, @AppliedHours, @ApprovedDate, @ApprovedBy, @IsApproved, @IsWithPay, @IsCancelled, @Remarks";

                            cmd.Parameters.AddWithValue("@empID", empLeaveApplication.empID);
                            cmd.Parameters.AddWithValue("@empAttendanceMainID", empLeaveApplication.empAttendanceMainID.ToString());
                            cmd.Parameters.AddWithValue("@@attendancedetaildtrID", empLeaveApplication.AttendanceDetailDTRId.ToString());
                            cmd.Parameters.AddWithValue("@LeaveTypeID", empLeaveApplication.LeaveTypeID);
                            cmd.Parameters.AddWithValue("@LeaveReason", empLeaveApplication.LeaveReason);
                            cmd.Parameters.AddWithValue("@DateFiled", empLeaveApplication.DateFiled);
                            cmd.Parameters.AddWithValue("@StartDate", empLeaveApplication.StartDate);
                            cmd.Parameters.AddWithValue("@EndDate", empLeaveApplication.EndDate);
                            cmd.Parameters.AddWithValue("@AppliedHours", empLeaveApplication.AppliedHours);
                            cmd.Parameters.AddWithValue("@ApprovedDate", empLeaveApplication.ApprovedDate);
                            cmd.Parameters.AddWithValue("@ApprovedBy", empLeaveApplication.ApprovedBy);
                            cmd.Parameters.AddWithValue("@IsApproved", empLeaveApplication.IsApproved);
                            cmd.Parameters.AddWithValue("@IsWithPay", empLeaveApplication.IsWithPay);
                            cmd.Parameters.AddWithValue("@IsCancelled", empLeaveApplication.IsCancelled);
                            cmd.Parameters.AddWithValue("@Remarks", empLeaveApplication.Remarks);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            return RedirectToAction("Create");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Leave Number " + empLeaveApplication.empLeaveAppID + " already exists. Please click update if you're trying to update a data.");
                        return View(empLeaveApplication);
                    }
                }
                else if (Edit != null)
                {
                    db.Set<EmpLeaveApplication>().AddOrUpdate(empLeaveApplication);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                
            }
            return View(empLeaveApplication);
        }

        // GET: LeaveApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpLeaveApplication empLeaveApplication = db.EmpLeaveApplications.Find(id);
            if (empLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(empLeaveApplication);
        }

        // POST: LeaveApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empLeaveAppID,empID,LeaveTypeID,LeaveReason,DateFiled,StartDate,EndDate,AppliedHours,ApprovedDate,ApprovedBy,IsApproved,IsWithPay,IsCancelled,Remarks,StampTime")] EmpLeaveApplication empLeaveApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empLeaveApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empLeaveApplication);
        }

        // GET: LeaveApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpLeaveApplication empLeaveApplication = db.EmpLeaveApplications.Find(id);
            if (empLeaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(empLeaveApplication);
        }

        // POST: LeaveApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpLeaveApplication empLeaveApplication = db.EmpLeaveApplications.Find(id);
            db.EmpLeaveApplications.Remove(empLeaveApplication);
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
