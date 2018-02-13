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

public partial class HomeDivision : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    DataTable dtDivision = new DataTable();
    dsEmpConfig objDS = new dsEmpConfig();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpadate.Value = "N";
            dtDivision.Rows.Clear();
            dtDivision.Dispose();
            grDivision.DataSource = null;
            grDivision.DataBind();
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
        dtDivision = objMasMgr.SelectHomeDivision(0,"");
        grDivision.DataSource = dtDivision;
        grDivision.DataBind();
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
                lngID = objDB.GerMaxIDNumber("HomeDivisionList", "DivID");
            else
                lngID = Convert.ToInt32(hfID.Value);

            DataTable dtData = objDS.Tables["HomeDivisionList"];
            DataRow nRow = dtData.NewRow();

            nRow["DivID"]=  lngID;
            nRow["DivName"]= txtDivision.Text.Trim() ;
            nRow["IsActive"] = ChkIsActive.Checked == true ? "N" : "Y";
            nRow["IsDeleted"]=  "N";
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
            lblMsg.Text = Common.GetMessage(strCmdType);
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

    protected void grDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grDivision.PageIndex = e.NewPageIndex;
        this.OpenRecord();
    }

    protected void grDivision_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):

                txtDivision.Text = grDivision.SelectedRow.Cells[1].Text;               
                ChkIsActive.Checked = grDivision.DataKeys[_gridView.SelectedIndex].Values[1].ToString() == "N" ? true : false;
                hfID.Value = grDivision.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
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
            lblMsg.Text = "Select a Division first from the list then try to delete.";
        }

        this.EntryMode(false);
    }
}
