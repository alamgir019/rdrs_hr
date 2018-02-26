using BaseHR.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseHR.Repository.DAL
{
    public class DEmployee
    {
        private RDRS_RDRSEntities context = DBConnector.DbConnect.context;
        public List<EmpInfoDTO> getEmployeeInfo(string empId)
        {
            return context.proc_select_EmpInfo(empId).Select(ee=>new EmpInfoDTO { EmpId=ee.EmpId,
                FullName =ee.FullName,
                EmpNameWithId=ee.FullName.Trim() +" ["+ee.EmpId+"]"
            }).ToList();
        }

    }
}
