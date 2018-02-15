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

public partial class Payroll_Payroll_FinalPaymentEntry : System.Web.UI.Page
{
    DataTable dtEmpInfo = new DataTable();
    DataTable dtTempDuty = new DataTable();

    MasterTablesManager objMasMgr = new MasterTablesManager();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
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
           // this.EntryMode(false);
        }
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

    private void OpenRecord()
    {
        DataTable dt = new DataTable();
       // dt= objEmpInfoMgr.SelectEmpInfoHRAction(txtEmpID.Text.Trim());
        dt = objEmpInfoMgr.SelectEmpFinalPayment(txtEmpID.Text.Trim());

        if (dt.Rows.Count > 0)
        {
            this.txtProcessDate.Text = Common.DisplayDate(dt.Rows[0]["ProcessDate"].ToString().Trim());
            this.txtDueDate.Text = Common.DisplayDate(dt.Rows[0]["DueDate"].ToString().Trim());
            this.txtPaymentAmt.Text = decimal.ToInt32(Convert.ToDecimal(dt.Rows[0]["PaymentAmount"])).ToString();
            this.txtPFAmount.Text = decimal.ToInt32(Convert.ToDecimal(dt.Rows[0]["PFAmount"])).ToString();// dt.Rows[0]["PFAmount"].ToString().Trim();
            this.txtRemarks.Text = dt.Rows[0]["Remarks"].ToString().Trim();

            //int a = decimal.ToInt32(Convert.ToDecimal( dt.Rows[0]["PaymentAmount"]));
            btnSave.Text = "Update";
            hfIsUpdate.Value = "Y";
        }
        else {
            hfIsUpdate.Value = "N";
        }

        //  EmpID,ProcessDate,DueDate,PaymentAmount,PFAmount,Remarks

        //grTempDuty.Dispose();
        //dtTempDuty = objEmpInfoMgr.SelectEmpTempDutyAssignLog(0, txtEmpID.Text.Trim());
        //grTempDuty.DataSource = dtTempDuty;
        //grTempDuty.DataBind();
        //if (grTempDuty.Rows.Count > 0)
        //{
        //    foreach (GridViewRow gRow in grTempDuty.Rows)
        //    {
        //        if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[7].Text)) == false)
        //            gRow.Cells[7].Text = Common.DisplayDate(gRow.Cells[7].Text);

        //        if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[8].Text)) == false)
        //            gRow.Cells[8].Text = Common.DisplayDate(gRow.Cells[8].Text);
        //    }
        //}
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

            if (string.IsNullOrEmpty(txtProcessDate.Text) == true)
            {
                lblMsg.Text = "Please enter process date.";
                txtProcessDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDueDate.Text) == true)
            {
                lblMsg.Text = "Please enter due date.";
                txtDueDate.Focus();
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
            hfId.Value = txtEmpID.ToString(); 
            string strStartDate = "";
            string strEndDate = "";

            if (string.IsNullOrEmpty(txtProcessDate.Text.Trim()) == false)
                strStartDate = Common.ReturnDate(txtProcessDate.Text.Trim());

            if (string.IsNullOrEmpty(txtDueDate.Text.Trim()) == false)
                strEndDate = Common.ReturnDate(txtDueDate.Text.Trim());

            //clsTempDutyAssign objclsTempDutyAssign = new clsTempDutyAssign
            //(
            //    hfId.Value.ToString(), txtEmpID.Text.Trim(), ddlAction.SelectedValue.ToString(), ddlDistrict.SelectedValue.ToString(), ddlLocation.SelectedValue.ToString(),
            //    ddlSector.SelectedValue.ToString(), ddlUnit.SelectedValue.ToString(), ddlDept.SelectedValue.ToString(), txtAssignment.Text.Trim(), strStartDate, strEndDate,
            //   txtPercentage.Text.Trim(), txtAmount.Text.Trim(), txtSupervisorId.Text.Trim(), txtSupervisorComments.Text.Trim(), Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString())
            //);

            objEmpInfoMgr.InsertFinalPayment(txtEmpID.Text.Trim(), strStartDate, strEndDate, txtPaymentAmt.Text.ToString(), txtPFAmount.Text.ToString(), txtRemarks.Text.ToString(), hfIsUpdate.Value);

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

                lblGrade.Text= row["GradeName"].ToString().Trim();
                lblJoindate.Text = Common.DisplayDate(row["JoiningDate"].ToString().Trim());
                lblSeprateDate.Text =Common.DisplayDate(row["SeparateDate"].ToString().Trim());
                lblSeparateType.Text = row["SeaprateType"].ToString().Trim();
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
    private void ClearControls()
    {

        txtProcessDate.Text = "";
        txtDueDate.Text = "";
        txtPaymentAmt.Text = ""; 
        txtPFAmount.Text = "";
        txtRemarks.Text = "";

    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave() == true)
            SaveData();
    }

    protected void grEmpTempDuty_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void grTempDuty_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}