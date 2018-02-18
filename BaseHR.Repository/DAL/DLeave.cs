using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BaseHR.DATA;

namespace BaseHR.Repository.DAL
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
                       select new EmpLeaveCTOEntitleLog()
                       { EmpId = cto.EmpId.Trim(), EndDate = cto.EndDate, EnjoyedStatus = cto.EnjoyedStatus
                       ,LeaveEnjoyed=cto.LeaveEnjoyed,LEntitled=cto.LEntitled,LogId=cto.LogId,LTypeId=cto.LTypeId,
                       LvAppId=cto.LvAppId,LYear=cto.LYear,StartDate=cto.StartDate,
                           LTypeTitle=typ.LTypeTitle,
                           Remarks=cto.Remarks
                       }).ToList();
            return ctos.ToList();
        }
        public int AddEmpLeaveCTOEntitleLog(decimal logID, string empId, decimal leaveType, decimal entitle, string strStartDate, string strEndDate, decimal year, string remarks, string insertedBy, decimal prevValue)
        {
            try
            {
                EmpLeaveCTOEntitleLog objcto = context.EmpLeaveCTOEntitleLogs.Where(cc => cc.LogId == logID).FirstOrDefault();

                if (objcto == null)
                {
                    decimal maxId = context.EmpLeaveCTOEntitleLogs.Select(cc => cc.LogId).DefaultIfEmpty(0).Max();
                    objcto = new EmpLeaveCTOEntitleLog();
                    objcto.LogId = maxId + 1;
                    objcto.EmpId = empId;
                    objcto.LTypeId = leaveType;
                    objcto.LEntitled = entitle;
                    objcto.StartDate = Convert.ToDateTime(strStartDate);
                    objcto.EndDate = Convert.ToDateTime(strEndDate);
                    objcto.LYear = year;
                    objcto.Remarks = remarks;
                    objcto.InsertedBy = insertedBy;
                    objcto.InsertedDate = DateTime.Now;
                    context.EmpLeaveCTOEntitleLogs.Add(objcto);
                }
                else
                {
                    objcto.LTypeId = leaveType;
                    objcto.EmpId = empId;
                    objcto.LEntitled = entitle;
                    objcto.StartDate = Convert.ToDateTime(strStartDate);
                    objcto.EndDate = Convert.ToDateTime(strEndDate);
                    objcto.LYear = year;
                    objcto.Remarks = remarks;
                    objcto.UpdatedBy = insertedBy;
                    objcto.UpdatedDate = DateTime.Now;
                }
                bool isUpdatd = UpdateEmpLeaveEntitlement(empId, leaveType, prevValue, entitle, insertedBy);
                if (!isUpdatd)
                {
                    return 0;
                }
                int cnt = context.SaveChanges();
                return cnt;
            }
            catch (Exception exc)
            {
                throw exc;
            }    
        }

        public List<LeavePlan> GetLeavePlan()
        {
            var plans = (from pl in context.LeavePlans
                         join ltype in context.LeaveTypeLists on pl.LTypeId equals ltype.LTypeID
                         select new LeavePlan
                         {
                             ID = pl.ID,
                             EmpId = pl.EmpId,
                             LTypeId = pl.LTypeId,
                             LTypeName = ltype.LTypeTitle,
                             StardDate = pl.StardDate,
                             EndDate = pl.EndDate,
                             Remarks = pl.Remarks,
                             IsActive = pl.IsActive
                         }).ToList();
            return plans;
        }

        public int AddLeavePlan(LeavePlan objLeavePlan)
        {
            try
            {
            if (objLeavePlan.ID==0)
            {
                decimal maxId = context.LeavePlans.Select(mm => mm.ID).DefaultIfEmpty(0).Max();
                objLeavePlan.ID = ++maxId;
                context.LeavePlans.Add(objLeavePlan);
            }
            else
            {
                LeavePlan exPlan = context.LeavePlans.Where(ll => ll.ID == objLeavePlan.ID).FirstOrDefault();
                exPlan.EmpId = objLeavePlan.EmpId;
                exPlan.LTypeId = objLeavePlan.LTypeId;
                exPlan.StardDate = objLeavePlan.StardDate;
                exPlan.EndDate = objLeavePlan.EndDate;
                exPlan.Remarks = objLeavePlan.Remarks;
                exPlan.IsActive = objLeavePlan.IsActive;                
            }
            int cnt = context.SaveChanges();
            return cnt;
            }
            catch (Exception exc)
            {
                return 0;
            }
        }

        private bool UpdateEmpLeaveEntitlement(string empId, decimal leaveType, decimal prevValue, decimal entitle, string strInsertedBy)
        {
            try
            {
                EmpLeaveProfile lProfile = context.EmpLeaveProfiles.Where(lp => lp.EmpId == empId && lp.LTypeID == leaveType).FirstOrDefault();
                if (lProfile != null)
                {
                    lProfile.LEntitled = lProfile.LEntitled + entitle - prevValue;
                    lProfile.UpdatedBy = strInsertedBy;
                    lProfile.UpdatedDate = DateTime.Now;
                    return true;
                }
                return false;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
