using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KalingaCMSFinal.Models
{
    [MetadataType(typeof(appUserMetadata))]
    public partial class appUser
    {
    }
    public class appUserMetadata
    {
        public int appuserid { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public Nullable<int> empid { get; set; }


        [Required(ErrorMessage = "Username is Required")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public string[] roles { get; set; }
    }

    [MetadataType(typeof(CornProductionMetadata))]
    public partial class CornProduction
    {
    }
    public class CornProductionMetadata
    {
        public int CornProdID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Corn")]
        public Nullable<int> CornID { get; set; }

        [Required]
        [Display(Name = "Area Hecatares")]
        public Nullable<int> AreaHectares { get; set; }

        [Required]
        [Display(Name = "Production")]
        public Nullable<int> Production { get; set; }

        [Required]
        [Display(Name = "Production Yield")]
        public Nullable<decimal> ProdYield { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(CoffeeProductionMetadata))]
    public partial class CoffeeProduction
    {
    }

    public class CoffeeProductionMetadata
    {
        public int CoffeeProdID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Coffee")]
        public Nullable<int> CoffeeID { get; set; }

        [Required]
        [Display(Name = "Area Hectares")]
        public Nullable<int> AreaHectares { get; set; }

        [Required]
        [Display(Name = "Total Production (MT)")]
        public Nullable<decimal> TotalProd { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(EstablishmentByIndustryMetadata))]
    public partial class EstablishmentByIndustry
    {
    }

    public class EstablishmentByIndustryMetadata
    {
        public int EstablishID { get; set; }

        [Required]
        [Display(Name = "Industry Class")]
        public Nullable<int> IndustryClassID { get; set; }

        [Required]
        [Display(Name = "Number of Firms")]
        public Nullable<int> NumberofFirms { get; set; }

        [Required]
        [Display(Name = "%")]
        public Nullable<decimal> PercentFirms { get; set; }

        [Required]
        [Display(Name = "Investment (Peso)")]
        public Nullable<decimal> Investment { get; set; }

        [Required]
        [Display(Name = "%")]
        public Nullable<decimal> PercentInvest { get; set; }

        [Required]
        [Display(Name = "Number of Employess")]
        public Nullable<int> NumberofEmployee { get; set; }

        [Required]
        [Display(Name = "%")]
        public Nullable<decimal> Distribution { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }
    [MetadataType(typeof(ForestCoverVegetationMetaData))]
    public partial class ForestCoverVegetation
    {
    }

    public class ForestCoverVegetationMetaData
    {
        public int VegetationID { get; set; }

        [Required]
        [Display(Name = "Land Cover Classification")]
        public Nullable<int> LandCoverClassID { get; set; }

        [Required]
        [Display(Name = "Area Hectares")]
        public Nullable<decimal> AreaHectares { get; set; }

        [Required]
        [Display(Name = "Distribution")]
        public Nullable<decimal> Distribution { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(IrrigationSystemMetadata))]
    public partial class IrrigationSystem
    {
    }

    public class IrrigationSystemMetadata
    {
        public int IrrigationSysID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Potential Areas Irrigable")]
        public Nullable<decimal> AreasIrrigable { get; set; }

        [Required]
        [Display(Name = "National Irrigation System")]
        public Nullable<decimal> NatlIrrigationSys { get; set; }

        [Required]
        [Display(Name = "NIA Assisted/Constructed")]
        public Nullable<decimal> NIAAssisted { get; set; }

        [Required]
        [Display(Name = "Other Agency")]
        public Nullable<decimal> OtherAgency { get; set; }

        [Required]
        [Display(Name = "Private Irrigation")]
        public Nullable<decimal> PrivateIrrigation { get; set; }

        [Required]
        [Display(Name = "Pump System")]
        public Nullable<decimal> PumpSystem { get; set; }

        [Required]
        [Display(Name = "Irrigation Development")]
        public Nullable<decimal> IrrigationDev { get; set; }

        [Required]
        [Display(Name = "Remaining Areas")]
        public Nullable<decimal> RemainingAreas { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(LivestockPoultryInventoryMetadata))]
    public partial class LivestockPoultryInventory
    {
    }

    public class LivestockPoultryInventoryMetadata
    {
        public int LivestockInvID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Livestock/Poultry")]
        public Nullable<int> LivestockPoultryID { get; set; }

        [Required]
        [Display(Name = "Number of Livestock")]
        public Nullable<int> NumberofLivestock { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(OtherCropsProductionMetadata))]
    public partial class OtherCropsProduction
    {
    }

    public class OtherCropsProductionMetadata
    {
        public int OtherCropsProdID { get; set; }

        [Required]
        [Display(Name = "High Value Crop")]
        public Nullable<int> HighValueCropID { get; set; }

        [Required]
        [Display(Name = "Area Hectares")]
        public Nullable<int> AreaHectares { get; set; }

        [Required]
        [Display(Name = "Production (MT)")]
        public Nullable<decimal> ProdMetricTons { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PalayProductionMetadata))]
    public partial class PalayProduction
    {
    }

    public class PalayProductionMetadata
    {
        public int PalayProdID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Method")]
        public Nullable<int> MethodID { get; set; }

        [Required]
        [Display(Name = "Area Hectares")]
        public Nullable<int> AreaHectares { get; set; }

        [Required]
        [Display(Name = "Production (MT)")]
        public Nullable<int> Production { get; set; }

        [Required]
        [Display(Name = "Production Yield")]
        public Nullable<decimal> ProdYield { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationByCitizenshipGenderMetadata))]
    public partial class PopulationByCitizenshipGender
    {
    }

    public class PopulationByCitizenshipGenderMetadata
    {
        public int PopCitizenSexID { get; set; }

        [Required]
        [Display(Name = "Citizenship")]
        public Nullable<int> CountryID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Nullable<int> GenderID { get; set; }

        [Required]
        [Display(Name = "Number of Household")]
        public Nullable<int> NumberofHousehold { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationByEthnicityMetadata))]
    public partial class PopulationByEthnicity
    {
    }

    public class PopulationByEthnicityMetadata
    {
        public int PopEthnicityID { get; set; }

        [Required]
        [Display(Name = "Ethnicity")]
        public Nullable<int> EthnicityID { get; set; }

        [Required]
        [Display(Name = "Number of Population")]
        public Nullable<int> NumberofPopulation { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationByLanguageSpokenMetadata))]
    public partial class PopulationByLanguageSpoken
    {
    }

    public class PopulationByLanguageSpokenMetadata
    {
        public int PopLanguageID { get; set; }

        [Required]
        [Display(Name = "Language")]
        public Nullable<int> LanguageID { get; set; }

        [Required]
        [Display(Name = "Number of Household")]
        public Nullable<int> NumberHousehold { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationByReligiousAffiliationMetadata))]
    public partial class PopulationByReligiousAffiliation
    {
    }

    public class PopulationByReligiousAffiliationMetadata
    {
        public int PopReligionID { get; set; }

        [Required]
        [Display(Name = "Religion")]
        public Nullable<int> ReligionID { get; set; }

        [Required]
        [Display(Name = "Number of Household")]
        public Nullable<int> NumberofHouseholds { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationDensityMetadata))]
    public partial class PopulationDensity
    {
    }

    public class PopulationDensityMetadata
    {
        public int PopDensityID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Land Area")]
        public Nullable<decimal> LandArea { get; set; }

        [Required]
        [Display(Name = "Population per Area")]
        public Nullable<int> PopulationPerArea { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationDistributionMetadata))]
    public partial class PopulationDistribution
    {
    }
    public class PopulationDistributionMetadata
    {
        public int PopDistributionID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Population")]
        public Nullable<int> Population { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationGrowthRateMetadata))]
    public partial class PopulationGrowthRate
    {
    }

    public class PopulationGrowthRateMetadata
    {
        public int PopGrowthRateID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Growth Rate")]
        public Nullable<decimal> GrowthRate { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationHighestEducationAttainedMetadata))]
    public partial class PopulationHighestEducationAttained
    {
    }

    public class PopulationHighestEducationAttainedMetadata
    {
        public int PopEducationAttainedID { get; set; }

        [Required]
        [Display(Name = "Highest Education Attained")]
        public Nullable<int> HighestEducAttainedID { get; set; }

        [Required]
        [Display(Name = "Male Population")]
        public Nullable<int> MalePopulation { get; set; }

        [Required]
        [Display(Name = "Female Population")]
        public Nullable<int> FemalePopulation { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationLiteracy10YrsAboveMetadata))]
    public partial class PopulationLiteracy10YrsAbove
    {
    }

    public class PopulationLiteracy10YrsAboveMetadata
    {
        public int PopLiteracyID { get; set; }

        [Required]
        [Display(Name = "Age Group")]
        public Nullable<int> AgeGroupID { get; set; }

        [Required]
        [Display(Name = "Literacy")]
        public Nullable<int> LiteracyID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Nullable<int> GenderID { get; set; }

        [Required]
        [Display(Name = "Number of Population")]
        public Nullable<int> NumberofPopulation { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(PopulationMigrationRateMetadata))]
    public partial class PopulationMigrationRate
    {
    }

    public class PopulationMigrationRateMetadata
    {
        public int PopMigrationID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Migrating IN")]
        public Nullable<int> MigratingIN { get; set; }

        [Required]
        [Display(Name = "Migrating IN (%)")]
        public Nullable<decimal> MigratingINPer { get; set; }

        [Required]
        [Display(Name = "Migrating OUT")]
        public Nullable<int> MigratingOUT { get; set; }

        [Required]
        [Display(Name = "Migrating OUT (%)")]
        public Nullable<decimal> MigratingOUTPer { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(ProjectProfileMetadata))]
    public partial class ProjectProfile
    {
    }

    public class ProjectProfileMetadata
    {
        public int ProjectProfileID { get; set; }

        [Required]
        [Display(Name = "Sectoral Code")]
        public Nullable<int> FunctionID { get; set; }

        [Required]
        [Display(Name = "Program Code")]
        public Nullable<int> ProgramID { get; set; }

        [Required]
        [Display(Name = "Account Code")]
        public Nullable<int> AccountCodeID { get; set; }

        [Required]
        [Display(Name = "Official Code")]
        public Nullable<int> OfficialCodeID { get; set; }

        [Required]
        [Display(Name = "Line Number")]
        public string LineNumber { get; set; }

        [Required]
        [Display(Name = "Sector")]
        public Nullable<int> SectorID { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Project Description")]
        public string ProjectDescription { get; set; }

        [Required]
        [Display(Name = "Implementing Department")]
        public Nullable<int> ImpDeptID { get; set; }

        [Required]
        [Display(Name = "Project Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> ProjStartDate { get; set; }

        [Required]
        [Display(Name = "Project End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> ProjEndDate { get; set; }

        [Required]
        [Display(Name = "Project Status")]
        public Nullable<int> ProjStatusID { get; set; }

        [Required]
        [Display(Name = "Project Expected Output")]
        public string ProjExpectedOutput { get; set; }

        [Required]
        [Display(Name = "Source Fund")]
        public Nullable<int> SourceFundID { get; set; }

        [Required]
        [Display(Name = "BDIP per Municipality")]
        public Nullable<int> BDIPID { get; set; }

        [Required]
        [Display(Name = "Project Category")]
        public Nullable<int> ProjCatID { get; set; }

        [Required]
        [Display(Name = "Reference Output")]
        public string ProjReferenceOutput { get; set; }

        [Required]
        [Display(Name = "Item of Work")]
        public string ProjItemWork { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "Barangay")]
        public Nullable<int> barangayID { get; set; }

        [Required]
        [Display(Name = "Purok")]
        public string ProjPurok { get; set; }

        [Required]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Required]
        [Display(Name = "PS")]
        public Nullable<decimal> ProjPS { get; set; }

        [Required]
        [Display(Name = "MOOE")]
        public Nullable<decimal> ProjMOOE { get; set; }

        [Required]
        [Display(Name = "Capital Outlay")]
        public Nullable<decimal> ProjCapitalOutlay { get; set; }

        [Required]
        [Display(Name = "Strategic Priority")]
        public Nullable<int> StrategicPriorityID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Area")]
        public Nullable<int> StrategicPriorityAreaID { get; set; }

        [Required]
        [Display(Name = "Climate Change Mitigation")]
        public Nullable<int> MitigationTypologyID { get; set; }

        [Required]
        [Display(Name = "Climate Change Adaptation")]
        public Nullable<int> AdaptationTypologyID { get; set; }
    }

    [MetadataType(typeof(ref_AccountCodeMetadata))]
    public partial class ref_AccountCode
    {
    }
    public class ref_AccountCodeMetadata
    {
        public int AccountCodeID { get; set; }

        [Required]
        [Display(Name = "Sectoral Code")]
        public Nullable<int> FunctionID { get; set; }

        [Required]
        [Display(Name = "Program Code")]
        public Nullable<int> ProgramID { get; set; }

        [Required]
        [Display(Name = "Account Code")]
        public Nullable<int> AccountCode { get; set; }

        [Required]
        [Display(Name = "Account Description")]
        public string AccountDescription { get; set; }
    }

    [MetadataType(typeof(ref_AgeGroupMetadata))]
    public partial class ref_AgeGroup
    {
    }

    public class ref_AgeGroupMetadata
    {
        public int AgeGroupID { get; set; }

        [Required]
        [Display(Name = "Age Group")]
        public string AgeGroup { get; set; }
    }

    [MetadataType(typeof(ref_BDIPperMunicipalityMetadata))]
    public partial class ref_BDIPperMunicipality
    {
    }

    public class ref_BDIPperMunicipalityMetadata
    {
        public int BDIPID { get; set; }

        [Required]
        [Display(Name = "Municipality")]
        public Nullable<int> MunicipalityID { get; set; }

        [Required]
        [Display(Name = "BDIP per Municipality Code")]
        public string BDIPMunicipalityCode { get; set; }

        [Required]
        [Display(Name = "BDIP per Municipality")]
        public string BDIPMunicipality { get; set; }
    }

    [MetadataType(typeof(ref_ClimateChangeTypologyMetadata))]
    public partial class ref_ClimateChangeTypology
    {
    }

    public class ref_ClimateChangeTypologyMetadata
    {
        public int TypologyID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority")]
        public Nullable<int> StrategicPriorityID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Area")]
        public Nullable<int> StrategicPriorityAreaID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Class")]
        public Nullable<int> StratPriorityClassID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Group")]
        public Nullable<int> StrategicPriorityGrpID { get; set; }

        [Required]
        [Display(Name = "Typology Code")]
        public string TypologyCode { get; set; }

        [Required]
        [Display(Name = "Typology Description")]
        public string TypologyDescription { get; set; }
    }

    [MetadataType(typeof(ref_CoffeeTypeMetadata))]
    public partial class ref_CoffeeType
    {
    }

    public class ref_CoffeeTypeMetadata
    {
        public int CoffeeID { get; set; }

        [Required]
        [Display(Name = "Coffee")]
        public string Coffee { get; set; }
    }

    [MetadataType(typeof(ref_CornTypeMetadata))]
    public partial class ref_CornType
    {
    }

    public class ref_CornTypeMetadata
    {
        public int CornID { get; set; }

        [Required]
        [Display(Name = "Corn")]
        public string Corn { get; set; }
    }

    [MetadataType(typeof(ref_CropCommodityMetadata))]
    public partial class ref_CropCommodity
    {
    }

    public class ref_CropCommodityMetadata
    {
        public int CropCommodityID { get; set; }

        [Required]
        [Display(Name = "Crop Commodity")]
        public string CropCommodity { get; set; }
    }

    [MetadataType(typeof(ref_EthnicityMetadata))]
    public partial class ref_Ethnicity
    {
    }

    public class ref_EthnicityMetadata
    {
        public int EthnicityID { get; set; }

        [Required]
        [Display(Name = "Ethnicity")]
        public string EthnicityDesc { get; set; }
    }

    [MetadataType(typeof(ref_GenderMetadata))]
    public partial class ref_Gender
    {
    }

    public class ref_GenderMetadata
    {
        public int genderID { get; set; }

        [Required]
        [Display(Name = "Gender Code")]
        public string genderCode { get; set; }

        [Required]
        [Display(Name = "Gender Description")]
        public string genderDescription { get; set; }
    }

    [MetadataType(typeof(ref_HighestEducationAttainedMetadata))]
    public partial class ref_HighestEducationAttained
    {
    }

    public class ref_HighestEducationAttainedMetadata
    {
        public int HighestEducAttainedID { get; set; }

        [Required]
        [Display(Name = "Highest Education Attained")]
        public string HighestEducAttainedDesc { get; set; }
    }

    [MetadataType(typeof(ref_HighValueCropMetadata))]
    public partial class ref_HighValueCrop
    {
    }

    public class ref_HighValueCropMetadata
    {
        public int HighValueCropID { get; set; }

        [Required]
        [Display(Name = "High Value Crop")]
        public string HighValueCrop { get; set; }

        [Required]
        [Display(Name = "Commodity")]
        public Nullable<int> CropCommodityID { get; set; }
    }

    [MetadataType(typeof(ref_ImplementingDepartmentMetadata))]
    public partial class ref_ImplementingDepartment
    {
    }

    public class ref_ImplementingDepartmentMetadata
    {
        public int ImpDeptID { get; set; }

        [Required]
        [Display(Name = "Implementing Department Code")]
        public string ImpDeptCode { get; set; }

        [Required]
        [Display(Name = "Implementing Department")]
        public string ImpDeptDescription { get; set; }
    }

    [MetadataType(typeof(ref_IndustryClassificationMetadata))]
    public partial class ref_IndustryClassification
    {
    }

    public class ref_IndustryClassificationMetadata
    {
        public int IndustryClassID { get; set; }

        [Required]
        [Display(Name = "Industry Classification")]
        public string IndustryClassification { get; set; }
    }

    [MetadataType(typeof(ref_LandCoverClassificationMetadata))]
    public partial class ref_LandCoverClassification
    {
    }

    public class ref_LandCoverClassificationMetadata
    {
        public int LandCoverClassID { get; set; }

        [Required]
        [Display(Name = "Land Cover Classification")]
        public string LandCoverClassificationDescription { get; set; }
    }

    [MetadataType(typeof(ref_LanguageSpokenMetadata))]
    public partial class ref_LanguageSpoken
    { 
    }

    public class ref_LanguageSpokenMetadata
    {
        public int LanguageID { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string Language { get; set; }
    }

    [MetadataType(typeof(ref_LiteracyMetadata))]
    public partial class ref_Literacy
    {
    }

    public class ref_LiteracyMetadata
    {
        public int LiteracyID { get; set; }

        [Required]
        [Display(Name = "Literacy")]
        public string LiteracyValue { get; set; }
    }

    [MetadataType(typeof(ref_LivestockPoultryMetadata))]
    public partial class ref_LivestockPoultry
    {
    }

    public class ref_LivestockPoultryMetadata
    {
        public int LivestockPoultryID { get; set; }

        [Required]
        [Display(Name = "Livestock/Poultry")]
        public string LivestockPoultry { get; set; }
    }

    [MetadataType(typeof(ref_MajorBusinessIndustryGroupMetadata))]
    public partial class ref_MajorBusinessIndustryGroup
    {
    }

    public class ref_MajorBusinessIndustryGroupMetadata
    {
        public int MajorBusinessIndustryID { get; set; }

        [Required]
        [Display(Name = "Major Business/Industry")]
        public string MajorBusinessIndustryDesc { get; set; }
    }

    [MetadataType(typeof(ref_MajorOccupationGroupMetadata))]
    public partial class ref_MajorOccupationGroup
    {
    }

    public class ref_MajorOccupationGroupMetadata
    {
        public int MajorOccupationID { get; set; }

        [Required]
        [Display(Name = "Major Occupation")]
        public string MajorOccupationDesc { get; set; }
    }

    [MetadataType(typeof(ref_MethodMetadata))]
    public partial class ref_Method
    {
    }

    public class ref_MethodMetadata
    {
        public int MethodID { get; set; }

        [Required]
        [Display(Name = "Method")]
        public string Method { get; set; }
    }

    [MetadataType(typeof(ref_OfficialCodeMetadata))]
    public partial class ref_OfficialCode
    {
    }

    public class ref_OfficialCodeMetadata
    {
        public int OfficialCodeID { get; set; }

        [Required]
        [Display(Name = "Official Code")]
        public Nullable<int> OfficialCode { get; set; }

        [Required]
        [Display(Name = "Official")]
        public string OfficialCodeDescription { get; set; }
    }

    [MetadataType(typeof(ref_OriginsMetadata))]
    public partial class ref_Origins
    {
    }

    public class ref_OriginsMetadata
    {
        public int countryID { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
    }

    [MetadataType(typeof(ref_ProjectCategoryMetadata))]
    public partial class ref_ProjectCategory
    {
    }

    public class ref_ProjectCategoryMetadata
    {
        public int ProjCatID { get; set; }

        [Required]
        [Display(Name = "Project Category Code")]
        public string ProjCategoryCode { get; set; }

        [Required]
        [Display(Name = "Project Category Description")]
        public string ProjCategoryDescription { get; set; }
    }

    [MetadataType(typeof(ref_ProjectStatusMetadata))]
    public partial class ref_ProjectStatus
    {
    }

    public class ref_ProjectStatusMetadata
    {
        public int ProjStatusID { get; set; }

        [Required]
        [Display(Name = "Project Status Code")]
        public string ProjStatusCode { get; set; }

        [Required]
        [Display(Name = "Project Status Description")]
        public string ProjStatusDescription { get; set; }
    }

    [MetadataType(typeof(ref_ReligionMetadata))]
    public partial class ref_Religion
    {
    }

    public class ref_ReligionMetadata
    {
        public int religionID { get; set; }

        [Required]
        [Display(Name = "Religion")]
        public string religionDescription { get; set; }
    }

    [MetadataType(typeof(ref_SectorMetadata))]
    public partial class ref_Sector
    {
    }

    public class ref_SectorMetadata
    {
        public int SectorID { get; set; }

        [Required]
        [Display(Name = "Sector Code")]
        public string SectorCode { get; set; }

        [Required]
        [Display(Name = "Sector")]
        public string SectorDescription { get; set; }
    }

    [MetadataType(typeof(ref_SourceOfFundMetadata))]
    public partial class ref_SourceOfFund
    {
    }

    public class ref_SourceOfFundMetadata
    {
        public int SourceFundID { get; set; }

        [Required]
        [Display(Name = "Source of Fund Code")]
        public string SourceFundCode { get; set; }

        [Required]
        [Display(Name = "Source of Fund")]
        public string SourceFundDescription { get; set; }
    }

    [MetadataType(typeof(ref_StrategicPriorityMetadata))]
    public partial class ref_StrategicPriority
    {
    }

    public class ref_StrategicPriorityMetadata
    {
        public int StrategicPriorityID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Number")]
        public Nullable<int> StrategicPriorityNo { get; set; }

        [Required]
        [Display(Name = "Strategic Priority")]
        public string StrategicPriorityDescription { get; set; }
    }

    [MetadataType(typeof(ref_StrategicPriorityAreaMetadata))]
    public partial class ref_StrategicPriorityArea
    {
    }

    public class ref_StrategicPriorityAreaMetadata
    {
        public int StrategicPriorityAreaID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority")]
        public Nullable<int> StrategicPriorityID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Area Number")]
        public Nullable<int> StrategicPriorityAreaNo { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Area")]
        public string StrategicPriorityAreaDescription { get; set; }
    }

    [MetadataType(typeof(ref_StrategicPriorityClassificationMetadata))]
    public partial class ref_StrategicPriorityClassification
    {
    }

    public class ref_StrategicPriorityClassificationMetadata
    {
        public int StratPriorityClassID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Classification")]
        public string StrategicPriorityClassification { get; set; }
    }

    [MetadataType(typeof(ref_StrategicPriorityGroupMetadata))]
    public partial class ref_StrategicPriorityGroup
    {
    }

    public class ref_StrategicPriorityGroupMetadata
    {
        public int StrategicPriorityGrpID { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Group Code")]
        public string StrategicPriorityGrpCode { get; set; }

        [Required]
        [Display(Name = "Strategic Priority Group")]
        public string StrategicPriorityGrpDescription { get; set; }
    }

    [MetadataType(typeof(rep_HouseholdHighestEducationAttainedMetadata))]
    public partial class rep_HouseholdHighestEducationAttained
    {
    }

    public class rep_HouseholdHighestEducationAttainedMetadata
    {
        public int PopEducationAttainedID { get; set; }

        [Required]
        [Display(Name = "Highest Education Attained")]
        public string HighestEducAttainedDesc { get; set; }

        [Required]
        [Display(Name = "Total Per Education Attaineed")]
        public Nullable<int> TotalPerEducAttaineed { get; set; }

        [Required]
        [Display(Name = "Overall Total")]
        public Nullable<int> OverAllTotal { get; set; }

        [Required]
        [Display(Name = "Male Population")]
        public Nullable<int> MalePopulation { get; set; }

        [Required]
        [Display(Name = "Female Population")]
        public Nullable<int> FemalePopulation { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }

        [Required]
        [Display(Name = "Highest Education Attained")]
        public Nullable<int> HighestEducAttainedID { get; set; }
    }

    [MetadataType(typeof(WorkerByClassMetadata))]
    public partial class WorkersByClass
    {
    }

    public partial class WorkerByClassMetadata
    {
        public int WorkersByClassID { get; set; }

        [Required]
        [Display(Name = "Class of Worker")]
        public Nullable<int> ClassWorkerID { get; set; }

        [Required]
        [Display(Name = "Age Group")]
        public Nullable<int> AgeGroupID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Nullable<int> GenderID { get; set; }

        [Required]
        [Display(Name = "Number of Population")]
        public Nullable<int> NumberofPopulation { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(WorkersByMajorIndustryMetadata))]
    public partial class WorkersByMajorIndustry
    {
    }

    public class WorkersByMajorIndustryMetadata
    {
        public int WorkersMajorIndustryID { get; set; }

        [Required]
        [Display(Name = "Major Business Industry")]
        public Nullable<int> MajorBusinessIndustryID { get; set; }

        [Required]
        [Display(Name = "Age Group")]
        public Nullable<int> AgeGroupID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Nullable<int> GenderID { get; set; }

        [Required]
        [Display(Name = "Number of Population")]
        public Nullable<int> NumberofPopulation { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }

    [MetadataType(typeof(WorkersByMajorOCcupationMetadata))]
    public partial class WorkersByMajorOCcupation
    {
    }

    public class WorkersByMajorOCcupationMetadata
    {
        public int WorkersMajorOccupationID { get; set; }

        [Required]
        [Display(Name = "Major Occupation")]
        public Nullable<int> MajorOccupationID { get; set; }

        [Required]
        [Display(Name = "Age Group")]
        public Nullable<int> AgeGroupID { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Nullable<int> GenderID { get; set; }

        [Required]
        [Display(Name = "Number of Population")]
        public Nullable<int> NumberofPopulation { get; set; }

        [Required]
        [Display(Name = "Year Taken")]
        public string YearTaken { get; set; }
    }
}