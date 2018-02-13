using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Base.Security.Models;
using Base.Security.DAL;
using Base.Security.DATA;

public partial class Security_UserPrivilege : System.Web.UI.Page
{
    UserManager objUserMgr = new UserManager();
    //DataTable dtList = null;
    MasterTablesManager objMasMgr = new MasterTablesManager();
    //DataTable permissionTable;
    List<UserPriv> lstPriv = new List<UserPriv>();
    UserPriv objPriv = null;
    DUserPrivilege objUserPriv = new DUserPrivilege();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //hfIsUpdate.Value = "N";
            ViewState["lstPriv"] = null;
            //dtList.Rows.Clear();
            //dtList.Dispose();
            grList.DataSource = null;
            grList.DataBind();
            //Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            //this.OpenRecord();
            DataTable dtUser=objUserMgr.SelectUserInfo("", "Y");
            Common.FillDropDownList(dtUser, ddlUserId, "USERID", "USERID", true);
            Common.FillDropDownList(dtUser, ddlUsers, "USERID", "USERID", true);
            Common.FillDropDownList_Nil(objMasMgr.SelectDivision(0), ddlIntervention);
            Common.FillDropDownList_Nil(objMasMgr.SelectProject(0), ddlProject);
            Common.FillDropDownList_Nil(objMasMgr.SelectSector(0), ddlSector);
            Common.FillDropDownList_Nil(objMasMgr.SelectGrade(0), ddlGrade);
            DataTable dtScreen=objUserMgr.SelectScreenInfo();
            Common.FillDropDownList(dtScreen, ddlScreen, "VIEWNAME", "VIEWID", true);
            Common.FillDropDownList(dtScreen, ddlScreens, "VIEWNAME", "VIEWID", true);
            DataTable dtUpz = new DataTable();
            Common.FillDropDownList(dtUpz, ddlUpazilla, "UpazillaName", "UpazillaID", true);

            //this.CreateTable();
        }
    }

    //private void OpenRecord()
    //{
    //    //    dtList = objEmpMgr.SelectTraining();
    //    grPrivilegeList.DataSource = null;
    //    grPrivilegeList.DataBind();
    //    objUserPriv.AddUserPrivPages(lstPriv)
    //    grPrivilegeList.DataSource = objTrMgr.SelectTrainingSetupList("A");
    //    grPrivilegeList.DataBind();
    //}
    protected void EntryMode(bool IsUpdate)
    {
        if (IsUpdate == true)
        {
            btnSave.Text = "Update";
            //hfIsUpdate.Value = "Y";
        }
        else
        {
            btnSave.Text = "Save";
            //hfIsUpdate.Value = "N";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave("Add") == false)
        {
            return;
        }
        UserPriv newPriv=this.CreateObject();
        //this.removeFromList(newPriv.UserId, newPriv.ViewId);
        if(ViewState["lstPriv"]!=null)
            lstPriv = (List < UserPriv >) ViewState["lstPriv"];
        else
        {
            lstPriv = new List<UserPriv>();
        }

        lstPriv.Add(newPriv);
        ViewState["lstPriv"] = lstPriv;
        //dt.Rows.Add(selUser,selViewId,selViewName, isView, isInsert, isDelete,selInt,selHeadOfc,selCCO,selZone,selUnit,selArea,selBran,selDist,selUpz,
        //            selProj,selGrade,selSect);

        grList.DataSource = lstPriv;
        grList.DataBind();
        hfId.Value = "";
    }
    private UserPriv CreateObject()
    {
        decimal selId = String.IsNullOrEmpty(hfId.Value)?0:Convert.ToDecimal(hfId.Value);
        string isView = chkView.Checked ? "Y" : "N";
        string isInsert = chkInsert.Checked ? "Y" : "N";
        string isDelete = chkDelete.Checked ? "Y" : "N";
        string selUser = ddlUserId.SelectedValue.ToString().Trim();
        int selViewId = Convert.ToInt32(ddlScreen.SelectedValue.Trim());
        string selViewName = ddlScreen.SelectedItem.Text.ToString().Trim();
        decimal selInt = Convert.ToDecimal(ddlIntervention.SelectedValue.Trim());
        selInt = selInt == 99999 || selInt <= 0 ? -1 : selInt;
        decimal selHeadOfc = ddlHeadOffice.Items.Count > 0 ? Convert.ToDecimal(ddlHeadOffice.SelectedValue.Trim()) : -1;
        decimal selCCO = ddlCCO.Items.Count > 0 ? Convert.ToDecimal(ddlCCO.SelectedValue.Trim()) : -1;
        decimal selZone = ddlZone.Items.Count > 0 ? Convert.ToDecimal(ddlZone.SelectedValue.Trim()) : -1;
        decimal selUnit = ddlUnit.Items.Count > 0 ? Convert.ToDecimal(ddlUnit.SelectedValue.Trim()) : -1;
        decimal selArea = ddlArea.Items.Count > 0 ? Convert.ToDecimal(ddlArea.SelectedValue.Trim()) : -1;
        decimal selBran = ddlBranch.Items.Count > 0 ? Convert.ToDecimal(ddlBranch.SelectedValue.Trim()) : -1;
        decimal selDist = ddlDistrict.Items.Count > 0 ? Convert.ToDecimal(ddlDistrict.SelectedValue.Trim()) : -1;
        decimal selUpz = Convert.ToDecimal(ddlUpazilla.SelectedValue.Trim());
        decimal selProj = Convert.ToDecimal(ddlProject.SelectedValue.Trim());
        decimal selGrade = Convert.ToDecimal(ddlGrade.SelectedValue.Trim());
        decimal selSect = Convert.ToDecimal(ddlSector.SelectedValue.Trim());

        objPriv = new UserPriv();
        objPriv.ID = selId;
        objPriv.AreaId = selArea;
        objPriv.BranchId = selBran;
        objPriv.CCOId = selCCO;
        objPriv.DeletePerm = isDelete;
        objPriv.DistrictId = selDist;
        objPriv.GradeId = selGrade;
        objPriv.HeadOfficeId = selHeadOfc;
        objPriv.InsertPerm = isInsert;
        objPriv.InsertedBy = Session["USERID"].ToString();
        objPriv.InsertedDate = DateTime.Now;
        objPriv.InterventionId = selInt;
        objPriv.ProjectId = selProj;
        objPriv.SectorId = selSect;
        objPriv.UnitId = selUnit;
        objPriv.UpazillaId = selUpz;
        objPriv.UserId = selUser;
        objPriv.ViewId = selViewId;
        objPriv.PageName = selViewName;
        objPriv.ViewPerm = isView;
        objPriv.ZoneId = selZone;
        return objPriv;
    }
    protected void btnView_Click(object sender, EventArgs e) 
    {
        if (ValidateAndSave("View") == false)
        {
            return;
        }
        objPriv = new UserPriv();
        objPriv.UserId = ddlUsers.SelectedValue.ToString().Trim();
        objPriv.ViewId = Convert.ToInt32(ddlScreens.SelectedValue.Trim());
        //    dtList = objEmpMgr.SelectTraining();
        grPrivilegeList.DataSource = null;
        grPrivilegeList.DataBind();
        lstPriv = objUserPriv.GetUserPrivPages(objPriv);
        ViewState["grPrivilegeList"] = lstPriv;
        grPrivilegeList.DataSource = lstPriv;
        grPrivilegeList.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave("Save") == false)
        { 
            return; 
        }
        lstPriv = (List<UserPriv>)ViewState["lstPriv"];
        if (objUserPriv.AddUserPrivPages(lstPriv))
            lblMsg.Text = "Data Saved Successfully";
        else
            lblMsg.Text = "Data did not Saved";
        
        ViewState["lstPriv"] = null;
        grList.DataSource = null;
        grList.DataBind();
        Common.EmptyTextBoxValues(this);
    }
        
    private bool ValidateAndSave(string Flag)
    {
        try
        {
            lblMsg.Text = "";
            switch (Flag)
            {
                case "Save":
                    if (grList.Rows.Count <= 0)
                    {
                        lblMsg.Text = "Please Add User Permissions";
                        return false;
                    }
                    break;
                case "Add":
                    if (ddlUserId.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please select User";
                        return false;
                    }

                    if (ddlScreen.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please Select Screen";
                        return false;
                    }
                    break;
                case "View":
                    if (ddlUsers.SelectedIndex<=0)
                    {
                        lblViewMsg.Text = "Please select User";
                        return false;
                    }
                    //if (ddlScreens.SelectedIndex <= 0)
                    //{
                    //    lblViewMsg.Text = "Please Select Screen";
                    //    return false;
                    //}
                    break;
            }
            return true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
    }
    protected void ddlIntervention_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), 0), ddlHeadOffice, "OfficeTitle", "OfficeID", true);
        ddlCCO.Items.Clear();
        ddlZone.Items.Clear();
        ddlUnit.Items.Clear();
        ddlDistrict.Items.Clear();
        ddlArea.Items.Clear();
        ddlBranch.Items.Clear();

        TabContainer1.ActiveTabIndex=0;
    }
    protected void ddlHeadOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlHeadOffice.SelectedValue.Trim())), ddlCCO, "OfficeTitle", "OfficeID", true);
        ddlZone.Items.Clear();
        ddlUnit.Items.Clear();
        ddlDistrict.Items.Clear();
        ddlArea.Items.Clear();
        ddlBranch.Items.Clear();
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void ddlCCO_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlCCO.SelectedValue.Trim())), ddlZone, "OfficeTitle", "OfficeID", true);
        ddlUnit.Items.Clear();
        ddlDistrict.Items.Clear();
        ddlArea.Items.Clear();
        ddlBranch.Items.Clear();
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlZone.SelectedValue.Trim())), ddlUnit, "OfficeTitle", "OfficeID", true);
        ddlDistrict.Items.Clear();
        ddlArea.Items.Clear();
        ddlBranch.Items.Clear();
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlUnit.SelectedValue.Trim())), ddlDistrict, "OfficeTitle", "OfficeID", true);
        ddlArea.Items.Clear();
        ddlBranch.Items.Clear();
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlDistrict.SelectedValue.Trim())), ddlArea, "OfficeTitle", "OfficeID", true);
        ddlBranch.Items.Clear(); 
        TabContainer1.ActiveTabIndex = 0;
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlArea.SelectedValue.Trim())), ddlBranch, "OfficeTitle", "OfficeID", true);
        TabContainer1.ActiveTabIndex = 0;
    }
    //protected void grList_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    GridView _gridView = (GridView)sender;
    //    // Get the selected index and the command name
    //    int _selectedIndex = int.Parse(e.CommandArgument.ToString());
    //    string _commandName = e.CommandName;
    //    _gridView.SelectedIndex = _selectedIndex;

    //    switch (_commandName)
    //    {
    //        case ("DoubleClick"):
    //            {

    //                ddlUserId.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
    //                ddlScreen.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[1].ToString();                    
    //                chkView.Checked=grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString()=="Y"?true:false;
    //                chkInsert.Checked=grList.DataKeys[_gridView.SelectedIndex].Values[3].ToString()=="Y"?true:false;
    //                chkDelete.Checked=grList.DataKeys[_gridView.SelectedIndex].Values[4].ToString()=="Y"?true:false;
    //                ddlIntervention.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[5].ToString();
    //                Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), 0), ddlHeadOffice, "OfficeTitle", "OfficeID", true);
    //                ddlHeadOffice.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[6].ToString();
    //                Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlHeadOffice.SelectedValue.Trim())), ddlCCO, "OfficeTitle", "OfficeID", true);
    //                ddlCCO.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[7].ToString();
    //                Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlCCO.SelectedValue.Trim())), ddlZone, "OfficeTitle", "OfficeID", true);
    //                ddlZone.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[8].ToString();
    //                Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlZone.SelectedValue.Trim())), ddlUnit, "OfficeTitle", "OfficeID", true);
    //                ddlUnit.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[9].ToString();
    //                Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlUnit.SelectedValue.Trim())), ddlDistrict, "OfficeTitle", "OfficeID", true);
    //                ddlDistrict.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[12].ToString();
    //                Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlDistrict.SelectedValue.Trim())), ddlArea, "OfficeTitle", "OfficeID", true);
    //                ddlArea.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[10].ToString();
    //                Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlArea.SelectedValue.Trim())), ddlBranch, "OfficeTitle", "OfficeID", true);
    //                ddlBranch.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[11].ToString();
    //                ddlUpazilla.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[13].ToString();
    //                ddlProject.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[14].ToString();
    //                ddlGrade.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[15].ToString();
    //                ddlSector.SelectedValue=grList.DataKeys[_gridView.SelectedIndex].Values[16].ToString();
    //                ViewState["selectedPriv"] = this.CreateObject();

    //                this.removeFromList(grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString(), Convert.ToInt32(grList.DataKeys[_gridView.SelectedIndex].Values[1]));

    //            }
    //            break;

    //        case ("Delete"):
    //            try
    //            {
    //                this.removeFromList(grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString(), Convert.ToInt32(grList.DataKeys[_gridView.SelectedIndex].Values[1]));

    //                grList.DataSource = null;
    //                grList.DataBind();
    //                lstPriv = (List<UserPriv>)ViewState["lstPriv"];
    //                grList.DataSource = lstPriv;
    //                grList.DataBind();

    //            }
    //            catch (Exception ex)
    //            {
    //                lblMsg.Text = "Error : " + ex;
    //                throw (ex);
    //            }
    //            break;
    //    }
    //}
    private void removeFromList(decimal ID,List<UserPriv> privlist)
    {
        //remove from list
        //lstPriv = (List<UserPriv>)ViewState["grPrivilegeList"];
        if (privlist == null)
            return;
        UserPriv exist = privlist.Where(pp => pp.ID.Equals(ID)).FirstOrDefault();
        if (exist != null)
        {
            privlist.Remove(exist);
        }
        //ViewState["lstPriv"] = lstPriv;
    }
    protected void grList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grPrivilegeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grPrivilegeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;

        switch (_commandName)
        {
            case ("DoubleClick"):
                {
      //              ID,UserId,ViewId,PageName,ViewPerm,InsertPerm,DeletePerm
      //,InterventionId,HeadOfficeId,CCOId,ZoneId,UnitId,AreaId,BranchId,DistrictId,UpazillaId,ProjectId,GradeId,SectorId
                    hfId.Value = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                    ddlUserId.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
                    ddlScreen.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                    chkView.Checked = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[4].ToString() == "Y" ? true : false;
                    chkInsert.Checked = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[5].ToString() == "Y" ? true : false;
                    chkDelete.Checked = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[6].ToString() == "Y" ? true : false;
                    ddlIntervention.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[7].ToString();
                    Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), 0), ddlHeadOffice, "OfficeTitle", "OfficeID", true);
                    ddlHeadOffice.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[8].ToString();
                    Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlHeadOffice.SelectedValue.Trim())), ddlCCO, "OfficeTitle", "OfficeID", true);
                    ddlCCO.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[9].ToString();
                    Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlCCO.SelectedValue.Trim())), ddlZone, "OfficeTitle", "OfficeID", true);
                    ddlZone.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[10].ToString();
                    Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlZone.SelectedValue.Trim())), ddlUnit, "OfficeTitle", "OfficeID", true);
                    ddlUnit.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[11].ToString();
                    Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlUnit.SelectedValue.Trim())), ddlDistrict, "OfficeTitle", "OfficeID", true);
                    ddlDistrict.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[14].ToString();
                    Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlDistrict.SelectedValue.Trim())), ddlArea, "OfficeTitle", "OfficeID", true);
                    ddlArea.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[12].ToString();
                    Common.FillDropDownList(objMasMgr.GetParentWiseOffice(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlArea.SelectedValue.Trim())), ddlBranch, "OfficeTitle", "OfficeID", true);
                    ddlBranch.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[13].ToString();
                    ddlUpazilla.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[15].ToString();
                    string tt= grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[16].ToString();
                    ddlProject.SelectedValue = tt;// grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[16].ToString();
                    ddlGrade.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[17].ToString();
                    ddlSector.SelectedValue = grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[18].ToString();
                    //this.removeFromList(grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[0].ToString(), Convert.ToInt32(grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[1]));
                    grList.DataSource = null;
                    grList.DataBind();
                    ViewState["grPrivilegeList"] = null;
                    this.EntryMode(false);
                    lblMsg.Text = "";
                    TabContainer1.ActiveTabIndex = 0;
                }
                break;
            case ("Delete"):
                try
                {
                    decimal selId = Convert.ToDecimal(grPrivilegeList.DataKeys[_gridView.SelectedIndex].Values[0].ToString());
                    if ( objUserPriv.RemovePrivilege(selId))
                    {
                        this.removeFromList(selId, (List<UserPriv>)ViewState["grPrivilegeList"]);

                        grPrivilegeList.DataSource = null;
                        grPrivilegeList.DataBind();
                        lstPriv = (List<UserPriv>)ViewState["grPrivilegeList"];
                        grPrivilegeList.DataSource = lstPriv;
                        grPrivilegeList.DataBind();

                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error : " + ex;
                    throw (ex);
                }
                break;
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        objUserPriv.ClearCache();
    }
}