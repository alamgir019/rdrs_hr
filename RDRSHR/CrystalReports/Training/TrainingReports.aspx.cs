using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrystalReports_Training_TrainingReports : System.Web.UI.Page
{
    MasterTablesManager objMasMgr = new MasterTablesManager();
    AttnPolicyTableManager AttPMgr = new AttnPolicyTableManager();
    LeaveManager objLeaveMgr = new LeaveManager();
    private Payroll_MasterMgr objPayMgr = new Payroll_MasterMgr();
    TrainingManager objEmpMgr = new TrainingManager();
    EmpInfoManager objEmp = new EmpInfoManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillDropDownList_All(objMasMgr.SelectTrainingName(0, "A"), ddlTrainingName);
            Common.FillDropDownList_All(objMasMgr.SelectLearningArea(0), ddlLearningArea);
            Common.FillDropDownList(objPayMgr.SelectFiscalYear(0, "FA"), ddlFiscalYr, "FISCALYRTITLE", "FISCALYRID", false);
            Common.FillDropDownList_All(objMasMgr.SelectDepartment(0), ddlProgDept);
            Common.FillDropDownList_All(objMasMgr.GetDivision(), ddlIntervention);
            //Common.FillDropDownList_All(objMasMgr.GetOfficety("0"), ddlSalLoc);
            //Common.FillDropDownList_All(objMasMgr.GetOfficeList("0"), ddlSalLoc);
            Common.FillDropDownList_All(objEmp.SelectEmpNameWithID("A"), ddlEmployeeName);

            ddlFiscalYr.SelectedIndex = 0;
            this.PanelVisibilityMst("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0","0");
        }
    }

    protected void ddlIntervention_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.SelectOfficeTypeList(Convert.ToDecimal(ddlIntervention.SelectedValue.Trim())), ddlOfficeType, "TypeName", "TypeID", true, "All");
    }

    protected void ddlOfficeType_SelectedIndexChanged(object sender, EventArgs e)
    {
       Common.FillDropDownList(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOfficeType.SelectedValue.Trim())), ddlOffice, "officetitle", "officeid", true);
    }

  

    protected void tvReports_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.PanelVisibilityMst("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
        switch (tvReports.SelectedValue)
        {
            case "TLR":
                {
                    PanelVisibilityMst("0", "0", "1", "1", "0", "1", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0");
                    break;
                }
            case "TLPALAW":
                {
                    PanelVisibilityMst("0", "0", "0", "1", "0", "1", "1", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0");
                    break;
                }
            case "MFPIT":
                {
                    PanelVisibilityMst("0", "0", "1", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "NTC":
                {
                    PanelVisibilityMst("1", "0", "1", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "OTR":
                {
                    PanelVisibilityMst("1", "0", "1", "1", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0", "0");
                    break;
                }
            case "1":
                {
                    PanelVisibilityMst("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "1", "0", "1", "0", "0", "0");
                    break;
                }
            case "2":
                {
                    PanelVisibilityMst("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "1", "0", "1", "0", "0", "0");
                    break;
                }
            case "GWP":
                {
                    PanelVisibilityMst("0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "MWTP":
                {
                    PanelVisibilityMst("0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "IDP":
                {
                    PanelVisibilityMst("1", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "LAWP":
                {
                    PanelVisibilityMst("0", "0", "1", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "TS":
                {
                    PanelVisibilityMst("1", "0", "1", "1", "0", "0", "1", "0", "0", "0", "0", "0", "0", "1", "1", "1", "0", "0", "0", "0");
                    break;
                }
            case "SWTI":
                {
                    PanelVisibilityMst("1", "0", "1", "1", "0", "0", "1", "0", "0", "0", "0", "0", "0", "1", "1", "1", "0", "0", "0", "0");
                    break;
                }
            case "SWP":
                {
                    PanelVisibilityMst("0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "QWP":
                {
                    PanelVisibilityMst("0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0");
                    break;
                }
            case "ETD":
                {
                    PanelVisibilityMst("0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0", "1");
                    break;
                }
            case "TSI":
                {
                    PanelVisibilityMst("0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0", "1");
                    break;
                }
            case "DTR":
                {
                    PanelVisibilityMst("0", "0", "0", "1", "0", "0", "1", "0", "0", "0", "0", "0", "1", "1", "0", "0", "0", "0", "0", "1");
                    break;
                }
            case "EER":
                {
                    PanelVisibilityMst("0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "1", "1");
                    break;
                }
        }
        this.PanelVisibilityDet();
    }

    protected void ddlReportBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.PanelVisibilityDet();
    }

    private void PanelVisibilityDet()
    {

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        switch (tvReports.SelectedValue)
        {
            case "TLR":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["EmpId"] = txtEmpCode.Text.Trim();
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["DeptId"] = ddlProgDept.SelectedValue.ToString();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["LAreaId"] = ddlLearningArea.SelectedValue.ToString();
                    break;
                }
            case "TLPALAW":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["DeptId"] = ddlProgDept.SelectedValue.ToString();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["LAreaId"] = ddlLearningArea.SelectedValue.ToString();
                    break;
                }

            case "MFPIT":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }
            case "NTC":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["EmpId"] = txtEmpCode.Text.Trim();
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }

            case "1":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FromDate"] = txtFromDate.Text;
                    Session["ToDate"] = txtToDate.Text;
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    Session["OTType"] = radBtnOTType.SelectedValue;
                    break;
                }
            case "2":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FromDate"] = txtFromDate.Text;
                    Session["ToDate"] = txtToDate.Text;
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    Session["OTType"] = radBtnOTType.SelectedValue;
                    break;
                }

            case "GWP":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }
            case "MWTP":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }

            case "IDP":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["EmpId"] = txtEmpCode.Text.Trim();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }

            case "LAWP":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["LAreaId"] = ddlLearningArea.SelectedValue.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }
            case "TS":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["EmpId"] = txtEmpCode.Text.Trim();
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["DeptId"] = ddlProgDept.SelectedValue.ToString();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["TrainingType"] = ddlTrainType.SelectedValue.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }
            case "SWTI":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["EmpId"] = txtEmpCode.Text.Trim();
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["DeptId"] = ddlProgDept.SelectedValue.ToString();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["TrainingType"] = ddlTrainType.SelectedValue.ToString();
                    Session["PHeader"] = ddlTrainType.SelectedItem.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;

                }
            case "SWP":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }
            case "QWP":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["FiscalYrId"] = ddlFiscalYr.SelectedValue.ToString();
                    Session["FiscalYr"] = ddlFiscalYr.SelectedItem.ToString();
                    Session["EmpStatus"] = radBtnListEmp.SelectedValue;
                    break;
                }
            case "ETD":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["Intervension"] = ddlIntervention.SelectedValue.ToString().Trim();
                    Session["OfficeId"] = ddlOffice.SelectedValue.ToString().Trim();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["FromDate"] = txtFromDate.Text.Trim();
                    Session["ToDate"] = txtToDate.Text.Trim();
                    break;
                }
            case "TSI":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["Intervension"] = ddlIntervention.SelectedValue.ToString().Trim();
                    Session["OfficeId"] = ddlOffice.SelectedValue.ToString().Trim();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString();
                    Session["FromDate"] = txtFromDate.Text.Trim();
                    Session["ToDate"] = txtToDate.Text.Trim();
                    break;
                }
            case "DTR":
                {
                    Session["REPORTID"] = tvReports.SelectedNode.Value;
                    Session["Intervension"] = ddlIntervention.SelectedValue.ToString().Trim();
                    Session["OfficeId"] = ddlOffice.SelectedValue.ToString().Trim();
                    Session["ProgDept"] = ddlProgDept.SelectedValue.ToString().Trim();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString().Trim();
                    Session["FromDate"] = txtFromDate.Text.Trim();
                    Session["ToDate"] = txtToDate.Text.Trim();
                    break;
                }
            case "EER":
                { 
                    Session["REPORTID"] = tvReports.SelectedNode.Value; 
                    Session["Intervension"] = ddlIntervention.SelectedValue.ToString().Trim();
                    Session["OfficeId"] = ddlOffice.SelectedValue.ToString().Trim();
                    Session["EmployeeName"] = ddlEmployeeName.SelectedValue.ToString().Trim();
                    Session["TrainingID"] = ddlTrainingName.SelectedValue.ToString().Trim();
                    break;
                }
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("<script>");
        sb.Append("window.open('frmTrainingReportViewer.aspx', '', 'fullscreen=true,scrollbars=yes,resizable=yes');");//
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmSubmit",
                                 sb.ToString(), false);
        ClientScript.RegisterStartupScript(this.GetType(), "ConfirmSubmit", sb.ToString());
    }

    private void PanelVisibilityMst(string sPEmp, string sPrbtnLArea, string sPFiscalYr, string sPTrainingName, string sPTraningState, string sPLearningArea,
        string sPProgramDept, string sPrbtnCost, string sPQuarter, string sPrbtnAcive, string sPMonth, string sPYear, string sPDateRange, string sPShow,
        string sPActveInAcBasic, string sPTraingType, string sPOTType, string sSalaryLocation, string sEmployeeName, string sPInterventionOffice)
    {
        if (sPEmp == "1")
            PEmp.Visible = true;
        else
            PEmp.Visible = false;

        if (sPrbtnLArea == "1")
            PrbtnLArea.Visible = true;
        else
            PrbtnLArea.Visible = false;

        if (sPFiscalYr == "1")

            PFiscalYr.Visible = true;
        else
            PFiscalYr.Visible = false;

        if (sPTrainingName == "1")
            PTrainingName.Visible = true;
        else
            PTrainingName.Visible = false;
        if (sPTraningState == "1")
            PTraningState.Visible = true;
        else
            PTraningState.Visible = false;

        if (sPLearningArea == "1")
            PLearningArea.Visible = true;
        else
            PLearningArea.Visible = false;

        if (sPProgramDept == "1")
            PProgramDept.Visible = true;
        else
            PProgramDept.Visible = false;

        if (sPrbtnCost == "1")
            PrbtnCost.Visible = true;
        else
            PrbtnCost.Visible = false;

        if (sPQuarter == "1")
            PQuarter.Visible = true;
        else
            PQuarter.Visible = false;

        if (sPrbtnAcive == "1")
            PrbtnAcive.Visible = true;
        else
            PrbtnAcive.Visible = false;

        if (sPMonth == "1")
            PMonth.Visible = true;
        else
            PMonth.Visible = false;

        if (sPDateRange == "1")
            PDateRange.Visible = true;
        else
            PDateRange.Visible = false;

        if (sPYear == "1")
            PYear.Visible = true;
        else
            PYear.Visible = false;

        if (sPShow == "1")
            PShow.Visible = true;
        else
            PShow.Visible = false;

        if (sPActveInAcBasic == "1")
            PActveInAcBasic.Visible = true;
        else
            PActveInAcBasic.Visible = false;

        if (sPTraingType == "1")
            PTraingType.Visible = true;
        else
            PTraingType.Visible = false;

        if (sPOTType == "1")
            pnlOTType.Visible = true;
        else
            pnlOTType.Visible = false;

        if (sSalaryLocation == "1")
            pSalaryLocation.Visible = true;
        else
            pSalaryLocation.Visible = false;

        if (sEmployeeName == "1")
            pEmployeeName.Visible = true;
        else
            pEmployeeName.Visible = false;

        if (sPInterventionOffice == "1")
        {
            pIntervention.Visible = true;
            pOfficeType.Visible = true;
            pOffice.Visible = true;
        }
        else
        {
            pIntervention.Visible = false;
            pOfficeType.Visible = false;
            pOffice.Visible = false;
        }
    }

    protected void Bind_ddlFiscalYr()
    {
        Common.FillDropDownList(objPayMgr.SelectFiscalYear(0), ddlFiscalYr, true);
    }

    protected void Bind_ddlProgDept()
    {
        Common.FillDropDownList_All(objMasMgr.SelectDepartment(0), ddlProgDept);
    }
    protected void Bind_ddlLearningArea()
    {
        Common.FillDropDownList_All(objMasMgr.SelectLearningArea(0), ddlLearningArea);
    }

    protected void Bind_ddlTrainingName()
    {
        Common.FillDropDownList_All(objMasMgr.SelectTrainingName(0, "A"), ddlTrainingName);
    }
}