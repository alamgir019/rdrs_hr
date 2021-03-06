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
    
    public partial class LeaveTypeList
    {
        public LeaveTypeList()
        {
            this.EmpLeaveCTOEntitleLogs = new HashSet<EmpLeaveCTOEntitleLog>();
            this.EmpLeaveProfiles = new HashSet<EmpLeaveProfile>();
        }
    
        public decimal LTypeID { get; set; }
        public string LTypeTitle { get; set; }
        public string LeaveDesc { get; set; }
        public string LAbbrName { get; set; }
        public string LMunit { get; set; }
        public string LNature { get; set; }
        public Nullable<decimal> LeaveTTL { get; set; }
        public Nullable<decimal> CarryToNextYear { get; set; }
        public Nullable<decimal> NumberofDaysInCashAble { get; set; }
        public Nullable<decimal> MaxDaysAllowablePerYear { get; set; }
        public Nullable<decimal> MinValidationPeriodInMonth { get; set; }
        public Nullable<decimal> MaxTotalAllowable { get; set; }
        public Nullable<decimal> MaximumAllowed { get; set; }
        public Nullable<decimal> MinimumAllowed { get; set; }
        public Nullable<decimal> FiscalYrId { get; set; }
        public string IsOffdayCounted { get; set; }
        public Nullable<decimal> Eligibility { get; set; }
        public Nullable<decimal> NextLevInterval { get; set; }
        public Nullable<decimal> TotalMatLev { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<System.DateTime> InsertedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual ICollection<EmpLeaveCTOEntitleLog> EmpLeaveCTOEntitleLogs { get; set; }
        public virtual ICollection<EmpLeaveProfile> EmpLeaveProfiles { get; set; }
    }
}
