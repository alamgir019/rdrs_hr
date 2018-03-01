using System;
using System.Data;
using System.Web.UI.WebControls;
using BaseHR.Repository.DAL;
using BaseHR.DATA;

public partial class ComponentSetup : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    DComponent objComp = new DComponent();
    DataTable dtComp = new DataTable();
    ComponentListDTO compDto =null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpdate.Value = "N";

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
        grCmpList.DataSource = objComp.getComponents();
        grCmpList.DataBind();
    }

    private void SaveData(string IsDelete)
    {
        try
        {
            CreateObjet(IsDelete);
            objComp.AddComponent(compDto);           

            if (hfIsUpdate.Value == "N")
                lblMsg.Text = Common.GetMessage("I");
            else
                lblMsg.Text = Common.GetMessage("U");
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

    private void CreateObjet(string IsDelete)
    {
        compDto = new ComponentListDTO();

        if (IsDelete == "Y")
            compDto.IsDeleted = "Y";
        else
            compDto.IsDeleted = "N";
        if (hfIsUpdate.Value == "N")
        {
            compDto.ComponentId = 0;
            compDto.InsertedBy = Session["USERID"].ToString();
            compDto.InsertedDate = DateTime.Now;
        }
        else
        {
            compDto.ComponentId = Convert.ToDecimal(hfID.Value.ToString());
            compDto.UpdatedBy = Session["USERID"].ToString();
            compDto.UpdatedDate = DateTime.Now;
        }
        compDto.ComponentName = txtCompName.Text.Trim();
        compDto.IsActive = chkInActive.Checked ? "N" : "Y";
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfID.Value) == false)
        {
            this.SaveData("Y");
            lblMsg.Text = Common.GetMessage("D");
        }
        else
        {
            lblMsg.Text = "Select a record first then try to delete.";
        }

        this.EntryMode(false);
    }
    protected void grCmpList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                txtCompName.Text = grCmpList.SelectedRow.Cells[1].Text;
                hfID.Value = grCmpList.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                chkInActive.Checked = grCmpList.SelectedRow.Cells[2].Text == "N" ? true : false;
                this.EntryMode(true);
                this.OpenRecord();
                break;
        }
    }
}
