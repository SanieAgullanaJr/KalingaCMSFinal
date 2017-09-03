using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Models;
using System.Security.Cryptography;
using KalingaCMSFinal.Security;

namespace KalingaCMSFinal.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,SystemAdmin")]
    public class AppUsersController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: AppUsers
        public ActionResult Index()
        {
            return View(db.appUsers.ToList());
        }

        // GET: AppUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appUser appUser = db.appUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }


        // GET: AppUsers/Create
        public ActionResult Create()
        {
            UserDD();
            return View(Tuple.Create<appUser, IEnumerable<vw_appUsers>>(new appUser(), db.vw_appUsers.ToList()));
        }

        //User Dropdown
        public ActionResult UserDD()
        {
            List<DropDown_AppUsers> AppUsers = db.DropDown_AppUsers.ToList();
            ViewBag.AppUsers = new SelectList(AppUsers, "empid", "fullname");
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix= "Item1", Include = "appuserid,empid,username,password,roles")] appUser appUser)
        {
            ModelState.Clear();
            UserDD();
            var check = appUser.empid;
            var HasAccount = db.appUsers.Where(user => user.empid == check).Select(user => user.empid).FirstOrDefault().ToString();
            var check2 = appUser.username;
            var IsExisting = db.appUsers.FirstOrDefault(user => user.username == check2);

            if (HasAccount == "")
            {
                if (IsExisting == null)
                {
                    if (ModelState.IsValid)
                    {
                        db.appUsers.Add(appUser);
                        db.SaveChanges();
                        return RedirectToAction("Create");
                    }
                }
                else if (IsExisting != null)
                {
                    ModelState.AddModelError("", "User name is already taken.");
                }
            }
            else if (HasAccount != "")
            {
                ModelState.AddModelError("", "Employee already has an account.");
            }

            return View(appUser);
        }

        // GET: AppUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            UserDD();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appUser appUser = db.appUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "appuserid,empid,username,password,roles")] appUser appUser)
        {
            ModelState.Clear();
            UserDD();
            if (ModelState.IsValid)
            {
                db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(appUser);
        }

        // GET: AppUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appUser appUser = db.appUsers.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appUser appUser = db.appUsers.Find(id);
            db.appUsers.Remove(appUser);
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
