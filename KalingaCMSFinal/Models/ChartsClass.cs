using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KalingaCMSFinal.Models
{
    public class trafficSourceData
    {
        public string label { get; set; }
        public string data { get; set; }
        public string data2 { get; set; }
        public string data3 { get; set; }
        public string data4 { get; set; }
        public string data5 { get; set; }
        public string data6 { get; set; }
        public string data7 { get; set; }
        public string data8 { get; set; }
        public string backgroundColor { get; set; }
        public string hightlight { get; set; }
    }

    public class PopulationChartsModels
    {
        public rep_PopulationDistributionByYearByMunicipality PopulationDistribution { get; set; }
        public vw_GrowthRateByMunicipalityByYear GrowthRate { get; set; }
        public vw_PopulationDensityByMunicipalityByYear PopulationDensity { get; set; }
        public vw_HouseholdMigrationByYear HouseholdMigration { get; set; }
        public vw_ReligiousAffiliation ReligiousAffiliation { get; set; }
        public vw_HouseholdPopulationByCitizenshipAndSex Citizenship { get; set; }
    }

    public class AgricultureChartsModels
    {
        public vw_PalayProductionIrrigatedRainfedUpland PalayProduction { get; set; }
        public vw_CornAreaProductionYield CornProduction { get; set; }
        public vw_OtherHighValueCropsAreaAndProduction OtherCropsProduction { get; set; }
        public vw_LivestockAndPoultryInventoryByMunicipalityByYear LivestockPoultry { get; set; }
        public vw_ForestCoverByVegetationByYear Vegetation { get; set; }

    }

    public class appUserDTO
    {
        public string username { get; set; }
        public string roles { get; set; }
    }

    public class AccountModel
    {
        

        public List<appUserDTO> Role()
        {
            kalingaPPDOEntities db = new kalingaPPDOEntities();
            var appUsername = (from data in db.appUsers
                               select new appUserDTO
                               {
                                   username = data.username,
                                   roles = data.roles
                                });
            return appUsername.ToList();
        }

        public appUserDTO find(string username)
        {
            List<appUserDTO> Roles = Role();
            return Roles.Where(acc => acc.username.Equals(username)).FirstOrDefault();
        }
    }
}