using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using KalingaCMSFinal.Models;
using System.Web;

namespace KalingaCMSFinal.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private appUser AppUser;

        public CustomPrincipal(appUser appuser)
        {
            this.AppUser = appuser;
            this.Identity = new GenericIdentity(AppUser.username);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}