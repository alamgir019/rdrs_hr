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

public partial class GradeSetup : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    DataTable dtGrade = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpadate.Value = "N";
            dtGrade.Rows.Clear();
            dtGrade.Dispose();
            grGrade.DataSource = null;
            grGrade.DataBind();
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
            hfIsUpadate.Value = "Y";
        }
        else
        {
            btnSave.Text = "Save";
            hfIsUpadate.Value = "N";
        }
    }

    private void OpenRecord()
    {
        dtGrade = objMasMgr.SelectGrade(0);
        grGrade.DataSource = dtGrade;
        grGrade.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        long lngID = 0;
        try
        {
            MasterTablesManager MasMgr = new MasterTablesManager();
            //Filling Class Properties with values
            if (hfIsUpadate.Value == "N")
                lngID = objDB.GerMaxIDNumber("GradeList", "GradeID");
            else
                lngID = Convert.ToInt32(hfID.Value);

            GradeEquiv objGrd = new GradeEquiv(lngID.ToString(), txtGrade.Text.Trim(), "N", Session["USERID"].ToString(),
                Common.SetDateTime(DateTime.Now.ToString()), Session["USERID"].ToString(),
                Common.SetDateTime(DateTime.Now.ToString()), "HRD", "N", "N", (chkIsActive.Checked == true ? "N" : "Y"), ddlGradeType.SelectedValue.ToString());

            MasMgr.InsertGrade(objGrd, hfIsUpadate.Value, IsDelete, (chkIsActive.Checked == true ? "N" : "Y"), "0",txtBasicMin.Text.Trim(),txtBasicMax.Text.Trim());

            if (hfIsUpadate.Value == "N")
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
        try
        {
            this.SaveData("N");
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error : " + ex.Message.ToString();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        this.OpenRecord();
    }

    protected void grGrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grGrade.PageIndex = e.NewPageIndex;
        this.OpenRecord();
    }

    protected void grGrade_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):

                txtGrade.Text = Common.CheckNullString(grGrade.SelectedRow.Cells[1].Text.Trim());
                hfID.Value = grGrade.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                ddlGradeType.SelectedValue = Common.CheckNullString(grGrade.SelectedRow.Cells[2].Text.Trim());
                chkIsActive.Checked = (grGrade.DataKeys[_gridView.SelectedIndex].Values[1].ToString() == "Y" ? false : true);               
                this.EntryMode(true);
                break;
        }
    }

    protected void grGrade_SelectedIndexChanged(object sender, EventArgs e)
    {

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
