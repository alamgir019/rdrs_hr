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

public partial class GradeMatrixSetup : System.Web.UI.Page
{
    MasterTablesManager objMasMgr = new MasterTablesManager();
    DataTable dtGradeMatrix = new DataTable();
    dsEmpConfig objDS = new dsEmpConfig();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpdate.Value = "N";
            Common.FillDropDownList_Nil(objMasMgr.SelectGrade(0), ddlGrade);
            Common.FillDropDownList_Nil(objMasMgr.SelectGradeLevel(0), ddlGradeLevel);
            dtGradeMatrix.Rows.Clear();
            dtGradeMatrix.Dispose();
            grGradeMatrix.DataSource = null;
            grGradeMatrix.DataBind();
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

        dtGradeMatrix = objMasMgr.SelectGradeSalaryMatrix(0,0,"");
        grGradeMatrix.DataSource = dtGradeMatrix;
        grGradeMatrix.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        long lngID = 0;
        try
        {
            string strId ="";
            string strCmdType = "";
            if (IsDelete == "Y")
                strCmdType = "U";
            else
                strCmdType = hfIsUpdate.Value == "N" ? "I" : "U";

            if (hfIsUpdate.Value == "N")
                strId = Common.getMaxId("GradeSalaryMatrix", "RecID");
            else
                strId = hfID.Value.ToString() ;

            DataTable dtData = objDS.Tables["GradeSalaryMatrix"];
            DataRow nRow = dtData.NewRow();

            nRow["RecID"] = Convert.ToInt32( strId);
            nRow["GradeId"] = ddlGrade.SelectedValue.ToString();
            nRow["GradeLevelId"] = ddlGradeLevel.SelectedValue.ToString();
            nRow["BasicSal"] = txtBasic.Text.Trim();
            nRow["Housing"] = txtHousing.Text.Trim();
            nRow["HOHousing"] = txtHOHousing.Text.Trim();
            nRow["Conveyance"] = txtConveyance.Text.Trim();
            nRow["HOConveyance"] = txtHOConveyance.Text.Trim();
            nRow["Medical"] = txtMedical.Text.Trim();
            nRow["IsActive"] = chkIsActive.Checked == true ? "N" : "Y";
            nRow["IsDeleted"] = "N";
            if (hfIsUpdate.Value == "N")
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

            objMasMgr.SaveData(dtData, strCmdType);
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
        lblMsg.Text = "";
    }

    protected void grGradeMatrix_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grGradeMatrix.PageIndex = e.NewPageIndex;
        this.OpenRecord();
    }

    protected void grGradeMatrix_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                hfID.Value = grGradeMatrix.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                ddlGrade.SelectedValue = grGradeMatrix.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                ddlGradeLevel.SelectedValue = grGradeMatrix.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                txtBasic.Text = Common.CheckNullString(grGradeMatrix.SelectedRow.Cells[3].Text.Trim());
                txtHousing.Text = Common.CheckNullString(grGradeMatrix.SelectedRow.Cells[4].Text.Trim());
                txtHOHousing.Text = Common.CheckNullString(grGradeMatrix.SelectedRow.Cells[5].Text.Trim());
                txtConveyance.Text = Common.CheckNullString(grGradeMatrix.SelectedRow.Cells[6].Text.Trim());
                txtHOConveyance.Text = Common.CheckNullString(grGradeMatrix.SelectedRow.Cells[7].Text.Trim());
                txtMedical.Text = Common.CheckNullString(grGradeMatrix.SelectedRow.Cells[8].Text.Trim());
                chkIsActive.Checked = ( Common.CheckNullString(grGradeMatrix.SelectedRow.Cells[9].Text.Trim()) == "Y" ? false : true);
                this.EntryMode(true);
                break;
        }
    }

    protected void grGradeMatrix_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfID.Value) == false)
        {
            this.SaveData("Y");
        }
        else
        {
            lblMsg.Text = "Select a record first from the list then try to delete.";
        }

        this.EntryMode(false);
    }
    protected void txtBasic_TextChanged(object sender, EventArgs e)
    {
        decimal dclBasic=0;
        decimal dclHouse = 0;
        decimal dclHOHouse = 0;
        if (string.IsNullOrEmpty(txtBasic.Text) == false)
        {
            dclBasic=Convert.ToDecimal(txtBasic.Text.Trim ());

            dclHouse = (dclBasic *60) / 100;
            dclHOHouse = (dclBasic * 70) / 100;

            txtHousing.Text = dclHouse.ToString();
            txtHOHousing.Text = dclHOHouse.ToString();
        }
    }
}
