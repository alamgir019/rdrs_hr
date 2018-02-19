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

public partial class EIS_HRAction_TempDutyAssign : System.Web.UI.Page
{
    DataTable dtEmpInfo = new DataTable();
    DataTable dtTempDuty = new DataTable();

    MasterTablesManager objMasMgr = new MasterTablesManager();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillDropDownList_Nil(objEmpInfoMgr.SelectNatureWiseAction("T"), ddlAction);
            Common.FillDropDownList_Nil(objMasMgr.SelectSector(0), ddlSector);
            Common.FillDropDownList_Nil(objMasMgr.SelectDepartment(0), ddlDept);
            Common.FillDropDownList_Nil(objMasMgr.SelectUnit(0), ddlUnit);
            Common.FillDropDownList_Nil(objMasMgr.SelectDistrict(0), ddlDistrict);
            Common.FillDropDownList_Nil(objMasMgr.SelectLocation(0), ddlLocation);
            hfIsUpdate.Value = "N";
            this.EntryMode(false);
        }
    }

    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(txtEmpID.Text.Trim()) == false)
        {
            this.FillEmpInfo(txtEmpID.Text.Trim());
            this.OpenRecord();            
            this.EntryMode(false);
        }
    }

    private void FillEmpInfo(string EmpId)
    {
        dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHRAction(txtEmpID.Text.Trim());

        if (dtEmpInfo.Rows.Count > 0)
        {
            foreach (DataRow row in dtEmpInfo.Rows)
            {
                lblName.Text = row["FullName"].ToString().Trim();
                lblDesignation.Text = row["DesigName"].ToString().Trim();
                lblSector.Text = row["SectorName"].ToString().Trim();
                lblDept.Text = row["DeptName"].ToString().Trim();                
            }
        }
        else
        {
            lblMsg.Text = "Employee code is not valid.";
            txtEmpID.Text = "";
            lblName.Text = "";
            lblDesignation.Text = "";
            lblSector.Text = "";
            lblDept.Text = "";
            return;
        }
        lblMsg.Text = "";
    }

     private void OpenRecord()
     {
         grTempDuty.Dispose();
         dtTempDuty = objEmpInfoMgr.SelectEmpTempDutyAssignLog(txtEmpID.Text.Trim());
         grTempDuty.DataSource = dtTempDuty;
         grTempDuty.DataBind();
         if (grTempDuty.Rows.Count > 0)
         {
             foreach (GridViewRow gRow in grTempDuty.Rows)
             {
                 if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[7].Text)) == false)
                     gRow.Cells[7].Text = Common.DisplayDate(gRow.Cells[7].Text);

                 if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[8].Text)) == false)
                     gRow.Cells[8].Text = Common.DisplayDate(gRow.Cells[8].Text);
             }
         }
     }

     protected void btnRefresh_Click(object sender, EventArgs e)
     {
         txtEmpID.Text = "";
         lblName.Text = "";
         lblDesignation.Text = "";
         lblDept.Text = "";
         lblSector.Text = "";

         this.EntryMode(false);
         this.ClearControls();

         grTempDuty.DataSource = null;
         grTempDuty.DataBind();
     }

     protected void EntryMode(bool IsUpdate)
     {
         if (IsUpdate == true)
         {
             btnSave.Text = "Update";
             hfIsUpdate.Value = "Y";
             lblMsg.Text = "";
         }
         else
         {
             btnSave.Text = "Save";
             hfIsUpdate.Value = "N";
             this.ClearControls();
         }
     }

     private void ClearControls()
     {
        ddlAction.SelectedIndex =-1;
        ddlDistrict.SelectedIndex = -1;
        ddlLocation.SelectedIndex = -1;
        ddlSector.SelectedIndex = -1;
        ddlUnit.SelectedIndex = -1;
        ddlDept.SelectedIndex = -1;
        txtAssignment.Text = "";
        txtStartDate.Text = "";
        txtEndDate.Text = "";
        txtPercentage.Text = "";
        txtAmount.Text = "";
        txtSupervisorId.Text = "";
        txtSupervisorName.Text = "";
        txtSupervisorComments.Text = "";
        txtRecommendId.Text = "";
        txtRecommendName.Text = "";    
     }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave() == true)
            SaveData();
    }
    protected bool ValidateAndSave()
    {
        try
        {
            if (ddlAction.SelectedIndex == 0)
            {
                lblMsg.Text = "Please Select The Action From The List.";
                ddlAction.Focus();
                return false;
            }
            if (ddlDistrict.SelectedIndex == 0)
            {
                lblMsg.Text = "Please Select The Posting District From The List.";
                ddlDistrict.Focus();
                return false;
            }
            if (ddlSector.SelectedIndex == 0)
            {
                lblMsg.Text = "Please Select The Sector From The List.";
                ddlSector.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtStartDate.Text  )==true )
            {
                lblMsg.Text = "Please enter starting date.";
                txtStartDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEndDate.Text) == true)
            {
                lblMsg.Text = "Please enter ending date.";
                txtEndDate.Focus();
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
        try
        {
            MasterTablesManager MasMgr = new MasterTablesManager();

            if (hfIsUpdate.Value == "Y")
                hfId.Value = hfId.Value;
            else
                hfId.Value = Common.getMaxId("EmpTempDutyAssignLog", "DutyAssignID");

            string strStartDate = "";
            string strEndDate = "";

            if (string.IsNullOrEmpty(txtStartDate.Text.Trim()) == false)
                strStartDate = Common.ReturnDate(txtStartDate.Text.Trim());

            if (string.IsNullOrEmpty(txtEndDate.Text.Trim()) == false)
                strEndDate = Common.ReturnDate(txtEndDate.Text.Trim());

            clsTempDutyAssign objclsTempDutyAssign = new clsTempDutyAssign
            (
                hfId.Value.ToString(), txtEmpID.Text.Trim(), ddlAction.SelectedValue.ToString(), ddlDistrict.SelectedValue.ToString(), ddlLocation.SelectedValue.ToString(),
                ddlSector.SelectedValue.ToString(), ddlUnit.SelectedValue.ToString(), ddlDept.SelectedValue.ToString(), txtAssignment.Text.Trim(), strStartDate, strEndDate,
               txtPercentage.Text.Trim(),txtAmount.Text.Trim(),txtSupervisorId.Text.Trim(),txtRecommendId.Text.Trim(),txtSupervisorComments.Text.Trim(),Session["USERID"].ToString(),Common.SetDateTime(DateTime.Now.ToString())
            );

            objEmpInfoMgr.InsertEmpTempDuty(objclsTempDutyAssign, hfIsUpdate.Value);

            if (hfIsUpdate.Value == "N")
                lblMsg.Text = "Record Saved Successfully";
            else if (hfIsUpdate.Value == "Y")
                lblMsg.Text = "Record Updated Successfully";
            else
                lblMsg.Text = "Record Deleted Successfully";

            this.EntryMode(false);            
            this.ClearControls();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }

    protected void grEmpTempDuty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                hfIsUpdate.Value = "N";
                hfId.Value = grTempDuty.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                ddlAction.SelectedValue = grTempDuty.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                if (string.IsNullOrEmpty(grTempDuty.DataKeys[_gridView.SelectedIndex].Values[2].ToString()) == false)
                    ddlDistrict.SelectedValue = grTempDuty.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                if (string.IsNullOrEmpty(grTempDuty.DataKeys[_gridView.SelectedIndex].Values[3].ToString()) == false)
                    ddlLocation.SelectedValue = grTempDuty.DataKeys[_gridView.SelectedIndex].Values[3].ToString();
                if (string.IsNullOrEmpty(grTempDuty.DataKeys[_gridView.SelectedIndex].Values[4].ToString()) == false)
                    ddlSector.SelectedValue = grTempDuty.DataKeys[_gridView.SelectedIndex].Values[4].ToString();
                if (string.IsNullOrEmpty(grTempDuty.DataKeys[_gridView.SelectedIndex].Values[5].ToString()) == false)
                    ddlUnit.SelectedValue = grTempDuty.DataKeys[_gridView.SelectedIndex].Values[5].ToString();
                if (string.IsNullOrEmpty(grTempDuty.DataKeys[_gridView.SelectedIndex].Values[6].ToString()) == false)
                    ddlDept.SelectedValue = grTempDuty.DataKeys[_gridView.SelectedIndex].Values[6].ToString();
                txtStartDate.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[7].Text);
                txtEndDate.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[8].Text);
                txtAmount.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[9].Text);
                txtPercentage.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[10].Text);
                txtAssignment.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[11].Text.Trim());
                txtSupervisorId.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[12].Text);
                txtSupervisorComments.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[13].Text.Trim());
                txtRecommendId.Text = Common.CheckNullString(grTempDuty.SelectedRow.Cells[14].Text);
                this.EntryMode(true);
                break;
            case ("RowDeleting"):
                hfIsUpdate.Value = "N";
                SaveData();
                break;
        }
    }

    protected void grTempDuty_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void imgBtnSuper_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(txtSupervisorId.Text.Trim()) == false)
        {
            dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHRAction(txtSupervisorId.Text.Trim());

            if (dtEmpInfo.Rows.Count > 0)
            {
                foreach (DataRow row in dtEmpInfo.Rows)
                {
                    txtSupervisorName.Text = row["FullName"].ToString().Trim();
                    lblMsg.Text = "";

                }
            }
            else
            {
                lblMsg.Text = "Supervisor Id is not valid.";
            }
        }
    }

    protected void imgBtnRec_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(txtRecommendId.Text.Trim()) == false)
        {
            dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHRAction(txtRecommendId.Text.Trim());

            if (dtEmpInfo.Rows.Count > 0)
            {
                foreach (DataRow row in dtEmpInfo.Rows)
                {
                    txtRecommendName.Text = row["FullName"].ToString().Trim();
                    lblMsg.Text = "";

                }
            }
            else
            {
                lblMsg.Text = "Recommender Id is not valid.";
            }
        }
    }
    
}
