using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHR.DATA
{
    public class LeavePlanDTO
    {
        public decimal ID { get; set; }
        public Nullable<decimal> LTypeId { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public string Remarks { get; set; }
        public string IsActive { get; set; }
        public string EmpId { get; set; }
        public string LTypeName { get; set; }
    }
}
