using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalingaCMSFinal.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Reflection;

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
        public string DisplayPicturePath { get; set; }
    }

    public class EmployeeMasterProfile
    {
        public string EmployeeID { get; set; }
        public string AgencyEmployeeNumber { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string Barangay { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Country2 { get; set; }
        public string Region2 { get; set; }
        public string Province2 { get; set; }
        public string Municipality2 { get; set; }
        public string Barangay2 { get; set; }
        public string Street2 { get; set; }
        public string ZipCode2 { get; set; }
        public string Telephone2 { get; set; }
        public string DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public string CivilStatus { get; set; }
        public string Citizenship { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodType { get; set; }
        public string GSIS { get; set; }
        public string PAGIBIG { get; set; }
        public string PhilHealth { get; set; }
        public string SSS { get; set; }
        public string TIN { get; set; }
        public string TelNo { get; set; }
        public string CelNo { get; set; }
        public string Email { get; set; }
        public string YearsInService { get; set; }
        public string MonthsInService { get; set; }
        public string FirstApprover { get; set; }
        public string SecondApprover { get; set; }
        public string IsSuperVisor { get; set; }
        public string IsSeparated { get; set; }
        public string Department { get; set; }
        public string DepartmentUnit { get; set; }
        public string AppointmentStatus { get; set; }
        public string Position { get; set; }
        public string DateHired { get; set; }
        public string DateResigned { get; set; }
        public string Salary { get; set; }
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
    public class FamilyBackground
    {
        public string empFamBGID { get; set; }
        public string Relationship { get; set; }
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
    }

    public class CertificatesAndLicensures
    {
        public string empCertID { get; set; }
        public string ExamName { get; set; }
        public string Rating { get; set; }
        public string ExamDate { get; set; }
        public string ExamVenue { get; set; }
        public string LicenseNumber { get; set; }
        public string ReleaseDate { get; set; }
    }

    public class Trainings
    {
        public string empTrainID { get; set; }
        public string TrainingTitle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DurationHours { get; set; }
        public string EventSponsor { get; set; }
        public string EventVenue { get; set; }
    }

    public class Volunteer
    {
        public string empVolID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string HoursVolunteered { get; set; }
        public string InvolvementTypeDescription { get; set; }
        public string OrganizationNature { get; set; }
    }

    public class Locations
    {
        public string CountryID { get; set; }
        public string RegionID { get; set; }
        public string ProvinceID { get; set; }
        public string MunicipalityID { get; set; }
        public string BarangayID { get; set; }
    }

    public class TableData
    {
        public string Region { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string Barangay { get; set; }
        public string BarangayID { get; set; }
        public string ZipCode { get; set; }
        public string MunicipalityID { get; set; }
    }
}