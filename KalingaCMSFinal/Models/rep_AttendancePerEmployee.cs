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
    
    public partial class rep_AttendancePerEmployee
    {
        public Nullable<int> empAttendanceMainID { get; set; }
        public string NameDay { get; set; }
        public Nullable<int> empID { get; set; }
        public string In1 { get; set; }
        public string Out1 { get; set; }
        public string LateHrs { get; set; }
        public string UnderTimeHours { get; set; }
        public string AbsHrs { get; set; }
        public Nullable<decimal> LeaveHrs { get; set; }
        public string HrsWorked { get; set; }
        public string LeaveTypeCode { get; set; }
        public int AttendanceDetailDTRId { get; set; }
    }
}