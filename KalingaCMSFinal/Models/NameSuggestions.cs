using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Models
{
    public class NameSuggestions
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        public List<string> Search(string name)
        {
            return db.EmpMasterProfiles.Where(p => p.FirstName.StartsWith(name) ||
            p.LastName.StartsWith(name) ||
            p.MiddleName.StartsWith(name))
            .Select(p => p.FirstName + " " + p.MiddleName + " " + p.LastName).ToList();
        }
    }

    public class EmployeeName
    {
        public string EmployeeFullName { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeID { get; set; }
    }

    public class EmployeeMasterProfile
    {
        public int AgencyEmployeeNumber { get; set; }
        public int Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Suffix { get; set; }
        public int Gender { get; set; }
        public int Religion { get; set; }
        public int Country { get; set; }
        public int Region { get; set; }
        public int Province { get; set; }
        public int Municipality { get; set; }
        public int Barangay { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public int Telephone { get; set; }
        public int Country2 { get; set; }
        public int Region2 { get; set; }
        public int Province2 { get; set; }
        public int Municipality2 { get; set; }
        public int Barangay2 { get; set; }
        public string Street2 { get; set; }
        public int ZipCode2 { get; set; }
        public int Telephone2 { get; set; }
        public string DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public int CivilStatus { get; set; }
        public int Citizenship { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int BloodType { get; set; }
        public string GSIS { get; set; }
        public string PAGIBIG { get; set; }
        public string PhilHealth { get; set; }
        public string SSS { get; set; }
        public string TIN { get; set; }
        public string TelNo { get; set; }
        public string CelNo { get; set; }
        public string Email { get; set; }
        public int YearsInService { get; set; }
        public int MonthsInService { get; set; }
        public int FirstApprover { get; set; }
        public int SecondApprover { get; set; }
        public int IsSuperVisor { get; set; }
        public int IsSeparated { get; set; }
        public int Department { get; set; }
        public int DepartmentUnit { get; set; }
        public int AppointmentStatus { get; set; }
        public int Position { get; set; }
        public string DateHired { get; set; }
        public string DateResigned { get; set; }
        public double Salary { get; set; }
        public string DisplayPicturePath { get; set; }
    }

    public class EmployeeEducationDetails
    {
        public string EducationID { get; set; }
        public string Level { get; set; }
        public string SchoolName { get; set; }
        public string DegreeCourse { get; set; }
        public string YearGraduated { get; set; }
        public string HighestAttainment { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AcademicHonors { get; set; }
    }

    public class EmployeeWorkHistoryDetails
    {
        public string WorkID { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Position { get; set; }
        public string MonthlySalary { get; set; }
        public string SalaryGradeCode { get; set; }
        public string StepIncrement { get; set; }
        public string StatusDescription { get; set; }
        public string GovernmentService { get; set; }
    }
}