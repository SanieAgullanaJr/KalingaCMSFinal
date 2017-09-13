using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KalingaCMSFinal.Security
{
    public static class RemainSession
    {
        static string usernameSessionVar = "Username";
        static string firstnameSessionVar = "Firstname";
        static string lastnameSessionVar = "Lastname";
        static string employeeIDSessionVar = "EmployeeID";
        static string rolesSessionVar = "Roles";
        static string pathSessionVar = "ImagePath";

        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[usernameSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernameSessionVar] = value;
            }
        }

        public static string Firstname
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[firstnameSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[firstnameSessionVar] = value;
            }
        }

        public static string Lastname
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[lastnameSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[lastnameSessionVar] = value;
            }
        }

        public static string EmployeeID
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[employeeIDSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[employeeIDSessionVar] = value;
            }
        }

        public static string Roles
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[rolesSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[rolesSessionVar] = value;
            }
        }

        public static string ImagePath
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[pathSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[pathSessionVar] = value;
            }
        }
    }
}