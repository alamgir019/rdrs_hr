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
using System.Text;

public partial class Payroll_Payroll_ITStatement : System.Web.UI.Page
{
    Payroll_MasterMgr objPayMstMgr = new Payroll_MasterMgr();
    EmpInfoManager objEmpMgr = new EmpInfoManager();
    MasterTablesManager objMastMg = new MasterTablesManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Common.FillDropDownList(objPayMstMgr.SelectFiscalYear(0, "T"), ddlFiscalYear, "FISCALYRTITLE", "FISCALYRID", false);
           // Common.FillDropDownList(objEmpMgr.SelectEmpNameWithIDForIT("A", ddlFiscalYear.SelectedValue.Trim()), ddlEmployee, "EmpName", "EmpID", true,"All");
            Common.FillDropDownList(objMastMg.GetDivision(), ddlIntervention, "DivisionName", "DivisionID", true, "Select");
        }
    }
    protected void rdbEmpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objEmpMgr.SelectEmpNameWithIDForIT(rdbEmpStatus.SelectedValue.Trim(), ddlFiscalYear.SelectedValue.Trim()), ddlEmployee, "EmpName", "EmpID", true, "All");
    }

    protected void dtnPrint_Click(object sender, EventArgs e)
    {
        string strURL = "";
        StringBuilder sb = new StringBuilder();

        strURL = "ITStatementReportMulti.aspx?params=" + ddlEmployee.SelectedValue.ToString().Trim() + "," + ddlFiscalYear.SelectedValue.ToString().Trim() + ","
            + rdbEmpStatus.SelectedValue.Trim() + "," + ddlFiscalYear.SelectedItem.Text.Trim() + "," + txtAssessYear.Text.Trim();
            //+","+ddlIntervention.SelectedValue.Trim()
           // +","+ddlOffice.SelectedValue.Trim(); 

        sb.Append("<script>");
        //sb.Append("window.open('" + strURL + "', '', 'fullscreen=true,scrollbars=yes,resizable=yes');");//
        sb.Append("window.open('" + strURL + "', '', '');");
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmSubmit",
                                 sb.ToString(), false);
        ClientScript.RegisterStartupScript(this.GetType(), "ConfirmSubmit", sb.ToString());
    }
    protected void ddlFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
    {
         //Common.FillDropDownList(objEmpMgr.SelectEmpNameWithIDForIT(rdbEmpStatus.SelectedValue.Trim(),ddlFiscalYear.SelectedValue.Trim()), ddlEmployee, "EmpName", "EmpID", true,"All");
    }
    protected void ddlIntervention_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMastMg.GetSalaryLocationByDivision(Convert.ToInt32(ddlIntervention.SelectedValue.Trim()), "Y", "N"), ddlOffice, "SalLocName", "SalLocId", true, "All");
        ddlEmployee.Items.Clear();
        Common.FillDropDownList(objEmpMgr.SelectEmpNameUsingDivisionSalLoc(ddlIntervention.SelectedValue.Trim(), "-1", "A"), ddlEmployee, "EMPNAME", "EMPID", false, "");
    }
    protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEmployee.Items.Clear();
        Common.FillDropDownList(objEmpMgr.SelectEmpNameUsingDivisionSalLoc(ddlIntervention.SelectedValue.Trim(), ddlOffice.SelectedValue.Trim(), "A"), ddlEmployee, "EMPNAME", "EMPID", false, "");
    }
}
