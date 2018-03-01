using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHR.DATA
{
    [Serializable]
    public class ComponentListDTO
    {
        public decimal ComponentId { get; set; }
        public string ComponentName { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<System.DateTime> InsertedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string LastUpdatedFrom { get; set; }
        
    }
}
