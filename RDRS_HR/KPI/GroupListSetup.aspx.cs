﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class KPI_GroupListSetup : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    // MasterTablesManager objMasMgr = new MasterTablesManager();
    DataTable dtGroup = new DataTable();
    KPIManager objKpi = new KPIManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpdate.Value = "N";
            dtGroup.Rows.Clear();
            dtGroup.Dispose();
            grGroup.DataSource = null;
            grGroup.DataBind();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            this.OpenRecord();

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
        }
    }

    private void OpenRecord()
    {
        dtGroup = objKpi.SelectGroup(0);
        grGroup.DataSource = dtGroup;
        grGroup.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        long lngID = 0;
        try
        {

            if (hfIsUpdate.Value == "N")
                lngID = objDB.GerMaxIDNumber("KPIGroupList", "GroupId");
            else
                lngID = Convert.ToInt32(hfId.Value);

            clsCommonSetup objCommonSetup = new clsCommonSetup(lngID.ToString(), txtGroup.Text.Trim(), (chkInActive.Checked == true ? "N" : "Y"), "N",
                Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()), "N", IsDelete);

            objKpi.InsertGroup(objCommonSetup,  hfIsUpdate.Value, IsDelete);

            if (hfIsUpdate.Value == "N")
                lblMsg.Text = "Record Saved Successfully";
            else
                lblMsg.Text = "Record Updated Successfully";
            Common.EmptyTextBoxValues(this);
            this.EntryMode(false);
            this.OpenRecord();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.SaveData("N");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        this.OpenRecord();
    }

    protected void grGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grGroup.PageIndex = e.NewPageIndex;
        this.OpenRecord();
    }

    protected void grGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):

                txtGroup.Text = grGroup.SelectedRow.Cells[1].Text;
                hfId.Value = grGroup.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                this.EntryMode(true);
                break;
        }
    }

    protected void grGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfId.Value) == false)
        {
            this.SaveData("Y");
        }
        else
        {
            lblMsg.Text = "Select a Group first from the list then try to delete.";
        }

        this.EntryMode(false);
    }


}
