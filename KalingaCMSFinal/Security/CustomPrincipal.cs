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
        private appUserDTO AppUser;

        public CustomPrincipal(appUserDTO appuser)
        {
            this.AppUser = appuser;
            this.Identity = new GenericIdentity(appuser.username);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any( r => this.AppUser.roles.Contains(r));
        }
    }
}