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
    
    public partial class vw_TrainingsAttended
    {
        public int empTrainID { get; set; }
        public Nullable<int> empID { get; set; }
        public string TrainingTitle { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string DurationHours { get; set; }
        public string EventSponsor { get; set; }
        public string EventVenue { get; set; }
    }
}
