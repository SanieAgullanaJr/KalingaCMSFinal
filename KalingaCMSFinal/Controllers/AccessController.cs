using KalingaCMSFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KalingaCMSFinal.Views.Login
{
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
                    var UserCredentials = db.appUsers.Single(u => u.username == appUser.username && u.password == appUser.password);
                    var Name = db.EmpMasterProfiles.Single(n => n.empid == UserCredentials.empid);
                    if (UserCredentials != null)
                    {
                        Session["First"] = Name.FirstName.ToString();
                        Session["Last"] = Name.LastName.ToString();
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
            return RedirectToAction("Login","Access");
        }
    }
}