//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KalingaCMSFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class appModule
    {
        public int appmoduleid { get; set; }
        public string moduleName { get; set; }
        public Nullable<int> parentModuleID { get; set; }
        public Nullable<int> moduleLevel { get; set; }
        public Nullable<int> moduleGroup { get; set; }
        public Nullable<bool> IsMain { get; set; }
        public string moduleURL { get; set; }
    }
}
