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
    
    public partial class Emp_LeaveCredit
    {
        public int EmpLeaveCreditID { get; set; }
        public Nullable<int> empID { get; set; }
        public Nullable<int> LeaveTypeID { get; set; }
        public Nullable<System.DateTime> AcquiredDate { get; set; }
        public Nullable<decimal> LeaveHrs { get; set; }
        public string Remark { get; set; }
        public string UpdatedBy { get; set; }
    }
}
