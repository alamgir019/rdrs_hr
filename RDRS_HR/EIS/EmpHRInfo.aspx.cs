using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Linq;
using BaseHR.Repository;

public partial class EIS_EmpHRInfo : System.Web.UI.Page
{
    MasterTablesManager objMasMgr = new MasterTablesManager();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();
    Payroll_MasterMgr objSalaryManager = new Payroll_MasterMgr();
    Payroll_PaySlipOptionMgr objPayOptMgr = new Payroll_PaySlipOptionMgr();
    UserManager objUserMgr = new UserManager();
    ViewPermission objViewPerm = new ViewPermission();

    DataTable dtEmpInfo = new DataTable();
    DataTable dtEmpAction = new DataTable();
    DataTable dtTrainService = new DataTable();
    DataTable dtTaskPermission = new DataTable();

    decimal minSal = 0;
    decimal maxSal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable allowedInterventions = objViewPerm.ExistSelection(objMasMgr.SelectDivision(0), ViewPermission.SelectionList.Intervention, 302);
            DataTable allowedProjects = objViewPerm.ExistSelection(objMasMgr.SelectProject(0), ViewPermission.SelectionList.ProjectId, 302);
            DataTable allowedSectors = objViewPerm.ExistSelection(objMasMgr.SelectSector(0), ViewPermission.SelectionList.SectorId, 302);
            DataTable allowedGrades = objViewPerm.ExistSelection(objMasMgr.SelectGrade(0), ViewPermission.SelectionList.GradeId, 302);
            //DataTable allowedInterventions = objViewPerm.ExistSelection(objMasMgr.SelectDivision(0), ViewPermission.SelectionList.Intervention, 302);
            //DataTable allowedInterventions = objViewPerm.ExistSelection(objMasMgr.SelectDivision(0), ViewPermission.SelectionList.Intervention, 302);
            if (allowedInterventions!=null)
	        {
                Common.FillDropDownList_Nil(allowedInterventions, ddlCompany);
            }
            if (allowedProjects!=null)
            {
                Common.FillDropDownList_Nil(allowedProjects, ddlProject);
            }
            Common.FillDropDownList_Nil(objMasMgr.SelectOfficeTypeList(0), ddlOffType);
            if (allowedSectors!=null)
            {
                Common.FillDropDownList_Nil(allowedSectors, ddlSector);
            }
            Common.FillDropDownList_Nil(objMasMgr.SelectDepartment(0), ddlDept);
            Common.FillDropDownList_Nil(objMasMgr.SelectUnit(0), ddlUnit);
            Common.FillDropDownList_Nil(objMasMgr.SelectComponent(0), ddlComponent);
            Common.FillDropDownList_Nil(objMasMgr.SelectPoistingDivision(0), ddlPostDivision);
            Common.FillDropDownList_Nil(objMasMgr.SelectDivisionWiseDistrict2(Convert.ToInt32(ddlPostDivision.SelectedValue)), ddlPostDistrict);
            Common.FillDropDownList_Nil(objMasMgr.SelectLocation(0), ddlPostingPlace);
            Common.FillDropDownList_Nil(objMasMgr.SelectDesignation(0), ddlDesignation);
            Common.FillDropDownList_Nil(objMasMgr.SelectJobTitle(0), ddlJobTitle);
            Common.FillDropDownList_Nil(objMasMgr.SelectPositionByFunction(0), ddlPosByFunction);
            if (allowedGrades!=null)
            {
                Common.FillDropDownList_Nil(allowedGrades, ddlGrade);
            }
            Common.FillDropDownList_Nil(objMasMgr.SelectGradeLevel(0), ddlGradeLevel);
            Common.FillDropDownList_Nil(objMasMgr.SelectSalaryLocation(0), ddlSalaryLoc);
            Common.FillDropDownList_Nil(objMasMgr.SelectSalarySubLocation(0), ddlSalarySubLoc);
            Common.FillDropDownList_Nil(objMasMgr.SelectLeavePakMst(0), ddlLeavePackage);
            Common.FillDropDownList_Nil(objMasMgr.SelectWeekendPolicy(0), ddlWeekend);
            Common.FillDropDownList_Nil(objMasMgr.SelectAttendancePolicy(0), ddlAttndPolicy);
            Common.FillDropDownList_Nil(objMasMgr.SelectAction(0, "S"), ddlSepType);
            Common.FillDropDownList_Nil(objSalaryManager.SelectSalaryPackage(0), ddlSalaryPak);
            Common.FillDropDownList_Nil(objPayOptMgr.GetMonthlyPayrollCycleData(), ddlMPC);

            Common.FillDropDownList(objEmpInfoMgr.SelectSupervisor(), ddlSupervisor, "EMPNAME", "EMPID", true, "Nil");
            Common.FillDropDownList(objEmpInfoMgr.SelectBankList(), ddlBankName, "BankName", "BankCode", true, "Nil");
            this.GetTaskPermissionContract();
            Common.FillDropDownList_Nil(objMasMgr.SelectEmpType(0).Select("IsActive='Y'").CopyToDataTable(), ddlEmpType);
            //if (string.IsNullOrEmpty(Session["HREMPID"].ToString()) == false)
            //{
            //    txtEmpID.Text = Session["HREMPID"].ToString().Trim();
            //    this.FillEmpInfo(Session["HREMPID"].ToString().Trim());
            //}
        }
    }

    protected void SetBasicAndGross()
    {
        DataTable dtBasic = objEmpInfoMgr.GetGradeWiseSalaryMatrix(Convert.ToDecimal(ddlGrade.SelectedValue.Trim()), Convert.ToDecimal(ddlGradeLevel.SelectedValue.Trim()));
        decimal decGross = 0;
        if (dtBasic.Rows.Count > 0)
        {
            
            txtBasicSalary.Text = dtBasic.Rows[0]["BasicSal"].ToString();
            if (ddlOffice.SelectedValue.Trim() != "1")
            {
                decGross = Convert.ToDecimal(dtBasic.Rows[0]["BasicSal"].ToString()) +
               Convert.ToDecimal(dtBasic.Rows[0]["Housing"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["Conveyance"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["Medical"].ToString());
            }
            else
            {
                decGross = Convert.ToDecimal(dtBasic.Rows[0]["BasicSal"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["HOHousing"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["HOConveyance"].ToString()) +
                Convert.ToDecimal(dtBasic.Rows[0]["Medical"].ToString());
            } 
            txtGross.Text = decGross.ToString();
        }
        else
        {
            txtBasicSalary.Text = "0";
            txtGross.Text = "0";
        }

    }
    
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
    }

    protected void ddlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
    }

    protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetBasicAndGross();
        //DataTable dtDivision = objMasMgr.GetOfficeList(Convert.ToDecimal(ddlOffice.SelectedValue.Trim()), 0, 0);
        //if (dtDivision.Rows.Count > 0)
        //{
        //    ListItem lstDiv = new ListItem();
        //    lstDiv.Value = dtDivision.Rows[0]["DivID"].ToString().Trim();
        //    lstDiv.Text = dtDivision.Rows[0]["PostingDivName"].ToString().Trim();
        //    ddlPostDivision.Items.Add(lstDiv);

        //    ListItem lstDist = new ListItem();
        //    lstDist.Value = dtDivision.Rows[0]["DistId"].ToString().Trim();
        //    lstDist.Text = dtDivision.Rows[0]["PostingDistName"].ToString().Trim();
        //    ddlPostDistrict.Items.Add(lstDist);
        //}
        //else
        //{
        //    ddlPostDivision.Items.Clear();
        //    ddlPostDistrict.Items.Clear();
        //}
    }
    
    protected void cmdFind_Click(object sender, EventArgs e)
    {
        this.FillEmpInfo("");
    }

    private void FillEmpInfo(string strEmpId)
    {
        if (txtEmpID.Text.Trim() != "")
        {
            dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHR(txtEmpID.Text.Trim());
            if (dtEmpInfo.Rows.Count == 0)
            {
                lblMsg.Text = "Invalid Employee Id .";
            }
            else
            {
                //if (GetTaskPermission() == false)
                //{
                //    this.RefreshControl();
                //    lblMsg.Text = "Please mention contractual & intern staff's id.";
                //    btnSave.Enabled = false;
                //    return;
                //}



                lblMsg.Text = "";
                chkIsNew.Checked = false;
                foreach (DataRow dRow in dtEmpInfo.Rows)
                {
                    bool isPermitted = objViewPerm.GetExistPermission(dRow,302);
                    if (!isPermitted)
                    {
                        lblMsg.Text = "You have no permission to View this Employee";
                        return;
                    }
                    txtEmpFullName.Text = dRow["FullName"].ToString().Trim();
                    txtEmpFullName.ToolTip = Common.DisplayDate(dRow["DOB"].ToString().Trim());
                    ddlCompany.SelectedValue = Common.RetrieveddL(ddlCompany, dRow["DivisionId"].ToString(), "99999");
                    Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), -1), ddlOffice);

                    //DataTable allowedDivisions = objViewPerm.ExistSelection(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim())), ViewPermission.SelectionList.HeadOfficeId, 302);
                    //Common.FillDropDownList(allowedDivisions, ddlOffice, "OfficeTitleCombine", "OfficeID", true);

                    ddlOffice.SelectedValue = Common.RetrieveddL(ddlOffice, dRow["OfficeId"].ToString(), "99999");
                    ddlProject.SelectedValue = Common.RetrieveddL(ddlProject, dRow["ProjectId"].ToString(), "99999");
                    ddlSector.SelectedValue = Common.RetrieveddL(ddlSector, dRow["SectorId"].ToString(), "99999");
                    ddlDept.SelectedValue = Common.RetrieveddL(ddlDept, dRow["DeptId"].ToString(), "99999");
                    ddlUnit.SelectedValue = Common.RetrieveddL(ddlUnit, dRow["UnitId"].ToString(), "99999");
                    ddlComponent.SelectedValue = Common.RetrieveddL(ddlComponent, dRow["ComponentId"].ToString(), "99999");
                    ddlPosByFunction.SelectedValue = Common.RetrieveddL(ddlPosByFunction, dRow["PosFuncId"].ToString(), "99999");
                    ddlGrade.SelectedValue = Common.RetrieveddL(ddlGrade, dRow["GradeId"].ToString(), "99999");
                    ddlGradeLevel.SelectedValue = Common.RetrieveddL(ddlGradeLevel, dRow["GradeLevelId"].ToString(), "99999");

                    ddlDesignation.SelectedValue = Common.RetrieveddL(ddlDesignation, dRow["DesigId"].ToString(), "99999");
                    //Common.FillDropDownList_Nil(objMasMgr.SelectDesigWiseJobTitle2(Convert.ToInt32(ddlDesignation.SelectedValue)), ddlJobTitle);
                    ddlJobTitle.SelectedValue = Common.RetrieveddL(ddlJobTitle, dRow["JobTitleId"].ToString(), "99999");

                    ddlEmpType.SelectedValue = Common.RetrieveddL(ddlEmpType, dRow["EmpTypeID"].ToString(), "99999");
                    ddlEmpNature.SelectedValue = Common.RetrieveddL(ddlEmpNature, dRow["EmpNatureID"].ToString(), "99999");
                    
                    ddlPostDivision.SelectedValue = Common.RetrieveddL(ddlPostDivision, dRow["PostingDivId"].ToString(), "99999");
                    Common.FillDropDownList_Nil(objMasMgr.SelectDivisionWiseDistrict2(Convert.ToInt32(ddlPostDivision.SelectedValue)), ddlPostDistrict);
                    ddlPostDistrict.SelectedValue = Common.RetrieveddL(ddlPostDistrict, dRow["PostingDistId"].ToString(), "99999");

                    ddlPostingPlace.SelectedValue = Common.RetrieveddL(ddlPostingPlace, dRow["PostingPlaceId"].ToString(), "99999");
                    ddlSalaryLoc.SelectedValue = Common.RetrieveddL(ddlSalaryLoc, dRow["SalLocId"].ToString(), "99999");
                    
                    ddlSalarySubLoc.SelectedValue = Common.RetrieveddL(ddlSalarySubLoc, dRow["SalSubLocId"].ToString(), "99999");

                    txtBankAccNo.Text = dRow["BankAccNo"].ToString().Trim();
                    txtBasicSalary.Text = dRow["BasicSalary"].ToString().Trim();
                    txtConfirmDate.Text = string.IsNullOrEmpty(dRow["ConfirmationDate"].ToString()) == false ? Common.DisplayDate(dRow["ConfirmationDate"].ToString()) : "";
                    txtContractExpDate.Text = string.IsNullOrEmpty(dRow["ContractEndDate"].ToString()) == false ? Common.DisplayDate(dRow["ContractEndDate"].ToString()) : "";
                    txtContractInterval.Text = dRow["ContractInterval"].ToString().Trim();
                    txtContractPurpose.Text = dRow["ContractPurpose"].ToString().Trim();
                    txtDateInGrade.Text = string.IsNullOrEmpty(dRow["DateInGrade"].ToString()) == false ? Common.DisplayDate(dRow["DateInGrade"].ToString()) : "";
                    txtDateInPosition.Text = string.IsNullOrEmpty(dRow["DateInPosition"].ToString()) == false ? Common.DisplayDate(dRow["DateInPosition"].ToString()) : "";
                    txtJoiningDate.Text = string.IsNullOrEmpty(dRow["JoiningDate"].ToString()) == false ? Common.DisplayDate(dRow["JoiningDate"].ToString()) : "";
                    txtOtherBenefit.Text = dRow["OtherBenefit"].ToString().Trim();
                    txtPostingDate.Text = string.IsNullOrEmpty(dRow["PostingDate"].ToString()) == false ? Common.DisplayDate(dRow["PostingDate"].ToString()) : "";
                    txtProbationPeriod.Text = dRow["ProbationPeriod"].ToString().Trim();
                    txtRemarks.Text = dRow["Remarks"].ToString().Trim();
                    txtRetirementDate.Text = string.IsNullOrEmpty(dRow["RetirementDate"].ToString()) == false ? Common.DisplayDate(dRow["RetirementDate"].ToString()) : "";
                    if (string.IsNullOrEmpty(txtRetirementDate.Text) == true)
                    {
                        char[] splitter = { '/' };
                        string[] arinfo = Common.str_split(txtEmpFullName.ToolTip.ToString(), splitter);
                        int iBirthYear = 0;
                        string strRetirementDate = "";
                        if (arinfo.Length == 3)
                        {
                            iBirthYear = Convert.ToInt16(arinfo[2]);
                            iBirthYear = iBirthYear + 60;

                            strRetirementDate = iBirthYear + "/" + arinfo[1] + "/" + arinfo[0];
                            arinfo = null;
                        }
                        txtRetirementDate.Text = Common.DisplayDate(strRetirementDate);
                    }
                    txtSeparationDate.Text = string.IsNullOrEmpty(dRow["SeparateDate"].ToString()) == false ? Common.DisplayDate(dRow["SeparateDate"].ToString()) : "";
                    txtSeparationReason.Text = dRow["SeparateReason"].ToString().Trim();
                    //txtTrainSerEndDt.Text = string.IsNullOrEmpty(dRow["ServiceEndDate"].ToString()) == false ? Common.DisplayDate(dRow["ServiceEndDate"].ToString()) : "";
                    //txtTranSerStartDt.Text = string.IsNullOrEmpty(dRow["ServiceStartDate"].ToString()) == false ? Common.DisplayDate(dRow["ServiceStartDate"].ToString()) : "";
                    txtSeveranceId.Text = dRow["SeveranceId"].ToString().Trim();
                    txtSeveranceReason.Text = dRow["SeveranceReason"].ToString().Trim();
                    txtWorkArea.Text = dRow["WorkArea"].ToString().Trim();
                    txtActionDate.Text = string.IsNullOrEmpty(dRow["ActionDate"].ToString()) == false ? Common.DisplayDate(dRow["ActionDate"].ToString()) : "";
                    txtActionName.Text = dRow["ActionName"].ToString().Trim();
                    txtWorkingDays.Text = dRow["WorkingDays"].ToString().Trim();

                    lnkEmpCV.Text = dRow["UploadCV"].ToString().Trim();
                    lnkEmpSignature.Text = dRow["EmpSignature"].ToString().Trim();
                    lnkEmpDocument.Text = dRow["UploadDocument"].ToString().Trim();

                    //ddlBonusPak.SelectedValue = Common.RetrieveddL(ddlBonusPak, dRow["BonusPakId"].ToString(), "-1");
                    ddlBankName.SelectedValue = Common.RetrieveddL(ddlBankName, dRow["BankCode"].ToString(), "-1");
                    Common.FillDropDownList(objEmpInfoMgr.SelectBranchList(ddlBankName.SelectedValue.ToString()), ddlBranchCode, "BranchName", "Routingno", true, "Nil");
                    ddlBranchCode.SelectedValue = Common.RetrieveddL(ddlBranchCode, dRow["RoutingNo"].ToString(), "-1");
                    lblRoutingNo.Text = dRow["RoutingNo"].ToString().Trim();

                    ddlLeavePackage.SelectedValue = Common.RetrieveddL(ddlLeavePackage, dRow["LeavePakId"].ToString(), "99999");
                    hfLPakId.Value = ddlLeavePackage.SelectedValue.ToString();
                    //hfJoiningDate.Value = Common.DisplayDate(txtJoiningDate.Text);
                    ddlMPC.SelectedValue = Common.RetrieveddL(ddlMPC, dRow["MPCId"].ToString(), "99999");
                    ddlSalaryPak.SelectedValue = Common.RetrieveddL(ddlSalaryPak, dRow["SalPakId"].ToString(), "99999");

                    ddlSepType.SelectedValue = Common.RetrieveddL(ddlSepType, dRow["SeparateTypeId"].ToString(), "99999");
                    ddlStatus.SelectedValue = Common.RetrieveddL(ddlStatus, dRow["EmpStatus"].ToString(), "99999");
                    chkIsNotRehire.Checked = dRow["IsNotRehirable"].ToString() == "Y" ? true : false;
                    txtNotRehireReason.Text = dRow["NotRehireReason"].ToString().Trim();

                    ddlSupervisor.SelectedValue = Common.RetrieveddL(ddlSupervisor, dRow["SupervisorId"].ToString(), "-1");
                    txtLeaveSupervisor.Text = dRow["LeaveSupervisorId"].ToString().Trim();
                    ddlUnit.SelectedValue = Common.RetrieveddL(ddlUnit, dRow["UnitId"].ToString(), "99999");
                    ddlComponent.SelectedValue = Common.RetrieveddL(ddlComponent, dRow["ComponentId"].ToString(), "99999");
                    ddlWeekend.SelectedValue = Common.RetrieveddL(ddlWeekend, dRow["WeekendId"].ToString(), "99999");
                    ddlAttndPolicy.SelectedValue = Common.RetrieveddL(ddlWeekend, dRow["AttnPolicyID"].ToString(), "99999");

                    chkIsChildEdu.Checked = dRow["IsChildEduAllow"].ToString() == "Y" ? true : false;
                    chkIsMedicalEntitle.Checked = dRow["IsMedicalEntmnt"].ToString() == "Y" ? true : false;
                    chkIsOTEntitle.Checked = dRow["IsOTEntmnt"].ToString() == "Y" ? true : false;
                    chkIsPayrollStaff.Checked = dRow["IsPayrollStaff"].ToString() == "Y" ? true : false;
                    chkIsServiceAgrmnt.Checked = dRow["IsServiceAgrmnt"].ToString() == "Y" ? true : false;
                    chkIsSeveranceBenefit.Checked = dRow["IsSeveranceBenefit"].ToString() == "Y" ? true : false;
                    chkWorkArea.Checked = dRow["WorkAreaType"].ToString() == "Y" ? true : false;

                    dtEmpAction = objEmpInfoMgr.SelectEmpActionLog(txtEmpID.Text.Trim());
                    if (dtEmpAction.Rows.Count > 0)
                    {
                        grEmpAction.DataSource = dtEmpAction;
                        grEmpAction.DataBind();

                        foreach (GridViewRow gRow in grEmpAction.Rows)
                        {
                            gRow.Cells[1].Text = Common.DisplayDate(gRow.Cells[1].Text);
                        }
                    }

                    ddlAppointType.SelectedValue = Common.RetrieveddL(ddlAppointType, dRow["AppointType"].ToString(), "99999");
                    txtGross.Text = dRow["GrossSalary"].ToString();

                    ddlOffType.SelectedValue = Common.RetrieveddL(ddlOffType, dRow["OfficeTypeId"].ToString(), "99999");
                    //dtTrainService = objEmpInfoMgr.SelectTrainService(txtEmpID.Text.Trim(), Session["FISCALYRID"].ToString());
                    //if (dtTrainService.Rows.Count > 0)
                    //{
                    //    chkIsServiceAgrmnt.Checked = dtTrainService.Rows[0]["ServAgreement"].ToString() == "Y" ? true : false;
                    //    txtTrainSerStartDt.Text = string.IsNullOrEmpty(dtTrainService.Rows[0]["AgrStartDate"].ToString()) == false ? Common.DisplayDate(dtTrainService.Rows[0]["AgrStartDate"].ToString()) : "";
                    //    txtTrainSerEndDt.Text = string.IsNullOrEmpty(dtTrainService.Rows[0]["AgrEndDate"].ToString()) == false ? Common.DisplayDate(dtTrainService.Rows[0]["AgrEndDate"].ToString()) : "";
                    //}
                    if (Common.CheckNullString(dRow["EmpStatus"].ToString()) == "I")
                    {
                        lblMsg.Text = "This Staff Has Been Separated.";
                        txtSeparationReason.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                        lblMsg.Text = "";

                    if ((Common.CheckNullString(dRow["EmpStatus"].ToString()) == "I") && (chkIsNotRehire.Checked == true))
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        txtNotRehireReason.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        this.SaveData();
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
            if (txtEmpFullName.Text == "")
            {
                lblMsg.Text = "You have to press find button with this EmpID";
                cmdFind.Focus();
                return false;
            }
            if (ddlEmpType.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select employee type.";
                ddlEmpType.Focus();
                return false;
            }
            if (ddlEmpNature.SelectedIndex == 0)
            {
                lblMsg.Text = "Please select employee Nature.";
                ddlEmpNature.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtWorkingDays.Text.Trim()) == true)
            {
                lblMsg.Text = "Please Enter Working Day.";
                txtWorkingDays.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtBasicSalary.Text.Trim()) == true)
            {
                lblMsg.Text = "Please Enter Basic Salary.";
                txtBasicSalary.Focus();
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            lblMsg.Text = ex.Message;
            throw (ex);
        }
    }

    public void GetBasicSalaryRange(Int32 grdId)
    {
        DataTable dtGradeLevel = new DataTable();
        dtGradeLevel = objMasMgr.Select_GradeLevel_MinMaxSal(grdId);
        if (dtGradeLevel.Rows.Count > 0)
        {
            foreach (DataRow dr in dtGradeLevel.Rows)
            {
                minSal = Convert.ToDecimal(dr["Min"].ToString().Trim());
                maxSal = Convert.ToDecimal(dr["Max"].ToString().Trim());              
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        this.RefreshControl();
    }

    protected void RefreshControl()
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        grEmpAction.DataSource = null;
        grEmpAction.DataBind();
        lblMsg.Text = "";
        lblRoutingNo.Text = "";
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave() == true)
        {
            if (string.IsNullOrEmpty(txtEmpID.Text) == false)
            {
                this.SaveData();
            }
            else
            {
                lblMsg.Text = "Insert EmpID to Delete.";
            }
        }
        this.EntryMode(false);
    }
    
    private clsEmpInfoHr BindObject()
    {
        string strJoinDate = "";
        string strConfirmDate = "";
        string strContractExpDate = "";
        string strDateInGrade = "";
        string strDateInPosition = "";
        string strPostingDate = "";
        string strSeparationDate = "";
        string strRetirementDate = "";
        string strServiceStart = "";
        string strServiceEnd = "";

        if (string.IsNullOrEmpty(txtJoiningDate.Text.Trim()) == false)
            strJoinDate = Common.ReturnDate(txtJoiningDate.Text.Trim());

        if (string.IsNullOrEmpty(txtConfirmDate.Text.Trim()) == false)
            strConfirmDate = Common.ReturnDate(txtConfirmDate.Text.Trim());

        if (string.IsNullOrEmpty(txtContractExpDate.Text.Trim()) == false)
            strContractExpDate = Common.ReturnDate(txtContractExpDate.Text.Trim());

        if (string.IsNullOrEmpty(txtDateInGrade.Text.Trim()) == false)
            strDateInGrade = Common.ReturnDate(txtDateInGrade.Text.Trim());

        if (string.IsNullOrEmpty(txtDateInPosition.Text.Trim()) == false)
            strDateInPosition = Common.ReturnDate(txtDateInPosition.Text.Trim());

        if (string.IsNullOrEmpty(txtPostingDate.Text.Trim()) == false)
            strPostingDate = Common.ReturnDate(txtPostingDate.Text.Trim());

        if (string.IsNullOrEmpty(txtSeparationDate.Text.Trim()) == false)
            strSeparationDate = Common.ReturnDate(txtSeparationDate.Text.Trim());

        if (string.IsNullOrEmpty(txtTrainSerStartDt.Text.Trim()) == false)
            strServiceStart = Common.ReturnDate(txtTrainSerStartDt.Text.Trim());

        if (string.IsNullOrEmpty(txtTrainSerEndDt.Text.Trim()) == false)
            strServiceEnd = Common.ReturnDate(txtTrainSerEndDt.Text.Trim());

        if (string.IsNullOrEmpty(txtRetirementDate.Text.Trim()) == false)
            strRetirementDate = Common.ReturnDate(txtRetirementDate.Text.Trim());

        clsEmpInfoHr obj = new clsEmpInfoHr();
        obj.EmpTypeID = ddlEmpType.SelectedValue.ToString();
        obj.DivisionId = ddlCompany.SelectedValue.ToString();
        obj.OfficeId = ddlOffice.SelectedValue.ToString();
        obj.ProjectId = ddlProject.SelectedValue.ToString();
        obj.SectorId = ddlSector.SelectedValue.ToString();
        obj.DeptId = ddlDept.SelectedValue.ToString();
        obj.UnitId = ddlUnit.SelectedValue.ToString();
        obj.ComponentId = ddlComponent.SelectedValue.ToString();
        obj.PosFuncId = ddlPosByFunction.SelectedValue.ToString();
        obj.GradeId = ddlGrade.SelectedValue.ToString();
        obj.GradeLevelId = ddlGradeLevel.SelectedValue.ToString();
        obj.DesigId = ddlDesignation.SelectedValue.ToString();
        obj.JobTitleId = ddlJobTitle.SelectedValue.ToString();
        obj.PostingDistId = ddlPostDistrict.SelectedValue.ToString();
        obj.PostingDivId = ddlPostDivision.SelectedValue.ToString();
        obj.PostingPlaceId = ddlPostingPlace.SelectedValue.ToString();
        obj.SalLocId = ddlSalaryLoc.SelectedValue.ToString();
        obj.SalSubLocId = ddlSalarySubLoc.SelectedValue.ToString();

        obj.ActionDate = txtActionDate.Text.Trim();
        obj.ActionName = txtActionName.Text.Trim();
        obj.BankAccNo = txtBankAccNo.Text.Trim();
        obj.BankCode = ddlBankName.SelectedValue.ToString();
        obj.BasicSalary = txtBasicSalary.Text.Trim();
        obj.ConfirmationDate = strConfirmDate;
        obj.ContractEndDate = strContractExpDate;
        obj.ContractInterval = txtContractInterval.Text.Trim();
        obj.ContractPurpose = txtContractPurpose.Text.Trim();
        obj.DateInGrade = strDateInGrade;
        obj.DateInPosition = strDateInPosition;
        
       
        obj.EmpId = txtEmpID.Text.Trim();

        if (ddlSepType.SelectedIndex == 0)
            obj.EmpStatus = ddlStatus.SelectedValue.ToString();
        else
            obj.EmpStatus = "I";
        
        obj.EmpNatureID = ddlEmpNature.SelectedValue.ToString();
        obj.PostingDate = strPostingDate;
        obj.IsChildEduAllow = chkIsChildEdu.Checked == true ? "Y" : "N";
        obj.IsMedicalEntmnt = chkIsMedicalEntitle.Checked == true ? "Y" : "N";
        obj.IsOTEntmnt = chkIsOTEntitle.Checked == true ? "Y" : "N";
        obj.IsPayrollStaff = chkIsPayrollStaff.Checked == true ? "Y" : "N";
        obj.IsServiceAgrmnt = chkIsServiceAgrmnt.Checked == true ? "Y" : "N";
        obj.IsSeveranceBenefit = chkIsSeveranceBenefit.Checked == true ? "Y" : "N";
       
        obj.JoiningDate = strJoinDate;
        obj.MPCId = ddlMPC.SelectedValue.ToString();
        obj.OtherBenefit = txtOtherBenefit.Text.Trim();
        
        obj.ProbationPeriod = txtProbationPeriod.Text.Trim();
        obj.Remarks = txtRemarks.Text.Trim();
        obj.RetirementDate = strRetirementDate;
        obj.RoutingNo = ddlBranchCode.SelectedValue.ToString();
       
        obj.SalPakId = ddlSalaryPak.SelectedValue.ToString();
        obj.BonusPakId = "1";
      
        
        obj.SeparateDate = strSeparationDate;
        obj.SeparateReason = txtSeparationReason.Text.Trim();
        obj.SeparateTypeId = ddlSepType.SelectedValue.ToString();

        obj.ServiceEndDate = strServiceStart;
        obj.ServiceStartDate = strServiceEnd;
        obj.RetirementDate = strRetirementDate;
        obj.SeveranceId = txtSeveranceId.Text.Trim();
        obj.SeveranceReason = txtSeveranceReason.Text.Trim();
        obj.SubDesigId = ddlJobTitle.SelectedValue.ToString();
        obj.SupervisorId = ddlSupervisor.SelectedValue.ToString();
        obj.LeaveSupervisorId = txtLeaveSupervisor.Text.Trim();  
      
        if (string.IsNullOrEmpty(fileEmpCV.PostedFile.FileName) == false)
            obj.EmpCV = txtEmpID.Text.Trim() + "-" + fileEmpCV.PostedFile.FileName;
        else
            obj.EmpCV = lnkEmpCV.Text.Trim();

        if (string.IsNullOrEmpty(fileEmpSignature.PostedFile.FileName) == false)
            obj.EmpSignature = txtEmpID.Text.Trim() + "-" + fileEmpSignature.PostedFile.FileName;
        else
            obj.EmpSignature = lnkEmpSignature.Text.Trim();

        if (string.IsNullOrEmpty(fileEmpDocument.PostedFile.FileName) == false)
            obj.EmpDocument = txtEmpID.Text.Trim() + "-" + fileEmpDocument.PostedFile.FileName;
        else
            obj.EmpDocument = lnkEmpDocument.Text.Trim();

        obj.WorkArea = txtWorkArea.Text.Trim();
        obj.WorkAreaType = chkWorkArea.Checked == true ? "Y" : "N";
        // obj.BonusPakId = ddlBonusPak.SelectedValue.ToString();
        obj.LeavePakId = ddlLeavePackage.SelectedValue.ToString();
        obj.WeekendId = ddlWeekend.SelectedValue.ToString();
        obj.AttnPolicyID = ddlAttndPolicy.SelectedValue.ToString();
        obj.CardNo = Convert.ToInt32(txtEmpID.Text.Trim());
        obj.WorkingDays = txtWorkingDays.Text.Trim();
        obj.IsNotRehirable = chkIsNotRehire.Checked == true ? "Y" : "N";
        obj.NotRehireReason = txtNotRehireReason.Text.Trim();
        obj.InsertedBy = Session["USERID"].ToString();
        obj.InsertedDate = Common.SetDateTime(DateTime.Now.ToString());
        obj.Asset = txtAsset.Text.Trim();  
        obj.AppointType = ddlAppointType.SelectedValue.ToString();
        obj.GrossSalary = txtGross.Text.Trim();
        obj.OfficeTypeId = ddlOffType.SelectedValue.ToString();
        return obj;
    }

    private void SaveData()
    {
        try
        {
            string strLeaveUpdate = "";
            this.UploadCV();
            this.UploadDocument();
            this.UploadSignature();

            if (hfLPakId.Value.ToString()  == ddlLeavePackage.SelectedValue.ToString())// || (hfJoiningDate.Value == Common.DisplayDate(txtJoiningDate.Text))) //mn
                strLeaveUpdate = "N";
            else
                strLeaveUpdate = "Y";

            objEmpInfoMgr.InsertEmpInfoTabHR(this.BindObject(), strLeaveUpdate, chkIsNew.Checked == true ? "Y" : "N", Session["FISCALYRID"].ToString());

            lblMsg.Text = "Record Updated Successfully";

            this.EntryMode(false);
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }

    protected void EntryMode(bool IsUpdate)
    {
        if (IsUpdate == true)
        {
            btnSave.Text = "Update";
            hfIsUpadate.Value = "Y";
        }
        else
        {
            btnSave.Text = "Save";
            hfIsUpadate.Value = "N";
            //btnSave.Enabled = true;
            Common.EmptyTextBoxValues(this);
            txtBasicSalary.Text = "0";
            txtContractInterval.Text = "0";
            txtProbationPeriod.Text = "0";
            chkIsNew.Checked = false;
            lnkEmpCV.Text = "";
            lnkEmpSignature.Text = "";
            lnkEmpDocument.Text = "";
            grEmpAction.DataSource = null;
            grEmpAction.DataBind();
        }
    }

    protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objEmpInfoMgr.SelectBranchList(ddlBankName.SelectedValue.ToString()), ddlBranchCode, "BranchName", "Routingno", true, "Nil");
    }

    protected void txtContractInterval_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtContractInterval.Text.Trim()) == false)
        {
            DateTime dateRetirement = Convert.ToDateTime(Common.ReturnDate(txtJoiningDate.Text.Trim()));
            dateRetirement = dateRetirement.AddMonths(Convert.ToInt32(txtContractInterval.Text.Trim()));
            txtContractExpDate.Text = Common.DisplayDate(dateRetirement.ToString());
            //txtClosingDate.Text = Common.DisplayDate(dateRetirement.ToString());
        }
    }

    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Common.FillDropDownList_Nil(objMasMgr.SelectSectorWiseDepartment2(Convert.ToInt32(ddlSector.SelectedValue)), ddlDept);
    }

    protected void ddlPostDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList_Nil(objMasMgr.SelectDivisionWiseDistrict2(Convert.ToInt32(ddlPostDivision.SelectedValue)), ddlPostDistrict);
    }

    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Common.FillDropDownList_Nil(objMasMgr.SelectDesigWiseJobTitle2(Convert.ToInt32(ddlDesignation.SelectedValue)), ddlJobTitle);
    }

    private void UploadCV()
    {
        if (fileEmpCV.HasFile)
        {
            string flName = txtEmpID.Text.Trim() + "-" + fileEmpCV.PostedFile.FileName;
            string FilePath = Server.MapPath("../EmpCV" + "/" + flName);

            //Delete Existing File
            FileInfo File = new FileInfo(FilePath);
            File.Delete();

            fileEmpCV.SaveAs(FilePath);
        }
    }

    private void UploadSignature()
    {
        if (fileEmpSignature.HasFile)
        {
            string flName = txtEmpID.Text.Trim() + "-" + fileEmpSignature.PostedFile.FileName;
            string FilePath = Server.MapPath("../EmpSignature" + "/" + flName);

            //Delete Existing File
            FileInfo File = new FileInfo(FilePath);
            File.Delete();

            fileEmpSignature.SaveAs(FilePath);
        }
    }

    private void UploadDocument()
    {
        if (fileEmpDocument.HasFile)
        {
            string flName = txtEmpID.Text.Trim() + "-" + fileEmpDocument.PostedFile.FileName;
            string FilePath = Server.MapPath("../EmpDocument" + "/" + flName);

            //Delete Existing File
            FileInfo File = new FileInfo(FilePath);
            File.Delete();

            fileEmpDocument.SaveAs(FilePath);
        }
    }

    protected void lnkEmpCV_Click(object sender, EventArgs e)
    {
        string FilePath = Server.MapPath("../EmpCV" + "/" + lnkEmpCV.Text);
        System.Diagnostics.Process.Start(FilePath);
    }

    protected void lnkEmpSignature_Click(object sender, EventArgs e)
    {
        string FilePath = Server.MapPath("../EmpSignature" + "/" + lnkEmpSignature.Text);
        System.Diagnostics.Process.Start(FilePath);
    }

    protected void lnkEmpDocument_Click(object sender, EventArgs e)
    {
        string FilePath = Server.MapPath("../EmpDocument" + "/" + lnkEmpDocument.Text);
        System.Diagnostics.Process.Start(FilePath);
    }
    private void GetTaskPermissionContract()
    {
        ViewPermission userPerm = UserAccess.Access.viewPerms.Where(vv => vv.PageId == 302).FirstOrDefault();
        if (userPerm.InsertPerm == "Y")
        {
            btnSave.Enabled = true;
            lblActionName.Visible = true;
            txtActionName.Visible = true;
            lblActionDate.Visible = true;
            txtActionDate.Visible = true;
            lblSeparationReason.Visible = true;
            txtSeparationReason.Visible = true;
            chkIsNotRehire.Visible = true;
            lblNotRehireReason.Visible = true;
            txtNotRehireReason.Visible = true;
            grEmpAction.Visible = true;
            pnlLeaveAttn.Visible = true;
            pnlUploadDoc.Visible = true; 
        }
        else
        {
            btnSave.Enabled = false;
            lblActionName.Visible = false;
            txtActionName.Visible = false;
            lblActionDate.Visible = false;
            txtActionDate.Visible = false;
            lblSeparationReason.Visible = false;
            txtSeparationReason.Visible = false;
            lblNotRehireReason.Visible = false;
            txtNotRehireReason.Visible = false;
            grEmpAction.Visible = false;
            pnlLeaveAttn.Visible = false;
            pnlUploadDoc.Visible = false;
            txtBasicSalary.TextMode = TextBoxMode.Password;
            txtBasicSalary.Text = "*****";

        }
    }
    //private void GetTaskPermissionContract()
    //{
    //    DataTable dtTaskPermissionContract = objUserMgr.GetUserTaskPermission(Session["USERID"].ToString(), "302", "T101");
    //    if (dtTaskPermissionContract.Rows.Count > 0)
    //    {
    //        btnSave.Enabled = true;
    //        lblActionName.Visible = true;
    //        txtActionName.Visible = true;
    //        lblActionDate.Visible = true;
    //        txtActionDate.Visible = true;
    //        lblSeparationReason.Visible = true;
    //        txtSeparationReason.Visible = true;
    //        chkIsNotRehire.Visible = true;
    //        lblNotRehireReason.Visible = true;
    //        txtNotRehireReason.Visible = true;
    //        grEmpAction.Visible = true;
    //        pnlLeaveAttn.Visible = true;
    //        pnlUploadDoc.Visible = true;
    //    }
    //    else
    //    {
    //        btnSave.Enabled = false;
    //        lblActionName.Visible = false;
    //        txtActionName.Visible = false;
    //        lblActionDate.Visible = false;
    //        txtActionDate.Visible = false;
    //        lblSeparationReason.Visible = false;
    //        txtSeparationReason.Visible = false;
    //        lblNotRehireReason.Visible = false;
    //        txtNotRehireReason.Visible = false;
    //        grEmpAction.Visible = false;
    //        pnlLeaveAttn.Visible = false;
    //        pnlUploadDoc.Visible = false;
    //        txtBasicSalary.TextMode = TextBoxMode.Password;
    //        txtBasicSalary.Text = "*****";
    //    }
    //}
    //private bool GetTaskPermission()
    //{
    //    string strEmpType = "";
    //    dtTaskPermission = objUserMgr.GetUserTaskPermission(Session["USERID"].ToString(), "302", "T102");
    //    if (dtTaskPermission.Rows.Count > 0)
    //    {
    //        strEmpType = objEmpInfoMgr.SelectEmpWiseContractType(txtEmpID.Text.Trim());
    //        if (strEmpType != "")
    //        {
    //            txtBasicSalary.TextMode = TextBoxMode.SingleLine;
    //            return true;
    //        }
    //        else
    //            return false;
    //    }
    //    else
    //    {
    //        dtTaskPermission = objUserMgr.GetUserTaskPermission(Session["USERID"].ToString(), "302", "T104");
    //        if (dtTaskPermission.Rows.Count > 0)
    //        {
    //            txtBasicSalary.TextMode = TextBoxMode.SingleLine;
    //        }
    //    }
    //    return true;
    //}
    protected void ddlSalaryLoc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Common.FillDropDownList_Nil(objMasMgr.SelectSectorWiseDepartment2(Convert.ToInt32(ddlCompany.SelectedValue)), ddlDept);
        Common.FillDropDownList_Nil(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim()) ), ddlOffice);
    }
    protected void ddlOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable allowedDivisions = objViewPerm.ExistSelection(objMasMgr.GetOfficeList(0, Convert.ToDecimal(ddlCompany.SelectedValue.Trim()), Convert.ToDecimal(ddlOffType.SelectedValue.Trim())), ViewPermission.SelectionList.HeadOfficeId, 302);
        Common.FillDropDownList(allowedDivisions, ddlOffice, "OfficeTitleCombine", "OfficeID", true);
    }
    protected void txtProbationPeriod_TextChanged(object sender, EventArgs e)
    {
        DateTime dateJoin = Convert.ToDateTime(Common.ReturnDate(txtJoiningDate.Text.Trim()));
        dateJoin=dateJoin.AddMonths(Convert.ToInt32(Common.RoundDecimal(txtProbationPeriod.Text.Trim(), 0)));
        txtConfirmDate.Text = Common.DisplayDate(dateJoin.ToString());
    }
}
