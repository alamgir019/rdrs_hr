﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class RDRS_RDRSEntities : DbContext
    {
        public RDRS_RDRSEntities()
            : base("name=RDRS_RDRSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DivisionList> DivisionLists { get; set; }
        public DbSet<EmpLeaveCTOEntitleLog> EmpLeaveCTOEntitleLogs { get; set; }
        public DbSet<GradeList> GradeLists { get; set; }
        public DbSet<LeaveTypeList> LeaveTypeLists { get; set; }
        public DbSet<OfficeList> OfficeLists { get; set; }
        public DbSet<SectorList> SectorLists { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<UserPriv> UserPrivs { get; set; }
        public DbSet<ViewName> ViewNames { get; set; }
        public DbSet<EmpLeaveProfile> EmpLeaveProfiles { get; set; }
        public DbSet<LeavePlan> LeavePlans { get; set; }
        public DbSet<EmpInfo> EmpInfoes { get; set; }
        public DbSet<ProjectList> ProjectLists { get; set; }
    
        public virtual ObjectResult<proc_select_EmpInfo_Result> proc_select_EmpInfo(string empId)
        {
            var empIdParameter = empId != null ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_select_EmpInfo_Result>("proc_select_EmpInfo", empIdParameter);
        }
    }
}
