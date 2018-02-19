using BaseHR.DATA;
using BaseHR.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Leave_LeavePlan : System.Web.UI.Page
{
    DLeavePlan objLeaveMgr = new DLeavePlan();
    LeavePlanDTO objLeavePlan = null;
    List<LeavePlanDTO> planList = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlLeaveType.DataSource = objLeaveMgr.getLeaveType();
            ddlLeaveType.DataTextField = "LTypeTitle";
            ddlLeaveType.DataValueField = "LTypeId";
            ddlLeaveType.DataBind();
            this.EntryMode(false);
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
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            ddlLeaveType.SelectedIndex = -1;
            txtEmpId.Text = Session["EMPID"].ToString();
            txtRemarks.Text = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave() == true)
        {
            this.SaveData();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.OpenRecord();
    }
    private bool ValidateAndSave()
    {
        try
        {
            if (txtEmpId.Text == "")
            {
                lblMsg.Text = "Please enter employee code and press enter.";
                txtEmpId.Focus();
                return false;
            }
            if (txtStartDate.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter entitlement date.";
                txtStartDate.Focus();
                return false;
            }
            if (txtEndDate.Text.Trim() == "")
            {
                lblMsg.Text = "Please enter date.";
                txtStartDate.Focus();
                return false;
            }
            return true;

        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }

    private void SaveData()
    {
        this.CreateObjet();
        int saveCnt = objLeaveMgr.AddLeavePlan(objLeavePlan);
        if (saveCnt > 0)
        {
            if (hfIsUpdate.Value == "N")
                lblMsg.Text = "Leave Plan Saved Successfully";
            else
                lblMsg.Text = "Leave Plan Updated Successfully";
            this.EntryMode(false);
        }
        else
        {
            lblMsg.Text = "Leave Plan did not saved";
        }
        this.OpenRecord();
    }

    private void OpenRecord()
    {
        if (!string.IsNullOrEmpty(txtEmployeeId.Text.Trim()))
        {
            var list = objLeaveMgr.GetLeavePlan();
            planList = list.Where(cc => cc.EmpId.Equals(txtEmployeeId.Text.Trim())).ToList();
            grLeavePlan.DataSource = planList;
            grLeavePlan.DataBind();
        }
    }
    private void CreateObjet()
    {

        decimal planID = 0;
        string strStartDate = "";
        string strEndDate = "";

        if (string.IsNullOrEmpty(txtStartDate.Text.Trim()) == false)
            strStartDate = Common.ReturnDate(txtStartDate.Text.Trim());

        if (string.IsNullOrEmpty(txtEndDate.Text.Trim()) == false)
            strEndDate = Common.ReturnDate(txtEndDate.Text.Trim());

        if (hfIsUpdate.Value == "N")
        {
            planID = 0;
        }
        else
        {
            planID = Convert.ToDecimal(hfID.Value.ToString());
        }
        objLeavePlan = new LeavePlanDTO();
        objLeavePlan.ID = planID;
        objLeavePlan.EmpId = txtEmpId.Text.Trim();
        objLeavePlan.LTypeId = Convert.ToDecimal(ddlLeaveType.SelectedValue);
        objLeavePlan.StartDate = Convert.ToDateTime(strStartDate);
        objLeavePlan.EndDate = Convert.ToDateTime(strEndDate);
        objLeavePlan.Remarks = txtRemarks.Text;
        objLeavePlan.IsActive = ChkIsActive.Checked ? "N" : "Y";
    }

    protected void grLeavePlan_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void grLeavePlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                //ID ,EmpId,LTypeId,LTypeName,StartDate,EndDate,Remarks,IsActive
                txtEmpId.Text = grLeavePlan.SelectedRow.Cells[1].Text;
                hfID.Value = grLeavePlan.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                ChkIsActive.Checked = (grLeavePlan.DataKeys[_gridView.SelectedIndex].Values[7].ToString() == "N" ? true : false);
                var pp = grLeavePlan.DataKeys[_gridView.SelectedIndex].Values[7].ToString();
                txtRemarks.Text = Common.CheckNullString(grLeavePlan.SelectedRow.Cells[5].Text);
                ddlLeaveType.SelectedValue = grLeavePlan.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                txtStartDate.Text = grLeavePlan.SelectedRow.Cells[3].Text;//grLeavePlan.DataKeys[_gridView.SelectedIndex].Values[4].ToString();
                txtEndDate.Text = grLeavePlan.SelectedRow.Cells[4].Text; //grLeavePlan.DataKeys[_gridView.SelectedIndex].Values[5].ToString();
                this.EntryMode(true);
                break;
        }
    }
}