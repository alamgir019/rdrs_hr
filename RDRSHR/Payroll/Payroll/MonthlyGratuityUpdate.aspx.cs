using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Payroll_Loan_MonthlyPFUpdate : System.Web.UI.Page
{
    Payroll_MasterMgr objPayrollMgr = new Payroll_MasterMgr();
    Payroll_LoanAppManager objLoanMgr = new Payroll_LoanAppManager();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();
    dsPayroll_Loan objDs = new dsPayroll_Loan();
    Payroll_PayslipApprovalManager objPayAppMgr = new Payroll_PayslipApprovalManager();
    MasterTablesManager objMastMg = new MasterTablesManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.EntryMode(false);
            Common.FillMonthList(ddlMonth);
            Common.FillYearList(5, ddlYear);
            ddlMonth.SelectedValue = Convert.ToString(DateTime.Today.Month);
            ddlYear.SelectedValue = Convert.ToString(DateTime.Today.Year);
            Common.FillDropDownList(objPayrollMgr.SelectFiscalYear(0), ddlFiscalYear, "FISCALYRTITLE", "FISCALYRID", false);
            Common.FillDropDownList(objMastMg.SelectEmpGroup(0), ddlGroup, "GrpName", "EmpGrpID", false);
        }
    }

    //protected DataTable GeneratePayrollReport(string strGenFor, string strGenValue, string strMonth, string strYear, string strBank, string strSalType)
    //{
    //    string strEmpID = "";


    //    //DataTable dtEmpPayroll = objPayRptMgr.GetSalarySheetDataForCrystalReport(strGenFor, strGenValue,
    //    //    strMonth, strYear, strBank,
    //    //    strSalType);
    //    DataTable dtEmpPayroll = objPayAppMgr.GetPayrollApprovedDataForDisbursement(strGenFor, strGenValue,
    //        strMonth, strYear, strBank,
    //        strSalType,ddlGroup.SelectedValue.Trim());
    //    //
    //    foreach (DataRow dEmpRow in dtEmpPayroll.Rows)
    //    {
    //        if (strEmpID == dEmpRow["EMPID"].ToString().Trim())
    //        {
    //            continue;
    //        }
    //        DataRow nRow = objDsSal.dtSalarySheet.NewRow();
    //        // Employee Basic
    //        nRow["EMPID"] = dEmpRow["EMPID"].ToString().Trim();

    //        // Gross, Net Pay, Total Deduction, Bank Acc
    //        nRow["GROSS"] = dEmpRow["GROSSAMNT"].ToString().Trim();
    //        nRow["NETSAL"] = dEmpRow["NETPAY"].ToString().Trim();
    //        nRow["BANKACC"] = dEmpRow["BANKACCNO"].ToString().Trim();
    //        nRow["TOTALDED"] = GetEmpBenefitsAndDeductionAmount(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim());

    //        // Employee Salary Items
    //        // Basic    1
    //        nRow["BASIC"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "1").ToString();
    //        // Basic Arrear 2
    //        nRow["BASICARR"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "19").ToString();
    //        // House Rent   3
    //        nRow["HRENT"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "2").ToString();
    //        // House Rent Arrear    4
    //        nRow["HRENTARR"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "20").ToString();
    //        // Medical  5
    //        nRow["MEDC"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "3").ToString();
    //        // Medical Arrear 6
    //        nRow["MEDCARR"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "21").ToString();

    //        // TransPort 7
    //        nRow["TRANS"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "4").ToString();
    //        // TransPort Arrear 8
    //        nRow["TRANSARR"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "22").ToString();

    //        // Field 9
    //        nRow["FIELD"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "7").ToString();
    //        // Field Arrear 10
    //        nRow["FIELDARR"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "23").ToString();
    //        // Other Allow 11
    //        nRow["OTHERS"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "8").ToString();

    //        // Advance Adjustment 12
    //        nRow["ADVADJ"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "26").ToString();

    //        // Revenue Stamp 13
    //        nRow["STP"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "17").ToString();
    //        // Other Deduction 14
    //        nRow["OTHERSDED"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "18").ToString();

    //        // PF Dedcution 15
    //        nRow["PF"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "9").ToString();
    //        // PF Dedcution Arrear 16
    //        nRow["PFARR"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "24").ToString();

    //        // PF Loan 17
    //        nRow["PFLOAN"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "10").ToString();
    //        // PF Interest 18
    //        nRow["PFINT"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "11").ToString();

    //        // PF Loan Charge 19
    //        nRow["PFCHARGE"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "27").ToString();

    //        // CU Share 20
    //        nRow["CUSHARE"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "12").ToString();

    //        // CU Loan 21
    //        nRow["CULOAN"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "13").ToString();

    //        // CU Interest 22
    //        nRow["CUINT"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "14").ToString();

    //        // CU Loan Charge 23
    //        nRow["CUCHARGE"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "28").ToString();

    //        // Income Tax 24
    //        nRow["IT"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "15").ToString();

    //        // Income Tax Ass 25
    //        nRow["ITASS"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "16").ToString();
    //        // Festival Bonus 26
    //        nRow["FESTIVAL"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "6").ToString();

    //        // SER Bonus 27
    //        nRow["SERBONUS"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "29").ToString();

    //        // LWOP 28
    //        nRow["LWOP"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "25").ToString();

    //        objDsSal.dtSalarySheet.Rows.Add(nRow);
    //        objDsSal.dtSalarySheet.AcceptChanges();
    //        strEmpID = dEmpRow["EMPID"].ToString().Trim();
    //    }
    //    return objDsSal.Tables["dtSalarySheet"];
    //}

    //protected DataTable GetPFRecordFromSalary(string strMonth, string strYear)
    //{
    //    string strEmpID = "";
    //    DataTable dtEmpPayroll = objPayAppMgr.GetGratuityFromSalary(strMonth, strYear, ddlGroup.SelectedValue.Trim());
    //    foreach (DataRow dEmpRow in dtEmpPayroll.Rows)
    //    {
    //        if (strEmpID == dEmpRow["EMPID"].ToString().Trim())
    //        {
    //            continue;
    //        }
    //        DataRow nRow = objDs.dtPFLoanLedger.NewRow();
    //        // Employee Basic
    //        nRow["EMPID"] = dEmpRow["EMPID"].ToString().Trim();
    //        // PF Emp
    //        nRow["PFAMT"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "6").ToString();
    //        // PF Loan
    //        nRow["PFLOAN"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "7").ToString();
    //        // PF Int
    //        nRow["PFINT"] = this.GetSalHeadAmt(dtEmpPayroll, dEmpRow["EMPID"].ToString().Trim(), "16").ToString();

    //        objDs.dtPFLoanLedger.Rows.Add(nRow);
    //        objDs.dtPFLoanLedger.AcceptChanges();
    //        strEmpID = dEmpRow["EMPID"].ToString().Trim();
    //    }
    //    return objDs.Tables["dtPFLoanLedger"];
    //}

    protected decimal GetSalHeadAmt(DataTable dt, string strEmpID, string strSHeadID)
    {
        decimal dclSalHeadAmt = 0;
        DataRow[] foundRows = dt.Select("EMPID='" + strEmpID + "' AND SHEADID=" + strSHeadID);
        if (foundRows.Length > 0)
        {
            dclSalHeadAmt = Convert.ToDecimal(foundRows[0]["PAYAMT"].ToString());
        }
        dclSalHeadAmt = Common.RoundDecimal(dclSalHeadAmt.ToString(), 0);
        return dclSalHeadAmt;
    }

    protected decimal GetEmpBenefitsAndDeductionAmount(DataTable dt, string strEmpID)
    {
        //dclTotalSalary = Convert.ToDecimal(strGrossSal);
        decimal dclSalHeadAmt = 0;
        decimal dclEmpDeduct = 0;
        DataRow[] foundRows = dt.Select("EMPID='" + strEmpID + "'");
        foreach (DataRow dRow in foundRows)
        {
            dclSalHeadAmt = 0;
            switch (dRow["ISDEDUCTED"].ToString())
            {
                //case "N":
                //    //dclEmpBenefits = dclEmpBenefits + this.GetSalHeadAmt(strEmpID, dRow["SHEADID"].ToString());
                //    break;
                case "Y":
                    dclSalHeadAmt = Common.RoundDecimal(dRow["PAYAMT"].ToString().Trim(), 0);
                    dclEmpDeduct = dclEmpDeduct + dclSalHeadAmt;
                    break;
            }
        }
        return dclEmpDeduct;
    }

    protected void btnUpdateGratuityLedger_Click(object sender, EventArgs e)
    {
        if (objLoanMgr.IsCurrentMonthGratuityLedgerExist(ddlMonth.SelectedValue.Trim(), ddlFiscalYear.SelectedValue.Trim()) == false)
        {
            DataTable dtEmpPayroll = objLoanMgr.GetDistinctEmployeeForLedger(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString());
            DataTable dtEmpGratuityData = objPayAppMgr.GetGratuityFromSalary(ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), ddlGroup.SelectedValue.Trim());
            objLoanMgr.PrepareGratuityLedgerData(dtEmpPayroll, dtEmpGratuityData, ddlMonth.SelectedValue.ToString(), ddlYear.SelectedValue.Trim(), "D", Session["USERID"].ToString().Trim(), Common.SetDateTime(DateTime.Now.ToString()), "S", Session["FISCALYRID"].ToString().Trim());
            if (dtEmpGratuityData.Rows.Count > 0)
            {
                lblMsg.Text = ddlMonth.SelectedItem.Text.Trim() + " Gratuity Ledger Prepared Successfully.";
            }
            else
            {
                lblMsg.Text = "Ledger not prepared. " + ddlMonth.SelectedItem.Text.Trim() + " month salary has not been disbursed yet.";
            }
        }
        else
        {
            lblMsg.Text = ddlMonth.SelectedItem.Text.Trim() + " PF Ledger Aleady Prepared.";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        objLoanMgr.DeleteGratuityLedgerData(ddlMonth.SelectedValue.Trim(), ddlFiscalYear.SelectedValue.Trim());
        lblMsg.Text = ddlMonth.SelectedItem.Text.Trim() + " PF Ledger Deleted Successfully.";
    }
}
