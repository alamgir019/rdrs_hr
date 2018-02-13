﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EIS_Designation : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    DataTable dtDesigation = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpadate.Value = "N";
            dtDesigation.Rows.Clear();
            dtDesigation.Dispose();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            this.OpenRecord(0);
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
            TabContainer1.ActiveTabIndex = 1;
        }
    }

    private void OpenRecord(int desigId)
    {
        grJobTitle.DataSource = objMasMgr.SelectDesigWiseJobTitle(desigId);
        grJobTitle.DataBind();

        foreach (GridViewRow gRow in grJobTitle.Rows)
        {
            CheckBox chkBox = (CheckBox)gRow.FindControl("chkBox");

            if (Convert.ToDecimal(grJobTitle.DataKeys[gRow.RowIndex].Values[1]) > 0)
            {
                chkBox.Checked = true;
            }
            else
            {
                chkBox.Checked = false;
            }
        }

        grDesigation.DataSource = objMasMgr.SelectDesignation(0);
        grDesigation.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        long lngID = 0;
        try
        {
            MasterTablesManager MasMgr = new MasterTablesManager();

            if (hfIsUpadate.Value == "N")
                lngID = objDB.GerMaxIDNumber("Designation", "DesigId");
            else
                lngID = Convert.ToInt32(hfID.Value);

            Desigation objCnt = new Desigation(lngID.ToString(), txtDesigation.Text.Trim(),txtDesigShortName.Text.Trim(), "N", Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()), Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()), "HRD", "N", "N", (ChkIsActive.Checked == true ? "N" : "Y"));

            MasMgr.InsertDesignation(grJobTitle, objCnt, hfIsUpadate.Value, IsDelete, (ChkIsActive.Checked == true ? "N" : "Y"));

            if (hfIsUpadate.Value == "N")
                lblMsg.Text = "Record Saved Successfully";
            else
                lblMsg.Text = "Record Updated Successfully";
            Common.EmptyTextBoxValues(this);
            this.EntryMode(false);
            this.OpenRecord(0);
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
        this.OpenRecord(0);
        lblMsg.Text = "";
    }

    protected void grDesigation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grDesigation.PageIndex = e.NewPageIndex;
        this.OpenRecord(0);
    }

    protected void grDesigation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):


                 txtDesigation.Text = Server.HtmlDecode(Common.CheckNullString(grDesigation.SelectedRow.Cells[1].Text.Trim()));

                 txtDesigation.Text =Server.HtmlDecode( Common.CheckNullString(grDesigation.SelectedRow.Cells[1].Text.Trim() ));

                txtDesigShortName.Text = Common.CheckNullString(grDesigation.SelectedRow.Cells[2].Text.Trim());
                hfID.Value = grDesigation.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                ChkIsActive.Checked = grDesigation.DataKeys[_gridView.SelectedIndex].Values[1].ToString() == "N" ? true : false;
                this.EntryMode(true);
                this.OpenRecord(Convert.ToInt32(grDesigation.DataKeys[_gridView.SelectedIndex].Values[0].ToString()));
                TabContainer1.ActiveTabIndex = 0;
                break;
        }
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

        this.EntryMode(false);
    }
}
