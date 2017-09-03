using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using KalingaCMSFinal.Security;
using System.IO;
using System.Web.Helpers;
using System.Configuration;
using System.Data.SqlClient;

namespace KalingaCMSFinal.Controllers
{
    //[CustomAuthorize(Roles = "SuperAdmin,HRAdmin")]
    public class PersonnelDataSheetController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: PersonnelDataSheet
        public ActionResult Index()
        {
            return View(db.EmpMasterProfiles.ToList());
        }

        // GET: PersonnelDataSheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpMasterProfile empMasterProfile = db.EmpMasterProfiles.Find(id);
            if (empMasterProfile == null)
            {
                return HttpNotFound();
            }
            return View(empMasterProfile);
        }

        //Prefix Dropdown
        public ActionResult PrefixDD()
        {
            List<ref_NamePrefix> NamePrefixes = db.ref_NamePrefix.ToList();
            ViewBag.NamePrefixes = new SelectList(NamePrefixes, "NamePrefixTitleID", "Prefix");
            return View();
        }

        //Suffix Dropdown
        public ActionResult SuffixDD()
        {
            List<ref_NameSuffix> NameSuffixes = db.ref_NameSuffix.ToList();
            ViewBag.NameSuffixes = new SelectList(NameSuffixes, "NameSuffixTitleID", "Suffix");
            return View();
        }

        //Gender Dropdown
        public ActionResult GenderDD()
        {
            List<ref_Gender> Genders = db.ref_Gender.ToList();
            ViewBag.Genders = new SelectList(Genders, "genderID", "genderDescription");
            return View();
        }

        //Religion Dropdown
        public ActionResult ReligionDD()
        {
            List<ref_Religion> Religions = db.ref_Religion.ToList();
            ViewBag.Religions = new SelectList(Religions, "religionID", "religionDescription");
            return View();
        }

        //CivilStatus Dropdown
        public ActionResult CivilStatusDD()
        {
            List<ref_CivilStatus> CivilStatuses = db.ref_CivilStatus.ToList();
            ViewBag.CivilStatuses = new SelectList(CivilStatuses, "CivilStatusID", "CivilStatusDescription");
            return View();
        }

        //Citizenship Dropdown
        public ActionResult CitizenshipDD()
        {
            List<ref_Origins> Citizenships = db.ref_Origins.ToList();
            ViewBag.Citizenships = new SelectList(Citizenships, "CountryID", "Nationality");
            return View();
        }

        //1stApprover Dropdown
        public ActionResult SupervisorsDD()
        {
            List<DropDown_SupervisorList> Supervisors = db.DropDown_SupervisorList.ToList();
            ViewBag.Supervisors = new SelectList(Supervisors, "empID", "Supervisor");
            return View();
        }

        //Department Dropdown
        public ActionResult DepartmentDD()
        {
            List<ref_Department> Departments = db.ref_Department.ToList();
            ViewBag.Departments = new SelectList(Departments, "DeptID", "DeptDescription");
            return View();
        }

        //DepartmentUnit Dropdown
        public ActionResult DepartmentUnitDD()
        {
            List<ref_DepartmentUnit> DepartmentUnits = db.ref_DepartmentUnit.ToList();
            ViewBag.DepartmentUnits = new SelectList(DepartmentUnits, "DepartmentUnitID", "DepartmentUnitDescription");
            return View();
        }

        //AppointmentStatus Dropdown
        public ActionResult AppointmentStatusDD()
        {
            List<ref_AppointmentStatus> AppointmentStatuses = db.ref_AppointmentStatus.ToList();
            ViewBag.AppointmentStatuses = new SelectList(AppointmentStatuses, "AppointmentStatusID", "EmpStatusDescription");
            return View();
        }

        //Positions Dropdown
        public ActionResult PositionDD()
        {
            List<ref_Position> Positions = db.ref_Position.ToList();
            ViewBag.Positions = new SelectList(Positions, "PositionID", "PositionDescription");
            return View();
        }

        //Positions Dropdown
        public ActionResult CountryDD()
        {
            List<ref_Origins> Countries = db.ref_Origins.ToList();
            ViewBag.Countries = new SelectList(Countries, "CountryID", "Country");
            return View();
        }

        //Positions Dropdown
        public ActionResult BloodTypeDD()
        {
            List<ref_BloodType> BloodTypes = db.ref_BloodType.ToList();
            ViewBag.BloodTypes = new SelectList(BloodTypes, "BloodTypeID", "BloodTypeDescription");
            return View();
        }

        public JsonResult GetRegionList(int CountryID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_RegionList> Regions = db.vw_RegionList.Where(x => x.CountryID == CountryID).ToList();
            return Json(Regions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProvinceList(int RegionID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_ProvinceList> Provinces = db.vw_ProvinceList.Where(x => x.RegionID == RegionID).ToList();
            return Json(Provinces, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipalityList(int ProvinceID)
        {
           db.Configuration.ProxyCreationEnabled = false;
            List<vw_MunicipalityList> Municipalities = db.vw_MunicipalityList.Where(x => x.provinceID == ProvinceID).ToList();
            return Json(Municipalities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBarangayList(int MunicipalityID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<vw_BarangayList> Barangays = db.vw_BarangayList.Where(x => x.MunicipalityID == MunicipalityID).ToList();
            return Json(Barangays, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmployeeProfile(int EmployeeID)
        {
            List<EmployeeMasterProfile> t = new List<EmployeeMasterProfile>();
            string conn = ConfigurationManager.ConnectionStrings["kalingaPPDO"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                string myQuery = "select * from EmpMasterProfile where empid = @EmployeeID";
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
                        EmployeeMasterProfile tsData = new EmployeeMasterProfile()
                        {
                            AgencyEmployeeNumber = int.Parse(dr["empNo"].ToString()),
                            Prefix = int.Parse(dr["namePrefixTitleID"].ToString()),
                            FirstName = dr["FirstName"].ToString(),
                            MiddleName = dr["MiddleName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Suffix = int.Parse(dr["namePrefixTitleID"].ToString()),
                            Gender = int.Parse(dr["GenderID"].ToString()),
                            Religion = int.Parse(dr["ReligionID"].ToString()),
                            Country = int.Parse(dr["CountryID"].ToString()),
                            Region = int.Parse(dr["RegionID"].ToString()),
                            Province = int.Parse(dr["ProvinceID"].ToString()),
                            Municipality = int.Parse(dr["MunicipalityID"].ToString()),
                            Barangay = int.Parse(dr["BarangayID"].ToString()),
                            Street = dr["Street"].ToString(),
                            Country2 = int.Parse(dr["CountryID2"].ToString()),
                            Region2 = int.Parse(dr["RegionID2"].ToString()),
                            Province2 = int.Parse(dr["ProvinceID2"].ToString()),
                            Municipality2 = int.Parse(dr["MunicipalityID2"].ToString()),
                            Barangay2 = int.Parse(dr["BarangayID"].ToString()),
                            Street2 = dr["Street2"].ToString(),
                            Telephone = int.Parse(dr["residentialPhoneNo"].ToString()),
                            Telephone2 = int.Parse(dr["residentialPhoneNo2"].ToString()),
                            ZipCode = int.Parse(dr["zipCode"].ToString()),
                            ZipCode2 = int.Parse(dr["zipCode2"].ToString()),
                            DateofBirth = dr["birthDate"].ToString(),
                            PlaceofBirth = dr["birthPlace"].ToString(),
                            CivilStatus = int.Parse(dr["CivilStatusID"].ToString()),
                            Citizenship = int.Parse(dr["CitizenshipID"].ToString()),
                            Height = dr["Height"].ToString(),
                            Weight = dr["Weight"].ToString(),
                            BloodType = int.Parse(dr["BloodTypeID"].ToString()),
                            GSIS = dr["GSIS"].ToString(),
                            PAGIBIG = dr["HDMF"].ToString(),
                            PhilHealth = dr["PhilHealth"].ToString(),
                            SSS = dr["SSS"].ToString(),
                            TIN = dr["TIN"].ToString(),
                            Email = dr["EmailAddress"].ToString(),
                            TelNo = dr["LandLineNo"].ToString(),
                            CelNo = dr["CellphoneNo"].ToString(),
                            FirstApprover = int.Parse(dr["FirstApprover"].ToString()),
                            SecondApprover = int.Parse(dr["SecondApprover"].ToString()),
                            IsSeparated = int.Parse(dr["IsSeparated"].ToString()),
                            IsSuperVisor = int.Parse(dr["IsSuperVisor"].ToString()),
                            YearsInService = int.Parse(dr["YearsInService"].ToString()),
                            MonthsInService = int.Parse(dr["MonthsInService"].ToString()),
                            Department = int.Parse(dr["DepartmentID"].ToString()),
                            DepartmentUnit = int.Parse(dr["DepartmentUnitID"].ToString()),
                            AppointmentStatus = int.Parse(dr["AppointmentStatusID"].ToString()),
                            Position = int.Parse(dr["PositionID"].ToString()),
                            DateHired = dr["Company"].ToString(),
                            DateResigned = dr["Company"].ToString(),
                            Salary = double.Parse(dr["Company"].ToString()),
                            DisplayPicturePath = dr["DisplayPicturePath"].ToString()
                        };
                        t.Add(tsData);
                        counter++;
                    }
                }
            }
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        // GET: PersonnelDataSheet/Create
        public ActionResult Create()
        {
            CountryDD();
            BloodTypeDD();
            CitizenshipDD();
            CivilStatusDD();
            GenderDD();
            PrefixDD();
            ReligionDD();
            SuffixDD();
            SupervisorsDD();
            DepartmentDD();
            DepartmentUnitDD();
            AppointmentStatusDD();
            PositionDD();
            return View(Tuple.Create<EmpMasterProfile, IEnumerable<vw_EmployeeList>>(new EmpMasterProfile(), db.vw_EmployeeList.ToList()));
        }

        // POST: PersonnelDataSheet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix="Item1", Include = "empid,empNo,namePrefixTitleID,LastName,MiddleName,FirstName,nameSuffixTitleID,GenderID,ReligionID,street,BarangayID,MunicipalityID,ProvinceID,CountryID,zipCode,residentialPhoneNo,street2,BarangayID2,MunicipalityID2,ProvinceID2,CountryID2,zipCode2,residentialPhoneNo2,birthDate,birthPlace,CivilStatusID,CitizenshipID,Height,Weight,BloodTypeID,GSIS,HDMF,PhilHealth,SSS,TIN,LandLineNo,CellphoneNo,EmailAddress,YearsInService,MonthsInService,IsSupervisor,FirstApprover,SecondApprover,IsSeparated,DeptID,DepartmentUnitID,AppointmentStatusID,PositionID,DateHired,DateResigned,CurrentSalary,DisplayPicturePath,RegionID,RegionID2")] EmpMasterProfile empMasterProfile, HttpPostedFileBase File)
        {
            if (File != null)
            {
                if (File.ContentLength > 0)
                {
                    if ((Path.GetExtension(File.FileName).ToLower() == ".jpg") ||
                        (Path.GetExtension(File.FileName).ToLower() == ".jpeg") ||
                        (Path.GetExtension(File.FileName).ToLower() == ".png") ||
                        (Path.GetExtension(File.FileName).ToLower() == ".gif"))
                    {
                        WebImage img = new WebImage(File.InputStream);
                        if ((img.Width > 180) || (img.Height > 190))
                        {
                            img.Resize(190, 180);
                            string extension = Path.GetExtension(File.FileName);
                            string filename = empMasterProfile.FirstName + empMasterProfile.MiddleName + empMasterProfile.LastName + DateTime.Now.ToString("MMddyy") + extension;
                            empMasterProfile.DisplayPicturePath = "~/Content/EmployeeProfileImages/" + filename;
                            img.Save(empMasterProfile.DisplayPicturePath);
                            filename = Path.Combine(Server.MapPath("~/Content/EmployeeProfileImages/"), filename);
                        }
                        else
                        {
                            string extension = Path.GetExtension(File.FileName);
                            string filename = empMasterProfile.FirstName + empMasterProfile.MiddleName + empMasterProfile.LastName + DateTime.Now.ToString("MMddyy") + extension;
                            empMasterProfile.DisplayPicturePath = "~/Content/EmployeeProfileImages/" + filename;
                            filename = Path.Combine(Server.MapPath("~/Content/EmployeeProfileImages/"), filename);
                            File.SaveAs(filename);
                        }
                    }
                }
            }
            else
            {
                empMasterProfile.DisplayPicturePath = null;
            }
            if (ModelState.IsValid)
            {
                db.EmpMasterProfiles.Add(empMasterProfile);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(empMasterProfile);
        }

        // GET: PersonnelDataSheet/Edit/5
        public ActionResult Edit(int? id)
        {
            CountryDD();
            BloodTypeDD();
            CitizenshipDD();
            CivilStatusDD();
            GenderDD();
            PrefixDD();
            ReligionDD();
            SuffixDD();
            SupervisorsDD();
            DepartmentDD();
            DepartmentUnitDD();
            AppointmentStatusDD();
            PositionDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpMasterProfile empMasterProfile = db.EmpMasterProfiles.Find(id);
            if (empMasterProfile == null)
            {
                return HttpNotFound();
            }
            return View(empMasterProfile);
        }

        // POST: PersonnelDataSheet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empid,empNo,namePrefixTitleID,LastName,MiddleName,FirstName,nameSuffixTitleID,GenderID,ReligionID,street,BarangayID,MunicipalityID,ProvinceID,CountryID,zipCode,residentialPhoneNo,street2,BarangayID2,MunicipalityID2,ProvinceID2,CountryID2,zipCode2,residentialPhoneNo2,birthDate,birthPlace,CivilStatusID,CitizenshipID,Height,Weight,BloodTypeID,GSIS,HDMF,PhilHealth,SSS,TIN,LandLineNo,CellphoneNo,EmailAddress,YearsInService,MonthsInService,IsSupervisor,FirstApprover,SecondApprover,IsSeparated,DeptID,DepartmentUnitID,AppointmentStatusID,PositionID,DateHired,DateResigned,CurrentSalary,DisplayPicturePath,RegionID,RegionID2")] EmpMasterProfile empMasterProfile)
        {

            if (ModelState.IsValid)
            {
                db.Entry(empMasterProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(empMasterProfile);
        }

        // GET: PersonnelDataSheet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpMasterProfile empMasterProfile = db.EmpMasterProfiles.Find(id);
            if (empMasterProfile == null)
            {
                return HttpNotFound();
            }
            return View(empMasterProfile);
        }

        // POST: PersonnelDataSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpMasterProfile empMasterProfile = db.EmpMasterProfiles.Find(id);
            db.EmpMasterProfiles.Remove(empMasterProfile);
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
