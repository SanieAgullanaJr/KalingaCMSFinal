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
    
    public partial class Emp_DTRCapture
    {
        public int empDTRCaptureID { get; set; }
        public Nullable<int> empID { get; set; }
        public string empNo { get; set; }
        public string LogType { get; set; }
        public Nullable<System.DateTime> DTRDate { get; set; }
        public string DTRTime { get; set; }
        public byte[] DTRTimeStamp { get; set; }
    }
}
