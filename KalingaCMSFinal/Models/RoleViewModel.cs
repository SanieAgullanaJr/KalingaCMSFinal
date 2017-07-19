using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KalingaCMSFinal.Models
{

    public class RoleViewModel
    {
        public appUser appUser { get; set; }
        public List<appRoleDTO> appRole { get; set; }
    }

    public class appRoleDTO
    {
        public string RoleName { get; set; }
        public bool IsInRole { get; set; }
    }

}