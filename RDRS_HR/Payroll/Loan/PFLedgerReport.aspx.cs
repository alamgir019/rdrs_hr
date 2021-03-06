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
using System.Net;
using System.IO;
public partial class Payroll_Loan_PFLedgerReport : System.Web.UI.Page
{
    Payroll_MasterMgr objPayrollMgr = new Payroll_MasterMgr();
    Payroll_PFManager objPFMgr = new Payroll_PFManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillMonthList(ddlMonth);
            Common.FillYearList(5, ddlYear);
            ddlMonth.Items.Add("Nil");
            ddlYear.Items.Add("Nil");
            ddlMonth.SelectedValue = "Nil";
            ddlYear.SelectedValue = "Nil";
            Common.FillDropDownList(objPayrollMgr.SelectFiscalYear(0), ddlFiscalYear, "FISCALYRTITLE", "FISCALYRID", false);
        }
    }

    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string strMonth = "";
        string strYear = "";
        string strFiscalYear = "";
        string strEmpID = "";
        strMonth = ddlMonth.SelectedItem.Text == "Nil" ? "0" : ddlMonth.SelectedValue.Trim();
        strYear = ddlYear.SelectedItem.Text == "Nil" ? "0" : ddlYear.SelectedValue.Trim();
        strFiscalYear = ddlFiscalYear.SelectedItem.Text == "Nil" ? "0" : ddlFiscalYear.SelectedValue.Trim();
        strEmpID = txtEmpID.Text.Trim() == "" ? "" : txtEmpID.Text.Trim();
        if (strMonth == "0")
            lblPeriod.Text = ddlFiscalYear.SelectedItem.Text;
        else
            lblPeriod.Text = ddlMonth.SelectedItem.Text + " " + ddlFiscalYear.SelectedItem.Text;

        lblPrintDate.Text = Common.DisplayDateTime(DateTime.Now.ToString());

        rptPFLedger.DataSource = objPFMgr.GetPFLedgerData(strFiscalYear, strMonth, strYear, strEmpID);
        rptPFLedger.DataBind();
        rptPFLedgerSummary.DataSource = objPFMgr.GetPFLedgerSummaryData(strFiscalYear, strMonth, strYear, strEmpID);
        rptPFLedgerSummary.DataBind();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataTable dtLedger = objPFMgr.GetPFLedgerDataForExcel(ddlFiscalYear.SelectedValue.Trim(), ddlMonth.SelectedValue.Trim());
        grExport.Visible = true;
        grExport.DataSource = dtLedger;
        grExport.DataBind();
        foreach (GridViewRow gRow in grExport.Rows)
        {
            gRow.Cells[24].Text = Common.ReturnFullMonthName(gRow.Cells[24].Text.Trim());
            if (Common.CheckNullString(gRow.Cells[5].Text) !="")
                gRow.Cells[5].Text = Common.SetDate(gRow.Cells[5].Text.Trim());
            if (Common.CheckNullString(gRow.Cells[6].Text) != "")
                gRow.Cells[6].Text = Common.SetDate(gRow.Cells[6].Text.Trim());
        }
        string attachment = "attachment; filename=PFLedger.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grExport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
        grExport.DataSource = null;
        grExport.DataBind();
        grExport.Visible = true;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string strMonth = ddlMonth.SelectedItem.Text == "Nil" ? "0" : ddlMonth.SelectedValue.Trim();
        string strYear = ddlYear.SelectedItem.Text == "Nil" ? "0" : ddlYear.SelectedValue.Trim();
        string strFiscalYear = ddlFiscalYear.SelectedItem.Text == "Nil" ? "0" : ddlFiscalYear.SelectedValue.Trim();
        string strEmpID = txtEmpID.Text.Trim() == "" ? "" : txtEmpID.Text.Trim();


        Session["REPORTID"] = "PFLED";
        Session["FiscalYr"] = strFiscalYear;
        Session["FiscalYrValue"] = ddlFiscalYear.SelectedItem.Text == "Nil" ? "0" : ddlFiscalYear.SelectedItem.Text;
        Session["Month"] = strMonth;
        Session["MonthValue"] = ddlMonth.SelectedItem.Text == "Nil" ? "0" : ddlMonth.SelectedItem.Text;
        Session["Year"] = strYear;
        Session["EmpId"] = strEmpID;
        
        StringBuilder sb = new StringBuilder();

        sb.Append("<script>");
        sb.Append("window.open('../../CrystalReports/Payroll/LoanReportViewer.aspx', '', 'fullscreen=true,scrollbars=yes,resizable=yes');");//
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmSubmit",
                                 sb.ToString(), false);
        ClientScript.RegisterStartupScript(this.GetType(), "ConfirmSubmit", sb.ToString());
    }
}
