﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Training_TrainingPlan : System.Web.UI.Page
{
    TrainingManager objTrMgr = new TrainingManager();
    MasterTablesManager objTblmast = new MasterTablesManager();
    EmpInfoManager objEmp = new EmpInfoManager();
    SOFManager objSOFMgr = new SOFManager();

    DataTable personTable=new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpdate.Value = "N";
           // dtList.Rows.Clear();
            //dtList.Dispose();
            grList.DataSource = null;
            grList.DataBind();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            this.OpenRecord();
            this.CreateTable();
            DataTable dtEmp = objEmp.SelectEmpNameWithID("A");
            Common.FillDropDownList_Nil(objTrMgr.SelectTrainingList("0"), ddlTrainingName);
            Common.FillDropDownList(dtEmp, ddlCourseCoordinator, "EmpName", "EmpID", false);
            Common.FillDropDownList_Nil(dtEmp, ddlRespectiveResource);
            Common.FillDropDownList(objTrMgr.SelectTrainingVenue("0"), ddlVenue, "VenueName", "VenueId", false);
            Common.FillDropDownList(objEmp.GetEmpDesignation("A"), ddlParticipantLevel, "DesigName", "DesigId", false);         
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
    private void CreateTable()
    {
        personTable = new DataTable();
        personTable.Columns.AddRange(new DataColumn[2] 
                            { 
                              new DataColumn("RespectiveResourceId", typeof(string)),
                              new DataColumn("RespectiveResourceName", typeof(string))
                                                           
                            });
        ViewState["dt"] = personTable;
    }
    private void OpenRecord()
    {
        //    dtList = objEmpMgr.SelectTraining();
        this.CreateTable();
        grList.DataSource = null;
        grList.DataBind();

        grTrainingPlan.DataSource = null;
        grTrainingPlan.DataBind();
        grTrainingPlan.DataSource=objTrMgr.SelectTrainingPlanList("A");
        grTrainingPlan.DataBind();
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
                    //else if (ddlParticipantLevel.SelectedIndex<= 0)
                    //{
                    //    lblMsg.Text = "Please Select Participant Level.";
                    //    return false;
                    //}
                    //else if (ddlCourseCoordinator.SelectedIndex <= 0)
                    //{
                    //    lblMsg.Text = "Please Select Course Coordinator.";
                    //    return false;
                    //}
                    else if (grList.Rows.Count == 0)
                    {
                        lblMsg.Text = "Please add Respective Resource.";
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
            hfId.Value = Common.getMaxId("TrTrainingPlan", "TrainingPlanId");
        }

        List<DataTable> tblList = new List<DataTable>();

        DataTable dtMst = objDS.Tables["TrTrainingPlan"];
        DataRow nRow = dtMst.NewRow();

        nRow["TrainingPlanId"] = Common.RoundDecimal(hfId.Value, 0);
        nRow["TrainId"] = Common.RoundDecimal(ddlTrainingName.SelectedValue.ToString().Trim(), 0);
        nRow["TentativeDate"] = Common.ReturnDate(txtTentativeDate.Text.Trim());
        nRow["ParticipantLevel"] = Common.RoundDecimal(ddlParticipantLevel.SelectedValue.ToString().Trim(),0);
        nRow["VenueId"] = Common.RoundDecimal(ddlVenue.SelectedValue.ToString().Trim(),0);


        nRow["NoofParticipant"] = txtNoofParticipant.Text.Trim();
        nRow["ParticipantMatrix"] = txtParticipantMatrix.Text.Trim();
        nRow["Remarks"] = txtRemarks.Text.Trim();
        nRow["CourseCoordinator"] = ddlCourseCoordinator.SelectedValue.ToString().Trim();
       

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

        dtMst.Rows.Add(nRow);
        dtMst.AcceptChanges();

        tblList.Add(dtMst);

        //detail table
        DataTable dtDtl = objDS.Tables["TrTrainingPlanDtls"];

        DataTable dtDtlInput = ViewState["dt"] as DataTable;
        int DtlId = Int32.Parse(Common.getMaxId("TrTrainingPlanDtls", "TrainingPlanDtlId"));
        // //TraineeId,TraineeName,Designation,Dept,IsResidential,Fundedby
        foreach (DataRow row in dtDtlInput.Rows)
        {
            DataRow nRowdtl = dtDtl.NewRow();
            nRowdtl["TrainingPlanDtlId"] = DtlId;
            nRowdtl["TrainingPlanId"] = Common.RoundDecimal(hfId.Value, 0);
            nRowdtl["RespectiveResource"] = row["RespectiveResourceId"].ToString().Trim();
           
            nRowdtl["InsertedBy"] = Session["USERID"].ToString().Trim();
            nRowdtl["InsertedDate"] = DateTime.Now;

            DtlId++;
            dtDtl.Rows.Add(nRowdtl);
        }

        dtDtl.AcceptChanges();
        tblList.Add(dtDtl);

        try
        {
            objTrMgr.SaveMultiTableData(tblList, cmdType == "D" ? "U" : cmdType);
            lblMsg.Text = Common.GetMessage(cmdType);
            Common.EmptyTextBoxValues(this);
            this.EntryMode(false);
            this.OpenRecord();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
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
    protected void grTrainingPlan_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    // TrainingPlanId,TrainId,TrainName,TentativeDate,ParticipantLevel,DesigName,VenueId,VenueName,NoofParticipant,ParticipantMatrix,Remarks,CourseCoordinator,EmpName,IsActive
                    Common.EmptyTextBoxValues(this);
                    hfId.Value = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                    ddlTrainingName.SelectedValue = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
                    
                    txtTentativeDate.Text = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim();
                   ddlParticipantLevel.SelectedValue = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim();
                   ddlVenue.SelectedValue = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim();

                    txtNoofParticipant.Text= grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[8].ToString().Trim();
                    txtParticipantMatrix.Text = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[9].ToString().Trim();
                    txtRemarks.Text = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[10].ToString().Trim();
                    ddlCourseCoordinator.SelectedValue = grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim();

                    
                    if (grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[13].ToString().Trim() == "N")
                        chkInActive.Checked = true;
                    else
                        chkInActive.Checked = false;

                    grList.DataSource = null;
                    grList.DataBind();
                    this.CreateTable();
                    personTable = objTrMgr.SelectTrainingPlanDtlsList(grTrainingPlan.DataKeys[_gridView.SelectedIndex].Values[0].ToString());
                    grList.DataSource = personTable;
                    grList.DataBind();
                    ViewState["dt"] = personTable;
                    this.EntryMode(true);
                    lblMsg.Text = "";
                }
                break;
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
            case ("DoubleClick"):
                {
                    personTable = ViewState["dt"] as DataTable;     
                    ddlRespectiveResource.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();

                    DataRow[] drr = personTable.Select("RespectiveResourceId='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim() + "'");
                    for (int i = 0; i < drr.Length; i++)
                    {
                        drr[i].Delete();
                    }
                    personTable.AcceptChanges();
                    ViewState["dt"] = personTable;
                }
                break;

            case ("Delete"):
               
                {
                    personTable = ViewState["dt"] as DataTable;
                    DataRow[] drr = personTable.Select("RespectiveResourceId='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim() + "'");
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
                break;
        }
    }
    protected void grList_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = ViewState["dt"] as DataTable;
        DataRow[] drr = dt.Select("RespectiveResourceId='" + ddlRespectiveResource.SelectedValue.ToString().Trim() + "'");
        for (int i = 0; i < drr.Length; i++)
        {
            drr[i].Delete();
        }
        dt.AcceptChanges();
        dt.Rows.Add(ddlRespectiveResource.SelectedValue.ToString().Trim(), ddlRespectiveResource.SelectedItem.ToString().Trim());
        grList.DataSource = dt;
        grList.DataBind();
    }
}
