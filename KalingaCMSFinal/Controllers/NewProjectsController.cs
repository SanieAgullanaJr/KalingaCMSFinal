using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Controllers
{
    [Authorize]
    public class NewProjectsController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: NewProjects
        public ActionResult Index()
        {
            return View(db.ProjectProfiles.ToList());
        }

        // GET: NewProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectProfile projectProfile = db.ProjectProfiles.Find(id);
            if (projectProfile == null)
            {
                return HttpNotFound();
            }
            return View(projectProfile);
        }

        //Sectoral Code Dropdown
        public ActionResult SectoralCodeDD()
        {
            List<DropDown_SectoralCode> SectoralCodes = db.DropDown_SectoralCode.ToList();
            ViewBag.SectoralCodes = new SelectList(SectoralCodes, "FunctionId", "SectoralCode");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult ProgramCodeDD()
        {
            List<DropDown_ProgramCode> ProgramCodes = db.DropDown_ProgramCode.ToList();
            ViewBag.ProgramCodes = new SelectList(ProgramCodes, "ProgramId", "ProgramCode");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult AccountCodeDD()
        {
            List<DropDown_AcountCode> AccountCodes = db.DropDown_AcountCode.ToList();
            ViewBag.AccountCodes = new SelectList(AccountCodes, "AccountCodeId", "AccountCode");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult OfficialCodeDD()
        {
            List<DropDown_OfficialCode> OfficialCodes = db.DropDown_OfficialCode.ToList();
            ViewBag.OfficialCodes = new SelectList(OfficialCodes, "OfficialCodeId", "OfficialCode");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult SectorDD()
        {
            List<ref_Sector> Sectors = db.ref_Sector.ToList();
            ViewBag.Sectors = new SelectList(Sectors, "SectorId", "SectorDescription");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult ImplementingDepartmentDD()
        {
            List<ref_ImplementingDepartment> ImplementingDepartments = db.ref_ImplementingDepartment.ToList();
            ViewBag.ImplementingDepartments = new SelectList(ImplementingDepartments, "ImpDeptID", "ImpDeptDescription");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult ProjectStatusDD()
        {
            List<ref_ProjectStatus> ProjectStatuses = db.ref_ProjectStatus.ToList();
            ViewBag.ProjectStatuses = new SelectList(ProjectStatuses, "ProjStatusID", "ProjStatusDescription");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult SourceOfFundDD()
        {
            List<ref_SourceOfFund> SourceOfFunds = db.ref_SourceOfFund.ToList();
            ViewBag.SourceOfFunds = new SelectList(SourceOfFunds, "SourceFundID", "SourceFundDescription");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult BDIPperMunicipalityDD()
        {
            List<ref_BDIPperMunicipality> BDIPs = db.ref_BDIPperMunicipality.ToList();
            ViewBag.BDIPs = new SelectList(BDIPs, "BDIPID", "BDIPMunicipality");
            return View();
        }

        //Sectoral Code Dropdown
        public ActionResult ProjectCategoryDD()
        {
            List<ref_ProjectCategory> ProjectCategories = db.ref_ProjectCategory.ToList();
            ViewBag.ProjectCategories = new SelectList(ProjectCategories, "ProjCatID", "ProjCategoryDescription");
            return View();
        }

        //Municipality Dropdown
        public ActionResult MunicipalityDD()
        {
            List<DropDown_Municipality> Municipalities = db.DropDown_Municipality.ToList();
            ViewBag.Municipalities = new SelectList(Municipalities, "MunicipalityID", "Municipality");
            return View();
        }

        public ActionResult TypologyCodeDD()
        {
            List<DropDown_TypologyCode> TypologyCodes = db.DropDown_TypologyCode.ToList();
            ViewBag.TypologyCodes = new SelectList(TypologyCodes, "StrategicPriorityID", "Typology");
            return View();
        }

        public ActionResult PriorityAreaDD()
        {
            List<Dropdown_PriorityArea> PriorityAreas = db.Dropdown_PriorityArea.ToList();
            ViewBag.PriorityAreas = new SelectList(PriorityAreas, "StrategicPriorityAreaID", "StrategicPriorityArea");
            return View();
        }

        public ActionResult ClimateChangeMitigationDD()
        {
            List<DropDown_ClimateChangeMitigation> Mitigations = db.DropDown_ClimateChangeMitigation.ToList();
            ViewBag.Mitigations = new SelectList(Mitigations, "TypologyID", "Mitigation");
            return View();
        }

        public ActionResult ClimateChangeAdaptationDD()
        {
            List<DropDown_ClimateChangeAdaptation> Adaptations = db.DropDown_ClimateChangeAdaptation.ToList();
            ViewBag.Adaptations = new SelectList(Adaptations, "TypologyID", "Adaptation");
            return View();
        }

        // GET: NewProjects/Create
        public ActionResult Create()
        {
            SectoralCodeDD();
            OfficialCodeDD();
            ClimateChangeAdaptationDD();
            ClimateChangeMitigationDD();
            AccountCodeDD();
            BDIPperMunicipalityDD();
            ImplementingDepartmentDD();
            MunicipalityDD();
            PriorityAreaDD();
            ProgramCodeDD();
            ProjectCategoryDD();
            ProjectStatusDD();
            SectorDD();
            SourceOfFundDD();
            TypologyCodeDD();
            return View(Tuple.Create<ProjectProfile, IEnumerable<vw_ProjectProfile>>(new ProjectProfile(), db.vw_ProjectProfile.ToList()));
        }

        public JsonResult GetBarangayList(int MunicipalityID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<DropDown_Barangay> Barangays = db.DropDown_Barangay.Where(x=>x.MunicipalityID == MunicipalityID).ToList();
            return Json(Barangays, JsonRequestBehavior.AllowGet);
        }

        // POST: NewProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix = "Item1", Include = "ProjectProfileID,FunctionID,ProgramID,AccountCodeID,OfficialCodeID,LineNumber,SectorID,ProjectTitle,ProjectDescription,ImpDeptID,ProjStartDate,ProjEndDate,ProjStatusID,ProjExpectedOutput,SourceFundID,BDIPID,ProjCatID,ProjReferenceOutput,ProjItemWork,MunicipalityID,barangayID,ProjPurok,Remarks,ProjPS,ProjMOOE,ProjCapitalOutlay,StrategicPriorityID,StrategicPriorityAreaID,MitigationTypologyID,AdaptationTypologyID")] ProjectProfile ProjectProfile)
        {
            if (ModelState.IsValid)
            {
                db.ProjectProfiles.Add(ProjectProfile);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(ProjectProfile);
        }

        // GET: NewProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            SectoralCodeDD();
            OfficialCodeDD();
            ClimateChangeAdaptationDD();
            ClimateChangeMitigationDD();
            AccountCodeDD();
            BDIPperMunicipalityDD();
            ImplementingDepartmentDD();
            MunicipalityDD();
            PriorityAreaDD();
            ProgramCodeDD();
            ProjectCategoryDD();
            ProjectStatusDD();
            SectorDD();
            SourceOfFundDD();
            TypologyCodeDD();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectProfile projectProfile = db.ProjectProfiles.Find(id);
            if (projectProfile == null)
            {
                return HttpNotFound();
            }
            return View(projectProfile);
        }

        // POST: NewProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectProfileID,FunctionID,ProgramID,AccountCodeID,OfficialCodeID,LineNumber,SectorID,ProjectTitle,ProjectDescription,ImpDeptID,ProjStartDate,ProjEndDate,ProjStatusID,ProjExpectedOutput,SourceFundID,BDIPID,ProjCatID,ProjReferenceOutput,ProjItemWork,MunicipalityID,barangayID,ProjPurok,Remarks,ProjPS,ProjMOOE,ProjCapitalOutlay,StrategicPriorityID,StrategicPriorityAreaID,MitigationTypologyID,AdaptationTypologyID")] ProjectProfile projectProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(projectProfile);
        }

        // GET: NewProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectProfile projectProfile = db.ProjectProfiles.Find(id);
            if (projectProfile == null)
            {
                return HttpNotFound();
            }
            return View(projectProfile);
        }

        // POST: NewProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectProfile projectProfile = db.ProjectProfiles.Find(id);
            db.ProjectProfiles.Remove(projectProfile);
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
