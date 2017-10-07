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
    public class EmployeeSalaryHistoryController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        public JsonResult SalaryHistory(int EmployeeID)
        {
            List<SalaryHistory> t = new List<SalaryHistory>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_EmployeeSalaryHistory where empid = @EmployeeID";
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
                        SalaryHistory tsData = new SalaryHistory()
                        {
                            Department = dr["Company"].ToString(),
                            DateHired = dr["StartDate"].ToString(),
                            DateResigned = dr["EndDate"].ToString(),
                            PositionTitle = dr["PositionDescription"].ToString(),
                            MonthlySalary = dr["MonthlySalary"].ToString(),
                            SalaryGrade = dr["SalaryGradeDescription"].ToString(),
                            StepIncrement = dr["StepIncrement"].ToString(),
                            AppointmentStatus = dr["EmpStatusDescription"].ToString(),
                            GovernmentService = dr["IsGovService"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: EmployeeSalaryHistory
        public ActionResult Index()
        {
            EmployeeListDD();
            return View();
        }

        // GET: EmployeeSalaryHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_EmployeeSalaryHistory vw_EmployeeSalaryHistory = db.vw_EmployeeSalaryHistory.Find(id);
            if (vw_EmployeeSalaryHistory == null)
            {
                return HttpNotFound();
            }
            return View(vw_EmployeeSalaryHistory);
        }

        public ActionResult EmployeeListDD()
        {
            List<DropDown_EmpployeeList> Employees = db.DropDown_EmpployeeList.ToList();
            ViewBag.Employees = new SelectList(Employees, "empID", "FullName");
            return View();
        }

        // GET: EmployeeSalaryHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeSalaryHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empID,Company,StartDate,EndDate,PositionDescription,MonthlySalary,SalaryGradeDescription,StepIncrement,EmpStatusDescription,IsGovService,workID")] vw_EmployeeSalaryHistory vw_EmployeeSalaryHistory)
        {
            if (ModelState.IsValid)
            {
                db.vw_EmployeeSalaryHistory.Add(vw_EmployeeSalaryHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_EmployeeSalaryHistory);
        }

        // GET: EmployeeSalaryHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_EmployeeSalaryHistory vw_EmployeeSalaryHistory = db.vw_EmployeeSalaryHistory.Find(id);
            if (vw_EmployeeSalaryHistory == null)
            {
                return HttpNotFound();
            }
            return View(vw_EmployeeSalaryHistory);
        }

        // POST: EmployeeSalaryHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empID,Company,StartDate,EndDate,PositionDescription,MonthlySalary,SalaryGradeDescription,StepIncrement,EmpStatusDescription,IsGovService,workID")] vw_EmployeeSalaryHistory vw_EmployeeSalaryHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_EmployeeSalaryHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_EmployeeSalaryHistory);
        }

        // GET: EmployeeSalaryHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_EmployeeSalaryHistory vw_EmployeeSalaryHistory = db.vw_EmployeeSalaryHistory.Find(id);
            if (vw_EmployeeSalaryHistory == null)
            {
                return HttpNotFound();
            }
            return View(vw_EmployeeSalaryHistory);
        }

        // POST: EmployeeSalaryHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vw_EmployeeSalaryHistory vw_EmployeeSalaryHistory = db.vw_EmployeeSalaryHistory.Find(id);
            db.vw_EmployeeSalaryHistory.Remove(vw_EmployeeSalaryHistory);
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
