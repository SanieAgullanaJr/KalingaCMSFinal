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
    
    public partial class vw_ExamTaken
    {
        public int empCertID { get; set; }
        public Nullable<int> empID { get; set; }
        public string ExamName { get; set; }
        public string Rating { get; set; }
        public Nullable<System.DateTime> ExamDate { get; set; }
        public string ExamVenue { get; set; }
        public string LicenseNumber { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
    }
}
