using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EIS_OfficeSetup : System.Web.UI.Page
{

    MasterTablesManager objTMM = new MasterTablesManager();
    dsEmpConfig objDS = new dsEmpConfig();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMsg.Text = "";
            this.EntryMode(false);
            Common.FillDropDownListWithAll(objTMM.GetDivision(), ddlIntervention, "DivisionName", "DivisionID");
            Common.FillDropDownList(objTMM.SelectOfficeTypeList(0), ddlOffType, "TypeNameLvl", "TypeID", true);
            Common.FillDropDownListWithAll(objTMM.SelectOfficeTypeList(Convert.ToDecimal(ddlIntervention.SelectedValue.Trim())), ddlOffTypeSearch, "TypeName", "TypeID");
            Common.FillDropDownList(objTMM.SelectHomeDivision(0,"Y"), ddlDivision, "DivName", "DivId", true);
            this.OpenRecord(0, 0, 0);
        }
    }
    private void OpenRecord(decimal officeid, decimal unit, decimal offtype)
    {
        //Common.EmptyTextBoxValues(this);
        DataTable dtList = objTMM.GetOfficeList(officeid, unit, offtype);
        grOfficeList.DataSource = dtList;
        grOfficeList.DataBind();
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList_Nil(objTMM.SelectHomeDistrict(Convert.ToInt32(ddlDivision.SelectedValue),0, "Y"), ddlDistrict);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownList_Nil(objTMM.SelectHomeUpazilla(Convert.ToInt32(ddlDistrict.SelectedValue),0,"Y"), ddlUpazila);
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

            hfID.Value = "";
            hfDivisionID.Value = "";
            txtOfficeID.Text = "";
            txtOffTitle.Text = "";
            ddlOffType.SelectedIndex = -1;
            ddlParentOff.SelectedIndex = -1;
            chkInActive.Checked = false;
        }
    }

    protected void ddlIntervention_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.FillDropDownListWithAll(objTMM.SelectOfficeTypeList(Convert.ToDecimal(ddlIntervention.SelectedValue.Trim())), ddlOffTypeSearch, "TypeName", "TypeID");
        TabContainer1.ActiveTabIndex = 1;
    }

    protected void ddlOffType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadParentOffice();
    }

    protected void LoadParentOffice()
    {
        string[] strArr = ddlOffType.SelectedItem.Text.ToString().Split('-');
        if (string.IsNullOrEmpty(strArr[1]) == false)
            Common.FillDropDownList(objTMM.SelectParentList(Convert.ToDecimal(strArr[1])), ddlParentOff, "officetitle", "officeid", true);

        hfDivisionID.Value = objTMM.GetOfficeTypeWiseDivisionID(ddlOffType.SelectedValue.Trim());

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.SaveData("N");
    }

    private void SaveData(string IsDelete)
    {
        decimal decID = 0;
        try
        {
            MasterTablesManager MasMgr = new MasterTablesManager();
            if (hfIsUpdate.Value == "N")
                decID = Convert.ToDecimal(Common.getMaxId("OfficeList", "OfficeID"));
            else
                decID = Convert.ToDecimal(hfID.Value);

            List<DataTable> dtList = new List<DataTable>();

            DataTable dtData = objDS.Tables["OfficeList"];
            DataRow nRow = dtData.NewRow();
            nRow["OfficeID"] = decID;
            nRow["OfficeTitle"] = txtOffTitle.Text.Trim();
            nRow["OfficeTypeID"] = Common.RoundDecimal(ddlOffType.SelectedItem.Value.ToString(), 0);
            if (ddlParentOff.Items.Count != 0)
                if (ddlParentOff.SelectedItem.Value.ToString() != "-1")
                {
                    nRow["ParentID"] = Common.RoundDecimal(ddlParentOff.SelectedItem.Value.ToString(), 0);
                }

            nRow["DivID"] = Common.RoundDecimal(ddlDivision.SelectedItem.Value.ToString(), 0);
            nRow["DistID"] = Common.RoundDecimal(ddlDistrict.SelectedItem.Value.ToString(), 0);
            nRow["UpzID"] = Common.RoundDecimal(ddlUpazila.SelectedItem.Value.ToString(), 0);

            nRow["IsActive"] = chkInActive.Checked == true ? 'N' : 'Y';
            nRow["IsDeleted"] = "N";
            nRow["IsPayLoc"] = chkIsPayroleLoc.Checked == true ? 'Y' : 'N';
            if (hfIsUpdate.Value == "N")
            {
                nRow["InsertedBy"] = Session["USERID"].ToString();
                nRow["InsertedDate"] = DateTime.Now;
            }
            else
            {
                nRow["UpdatedBy"] = Session["USERID"].ToString();
                nRow["UpdatedDate"] = DateTime.Now;
            }


            dtData.Rows.Add(nRow);
            dtData.AcceptChanges();
            dtList.Add(dtData);

            DataTable dtDataSalLoc = objDS.Tables["SalaryLocation"];
            DataRow nRowSal = dtDataSalLoc.NewRow();
            nRowSal["SalLocId"] = decID;
            nRowSal["SalLocName"] = txtOffTitle.Text.Trim();
            nRowSal["DivisionID"] = Common.RoundDecimal(hfDivisionID.Value, 0);
            nRowSal["IsActive"] = chkInActive.Checked == true ? 'N' : 'Y';
            nRowSal["IsDeleted"] = "Y";
            nRowSal["InsertedBy"] = Session["USERID"].ToString();
            nRowSal["InsertedDate"] = DateTime.Now;
            nRowSal["UpdatedBy"] = Session["USERID"].ToString();
            nRowSal["UpdatedDate"] = DateTime.Now;
            nRowSal["LastUpdatedFrom"] = Session["USERID"].ToString();
            if (chkIsPayroleLoc.Checked)
            {
                nRowSal["IsDeleted"] = "N";
            }
            dtDataSalLoc.Rows.Add(nRowSal);
            dtDataSalLoc.AcceptChanges();
            dtList.Add(dtDataSalLoc);
            objTMM.SaveOfficeData(dtList, hfIsUpdate.Value == "N" ? "I" : "U");
            
            lblMsg.Text = Common.GetMessage(hfIsUpdate.Value == "N" ? "I" : "U");
            this.EntryMode(false);
            this.OpenRecord(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffTypeSearch.SelectedValue.Trim()));
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        this.EntryMode(false);
        this.OpenRecord(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffTypeSearch.SelectedValue.Trim()));
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfID.Value) == false)
        {
            this.SaveData("Y");
            lblMsg.Text = "Record Deleted Successfully";
        }
        else
        {
            lblMsg.Text = "Select a record first then try to delete.";
        }
        this.OpenRecord(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffTypeSearch.SelectedValue.Trim()));
        this.EntryMode(false);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.OpenRecord(0, Convert.ToDecimal(ddlIntervention.SelectedValue.Trim()), Convert.ToDecimal(ddlOffTypeSearch.SelectedValue.Trim()));
        TabContainer1.ActiveTabIndex = 1;
    }

    protected void grOfficeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("RowEdit"):


                hfIsUpdate.Value = "Y";
                hfID.Value = grOfficeList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                txtOfficeID.Text = grOfficeList.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim();
                txtOffTitle.Text = grOfficeList.SelectedRow.Cells[1].Text;
               
                ddlOffType.SelectedValue = grOfficeList.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim();
                this.LoadParentOffice();
                if (string.IsNullOrEmpty(grOfficeList.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim()) == false)
                {
                    ddlParentOff.SelectedValue = grOfficeList.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim();
                }

                if (string.IsNullOrEmpty(grOfficeList.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim()) == false)
                {
                    ddlDivision.SelectedValue = grOfficeList.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim();
                    Common.FillDropDownList_Nil(objTMM.SelectHomeDistrict(Convert.ToInt32(ddlDivision.SelectedValue), 0, "Y"), ddlDistrict);
                }
                if (string.IsNullOrEmpty(grOfficeList.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim()) == false)
                {
                    ddlDistrict.SelectedValue = grOfficeList.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim();
                    Common.FillDropDownList_Nil(objTMM.SelectHomeUpazilla(Convert.ToInt32(ddlDistrict.SelectedValue), 0, "Y"), ddlUpazila);
                }
                if (string.IsNullOrEmpty(grOfficeList.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim()) == false)
                {
                    ddlUpazila.SelectedValue = grOfficeList.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim();
                }

                if (string.IsNullOrEmpty(grOfficeList.DataKeys[_gridView.SelectedIndex].Values[7].ToString().Trim()) == false)
                {
                    if (grOfficeList.DataKeys[_gridView.SelectedIndex].Values[7].ToString().Trim() == "Y")
                        chkIsPayroleLoc.Checked = true;
                    else
                        chkIsPayroleLoc.Checked = false;
                }

                this.EntryMode(true);

                TabContainer1.ActiveTabIndex = 0;
                break;
        }
    }
}