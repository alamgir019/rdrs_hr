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
        public List<proc_select_EmpInfo_Result> getEmployeeInfo(string empId)
        {
            return context.proc_select_EmpInfo(empId).ToList();
        }

    }
}
