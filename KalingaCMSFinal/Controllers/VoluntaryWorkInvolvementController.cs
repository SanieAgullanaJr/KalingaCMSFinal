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
    public class VoluntaryWorkInvolvementController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: VoluntaryWorkInvolvement
        public ActionResult Index()
        {
            return View(db.EmpVolunteers.ToList());
        }

        // GET: VoluntaryWorkInvolvement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            if (empVolunteer == null)
            {
                return HttpNotFound();
            }
            return View(empVolunteer);
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

        public JsonResult Volunteers(int EmployeeID)
        {
            List<Volunteer> t = new List<Volunteer>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_VolunteerList where empid = @EmployeeID";
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
                        Volunteer tsData = new Volunteer()
                        {
                            empVolID = dr["empVolID"].ToString(),
                            OrganizationName = dr["OrganizationName"].ToString(),
                            OrganizationAddress = dr["OrganizationAddress"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            HoursVolunteered = dr["HoursVolunteered"].ToString(),
                            InvolvementTypeDescription = dr["InvolvementTypeDescription"].ToString(),
                            OrganizationNature = dr["OrganizationNature"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        //Involvement Dropdown
        public ActionResult InvolvementDD()
        {
            List<ref_InvolvementType> Involvements = db.ref_InvolvementType.ToList();
            ViewBag.Involvements = new SelectList(Involvements, "InvolvementTypeID", "InvolvementTypeDescription");
            return View();
        }

        // GET: VoluntaryWorkInvolvement/Create
        public ActionResult Create()
        {
            InvolvementDD();
            return View(Tuple.Create<EmpVolunteer, IEnumerable<vw_VolunteerList>>(new EmpVolunteer(), db.vw_VolunteerList.ToList()));
        }

        // POST: VoluntaryWorkInvolvement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "empVolID,empID,OrganizationName,OrganizationAddress,StartDate,EndDate,HoursVolunteered,InvolveTypeID,OrganizationNature")] EmpVolunteer empVolunteer)
        {
            if (ModelState.IsValid)
            {
                db.EmpVolunteers.Add(empVolunteer);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(empVolunteer);
        }

        // GET: VoluntaryWorkInvolvement/Edit/5
        public ActionResult Edit(int? id)
        {
            InvolvementDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            if (empVolunteer == null)
            {
                return HttpNotFound();
            }
            return View(empVolunteer);
        }

        // POST: VoluntaryWorkInvolvement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empVolID,empID,OrganizationName,OrganizationAddress,StartDate,EndDate,HoursVolunteered,InvolveTypeID,OrganizationNature")] EmpVolunteer empVolunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empVolunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empVolunteer);
        }

        // GET: VoluntaryWorkInvolvement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            if (empVolunteer == null)
            {
                return HttpNotFound();
            }
            return View(empVolunteer);
        }

        // POST: VoluntaryWorkInvolvement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpVolunteer empVolunteer = db.EmpVolunteers.Find(id);
            db.EmpVolunteers.Remove(empVolunteer);
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
