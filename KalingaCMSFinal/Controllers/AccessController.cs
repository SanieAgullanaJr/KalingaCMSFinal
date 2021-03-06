﻿using KalingaCMSFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalingaCMSFinal.Security;
using System.Security.Cryptography;

namespace KalingaCMSFinal.Views.Login
{
    [AllowAnonymous]
    public class AccessController : Controller
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();

        // GET: Login
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(appUser appUser)
        {
            using (kalingaPPDOEntities db = new kalingaPPDOEntities())
            {
                try
                {
                    var UserCredentials = db.appUsers.Single(u => u.username == appUser.username);
                    var Name = db.EmpMasterProfiles.Single(n => n.empid == UserCredentials.empid);
                    if (UserCredentials != null && appUser.password == UserCredentials.password)
                    {
                        RemainSession.Username = UserCredentials.username;
                        RemainSession.Firstname = Name.FirstName;
                        RemainSession.Lastname = Name.LastName;
                        RemainSession.EmployeeID = UserCredentials.empid.ToString();
                        RemainSession.Roles = UserCredentials.roles;
                        RemainSession.ImagePath = Name.DisplayPicturePath;
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is wrong");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Access");
        }
    }
}