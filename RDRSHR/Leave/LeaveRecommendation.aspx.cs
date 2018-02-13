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
using System.Data.SqlClient;
using System.Web.Mail;
using System.Text; 

public partial class Leave_LeaveRecommendation : System.Web.UI.Page
{
    DBConnector objDB = new DBConnector();
    LeaveManager objLMgr = new LeaveManager();
    LeaveApplicationManager objLeaveMgr = new LeaveApplicationManager();
    EmpInfoManager objEmpInfoMgr = new EmpInfoManager();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    MailManagerSmtpClient objMail = new MailManagerSmtpClient();

    DataTable dtLeaveApp = new DataTable();
    DataTable dtLeaveType = new DataTable();
    DataTable dtAppType = new DataTable();
    DataTable dtEmpInfo = new DataTable();
    DataTable dtEmpLvProfile = new DataTable();
    OptionManager OptMgr = new OptionManager();

    static string optLeaveType = "";
    static int optTotalLvDays = 0;
    static int optLvExpireMonth = 0;
    static decimal PreYrLVAvail = 0;
    static double TotWeekedDay = 0;
    static string strStartDate = "";
    static string strEndDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GetRecord();
        }
    }

    protected void GetRecord()
    {
        this.OpenRecord();
        //this.FillDenyLeaveList();
        //this.FillApproveLeaveList();
        //this.TabContainer1.ActiveTabIndex = 0;
    }

    private void OpenRecord()
    {
        grLeaveApp.DataSource = null;
        grLeaveApp.DataBind();
        dtLeaveApp.Rows.Clear();
        dtLeaveApp.Dispose();

        string strStartYear = DateTime.Now.Year.ToString();
        string strStartMonth = DateTime.Now.Month.ToString();

        if (Convert.ToInt32(strStartMonth) >= 1)
        {
            strStartDate = Convert.ToString(Convert.ToInt32(strStartYear) - 1);
            strEndDate = Convert.ToString(Convert.ToInt32(strStartDate) + 2);
            strStartDate = strStartDate + "-" + "07" + "-" + "01";
            strEndDate = strEndDate + "-" + "12" + "-" + "31";
        }

        dtLeaveApp = objLeaveMgr.SelectRequestLeaveAppMstForHR("P", strStartDate, strEndDate);

        // delete where leavesupervisorid is null
        DataRow[] drow = dtLeaveApp.Select("[LeaveSupervisorId]  is NULL or [LeaveSupervisorId]=''");
        for (int i = 0; i < drow.Length; i++)
        {
            drow[i].Delete();
        }
        dtLeaveApp.AcceptChanges();

        string currentUser=Session["EMPLOYEEID"].ToString();
        if (!currentUser.Equals(""))
        {
            DataRow[] drr = dtLeaveApp.Select("LeaveSupervisorId not = '" + currentUser + "'");
            for (int i = 0; i < drr.Length; i++)
            {
                drr[i].Delete();
            }
            dtLeaveApp.AcceptChanges();
        }

        grLeaveApp.DataSource = dtLeaveApp;
        grLeaveApp.DataBind();
        this.FormatGridDate();
        dtLeaveApp.Dispose();
    }

    protected void FormatGridDate()
    {
        int SlNo = 0;
        foreach (GridViewRow gRow in grLeaveApp.Rows)
        {
            SlNo = SlNo + 1;
            gRow.Cells[0].Text = SlNo.ToString();
            gRow.Cells[1].Text = gRow.Cells[1].Text.ToUpper() + " [" + grLeaveApp.DataKeys[SlNo - 1].Values[12].ToString() + "]";
            gRow.Cells[2].Text = Common.DisplayDate(gRow.Cells[2].Text);
            gRow.Cells[4].Text = Common.DisplayDate(gRow.Cells[4].Text);
            gRow.Cells[5].Text = Common.DisplayDate(gRow.Cells[5].Text);
            gRow.Cells[6].Text = Convert.ToString(Math.Round(Convert.ToDouble(gRow.Cells[6].Text), 1));
        }
        SlNo = 0;
    }

    private void FillDenyLeaveList()
    {
        //grLeaveDeny.DataSource = null;
        //grLeaveDeny.DataBind();

        string strStartDate = DateTime.Now.Year.ToString();
        string strEndDate = Convert.ToString(Convert.ToInt32(strStartDate) + 1);

        strStartDate = strStartDate + "-" + "01" + "-" + "01";
        strEndDate = strEndDate + "-" + "12" + "-" + "31";
        DataTable dtLeaveDeny = new DataTable();
        //dtLeaveDeny = objLeaveMgr.SelectRequestLeaveAppMst(0, "", "D", strStartDate, strEndDate, Session["EMPLOYEEID"].ToString());
        if (Session["ISADMIN"].ToString() == "N")
        {
            dtLeaveDeny = objLeaveMgr.SelectRequestLeaveAppMst(0, "", "D", strStartDate, strEndDate, Session["EMPID"].ToString().Trim());
        }
        else
        {
            dtLeaveDeny = objLeaveMgr.SelectRequestLeaveAppMst(0, "", "D", strStartDate, strEndDate, "");
        }

        //grLeaveDeny.DataSource = dtLeaveDeny;
        //grLeaveDeny.DataBind();
        this.FormatDenyGridDate();
        dtLeaveDeny.Rows.Clear();
        dtLeaveDeny.Dispose();
    }

    protected void FormatDenyGridDate()
    {
        //int SlNo = 0;
        //foreach (GridViewRow gRow in grLeaveDeny.Rows)
        //{
        //    SlNo = SlNo + 1;
        //    gRow.Cells[0].Text = SlNo.ToString();
        //    gRow.Cells[1].Text = gRow.Cells[1].Text.ToUpper() + " [" + grLeaveDeny.DataKeys[SlNo - 1].Values[12].ToString() + "]";
        //    gRow.Cells[2].Text = Common.DisplayDate(gRow.Cells[2].Text);
        //    gRow.Cells[4].Text = Common.DisplayDate(gRow.Cells[4].Text);
        //    gRow.Cells[5].Text = Common.DisplayDate(gRow.Cells[5].Text);
        //    gRow.Cells[6].Text = Convert.ToString(Math.Round(Convert.ToDouble(gRow.Cells[6].Text), 1));
        //}
        //SlNo = 0;
    }

    private void FillApproveLeaveList()
    {
        //grLeaveApprove.DataSource = null;
        //grLeaveApprove.DataBind();

        string strStartDate = DateTime.Now.Year.ToString();
        string strEndDate = Convert.ToString(Convert.ToInt32(strStartDate));

        strStartDate = strStartDate + "-" + "01" + "-" + "01";
        strEndDate = strEndDate + "-" + "12" + "-" + "31";
        DataTable dtApproveLeave = new DataTable();
        //dtApproveLeave = objLeaveMgr.SelectRequestLeaveAppMst(0, "", "A", strStartDate, strEndDate, Session["EMPLOYEEID"].ToString());

        if (Session["ISADMIN"].ToString() == "N")
        {
            dtApproveLeave = objLeaveMgr.SelectRequestLeaveAppMst(0, "", "A", strStartDate, strEndDate, Session["EMPID"].ToString().Trim());
        }
        else
        {
            dtApproveLeave = objLeaveMgr.SelectRequestLeaveAppMst(0, "", "A", strStartDate, strEndDate, "");
        }
        //grLeaveApprove.DataSource = dtApproveLeave;
        //grLeaveApprove.DataBind();
        this.FormatApproveGridDate();
        dtApproveLeave.Rows.Clear();
        dtApproveLeave.Dispose();
    }

    protected void FormatApproveGridDate()
    {
        //int SlNo = 0;
        //foreach (GridViewRow gRow in grLeaveApprove.Rows)
        //{
        //    SlNo = SlNo + 1;
        //    gRow.Cells[0].Text = SlNo.ToString();
        //    gRow.Cells[1].Text = gRow.Cells[1].Text.ToUpper() + " [" + grLeaveApprove.DataKeys[SlNo - 1].Values[12].ToString() + "]";
        //    gRow.Cells[2].Text = Common.DisplayDate(gRow.Cells[2].Text);
        //    gRow.Cells[4].Text = Common.DisplayDate(gRow.Cells[4].Text);
        //    gRow.Cells[5].Text = Common.DisplayDate(gRow.Cells[5].Text);
        //    gRow.Cells[6].Text = Convert.ToString(Math.Round(Convert.ToDouble(gRow.Cells[6].Text), 1));
        //}
        //SlNo = 0;
    }

    private void AvailableLeave(string gridStatus, string strEmpID, string strLTypeID)
    {
        DataTable dtLeaveProfile = new DataTable();
        if (gridStatus == "A")
        {
            dtLeaveProfile = objLeaveMgr.SelectEmpLeaveProfile(strEmpID, strLTypeID);
            if (dtLeaveProfile.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) == false)
                    hfLEnjoyed.Value = Convert.ToString(Convert.ToDecimal(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) + Convert.ToDecimal(grLeaveApp.SelectedRow.Cells[6].Text.Trim()));
                else
                    hfLEnjoyed.Value = grLeaveApp.SelectedRow.Cells[6].Text.Trim();
            }
        }
        //else if (gridStatus == "D")
        //{
        //    dtLeaveProfile = objLeaveMgr.SelectEmpLeaveProfile(strEmpID, strLTypeID);
        //    if (dtLeaveProfile.Rows.Count > 0)
        //    {
        //        if (string.IsNullOrEmpty(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) == false)
        //            hfLEnjoyed.Value = Convert.ToString(Convert.ToDecimal(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) + Convert.ToDecimal(grLeaveDeny.SelectedRow.Cells[6].Text.Trim()));
        //        else
        //            hfLEnjoyed.Value = "0";
        //    }
        //}
    }

    private void AvailableHisLeave(string gridStatus, string strEmpID, string strLTypeID)
    {
        //DataTable dtLeaveProfile = new DataTable();
        //if (gridStatus == "A")
        //{
        //    dtLeaveProfile = objLeaveMgr.SelectEmpLeaveProfileEXCPL_History(strEmpID, strLTypeID, "01/01/2010");
        //    if (dtLeaveProfile.Rows.Count > 0)
        //    {
        //        if (string.IsNullOrEmpty(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) == false)
        //            hfLEnjoyed.Value = Convert.ToString(Convert.ToDecimal(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) + Convert.ToDecimal(grLeaveApp.SelectedRow.Cells[6].Text));
        //        else
        //            hfLEnjoyed.Value = "0";
        //    }
        //}
        //else if (gridStatus == "D")
        //{
        //    dtLeaveProfile = objLeaveMgr.SelectEmpLeaveProfile(strEmpID, strLTypeID);
        //    if (dtLeaveProfile.Rows.Count > 0)
        //    {
        //        if (string.IsNullOrEmpty(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) == false)
        //            hfLEnjoyed.Value = Convert.ToString(Convert.ToDecimal(dtLeaveProfile.Rows[0]["LeaveEnjoyed"].ToString()) + Convert.ToDecimal(grLeaveDeny.SelectedRow.Cells[6].Text));
        //        else
        //            hfLEnjoyed.Value = "0";
        //    }
        //}
    }

    protected void grLeaveApp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;
        // Get the selected index and the command name

        int _selectedIndex = int.Parse( e.CommandArgument.ToString());
        string _commandName = e.CommandName;
        _gridView.SelectedIndex = _selectedIndex;
        string strPreYrLv = "";
        switch (_commandName)
        {
            case ("ViewClick"):
                //Open New Window
                StringBuilder sb = new StringBuilder();
                string strURL = "LeaveApplicationRpt.aspx?params=" + grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[11].ToString() + "," + grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[0].ToString().Trim() + ", X";
                sb.Append("<script>");
                //sb.Append("window.open('" + strURL + "', '', 'fullscreen=true,scrollbars=yes,resizable=yes');");//
                sb.Append("window.open('" + strURL + "', '', '');");
                sb.Append("</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmSubmit",
                                         sb.ToString(), false);
                ClientScript.RegisterStartupScript(this.GetType(), "ConfirmSubmit", sb.ToString());
                break;

            case ("RecommendClick"):
                string strApprovedBy = "";
                TextBox txtApprovedBy = (TextBox)(grLeaveApp.SelectedRow.Cells[1].FindControl("txtApproverId"));
                strApprovedBy = txtApprovedBy.Text.Trim ();
                  if (String.IsNullOrEmpty(strApprovedBy))
                {
                    lblMsg.Text = "Please Insert Approved By Id";
                }
                else
                {
                    objLeaveMgr.UpdateLeaveAppMstForRecommendation(grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[0].ToString(),
                        grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim(), "R", strApprovedBy, Session["USERID"].ToString(),
                         Common.SetDateTime(DateTime.Now.ToString())); 
                }

                //////Email Notification
                ////lblMsg.Text = objMail.LeaveApprovalByHR(grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim(),
                ////    grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[0].ToString(), Session["EMPID"].ToString(), 
                ////    Session["USERNAME"].ToString(), Session["DESIGNATION"].ToString(), Session["LOCATION"].ToString(),
                ////      Session["USERID"].ToString().Trim().ToUpper() == "ADMIN" ? "Y" : "N", Session["EMAILID"].ToString());
                if (lblMsg.Text == "")
                    lblMsg.Text = "Leave has been Recommended";
                break;

            case ("DenyClick"):
               AvailableLeave("A", grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim(), grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[2].ToString());
                this.GetLeaveDates(grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[0].ToString(), "A", grLeaveApp.SelectedRow.Cells[4].Text.Trim(), grLeaveApp.SelectedRow.Cells[5].Text.Trim());
                //CalculateLeaveDates("A");
                //this.GetWeekend(grLeaveApp.SelectedRow.Cells[1].Text.Trim(), grLeaveApp.SelectedRow.Cells[4].Text.Trim(), grLeaveApp.SelectedRow.Cells[5].Text.Trim(),"A"); 
                objLeaveMgr.UpdateLeaveAppMstForDeny(grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[0].ToString(),
                    grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim(), "Y", "N", "D",
                    Session["USERID"].ToString(), Common.SetDateTime(DateTime.Now.ToString()));

                ////Email Notification
                //lblMsg.Text = objMail.LeaveRegretBySupervisor(grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[11].ToString().Trim(), 
                //    grLeaveApp.DataKeys[_gridView.SelectedIndex].Values[0].ToString(), Session["EMPID"].ToString(), 
                //    Session["USERNAME"].ToString(), Session["DESIGNATION"].ToString(), Session["LOCATION"].ToString(),
                //      Session["USERID"].ToString().Trim().ToUpper() == "ADMIN" ? "Y" : "N", Session["EMAILID"].ToString());
                //if (lblMsg.Text == "")
                    lblMsg.Text = "Leave has been Regreted Successfully.";
                    //lblMsg.Text = "Leave has been Regreted and Mailed Successfully";
                break;        
        }

        this.GetRecord();
        strPreYrLv = "";
    }

    protected bool CheckPreYrLvBalance()
    {
        DateTime dtCurrdt = Convert.ToDateTime(Common.SetDate(DateTime.Now.ToString()));
        DateTime dtLvStartdt = Convert.ToDateTime(grLeaveApp.SelectedRow.Cells[4].Text.Trim());

        int LvStartMonth = Convert.ToInt16(dtLvStartdt.Month);

        if (LvStartMonth <= optLvExpireMonth)
        {

            DataTable dtPreLvPro = new DataTable();
            dtPreLvPro = objLeaveMgr.SelectEmpLeaveProfileEXCPL_History(grLeaveApp.SelectedRow.Cells[1].Text.Trim(), grLeaveApp.DataKeys[0].Values[2].ToString(), "01/01/2010");

            decimal LEntitled = 0;
            decimal LEnjoyed = 0;
            decimal LeaveElapsed = 0;

            if (dtPreLvPro.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtPreLvPro.Rows[0]["LEntitled"].ToString()) == false)
                    LEntitled = LEntitled + Convert.ToDecimal(dtPreLvPro.Rows[0]["LEntitled"].ToString());
                else
                    LEntitled = 0;
                if (string.IsNullOrEmpty(dtPreLvPro.Rows[0]["LeaveEnjoyed"].ToString()) == false)
                    hfLEnjoyed.Value = dtPreLvPro.Rows[0]["LeaveEnjoyed"].ToString();
                else
                    hfLEnjoyed.Value = "0";
                if (string.IsNullOrEmpty(dtPreLvPro.Rows[0]["LeaveElapsed"].ToString()) == false)
                    LeaveElapsed = LeaveElapsed + Convert.ToDecimal(dtPreLvPro.Rows[0]["LeaveElapsed"].ToString());
                else
                    LeaveElapsed = 0;

                PreYrLVAvail = LEntitled - (Convert.ToDecimal(hfLEnjoyed.Value) + LeaveElapsed + LEnjoyed);

            }

            if (PreYrLVAvail >= optTotalLvDays)
                return false;
            else
                return true;
        }
        else
            return false;
    }

    protected void CalculateLeaveDates(string gridStatus, string strDateFrom, string strDateTo)
    {
        double TotDay = 0;
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();

        string strFromDate = "";
        string strToDate = "";
        if (gridStatus == "A")
        {
            strFromDate = strDateFrom;// grLeaveApp.SelectedRow.Cells[4].Text;
            strToDate = strDateTo;// grLeaveApp.SelectedRow.Cells[5].Text;
        }
        else if (gridStatus == "D")
        {
            strFromDate = strDateFrom;// grLeaveDeny.SelectedRow.Cells[4].Text;
            strToDate = strDateTo;// grLeaveDeny.SelectedRow.Cells[5].Text;
        }
        else if (gridStatus == "AC")
        {
            strFromDate = strDateFrom;// grLeaveApprove.SelectedRow.Cells[4].Text;
            strToDate = strDateTo;// grLeaveApprove.SelectedRow.Cells[5].Text;
        }

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
        //int row = 0;
        //int LeaveDay = 0;
        //hfLDates.Value = "";
        //if ((gridStatus == "A") || gridStatus == "D")
        //{
        //    for (row = 0; row < Convert.ToInt32(TotDay); row++)
        //    {
        //        if (hfLDates.Value != "")
        //        {
        //            hfLDates.Value = hfLDates.Value + ",";
        //        }
        //        LeaveDay = LeaveDay + 1;
        //        hfLDates.Value = hfLDates.Value + Common.SetDate(LDate.ToString());
        //        LDate = LDate.AddDays(1);
        //    }
        //}
        //else if (gridStatus == "AC")
        //if (gridStatus == "AC")
        //{
        //    for (row = 0; row < Convert.ToInt32(TotDay); row++)
        //    {
        //        if (hfLDates.Value != "")
        //        {
        //            hfLDatesForCancel.Value = hfLDatesForCancel.Value + ",";
        //        }
        //        LeaveDay = LeaveDay + 1;
        //        hfLDatesForCancel.Value = hfLDates.Value + Common.SetDate(LDate.ToString());
        //        LDate = LDate.AddDays(1);
        //    }
        //}        
    }

    protected void GetLeaveDates(string strLvAppId, string gridStatus, string strDateFrom, string strDateTo)
    {
        string strFromDate = "";
        string strToDate = "";
        if (gridStatus == "A")
        {
            strFromDate = strDateFrom; //grLeaveApp.SelectedRow.Cells[4].Text;
            strToDate = strDateTo; //grLeaveApp.SelectedRow.Cells[5].Text;
        }
        else if (gridStatus == "D")
        {
            strFromDate = strDateFrom; //grLeaveDeny.SelectedRow.Cells[4].Text;
            strToDate = strDateTo; // grLeaveDeny.SelectedRow.Cells[5].Text;
        }
        else if (gridStatus == "AC")
        {
            strFromDate = strDateFrom; //grLeaveApprove.SelectedRow.Cells[4].Text;
            strToDate = strDateTo; //grLeaveApprove.SelectedRow.Cells[5].Text;
        }

        DataTable dtLeaveDates = new DataTable();
        dtLeaveDates = objLeaveMgr.GetLeaveDates(strLvAppId);
        if (dtLeaveDates.Rows.Count > 0)
        {
            hfLDates.Value = "";
            foreach (DataRow dRow in dtLeaveDates.Rows)
            {
                if (hfLDates.Value != "")
                    hfLDates.Value = hfLDates.Value + "," + Common.SetDate(dRow["LevDate"].ToString());
                else
                    hfLDates.Value = Common.SetDate(dRow["LevDate"].ToString());
            }
        }
    }

    protected void GetWeekend(string strEmpId, string strFromDate, string strToDate, string gridStatus)
    {
        HiddenField hfLeaveDates = new HiddenField();
        HiddenField hfWeeekendDay = new HiddenField();

        //HiddenField hfWeeekendDate = new HiddenField();

        double TotDay = 0;
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();

        if (string.IsNullOrEmpty(strFromDate) == true)
        {
            lblMsg.Text = "Please insert valid start date";
            return;
        }
        if (string.IsNullOrEmpty(strToDate) == true)
        {
            lblMsg.Text = "Please insert valid end date";
            return;
        }

        if (string.IsNullOrEmpty(strToDate) == false && string.IsNullOrEmpty(strFromDate) == false)
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
            if (TotDay < 0)
            {
                lblMsg.Text = "Start date can not be greater than end date.";
                return;
            }
        }

        DataTable dtEmpWeekend = new DataTable();
        dtEmpWeekend = objLeaveMgr.SelectEmpWiseWeekend(strEmpId);
        DateTime LDate = dtFrom;
        int row;
        int LeaveDay = 0;
        TotWeekedDay = 0;
        hfLeaveDates.Value = "";

        if (dtEmpWeekend.Rows.Count > 0)
        {
            for (row = 0; row < Convert.ToInt32(TotDay); row++)
            {
                string DayName = LDate.DayOfWeek.ToString();
                switch (DayName)
                {
                    case "Sunday":
                        {
                            if (dtEmpWeekend.Rows[0]["WESun"].ToString() == "N")
                            {
                                LeaveDay = LeaveDay + 1;
                                if (hfLeaveDates.Value != "")
                                    hfLeaveDates.Value = hfLeaveDates.Value + "," + Common.SetDate(LDate.ToString());
                                else
                                    hfLeaveDates.Value = Common.SetDate(LDate.ToString());
                                break;
                            }
                            else
                            {
                                LDate = LDate.AddDays(1);
                                if (hfWeeekendDay.Value == "")
                                    hfWeeekendDay.Value = "Sunday";
                                else
                                    hfWeeekendDay.Value = hfWeeekendDay.Value + ", Sunday";
                                TotWeekedDay++;
                                continue;
                            }
                        }
                    case "Monday":
                        {
                            if (dtEmpWeekend.Rows[0]["WEMon"].ToString() == "N")
                            {
                                LeaveDay = LeaveDay + 1;
                                if (hfLeaveDates.Value != "")
                                    hfLeaveDates.Value = hfLeaveDates.Value + "," + Common.SetDate(LDate.ToString());
                                else
                                    hfLeaveDates.Value = Common.SetDate(LDate.ToString());
                                break;
                            }
                            else
                            {
                                LDate = LDate.AddDays(1);
                                if (hfWeeekendDay.Value == "")
                                    hfWeeekendDay.Value = "Monday";
                                else
                                    hfWeeekendDay.Value = hfWeeekendDay.Value + ", Monday";
                                TotWeekedDay++;
                                continue;
                            }
                        }
                    case "Tuesday":
                        {
                            if (dtEmpWeekend.Rows[0]["WETues"].ToString() == "N")
                            {
                                LeaveDay = LeaveDay + 1;
                                if (hfLeaveDates.Value != "")
                                    hfLeaveDates.Value = hfLeaveDates.Value + "," + Common.SetDate(LDate.ToString());
                                else
                                    hfLeaveDates.Value = Common.SetDate(LDate.ToString());
                                break;
                            }
                            else
                            {
                                LDate = LDate.AddDays(1);
                                if (hfWeeekendDay.Value == "")
                                    hfWeeekendDay.Value = "Tuesday";
                                else
                                    hfWeeekendDay.Value = hfWeeekendDay.Value + ", Tuesday";
                                TotWeekedDay++;
                                continue;
                            }
                        }
                    case "Wednesday":
                        {
                            if (dtEmpWeekend.Rows[0]["WEWed"].ToString() == "N")
                            {
                                LeaveDay = LeaveDay + 1;
                                if (hfLeaveDates.Value != "")
                                    hfLeaveDates.Value = hfLeaveDates.Value + "," + Common.SetDate(LDate.ToString());
                                else
                                    hfLeaveDates.Value = Common.SetDate(LDate.ToString());
                                break;
                            }
                            else
                            {
                                LDate = LDate.AddDays(1);
                                if (hfWeeekendDay.Value == "")
                                    hfWeeekendDay.Value = "Wednesday";
                                else
                                    hfWeeekendDay.Value = hfWeeekendDay.Value + ", Wednesday";
                                TotWeekedDay++;
                                continue;
                            }
                        }
                    case "Thursday":
                        {
                            if (dtEmpWeekend.Rows[0]["WETue"].ToString() == "N")
                            {
                                LeaveDay = LeaveDay + 1;
                                if (hfLeaveDates.Value != "")
                                    hfLeaveDates.Value = hfLeaveDates.Value + "," + Common.SetDate(LDate.ToString());
                                else
                                    hfLeaveDates.Value = Common.SetDate(LDate.ToString());
                                break;
                            }
                            else
                            {
                                LDate = LDate.AddDays(1);
                                if (hfWeeekendDay.Value == "")
                                    hfWeeekendDay.Value = "Thursday";
                                else
                                    hfWeeekendDay.Value = hfWeeekendDay.Value + ", Thursday";
                                TotWeekedDay++;
                                continue;
                            }
                        }
                    case "Friday":
                        {
                            if (dtEmpWeekend.Rows[0]["WEFri"].ToString() == "N")
                            {
                                LeaveDay = LeaveDay + 1;
                                if (hfLeaveDates.Value != "")
                                    hfLeaveDates.Value = hfLeaveDates.Value + "," + Common.SetDate(LDate.ToString());
                                else
                                    hfLeaveDates.Value = Common.SetDate(LDate.ToString());
                                break;
                            }
                            else
                            {
                                LDate = LDate.AddDays(1);
                                if (hfWeeekendDay.Value == "")
                                    hfWeeekendDay.Value = "Friday";
                                else
                                    hfWeeekendDay.Value = hfWeeekendDay.Value + ", Friday";
                                TotWeekedDay++;
                                continue;
                            }
                        }
                    case "Saturday":
                        {
                            if (dtEmpWeekend.Rows[0]["WESat"].ToString() == "N")
                            {
                                LeaveDay = LeaveDay + 1;
                                if (hfLeaveDates.Value != "")
                                    hfLeaveDates.Value = hfLeaveDates.Value + "," + Common.SetDate(LDate.ToString());
                                else
                                    hfLeaveDates.Value = Common.SetDate(LDate.ToString());
                                break;
                            }
                            else
                            {
                                LDate = LDate.AddDays(1);
                                if (hfWeeekendDay.Value == "")
                                    hfWeeekendDay.Value = "Saturday";
                                else
                                    hfWeeekendDay.Value = hfWeeekendDay.Value + ", Saturday";
                                TotWeekedDay++;
                                continue;
                            }
                        }
                }
                LDate = LDate.AddDays(1);
            }
        }
        //if ((gridStatus == "A") || (gridStatus == "D"))
        //    hfLDates.Value = hfLeaveDates.Value;
        //else
        //    hfLDatesForCancel.Value = hfLeaveDates.Value;

        //if (hfWeeekendDay.Value != "")
        //    lblMsg.Text = hfWeeekendDay.Value + " Is Weekend";
        //else
        //    lblMsg.Text = "";
    }
    // Sending Reminder to Supervisor
    protected void btnSendReminder_Click(object sender, EventArgs e)
    {
        int i = 0;
        int inCount = 0;
        string strSupervisor = "";
        foreach (GridViewRow gRow in grLeaveApp.Rows)
        {
            string strEmpID = gRow.Cells[1].Text.Trim();

            CheckBox chk = (CheckBox)gRow.Cells[12].FindControl("chkBox");
            if (chk.Checked == true)
            {
                if (strSupervisor == "")
                    strSupervisor = grLeaveApp.DataKeys[gRow.DataItemIndex].Values[13].ToString().Trim();
                else
                    strSupervisor = strSupervisor + "," + grLeaveApp.DataKeys[gRow.DataItemIndex].Values[13].ToString().Trim();
                inCount++;
            }
        }
        strSupervisor = Common.ShowDistinctValueFromString(inCount, strSupervisor);
        string[] strSupervisors = strSupervisor.Split(',');
        MailManagerSmtpClient objMailClient = new MailManagerSmtpClient();
        objMailClient.SendLeavePendingReminder(strSupervisors, grLeaveApp, Session["EMAILID"].ToString().Trim(), lblMsg, Session["USERNAME"].ToString(),
                      Session["DESIGNATION"].ToString(), Session["LOCATION"].ToString());
    }
    
    protected void grLeaveApp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
