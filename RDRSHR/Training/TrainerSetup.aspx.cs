using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Training_TrainerSetup : System.Web.UI.Page
{
    TrainingManager objTrMgr = new TrainingManager();

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
        grList.DataSource = objTrMgr.SelectTrainingTrainerList("A");
        grList.DataBind();
    }
    
    
    private void SaveData(string cmdType)
    {
        dsTraining objDS = new dsTraining();
        if (cmdType == "I")
        {
            hfId.Value = Common.getMaxId("TrTrainerInfo", "TrainnerId");
        }

        DataTable dtMst = objDS.Tables["TrTrainerInfo"];
        DataRow nRow = dtMst.NewRow();

        nRow["TrainnerId"] = Common.RoundDecimal(hfId.Value, 0);
        nRow["TrainerName"] = txtTrainerName.Text.Trim();
        nRow["Address"] = txtAddress.Text.Trim();
        nRow["ContactNo"] = txtContactNo.Text.Trim();
        nRow["Organization"] = txtOrganization.Text.Trim();

        nRow["EmailId"] =txtEmailId.Text.Trim();  

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

        try
        {
            objTrMgr.SaveData(dtMst, cmdType == "D" ? "U" : cmdType);
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
    protected void grList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            //TrainnerId,TrainerName,Address,ContactNo,Organization,EmailId,IsActive
            case ("DoubleClick"):
                {
                    hfId.Value = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                   // txtTrainnerId.Text = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                    txtTrainerName.Text = grList.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
                    txtAddress.Text = grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim();
                    txtContactNo.Text = grList.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim();
                    txtOrganization.Text = grList.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim();
                    txtEmailId.Text = grList.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim();
         
                    if (grList.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim() == "N")
                        chkInActive.Checked = true;
                    else
                        chkInActive.Checked = false;

                    this.EntryMode(true);
                    lblMsg.Text = "";
                }
                break;
        }
    }
}