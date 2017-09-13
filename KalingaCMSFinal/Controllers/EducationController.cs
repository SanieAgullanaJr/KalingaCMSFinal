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
    public class EducationController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Education
        public ActionResult Index()
        {
            return View(db.EmpEducationHistories.ToList());
        }

        // GET: Education/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpEducationHistory empEducationHistory = db.EmpEducationHistories.Find(id);
            if (empEducationHistory == null)
            {
                return HttpNotFound();
            }
            return View(empEducationHistory);
        }

        public ActionResult LevelDD()
        {
            List<ref_EducationLevel> Levels = db.ref_EducationLevel.ToList();
            ViewBag.Levels = new SelectList(Levels, "EducLevelID", "EducLevel");
            return View();
        }

        public ActionResult DegreeDD()
        {
            List<ref_Degree> Degrees = db.ref_Degree.ToList();
            ViewBag.Degrees = new SelectList(Degrees, "degreeID", "Degree");
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
                string myQuery = "select empid, empNo, CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS FullName, DisplayPicturePath from EmpMasterProfile where CONCAT(FirstName, ' ', MiddleName, ' ', LastName) LIKE @Name";
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
                            EmployeeID = dr["empid"].ToString(),
                            DisplayPicturePath = dr["DisplayPicturePath"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EducationHistory(int EmployeeID)
        {
            List<EmployeeEducationDetails> t = new List<EmployeeEducationDetails>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_EducationHistory where empid = @EmployeeID";
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
                        EmployeeEducationDetails tsData = new EmployeeEducationDetails()
                        {
                            EducationID = dr["empEducID"].ToString(),
                            Level = dr["EducLevel"].ToString(),
                            SchoolName = dr["SchoolName"].ToString(),
                            DegreeCourse = dr["Degree"].ToString(),
                            YearGraduated = dr["YearGraduated"].ToString(),
                            HighestAttainment = dr["Earned"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            AcademicHonors = dr["Distinction"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: Education/Create
        public ActionResult Create()
        {
            LevelDD();
            DegreeDD();
            return View(Tuple.Create<EmpEducationHistory, IEnumerable<vw_EducationHistory>>(new EmpEducationHistory(), db.vw_EducationHistory.ToList()));
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "empEducID,empID,EducLevelID,SchoolName,DegreeID,YearGraduated,Earned,StartDate,EndDate,Distinction")] EmpEducationHistory empEducationHistory)
        {
            if (ModelState.IsValid)
            {
                db.EmpEducationHistories.Add(empEducationHistory);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(empEducationHistory);
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int? id)
        {
            LevelDD();
            DegreeDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpEducationHistory empEducationHistory = db.EmpEducationHistories.Find(id);
            if (empEducationHistory == null)
            {
                return HttpNotFound();
            }
            return View(empEducationHistory);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empEducID,empID,EducLevelID,SchoolName,DegreeID,YearGraduated,Earned,StartDate,EndDate,Distinction")] EmpEducationHistory empEducationHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empEducationHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empEducationHistory);
        }

        // GET: Education/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpEducationHistory empEducationHistory = db.EmpEducationHistories.Find(id);
            if (empEducationHistory == null)
            {
                return HttpNotFound();
            }
            return View(empEducationHistory);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpEducationHistory empEducationHistory = db.EmpEducationHistories.Find(id);
            db.EmpEducationHistories.Remove(empEducationHistory);
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
