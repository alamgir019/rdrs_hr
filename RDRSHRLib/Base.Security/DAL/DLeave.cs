using Base.Repository.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Base.Repository.DAL
{
    public class DLeave
    {
        private RDRS_RDRSEntities context = DBConnector.DbConnect.context;
        public List<LeaveTypeList> getLeaveType()
        {
            return context.LeaveTypeLists.ToList();
        }
        public List<EmpLeaveCTOEntitleLog> GetLeaveCTO()
        {
            var ctos = (from cto in context.EmpLeaveCTOEntitleLogs
                       join typ in context.LeaveTypeLists on cto.LTypeId equals typ.LTypeID
                       select new EmpLeaveCTOEntitleLog() { EmpId = cto.EmpId, EndDate = cto.EndDate, EnjoyedStatus = cto.EnjoyedStatus
                       ,LeaveEnjoyed=cto.LeaveEnjoyed,LEntitled=cto.LEntitled,LogId=cto.LogId,LTypeId=cto.LTypeId,
                       LvAppId=cto.LvAppId,LYear=cto.LYear,StartDate=cto.StartDate,
                           LTypeTitle=typ.LTypeTitle
                       }).ToList();
            return ctos;
        }
        

        public void AddEmpLeaveCTOEntitleLog(string strLogID, string v1, string v2, string v3, string v4, string strStartDate, string strEndDate, string v5, string v6, string v7, string v8, string v9)
        {
            throw new NotImplementedException();
        }
    }
}
