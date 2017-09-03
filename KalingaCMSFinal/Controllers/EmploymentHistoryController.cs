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
using System.IO;

namespace KalingaCMSFinal.Controllers
{
    public class EmploymentHistoryController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: EmploymentHistory
        public ActionResult Index()
        {
            return View(db.EmpWorkHistories.ToList());
        }

        // GET: EmploymentHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpWorkHistory empWorkHistory = db.EmpWorkHistories.Find(id);
            if (empWorkHistory == null)
            {
                return HttpNotFound();
            }
            return View(empWorkHistory);
        }

        public ActionResult PositionTitleDD()
        {
            List<ref_Position> Positions = db.ref_Position.ToList();
            ViewBag.Positions = new SelectList(Positions, "PositionID", "PositionDescription");
            return View();
        }

        public ActionResult AppointmentStatusDD()
        {
            List<ref_AppointmentStatus> AppointmentStatuses = db.ref_AppointmentStatus.ToList();
            ViewBag.AppointmentStatuses = new SelectList(AppointmentStatuses, "AppointmentStatusID", "EmpStatusDescription");
            return View();
        }

        public ActionResult SalaryGradeDD()
        {
            List<ref_SalaryGrade> SalaryGrades = db.ref_SalaryGrade.ToList();
            ViewBag.SalaryGrades = new SelectList(SalaryGrades, "SalaryGradeID", "SalaryGradeDescription");
            return View();
        }

        public ActionResult StepIncrementDD()
        {
            List<ref_SalaryGradeIncrement> StepIncrements = db.ref_SalaryGradeIncrement.ToList();
            ViewBag.StepIncrements = new SelectList(StepIncrements, "SGIncrementID", "StepIncrement");
            return View();
        }

        public ActionResult Search(string term)
        {
            NameSuggestions ns = new NameSuggestions();
            return Json(ns.Search(term), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmployeeName(string Name)
        {
            List<EmployeeName> t = new List<EmployeeName>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select empid, empNo, CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS FullName from EmpMasterProfile where CONCAT(FirstName, ' ', MiddleName, ' ', LastName) LIKE @Name";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = myQuery,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int counter = 0;
                    while (dr.Read())
                    {
                        EmployeeName tsData = new EmployeeName()
                        {
                            EmployeeFullName = dr["FullName"].ToString(),
                            EmployeeNumber = dr["empNo"].ToString(),
                            EmployeeID = dr["empid"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult WorkHistory(int EmployeeID)
        {
            List<EmployeeWorkHistoryDetails> t = new List<EmployeeWorkHistoryDetails>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_EmploymentRecord where empid = @EmployeeID";
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
                        EmployeeWorkHistoryDetails tsData = new EmployeeWorkHistoryDetails()
                        {
                            WorkID = dr["WorkID"].ToString(),
                            Position = dr["PositionDescription"].ToString(),
                            MonthlySalary = dr["MonthlySalary"].ToString(),
                            SalaryGradeCode = dr["SalaryGradeCode"].ToString(),
                            StepIncrement = dr["StepIncrement"].ToString(),
                            StatusDescription = dr["EmpStatusDescription"].ToString(),
                            GovernmentService = dr["IsGovService"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            Company = dr["Company"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: EmploymentHistory/Create
        public ActionResult Create()
        {
            AppointmentStatusDD();
            PositionTitleDD();
            SalaryGradeDD();
            StepIncrementDD();
            return View(Tuple.Create<EmpWorkHistory, IEnumerable<vw_EmploymentRecord>>(new EmpWorkHistory(), db.vw_EmploymentRecord.ToList()));
        }

        // POST: EmploymentHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "workID,empID,Company,StartDate,EndDate,PositionID,MonthlySalary,SalaryGradeID,SGIncrementID,AppointmentStatusID,IsGovService,IsSupervisor")] EmpWorkHistory empWorkHistory)
        {
            if (ModelState.IsValid)
            {
                db.EmpWorkHistories.Add(empWorkHistory);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(empWorkHistory);
        }

        // GET: EmploymentHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            AppointmentStatusDD();
            PositionTitleDD();
            SalaryGradeDD();
            StepIncrementDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpWorkHistory empWorkHistory = db.EmpWorkHistories.Find(id);
            if (empWorkHistory == null)
            {
                return HttpNotFound();
            }
            return View(empWorkHistory);
        }

        // POST: EmploymentHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "workID,empID,Company,StartDate,EndDate,PositionID,MonthlySalary,SalaryGradeID,SGIncrementID,AppointmentStatusID,IsGovService,IsSupervisor, DisplayPicturePath")] EmpWorkHistory empWorkHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empWorkHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empWorkHistory);
        }

        // GET: EmploymentHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpWorkHistory empWorkHistory = db.EmpWorkHistories.Find(id);
            if (empWorkHistory == null)
            {
                return HttpNotFound();
            }
            return View(empWorkHistory);
        }

        // POST: EmploymentHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpWorkHistory empWorkHistory = db.EmpWorkHistories.Find(id);
            db.EmpWorkHistories.Remove(empWorkHistory);
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
