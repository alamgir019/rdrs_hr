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
using System.Web.Mail;

public partial class Training_PrevTraining : System.Web.UI.Page
{
    MasterTablesManager objMasMgr = new MasterTablesManager();
   // dsEmpTraining objDsT = new dsEmpTraining();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();
    EmpTrainingManager objEmpTrainMgr = new EmpTrainingManager();
    DataTable dtEmpInfo = new DataTable();
    DataTable dtEmpTraining = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Common.FillDropDownList_Nil(objMasMgr.SelectCountry(0), ddlCountry);
            Common.FillDropDownList_Nil(objMasMgr.SelectEvent(0), ddlevent);
           

            hfIsUpadate.Value = "N";
            dtEmpTraining.Rows.Clear();
            dtEmpTraining.Dispose();
            grEmpTraining.DataSource = null;
            grEmpTraining.DataBind();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            this.OpenRecord();
        }
    }
    private void OpenRecord()
    {
        dtEmpTraining = objEmpTrainMgr.SelectEmpTraining(txtEmpID.Text ) ;
        grEmpTraining.DataSource = dtEmpTraining;
        grEmpTraining.DataBind();
        if (dtEmpTraining.Rows.Count > 0)
        {
            foreach (GridViewRow gRow in grEmpTraining.Rows)
            {
                gRow.Cells[6].Text = Common.DisplayDate(gRow.Cells[6].Text);
                gRow.Cells[7].Text = Common.DisplayDate(gRow.Cells[7].Text);
            }
            txtStartDate.Text = Common.DisplayDate(Common.SetDate(DateTime.Now.ToString()));
            txtEndDate.Text = txtStartDate.Text;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        grEmpTraining.DataSource = null;
        grEmpTraining.DataBind();
    }
    protected void cmdFind_Click(object sender, EventArgs e)
    {
        if (txtEmpID.Text.Trim() == "")
            return;

        dtEmpInfo = objEmpInfoMgr.SelectEmpInfoHR(txtEmpID.Text.Trim());
        if (dtEmpInfo.Rows.Count == 0)
        {
            lblMsg.Text = "This LB No is not vaild.";
            return;
        }
        else
        {
            lblMsg.Text = "";
            foreach (DataRow tt in dtEmpInfo.Rows)
            {
                txtEmpFullName.Text = tt["FullName"].ToString();
            }
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
            ddlevent.SelectedIndex = -1;
            ddlCountry.SelectedIndex = -1;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtDuration.Text = "0";

        }
    }

    protected void Entry()
    {
        txtDuration.Text="";
        txtTraining.Text="";
        txtVanue.Text="";
        txtOrg.Text="";
        //ddlevent.Text = "";
    }

    protected void SaveData(string IsDelete)
    {
        if ((hfIsUpadate.Value == "Y") || (IsDelete == "Y"))
            hfTrainId.Value = hfTrainId.Value;            
        else
            hfTrainId.Value = Common.getMaxId("EmpTraining", "TrainId");

        if ((string.IsNullOrEmpty(txtStartDate.Text.Trim()) == false) && (string.IsNullOrEmpty(txtEndDate.Text.Trim()) == false))
        {
            DateTime dtFrom = Convert.ToDateTime(Common.ReturnDate(txtStartDate.Text.Trim()));
            DateTime dtEnd = Convert.ToDateTime(Common.ReturnDate(txtEndDate.Text.Trim()));
            double TotDay = 0;

            TimeSpan Dur = dtEnd.Subtract(dtFrom);

            TotDay = Math.Round(Convert.ToDouble(Dur.Days), 0) + 1;
            txtDuration.Text = TotDay.ToString();
        }

        clsEmpTraining objTrain = new clsEmpTraining(txtEmpID.Text, hfTrainId.Value.ToString(), txtTraining.Text,
            txtVanue.Text, ddlCountry.SelectedValue.ToString(), (txtDuration.Text == "" ? "0" : txtDuration.Text),
            txtStartDate.Text, txtEndDate.Text, Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()),
            txtOrg.Text.Trim(),ddlevent.SelectedValue.ToString());
        EmpTrainingManager objTrainMgr = new EmpTrainingManager();
        objTrainMgr.InsertEmpTraining(objTrain, hfIsUpadate.Value, IsDelete);
        if (hfIsUpadate.Value == "N")
            lblMsg.Text = "Record Saved Successfully";
        else
            lblMsg.Text = "Record Updated Successfully";
        this.EntryMode(false);
        this.Entry();
        this.OpenRecord();
    }

    protected void grEmpTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                hfIsDelete.Value = "N";
                hfTrainId.Value = grEmpTraining.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
                txtTraining.Text = grEmpTraining.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim();
                txtVanue.Text = grEmpTraining.SelectedRow.Cells[3].Text;
                ddlCountry.SelectedValue = grEmpTraining.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim();
                txtDuration.Text = grEmpTraining.SelectedRow.Cells[5].Text; 
                txtStartDate.Text = grEmpTraining.SelectedRow.Cells[6].Text; 
                txtEndDate.Text = grEmpTraining.SelectedRow.Cells[7].Text;
                txtOrg.Text = grEmpTraining.SelectedRow.Cells[8].Text;
                ddlevent.SelectedValue = grEmpTraining.DataKeys[_gridView.SelectedIndex].Values[7].ToString().Trim();
                this.EntryMode(true);
                break;
            case ("RowDeleting"):
                hfIsDelete.Value="Y";
                hfTrainId.Value = grEmpTraining.DataKeys[_gridView.SelectedIndex].Values[1].ToString().Trim();
                EmpTrainingManager objTrainMgr =new EmpTrainingManager();
                objTrainMgr.DeleteEmpTraining (grEmpTraining.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim(),hfTrainId.Value );
                this.EntryMode(false);
                this.OpenRecord();
                break;
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.SaveData("N");
    }
    

    protected void CalculateTrainDates()
    {
        double TotDay = 0;
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();

        string strFromDate = "";
        string strToDate = "";


        strFromDate = grEmpTraining.SelectedRow.Cells[6].Text;
        strToDate = grEmpTraining.SelectedRow.Cells[7].Text;
        
        if (string.IsNullOrEmpty(strFromDate) == false
            && string.IsNullOrEmpty(strToDate) == false)
        {
            char[] splitter ={ '/' };
            string[] arinfo = Common.str_split(strFromDate, splitter);
            if (arinfo.Length == 3)
            {
                dtFrom = Convert.ToDateTime(arinfo[2] + "/" + arinfo[1] + "/" + arinfo[0]);
                arinfo = null;
            }
            arinfo = Common.str_split(strToDate, splitter);
            if (arinfo.Length == 3)
            {
                dtTo = Convert.ToDateTime(arinfo[2] + "/" + arinfo[1] + "/" + arinfo[0]);
                arinfo = null;
            }
            TimeSpan Dur = dtTo.Subtract(dtFrom);
            TotDay = Math.Round(Convert.ToDouble(Dur.Days), 0) + 1;
        }
        DateTime LDate = dtFrom;
        int row = 0;
        int TrainDay = 0;
        hfTrainDates.Value = "";
        for (row = 0; row < Convert.ToInt32(TotDay); row++)
        {
            if (hfTrainDates.Value != "")
            {
                hfTrainDates.Value = hfTrainDates.Value + ",";
            }
            TrainDay = TrainDay + 1;
            hfTrainDates.Value = hfTrainDates.Value + Common.SetDate(LDate.ToString());
            LDate = LDate.AddDays(1);
        }
    }
    protected void txtDuration_TextChanged(object sender, EventArgs e)
    {
        
    }
}
