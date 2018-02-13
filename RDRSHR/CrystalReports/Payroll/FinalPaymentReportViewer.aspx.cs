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
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using CrystalDecisions.Shared;
using cashword.BLL;

public partial class CrystalReports_Payroll_FinalPaymentReportViewer : System.Web.UI.Page
{
    Payroll_GratuityLedgerManager objGrMgr = new Payroll_GratuityLedgerManager();

    private ReportDocument ReportDoc;
    private PrintDocument printDoc = new PrintDocument();
    private string ReportPath = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strParams = Request.QueryString["params"];
        string[] strVal = strParams.Split(',');
        this.GenerateReport(strVal[0], strVal[1], strVal[2], strVal[3]);
    }

    protected void GenerateReport(string strMonth, string strYear, string strEmpID, string IsFromPayroll)
    {
        dsFinalPayment objFinalPay = new dsFinalPayment();
        ReportDoc = new ReportDocument();
        ReportPath = Server.MapPath("~/CrystalReports/Payroll/rptFinalPayment.rpt");

        DataTable dtTmp = objGrMgr.GetFinalPaymentData(strMonth, strYear, strEmpID, IsFromPayroll);
        foreach (DataRow dRow in dtTmp.Rows)
        {
            clscashword objWord = new clscashword();
            DataRow nRow = objFinalPay.dtFinalPayment.NewRow();

            nRow["EmpId"] = dRow["EmpId"];
            nRow["FullName"] = dRow["FullName"];
            nRow["JobTitle"] = dRow["JobTitleName"];
            nRow["JoiningDate"] = dRow["JoiningDate"];
            nRow["SEPERATEDATE"] = dRow["SeparateDate"];
            nRow["SeparationType"] = dRow["SeparateTypeId"];
            nRow["Salary"] = dRow["Salary"];
            nRow["SalayUpto"] = dRow["SalayUpto"];
            nRow["Bonus"] = dRow["Bonus"];
            nRow["SalaryMinBonus"] = dRow["SalaryMinBonus"];
            nRow["BonusDays"] = dRow["BonusDays"];
            nRow["Gratuity"] = dRow["Gratuity"];
            nRow["GrPayDate"] = dRow["GrPayDate"];
            nRow["LeaveEncash"] = dRow["LeaveEncash"];
            nRow["AnnualLeave"] = dRow["AnnualLeave"];
            nRow["PFAmount"] = dRow["PFAmount"];
            nRow["TotalAmt"] = dRow["TotalAmt"];
            nRow["InWord"] = objWord.getCashWord(dRow["TotalAmt"].ToString());
            nRow["BasicSalary"] = dRow["BasicSalary"];
            nRow["BONUSALLOW"] = dRow["BONUSALLOW"];

            objFinalPay.dtFinalPayment.Rows.Add(nRow);
        }
        objFinalPay.dtFinalPayment.AcceptChanges();

        ReportDoc.Load(ReportPath);
        ReportDoc.SetDataSource(objFinalPay.Tables["dtFinalPayment"]);
        CRV.ReportSource = ReportDoc;
    }

    public void PassParameter(string strMonthName)
    {
        ParameterFields pFields = new ParameterFields();
        ParameterField pMonthName = new ParameterField();

        //Generate ParameterDiscreteValue        
        ParameterDiscreteValue MonthName = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField        
        pMonthName.Name = "pMonthName";
        MonthName.Value = strMonthName;
        pMonthName.CurrentValues.Add(MonthName);

        //Adding Parameters to ParameterFields 
        pFields.Add(pMonthName);

        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;
    }

    protected void CRV_Unload(object sender, EventArgs e)
    {
        ReportDoc.Close();
        ReportDoc.Dispose();
        ReportDoc = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    protected void CRV_BeforeRender(object source, CrystalDecisions.Web.HtmlReportRender.BeforeRenderEvent e)
    {
        Page.ClientScript.RegisterForEventValidation(CRV.UniqueID);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.
    }
}
