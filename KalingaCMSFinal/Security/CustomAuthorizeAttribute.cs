using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private kalingaPPDOEntities db = new kalingaPPDOEntities();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(RemainSession.Username))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new { Controller = "Access", action = "Login" }));
            else
            {
                AccountModel am = new AccountModel();
                CustomPrincipal mp = new CustomPrincipal(am.find(RemainSession.Username));
                if (!mp.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                        (new { Controller = "Error", action = "Forbidden" }));
            }
        }
    }
}