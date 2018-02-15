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
/// Summary description for BonusAllowanceManager
/// </summary>
public class BonusAllowanceManager
{
    DBConnector objDC = new DBConnector();

    public void InsertBonusAllowanceData(GridView gr, string strFinYear, string strReligion, string strMonth, string strYear, string strFestiveDate,
        string strSheadID, string strInsBy, string strInsDate, string FestivalID, string strVStatus,string strTaxFinYr,string strDivisioId,string strSalaryLocation)
    {
        SqlCommand[] cmd = new SqlCommand[gr.Rows.Count];
        int i = 0;
        long lngVID = objDC.GerMaxIDNumber("BonusAllowance", "VID");

        foreach (GridViewRow gRow in gr.Rows)
        {
            CheckBox chkB = (CheckBox)gRow.Cells[0].FindControl("ChkBox");
            if (chkB.Checked == true)
            {
                cmd[i] = new SqlCommand("proc_Payroll_Insert_BonusAllowance");
                cmd[i].CommandType = CommandType.StoredProcedure;

                SqlParameter p_VID = cmd[i].Parameters.Add("VID", SqlDbType.BigInt);
                p_VID.Direction = ParameterDirection.Input;
                p_VID.Value = lngVID;

                SqlParameter p_EMPID = cmd[i].Parameters.Add("EMPID", SqlDbType.Char);
                p_EMPID.Direction = ParameterDirection.Input;
                p_EMPID.Value = gRow.Cells[1].Text.Trim();

                SqlParameter p_EMPTYPEID = cmd[i].Parameters.Add("EMPTYPEID", SqlDbType.BigInt);
                p_EMPTYPEID.Direction = ParameterDirection.Input;
                p_EMPTYPEID.Value = gr.DataKeys[gRow.DataItemIndex].Values[2].ToString().Trim();

                SqlParameter p_VMONTH = cmd[i].Parameters.Add("VMONTH", SqlDbType.BigInt);
                p_VMONTH.Direction = ParameterDirection.Input;
                p_VMONTH.Value = strMonth;

                SqlParameter p_VYEAR = cmd[i].Parameters.Add("VYEAR", SqlDbType.BigInt);
                p_VYEAR.Direction = ParameterDirection.Input;
                p_VYEAR.Value = strYear;

                SqlParameter p_FISCALYRID = cmd[i].Parameters.Add("FISCALYRID", SqlDbType.BigInt);
                p_FISCALYRID.Direction = ParameterDirection.Input;
                p_FISCALYRID.Value = strFinYear;

                SqlParameter p_SHEADID = cmd[i].Parameters.Add("SHEADID", SqlDbType.BigInt);
                p_SHEADID.Direction = ParameterDirection.Input;
                p_SHEADID.Value = strSheadID;

                SqlParameter p_EMPBASIC = cmd[i].Parameters.Add("EMPBASIC", SqlDbType.Decimal);
                p_EMPBASIC.Direction = ParameterDirection.Input;
                p_EMPBASIC.Value = gRow.Cells[8].Text.Trim();

                TextBox txtB = (TextBox)gRow.Cells[9].FindControl("txtBonus");
                SqlParameter p_PAYAMT = cmd[i].Parameters.Add("PAYAMT", SqlDbType.Decimal);
                p_PAYAMT.Direction = ParameterDirection.Input;
                p_PAYAMT.Value = txtB.Text;

                SqlParameter p_ISPRORATA = cmd[i].Parameters.Add("ISPRORATA", SqlDbType.Char);
                p_ISPRORATA.Direction = ParameterDirection.Input;
                p_ISPRORATA.Value = gRow.Cells[7].Text.Trim();

                SqlParameter p_VSTATUS = cmd[i].Parameters.Add("VSTATUS", SqlDbType.Char);
                p_VSTATUS.Direction = ParameterDirection.Input;
                p_VSTATUS.Value = strVStatus;

                SqlParameter p_INSERTTEDBY = cmd[i].Parameters.Add("INSERTTEDBY", SqlDbType.VarChar);
                p_INSERTTEDBY.Direction = ParameterDirection.Input;
                p_INSERTTEDBY.Value = strInsBy;

                SqlParameter p_INSERTTEDDATE = cmd[i].Parameters.Add("INSERTTEDDATE", SqlDbType.Char);
                p_INSERTTEDDATE.Direction = ParameterDirection.Input;
                p_INSERTTEDDATE.Value = strInsDate;

                SqlParameter p_RELIGION = cmd[i].Parameters.Add("RELIGIONId", SqlDbType.BigInt);
                p_RELIGION.Direction = ParameterDirection.Input;
                p_RELIGION.Value = strReligion;

                SqlParameter p_PRORATADAYS = cmd[i].Parameters.Add("PRORATADAYS", SqlDbType.Char);
                p_PRORATADAYS.Direction = ParameterDirection.Input;
                p_PRORATADAYS.Value = gRow.Cells[10].Text.Trim();

                SqlParameter p_FESTIVEDATE = cmd[i].Parameters.Add("FESTIVEDATE", SqlDbType.DateTime);
                p_FESTIVEDATE.Direction = ParameterDirection.Input;
                p_FESTIVEDATE.Value = strFestiveDate;

                SqlParameter p_FestivalID = cmd[i].Parameters.Add("FestivalID", SqlDbType.BigInt);
                p_FestivalID.Direction = ParameterDirection.Input;
                p_FestivalID.Value = FestivalID;    

                //SqlParameter p_TaxFiscalYrId = cmd[i].Parameters.Add("TaxFiscalYrId", SqlDbType.BigInt);
                //p_TaxFiscalYrId.Direction = ParameterDirection.Input;
                //p_TaxFiscalYrId.Value = strTaxFinYr;
                if (strDivisioId!="-1" && strDivisioId != string.Empty)
                {
                    SqlParameter p_DivisionId = cmd[i].Parameters.Add("DivisionId", SqlDbType.Int);
                    p_DivisionId.Direction = ParameterDirection.Input;
                    p_DivisionId.Value = strDivisioId;
                }
                else
                {
                    SqlParameter p_DivisionId = cmd[i].Parameters.Add("DivisionId", SqlDbType.Int);
                    p_DivisionId.Direction = ParameterDirection.Input;
                    p_DivisionId.Value = DBNull.Value;
                }

                if (strSalaryLocation!= "-1" && strSalaryLocation != string.Empty)
                {
                    SqlParameter p_SalLocId = cmd[i].Parameters.Add("SalLocId", SqlDbType.Int);
                    p_SalLocId.Direction = ParameterDirection.Input;
                    p_SalLocId.Value = strSalaryLocation;
                }
                else
                {
                    SqlParameter p_SalLocId = cmd[i].Parameters.Add("SalLocId", SqlDbType.Int);
                    p_SalLocId.Direction = ParameterDirection.Input;
                    p_SalLocId.Value = DBNull.Value;
                }

                i++;
                lngVID++;
            }
        }
        objDC.MakeTransaction(cmd);
    }

    public void DeleteBonusAllowanceData(string strMonth, string strYear, string strFinYear, string strSheadId, string strRelegion, string strFistavalID, string strEmpTypeId)
    {
        SqlCommand cmd = new SqlCommand("Proc_Payroll_Delete_BonusAllowance");
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p_VMONTH = cmd.Parameters.Add("VMONTH", SqlDbType.BigInt);
        p_VMONTH.Direction = ParameterDirection.Input;
        p_VMONTH.Value = strMonth;

        SqlParameter p_VYEAR = cmd.Parameters.Add("VYEAR", SqlDbType.BigInt);
        p_VYEAR.Direction = ParameterDirection.Input;
        p_VYEAR.Value = strYear;

        SqlParameter p_FISCALYRID = cmd.Parameters.Add("FISCALYRID", SqlDbType.BigInt);
        p_FISCALYRID.Direction = ParameterDirection.Input;
        p_FISCALYRID.Value = strFinYear;

        SqlParameter p_SHEADID = cmd.Parameters.Add("SHEADID", SqlDbType.BigInt);
        p_SHEADID.Direction = ParameterDirection.Input;
        p_SHEADID.Value = strSheadId;

        SqlParameter p_Religion = cmd.Parameters.Add("Religion", SqlDbType.VarChar);
        p_Religion.Direction = ParameterDirection.Input;
        p_Religion.Value = strRelegion;

        SqlParameter p_FestivalID = cmd.Parameters.Add("FestivalID", SqlDbType.BigInt);
        p_FestivalID.Direction = ParameterDirection.Input;
        p_FestivalID.Value = strFistavalID;

        SqlParameter p_EmpTypeId = cmd.Parameters.Add("EmpTypeId", SqlDbType.BigInt);
        p_EmpTypeId.Direction = ParameterDirection.Input;
        p_EmpTypeId.Value = strEmpTypeId;

        objDC.ExecuteQuery(cmd);
    }

    public DataTable GetBonusAllowanceData(string strDivisionId,string strSalaryLoc, string strMonth,string strYear,string strFinYear,string strSheadId, string strRelegion,string strFistavalID,string strEmpTypeId)
    {
        SqlCommand cmd = new SqlCommand("Proc_Payroll_Select_BonusAllowance");
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p_DivisionId = cmd.Parameters.Add("DivisionId", SqlDbType.Int);
        p_DivisionId.Direction = ParameterDirection.Input;
        p_DivisionId.Value = strDivisionId;

        SqlParameter p_SalLocId = cmd.Parameters.Add("SalLocId", SqlDbType.Int);
        p_SalLocId.Direction = ParameterDirection.Input;
        p_SalLocId.Value = strSalaryLoc;

        SqlParameter p_VMONTH = cmd.Parameters.Add("VMONTH", SqlDbType.BigInt);
        p_VMONTH.Direction = ParameterDirection.Input;
        p_VMONTH.Value = strMonth;

        SqlParameter p_VYEAR = cmd.Parameters.Add("VYEAR", SqlDbType.BigInt);
        p_VYEAR.Direction = ParameterDirection.Input;
        p_VYEAR.Value = strYear;

        SqlParameter p_FISCALYRID = cmd.Parameters.Add("FISCALYRID", SqlDbType.BigInt);
        p_FISCALYRID.Direction = ParameterDirection.Input;
        p_FISCALYRID.Value = strFinYear;

        SqlParameter p_SHEADID = cmd.Parameters.Add("SHEADID", SqlDbType.BigInt);
        p_SHEADID.Direction = ParameterDirection.Input;
        p_SHEADID.Value = strSheadId;

        SqlParameter p_Religion = cmd.Parameters.Add("ReligionId", SqlDbType.BigInt);
        p_Religion.Direction = ParameterDirection.Input;
        p_Religion.Value = strRelegion;

        SqlParameter p_FestivalID = cmd.Parameters.Add("FestivalID", SqlDbType.BigInt);
        p_FestivalID.Direction = ParameterDirection.Input;
        p_FestivalID.Value = strFistavalID;

        SqlParameter p_EmpTypeId = cmd.Parameters.Add("EmpTypeId", SqlDbType.BigInt);
        p_EmpTypeId.Direction = ParameterDirection.Input;
        p_EmpTypeId.Value = strEmpTypeId;

        objDC.CreateDSFromProc(cmd, "GetBonusAllowanceData");
        return objDC.ds.Tables["GetBonusAllowanceData"];
    }

    public DataTable GetEmployeeForBonusAllowance(string strRelegion, string strDate, string strEmpTypeId)
    {
        SqlCommand cmd = new SqlCommand("proc_Payroll_Select_EmployeeForBonusAllowance");
        cmd.CommandType = CommandType.StoredProcedure;
        
        SqlParameter p_Religion = cmd.Parameters.Add("ReligionId", SqlDbType.BigInt);
        p_Religion.Direction = ParameterDirection.Input;
        p_Religion.Value = strRelegion;

         SqlParameter p_JoiningDate = cmd.Parameters.Add("JOININGDATE", SqlDbType.DateTime);
        p_JoiningDate.Direction = ParameterDirection.Input;
        p_JoiningDate.Value = strDate;

        SqlParameter p_EmpTypeId = cmd.Parameters.Add("EmpTypeId", SqlDbType.BigInt);
        p_EmpTypeId.Direction = ParameterDirection.Input;
        p_EmpTypeId.Value = strEmpTypeId;

        // SqlParameter p_JoiningDate = cmd.Parameters.Add("JoiningDate", SqlDbType.DateTime);
        //p_JoiningDate.Direction = ParameterDirection.Input;
        //p_JoiningDate.Value = strDate;

        //SqlParameter p_Religion = cmd.Parameters.Add("ReligionId", SqlDbType.BigInt);
        //p_Religion.Direction = ParameterDirection.Input;
        //p_Religion.Value = strRelegion;

        //@Religion varchar(60),        
        //@JOININGDATE datetime         
 
        objDC.CreateDSFromProc(cmd, "GetEmployeeForBonusAllowance");
        return objDC.ds.Tables["GetEmployeeForBonusAllowance"];
    }

    public DataTable GetNoOfBasicRelagionWise(string strRelagionId)
    {
        string strSQL = "SELECT isnull(NumberOfbasic,1) as NumberOfbasic FROM ReligionList WHERE ReligionId =" + Convert.ToInt32(strRelagionId);
          
        SqlCommand cmd = new SqlCommand(strSQL);
        //cmd2.CommandType = CommandType.StoredProcedure;

        objDC.CreateDT(cmd, "NumberOfbasic");
        return objDC.ds.Tables["NumberOfbasic"];
    }

	public BonusAllowanceManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
