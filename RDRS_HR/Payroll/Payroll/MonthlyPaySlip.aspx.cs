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

public partial class Payroll_Payroll_MonthlyPaySlip : System.Web.UI.Page
{
    EmpInfoManager objEmp = new EmpInfoManager();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillMonthList(ddlMonth);
            Common.FillYearList(5, ddlYear);
            ddlMonth.SelectedValue = Convert.ToString(DateTime.Today.Month);
            ddlYear.SelectedValue = Convert.ToString(DateTime.Today.Year);
           // Common.FillDropDownList(objEmp.SelectEmpNameWithID("A"), ddlEmployee, "EmpName", "EmpID", false);
            Common.FillDropDownList_All(objMasMgr.GetDivision(), ddlIntervention);
            if (Session["ISADMIN"].ToString() == "N")
            {
                ddlEmployee.SelectedValue = Session["EMPID"].ToString().ToUpper().Trim();
                ddlEmployee.Enabled = false;
            }
            else if (Session["ISADMIN"].ToString() == "Y")
            {
                if (Session["USERID"].ToString().ToUpper() != "ADMIN")             
                    ddlEmployee.SelectedValue = Session["EMPID"].ToString().ToUpper();                                   
            }
        }
    }
    protected void ddlIntervention_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetSalaryLocationByDivision(Convert.ToInt32(ddlIntervention.SelectedValue.Trim()), "Y", "N"), ddlOffice, "SalLocName", "SalLocId", true, "All");
        ddlEmployee.Items.Clear();
        Common.FillDropDownList(objEmp.SelectEmpNameUsingDivisionSalLoc(ddlIntervention.SelectedValue.Trim(), "-1", "A"), ddlEmployee, "EMPNAME", "EMPID", true, "Select");
    }
    protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEmployee.Items.Clear();
        Common.FillDropDownList(objEmp.SelectEmpNameUsingDivisionSalLoc(ddlIntervention.SelectedValue.Trim(), ddlOffice.SelectedValue.Trim(), "A"), ddlEmployee, "EMPNAME", "EMPID", true, "Select");
    }
    protected void rdbEmpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objEmp.SelectEmpNameWithID(rdbEmpStatus.SelectedValue.Trim()), ddlEmployee, "EmpName", "EmpID", false);
    }
    protected void dtnPrint_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string strURL = "MonthlyPaySlipReport.aspx?params=" + ddlMonth.SelectedValue.ToString() + "," + ddlMonth.SelectedItem.Text.Trim() + "," + ddlYear.SelectedValue.ToString() + "," 
            + ddlEmployee.SelectedValue.Trim() + "," + rdbSalaryType.SelectedValue.Trim();
        sb.Append("<script>");
        //sb.Append("window.open('" + strURL + "', '', 'fullscreen=true,scrollbars=yes,resizable=yes');");//
        sb.Append("window.open('" + strURL + "', '', '');");
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmSubmit",
                                 sb.ToString(), false);
        ClientScript.RegisterStartupScript(this.GetType(), "ConfirmSubmit", sb.ToString());
    }
}
