using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalingaCMSFinal.Models;

namespace KalingaCMSFinal.Models
{
    public class SummaryReportSelector
    {
        public string empID { get; set; }
        public string empAttendanceMainID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string CutoffDate { get; set; }
    }

    public class SummaryReport
    {
        public string empAttendanceMainID { get; set; }
        public string Name { get; set; }
        public string LeaveType { get; set; }
        public string DateFiled { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AppliedHours { get; set; }
        public string Status { get; set; }
        public string Approver { get; set; }    
        public string DateofAction { get; set; }
        public string Reason { get; set; }
    }
}