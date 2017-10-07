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

    public class SalaryHistory
    {
        public string Department { get; set; }
        public string DateHired { get; set; }
        public string DateResigned { get; set; }
        public string PositionTitle { get; set; }
        public string MonthlySalary { get; set; }
        public string SalaryGrade { get; set; }
        public string StepIncrement { get; set; }
        public string AppointmentStatus { get; set; }
        public string GovernmentService { get; set; }
    }

    public class LeaveApplicationHistory
    {
        public string empLeaveAppID { get; set; }
        public string empID { get; set; }
        public string empAttendanceMainID { get; set; }
        public string Fullname { get; set; }
        public string LeaveTypeDescription { get; set; }
        public string DateFiled { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Supervisor { get; set; }
        public string IsApproved { get; set; }
        public string IsWithPay { get; set; }
        public string IsCancelled { get; set; }
        public string Remarks { get; set; }
        public string AppliedHours { get; set; }
    }

    public class LeaveBalance
    {
        public string LeaveType { get; set; }
        public string Days { get; set; }
        public string Hours { get; set; }
    }

    public class OffsetBalance
    {
        public string ExpirationDate { get; set; }
        public string Days { get; set; }
        public string Hours { get; set; }
    }

    public class LeaveApplicationData
    {
        public string empLeaveAppID { get; set; }
        public string empAttendanceMainID { get; set; }
        public string LeaveType { get; set; }
        public string LeaveReason { get; set; }
        public string DateFiled { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AppliedHours { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string IsApproved { get; set; }
        public string IsWithPay { get; set; }
        public string IsCancelled { get; set; }
        public string Remarks { get; set; }
        public string StampTime { get; set; }
    }

    public class LeaveCreditsData
    {
        public string VLID { get; set; }
        public string SLID { get; set; }
        public string OSID { get; set; }
        public string VLDateAcquired { get; set; }
        public string VLEarnedHours { get; set; }
        public string SLDateAcquired { get; set; }
        public string SLEarnedHours { get; set; }
        public string OSDateAcquired { get; set; }
        public string OSEarnedHours { get; set; }
    }

    public class AbsencesAndTardiness
    {
        public string empAttendanceMainID { get; set; }
        public string NameDate { get; set; }
        public string DTRDate { get; set; }
        public string empID { get; set; }
        public string LOGIN { get; set; }
        public string LOGOUT { get; set; }
        public string AbsHrs { get; set; }
        public string AbsHrsDec { get; set; }
        public string LateHrs { get; set; }
        public string LateHrsDec { get; set; }
        public string UnderTimeHours { get; set; }
        public string UnderTimeHoursDec { get; set; }
        public string LeaveTypeCode { get; set; }
        public string OTHrs { get; set; }
        public string OTHrsDec { get; set; }
    }

    public class OvertimeApplicationData
    {
        public string empOTID { get; set; }
        public string empID { get; set; }
        public string AttendanceDetailDTRId { get; set; }
        public string In1 { get; set; }
        public string Out1 { get; set; }
        public string OTReason { get; set; }
        public string AppliedOTHoursDec { get; set; }
        public string AppliedOTHoursCHAR { get; set; }
        public string SupervisorID { get; set; }
        public string Remarks { get; set; }
        public string DateApproved { get; set; }
        public string DateApplied { get; set; }
        public string IsApproved { get; set; }
        public string IsDenied { get; set; }
        public string DTRDate { get; set; }
    }

    public class OvertimeHistory
    {
        public string empOTID { get; set; }
        public string empID { get; set; }
        public string DateApplied { get; set; }
        public string AttendanceDetailDTRId { get; set; }
        public string DTRDate { get; set; }
        public string LOGIN { get; set; }
        public string LOGOUT { get; set; }
        public string AppliedOTHoursDEC { get; set; }
        public string AppliedOTHoursCHAR { get; set; }
        public string SupervisorID { get; set; }
        public string IsApproved { get; set; }
        public string IsDenied { get; set; }
        public string DateApproved { get; set; }
    }

    public class OTWorkFromDTR
    {
        public string AttendanceDetailDTRId { get; set; }
        public string empAttendanceMainID { get; set; }
        public string empID { get; set; }
        public string NameDate { get; set; }
        public string DTRDate { get; set; }
        public string LOGIN { get; set; }
        public string LOGOUT { get; set; }
        public string OTHrs { get; set; }
        public string OTHrsDec { get; set; }
    }
}