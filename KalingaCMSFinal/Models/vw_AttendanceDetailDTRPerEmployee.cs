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
    
    public partial class vw_AttendanceDetailDTRPerEmployee
    {
        public int LogNumber { get; set; }
        public Nullable<int> empAttendanceMainID { get; set; }
        public Nullable<int> empID { get; set; }
        public Nullable<System.DateTime> DTRDate { get; set; }
        public string DayName { get; set; }
        public string LOGIN { get; set; }
        public string LOGOUT { get; set; }
    }
}
