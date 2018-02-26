using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHR.DATA
{
    [Serializable]
    public class EmpInfoDTO
    {
        public string EmpId { get; set; }
        public string FullName { get; set; }
        public string EmpNameWithId { get; set; }
    }
}
