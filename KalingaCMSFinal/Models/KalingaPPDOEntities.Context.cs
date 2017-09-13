﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KalingaCMSFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kalingaPPDOEntities : DbContext
    {
        public kalingaPPDOEntities()
            : base("name=kalingaPPDOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<appModule> appModules { get; set; }
        public virtual DbSet<appRole> appRoles { get; set; }
        public virtual DbSet<appUserAccess> appUserAccesses { get; set; }
        public virtual DbSet<appUser> appUsers { get; set; }
        public virtual DbSet<CoffeeProduction> CoffeeProductions { get; set; }
        public virtual DbSet<CornProduction> CornProductions { get; set; }
        public virtual DbSet<Emp_DTRCapture> Emp_DTRCapture { get; set; }
        public virtual DbSet<Emp_LeaveApplication> Emp_LeaveApplication { get; set; }
        public virtual DbSet<Emp_LeaveApplicationDetail> Emp_LeaveApplicationDetail { get; set; }
        public virtual DbSet<Emp_LeaveBalance> Emp_LeaveBalance { get; set; }
        public virtual DbSet<Emp_LeaveBalanceAudit> Emp_LeaveBalanceAudit { get; set; }
        public virtual DbSet<Emp_LeaveCredit> Emp_LeaveCredit { get; set; }
        public virtual DbSet<Emp_OffsetApplication> Emp_OffsetApplication { get; set; }
        public virtual DbSet<Emp_OffsetHoursBalance> Emp_OffsetHoursBalance { get; set; }
        public virtual DbSet<Emp_OvertimeApplication> Emp_OvertimeApplication { get; set; }
        public virtual DbSet<EmpAttendanceMain> EmpAttendanceMains { get; set; }
        public virtual DbSet<EmpCertificate> EmpCertificates { get; set; }
        public virtual DbSet<EmpEducationHistory> EmpEducationHistories { get; set; }
        public virtual DbSet<EmpFamilyBackGround> EmpFamilyBackGrounds { get; set; }
        public virtual DbSet<EmpTraining> EmpTrainings { get; set; }
        public virtual DbSet<EmpVolunteer> EmpVolunteers { get; set; }
        public virtual DbSet<EmpWorkHistory> EmpWorkHistories { get; set; }
        public virtual DbSet<EstablishmentByIndustry> EstablishmentByIndustries { get; set; }
        public virtual DbSet<ForestCoverVegetation> ForestCoverVegetations { get; set; }
        public virtual DbSet<IrrigationSystem> IrrigationSystems { get; set; }
        public virtual DbSet<LivestockPoultryInventory> LivestockPoultryInventories { get; set; }
        public virtual DbSet<OtherCropsProduction> OtherCropsProductions { get; set; }
        public virtual DbSet<PalayProduction> PalayProductions { get; set; }
        public virtual DbSet<PopulationByCitizenshipGender> PopulationByCitizenshipGenders { get; set; }
        public virtual DbSet<PopulationByEthnicity> PopulationByEthnicities { get; set; }
        public virtual DbSet<PopulationByLanguageSpoken> PopulationByLanguageSpokens { get; set; }
        public virtual DbSet<PopulationByReligiousAffiliation> PopulationByReligiousAffiliations { get; set; }
        public virtual DbSet<PopulationDensity> PopulationDensities { get; set; }
        public virtual DbSet<PopulationDistribution> PopulationDistributions { get; set; }
        public virtual DbSet<PopulationGrowthRate> PopulationGrowthRates { get; set; }
        public virtual DbSet<PopulationHighestEducationAttained> PopulationHighestEducationAttaineds { get; set; }
        public virtual DbSet<PopulationLiteracy10YrsAbove> PopulationLiteracy10YrsAbove { get; set; }
        public virtual DbSet<PopulationMigrationRate> PopulationMigrationRates { get; set; }
        public virtual DbSet<ProjectProfile> ProjectProfiles { get; set; }
        public virtual DbSet<ref_AccountCode> ref_AccountCode { get; set; }
        public virtual DbSet<ref_AgeGroup> ref_AgeGroup { get; set; }
        public virtual DbSet<ref_AppointmentStatus> ref_AppointmentStatus { get; set; }
        public virtual DbSet<ref_AreabySector> ref_AreabySector { get; set; }
        public virtual DbSet<ref_Barangay> ref_Barangay { get; set; }
        public virtual DbSet<ref_BDIPperMunicipality> ref_BDIPperMunicipality { get; set; }
        public virtual DbSet<ref_BloodType> ref_BloodType { get; set; }
        public virtual DbSet<ref_CivilStatus> ref_CivilStatus { get; set; }
        public virtual DbSet<ref_ClassWorker> ref_ClassWorker { get; set; }
        public virtual DbSet<ref_ClimateChangeTypology> ref_ClimateChangeTypology { get; set; }
        public virtual DbSet<ref_CoffeeType> ref_CoffeeType { get; set; }
        public virtual DbSet<ref_CornType> ref_CornType { get; set; }
        public virtual DbSet<ref_CropCommodity> ref_CropCommodity { get; set; }
        public virtual DbSet<ref_DayType> ref_DayType { get; set; }
        public virtual DbSet<ref_Degree> ref_Degree { get; set; }
        public virtual DbSet<ref_Department> ref_Department { get; set; }
        public virtual DbSet<ref_DepartmentUnit> ref_DepartmentUnit { get; set; }
        public virtual DbSet<ref_EducationLevel> ref_EducationLevel { get; set; }
        public virtual DbSet<ref_Ethnicity> ref_Ethnicity { get; set; }
        public virtual DbSet<ref_Gender> ref_Gender { get; set; }
        public virtual DbSet<ref_HighestEducationAttained> ref_HighestEducationAttained { get; set; }
        public virtual DbSet<ref_HighValueCrop> ref_HighValueCrop { get; set; }
        public virtual DbSet<ref_Holiday> ref_Holiday { get; set; }
        public virtual DbSet<ref_ImplementingDepartment> ref_ImplementingDepartment { get; set; }
        public virtual DbSet<ref_IndustryClassification> ref_IndustryClassification { get; set; }
        public virtual DbSet<ref_InvolvementType> ref_InvolvementType { get; set; }
        public virtual DbSet<ref_LandCoverClassification> ref_LandCoverClassification { get; set; }
        public virtual DbSet<ref_LanguageSpoken> ref_LanguageSpoken { get; set; }
        public virtual DbSet<ref_LeavePolicy> ref_LeavePolicy { get; set; }
        public virtual DbSet<ref_LeaveType> ref_LeaveType { get; set; }
        public virtual DbSet<ref_Literacy> ref_Literacy { get; set; }
        public virtual DbSet<ref_LivestockPoultry> ref_LivestockPoultry { get; set; }
        public virtual DbSet<ref_MajorBusinessIndustryGroup> ref_MajorBusinessIndustryGroup { get; set; }
        public virtual DbSet<ref_MajorOccupationGroup> ref_MajorOccupationGroup { get; set; }
        public virtual DbSet<ref_Method> ref_Method { get; set; }
        public virtual DbSet<ref_Municipality> ref_Municipality { get; set; }
        public virtual DbSet<ref_NamePrefix> ref_NamePrefix { get; set; }
        public virtual DbSet<ref_NameSuffix> ref_NameSuffix { get; set; }
        public virtual DbSet<ref_OfficialCode> ref_OfficialCode { get; set; }
        public virtual DbSet<ref_Origins> ref_Origins { get; set; }
        public virtual DbSet<ref_Position> ref_Position { get; set; }
        public virtual DbSet<ref_ProjectCategory> ref_ProjectCategory { get; set; }
        public virtual DbSet<ref_ProjectClassificationbyProgram> ref_ProjectClassificationbyProgram { get; set; }
        public virtual DbSet<ref_ProjectClassificationbySector> ref_ProjectClassificationbySector { get; set; }
        public virtual DbSet<ref_ProjectStatus> ref_ProjectStatus { get; set; }
        public virtual DbSet<ref_Province> ref_Province { get; set; }
        public virtual DbSet<ref_Regions> ref_Regions { get; set; }
        public virtual DbSet<ref_Relationship> ref_Relationship { get; set; }
        public virtual DbSet<ref_Religion> ref_Religion { get; set; }
        public virtual DbSet<ref_SalaryGrade> ref_SalaryGrade { get; set; }
        public virtual DbSet<ref_SalaryGradeIncrement> ref_SalaryGradeIncrement { get; set; }
        public virtual DbSet<ref_Sector> ref_Sector { get; set; }
        public virtual DbSet<ref_SourceOfFund> ref_SourceOfFund { get; set; }
        public virtual DbSet<ref_StrategicPriority> ref_StrategicPriority { get; set; }
        public virtual DbSet<ref_StrategicPriorityArea> ref_StrategicPriorityArea { get; set; }
        public virtual DbSet<ref_StrategicPriorityClassification> ref_StrategicPriorityClassification { get; set; }
        public virtual DbSet<ref_StrategicPriorityGroup> ref_StrategicPriorityGroup { get; set; }
        public virtual DbSet<WorkersByClass> WorkersByClasses { get; set; }
        public virtual DbSet<WorkersByMajorIndustry> WorkersByMajorIndustries { get; set; }
        public virtual DbSet<WorkersByMajorOCcupation> WorkersByMajorOCcupations { get; set; }
        public virtual DbSet<DropDown_AcountCode> DropDown_AcountCode { get; set; }
        public virtual DbSet<DropDown_AppUsers> DropDown_AppUsers { get; set; }
        public virtual DbSet<DropDown_Barangay> DropDown_Barangay { get; set; }
        public virtual DbSet<DropDown_BDIPMunicipality> DropDown_BDIPMunicipality { get; set; }
        public virtual DbSet<DropDown_ClimateChangeAdaptation> DropDown_ClimateChangeAdaptation { get; set; }
        public virtual DbSet<DropDown_ClimateChangeMitigation> DropDown_ClimateChangeMitigation { get; set; }
        public virtual DbSet<DropDown_ImplementingDepartment> DropDown_ImplementingDepartment { get; set; }
        public virtual DbSet<DropDown_Municipality> DropDown_Municipality { get; set; }
        public virtual DbSet<DropDown_OfficialCode> DropDown_OfficialCode { get; set; }
        public virtual DbSet<Dropdown_PriorityArea> Dropdown_PriorityArea { get; set; }
        public virtual DbSet<DropDown_ProgramCode> DropDown_ProgramCode { get; set; }
        public virtual DbSet<DropDown_SectoralCode> DropDown_SectoralCode { get; set; }
        public virtual DbSet<DropDown_SourceofFund> DropDown_SourceofFund { get; set; }
        public virtual DbSet<DropDown_SupervisorList> DropDown_SupervisorList { get; set; }
        public virtual DbSet<DropDown_TypologyCode> DropDown_TypologyCode { get; set; }
        public virtual DbSet<rep_HouseholdHighestEducationAttained> rep_HouseholdHighestEducationAttained { get; set; }
        public virtual DbSet<rep_PopulationDistributionByYearByMunicipality> rep_PopulationDistributionByYearByMunicipality { get; set; }
        public virtual DbSet<vw_AccountCodes> vw_AccountCodes { get; set; }
        public virtual DbSet<vw_BarangayList> vw_BarangayList { get; set; }
        public virtual DbSet<vw_BDIPperMunicipality> vw_BDIPperMunicipality { get; set; }
        public virtual DbSet<vw_ByMajorBusinessOrIndustry> vw_ByMajorBusinessOrIndustry { get; set; }
        public virtual DbSet<vw_ByMajorOccupationGroup> vw_ByMajorOccupationGroup { get; set; }
        public virtual DbSet<vw_ClassOfWorker> vw_ClassOfWorker { get; set; }
        public virtual DbSet<vw_ClimateChangeTypology> vw_ClimateChangeTypology { get; set; }
        public virtual DbSet<vw_CornAreaProductionYield> vw_CornAreaProductionYield { get; set; }
        public virtual DbSet<vw_DepartmentUnitsList> vw_DepartmentUnitsList { get; set; }
        public virtual DbSet<vw_EducationHistory> vw_EducationHistory { get; set; }
        public virtual DbSet<vw_EmployeeList> vw_EmployeeList { get; set; }
        public virtual DbSet<vw_EmployeeSalaryHistory> vw_EmployeeSalaryHistory { get; set; }
        public virtual DbSet<vw_EmploymentRecord> vw_EmploymentRecord { get; set; }
        public virtual DbSet<vw_EstablishmentByIndustryByYear> vw_EstablishmentByIndustryByYear { get; set; }
        public virtual DbSet<vw_ExamTaken> vw_ExamTaken { get; set; }
        public virtual DbSet<vw_FamilyBackground> vw_FamilyBackground { get; set; }
        public virtual DbSet<vw_ForestCoverByVegetationByYear> vw_ForestCoverByVegetationByYear { get; set; }
        public virtual DbSet<vw_GrowthRateByMunicipalityByYear> vw_GrowthRateByMunicipalityByYear { get; set; }
        public virtual DbSet<vw_HolidayList> vw_HolidayList { get; set; }
        public virtual DbSet<vw_HouseholdHighestEducationAttained> vw_HouseholdHighestEducationAttained { get; set; }
        public virtual DbSet<vw_HouseholdMigrationByYear> vw_HouseholdMigrationByYear { get; set; }
        public virtual DbSet<vw_HouseholdPopulation10YearsAbove> vw_HouseholdPopulation10YearsAbove { get; set; }
        public virtual DbSet<vw_HouseholdPopulationByCitizenshipAndSex> vw_HouseholdPopulationByCitizenshipAndSex { get; set; }
        public virtual DbSet<vw_LivestockAndPoultryInventoryByMunicipalityByYear> vw_LivestockAndPoultryInventoryByMunicipalityByYear { get; set; }
        public virtual DbSet<vw_MunicipalityList> vw_MunicipalityList { get; set; }
        public virtual DbSet<vw_OtherHighValueCropsAreaAndProduction> vw_OtherHighValueCropsAreaAndProduction { get; set; }
        public virtual DbSet<vw_PalayProductionIrrigatedRainfedUpland> vw_PalayProductionIrrigatedRainfedUpland { get; set; }
        public virtual DbSet<vw_PopulationByEthnicity> vw_PopulationByEthnicity { get; set; }
        public virtual DbSet<vw_PopulationByLanguageSpokenByYear> vw_PopulationByLanguageSpokenByYear { get; set; }
        public virtual DbSet<vw_PopulationDensityByMunicipalityByYear> vw_PopulationDensityByMunicipalityByYear { get; set; }
        public virtual DbSet<vw_ProjectAccountCode> vw_ProjectAccountCode { get; set; }
        public virtual DbSet<vw_ProjectProfile> vw_ProjectProfile { get; set; }
        public virtual DbSet<vw_ProvinceList> vw_ProvinceList { get; set; }
        public virtual DbSet<vw_RegionList> vw_RegionList { get; set; }
        public virtual DbSet<vw_ReligiousAffiliation> vw_ReligiousAffiliation { get; set; }
        public virtual DbSet<vw_StatusOfIrrigationSystemByMunicipalityByYear> vw_StatusOfIrrigationSystemByMunicipalityByYear { get; set; }
        public virtual DbSet<vw_StrategicPriorityArea> vw_StrategicPriorityArea { get; set; }
        public virtual DbSet<vw_TrainingsAttended> vw_TrainingsAttended { get; set; }
        public virtual DbSet<vw_VolunteerList> vw_VolunteerList { get; set; }
        public virtual DbSet<vw_appUsers> vw_appUsers { get; set; }
        public virtual DbSet<DropDown_AIPLevel1> DropDown_AIPLevel1 { get; set; }
        public virtual DbSet<DropDown_AIPLevel2> DropDown_AIPLevel2 { get; set; }
        public virtual DbSet<DropDown_AIPLevel3> DropDown_AIPLevel3 { get; set; }
        public virtual DbSet<DropDown_AIPLevel4> DropDown_AIPLevel4 { get; set; }
        public virtual DbSet<DropDown_AIPLevel5> DropDown_AIPLevel5 { get; set; }
        public virtual DbSet<DropDown_AIPLevel6> DropDown_AIPLevel6 { get; set; }
        public virtual DbSet<DropDown_EmpployeeList> DropDown_EmpployeeList { get; set; }
        public virtual DbSet<DropDown_ImplementingOffice> DropDown_ImplementingOffice { get; set; }
        public virtual DbSet<DropDown_LGULevel> DropDown_LGULevel { get; set; }
        public virtual DbSet<DropDown_OfficeType> DropDown_OfficeType { get; set; }
        public virtual DbSet<DropDown_StrategicPriority> DropDown_StrategicPriority { get; set; }
        public virtual DbSet<DropDown_TypologyCode2> DropDown_TypologyCode2 { get; set; }
        public virtual DbSet<rep_AIPLevel2> rep_AIPLevel2 { get; set; }
        public virtual DbSet<rep_AIPLevel3> rep_AIPLevel3 { get; set; }
        public virtual DbSet<rep_AIPLevel4> rep_AIPLevel4 { get; set; }
        public virtual DbSet<rep_AIPLevel5> rep_AIPLevel5 { get; set; }
        public virtual DbSet<rep_AIPLevel6> rep_AIPLevel6 { get; set; }
        public virtual DbSet<rep_OfficeType> rep_OfficeType { get; set; }
        public virtual DbSet<vw_AnnualInvestmentProgramProfile> vw_AnnualInvestmentProgramProfile { get; set; }
        public virtual DbSet<vw_Employment> vw_Employment { get; set; }
        public virtual DbSet<vw_Employment2> vw_Employment2 { get; set; }
        public virtual DbSet<AnnualInvestmentProgram> AnnualInvestmentPrograms { get; set; }
        public virtual DbSet<EmpEmploymentRecord> EmpEmploymentRecords { get; set; }
        public virtual DbSet<ProjectSignatory> ProjectSignatories { get; set; }
        public virtual DbSet<ref_AIP1stLevelSector> ref_AIP1stLevelSector { get; set; }
        public virtual DbSet<ref_AIP2ndLevel> ref_AIP2ndLevel { get; set; }
        public virtual DbSet<ref_AIP3rdLevel> ref_AIP3rdLevel { get; set; }
        public virtual DbSet<ref_AIP4thLevel> ref_AIP4thLevel { get; set; }
        public virtual DbSet<ref_AIP5thLevel> ref_AIP5thLevel { get; set; }
        public virtual DbSet<ref_AIP6thLevel> ref_AIP6thLevel { get; set; }
        public virtual DbSet<ref_ImplementingDept> ref_ImplementingDept { get; set; }
        public virtual DbSet<ref_OfficeType> ref_OfficeType { get; set; }
        public virtual DbSet<ref_LGULevel> ref_LGULevel { get; set; }
        public virtual DbSet<DropDown_Province> DropDown_Province { get; set; }
        public virtual DbSet<DropDown_Regions> DropDown_Regions { get; set; }
        public virtual DbSet<EmpMasterProfile> EmpMasterProfiles { get; set; }
    }
}
