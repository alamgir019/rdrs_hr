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

public partial class EIS_ReHired : System.Web.UI.Page
{
    MasterTablesManager objMasMgr = new MasterTablesManager();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();

    DBConnector objDB = new DBConnector();

    DataTable dtEmpSep = new DataTable();
    DataTable dtEmpInfo = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillDropDownList_Nil(objMasMgr.SelectAction(0,"A"), ddlAction);
            hfIsUpdate.Value = "N";
        }
    }
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (string.IsNullOrEmpty(txtEmpID.Text.Trim()) == false)
        {
            this.FillEmpInfo(txtEmpID.Text.Trim());
            this.OpenRecord();
        }
        else
        {
            //this.EntryMode(false);
        }
    }

    private void FillEmpInfo(string EmpId)
    {
        if (Session["USERID"].ToString().Trim().ToUpper() == "SYSTEM")
            dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHRAction(txtEmpID.Text.Trim());
        else if (Session["USERID"].ToString().Trim().ToUpper() != "SYSTEM")
        {
            dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHRAction(txtEmpID.Text.Trim());
        }

        if (dtEmpInfo.Rows.Count > 0)
        {
            foreach (DataRow row in dtEmpInfo.Rows)
            {
                lblName.Text = row["FullName"].ToString().Trim();
                lblDesignation.Text = row["DesigName"].ToString().Trim();
                lblSector.Text = row["SectorName"].ToString().Trim();
                lblDept.Text = row["DeptName"].ToString().Trim();
                if (string.IsNullOrEmpty(row["SeparateDate"].ToString().Trim()) == false)
                    lblSeperateddate.Text = Common.DisplayDate(row["SeparateDate"].ToString().Trim());
            }
        }
        else
        {
            lblMsg.Text = "Employee code is not valid Or not under your office.";
            txtEmpID.Text = "";
            lblName.Text = "";
            lblDesignation.Text = "";
            lblSector.Text = "";
            lblDept.Text = "";
            lblSeperateddate.Text = "";
            return;
        }
    }

    protected void grReHired_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                hfReHiredId.Value = grReHired.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                txtPayEmpId.Text = Common.CheckNullString(grReHired.SelectedRow.Cells[1].Text.Trim());                
                ddlAction.SelectedValue = grReHired.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                txtEffDate.Text = Common.CheckNullString(grReHired.SelectedRow.Cells[3].Text.Trim());                
                this.EntryMode(true);
                break;
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        //this.OpenRecord();
        grReHired.DataSource = null;
        grReHired.DataBind();

        lblName.Text = "";
        lblDesignation.Text = "";
        lblSector.Text = "";
        lblDept.Text = "";
        lblSeperateddate.Text = "";  
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave() == true)
        {
            this.SaveData();
            //ddlAction.SelectedIndex = 0;
        }
    }

    protected bool ValidateAndSave()
    {
        if (ddlAction.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select an Action.";            
            ddlAction.Focus();
            return false;
        }
        if (txtEffDate.Text == "")
        {
            lblMsg.Text = "Please input a valid date.";
            txtEffDate.Focus();
            return false;
        }
      
        return true;
    }

    private void SaveData()
    {
        long lnId = 0;
        if (hfIsUpdate.Value == "Y")
            lnId = Convert.ToInt64(hfReHiredId.Value);
        else 
            lnId = objDB.GerMaxIDNumber("EmpReHiredLog", "ReHiredId");

        string strEffDate = "";

        if (string.IsNullOrEmpty(txtEffDate.Text.Trim()) == false)
            strEffDate = Common.ReturnDate(txtEffDate.Text.Trim());               

        clsContractExt objReHired = new clsContractExt(txtEmpID.Text.Trim(), lnId.ToString(), ddlAction.SelectedValue.ToString(), strEffDate,
            Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()));

        EmpInfoManager objEmp = new EmpInfoManager();
        objEmp.InsertReHiredLog(objReHired, txtPayEmpId.Text.Trim(), ddlAction.SelectedItem.ToString(), hfIsUpdate.Value);            

        if (hfIsUpdate.Value == "N")
            lblMsg.Text = "Record Saved Successfully";

        else if (hfIsUpdate.Value == "Y")
            lblMsg.Text = "Record Updated Successfully";

        else
            lblMsg.Text = "";



        this.OpenRecord();
        this.EntryText();
        this.EntryMode(false);
    }

    protected void EntryText()
    {
        txtEmpID.Text = ""; 
        lblName.Text ="";
        lblDesignation.Text = "";
        lblDept.Text = "";
        lblSector.Text = "";
        lblSeperateddate.Text = ""; 

        txtPayEmpId.Text = ""; 
        ddlAction.SelectedIndex = -1;
        txtEffDate.Text = "";

        grReHired.DataSource = null;
        grReHired.DataBind();  
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
            EntryText();
        }
    }

    private void OpenRecord()
    {
        grReHired.Dispose();
        dtEmpSep = objEmpInfoMgr.SelectEmpReHiredlog(0,txtEmpID.Text.Trim());
        grReHired.DataSource = dtEmpSep;
        grReHired.DataBind();
        if (grReHired.Rows.Count > 0)
        {
            foreach (GridViewRow gRow in grReHired.Rows)
            {
                if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[3].Text)) == false)
                    gRow.Cells[3].Text = Common.DisplayDate(gRow.Cells[3].Text);
            }
        }
    }

}
