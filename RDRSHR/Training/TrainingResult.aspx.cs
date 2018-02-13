using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Training_TrainingResult : System.Web.UI.Page
{
    TrainingManager objTrMgr = new TrainingManager();
    MasterTablesManager objTblmast = new MasterTablesManager();
    EmpInfoManager objEmp = new EmpInfoManager();
    DataTable dtList = new DataTable();
    DataTable personTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hfIsUpdate.Value = "N";
            grList.DataSource = null;
            grList.DataBind();
            Common.EmptyTextBoxValues(this);
            lblMsg.Text = "";
            this.EntryMode(false);
            this.OpenRecord();
            this.CreateTable();
            DataTable dtEmp = objEmp.SelectEmpNameWithID("A");
            Common.FillDropDownList_Nil(objTrMgr.SelectTrainingList("0"), ddlTrainingName);
            Common.FillDropDownList(dtEmp, ddlTraineeName, "EmpName", "EmpID", true);
            Common.FillDropDownList(dtEmp, ddlEvaluationBy, "EmpName", "EmpID", true);
            Common.FillDropDownList(dtEmp, ddlSignatory1, "EmpName", "EmpID", true);
            Common.FillDropDownList(dtEmp, ddlSignatory2, "EmpName", "EmpID", true);
            Common.FillDropDownList(dtEmp, ddlSignatory3, "EmpName", "EmpID", true);
        }

    }
    private void CreateTable()
    {
        //TraineeId,TraineeName,PreTest,PostTest,PracticalTest,Viva,Overall,Remarks
        personTable = new DataTable();
        personTable.Columns.AddRange(new DataColumn[8] 
                            { 
                              new DataColumn("TraineeId", typeof(string)),
                              new DataColumn("TraineeName", typeof(string)),
                              new DataColumn("PreTest", typeof(string)),
                              new DataColumn("PostTest", typeof(string)),
                              new DataColumn("PracticalTest", typeof(string)),
                              new DataColumn("Viva", typeof(string)),
                              new DataColumn("Overall", typeof(string)),
                               new DataColumn("Remark", typeof(string))
                            });
        ViewState["dt"] = personTable;
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
    private bool ValidateAndSave(string Flag)
    {
        try
        {
            lblMsg.Text = "";
            switch (Flag)
            {
                case "Save":
                    if (ddlTrainingName.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please select Training";
                        return false;
                    }
                    
                    else if (grList.Rows.Count == 0)
                    {
                        lblMsg.Text = "Please add Employee";
                        return false;
                    }
                    break;

                case "Add":
                    if (ddlTraineeName.SelectedIndex <= 0)
                    {
                        lblMsg.Text = "Please select Employee";
                        return false;
                    }
                    else if (txtPreTest.Text == "")
                    {
                        lblMsg.Text = "Please Enter Pre Test Score";
                        return false;
                    }
                    else if (txtPostTest.Text == "")
                    {
                        lblMsg.Text = "Please Enter Post Test Score";
                        return false;
                    }
                    else if (txtPracticalTest.Text == "")
                    {
                        lblMsg.Text = "Please Enter Practical Test Score";
                        return false;
                    }
                    else if (txtOverall.Text == "")
                    {
                        lblMsg.Text = "Please Enter Overall Score";
                        return false;
                    }
                    else if (txtRemarks.Text == "")
                    {
                        lblMsg.Text = "Please Enter Remarks";
                        return false;
                    }
                    else if (txtViva.Text == "")
                    {
                        lblMsg.Text = "Please Enter Viva Score";
                        return false;
                    }
                    break;
            }
            return true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
            throw (ex);
        }
    }
    private void OpenRecord()
    {
        //dtList = objEmpMgr.SelectTraining();
        grList.DataSource = null;
        grList.DataBind();
        grTrainingResult.DataSource = objTrMgr.SelectTrainingResultList("A");
        grTrainingResult.DataBind();
    }

    private void SaveData(string cmdType)
    {

        dsTraining objDS = new dsTraining();
        if (cmdType == "I")
        {
            hfId.Value = Common.getMaxId("TrTrainResult", "ResultId");
        }

        List<DataTable> tblList = new List<DataTable>();

        DataTable dtMst = objDS.Tables["TrTrainResult"];
        DataRow nRow = dtMst.NewRow();
        
        nRow["ResultId"] = Common.RoundDecimal(hfId.Value, 0);
        nRow["TrainId"] = Common.RoundDecimal(ddlTrainingName.SelectedValue.ToString().Trim(), 0);
        nRow["EvalDate"] = Common.ReturnDate(txtEvaluationDate.Text.Trim());
        nRow["EvalMethod"] = txtEvaluationMethod.Text.Trim();
        nRow["EvalBy"] = ddlEvaluationBy.SelectedValue.ToString().Trim();
        nRow["SignID1"] = ddlSignatory1.SelectedValue.ToString().Trim();
        nRow["SignID2"] = ddlSignatory2.SelectedValue.ToString().Trim();
        nRow["SignID3"] = ddlSignatory3.SelectedValue.ToString().Trim();

        if (cmdType == "I")
        {
            nRow["InsertedBy"] = Session["USERID"].ToString().Trim();
            nRow["InsertedDate"] = DateTime.Now;
        }
        else if (cmdType == "U")
        {
            nRow["UpdatedBy"] = Session["USERID"].ToString().Trim();
            nRow["UpdatedDate"] = DateTime.Now;
        }
        nRow["IsDeleted"] = cmdType == "D" ? "Y" : "N";
        nRow["IsActive"] = chkInActive.Checked == true ? "N" : "Y";

        dtMst.Rows.Add(nRow);
        dtMst.AcceptChanges();

        tblList.Add(dtMst);

        //detail table
        DataTable dtDtl = objDS.Tables["TrTrainResultDtls"];

        DataTable dtDtlInput = ViewState["dt"] as DataTable;
        int ResultDtlId = Int32.Parse(Common.getMaxId("TrTrainResultDtls", "ResultDtlId"));
        //TraineeId,TraineeName,Designation,Dept,IsResidential,Fundedby
        foreach (DataRow row in dtDtlInput.Rows)
        {
            DataRow nRowdtl = dtDtl.NewRow();
            nRowdtl["ResultDtlId"] = ResultDtlId;
            nRowdtl["ResultId"] = Common.RoundDecimal(hfId.Value, 0); ;
            nRowdtl["TraineeId"] = row["TraineeId"].ToString().Trim();
            nRowdtl["PreTest"] = row["PreTest"].ToString().Trim();
            nRowdtl["PostTest"] = row["PostTest"].ToString().Trim();
            nRowdtl["Viva"] = row["Viva"].ToString().Trim();
            nRowdtl["PostTest"] = row["PostTest"].ToString().Trim();
            nRowdtl["PracticalTest"] = row["PracticalTest"].ToString().Trim();
            nRowdtl["Overall"] = row["Overall"].ToString().Trim();
            nRowdtl["Remark"] = row["Remark"].ToString().Trim();
            nRowdtl["Overall"] = row["Overall"].ToString().Trim();
            nRowdtl["InsertedBy"] = Session["USERID"].ToString().Trim();
            nRowdtl["InsertedDate"] = DateTime.Now;

            ResultDtlId++;
            dtDtl.Rows.Add(nRowdtl);
        }

        dtDtl.AcceptChanges();
        tblList.Add(dtDtl);

        try
        {
            objTrMgr.SaveMultiTableData(tblList, cmdType == "D" ? "U" : cmdType);
            lblMsg.Text = Common.GetMessage(cmdType);
            Common.EmptyTextBoxValues(this);
            this.EntryMode(false);
            this.OpenRecord();
           //string s=string.parse(Convert.FromBase64String("WZNHp7Thsfhph2zxHz14FTd2PaSQ2rgAvoTpPtppgHjS0kfViSjeSjUuVsA8gpHS5SuDsxpJ49H6L9ISPJ574pbPin8S1"));
           
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave("Save") == false)
        {
            return;
        }

        if (hfIsUpdate.Value == "N")
        {
            this.SaveData("I");
        }
        else
        {
            this.SaveData("U");
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Common.EmptyTextBoxValues(this);
        this.EntryMode(false);
        this.OpenRecord();
        this.CreateTable();
        lblMsg.Text = "";
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(hfId.Value) == false)
        {
            this.SaveData("D");
        }
        else
        {
            lblMsg.Text = "Select a item first from the list then try to delete.";
        }

        this.EntryMode(false);
    }
    protected void grList_RowDelete(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
    }
    protected void grList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                {
                    //TraineeId,TraineeName,PreTest,PostTest,PracticalTest,Viva,Overall,Remarks
                    personTable = ViewState["dt"] as DataTable;
                    ddlTraineeName.SelectedValue = grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                    txtPreTest.Text = Math.Round(Convert.ToDecimal(Common.ReturnZeroForNull(grList.DataKeys[_gridView.SelectedIndex].Values[2].ToString().Trim()))).ToString();
                    txtPostTest.Text = Math.Round(Convert.ToDecimal(Common.ReturnZeroForNull(grList.DataKeys[_gridView.SelectedIndex].Values[3].ToString().Trim()))).ToString();
                    txtPracticalTest.Text = Math.Round(Convert.ToDecimal(Common.ReturnZeroForNull(grList.DataKeys[_gridView.SelectedIndex].Values[4].ToString().Trim()))).ToString();
                    txtViva.Text = Math.Round(Convert.ToDecimal(Common.ReturnZeroForNull(grList.DataKeys[_gridView.SelectedIndex].Values[5].ToString().Trim()))).ToString();
                    txtOverall.Text = Math.Round(Convert.ToDecimal(Common.ReturnZeroForNull(grList.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim()))).ToString();
                    txtRemarks.Text = grList.DataKeys[_gridView.SelectedIndex].Values[7].ToString();
                    DataRow[] drr = personTable.Select("TraineeId='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString() + "'");
                    for (int i = 0; i < drr.Length; i++)
                    {
                        drr[i].Delete();
                    }
                    personTable.AcceptChanges();
                    ViewState["dt"] = personTable;
                }
                break;

            case ("Delete"):
                try
                {
                    personTable = ViewState["dt"] as DataTable;
                    DataRow[] drr = personTable.Select("TraineeId='" + grList.DataKeys[_gridView.SelectedIndex].Values[0].ToString() + "'");
                    for (int i = 0; i < drr.Length; i++)
                    {
                        drr[i].Delete();
                    }
                    personTable.AcceptChanges();

                    grList.DataSource = null;
                    grList.DataBind();

                    grList.DataSource = personTable;
                    grList.DataBind();

                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Error : " + ex;
                    throw (ex);
                }
                break;
        }
    }
    protected void grTrainingResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name
        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        switch (_commandName)
        {
            case ("DoubleClick"):
                {
                    Common.EmptyTextBoxValues(this);
                    hfId.Value = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[0].ToString();
                    ddlTrainingName.SelectedValue = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[1].ToString();
                    txtEvaluationDate.Text = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[3].ToString();
                    txtEvaluationMethod.Text = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[4].ToString();
                    ddlEvaluationBy.SelectedValue = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[5].ToString();

                    ddlSignatory1.SelectedValue = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[6].ToString();
                    this.FillEmployeeInfo(grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[6].ToString().Trim(), "1");

                    ddlSignatory2.SelectedValue = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[8].ToString();
                    this.FillEmployeeInfo(grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[8].ToString().Trim(), "2");

                    ddlSignatory3.SelectedValue = grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[10].ToString();
                    this.FillEmployeeInfo(grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[10].ToString().Trim(), "3");

                    if (grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[12].ToString().Trim() == "N")
                        chkInActive.Checked = true;
                    else
                        chkInActive.Checked = false;

                    this.CreateTable();
                    personTable = objTrMgr.SelectTrainingResultDtlList(grTrainingResult.DataKeys[_gridView.SelectedIndex].Values[0].ToString());
                    ViewState["dt"]=personTable;
                    grList.DataSource = null;
                    grList.DataBind();

                    grList.DataSource=personTable;
                    grList.DataBind();
                    
                    this.EntryMode(true);
                    lblMsg.Text = "";
                }
                break;
        }
    }
    private void FillEmployeeInfo(string strEmpId,string ddlId)
    {
        DataTable dt =objTrMgr.SelectEmployeeDetail(strEmpId);
       
            if (dt.Rows.Count > 0)
            {
                switch (ddlId)
                {
                    case "1":
                        {
                            txtDesignation1.Text = dt.Rows[0]["DesigName"].ToString().Trim();
                            txtDept1.Text = dt.Rows[0]["DeptName"].ToString().Trim();
                        }
                        break;
                    case "2":
                        {
                            txtDesignation2.Text = dt.Rows[0]["DesigName"].ToString().Trim();
                            txtDept2.Text = dt.Rows[0]["DeptName"].ToString().Trim();
                        }
                        break;
                    case "3":
                        {
                            txtDesignation3.Text = dt.Rows[0]["DesigName"].ToString().Trim();
                            txtDept3.Text = dt.Rows[0]["DeptName"].ToString().Trim();
                        }
                        break;
                }
                
            }
    }
    protected void ddlSignatory1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDesignation1.Text = "";
        txtDept1.Text = "";
        if (Common.CheckNullString(ddlSignatory1.SelectedValue.ToString().Trim()) != "")
        {
            this.FillEmployeeInfo(ddlSignatory1.SelectedValue.ToString().Trim(),"1");
           
        }
    }
    protected void ddlSignatory2_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDesignation2.Text = "";
        txtDept2.Text = "";
        if (Common.CheckNullString(ddlSignatory2.SelectedValue.ToString().Trim()) != "")
        {
            this.FillEmployeeInfo(ddlSignatory2.SelectedValue.ToString().Trim(), "2");

        }
    }
    protected void ddlSignatory3_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDesignation3.Text = "";
        txtDept3.Text = "";
        if (Common.CheckNullString(ddlSignatory3.SelectedValue.ToString().Trim()) != "")
        {
            this.FillEmployeeInfo(ddlSignatory3.SelectedValue.ToString().Trim(), "3");

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ValidateAndSave("Add") == false)
        {
            return;
        }
        DataTable dt = ViewState["dt"] as DataTable;
        DataRow[] drr = dt.Select("TraineeId='" + ddlTraineeName.SelectedValue.ToString() + "'");
        for (int i = 0; i < drr.Length; i++)
        {
            drr[i].Delete();
        }
        dt.AcceptChanges();
        //TraineeId,TraineeName,PreTest,PostTest,PracticalTest,Viva,Overall,Remarks
        dt.Rows.Add(ddlTraineeName.SelectedValue.ToString(), ddlTraineeName.SelectedItem.Text.ToString(), txtPreTest.Text.ToString(), txtPostTest.Text.ToString(), txtPracticalTest.Text.ToString(), txtViva.Text.ToString(), txtOverall.Text.ToString(), txtRemarks.Text.ToString());
        grList.DataSource = dt;
        grList.DataBind();
    }
}
