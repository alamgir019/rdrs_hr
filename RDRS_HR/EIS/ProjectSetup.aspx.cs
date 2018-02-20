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

public partial class EIS_ProjectSetup : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    DataTable dtCompany = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpadate.Value = "N";
            dtCompany.Rows.Clear();
            dtCompany.Dispose();
            //Common.FillDropDownList_Nil(objMasMgr.SelectWeekendPolicy(0), ddlWeekend);
            grProject.DataSource = null;
            grProject.DataBind();
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
        dtCompany = objMasMgr.SelectProject(0);
        grProject.DataSource = dtCompany;
        grProject.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        long lngID = 0;
        try
        {
            MasterTablesManager MasMgr = new MasterTablesManager();
            //Filling Class Properties with values
            if (hfIsUpadate.Value == "N")
                lngID = objDB.GerMaxIDNumber("ProjectList", "ProjectId");
            else
                lngID = Convert.ToInt32(hfID.Value);

            clsProject objPrj = new clsProject( lngID.ToString(),
                                                txtProject.Text.Trim(),
                                                txtSName.Text.Trim(),
                                                txtProjectCode.Text.Trim(),
                                               
                                                Common.ReturnDate(txtStartDate.Text.ToString()),
                                                Common.ReturnDate(txtEndDate.Text.ToString()),
                                               
                                                //ddlWeekend.SelectedItem.Value.ToString(),
                                                //ddlIncrement.SelectedItem.Value.ToString(),
                                                //ddlIncrMonth.SelectedItem.Value.ToString(),
                                                //txtIncrementYear.Text.ToString(),
                                               
                                                (chkPF.Checked == true ? "Y" : "N"),
                                                (chkGratuity.Checked == true ? "Y" : "N"),
                                                //(chkEOC.Checked == true ? "Y" : "N"),
                                                //(chkEL.Checked == true ? "Y" : "N"),
                                                //(chkInsurance.Checked == true ? "Y" : "N"),
                                                //(chkGrossSalary.Checked == true ? "Y" : "N"),
                                                //(chkBasicSalary.Checked == true ? "Y" : "N"),
                                                //(chkCore.Checked == true ? "Y" : "N"),
                                                //(chkProject.Checked == true ? "Y" : "N"),
                                                
                                                (ChkIsActive.Checked == true ? "N" : "Y"),
                                                "N",
                                                Session["USERID"].ToString(), 
                                                Common.SetDateTime(DateTime.Now.ToString()),
                                                Session["USERID"].ToString(), 
                                                Common.SetDateTime(DateTime.Now.ToString()),
                                                "RDRS"

                                                );

            MasMgr.InsertUpProject(objPrj, hfIsUpadate.Value, IsDelete);

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
        this.SaveData("N");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        this.OpenRecord();
        lblMsg.Text = "";
    }

    protected void grProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grProject.PageIndex = e.NewPageIndex;
        this.OpenRecord();
    }

    protected void grProject_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):

                                txtProject.Text=grProject.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                                txtProjectCode.Text=grProject.DataKeys[_gridView.SelectedIndex].Values[2].ToString();
                                               
                                txtStartDate.Text=Common.DisplayDate(grProject.DataKeys[_gridView.SelectedIndex].Values[3].ToString());
                                txtEndDate.Text=Common.DisplayDate(grProject.DataKeys[_gridView.SelectedIndex].Values[4].ToString());
                                               
                                //ddlWeekend.SelectedValue=grProject.DataKeys[_gridView.SelectedIndex].Values[5].ToString();
                                //ddlIncrement.SelectedValue=grProject.DataKeys[_gridView.SelectedIndex].Values[6].ToString();
                                //ddlIncrMonth.SelectedValue=grProject.DataKeys[_gridView.SelectedIndex].Values[7].ToString();
                                //txtIncrementYear.Text=grProject.DataKeys[_gridView.SelectedIndex].Values[8].ToString();
                                               
                                chkPF.Checked=grProject.DataKeys[_gridView.SelectedIndex].Values[5].ToString() == "Y" ? true : false;
                                chkGratuity.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[6].ToString() == "Y" ? true : false;
                                //chkEOC.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[11].ToString() == "Y" ? true : false;
                                //chkEL.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[12].ToString() == "Y" ? true : false;
                                //chkInsurance.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[13].ToString() == "Y" ? true : false;
                                //chkGrossSalary.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[14].ToString() == "Y" ? true : false;
                                //chkBasicSalary.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[15].ToString() == "Y" ? true : false;
                                //chkCore.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[16].ToString() == "Y" ? true : false;
                                //chkProject.Checked =grProject.DataKeys[_gridView.SelectedIndex].Values[17].ToString() == "Y" ? true : false;
                                                
                                ChkIsActive.Checked=grProject.DataKeys[_gridView.SelectedIndex].Values[1].ToString() == "N" ? true : false;
                                hfID.Value = grProject.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                                txtSName.Text = grProject.DataKeys[_gridView.SelectedIndex].Values[7].ToString();
                
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
