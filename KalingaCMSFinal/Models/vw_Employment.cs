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
    
    public partial class vw_Employment
    {
        public int empRecID { get; set; }
        public Nullable<int> empID { get; set; }
        public string FullName { get; set; }
        public Nullable<System.DateTime> DateHired { get; set; }
        public Nullable<System.DateTime> DateResigned { get; set; }
        public string PositionDescription { get; set; }
        public Nullable<decimal> MonthlySalary { get; set; }
        public string SalaryGradeCode { get; set; }
        public string StepIncrement { get; set; }
        public string EmpStatusDescription { get; set; }
        public int FirstApprover { get; set; }
        public int SecondApprover { get; set; }
        public Nullable<bool> IsSupervisor { get; set; }
    }
}
