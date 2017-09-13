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
    public class TrainingsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Trainings
        public ActionResult Index()
        {
            return View(db.EmpTrainings.ToList());
        }

        // GET: Trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            if (empTraining == null)
            {
                return HttpNotFound();
            }
            return View(empTraining);
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

        // GET: Trainings/Create
        public ActionResult Create()
        {
            return View(Tuple.Create<EmpTraining, IEnumerable<vw_TrainingsAttended>>(new EmpTraining(), db.vw_TrainingsAttended.ToList()));
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "empTrainID,empID,TrainingTitle,StartDate,EndDate,DurationHours,EventSponsor,EventVenue")] EmpTraining empTraining)
        {
            if (ModelState.IsValid)
            {
                db.EmpTrainings.Add(empTraining);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(empTraining);
        }

        public JsonResult Trainings(int EmployeeID)
        {
            List<Trainings> t = new List<Trainings>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from vw_TrainingsAttended where empid = @EmployeeID";
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
                        Trainings tsData = new Trainings()
                        {
                            empTrainID = dr["empTrainID"].ToString(),
                            TrainingTitle = dr["TrainingTitle"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            EndDate = dr["EndDate"].ToString(),
                            DurationHours = dr["DurationHours"].ToString(),
                            EventSponsor = dr["EventSponsor"].ToString(),
                            EventVenue = dr["EventVenue"].ToString(),
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: Trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            if (empTraining == null)
            {
                return HttpNotFound();
            }
            return View(empTraining);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Prefix="Item1", Include = "empTrainID,empID,TrainingTitle,StartDate,EndDate,DurationHours,EventSponsor,EventVenue")] EmpTraining empTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empTraining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empTraining);
        }

        // GET: Trainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            if (empTraining == null)
            {
                return HttpNotFound();
            }
            return View(empTraining);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpTraining empTraining = db.EmpTrainings.Find(id);
            db.EmpTrainings.Remove(empTraining);
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
