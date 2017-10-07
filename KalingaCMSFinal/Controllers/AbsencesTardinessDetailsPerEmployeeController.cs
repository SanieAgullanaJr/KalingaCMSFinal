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
    public class AbsencesTardinessDetailsPerEmployeeController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        public ActionResult EmployeeListDD()
        {
            List<DropDown_EmpployeeList> Employees = db.DropDown_EmpployeeList.ToList();
            ViewBag.Employees = new SelectList(Employees, "empID", "FullName");
            return View();
        }

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
                cmd.Parameters.AddWithValue("@Year", "%" + Year + "%");
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

        public JsonResult PerEmployee(int empID, int AttendanceID)
        {
            List<AbsencesAndTardiness> t = new List<AbsencesAndTardiness>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "SELECT * FROM rep_AbsencesTardinessDetailsPerEmployee2 where empAttendanceMainID = @AttendanceID AND empID = @empID";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);
                cmd.Parameters.AddWithValue("@empID", empID);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        AbsencesAndTardiness tsData = new AbsencesAndTardiness()
                        {
                            empAttendanceMainID = dr["empAttendanceMainID"].ToString(),
                            NameDate = dr["NameDate"].ToString(),
                            DTRDate = dr["DTRDate"].ToString(),
                            empID = dr["empID"].ToString(),
                            LOGIN = dr["LOGIN"].ToString(),
                            LOGOUT = dr["LOGOUT"].ToString(),
                            AbsHrs = dr["AbsHrs"].ToString(),
                            AbsHrsDec = dr["AbsHrsDec"].ToString(),
                            LateHrs = dr["LateHrs"].ToString(),
                            LateHrsDec = dr["LateHrsDec"].ToString(),
                            UnderTimeHours = dr["UnderTimeHours"].ToString(),
                            UnderTimeHoursDec = dr["UnderTimeHoursDec"].ToString(),
                            LeaveTypeCode = dr["LeaveTypeCode"].ToString(),
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

        // GET: AbsencesTardinessDetailsPerEmployee
        public ActionResult Index()
        {
            EmployeeListDD();
            YearDD();
            return View();
        }

        // GET: AbsencesTardinessDetailsPerEmployee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rep_AbsencesTardinessDetailsPerEmployee rep_AbsencesTardinessDetailsPerEmployee = db.rep_AbsencesTardinessDetailsPerEmployee.Find(id);
            if (rep_AbsencesTardinessDetailsPerEmployee == null)
            {
                return HttpNotFound();
            }
            return View(rep_AbsencesTardinessDetailsPerEmployee);
        }

        // GET: AbsencesTardinessDetailsPerEmployee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbsencesTardinessDetailsPerEmployee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendanceDetailDTRId,empAttendanceMainID,NameDate,DTRDate,empID,LOGIN,LOGOUT,AbsHrs,AbsHrsDec,LateHrs,LateHrsDec,UnderTimeHours,UnderTimeHoursDec")] rep_AbsencesTardinessDetailsPerEmployee rep_AbsencesTardinessDetailsPerEmployee)
        {
            if (ModelState.IsValid)
            {
                db.rep_AbsencesTardinessDetailsPerEmployee.Add(rep_AbsencesTardinessDetailsPerEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rep_AbsencesTardinessDetailsPerEmployee);
        }

        // GET: AbsencesTardinessDetailsPerEmployee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rep_AbsencesTardinessDetailsPerEmployee rep_AbsencesTardinessDetailsPerEmployee = db.rep_AbsencesTardinessDetailsPerEmployee.Find(id);
            if (rep_AbsencesTardinessDetailsPerEmployee == null)
            {
                return HttpNotFound();
            }
            return View(rep_AbsencesTardinessDetailsPerEmployee);
        }

        // POST: AbsencesTardinessDetailsPerEmployee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendanceDetailDTRId,empAttendanceMainID,NameDate,DTRDate,empID,LOGIN,LOGOUT,AbsHrs,AbsHrsDec,LateHrs,LateHrsDec,UnderTimeHours,UnderTimeHoursDec")] rep_AbsencesTardinessDetailsPerEmployee rep_AbsencesTardinessDetailsPerEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rep_AbsencesTardinessDetailsPerEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rep_AbsencesTardinessDetailsPerEmployee);
        }

        // GET: AbsencesTardinessDetailsPerEmployee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rep_AbsencesTardinessDetailsPerEmployee rep_AbsencesTardinessDetailsPerEmployee = db.rep_AbsencesTardinessDetailsPerEmployee.Find(id);
            if (rep_AbsencesTardinessDetailsPerEmployee == null)
            {
                return HttpNotFound();
            }
            return View(rep_AbsencesTardinessDetailsPerEmployee);
        }

        // POST: AbsencesTardinessDetailsPerEmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep_AbsencesTardinessDetailsPerEmployee rep_AbsencesTardinessDetailsPerEmployee = db.rep_AbsencesTardinessDetailsPerEmployee.Find(id);
            db.rep_AbsencesTardinessDetailsPerEmployee.Remove(rep_AbsencesTardinessDetailsPerEmployee);
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
