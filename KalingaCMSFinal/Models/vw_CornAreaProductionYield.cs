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
    
    public partial class vw_CornAreaProductionYield
    {
        public int CornProdID { get; set; }
        public string Municipality { get; set; }
        public string Corn { get; set; }
        public Nullable<int> AreaHectares { get; set; }
        public Nullable<int> Production { get; set; }
        public Nullable<decimal> ProdYield { get; set; }
        public string YearTaken { get; set; }
    }
}