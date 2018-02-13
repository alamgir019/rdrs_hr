using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Training_TrainingRequisition : System.Web.UI.Page
{
    TrainingManager objEmpMgr = new TrainingManager();
    MasterTablesManager objTblmast = new MasterTablesManager();
    EmpInfoManager objEmp = new EmpInfoManager();
    SOFManager objSOFMgr = new SOFManager();
    DataTable dtList = new DataTable();

    DataTable personTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpdate.Value = "N";
            dtList.Rows.Clear();
            dtList.Dispose();
            grList.DataSource = null;
            grList.DataBind();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            this.OpenRecord();

            DataTable dtEmp = objEmp.SelectEmpNameWithID("A");
            Common.FillDropDownList(dtEmp, ddlTraineeName, "EmpName", "EmpID", false);
            Common.FillDropDownList(objEmpMgr.SelectScheduleList("A"), ddlSchedule, "ScheDate", "ScheduleID", true);

            Common.FillDropDownList(dtEmp, ddlSigenBy1, "EmpName", "EmpID", false);
            Common.FillDropDownList(dtEmp, ddlSigenBy2, "EmpName", "EmpID", false);
            Common.FillDropDownList(dtEmp, ddlApproveBy, "EmpName", "EmpID", false);
            Common.FillDropDownList(dtEmp, ddlRecomandedBy, "EmpName", "EmpID", false);
            Common.FillDropDownList(dtEmp, ddlReviewBy, "EmpName", "EmpID", false);
            Common.FillDropDownList(dtEmp, ddlSeenBy, "EmpName", "EmpID", false);
          
            this.CreateTable();
        }

    }
    protected void CreateTable()
    {
        personTable = new DataTable();
        personTable.Columns.AddRange(new DataColumn[5] 
                            { 
                              new DataColumn("EmpID", typeof(string)),
                              new DataColumn("EmpName", typeof(string)),
                               new DataColumn("ProjectId", typeof(string)),
                              new DataColumn("ProjectName", typeof(string)),
                              new DataColumn("FundType", typeof(string))
                            });
        ViewState["dt"] = personTable;
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
        //dtList = objEmpMgr.SelectTraining();
        grList.DataSource = null;
        grList.DataBind();
        grRequisition.DataSource=objEmpMgr.SelectTrainingRequisitionList();
        grRequisition.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        try
        {
            if (hfIsUpdate.Value == "Y")
                hfId.Value = hfId.Value;
            else
                hfId.Value = Common.getMaxId("TrRequisition", "ReqID");

            clsTrRequisition objTrReq = new clsTrRequisition(
                hfId.Value.ToString(),
                ddlSchedule.SelectedValue.ToString(),
                hfTrainingId.Value,
                this.ddlSigenBy1.SelectedValue.ToString().Trim(),
                this.ddlSigenBy2.SelectedValue.ToString().Trim(),
                this.ddlSeenBy.SelectedValue.ToString().Trim(),
                this.ddlReviewBy.SelectedValue.ToString().Trim(),
                this.ddlRecomandedBy.SelectedValue.ToString().Trim(),
               this.ddlApproveBy.SelectedValue.ToString().Trim(),
                (chkInActive.Checked == true ? "N" : "Y")
                );

            objEmpMgr.InsertTrRequisition(grList, objTrReq, Session["USERID"].ToString().Trim(), Common.SetDateTime(DateTime.Now.ToString()), hfIsUpdate.Value, IsDelete);

            lblMsg.Text = Common.GetMessage(hfIsUpdate.Value.ToString(), IsDelete);
            Common.EmptyTextBoxValues(this);
            this.EntryMode(false);
            this.OpenRecord();
            this.CreateTable();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error : "+ ex;
            throw (ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave("Save") == false)
        {
            return;
        }
        this.SaveData("N");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        this.OpenRecord();
        this.CreateTable();
        lblMsg.Text = "";
    }
    protected void ddlSchedule_SelectedIndexChanged(object sender, EventArgs e) 
    {
        hfTrainingId.Value = "";
        txtTrainingName.Text = "";
        txtTrainingLocation.Text = "";
        if (Common.CheckNullString(ddlSchedule.SelectedIndex.ToString()) != "")
        {
            DataTable dt= objEmpMgr.SelectTrainingNameLocUsingSchedule(ddlSchedule.SelectedValue.ToString());
            if (dt.Rows.Count>0)
            {
                hfTrainingId.Value = dt.Rows[0]["TrainId"].ToString().Trim();
                txtTrainingName.Text = dt.Rows[0]["TrainName"].ToString().Trim();
                txtTrainingLocation.Text = dt.Rows[0]["TrainLocation"].ToString().Trim();
            }
        }        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfId.Value) == false)
        {
            this.SaveData("Y");
        }
        else
        {
            lblMsg.Text = "Select a item first from the list then try to delete.";
        }

        this.EntryMode(false);
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
            case ("DoubleClick"):
                {
                    personTable = ViewState["dt"] as DataTable;
                    ddlProject.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim();// Common.CheckNullString(grList.SelectedRow.Cells[1].Text.Trim());
                    ddlTraineeName.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();

                    if (grList.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim() == "P")
                    {
                        ddlFundType.SelectedValue = "P";
                        Common.FillDropDownList(objSOFMgr.SelectProjectList(0), ddlProject, "ProjectName", "ProjectId", false);
                        ddlProjectDonar.Items.Clear();
                        if (ddlProject.Items.Count > 0)
                        {
                            ListItem item = ddlProject.Items.FindByValue(grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString());
                            if (item != null)
                                ddlProject.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                        }
                    }
                    else if (grList.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim() == "D")
                    {
                        ddlFundType.SelectedValue = "D";
                        Common.FillDropDownList(objSOFMgr.SelectDonerList(0), ddlProjectDonar, "DonerName", "DonerId", false);
                        ddlProject.Items.Clear();
                        if (ddlProjectDonar.Items.Count > 0)
                        {
                            ListItem item = ddlProjectDonar.Items.FindByValue(grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString());
                            if (item != null)
                                ddlProjectDonar.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                        }
                    }

                    DataRow[] drr = personTable.Select("EmpID='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim() + "'");
                    for (int i = 0; i < drr.Length; i++)
                    {
                        drr[i].Delete();
                    }
                    personTable.AcceptChanges();
                    ViewState["dt"] = personTable;
                }
                break;

              case ("Delete"):               
                try
                {
                    personTable = ViewState["dt"] as DataTable;
                    DataRow[] drr = personTable.Select("EmpID='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim() + "'");
                    for (int i = 0; i < drr.Length; i++)
                    {
                        drr[i].Delete();
                    }
                    personTable.AcceptChanges();
                
                    grList.DataSource = null;
                    grList.DataBind();

                    grList.DataSource = personTable;
                    grList.DataBind();
                    
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error : " + ex;
                    throw (ex);
                }
                break;
        }
    }
    protected void grRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        lblMsg.Text = "";
        switch (_commandName)
        {
            case ("DoubleClick"):
                try
                {
                    Common.EmptyTextBoxValues(this);
                    hfId.Value = grRequisition.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                     ddlSchedule.SelectedValue = grRequisition.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
                    hfTrainingId.Value = grRequisition.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim();
                    txtTrainingName.Text = grRequisition.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim();
                    txtTrainingLocation.Text = grRequisition.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim();
                    ddlSigenBy1.SelectedValue=grRequisition.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim();
                    ddlSigenBy2.SelectedValue = grRequisition.DataKeys[_gridView.SelectedIndex].Values[7].ToString().Trim();
                    ddlSeenBy.SelectedValue= grRequisition.DataKeys[_gridView.SelectedIndex].Values[8].ToString().Trim();
                    ddlReviewBy.SelectedValue = grRequisition.DataKeys[_gridView.SelectedIndex].Values[9].ToString().Trim();
                    ddlRecomandedBy.SelectedValue= grRequisition.DataKeys[_gridView.SelectedIndex].Values[10].ToString().Trim();
                    ddlApproveBy.SelectedValue = grRequisition.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim();
                    
                
                    if (grRequisition.DataKeys[_gridView.SelectedIndex].Values[12].ToString().Trim() == "Y")
                        chkInActive.Checked = false;
                    else
                        chkInActive.Checked = true;

                    grList.DataSource = null;
                    grList.DataBind();

                    this.CreateTable();
                    personTable = objEmpMgr.SelectTrainingReqDtlsList(grRequisition.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim());
                    if (personTable.Rows.Count > 0)
                    {
                        grList.DataSource = personTable;
                        grList.DataBind();
                    }
                    ViewState["dt"] = personTable;
                    this.EntryMode(true);

                    ddlProject.Items.Clear();
                    ddlProjectDonar.Items.Clear();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "";
                    throw (ex);
                }
                break;
        }
    }
    protected void grList_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {

    }
    private DataTable deleteGridRow(string row) 
    {
        personTable = ViewState["dt"] as DataTable;
        DataRow[] drr = personTable.Select(row);
        for (int i = 0; i < drr.Length; i++)
        {
            drr[i].Delete();
        }
        personTable.AcceptChanges();
        return personTable;
    }
    private bool ValidateAndSave(string Flag)
    {
        try
        {
            lblMsg.Text = "";
            switch (Flag)
            {
                case "Save":
                    if (ddlSchedule.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please select Training Schedule";
                        return false;
                    }
                    else if (grList.Rows.Count == 0)
                    {
                        lblMsg.Text = "Please add Employee";
                        return false;
                    }
                    break;
                case "Add":
                    if (ddlSchedule.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please Select Training Schedule";
                        return false;
                    }
                    else if (ddlFundType.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please Select Fund Type";
                        return false;
                    }                    
                    break;
            }
            return true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave("Add") == false)
        {
            return;
        }
        DataTable dt = ViewState["dt"] as DataTable;
        DataRow[] drr = dt.Select("EmpID='" + ddlTraineeName.SelectedValue.ToString().Trim() + "'");
        for (int i = 0; i < drr.Length; i++)
        {
            drr[i].Delete();
        }
        dt.AcceptChanges();
        if (ddlFundType.SelectedValue.ToString().Trim() == "P")
            dt.Rows.Add(ddlTraineeName.SelectedValue.ToString().Trim(), ddlTraineeName.SelectedItem.Text.ToString().Trim(), ddlProject.SelectedValue.ToString().Trim(), ddlProject.SelectedItem.ToString().Trim(), ddlFundType.SelectedValue.ToString().Trim());
        else if (ddlFundType.SelectedValue.ToString().Trim() == "D")
            dt.Rows.Add(ddlTraineeName.SelectedValue.ToString().Trim(), ddlTraineeName.SelectedItem.Text.ToString().Trim(), ddlProjectDonar.SelectedValue.ToString().Trim(), ddlProjectDonar.SelectedItem.ToString().Trim(), ddlFundType.SelectedValue.ToString().Trim());
       
        grList.DataSource = dt;
        grList.DataBind();
    }
    protected void ddlFundType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFundType.SelectedValue.ToString().Trim() == "P")
        {
            Common.FillDropDownList(objSOFMgr.SelectProjectList(0), ddlProject, "ProjectName", "ProjectId", false);
            ddlProjectDonar.Items.Clear();
        }
        else if (ddlFundType.SelectedValue.ToString().Trim() == "D")
        {
            Common.FillDropDownList(objSOFMgr.SelectDonerList(0), ddlProjectDonar, "DonerName", "DonerId", false);
            ddlProject.Items.Clear();
        }
        else
        {
            ddlProject.Items.Clear();
            ddlProjectDonar.Items.Clear();
        }

    }
}
