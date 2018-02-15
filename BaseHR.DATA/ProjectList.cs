//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseHR.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectList
    {
        public decimal ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public decimal WeekEndID { get; set; }
        public string IncrementType { get; set; }
        public decimal IncrementMonth { get; set; }
        public decimal IncrementAfter { get; set; }
        public string IsPF { get; set; }
        public string IsGratuity { get; set; }
        public string IsEOC { get; set; }
        public string IsLE { get; set; }
        public string IsInsurance { get; set; }
        public string IsGSal { get; set; }
        public string IsBSal { get; set; }
        public string IsCore { get; set; }
        public string IsProject { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<System.DateTime> InsertedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string LastUpdatedFrom { get; set; }
        public string ShortName { get; set; }
    }
}