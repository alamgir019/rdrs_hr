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
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using BaseHR.Repository.DAL;
using BaseHR.DATA;

public partial class EmpLeaveAdjustCTO : System.Web.UI.Page
{
    //DBConnector objDB = new DBConnector();
    DLeavePlan objLeaveMgr = new DLeavePlan();
    DEmployee objEmpInfoMgr = new DEmployee();
    List<EmpInfoDTO> objEmpinfo = new List<EmpInfoDTO>();
    List<EmpLeaveCTOEntitleLog> lvLogs = new List<EmpLeaveCTOEntitleLog>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillYearList(5, ddlYear);
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlLType.DataSource = objLeaveMgr.getLeaveType().Where(ll=>ll.LAbbrName=="CPL").ToList();
            ddlLType.DataTextField = "LTypeTitle";
            ddlLType.DataValueField = "LTypeId";
            ddlLType.DataBind();
            this.EntryMode(false);
        }
    }

    private void OpenRecord()
    {
        var ctolist = objLeaveMgr.GetLeaveCTO();
        lvLogs = ctolist.Where(cc=>cc.EmpId.Equals(txtEmpId.Text.Trim()) && cc.LYear.Equals(Convert.ToDecimal(ddlYear.SelectedValue))).ToList();
        grCTOLeaveHistory.DataSource = lvLogs;
        grCTOLeaveHistory.DataBind();
        int count = 0;
        foreach (GridViewRow gRow in grCTOLeaveHistory.Rows)
        {
            if (count == 0)
                gRow.Cells[0].Enabled = true;
            else
                gRow.Cells[0].Enabled = false;

            count++;
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
            txtEntitle.Text = "0";
            ddlLType.SelectedIndex = -1;
            txtEmpId.Text = Session["EMPID"].ToString();
            lblName.Text = Session["USERNAME"].ToString();
            txtStartDate.Text = "20/12/1900"; //DateTime.Now.ToString("dd/MM/yyyy");
            //txtStartDate.Text = Common.ReturnDate(DateTime.Now.ToString());
            //txtEndDate.Text = "";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        if (string.IsNullOrEmpty(txtEmpId.Text.Trim()) == false)
        {
            objEmpinfo = objEmpInfoMgr.getEmployeeInfo(txtEmpId.Text.Trim());

            if (objEmpinfo.Count == 0)
            {
                lblMsg2.Text = "Employee Code is not valid.";
                txtEmpId.Focus();
                lblName.Text = "";
                grCTOLeaveHistory.DataSource = null;
                grCTOLeaveHistory.DataBind();
                return;
            }
            else
            {
                lblMsg2.Text = "";
                lblMsg.Text = "";
                this.FillEmpInfo();
                this.OpenRecord();
                this.FormatLeaveStatusGridNumber();
            }
        }
    }

    private void FillEmpInfo()
    {
        if (objEmpinfo.Count > 0)
        {
            foreach (var row in objEmpinfo)
            {
                lblName.Text = row.FullName;
            }
        }
    }

    protected void FormatLeaveStatusGridNumber()
    {
        foreach (GridViewRow gRow in grCTOLeaveHistory.Rows)
        {
            if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[3].Text)) == false)
                gRow.Cells[3].Text = Common.DisplayDate(gRow.Cells[3].Text);
            if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[4].Text)) == false)
                gRow.Cells[4].Text = Common.DisplayDate(gRow.Cells[4].Text);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave() == true)
        {
            this.SaveData();
        }
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
            if ((txtEntitle.Text.Trim() == "") || (txtEntitle.Text.Trim() == "0"))
            {
                lblMsg.Text = "Please enter leave accrued.";
                txtEntitle.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtEntitle.Text) > 2)
            {
                lblMsg.Text = "CTO entitlement can not greater then 2 days";
                txtEntitle.Focus();
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
            if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
            {
                lblMsg.Text = "Please add remarks indicating overtime date.";
                txtRemarks.Focus();
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
        string strLogID = "";
        string strStartDate = "";
        string strEndDate = "";

        if (string.IsNullOrEmpty(txtStartDate.Text.Trim()) == false)
            strStartDate = Common.ReturnDate(txtStartDate.Text.Trim());

        if (string.IsNullOrEmpty(txtEndDate.Text.Trim()) == false)
            strEndDate = Common.ReturnDate(txtEndDate.Text.Trim());

        decimal PrevsValue = 0;

        if (hfIsUpdate.Value == "N")
        {
            strLogID = "0";
            PrevsValue = 0;
        }
        else
        {
            strLogID = hfID.Value.ToString();
            PrevsValue = Convert.ToDecimal(hfPrevsValue.Value);
        }

        int saveCnt= objLeaveMgr.AddEmpLeaveCTOEntitleLog(Convert.ToDecimal(strLogID), txtEmpId.Text.Trim(), Convert.ToDecimal(ddlLType.SelectedValue.ToString()),Convert.ToDecimal(txtEntitle.Text.Trim()),
            strStartDate, strEndDate, Convert.ToDecimal(ddlYear.SelectedItem.Text.Trim()),txtRemarks.Text.ToString(), Session["USERID"].ToString(), Convert.ToDecimal(PrevsValue.ToString()));
        if (saveCnt>0)
        {
            if (hfIsUpdate.Value == "N")
                lblMsg.Text = "CTO Leave Entitlement Saved Successfully";
            else
                lblMsg.Text = "CTO Leave Entitlement Updated Successfully";
        }
        else
        {
            lblMsg.Text = "CTO Leave did not saved";
        }
        this.OpenRecord();
        this.FormatLeaveStatusGridNumber();
        this.EntryMode(false);
    }
    

    protected void grCTOLeaveHistory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                hfID.Value = _gridView.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                ddlLType.SelectedValue = _gridView.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                txtEntitle.Text = grCTOLeaveHistory.SelectedRow.Cells[2].Text;
                txtStartDate.Text = Common.CheckNullString(grCTOLeaveHistory.SelectedRow.Cells[3].Text);
                txtEndDate.Text = Common.CheckNullString(grCTOLeaveHistory.SelectedRow.Cells[4].Text);
                ddlYear.SelectedValue = Common.CheckNullString(grCTOLeaveHistory.SelectedRow.Cells[5].Text);
                txtRemarks.Text = Common.CheckNullString(grCTOLeaveHistory.SelectedRow.Cells[6].Text);
                hfPrevsValue.Value = Common.CheckNullString(grCTOLeaveHistory.SelectedRow.Cells[2].Text);
                this.EntryMode(true);
                break;
        }
    }

    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtStartDate.Text.Trim()) == false)
        {
            char[] splitter = { '/' };
            string[] arinfo = Common.str_split(txtStartDate.Text.Trim(), splitter);
            DateTime dtStDate = new DateTime();
            if (arinfo.Length == 3)
            {
                dtStDate = Convert.ToDateTime(arinfo[2] + "/" + arinfo[1] + "/" + arinfo[0]);
                arinfo = null;
            }
            DateTime dtEndDate = dtStDate.AddMonths(2);
            txtEndDate.Text = Common.DisplayDate(dtEndDate.ToString());
        }
    }

}
