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
    
    public partial class LeavePlan
    {
        public decimal ID { get; set; }
        public Nullable<decimal> LTypeId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Remarks { get; set; }
        public string IsActive { get; set; }
        public string EmpId { get; set; }
    }
}
