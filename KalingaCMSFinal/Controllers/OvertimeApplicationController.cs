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
    public class OvertimeApplicationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        //Employees Dropdown
        public ActionResult EmployeeDD()
        {
            List<DropDown_EmpployeeList> Employees = db.DropDown_EmpployeeList.ToList();
            ViewBag.Employees = new SelectList(Employees, "empid", "Fullname");
            return View();
        }

        //Supervisors Dropdown
        public ActionResult SupervisorDD()
        {
            List<DropDown_SupervisorList> Supervisors = db.DropDown_SupervisorList.ToList();
            ViewBag.Supervisors = new SelectList(Supervisors, "empid", "Supervisor");
            return View();
        }

        public JsonResult OvertimeApplicationData(int? empOTID)
        {
            List<OvertimeApplicationData> t = new List<OvertimeApplicationData>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from EmpOvertime where empOTID = @empOTID";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@empOTID", empOTID);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        OvertimeApplicationData tsData = new OvertimeApplicationData()
                        {
                            empOTID = dr["empOTID"].ToString(),
                            empID = dr["empID"].ToString(),
                            AttendanceDetailDTRId = dr["AttendanceDetailDTRId"].ToString(),
                            In1 = dr["In1"].ToString(),
                            Out1 = dr["Out1"].ToString(),
                            OTReason = dr["OTReason"].ToString(),
                            AppliedOTHoursDec = dr["AppliedOTHoursDec"].ToString(),
                            AppliedOTHoursCHAR = dr["AppliedOTHoursCHAR"].ToString(),
                            SupervisorID = dr["SupervisorID"].ToString(),
                            Remarks = dr["Remarks"].ToString(),
                            DateApproved = dr["DateApproved"].ToString(),
                            DateApplied = dr["DateApplied"].ToString(),
                            IsApproved = dr["IsApproved"].ToString(),
                            IsDenied = dr["IsDenied"].ToString(),
                            DTRDate = dr["AttendanceDate"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OvertimeHistory(int? EmployeeID)
        {
            List<OvertimeHistory> t = new List<OvertimeHistory>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_EmpAppliedOvertime where empid = @EmployeeID";
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
                        OvertimeHistory tsData = new OvertimeHistory()
                        {
                            empOTID = dr["empOTID"].ToString(),
                            empID = dr["empID"].ToString(),
                            DateApplied = dr["DateApplied"].ToString(),
                            AttendanceDetailDTRId = dr["AttendanceDetailDTRId"].ToString(),
                            DTRDate = dr["DTRDate"].ToString(),
                            LOGIN = dr["LOGIN"].ToString(),
                            LOGOUT = dr["LOGOUT"].ToString(),
                            AppliedOTHoursDEC = dr["AppliedOTHoursDEC"].ToString(),
                            AppliedOTHoursCHAR = dr["AppliedOTHoursCHAR"].ToString(),
                            SupervisorID = dr["SupervisorID"].ToString(),
                            IsApproved = dr["IsApproved"].ToString(),
                            IsDenied = dr["IsDenied"].ToString(),
                            DateApproved = dr["DateApproved"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OTWorkFromDTR(int? EmployeeID)
        {
            List<OTWorkFromDTR> t = new List<OTWorkFromDTR>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_EmpOvertimeDetails where empid = @EmployeeID";
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
                        OTWorkFromDTR tsData = new OTWorkFromDTR()
                        {
                            AttendanceDetailDTRId = dr["AttendanceDetailDTRId"].ToString(),
                            empAttendanceMainID = dr["empAttendanceMainID"].ToString(),
                            empID = dr["empID"].ToString(),
                            NameDate = dr["NameDate"].ToString(),
                            DTRDate = dr["DTRDate"].ToString(),
                            LOGIN = dr["LOGIN"].ToString(),
                            LOGOUT = dr["LOGOUT"].ToString(),
                            OTHrs = dr["OTHrs"].ToString(),
                            OTHrsDec = dr["OTHrsDec"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OTWorkFromDTR0(int? AttendanceDetailDTRId)
        {
            List<OTWorkFromDTR> t = new List<OTWorkFromDTR>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_EmpOvertimeDetails where AttendanceDetailDTRId = @AttendanceDetailDTRId";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@AttendanceDetailDTRId", AttendanceDetailDTRId);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        OTWorkFromDTR tsData = new OTWorkFromDTR()
                        {
                            AttendanceDetailDTRId = dr["AttendanceDetailDTRId"].ToString(),
                            empAttendanceMainID = dr["empAttendanceMainID"].ToString(),
                            empID = dr["empID"].ToString(),
                            NameDate = dr["NameDate"].ToString(),
                            DTRDate = dr["DTRDate"].ToString(),
                            LOGIN = dr["LOGIN"].ToString(),
                            LOGOUT = dr["LOGOUT"].ToString(),
                            OTHrs = dr["OTHrs"].ToString(),
                            OTHrsDec = dr["OTHrsDec"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: OvertimeApplication
        public ActionResult Index()
        {
            return View(db.EmpOvertimes.ToList());
        }

        // GET: OvertimeApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpOvertime empOvertime = db.EmpOvertimes.Find(id);
            if (empOvertime == null)
            {
                return HttpNotFound();
            }
            return View(empOvertime);
        }

        // GET: OvertimeApplication/Create
        public ActionResult Create()
        {
            EmployeeDD();
            SupervisorDD();
            return View();
        }

        // POST: OvertimeApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empOTID,empID,AttendanceDetailDTRId,In1,Out1,OTReason,AppliedOTHoursDEC,AppliedOTHoursCHAR,SupervisorID,Remarks,DateApproved,DateApplied,IsApproved,IsDenied,AttendanceDate")] EmpOvertime empOvertime,string Create, string Edit)
        {
            Console.WriteLine(empOvertime.empID + " " +  empOvertime.AttendanceDetailDTRId + " " + empOvertime.In1 + " " + empOvertime.Out1 + " " + empOvertime.OTReason + " " + empOvertime.AppliedOTHoursDEC + " " + empOvertime.AppliedOTHoursCHAR + " " + empOvertime.AttendanceDetailDTRId + " " + empOvertime.SupervisorID + " " + empOvertime.Remarks + " " + empOvertime.DateApproved + " " + empOvertime.DateApplied +
                    empOvertime.AttendanceDate + " "  + empOvertime.IsApproved + " " + empOvertime.IsDenied
                );
            if (ModelState.IsValid)
            {
                db.EmpOvertimes.Add(empOvertime);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empOvertime);
        }

        // GET: OvertimeApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpOvertime empOvertime = db.EmpOvertimes.Find(id);
            if (empOvertime == null)
            {
                return HttpNotFound();
            }
            return View(empOvertime);
        }

        // POST: OvertimeApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empOTID,empID,AttendanceDetailDTRId,In1,Out1,OTReason,AppliedOTHoursDEC,AppliedOTHoursCHAR,SupervisorID,Remarks,DateApproved,DateApplied,IsApproved,IsDenied")] EmpOvertime empOvertime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empOvertime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empOvertime);
        }

        // GET: OvertimeApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpOvertime empOvertime = db.EmpOvertimes.Find(id);
            if (empOvertime == null)
            {
                return HttpNotFound();
            }
            return View(empOvertime);
        }

        // POST: OvertimeApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpOvertime empOvertime = db.EmpOvertimes.Find(id);
            db.EmpOvertimes.Remove(empOvertime);
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
