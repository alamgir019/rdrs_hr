using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHR.DATA
{
    [Serializable]
    public class UserPrivDTO
    {
        public decimal ID { get; set; }
        public string UserId { get; set; }
        public int ViewId { get; set; }
        public string ViewPerm { get; set; }
        public string InsertPerm { get; set; }
        public string DeletePerm { get; set; }
        public decimal InterventionId { get; set; }
        public decimal HeadOfficeId { get; set; }
        public decimal CCOId { get; set; }
        public Nullable<decimal> ZoneId { get; set; }
        public Nullable<decimal> UnitId { get; set; }
        public decimal AreaId { get; set; }
        public decimal BranchId { get; set; }
        public decimal DistrictId { get; set; }
        public decimal UpazillaId { get; set; }
        public decimal ProjectId { get; set; }
        public decimal GradeId { get; set; }
        public decimal SectorId { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<System.DateTime> InsertedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string LastUpdatedFrom { get; set; }

        public string PageName { get; set; }
        public string InterventionName { get; set; }
        public string HeadOfficeName { get; set; }
        public string CCOName { get; set; }
        public string ZoneName { get; set; }
        public string UnitName { get; set; }
        public string AreaName { get; set; }
        public string BranchName { get; set; }
        public string DistrictName { get; set; }
        public string ProjectName { get; set; }
        public string GradeName { get; set; }
        public string SectorName { get; set; }
    }
}
