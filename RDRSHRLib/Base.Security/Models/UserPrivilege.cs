using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Security.Models
{
    public class UserPrivilege
    {
        private string _USERID;

        public string USERID
        {
            get { return _USERID; }
            set { _USERID = value; }
        }

        private int _ViewId;

        public int ViewId
        {
            get { return _ViewId; }
            set { _ViewId = value; }
        }
        public string ViewName { get; set; }
        private string _ViewPerm;

        public string ViewPerm
        {
            get { return _ViewPerm; }
            set { _ViewPerm = value; }
        }

        public string InsertPerm { get; set; }
        public string DeletePerm { get; set; }
        public decimal InterventionId { get; set; }
        public decimal HeadOfficeId { get; set; }
        public decimal CCOId { get; set; }
        public decimal ZoneId { get; set; }
        public decimal UnitId { get; set; }
        public decimal AreaId { get; set; }
        public decimal BranchId { get; set; }
        public decimal DistrictId { get; set; }
        public decimal UpazillaId { get; set; }
        public decimal ProjectId { get; set; }
        public decimal GradeId { get; set; }
        public decimal SectorId { get; set; }
        private string _InsertedBy;
        public string InsertedBy
        {
            get { return _InsertedBy; }
            set { _InsertedBy = value; }
        }

        private string _InsertedDate;
        public string InsertedDate
        {
            get { return _InsertedDate; }
            set { _InsertedDate = value; }
        }

        private string _UpdatedBy;
        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }

        private string _UpdatedDate;
        public string UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
    }
}
