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

public partial class EIS_HRAction_Confirmation : System.Web.UI.Page
{
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();
    
    DataTable dtEmpInfo = new DataTable();
    DataTable dtConfrim = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillDropDownList_Nil(objEmpInfoMgr.SelectNatureWiseAction("C"), ddlAction);
            this.EntryMode(false);
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
            this.ClearControl();            
            btnSave.Text = "Save";
            hfIsUpdate.Value = "N";
            txtEntryDate.Text = Common.DisplayDate(Common.SetDate(DateTime.Today.ToShortDateString()));   
        }
    }
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (txtEmpID.Text.Trim() == "")
            return;

        dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHRAction(txtEmpID.Text.Trim());
        if (dtEmpInfo.Rows.Count == 0)
        {
            lblMsg.Text = "Invalid Employee No.";
            return;
        }
        else
        {
            lblMsg.Text = "";
            foreach (DataRow dRow in dtEmpInfo.Rows)
            {
                lblName.Text = dRow["FullName"].ToString();
                lblDesignation.Text = dRow["DesigName"].ToString().Trim();
                lblSector.Text = dRow["SectorName"].ToString().Trim();
                lblDept.Text = dRow["DeptName"].ToString().Trim();      
                lblJoinDate.Text = Common.DisplayDate(dRow["JoiningDate"].ToString());
                txtProbationPeriod.Text = dRow["ProbationPeriod"].ToString().Trim();
                if (string.IsNullOrEmpty(dRow["JoiningDate"].ToString().Trim()) == false)
                    txtStartDate.Text = Common.DisplayDate(dRow["JoiningDate"].ToString().Trim());
                if (string.IsNullOrEmpty(dRow["ConfirmationDate"].ToString().Trim()) == false)
                    txtConfirmDate.Text = Common.DisplayDate(dRow["ConfirmationDate"].ToString().Trim());
                lblBasicSalary.Text = dRow["BasicSalary"].ToString().Trim();
                lblBasicSalary.ToolTip = dRow["SalPakId"].ToString().Trim();
            }
            this.OpenRecord();
        }
    }

    private void OpenRecord()
    {
        dtConfrim = objEmpInfoMgr.SelectConfirmation(0, txtEmpID.Text.Trim());
        grConfirmation.DataSource = dtConfrim;
        grConfirmation.DataBind();

        if (dtConfrim.Rows.Count > 0)
        {
            foreach (GridViewRow gRow in grConfirmation.Rows)
            {
                if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[2].Text)) == false)
                    gRow.Cells[2].Text = Common.DisplayDate(gRow.Cells[2].Text);                
                if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[4].Text)) == false)
                    gRow.Cells[4].Text = Common.DisplayDate(gRow.Cells[4].Text);
                if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[5].Text)) == false)
                    gRow.Cells[5].Text = Common.DisplayDate(gRow.Cells[5].Text);
            }
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave() == true)
        {
            this.SaveData();
        }
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

            if (txtConfirmDate.Text.Trim()   == "")
            {
                lblMsg.Text = "Please enter confirmation date.";
                txtConfirmDate.Focus();  
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
    
    protected void SaveData()
    {
        dsPayroll_SalaryPackage objDs = new dsPayroll_SalaryPackage();
        Payroll_PaySlipOptionMgr objOptMgr = new Payroll_PaySlipOptionMgr();

        string strEntryDate = "";
        string strConfirmDate = "";
        string strNewConfirmDate = "";
        string strExtensionDate = "";        

        if (string.IsNullOrEmpty(txtEntryDate.Text.Trim()) == false)
            strEntryDate = Common.ReturnDate(txtEntryDate.Text.Trim());

        if (string.IsNullOrEmpty(txtConfirmDate.Text.Trim()) == false)
            strConfirmDate = Common.ReturnDate(txtConfirmDate.Text.Trim());

        if (string.IsNullOrEmpty(txtNewConfirmDate.Text.Trim()) == false)
            strNewConfirmDate = Common.ReturnDate(txtNewConfirmDate.Text.Trim());

        if (string.IsNullOrEmpty(txtExtensionDate.Text.Trim()) == false)
            strExtensionDate = Common.ReturnDate(txtExtensionDate.Text.Trim());     
    
        //PF Allowance 
        DataTable dtBfPlc = objOptMgr.SelectPayrollBenefitsPolicyData("0");
        DataRow[] foundPlcRow;        
        foundPlcRow = null;

        foundPlcRow = dtBfPlc.Select("SHEADID=13");
        if (foundPlcRow.Length > 0)
        {
            DataRow nRow3 = objDs.dtSalPackUpdate.NewRow();

            nRow3["SHEADID"] = 13;
            nRow3["PAYAMT"] = objEmpInfoMgr.GetHeadAmount(Common.RoundDecimal(lblBasicSalary.Text, 0), Common.RoundDecimal(foundPlcRow[0]["Value"].ToString(), 0));

            objDs.dtSalPackUpdate.Rows.Add(nRow3);
        }

        objDs.dtSalPackUpdate.AcceptChanges();

         if (hfIsUpdate.Value == "Y") 
            hfId.Value = hfId.Value;
        else
            hfId.Value = Common.getMaxId("EmpConfirmationLog", "ConfirmId");
         objEmpInfoMgr.InsertConfirmation(hfId.Value.ToString(), txtEmpID.Text.Trim(), ddlAction.SelectedValue.ToString(), strEntryDate, strConfirmDate, txtExtensionMonth.Text.Trim(), strNewConfirmDate, strExtensionDate,
            txtRemarks.Text.Trim(),Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()), hfIsUpdate.Value.ToString(),lblBasicSalary.ToolTip.ToString(),  objDs.dtSalPackUpdate);

        if (hfIsUpdate.Value == "N")
            lblMsg.Text = "Record Saved Successfully";
        else
            lblMsg.Text = "Record Updated Successfully";

        this.OpenRecord();
        this.EntryMode(false);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {        
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        this.OpenRecord();
        grConfirmation.DataSource = null;
        grConfirmation.DataBind();
        lblMsg.Text = "";
    }

    protected void ClearControl()
    {
        lblName.Text = "";
        lblDesignation.Text = "";
        lblDept.Text = "";
        lblSector.Text = "";
        txtEntryDate.Text = "";
        lblJoinDate.Text = "";
        lblBasicSalary.Text = "";
        txtEntryDate.Text = "";
 
        ddlAction.SelectedIndex = -1; 
        txtProbationPeriod.Text = "";
        txtStartDate.Text = "";
        txtConfirmDate.Text = "";
        txtNewConfirmDate.Text = "";
        txtExtensionMonth.Text = ""; 
        txtExtensionDate.Text = "";
        txtRemarks.Text = "";        
    }
    
    protected void grConfirmation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):

                ddlAction.SelectedValue = grConfirmation.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                hfId.Value = grConfirmation.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                txtConfirmDate.Text = Common.CheckNullString(grConfirmation.SelectedRow.Cells[2].Text.Trim());
                txtExtensionMonth.Text = Common.CheckNullString(grConfirmation.SelectedRow.Cells[3].Text.Trim());
                txtNewConfirmDate.Text = Common.CheckNullString(grConfirmation.SelectedRow.Cells[4].Text.Trim());
                txtExtensionDate.Text = Common.CheckNullString(grConfirmation.SelectedRow.Cells[5].Text.Trim());
                txtRemarks.Text = Common.CheckNullString(grConfirmation.SelectedRow.Cells[6].Text.Trim());
                this.EntryMode(true);
                lblMsg.Text = ""; 
                break;
        }
    }

    protected void txtExtensionMonth_TextChanged(object sender, EventArgs e)
    {
        DateTime dtJoinDate = new DateTime();
        DateTime dtConfirmDate = new DateTime();
        if ((string.IsNullOrEmpty(txtExtensionMonth.Text) == false) && (string.IsNullOrEmpty(txtStartDate.Text) == false))
        {
            dtJoinDate = Convert.ToDateTime(Common.ReturnDate(txtConfirmDate.Text.Trim()));
            dtConfirmDate = dtJoinDate.AddMonths(Convert.ToInt32(txtExtensionMonth.Text.Trim()));
            txtNewConfirmDate.Text = Common.DisplayDate(dtConfirmDate.ToString());            
        }
    }
}
