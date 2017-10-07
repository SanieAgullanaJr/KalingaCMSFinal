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
    public class CertificatesAndLicensuresController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: CertificatesAndLicensures
        public ActionResult Index()
        {
            return View(db.EmpCertificates.ToList());
        }

        // GET: CertificatesAndLicensures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            if (empCertificate == null)
            {
                return HttpNotFound();
            }
            return View(empCertificate);
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

        public JsonResult CertAndLicensures(int EmployeeID)
        {
            List<CertificatesAndLicensures> t = new List<CertificatesAndLicensures>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_ExamTaken where empid = @EmployeeID";
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
                        CertificatesAndLicensures tsData = new CertificatesAndLicensures()
                        {
                            empCertID = dr["empCertID"].ToString(),
                            ExamName = dr["ExamName"].ToString(),
                            Rating = dr["Rating"].ToString(),
                            ExamDate = dr["ExamDate"].ToString(),
                            ExamVenue = dr["ExamVenue"].ToString(),
                            LicenseNumber = dr["LicenseNumber"].ToString(),
                            ReleaseDate = dr["ReleaseDate"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: CertificatesAndLicensures/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<EmpCertificate, IEnumerable<vw_ExamTaken>>(new EmpCertificate(), db.vw_ExamTaken.ToList()));
        }

        // POST: CertificatesAndLicensures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "empCertID,empID,ExamName,Rating,ExamDate,ExamVenue,LicenseNumber,ReleaseDate")] EmpCertificate empCertificate)
        {
            if (ModelState.IsValid)
            {
                db.EmpCertificates.Add(empCertificate);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empCertificate);
        }

        // GET: CertificatesAndLicensures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            if (empCertificate == null)
            {
                return HttpNotFound();
            }
            return View(empCertificate);
        }

        // POST: CertificatesAndLicensures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empCertID,empID,ExamName,Rating,ExamDate,ExamVenue,LicenseNumber,ReleaseDate")] EmpCertificate empCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empCertificate);
        }

        // GET: CertificatesAndLicensures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            if (empCertificate == null)
            {
                return HttpNotFound();
            }
            return View(empCertificate);
        }

        // POST: CertificatesAndLicensures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpCertificate empCertificate = db.EmpCertificates.Find(id);
            db.EmpCertificates.Remove(empCertificate);
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
