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

public partial class EIS_HRAction_EmpSalaryAmendment : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();
    MasterTablesManager objMasMgr = new MasterTablesManager();

    DataTable dtEmpInfo = new DataTable();
    DataTable dtConfrim = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillDropDownList_Nil(objMasMgr.SelectAction(0, "M"), ddlAction);
            Common.FillDropDownList_Nil(objMasMgr.SelectGrade(0), ddlGrade);
            Common.FillDropDownList_Nil(objMasMgr.SelectGradeLevel(0), ddlGradeLevel);
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
        else
        {
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
                lblOffice_Loc.Text = row["DivisionName"].ToString().Trim() + ", " + row["OfficeTitle"].ToString().Trim();
                lblDeg_Project.Text = row["SectorName"].ToString().Trim() + ", " + row["DesigName"].ToString().Trim();
                
                lblGross.Text = row["GrossSalary"].ToString().Trim();
                lblBasic.Text = row["BasicSalary"].ToString().Trim();
              
                lblSalPac.Text = row["SPTitle"].ToString().Trim();
                lblSalPac.ToolTip = row["SalPakId"].ToString().Trim();

                ddlGrade.SelectedValue = Common.RetrieveddL(ddlGrade, row["GradeId"].ToString(), "99999");
                ddlGradeLevel.SelectedValue = Common.RetrieveddL(ddlGradeLevel, row["GradeLevelId"].ToString(), "99999");

            }
        }
        else
        {
            lblMsg.Text = "Employee code is not valid or not under your office.";
            txtEmpID.Text = "";
            lblName.Text = "";
            lblDeg_Project.Text = "";
            lblOffice_Loc.Text = "";
            lblSalPac.Text = "";
            lblSalPac.ToolTip = "";
            lblBasic.Text = "";
            return;
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
            ddlAction.SelectedIndex = -1;
            txtEffDate.Text = "";
            txtBasicSalary.Text = "0";
            txtRemarks.Text = "";
            txtGrossSal.Text = "0";
            txtHouseRent.Text = "0";
            txtMedical.Text = "0";
            txtConveyance.Text = "0";
            txtIncPercentage.Text = "";
        }
    }

    private void ClearControls()
    {
        txtEmpID.Text = "";
        lblName.Text = "";
        lblDeg_Project.Text = "";
        lblOffice_Loc.Text = "";
        lblBasic.Text = "";
        lblSalPac.Text = "";
        lblSalPac.ToolTip = "";
        lblGross.Text = "";
        lblBasic.Text = "";
        grConfirmation.DataSource = null;
        grConfirmation.DataBind();
    }

    private void OpenRecord()
    {
        dtConfrim = objEmpInfoMgr.SelectEmpSalaryAmendment(0, txtEmpID.Text.Trim());
        grConfirmation.DataSource = dtConfrim;
        grConfirmation.DataBind();

        if (dtConfrim.Rows.Count > 0)
        {
            foreach (GridViewRow gRow in grConfirmation.Rows)
            {
                if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[2].Text)) == false)
                    gRow.Cells[2].Text = Common.DisplayDate(gRow.Cells[2].Text);
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
        if (txtEmpID.Text == "")
        {
            lblMsg.Text = "Please select Emp code.";
            txtEmpID.Focus();
            return false;
        }

        if (ddlAction.SelectedIndex == 0)
        {
            lblMsg.Text = "Please select an action from the list.";
            ddlAction.Focus();
            return false;
        }

        if (txtBasicSalary.Text == "")
        {
            lblMsg.Text = "Please enter basic salary.";
            txtBasicSalary.Focus();
            return false;
        }
       
        return true;
    }

    private void SaveData()
    {
        dsPayroll_SalaryPackage objDs = new dsPayroll_SalaryPackage();
        Payroll_PaySlipOptionMgr objOptMgr = new Payroll_PaySlipOptionMgr();

        string IsDelete = "N";
        long lngID = 0;
        try
        {
            string strConfrimDate = "";

            if (string.IsNullOrEmpty(txtEffDate.Text.Trim()) == false)
                strConfrimDate = Common.ReturnDate(txtEffDate.Text.Trim());

            if (hfIsUpdate.Value == "N")
                lngID = objDB.GerMaxIDNumber("EmpSalaryAmendment", "LogId");
            else
                lngID = Convert.ToInt32(hfID.Value);

            DataTable dtBfPlc = objOptMgr.SelectPayrollBenefitsPolicyData("0");
            DataRow[] foundPlcRow;
            foundPlcRow = null;

            //Basic
            DataRow nRow1 = objDs.dtSalPackUpdate.NewRow();
            nRow1["SHEADID"] = 1;
            nRow1["PAYAMT"] = Common.RoundDecimal(txtBasicSalary.Text, 0);
            objDs.dtSalPackUpdate.Rows.Add(nRow1);

            //House Rent
            foundPlcRow = dtBfPlc.Select("SHEADID=2");
            if (foundPlcRow.Length > 0)
            {
                DataRow nRow2 = objDs.dtSalPackUpdate.NewRow();

                nRow2["SHEADID"] = 2;
                nRow2["PAYAMT"] = objEmpInfoMgr.GetHeadAmount(Common.RoundDecimal(txtBasicSalary.Text, 0), Common.RoundDecimal(foundPlcRow[0]["Value"].ToString(), 0));

                objDs.dtSalPackUpdate.Rows.Add(nRow2);
            }

            // Medical
            foundPlcRow = dtBfPlc.Select("SHEADID=3");
            if (foundPlcRow.Length > 0)
            {
                DataRow nRow2 = objDs.dtSalPackUpdate.NewRow();

                nRow2["SHEADID"] = 3;
                nRow2["PAYAMT"] = objEmpInfoMgr.GetHeadAmount(Common.RoundDecimal(txtBasicSalary.Text, 0), Common.RoundDecimal(foundPlcRow[0]["Value"].ToString(), 0));

                objDs.dtSalPackUpdate.Rows.Add(nRow2);
            }

            // Conveyance
            foundPlcRow = dtBfPlc.Select("SHEADID=4");
            if (foundPlcRow.Length > 0)
            {
                DataRow nRow2 = objDs.dtSalPackUpdate.NewRow();

                nRow2["SHEADID"] = 4;
                nRow2["PAYAMT"] = objEmpInfoMgr.GetHeadAmount(Common.RoundDecimal(txtBasicSalary.Text, 0), Common.RoundDecimal(foundPlcRow[0]["Value"].ToString(), 0));

                objDs.dtSalPackUpdate.Rows.Add(nRow2);
            }

            // Calculate Gross, Incremented Amount, and Percent 

            decimal decGross = Common.RoundDecimal(txtBasicSalary.Text.Trim(), 0) +
                Common.RoundDecimal(txtHouseRent.Text.Trim(), 0) +
                Common.RoundDecimal(txtMedical.Text.Trim(), 0) +
                Common.RoundDecimal(txtConveyance.Text.Trim(), 0);

            decimal decIncrAmt = decGross - Common.RoundDecimal(lblGross.Text.Trim(), 0);
            decimal decIncrPercnt = (decIncrAmt * 100) / Common.RoundDecimal(lblGross.Text.Trim(), 0);
            decIncrPercnt = Common.RoundDecimal(decIncrPercnt.ToString(), 2); 

            objEmpInfoMgr.InsertEmpSalaryAmendment(lngID.ToString(), txtEmpID.Text.Trim(), ddlAction.SelectedValue.ToString(), ddlAction.SelectedItem.ToString(),
                strConfrimDate, txtBasicSalary.Text, txtHouseRent.Text.Trim(), txtMedical.Text.Trim(), txtConveyance.Text.Trim(), decGross.ToString(),
                txtRemarks.Text.Trim(), decIncrAmt.ToString(), decIncrPercnt.ToString(), Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()), hfIsUpdate.Value, IsDelete,
                lblSalPac.ToolTip.ToString(), objDs.dtSalPackUpdate);

            if (hfIsUpdate.Value == "N")
                lblMsg.Text = "Record Saved Successfully";
            else
                lblMsg.Text = "Record Updated Successfully";
            this.EntryMode(false);
            this.ClearControls();
            //this.OpenRecord();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
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
                hfID.Value = grConfirmation.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                txtEffDate.Text = Common.CheckNullString(grConfirmation.SelectedRow.Cells[2].Text.Trim());
                txtBasicSalary.Text = Common.CheckNullString(grConfirmation.SelectedRow.Cells[3].Text.Trim());
                txtHouseRent.Text = grConfirmation.DataKeys[_gridView.SelectedIndex].Values["NewHouseRent"].ToString();
                txtMedical.Text = grConfirmation.DataKeys[_gridView.SelectedIndex].Values["NewMedical"].ToString();
                txtConveyance.Text = grConfirmation.DataKeys[_gridView.SelectedIndex].Values["NewConveyance"].ToString();
                txtGrossSal.Text = grConfirmation.DataKeys[_gridView.SelectedIndex].Values["NewGross"].ToString();
                txtIncPercentage.Text = grConfirmation.DataKeys[_gridView.SelectedIndex].Values["IncPercent"].ToString();

                txtRemarks.Text = Common.CheckNullString(grConfirmation.DataKeys[_gridView.SelectedIndex].Values["Remarks"].ToString());
                this.EntryMode(true);
                break;
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        this.EntryMode(false);
        this.ClearControls();
    }

    /*protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfID.Value) == false)
        {
            this.SaveData("Y");
        }
        else
        {
            lblMsg.Text = "Select an confirmation info. first from the list then try to delete.";
        }

        this.EntryMode(false);
    }*/
    
    protected void txtNewSalary_TextChanged(object sender, EventArgs e)
    {
        //if ((string.IsNullOrEmpty(txtBasicSal.Text) == false) && (string.IsNullOrEmpty(lblBasic.Text) == false))
        //{
        //    decimal basic=txt

        //    txtIncPercentage.Text = Convert.ToString(Convert.ToDecimal(txtBasicSal.Text) / Convert.ToDecimal(lblBasic.Text));
        //}
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
    }

    protected void SetBasicAndGross()
    {
        DataTable dtBasic = objEmpInfoMgr.GetGradeWiseSalaryMatrix(Convert.ToDecimal(ddlGrade.SelectedValue.Trim()), Convert.ToDecimal(ddlGradeLevel.SelectedValue.Trim()));
        decimal decGross = 0;
        if (dtBasic.Rows.Count > 0)
        {

            txtBasicSalary.Text = dtBasic.Rows[0]["BasicSal"].ToString();
            //if (ddlOffice.SelectedValue.Trim() != "1")
            //{
            //    decGross = Convert.ToDecimal(dtBasic.Rows[0]["BasicSal"].ToString()) +
            //   Convert.ToDecimal(dtBasic.Rows[0]["Housing"].ToString()) +
            //    Convert.ToDecimal(dtBasic.Rows[0]["Conveyance"].ToString()) +
            //    Convert.ToDecimal(dtBasic.Rows[0]["Medical"].ToString());
            //}
            //else
            //{
                decGross = Convert.ToDecimal(dtBasic.Rows[0]["BasicSal"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["HOHousing"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["HOConveyance"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["Medical"].ToString());
            //}
                txtGrossSal.Text = decGross.ToString();
        }
        else
        {
            txtBasicSalary.Text = "0";
            txtGrossSal.Text = "0";
        }

    }
    protected void ddlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
    }
}
