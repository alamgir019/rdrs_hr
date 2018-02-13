using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Training_TrainingScheduleDtl : System.Web.UI.Page
{
    TrainingManager objEmpMgr = new TrainingManager();
    MasterTablesManager objTblmast = new MasterTablesManager();
    SOFManager objSOFMgr = new SOFManager();
    EmpInfoManager objEmp = new EmpInfoManager();
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

            Common.FillDropDownList_Nil(objEmpMgr.SelectTrainingList("0"), ddlTrName);
            Common.FillDropDownList_Nil(objEmpMgr.SelectLocation("0"), ddlLocation);
            Common.FillDropDownList(objEmp.SelectEmpNameWithID("A"), ddlCourseCordinator, "EmpName", "EmpID", false);
            Common.FillDropDownList(objEmpMgr.SelectTrainingTrainerList("A"), ddlTrainer, "TrainerName", "TrainnerId", false);

            rblTrainerType.SelectedIndex = 0;

            this.CreateTable();
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
    protected void CreateTable()
    {
        personTable = new DataTable();
        personTable.Columns.AddRange(new DataColumn[4] 
                            { 
                              new DataColumn("TrainnerId", typeof(string)),
                              new DataColumn("TrainerName", typeof(string)),
                              new DataColumn("TrainerType", typeof(string)),
                              new DataColumn("TrainerTypeDtl", typeof(string))
                              
                            });
        ViewState["dt"] = personTable;
    }
    private void OpenRecord()
    {
        dtList = objEmpMgr.SelectScheduleList("A");
        grScheduleList.DataSource = dtList;
        grScheduleList.DataBind();

        grList.DataSource = null;
        grList.DataBind();
        this.CreateTable();
    }
    private Boolean getDateDiff(string strDate, string endDate)
    {
        double TotDay = 0;
        char[] splitter = { '/' };
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();
        lblMsg.Text = "";
        string[] arinfo = Common.str_split(strDate.Trim(), splitter);

        if (arinfo.Length == 3)
        {
            dtFrom = Convert.ToDateTime(arinfo[2] + "/" + arinfo[1] + "/" + arinfo[0]);
            arinfo = null;
        }
        arinfo = Common.str_split(endDate.Trim(), splitter);
        if (arinfo.Length == 3)
        {
            dtTo = Convert.ToDateTime(arinfo[2] + "/" + arinfo[1] + "/" + arinfo[0]);
            arinfo = null;
        }

        TimeSpan Dur = dtTo.Subtract(dtFrom);

        TotDay =Math.Round(Convert.ToDouble(Dur.Days), 0) + 1;
        if (TotDay < 0)
        {
            lblMsg.Text = "Start Date can not be greater than end date";
            txtDuration.Text = "";
            return false;
        }
        else
        {
            txtDuration.Text = TotDay.ToString();
            return true;
        }
    }
    private bool ValidateAndSave(string Flag)
    {
        try
        {
            double TotDay = 0;
            DateTime dtFrom = new DateTime();
            DateTime dtTo = new DateTime();
            lblMsg.Text = "";
            switch (Flag)
            {
                case "Save":
                    if (ddlTrName.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please Select Training Name";
                        return false;
                    }
                    else if (ddlLocation.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please Select Training Location";
                        return false;
                    }
                    else if (string.IsNullOrEmpty(txtStrDate.Text) == false && string.IsNullOrEmpty(txtEndDate.Text) == false)
                    {
                        txtDuration.Text = "";
                        char[] splitter = { '/' };
                        string[] arinfo = Common.str_split(txtStrDate.Text.Trim(), splitter);
                        if (arinfo.Length == 3)
                        {
                            dtFrom = Convert.ToDateTime(arinfo[2] + "/" + arinfo[1] + "/" + arinfo[0]);
                            arinfo = null;
                        }
                        arinfo = Common.str_split(txtEndDate.Text.Trim(), splitter);
                        if (arinfo.Length == 3)
                        {
                            dtTo = Convert.ToDateTime(arinfo[2] + "/" + arinfo[1] + "/" + arinfo[0]);
                            arinfo = null;
                        }

                        TimeSpan Dur = dtTo.Subtract(dtFrom);

                        TotDay = Math.Round(Convert.ToDouble(Dur.Days), 0)+1;
                        if (TotDay < 0)
                        {
                            lblMsg.Text = "Start Date can not be greater than end date";
                            return false;
                        }
                        else
                        {
                            txtDuration.Text = TotDay.ToString();
                           // return true;
                        }
                    }
                  if (ddlFundType.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please Select Fund Type";
                        return false;
                    }
                  if (grList.Rows.Count == 0)
                    {
                        lblMsg.Text = "Please add Trainer";
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
    private void SaveData(string IsDelete)
    {
        try
        {
            if (hfIsUpdate.Value == "Y")
                hfId.Value = hfId.Value;
            else
                hfId.Value = Common.getMaxId("TrSchedule", "ScheduleID");

            clsTrSchedule objtrSchedul = new clsTrSchedule(
                         hfId.Value.ToString(),
	                     this.ddlTrName.SelectedValue.ToString(),
	                     this.ddlLocation.SelectedValue.ToString(),
                         this.txtStrDate.Text.Trim().ToString(),
                         this.txtEndDate.Text.Trim().ToString(),
                         this.txtDuration.Text.Trim().ToString(),
                         this.txtNoOfPerson.Text.ToString(),
	                     this.ddlCourseCordinator.SelectedValue.ToString(),
                         this.ddlFundType.SelectedValue.ToString().Trim(),
                         this.ddlProject.SelectedValue.ToString(),
                         this.ddlProjectDonar.SelectedValue.ToString().Trim(),
                         this.ddlResidential.SelectedItem.ToString().Trim(),
	                     //this.ddlResidential.SelectedItem.ToString().Trim().Substring(0,1),
                         ""           
            );

            objEmpMgr.TrainingSchedule(grList,objtrSchedul, (chkInActive.Checked == true ? "N" : "Y"), Session["USERID"].ToString(), DateTime.Now.ToString(), hfIsUpdate.Value, IsDelete);


            lblMsg.Text = Common.GetMessage(hfIsUpdate.Value.ToString(), IsDelete);
            Common.EmptyTextBoxValues(this);
            this.EntryMode(false);
            this.OpenRecord();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
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
    protected void txtDuration_onclick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtStrDate.Text.ToString().Trim()) ==false)
        {
            lblMsg.Text="Start Date is Empty";
            txtDuration.Text="";
            return;
        }
        else if (string.IsNullOrEmpty(txtEndDate.Text.ToString().Trim()) ==false)
        {
            lblMsg.Text="End Date is Empty";
            txtDuration.Text="";
            return;
        }
            if (this.getDateDiff(txtStrDate.Text.ToString().Trim(), txtEndDate.Text.ToString().Trim()) == false) 
            {
                txtStrDate.Focus();
            }
    }
    protected void txtEndDate_OnTextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtStrDate.Text.ToString().Trim()) == false && string.IsNullOrEmpty(txtEndDate.Text.ToString().Trim()) == false)
        {
            if (this.getDateDiff(txtStrDate.Text.ToString().Trim(), txtEndDate.Text.ToString().Trim()) == false)
            {
                txtEndDate.Focus();
            }

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
            this.SaveData("Y");
        }
        else
        {
            lblMsg.Text = "Select a item first from the list then try to delete.";
        }

        this.EntryMode(false);
    }

    protected void grScheduleList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                //ScheduleID,TrainId,TrainName,SalLocId,SalLocName,StrDate,EndDate,Duration,NoofPerson,CoordinatorId,CoordinatorName,FundedBy,ProjectName,Residential,IsActive
                hfId.Value = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                //txtName.Text = Common.CheckNullString(grList.SelectedRow.Cells[1].Text.Trim());
                ddlTrName.SelectedValue = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                ddlLocation.SelectedValue = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[3].ToString();
                txtStrDate.Text = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[5].ToString();
                txtEndDate.Text = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[6].ToString();
                txtDuration.Text = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[7].ToString();
                txtNoOfPerson.Text = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[8].ToString();
                ddlCourseCordinator.SelectedValue = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[9].ToString();
               // ddlProject.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[11].ToString();
                ddlResidential.SelectedValue = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[13].ToString();

                if (grScheduleList.DataKeys[_gridView.SelectedIndex].Values[15].ToString() == "Y")
                    chkInActive.Checked = false;
                else
                    chkInActive.Checked = true;

                if (grScheduleList.DataKeys[_gridView.SelectedIndex].Values[16].ToString().Trim() == "P")
                {
                    ddlFundType.SelectedValue = "P";
                    Common.FillDropDownList(objSOFMgr.SelectProjectList(0), ddlProject, "ProjectName", "ProjectId", false);
                    ddlProjectDonar.Items.Clear();
                    if (ddlProject.Items.Count > 0)
                    {
                        ListItem item = ddlProject.Items.FindByValue(grScheduleList.DataKeys[_gridView.SelectedIndex].Values[11].ToString());
                        if (item != null)
                        ddlProject.SelectedValue = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[11].ToString();
                    }
                }
                else if (grScheduleList.DataKeys[_gridView.SelectedIndex].Values[16].ToString().Trim() == "D")
                {
                    ddlFundType.SelectedValue = "D";
                    Common.FillDropDownList(objSOFMgr.SelectDonerList(0), ddlProjectDonar, "DonerName", "DonerId", false);
                    ddlProject.Items.Clear();
                    if (ddlProjectDonar.Items.Count > 0)
                    {
                        ListItem item = ddlProjectDonar.Items.FindByValue(grScheduleList.DataKeys[_gridView.SelectedIndex].Values[17].ToString());
                        if (item != null)
                            ddlProjectDonar.SelectedValue = grScheduleList.DataKeys[_gridView.SelectedIndex].Values[17].ToString();
                    }
                }

                this.CreateTable();
                personTable = objEmpMgr.SelectTrainingScheduleDtlsList( grScheduleList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim());
                grList.DataSource = personTable;
                grList.DataBind();

                ViewState["dt"] = personTable;
                this.EntryMode(true);
                lblMsg.Text = "";
                break;
        }
    }
    protected void grList_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {

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
                   
                    ddlTrainer.Items.Clear();

                    if (grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim() == "E")
                    {
                        rblTrainerType.SelectedIndex = 0;
                        Common.FillDropDownList(objEmpMgr.SelectTrainingTrainerList("A"), ddlTrainer, "TrainerName", "TrainnerId", false);
                        ddlTrainer.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();// Common.CheckNullString(grList.SelectedRow.Cells[1].Text.Trim());

                    }
                    else if (grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim() == "I")
                    {
                        rblTrainerType.SelectedIndex = 1;
                        Common.FillDropDownList(objEmp.SelectEmpNameWithID("A"), ddlTrainer, "EmpName", "EmpID", false);
                        ddlTrainer.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();// Common.CheckNullString(grList.SelectedRow.Cells[1].Text.Trim());

                    }


                    DataRow[] drr = personTable.Select("TrainnerId='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim() + "'");
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
                    DataRow[] drr = personTable.Select("TrainnerId='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim() + "'");
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
         protected void ddlFundType_SelectedIndexChanged(object sender, EventArgs e)
         {
             if(ddlFundType.SelectedValue.ToString().Trim()=="P")
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
         protected void btnAdd_Click(object sender, EventArgs e)
         {
             DataTable dt = ViewState["dt"] as DataTable;
             DataRow[] drr = dt.Select("TrainnerId='" + ddlTrainer.SelectedValue.ToString().Trim() + "'");
             for (int i = 0; i < drr.Length; i++)
             {
                 drr[i].Delete();
             }
             dt.AcceptChanges();

             dt.Rows.Add(ddlTrainer.SelectedValue.ToString().Trim(), ddlTrainer.SelectedItem.ToString().Trim(), rblTrainerType.SelectedValue.Trim(), rblTrainerType.SelectedItem.ToString().Trim()); 
             
             grList.DataSource = dt;
             grList.DataBind();
         }
         protected void rblTrainerType_IndexChanged(object sender, EventArgs e)
         {
             ddlTrainer.Items.Clear();
             if (rblTrainerType.SelectedValue.Trim() == "E")
             {
                 Common.FillDropDownList(objEmpMgr.SelectTrainingTrainerList("A"), ddlTrainer, "TrainerName", "TrainnerId", false);
             }
             else if (rblTrainerType.SelectedValue.Trim() == "I")
             {
                 Common.FillDropDownList(objEmp.SelectEmpNameWithID("A"), ddlTrainer, "EmpName", "EmpID", false);
             }
         }
}
