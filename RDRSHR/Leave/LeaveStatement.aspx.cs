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

public partial class Leave_LeaveStatement : System.Web.UI.Page
{
    EmpInfoManager objEmpMgr = new EmpInfoManager();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillDropDownList_All(objMasMgr.SelectDivision(0), ddlIntervention);
            Common.FillDropDownList_All(objMasMgr.SelectOfficeTypeList(0), ddlOffType);
            Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(0,-1,-1), ddlOffice);
            Common.FillDropDownList(objEmpMgr.SelectEmpNameWithID("A"), ddlEmployee, "EMPNAME", "EMPID", true);
            if (Session["ISADMIN"].ToString() == "N")
            {
                ddlEmployee.SelectedValue = Session["EMPID"].ToString().ToUpper();
                ddlEmployee.Enabled = false;
                ddlOffice.Enabled = false;              
            }
            else if (Session["ISADMIN"].ToString() == "Y")
            {
                if (Session["USERID"].ToString().ToUpper() != "ADMIN")
                {
                    ddlEmployee.Enabled = true;
                    ddlOffice.Enabled = true;
                }
            }
            else
            {
                ddlEmployee.SelectedIndex = -1;
                ddlEmployee.Enabled = true;
                ddlOffice.Enabled = false;
            }
        }
    }

    protected void GetDivisionWiseEmp(string strDivID)
    {
        Common.FillDropDownList(objEmpMgr.SelectDivisionalEmp(strDivID), ddlEmployee, "EMPNAME", "EMPID", true);
    }
    protected void ddlOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownListWithAll(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim())), ddlOffice, "OfficeTitleCombine", "OfficeID");
        //GetEmployee(Convert.ToDecimal(ddlOffice.SelectedValue.Trim()), Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim()));
    }

    private void GetEmployee(decimal officeid, decimal intervention, decimal offtype)
    {
        Common.FillDropDownList(objEmpMgr.SelectEmpByOffice(officeid, intervention, offtype), ddlEmployee, "EMPNAME", "EMPID", true);
    }
    protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDivisionWiseEmp(ddlOffice.SelectedValue.ToString());
        GetEmployee(Convert.ToDecimal(ddlOffice.SelectedValue.Trim()), Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim()));
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string strURL = "LeaveStatementRpt.aspx?params=" +  ddlEmployee.SelectedValue.ToString();
        sb.Append("<script>");
        //sb.Append("window.open('" + strURL + "', '', 'fullscreen=true,scrollbars=yes,resizable=yes');");//
        sb.Append("window.open('" + strURL + "', '', '');");
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmSubmit",
                                 sb.ToString(), false);
        ClientScript.RegisterStartupScript(this.GetType(), "ConfirmSubmit", sb.ToString());
    }
    protected void ddlIntervention_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetEmployee(Convert.ToDecimal(ddlOffice.SelectedValue.Trim()), Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim()));
    }
}
