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
    
    public partial class Emp_LeaveApplication
    {
        public int LeaveApplicationID { get; set; }
        public int empID { get; set; }
        public int LeaveTypeID { get; set; }
        public byte[] DateFiled { get; set; }
        public Nullable<System.DateTime> Startdate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> AppliedHrs { get; set; }
        public Nullable<bool> IsWithPay { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<bool> IsCancelled { get; set; }
        public string LeaveReason { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public Nullable<System.DateTime> DateApproved { get; set; }
        public Nullable<System.DateTime> DateCancelled { get; set; }
        public Nullable<int> HRApproved { get; set; }
        public Nullable<System.DateTime> HRDateApproved { get; set; }
        public Nullable<int> HRDisApproved { get; set; }
    }
}
