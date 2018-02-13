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

public partial class HomeDistrict : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    DataTable dtDistrict = new DataTable();
    dsEmpConfig objDS = new dsEmpConfig();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpadate.Value = "N";
            dtDistrict.Rows.Clear();
            dtDistrict.Dispose();
            grDistrict.DataSource = null;
            grDistrict.DataBind();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            Common.FillDropDownList(objMasMgr.SelectHomeDivision(0,"Y"), ddlDivision, "DivName", "DivID", true);
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
        dtDistrict = objMasMgr.SelectHomeDistrict(0,0,"");
        grDistrict.DataSource = dtDistrict;
        grDistrict.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        long lngID = 0;
        string strCmdType = "";
        if (IsDelete == "Y")
            strCmdType = "U";
        else
            strCmdType = hfIsUpadate.Value == "N" ? "I" : "U";
        try
        {
            MasterTablesManager MasMgr = new MasterTablesManager();
            //Filling Class Properties with values
            if (hfIsUpadate.Value == "N")
                lngID = objDB.GerMaxIDNumber("HomeDistrictList", "DistId");
            else
                lngID = Convert.ToInt32(hfID.Value);

            DataTable dtData = objDS.Tables["HomeDistrictList"];
            DataRow nRow = dtData.NewRow();

            nRow["DistId"] = lngID;
            nRow["DistName"] = txtDistrict.Text.Trim();
            nRow["HomeDivId"] = ddlDivision.SelectedValue.Trim();
            nRow["IsActive"] = ChkIsActive.Checked == true ? "N" : "Y";
            nRow["IsDeleted"] = "N";
            if (hfIsUpadate.Value == "N")
            {
                nRow["InsertedBy"] = Session["USERID"].ToString();
                nRow["InsertedDate"] = DateTime.Now.ToString();
            }
            else
            {
                nRow["UpdatedBy"] = Session["USERID"].ToString();
                nRow["UpdatedDate"] = DateTime.Now.ToString();
            }
            dtData.Rows.Add(nRow);
            dtData.AcceptChanges();

            MasMgr.SaveData(dtData, strCmdType);
           lblMsg.Text= Common.GetMessage(strCmdType);

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
        lblMsg.Text = "";
    }

    protected void grDistrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grDistrict.PageIndex = e.NewPageIndex;
        this.OpenRecord();
    }

    protected void grDistrict_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):

                txtDistrict.Text = grDistrict.SelectedRow.Cells[2].Text;
                ddlDivision.SelectedValue = grDistrict.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                ChkIsActive.Checked = grDistrict.DataKeys[_gridView.SelectedIndex].Values[1].ToString() == "N" ? true : false;
                hfID.Value = grDistrict.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                this.EntryMode(true);
                break;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfID.Value) == false)
        {
            this.SaveData("Y");
        }
        else
        {
            lblMsg.Text = "Select a District first from the list then try to delete.";
        }

        this.EntryMode(false);
    }
}
