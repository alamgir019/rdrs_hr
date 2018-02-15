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

public partial class EIS_HRAction_Transition : System.Web.UI.Page
{
    DataTable dtEmpInfo = new DataTable();
    DataTable dtTrans = new DataTable();

    MasterTablesManager objMasMgr = new MasterTablesManager();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Common.FillDropDownList_Nil(objMasMgr.SelectAction(0, "P"), ddlAction);
            Common.FillDropDownList_Nil(objMasMgr.SelectDivision(0), ddlCompany);
            Common.FillDropDownList_Nil(objMasMgr.SelectOfficeTypeList(0), ddlOffType);
            Common.FillDropDownList_Nil(objMasMgr.SelectProject(0), ddlProject);
            Common.FillDropDownList_Nil(objMasMgr.SelectDesignation(0), ddlDesignation);
            Common.FillDropDownList_Nil(objMasMgr.SelectJobTitle(0), ddlJobTitle);
            Common.FillDropDownList_Nil(objMasMgr.SelectSector(0), ddlSector);
            Common.FillDropDownList_Nil(objMasMgr.SelectDepartment(0), ddlDepartment);
            Common.FillDropDownList_Nil(objMasMgr.SelectUnit(0), ddlUnit);
            Common.FillDropDownList_Nil(objMasMgr.SelectPositionByFunction(0), ddlPosByFunction);
            Common.FillDropDownList_Nil(objMasMgr.SelectGrade(0), ddlGrade);
            Common.FillDropDownList_Nil(objMasMgr.SelectGradeLevel(0), ddlGradeLevel);
            Common.FillDropDownList_Nil(objMasMgr.SelectDivision(0), ddlDivision);
            // Common.FillDropDownList_Nil(objMasMgr.SelectDistrict(0), ddlDistrict);
            Common.FillDropDownList_Nil(objMasMgr.SelectLocation(0), ddlPostingPlace);
            Common.FillDropDownList_Nil(objMasMgr.SelectSalaryLocation(0), ddlSalaryLoc);
            Common.FillDropDownList(objMasMgr.SelectPoistingDivision(0), ddlDivision, "PostingDivName", "PostingDivId", true);
            Common.FillDropDownList(objEmpInfoMgr.SelectSupervisor(), ddlSupervisor, "EMPNAME", "EMPID", true, "Nil");
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
            lblMsg.Text = "";
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
                lblName.ToolTip = Common.DisplayDate(row["DOB"].ToString().Trim());
                lblDesignation.Text = row["DesigName"].ToString().Trim();
                lblSector.Text = row["SectorName"].ToString().Trim();
                lblDept.Text = row["DeptName"].ToString().Trim();
                lblJoinDate.Text = Common.DisplayDate(row["JoiningDate"].ToString().Trim());
                lblJoinDate.ToolTip = row["SalPakId"].ToString().Trim();

                ddlCompany.SelectedValue = Common.RetrieveddL(ddlCompany, row["DivisionId"].ToString(), "99999");
                ddlOffType.SelectedValue = Common.RetrieveddL(ddlOffType, row["OfficeTypeId"].ToString(), "99999");
                //Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(Convert.ToDecimal(ddlDesignation.SelectedValue)), ddlJobTitle);
                Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), -1), ddlOffice);
                ddlOffice.SelectedValue = Common.RetrieveddL(ddlOffice, row["OfficeId"].ToString(), "99999");

                //ddlCompany.SelectedValue = Common.RetrieveddL(ddlCompany, row["DivisionId"].ToString(), "99999");
                //Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), -1), ddlOffice);
                //ddlOffice.SelectedValue = Common.RetrieveddL(ddlOffice, row["OfficeId"].ToString(), "99999");
                ddlProject.SelectedValue = Common.RetrieveddL(ddlProject, row["ProjectId"].ToString(), "99999");
                ddlJobTitle.SelectedValue = Common.RetrieveddL(ddlJobTitle, row["JobTitleId"].ToString(), "99999");
                ddlDesignation.SelectedValue = Common.RetrieveddL(ddlDesignation, row["DesigId"].ToString(), "99999");
                ddlSector.SelectedValue = Common.RetrieveddL(ddlSector, row["SectorId"].ToString(), "99999");

                ddlDepartment.SelectedValue = Common.RetrieveddL(ddlDepartment, row["DeptId"].ToString(), "99999");
                ddlUnit.SelectedValue = Common.RetrieveddL(ddlUnit, row["UnitId"].ToString(), "99999");
                ddlGrade.SelectedValue = Common.RetrieveddL(ddlGrade, row["GradeId"].ToString(), "99999");
                ddlGradeLevel.SelectedValue = Common.RetrieveddL(ddlGradeLevel, row["GradeLevelId"].ToString(), "99999");
                ddlDivision.SelectedValue = Common.RetrieveddL(ddlDivision, row["PostingDivId"].ToString(), "99999");
                Common.FillDropDownList_Nil(objMasMgr.SelectDivisionWiseDistrict2(Convert.ToInt32(ddlDivision.SelectedValue)), ddlDistrict);
                ddlDistrict.SelectedValue = Common.RetrieveddL(ddlDistrict, row["PostingDistId"].ToString(), "99999");
                ddlSalaryLoc.SelectedValue = Common.RetrieveddL(ddlSalaryLoc, row["SalLocId"].ToString(), "99999");
               
                ddlPostingPlace.SelectedValue = Common.RetrieveddL(ddlPostingPlace, row["PostingPlaceId"].ToString(), "99999");
                ddlPosByFunction.SelectedValue = Common.RetrieveddL(ddlPosByFunction, row["PosFuncId"].ToString(), "99999");

                ddlSupervisor.SelectedValue = Common.RetrieveddL(ddlSupervisor, row["SupervisorId"].ToString(), "-1");

                txtBankAccNo.Text = row["BankAccNo"].ToString().Trim();
                txtBasicSal.Text = string.IsNullOrEmpty(row["BasicSalary"].ToString()) == true ? "" : row["BasicSalary"].ToString();
                txtBasicSal.ToolTip = row["BasicSalary"].ToString().Trim();
                txtGrossSalary.Text = string.IsNullOrEmpty(row["GrossSalary"].ToString()) == true ? "" : row["GrossSalary"].ToString();
                txtGrossSalary.ToolTip = row["GrossSalary"].ToString().Trim();

                hfDesig.Value = ddlDesignation.SelectedValue.ToString();
                hfJobTitle.Value = ddlJobTitle.SelectedValue.ToString();
                hfSector.Value = ddlSector.SelectedValue.ToString();
                hfDept.Value = ddlDepartment.SelectedValue.ToString();
                hfUnit.Value = ddlUnit.SelectedValue.ToString();
                hfGrade.Value = ddlGrade.SelectedValue.ToString();

                hfPostingDiv.Value = ddlDivision.SelectedValue.ToString();
                hfPostingDist.Value = ddlDistrict.SelectedValue.ToString();
                hfSalLoc.Value = ddlSalaryLoc.SelectedValue.ToString();

                hfPostingPlace.Value = ddlPostingPlace.SelectedValue.ToString();
                hfPosByFunction.Value = ddlPosByFunction.SelectedValue.ToString();
            }
        }
        else
        {
            lblMsg.Text = "Employee code is not valid.";
            txtEmpID.Text = "";
            lblName.Text = "";
            lblDesignation.Text = "";
            lblDept.Text = "";
            lblJoinDate.Text = "";
            return;
        }
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList_Nil(objMasMgr.SelectDivisionWiseDistrict2(Convert.ToInt32(ddlDivision.SelectedValue)), ddlDistrict);
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList_Nil(objMasMgr.GetDistrictWiseOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), -1, Convert.ToDecimal(ddlDistrict.SelectedValue.Trim())), ddlOffice);

    }
    private void OpenRecord()
    {
        grEmpTransition.Dispose();
        dtTrans = objEmpInfoMgr.SelectEmpTransitionLog(txtEmpID.Text.Trim());
        grEmpTransition.DataSource = dtTrans;
        grEmpTransition.DataBind();
        if (grEmpTransition.Rows.Count > 0)
        {
            foreach (GridViewRow gRow in grEmpTransition.Rows)
            {
                if (gRow.Cells[1].Text == "P")
                    gRow.Cells[1].Text = "Promotion";
                else if (gRow.Cells[1].Text == "T")
                    gRow.Cells[1].Text = "Transfer";
                else if (gRow.Cells[1].Text == "C")
                    gRow.Cells[1].Text = "Change In Status";
                else if (gRow.Cells[1].Text == "E")
                    gRow.Cells[1].Text = "Equity Adjustment";
                else if (gRow.Cells[1].Text == "R")
                    gRow.Cells[1].Text = "Re-Designation";
                else if (gRow.Cells[1].Text == "D")
                    gRow.Cells[1].Text = "Deputation";
                else if (gRow.Cells[1].Text == "I")
                    gRow.Cells[1].Text = "Increment";

                if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[14].Text)) == false)
                    gRow.Cells[14].Text = Common.DisplayDate(gRow.Cells[14].Text);

                if (string.IsNullOrEmpty(Common.CheckNullString(gRow.Cells[15].Text)) == false)
                    gRow.Cells[15].Text = Common.DisplayDate(gRow.Cells[15].Text);
            }
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.EntryText();
        this.EntryMode(false);
        this.ClearControls();
        lblMsg.Text = "";
    }

    protected void EntryText()
    {
        Common.EmptyTextBoxValues(this, txtEmpID);
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
            txtEntryDate.Text = Common.DisplayDate(Common.SetDate(DateTime.Today.ToShortDateString()));
        }
    }

    private void ClearControls()
    {
        txtEmpID.Text = "";
        lblName.Text = "";
        lblDesignation.Text = "";
        lblDept.Text = "";
        lblSector.Text = "";
        lblJoinDate.ToolTip = "";

        grEmpTransition.DataSource = null;
        grEmpTransition.DataBind();
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

        if ((radPromotion.Checked == false) && (radTrans.Checked == false) && (radStatus.Checked == false) && (radEquity.Checked == false)
            && (radReDesig.Checked == false) && (radDeputation.Checked == false) && (radIncrement.Checked == false))
        {
            lblMsg.Text = "Please select any transition type.";
            radPromotion.Focus();
            return false;
        }

        if (ddlAction.SelectedIndex == 0)
        {
            lblMsg.Text = "Please select an action from the list.";
            ddlAction.Focus();
            return false;
        }

        if (txtEffDate.Text == "")
        {
            lblMsg.Text = "Please select a valid effective date.";
            txtEffDate.Focus();
            return false;
        }

        return true;
    }

    private void SaveData()
    {
        dsPayroll_SalaryPackage objDs = new dsPayroll_SalaryPackage();
        Payroll_PaySlipOptionMgr objOptMgr = new Payroll_PaySlipOptionMgr();
        //string strSalPackId;

        string strTranType = "";
        if (hfIsUpdate.Value == "Y")
            hfId.Value = hfId.Value;
        else
            hfId.Value = Common.getMaxId("EmpTransitionLog", "TransId");

        string strEntryDate = "";
        string strEffDate = "";
        string strNextIncDate = "";
        string strGradeChDate = "";
        string strRetirementDate = "";

        if (string.IsNullOrEmpty(txtEntryDate.Text.Trim()) == false)
            strEntryDate = Common.ReturnDate(txtEntryDate.Text.Trim());

        if (string.IsNullOrEmpty(txtEffDate.Text.Trim()) == false)
            strEffDate = Common.ReturnDate(txtEffDate.Text.Trim());

        if (string.IsNullOrEmpty(txtNextIncDate.Text.Trim()) == false)
            strNextIncDate = Common.ReturnDate(txtNextIncDate.Text.Trim());

        if (string.IsNullOrEmpty(txtGradeChangeDate.Text.Trim()) == false)
            strGradeChDate = Common.ReturnDate(txtGradeChangeDate.Text.Trim());

         if (radPromotion.Checked == true)
            strTranType = "P";
        else if (radTrans.Checked == true)
            strTranType = "T";
        else if (radStatus.Checked == true)
            strTranType = "C";
        else if (radEquity.Checked == true)
            strTranType = "E";
         else if (radReDesig.Checked == true)
             strTranType = "R";
         else if (radDeputation.Checked == true)
             strTranType = "D";
         else if (radIncrement.Checked == true)
             strTranType = "I";

        DataTable dtBfPlc = objOptMgr.SelectPayrollBenefitsPolicyData("0");
        DataRow[] foundPlcRow;
        foundPlcRow = null;

        //Basic
        DataRow nRow1 = objDs.dtSalPackUpdate.NewRow();
        nRow1["SHEADID"] = 1;
        nRow1["PAYAMT"] = Common.RoundDecimal(txtBasicSal.Text, 0);
        objDs.dtSalPackUpdate.Rows.Add(nRow1);

        //House Rent
        foundPlcRow = dtBfPlc.Select("SHEADID=2");
        if (foundPlcRow.Length > 0)
        {
            DataRow nRow2 = objDs.dtSalPackUpdate.NewRow();

            nRow2["SHEADID"] = 2;
            nRow2["PAYAMT"] = hfHousing.Value.ToString();   

            objDs.dtSalPackUpdate.Rows.Add(nRow2);
        }
        //PF Allowance 
        //dtBfPlc = objOptMgr.SelectPayrollBenefitsPolicyData("13");
        foundPlcRow = null;

        foundPlcRow = dtBfPlc.Select("SHEADID=8");
        if (foundPlcRow.Length > 0)
        {
            DataRow nRow3 = objDs.dtSalPackUpdate.NewRow();

            nRow3["SHEADID"] = 8;
            nRow3["PAYAMT"] = objEmpInfoMgr.GetHeadAmount(Common.RoundDecimal(txtBasicSal.Text, 0), Common.RoundDecimal(foundPlcRow[0]["Value"].ToString(), 0));

            objDs.dtSalPackUpdate.Rows.Add(nRow3);
        }

        objDs.dtSalPackUpdate.AcceptChanges();

        clsEmpTransition objEmpTrans = new clsEmpTransition(hfId.Value.ToString(), txtEmpID.Text.Trim(), strEntryDate, strTranType, ddlAction.SelectedValue.ToString(),
            ddlDivision.SelectedValue.ToString(), ddlOffice.SelectedValue.ToString(), ddlDesignation.SelectedValue.ToString(), ddlJobTitle.SelectedValue.ToString(), ddlSector.SelectedValue.ToString(), ddlDepartment.SelectedValue.ToString(),
            ddlUnit.SelectedValue.ToString(), ddlGrade.SelectedValue.ToString(), ddlGradeLevel.SelectedValue.ToString(), ddlDivision.SelectedValue.ToString(), ddlDistrict.SelectedValue.ToString(),
            ddlSalaryLoc.SelectedValue.ToString(), "", ddlPostingPlace.SelectedValue.ToString(), txtBasicSal.Text.Trim(),txtGrossSalary.Text.Trim(),   
            strEffDate, strNextIncDate, (chkIsNew.Checked == true ? "Y" : "N"), txtRemarks.Text.Trim(), Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()),
            ddlPosByFunction.SelectedValue.ToString(), strGradeChDate, ddlProject.SelectedValue.ToString(), ddlSupervisor.SelectedValue.ToString(),txtBankAccNo.Text.Trim()   );

        objEmpInfoMgr.InsertEmpTransitionLog(objEmpTrans, "", hfDiv.Value.ToString(), hfOffice.Value.ToString(), hfDesig.Value.ToString(), hfJobTitle.Value.ToString(), hfSector.Value.ToString(), hfDept.Value.ToString(),
            hfUnit.Value.ToString(), hfGrade.Value.ToString(), hfGradeLevel.Value.ToString(), hfPostingDiv.Value.ToString(), hfPostingDist.Value.ToString(), hfSalLoc.Value.ToString(), "",
            hfPostingPlace.Value.ToString(), hfPosByFunction.Value.ToString(), txtBasicSal.ToolTip, txtGrossSalary.ToolTip, strEffDate, strNextIncDate, strGradeChDate, strRetirementDate, txtRemarks.Text.Trim(), hfIsUpdate.Value,
            lblJoinDate.ToolTip.ToString(), objDs.dtSalPackUpdate, hfProject.Value.ToString(), hfSuperId.Value.ToString(),hfBankAccNo.Value.ToString());
        lblMsg.Text = "Record Saved Successfully";

        this.EntryText();
        this.EntryMode(false);
        this.ClearControls();
    }

    //protected void grEmpTransition_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    GridView _gridView = (GridView)sender;
    //    int _selectedIndex = int.Parse(e.CommandArgument.ToString());
    //    string _commandName = e.CommandName;
    //    _gridView.SelectedIndex = _selectedIndex;
    //    switch (_commandName)
    //    {
    //        case ("DoubleClick"):
    //            hfId.Value = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim()) == false)
    //                ddlAction.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim()) == false)
    //                ddlDesignation.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim();
    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim()) == false)
    //                ddlJobTitle.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim();

    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim()) == false)
    //                ddlSector.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim();

    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim()) == false)
    //                ddlDepartment.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim();
    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim()) == false)
    //                ddlUnit.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim();

    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[7].ToString().Trim()) == false)
    //                ddlGrade.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[7].ToString().Trim();

    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[8].ToString().Trim()) == false)
    //                ddlDivision.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[8].ToString().Trim();

    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[9].ToString().Trim()) == false)
    //                ddlDistrict.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[9].ToString().Trim();

    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[10].ToString().Trim()) == false)
    //                ddlLocation.SelectedValue = grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[10].ToString().Trim();

    //            if (string.IsNullOrEmpty(grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim()) == false)
    //            {
    //                if (grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim() == "P")
    //                {
    //                    radPromotion.Checked = true;
    //                    radTrans.Checked = false;
    //                    radEquity.Checked = false;
    //                }
    //                else if (grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim() == "T")
    //                {
    //                    radPromotion.Checked = false;
    //                    radTrans.Checked = true;
    //                    radEquity.Checked = false;
    //                }
    //                else if (grEmpTransition.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim() == "E")
    //                {
    //                    radPromotion.Checked = false;
    //                    radTrans.Checked = false;
    //                    radEquity.Checked = true;
    //                }
    //            }

    //            txtEffDate.Text = Common.CheckNullString(grEmpTransition.SelectedRow.Cells[12].Text.Trim());
    //            txtNextIncDate.Text = Common.CheckNullString(grEmpTransition.SelectedRow.Cells[13].Text.Trim());
    //            txtBasicSal.Text = Common.CheckNullString(grEmpTransition.SelectedRow.Cells[14].Text.Trim());
    //            txtRemarks.Text = Common.CheckNullString(grEmpTransition.SelectedRow.Cells[15].Text.Trim());
    //            this.EntryMode(true);
    //            break;
    //    }
    //}    

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim())), ddlOffice);
    }
    protected void ddlOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim())), ddlOffice);
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
    }
    protected void ddlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
    }
    protected void SetBasicAndGross()
    {
        DataTable dtBasic = objEmpInfoMgr.GetGradeWiseSalaryMatrix(Convert.ToDecimal(ddlGrade.SelectedValue.Trim()), Convert.ToDecimal(ddlGradeLevel.SelectedValue.Trim()));
        decimal decGross = 0;
        if (dtBasic.Rows.Count > 0)
        {

            txtBasicSal.Text = dtBasic.Rows[0]["BasicSal"].ToString();
            if (ddlOffice.SelectedValue.Trim() != "1")
            {
                decGross = Convert.ToDecimal(dtBasic.Rows[0]["BasicSal"].ToString()) +
               Convert.ToDecimal(dtBasic.Rows[0]["Housing"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["Conveyance"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["Medical"].ToString());

                hfHousing.Value = dtBasic.Rows[0]["Housing"].ToString();                
            }
            else
            {
                decGross = Convert.ToDecimal(dtBasic.Rows[0]["BasicSal"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["HOHousing"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["HOConveyance"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["Medical"].ToString());

                hfHousing.Value = dtBasic.Rows[0]["HOHousing"].ToString();              
            }
            txtGrossSalary.Text = decGross.ToString();
        }
        else
        {
            txtBasicSal.Text = "0";
            txtGrossSalary.Text = "0";
        }

    }
    protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
    }
}
