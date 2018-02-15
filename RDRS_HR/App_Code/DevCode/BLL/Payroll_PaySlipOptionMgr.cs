using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Payroll_PaySlipOption
/// </summary>
public class Payroll_PaySlipOptionMgr
{
    public long PAYSLIP_ADVANCE_LOAN_DEDUCT_SALARY_HEAD_ID = -1;
    public long PAYSLIP_TAXDEDEDUCTION_SALARYHEAD = -1;
    public long pa = -1;



    DBConnector objDC = new DBConnector();
    #region Insert Update Delete From Tables By Store procedure
    //Insert or Update  or Delete Data of Location table

    public void InsertpaySlipOption(clsPaySlipOptions[] opt, string strInsBy, string strInsDate)
    {
        SqlCommand[] command = new SqlCommand[opt.Length+2];

        //command[0] = new SqlCommand("proc_Payroll_DELETE_PaySlipOptions");
        //command[0].CommandType = CommandType.StoredProcedure;

        //SqlParameter p_OptID = command[0].Parameters.Add("OptID", SqlDbType.Char);
        //p_OptID.Direction = ParameterDirection.Input;
        //p_OptID.Value = opt[0].OptID;

        int i = 0;
        for (i = 0; i < opt.Length; i++)
        {
            command[i] = new SqlCommand("proc_Payroll_INSERT_PaySlipOptions");
            command[i].CommandType = CommandType.StoredProcedure;

            SqlParameter p_OptID = command[i].Parameters.Add("OptID", SqlDbType.Char);
            p_OptID.Direction = ParameterDirection.Input;
            p_OptID.Value = opt[i].OptID;

            SqlParameter p_OptName = command[i].Parameters.Add("OptName", SqlDbType.VarChar);
            p_OptName.Direction = ParameterDirection.Input;
            p_OptName.Value = opt[i].OptName;

            SqlParameter p_OptValue = command[i].Parameters.Add("OptValue", SqlDbType.VarChar);
            p_OptValue.Direction = ParameterDirection.Input;
            p_OptValue.Value = opt[i].OptValue;

            SqlParameter p_PayrollValidFrom = command[i].Parameters.Add("PayrollValidFrom", DBNull.Value);
            p_PayrollValidFrom.Direction = ParameterDirection.Input;
            p_PayrollValidFrom.IsNullable = true;
            if (string.IsNullOrEmpty(opt[i].ValidFrom) == false)
                p_PayrollValidFrom.Value = opt[i].ValidFrom;

            SqlParameter p_PayrollValidTo = command[i].Parameters.Add("PayrollValidTo", DBNull.Value);
            p_PayrollValidTo.Direction = ParameterDirection.Input;
            p_PayrollValidTo.IsNullable = true;
            if (string.IsNullOrEmpty(opt[i].ValidTo) == false)
                p_PayrollValidTo.Value = opt[i].ValidTo;

            SqlParameter p_InsertedBy = command[i].Parameters.Add("InsertedBy", SqlDbType.VarChar);
            p_InsertedBy.Direction = ParameterDirection.Input;
            p_InsertedBy.Value = strInsBy;

            SqlParameter p_InsertedDate = command[i].Parameters.Add("InsertedDate", SqlDbType.DateTime);
            p_InsertedDate.Direction = ParameterDirection.Input;
            p_InsertedDate.Value = strInsDate;
        }
        try
        {
            objDC.MakeTransaction(command);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            command = null;
        }
    }

    //public void InsertBenefitsPolicyData(string strSHeadID, string strEmpType, string strIsPercent, string strValue, string strPercentOf)
    //{
    //    SqlCommand cmd = new SqlCommand("");
    //}

    #endregion

    public DataTable SelectpaySlipOption(string StrOptId)
    {
        SqlCommand command = new SqlCommand("proc_Payroll_Select_PaySlipOption");

        SqlParameter p_OptID = command.Parameters.Add("OptID", SqlDbType.Char);
        p_OptID.Direction = ParameterDirection.Input;
        p_OptID.Value = StrOptId;

        objDC.CreateDSFromProc(command, "PaySlipOption");
        return objDC.ds.Tables["PaySlipOption"];
    }


    public void GetPaySlipOptionsValue()
    {
        SqlCommand command = new SqlCommand("proc_Payroll_Select_PaySlipOptionShow");

        objDC.CreateDSFromProc(command, "PaySlipOption");
        DataTable dtop = objDC.ds.Tables["PaySlipOption"];

        foreach (DataRow dRow in dtop.Rows)
        {
            if (dRow["OptId"].ToString() == "OC01".ToString())
                PAYSLIP_ADVANCE_LOAN_DEDUCT_SALARY_HEAD_ID = Convert.ToInt16(dRow["OptValue"]);
            else if (dRow["OptId"].ToString() == "OC02")
                PAYSLIP_TAXDEDEDUCTION_SALARYHEAD = Convert.ToInt16(dRow["OptValue"]);
        }
    }

    #region Monthly Payroll Cycle
    public void InsertMonthlyPayrollCycleData(string strMPCID, string strMPCTitle, string strPStartDay, string strPEndDay,
        string strAStartDay, string strAEndDay, string strIsUpdate, string strInsBy, string strInsDate)
    {
        SqlCommand cmd = new SqlCommand("Proc_Payroll_Insert_MONTHLYPAYROLLCYCLE");
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p_MPCID = cmd.Parameters.Add("MPCID", SqlDbType.BigInt);
        p_MPCID.Direction = ParameterDirection.Input;
        p_MPCID.Value = strMPCID;

        SqlParameter p_MPCTITLE = cmd.Parameters.Add("MPCTITLE", SqlDbType.VarChar);
        p_MPCTITLE.Direction = ParameterDirection.Input;
        p_MPCTITLE.Value = strMPCTitle;

        SqlParameter p_PSTARTDAY = cmd.Parameters.Add("PSTARTDAY", SqlDbType.BigInt);
        p_PSTARTDAY.Direction = ParameterDirection.Input;
        p_PSTARTDAY.Value = strPStartDay;

        SqlParameter p_PENDDAY = cmd.Parameters.Add("PENDDAY", SqlDbType.BigInt);
        p_PENDDAY.Direction = ParameterDirection.Input;
        p_PENDDAY.Value = strPEndDay;

        SqlParameter p_ASTARTDAY = cmd.Parameters.Add("ASTARTDAY", SqlDbType.BigInt);
        p_ASTARTDAY.Direction = ParameterDirection.Input;
        p_ASTARTDAY.Value = strAStartDay;

        SqlParameter p_AENDDAY = cmd.Parameters.Add("AENDDAY", SqlDbType.BigInt);
        p_AENDDAY.Direction = ParameterDirection.Input;
        p_AENDDAY.Value = strAEndDay;

        SqlParameter p_INSERTEDBY = cmd.Parameters.Add("INSERTEDBY", SqlDbType.VarChar);
        p_INSERTEDBY.Direction = ParameterDirection.Input;
        p_INSERTEDBY.Value = strInsBy;

        SqlParameter p_INSERTEDDATE = cmd.Parameters.Add("INSERTEDDATE", SqlDbType.DateTime);
        p_INSERTEDDATE.Direction = ParameterDirection.Input;
        p_INSERTEDDATE.Value = strInsDate;

        SqlParameter p_ISUPDATE = cmd.Parameters.Add("ISUPDATE", SqlDbType.Char);
        p_ISUPDATE.Direction = ParameterDirection.Input;
        p_ISUPDATE.Value = strIsUpdate;

        objDC.ExecuteQuery(cmd);

    }

    public void DeleteMonthlyPayrollCycleData(string strMPCID)
    {
        string strSQL = "DELETE FROM MonthlyPayrollCycle WHERE MPCID=@MPCID";
        SqlCommand cmd = new SqlCommand(strSQL);
        cmd.CommandType = CommandType.Text;
        SqlParameter p_MPCID = cmd.Parameters.Add("MPCID", SqlDbType.BigInt);
        p_MPCID.Direction = ParameterDirection.Input;
        p_MPCID.Value = strMPCID;
        objDC.ExecuteQuery(cmd);
    }

    public DataTable GetMonthlyPayrollCycleData()
    {
        string strSQL = "SELECT * FROM MonthlyPayrollCycle";
        return objDC.CreateDT(strSQL, "MonthlyPayrollCycleData");
    }

    public DataTable GetMPCData(string strMPCID)
    {
        string strSQL = "SELECT * FROM MonthlyPayrollCycle WHERE MPCID=@MPCID";
        SqlCommand cmd = new SqlCommand(strSQL);
        cmd.CommandType = CommandType.Text;

        SqlParameter p_MPCID = cmd.Parameters.Add("MPCID", SqlDbType.BigInt);
        p_MPCID.Direction = ParameterDirection.Input;
        p_MPCID.Value = strMPCID;

        return objDC.CreateDT(cmd, "GetMPCData");
    }

    #endregion

    #region Payroll Benefits Policy
    public void InsertPayrollBenefitsPolicyData(string strPID, string strSheadID, string strEmpType, string strIsPercent,
        string strPercentOf, string strValue, string strIsUpdate, string strInsBy, string strInsDate)
    {
        SqlCommand cmd = new SqlCommand("Proc_Payroll_Insert_PayrollBenefitsPolicy");
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p_PID = cmd.Parameters.Add("PID", SqlDbType.BigInt);
        p_PID.Direction = ParameterDirection.Input;
        p_PID.Value = strPID;

        SqlParameter p_SHEADID = cmd.Parameters.Add("SHEADID", SqlDbType.BigInt);
        p_SHEADID.Direction = ParameterDirection.Input;
        p_SHEADID.Value = strSheadID;

        SqlParameter p_EMPTYPEID = cmd.Parameters.Add("EMPTYPEID", SqlDbType.BigInt);
        p_EMPTYPEID.Direction = ParameterDirection.Input;
        p_EMPTYPEID.Value = strEmpType;

        SqlParameter p_VALUE = cmd.Parameters.Add("VALUE", SqlDbType.Decimal);
        p_VALUE.Direction = ParameterDirection.Input;
        p_VALUE.Value = strValue;

        SqlParameter p_ISPERCENT = cmd.Parameters.Add("ISPERCENT", SqlDbType.Char);
        p_ISPERCENT.Direction = ParameterDirection.Input;
        p_ISPERCENT.Value = strIsPercent;

        SqlParameter p_PERCENTOF = cmd.Parameters.Add("PERCENTOF", SqlDbType.BigInt);
        p_PERCENTOF.Direction = ParameterDirection.Input;
        p_PERCENTOF.Value = strPercentOf;

        SqlParameter p_INSERTEDBY = cmd.Parameters.Add("INSERTEDBY", SqlDbType.VarChar);
        p_INSERTEDBY.Direction = ParameterDirection.Input;
        p_INSERTEDBY.Value = strInsBy;

        SqlParameter p_INSERTEDDATE = cmd.Parameters.Add("INSERTEDDATE", SqlDbType.DateTime);
        p_INSERTEDDATE.Direction = ParameterDirection.Input;
        p_INSERTEDDATE.Value = strInsDate;

        SqlParameter p_ISUPDATE = cmd.Parameters.Add("ISUPDATE", SqlDbType.Char);
        p_ISUPDATE.Direction = ParameterDirection.Input;
        p_ISUPDATE.Value = strIsUpdate;

        objDC.ExecuteQuery(cmd);
    }

    public void DeletePayrollBenefitsPolicyData(string strPID)
    {
        SqlCommand cmd = new SqlCommand("Proc_Payroll_Delete_PayrollBenefitsPolicy");
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p_PID = cmd.Parameters.Add("PID", SqlDbType.BigInt);
        p_PID.Direction = ParameterDirection.Input;
        p_PID.Value = strPID;

        objDC.ExecuteQuery(cmd);
    }

    public DataTable SelectPayrollBenefitsPolicyData(string strHeadID)
    {
        SqlCommand cmd = new SqlCommand("Proc_Payroll_Select_PayrollBenefitsPolicy");
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p_SHEADID = cmd.Parameters.Add("SHEADID", SqlDbType.BigInt);
        p_SHEADID.Direction = ParameterDirection.Input;
        p_SHEADID.Value = strHeadID;

        objDC.CreateDSFromProc(cmd, "SelectPayrollBenefitsPolicyData");
        return objDC.ds.Tables["SelectPayrollBenefitsPolicyData"];
    }

    public DataTable SelectPayrollBenefitsPolicyDataByType(string strHeadID, string strEmpType)
    {
        SqlCommand cmd = new SqlCommand("Proc_Payroll_Select_PayrollBenefitsPolicyByType");
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p_SHEADID = cmd.Parameters.Add("SHEADID", SqlDbType.BigInt);
        p_SHEADID.Direction = ParameterDirection.Input;
        p_SHEADID.Value = strHeadID;

        SqlParameter p_EMPTYPEID = cmd.Parameters.Add("EMPTYPEID", SqlDbType.BigInt);
        p_EMPTYPEID.Direction = ParameterDirection.Input;
        p_EMPTYPEID.Value = strEmpType;

        objDC.CreateDSFromProc(cmd, "SelectPayrollBenefitsPolicyDataByType");
        return objDC.ds.Tables["SelectPayrollBenefitsPolicyDataByType"];
    }




    #endregion

    public Payroll_PaySlipOptionMgr()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region IT Policy
    public void SaveITPolicyData(DataTable dtITPolicy, string strInsBy, string strInsDate)
    {
        SqlCommand[] command = new SqlCommand[dtITPolicy.Rows.Count + 1];

        command[0] = new SqlCommand("PROC_PAYROLL_DELETE_ITPOLICY");
        command[0].CommandType = CommandType.StoredProcedure;
        int i = 1;
        foreach (DataRow dRow in dtITPolicy.Rows)
        {
            command[i] = new SqlCommand("PROC_PAYROLL_INSERT_ITPOLICY");
            command[i].CommandType = CommandType.StoredProcedure;

            SqlParameter p_POLICYID = command[i].Parameters.Add("POLICYID", SqlDbType.Char);
            p_POLICYID.Direction = ParameterDirection.Input;
            p_POLICYID.Value = dRow["POLICYID"].ToString().Trim();

            SqlParameter p_MAMT = command[i].Parameters.Add("MAMT", SqlDbType.Decimal);
            p_MAMT.Direction = ParameterDirection.Input;
            p_MAMT.Value = dRow["MAMT"].ToString().Trim();

            SqlParameter p_FAMT = command[i].Parameters.Add("FAMT", SqlDbType.Decimal);
            p_FAMT.Direction = ParameterDirection.Input;
            p_FAMT.Value = dRow["FAMT"].ToString().Trim();

            SqlParameter p_AAMT = command[i].Parameters.Add("AAMT", SqlDbType.Decimal);
            p_AAMT.Direction = ParameterDirection.Input;
            p_AAMT.Value = dRow["AAMT"].ToString().Trim();

            SqlParameter p_InsertedBy = command[i].Parameters.Add("INSERTEDBY", SqlDbType.VarChar);
            p_InsertedBy.Direction = ParameterDirection.Input;
            p_InsertedBy.Value = strInsBy;

            SqlParameter p_InsertedDate = command[i].Parameters.Add("INSERTEDDATE", SqlDbType.DateTime);
            p_InsertedDate.Direction = ParameterDirection.Input;
            p_InsertedDate.Value = strInsDate;

            i++;
        }
        try
        {
            objDC.MakeTransaction(command);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            command = null;
        }
    }

    
    public DataTable GetITPolicyData()
    {
        string strSQL = "SELECT POLICYID,MAMT,FAMT,AAMT FROM ITPolicy";
        return objDC.CreateDT(strSQL, "ITPolicyData");
    }

   
    #endregion   
}
