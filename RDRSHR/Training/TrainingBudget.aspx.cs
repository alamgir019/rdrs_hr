using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Training_TrainingBudget : System.Web.UI.Page
{
    TrainingManager objTrMgr = new TrainingManager();
    MasterTablesManager objTblmast = new MasterTablesManager();
    EmpInfoManager objEmp = new EmpInfoManager();
    SOFManager objSOFMgr = new SOFManager();
    DataTable personTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpdate.Value = "N";
            grList.DataSource = null;
            grList.DataBind();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            this.OpenRecord();

            Common.FillDropDownList_Nil(objTrMgr.SelectTrainingList("0"), ddlTrainingName);
        }
    }
    protected void EntryMode(bool IsUpdate)
    {
        if (IsUpdate == true)
        {
            btnSave.Text = "Update";
            hfIsUpdate.Value = "Y";
        }
        else
        {
            btnSave.Text = "Save";
            hfIsUpdate.Value = "N";
        }
    }
    private void OpenRecord()
    {
        grList.DataSource = null;
        grList.DataBind();
        grCostHead.DataSource = null;
        grCostHead.DataBind();
        grList.DataSource = objTrMgr.SelectTrainingBudgetList("A");
        grList.DataBind();
        grCostHead.DataSource = objTrMgr.SelectCostHeadList("0","Y");
        grCostHead.DataBind();
        this.CalculateCostTotal();
        
    }

    public void CalculateCostTotal()
    {
        decimal decTotal = 0;
        foreach (GridViewRow gRow in grCostHead.Rows)
        {
            TextBox txtHC = (TextBox)gRow.FindControl("txtHeadAmt");
            decTotal = decTotal + Common.RoundDecimal(txtHC.Text.Trim(), 0);
        }
        grCostHead.FooterRow.Cells[0].Text = "Total ";
        grCostHead.FooterRow.Cells[1].Text = decTotal.ToString();
    }

    protected void txtHeadAmt_TextChanged(object sender, EventArgs e)
    {
        this.CalculateCostTotal();
    }

    private void ClearControl(string strFlag)
    {
        switch (strFlag)
        {
            case "ddlSchedule":
                {
                    txtStrDate.Text = "";
                    txtEndDate.Text = "";
                    txtDuration.Text = "";
                    txtNoOfPerson.Text = "";
                    txtFundedBy.Text = "";
                    txtCourseCoordinator.Text = "";
                    txtResidential.Text = "";
                }
                break;
        }
    }
    private bool ValidateAndSave(string Flag)
    {
        try
        {
            lblMsg.Text = "";
            switch (Flag)
            {
                case "Save":
                    if (ddlTrainingName.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please select Training Name.";
                        return false;
                    }
                    break;
            }
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SaveData(string cmdType)
    {
        dsTraining objDS = new dsTraining();
        if (cmdType == "I")
        {
            hfId.Value = Common.getMaxId("TrTrainingBudget", "BudgetId");
        }

        List<DataTable> dtList = new List<DataTable>();
        DataTable dtMst = objDS.Tables["TrTrainingBudget"];
        DataRow nRow = dtMst.NewRow();

        nRow["BudgetId"] = Common.RoundDecimal(hfId.Value, 0);
        nRow["ScheduleID"] = Common.RoundDecimal(ddlSchedule.SelectedValue.ToString().Trim(), 0);
        nRow["TrainId"] = Common.RoundDecimal(ddlTrainingName.SelectedValue.ToString().Trim(), 0);
        nRow["FeePerPerson"] = Common.RoundDecimal(txtFeePP.Text.Trim(), 0);
        nRow["IncomePerPerson"] = Common.RoundDecimal(txtIncomePP.Text.Trim(), 0);

        // nRow["ResidencialCost"] = Common.RoundDecimal(txtResiCost.Text.Trim(),0);
        nRow["OtherIncome"] = Common.RoundDecimal(txtOtherIncome.Text.Trim(), 0);

        if (cmdType == "I")
        {
            nRow["InsertedBy"] = Session["USERID"].ToString().Trim();
            nRow["InsertedDate"] = DateTime.Now;
        }
        else if (cmdType == "U")
        {
            nRow["UpdatedBy"] = Session["USERID"].ToString().Trim();
            nRow["UpdatedDate"] = DateTime.Now;
        }
        nRow["IsDeleted"] = cmdType == "D" ? "Y" : "N";
        nRow["IsActive"] = chkInActive.Checked == true ? "N" : "Y";
        nRow["CostPerPerson"] = Common.RoundDecimal(grCostHead.FooterRow.Cells[1].Text.Trim(), 0);

        dtMst.Rows.Add(nRow);
        dtMst.AcceptChanges();
        dtList.Add(dtMst);

        // DETAILS RECORD
        DataTable dtDet = objDS.Tables["TrTrainingBudgetDetls"];
        foreach (GridViewRow gRow in grCostHead.Rows)
        {
            TextBox txtHC = (TextBox)gRow.FindControl("txtHeadAmt");
            DataRow dRow = dtDet.NewRow();
            dRow["HeadID"] = Common.RoundDecimal(grCostHead.DataKeys[gRow.RowIndex].Values[0].ToString(), 0);
            dRow["BudgetId"] = Common.RoundDecimal(hfId.Value, 0);
            dRow["HeadAmt"] = Common.RoundDecimal(txtHC.Text.Trim(), 0);
            dtDet.Rows.Add(dRow);
        }

        dtDet.AcceptChanges();
        dtList.Add(dtDet);
        try
        {
            objTrMgr.SaveMultiTableData(dtList, cmdType == "D" ? "U" : cmdType);
            lblMsg.Text = Common.GetMessage(cmdType);
            Common.EmptyTextBoxValues(this);
            ddlSchedule.Items.Clear();
            this.EntryMode(false);
            this.OpenRecord();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }
    protected void grList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            //BudgetId,TrainId,TrainName,ScheduleID,StrDate,EndDate,Duration,NoofPerson,CoordinatorName, FundedBy, Residential,FeePerPerson,
            //IncomePerPerson,ResidencialCost,OtherIncome,IsActive
            case ("DoubleClick"):
                {
                    hfId.Value = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                    ddlTrainingName.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
                    if (Common.CheckNullString(grList.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim()) != "")
                    {
                        Common.FillDropDownList(objTrMgr.SelectScheduleList(grList.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim()), ddlSchedule, "ScheDate", "ScheduleID", true);

                    }
                    ddlSchedule.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim();
                    txtStrDate.Text = grList.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim();
                    txtEndDate.Text = grList.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim();
                    txtDuration.Text = grList.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim();
                    txtNoOfPerson.Text = grList.DataKeys[_gridView.SelectedIndex].Values[7].ToString().Trim();
                    txtCourseCoordinator.Text = grList.DataKeys[_gridView.SelectedIndex].Values[8].ToString().Trim();
                    txtFundedBy.Text = grList.DataKeys[_gridView.SelectedIndex].Values[9].ToString().Trim();
                    txtResidential.Text = grList.DataKeys[_gridView.SelectedIndex].Values[10].ToString().Trim();
                    txtFeePP.Text = grList.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim();
                    txtIncomePP.Text = grList.DataKeys[_gridView.SelectedIndex].Values[12].ToString().Trim();
                    //txtResiCost.Text = grList.DataKeys[_gridView.SelectedIndex].Values[12].ToString().Trim();
                    txtOtherIncome.Text = grList.DataKeys[_gridView.SelectedIndex].Values[13].ToString().Trim();

                    if (grList.DataKeys[_gridView.SelectedIndex].Values[14].ToString().Trim() == "N")
                        chkInActive.Checked = true;
                    else
                        chkInActive.Checked = false;

                    grCostHead.DataSource = null;
                    grCostHead.DataBind();

                    grCostHead.DataSource = objTrMgr.SelectTrainingBudgetDetList(hfId.Value.Trim());
                    grCostHead.DataBind();
                    this.CalculateCostTotal();
                    this.EntryMode(true);
                    lblMsg.Text = "";
                }
                break;
        }
    }
   
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave("Save") == false)
        {
            return;
        }

        if (hfIsUpdate.Value == "N")
        {
            this.SaveData("I");
        }
        else
        {
            this.SaveData("U");
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        this.OpenRecord();
        lblMsg.Text = "";
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfId.Value) == false)
        {
            this.SaveData("D");
        }
        else
        {
            lblMsg.Text = "Select a item first from the list then try to delete.";
        }

        this.EntryMode(false);
    }
    protected void ddlTrainingName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTrainingName.SelectedIndex <= 0)
            return;
        if (Common.CheckNullString(ddlTrainingName.SelectedValue.ToString().Trim()) != "")
        {
            Common.FillDropDownList(objTrMgr.SelectScheduleList(ddlTrainingName.SelectedValue.ToString().Trim()), ddlSchedule, "ScheDate", "ScheduleID", true);

        }
    }
    protected void ddlSchedule_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ClearControl("ddlSchedule");
        if (ddlSchedule.SelectedIndex <= 0)
            return;
        if (Common.CheckNullString(ddlSchedule.SelectedValue.ToString().Trim()) != "")
        {
            DataTable dt = objTrMgr.SelectTrainingScheduleInfo(ddlSchedule.SelectedValue.ToString().Trim());
            if (dt.Rows.Count > 0)
            {
                txtStrDate.Text = dt.Rows[0]["StrDate"].ToString().Trim();
                txtEndDate.Text = dt.Rows[0]["EndDate"].ToString().Trim();
                txtDuration.Text = Math.Round(Convert.ToDecimal(Common.ReturnZeroForNull(dt.Rows[0]["Duration"].ToString().Trim()))).ToString();
                txtNoOfPerson.Text = Math.Round(Convert.ToDecimal(Common.ReturnZeroForNull(dt.Rows[0]["NoofPerson"].ToString().Trim()))).ToString();
                txtFundedBy.Text = dt.Rows[0]["ProjectName"].ToString().Trim();
                txtCourseCoordinator.Text = dt.Rows[0]["CoordinatorFName"].ToString().Trim();
                txtResidential.Text = dt.Rows[0]["Residential"].ToString().Trim();
            }
        }
    }



}