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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using System.IO;
using System.Net;

public partial class frmReportViewer : System.Web.UI.Page
{
    private ReportDocument ReportDoc;
    private PrintDocument printDoc = new PrintDocument();
    private string ReportPath = "";
    ReportManager rptManager = new ReportManager();
    DataTable MyDataTable = new DataTable();
   
   
    DataTable mydtINOUT = new DataTable();

    //dsMAReport dsMA = new dsMAReport();
    DataRow dRowIn;
    DataRow dRowOut;

    protected void Page_Load(object sender, EventArgs e)
    {
        ConfigureCrystalReports();
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        if (null != MyDataTable)
            MyDataTable.Dispose();
        if (ReportDoc != null)
        {
            ReportDoc.Close();
            ReportDoc.Dispose();
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        Page.ClientScript.RegisterForEventValidation(CRV.UniqueID);
        base.Render(writer);
    }

  

    private void ConfigureCrystalReports()
    {
        //string strMon = "";
        //string strYear = "";
        MyDataTable = new DataTable();
        ReportDoc = new ReportDocument();

        dsMainShftReport dsMSR = new dsMainShftReport();
        
        DataTable MyDataTable1 = new DataTable();


        DataColumn[] myPrimaryKey = new DataColumn[1];
        myPrimaryKey[0] = MyDataTable.Columns["EmpId"];
        MyDataTable.PrimaryKey = myPrimaryKey;
        //if (string.IsNullOrEmpty(Session["FromDate"].ToString()) == false)
        //{
        //    strMon = Common.ReturnSeparateValueFromDate(Session["FromDate"].ToString(), "m");
        //    strYear = Common.ReturnSeparateValueFromDate(Session["FromDate"].ToString(), "y");
        //}

        switch (Session["REPORTID"].ToString())
        {            
            case "DA":
                //Report no 1 : Attendance Report
                ReportPath = Server.MapPath("~/CrystalReports/rptAttandance.rpt");
                Label1.Text = ReportPath;
               
                ReportDoc.Load(ReportPath);

                MyDataTable = rptManager.Get_Attandance(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
                    Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["DeptId"].ToString(), Session["EmpId"].ToString(),
                    Session["ShiftID"].ToString(), Session["isClosed"].ToString());

                this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Attendance Report");
                CRV.Width = 10;                
                ReportDoc.SetDataSource(MyDataTable);
                CRV.ReportSource = ReportDoc;                
                break;
            //case "AE":
            //    //Report no 2 : Employee wise attendance
            //    //Anol                
            //    ReportPath = Server.MapPath("~/CrystalReports/rptAttndEmpWise.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_MonthlyAttnd(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //         Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["DeptId"].ToString(), Session["EmpId"].ToString(), 
            //        Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    string strPresent = CountStatus("P", MyDataTable);
            //    string strAbsent = CountStatus("A", MyDataTable);
            //    string strLeave = CountStatus("LV", MyDataTable);
            //    string strDelay = CountStatus("L", MyDataTable);
            //    string strWeekend = CountStatus("W", MyDataTable);
            //    string strHoliday = CountStatus("H", MyDataTable);

            //    this.PassParameterAttndEmpWisePLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Attendance Employee Wise", strPresent, strAbsent, strLeave, strDelay, strWeekend, strHoliday);
            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;

            //    break;
            //case "SumAttnd":
            //    //Report no 3 : Summery attendance
            //    //Anol
            //    string strEmpId = "";
            //    ReportPath = Server.MapPath("~/CrystalReports/rptSummeryAttnd.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_MonthlyAttnd(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //         Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["DeptId"].ToString(), Session["EmpId"].ToString(),
            //        Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    //MyDataTable = rptManager.Get_MonthlyAttnd(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //    //    Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //    //    Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    dsAttndSum objDS = new dsAttndSum();
            //    foreach (DataRow dRow in MyDataTable.Rows)
            //    {
            //        if (strEmpId != dRow["EMPID"].ToString().Trim())
            //        {
            //            strEmpId = dRow["EMPID"].ToString().Trim();
            //            DataRow nRow = objDS.dtAttndSum.NewRow();
            //            nRow["EMPID"] = dRow["EMPID"].ToString().Trim();
            //            nRow["EMPNAME"] = dRow["FullName"].ToString().Trim();
            //            nRow["Designation"] = dRow["JobTitle"].ToString().Trim();
            //            nRow["Department"] = dRow["DeptName"].ToString().Trim();
            //            nRow["Weekend"] = dRow["WEPackName"].ToString().Trim();
            //            nRow["NoofDayAttended"] = CountStatusPresent(strEmpId, MyDataTable);
            //            nRow["AttndOnWeekend"] = CountAttndOnWeekend("W", strEmpId, MyDataTable);
            //            nRow["AppliedforLeave"] = CountStatusEmpWise("LV", strEmpId, MyDataTable);
            //            nRow["NoofDayAbsent"] = CountStatusEmpWise("A", strEmpId, MyDataTable);
            //            nRow["CPL"] = CountStatusEmpWiseleave("CPL", strEmpId, MyDataTable);
            //            nRow["LWP"] = CountStatusEmpWiseleave("LWP", strEmpId, MyDataTable);
            //            nRow["NoofWeekend"] = CountStatusEmpWise("W", strEmpId, MyDataTable);
            //            nRow["Holiday"] = CountStatusEmpWise("H", strEmpId, MyDataTable);
            //            objDS.dtAttndSum.Rows.Add(nRow);
            //            objDS.dtAttndSum.AcceptChanges();
            //        }
            //    }

            //    this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Summary Attendance Report");
            //    ReportDoc.SetDataSource(objDS);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            
            //case "LR":
            //    //Report no 4 : late report
            //    ReportPath = Server.MapPath("~/CrystalReports/rptAttandance.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_LateReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //         Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["DeptId"].ToString(), Session["EmpId"].ToString(), Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Late Report");

            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;
            //    break;


            //case "AR":
            //    //Report no 5 : Absent report
            //    ReportPath = Server.MapPath("~/CrystalReports/rptAttandance.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_AbsentReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //         Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["DeptId"].ToString(), Session["EmpId"].ToString(), Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Absent report");

            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;

            //    break;
            //case "IR":
            //    //Report no 6 : Incomplete report
            //    ReportPath = Server.MapPath("~/CrystalReports/rptAttandance.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_IncompleteReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //         Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["DeptId"].ToString(), Session["EmpId"].ToString(), Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    if (Session["Flag"].ToString() == "D")
            //    {
            //        foreach (DataRow drow in MyDataTable.Rows)
            //        {
            //            if ((string.IsNullOrEmpty(drow["INTIME"].ToString()) == true) && (string.IsNullOrEmpty(drow["OUTTIME"].ToString()) == true))
            //            {
            //                drow.Delete();                            
            //            }
            //            else if ((string.IsNullOrEmpty(drow["INTIME"].ToString()) == false) && (string.IsNullOrEmpty(drow["OUTTIME"].ToString()) == false))
            //            {
            //                drow.Delete();                            
            //            }
            //        }
            //        MyDataTable.AcceptChanges();
            //    }
                
            //    this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Incomplete report");

            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            //case "ED":
            //    //Report no 7 : Early Departure
            //    ReportPath = Server.MapPath("~/CrystalReports/rptAttandance.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_EarlyDepartureReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["DeptId"].ToString(), Session["EmpId"].ToString(), Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Early Departure Report");

            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            //case "DailyA":
            //    //Report no 1 : 4 Days Attendance Report
            //    ReportPath = Server.MapPath("~/CrystalReports/rptDailyAttandance.rpt");
            //    strEmpId = "";
            //    ReportDoc.Load(ReportPath);

            //    DateTime dtFromDate = new DateTime();
            //    dtFromDate = Convert.ToDateTime(Common.ReturnDate(Session["FromDate"].ToString()));
            //    dtFromDate = dtFromDate.AddDays(-3);
            //    string strFromDate = Common.DisplayDate(dtFromDate.ToString()); //Common.DisplayDate(DateTime.Now.AddDays(-3).ToString());// 

            //    MyDataTable = rptManager.Get_Daily_Attandance(Session["Flag"].ToString(), strFromDate, Session["ToDate"].ToString(),
            //         Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["EmpId"].ToString(), 
            //        Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    ds4DayAttendance objDS2 = new ds4DayAttendance();
            //    DateTime dtDate = new DateTime();

            //    foreach (DataRow dRow in MyDataTable.Rows)
            //    {
            //        if (strEmpId != dRow["EMPID"].ToString().Trim())
            //        {
            //            strEmpId = dRow["EMPID"].ToString().Trim();
            //            DataRow nRow = objDS2.tblAttandance.NewRow();
            //            nRow["EMPID"] = dRow["EMPID"].ToString().Trim();
            //            nRow["Name"] = dRow["Name"].ToString().Trim();
            //            nRow["Designation"] = dRow["Designation"].ToString().Trim();
            //            nRow["DivisionName"] = dRow["DivisionName"].ToString().Trim();

            //            if (GetTime(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable, "Y") != "")
            //                nRow["InTime"] = GetTime(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable, "Y");
            //            else
            //                nRow["InTime"] = DBNull.Value;
            //            nRow["InLocation"] = GetLocation(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable, "Y");

            //            if (GetTime(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable, "N") != "")
            //                nRow["OutTime"] = GetTime(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable, "N");
            //            else
            //                nRow["OutTime"] = DBNull.Value;
            //            nRow["Status"] = GetAttnStatus(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable);
            //            nRow["OutLocation"] = GetLocation(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable, "N");
            //            nRow["LateHour"] = GetLtHour(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable);
            //            nRow["Manual"] = GetIsManual(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable);

            //            nRow["AttanDate"] = Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString()));

            //            dtDate = Convert.ToDateTime(Common.ReturnDate(Session["FromDate"].ToString())).AddDays(-1);
            //            if (GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "Y") != "")
            //                nRow["2InTime"] = GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "Y");
            //            else
            //                nRow["2InTime"] = DBNull.Value;

            //            if (GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "N") != "")
            //                nRow["2OutTime"] = GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "N");
            //            else
            //                nRow["2OutTime"] = DBNull.Value;
            //            nRow["2Status"] = GetAttnStatus(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable);
            //            nRow["2AttanDate"] = Common.DisplayDate(dtDate.ToString());

            //            dtDate = dtDate.AddDays(-1);
            //            if (GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "Y") != "")
            //                nRow["3InTime"] = GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "Y");
            //            else
            //                nRow["3InTime"] = DBNull.Value;
            //            if (GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "N") != "")
            //                nRow["3OutTime"] = GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "N");
            //            else
            //                nRow["3OutTime"] = DBNull.Value;
            //            nRow["3Status"] = GetAttnStatus(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable);
            //            nRow["3AttanDate"] = Common.DisplayDate(dtDate.ToString());

            //            dtDate = dtDate.AddDays(-1);
            //            if (GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "Y") != "")
            //                nRow["4InTime"] = GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "Y");
            //            else
            //                nRow["4InTime"] = DBNull.Value;
            //            if (GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "N") != "")
            //                nRow["4OutTime"] = GetTime(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable, "N");
            //            else
            //                nRow["4OutTime"] = DBNull.Value;
            //            nRow["4Status"] = GetAttnStatus(Common.DisplayDate(dtDate.ToString()), strEmpId, MyDataTable);

            //            nRow["4AttanDate"] = Common.DisplayDate(dtDate.ToString());

            //            objDS2.tblAttandance.Rows.Add(nRow);
            //            objDS2.tblAttandance.AcceptChanges();
            //        }
            //    }

                //if (Session["Flag"].ToString() == "E")
                //{
                //    DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
                //    if (dtDivSbuDept.Rows.Count > 0)
                //    {
                //        foreach (DataRow tt in dtDivSbuDept.Rows)
                //        {
                //            this.PassParameterNew(tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Attendance Report", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
                //        }
                //    }
                //    else
                //        this.PassParameterNew(Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Attendance Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
                //}
                //else
                //this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Daily Attendance Report");
                //CRV.Width = 10;
                //ReportDoc.SetDataSource(objDS2);
                //CRV.ReportSource = ReportDoc;
                //break;
            //case "MonthlyA":
            //    //Report no 1 : Monthly Attendance Report
            //    ReportPath = Server.MapPath("~/CrystalReports/rptMonthlyAttandance.rpt");
            //    strEmpId = "";
            //    ReportDoc.Load(ReportPath);
            //    DateTime dtFromDate2 = new DateTime();
            //    dtFromDate = Convert.ToDateTime(Common.ReturnDate(Session["FromDate"].ToString()));
            //    string strFromDate2 = Common.DisplayDate(dtFromDate2.ToString()); //Common.DisplayDate(DateTime.Now.AddDays(-3).ToString());// 

            //    MyDataTable = rptManager.Get_Monthly_Attandance(Session["Flag"].ToString(), strFromDate2, Session["ToDate"].ToString(),
            //         Session["DivisionId"].ToString(), Session["SBUId"].ToString(), Session["EmpId"].ToString(), Session["ShiftID"].ToString(), Session["isClosed"].ToString());

            //    dsMonthlyAttandance objDS3 = new dsMonthlyAttandance();
            //    DateTime dtDate2 = new DateTime();

            //    foreach (DataRow dRow in MyDataTable.Rows)
            //    {
            //        if (strEmpId != dRow["EMPID"].ToString().Trim())
            //        {
            //            strEmpId = dRow["EMPID"].ToString().Trim();
            //            DataRow nRow = objDS3.tblMonthlyAttandance.NewRow();
            //            nRow["EMPID"] = dRow["EMPID"].ToString().Trim();
            //            nRow["Name"] = dRow["Name"].ToString().Trim();
            //            //nRow["Designation"] = dRow["Designation"].ToString().Trim();
            //            nRow["DivisionName"] = dRow["DivisionName"].ToString().Trim();
            //            nRow["St1"] = GetAttnStatus(Common.DisplayDate(Common.ReturnDate(Session["FromDate"].ToString())), strEmpId, MyDataTable);

            //            dtDate2 = Convert.ToDateTime(Common.ReturnDate(Session["FromDate"].ToString())).AddDays(1);
            //            nRow["St2"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St3"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St4"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St5"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St6"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St7"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St8"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St9"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St10"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St11"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St12"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St13"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St14"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St15"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St16"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St17"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St18"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St19"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St20"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St21"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St22"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St23"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St24"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St25"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St26"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St27"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St28"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St29"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St30"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);
            //            dtDate2 = dtDate2.AddDays(1);
            //            nRow["St31"] = GetAttnStatus(Common.DisplayDate(dtDate2.ToString()), strEmpId, MyDataTable);

            //            objDS3.tblMonthlyAttandance.Rows.Add(nRow);
            //            objDS3.tblMonthlyAttandance.AcceptChanges();
            //        }
            //    }

            //    //if (Session["Flag"].ToString() == "E")
            //    //{
            //    //    DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //    //    if (dtDivSbuDept.Rows.Count > 0)
            //    //    {
            //    //        foreach (DataRow tt in dtDivSbuDept.Rows)
            //    //        {
            //    //            this.PassParameterDBBL1(tt["BranchName"].ToString(), tt["DivisionName"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Monthly Attendance Report");
            //    //        }
            //    //    }
            //    //    else
            //    //        this.PassParameterDBBL1(Session["Branch"].ToString(), Session["Div"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Monthly Attendance Report");
            //    //}
            //    //else
            //        //this.PassParameterPLAN(Session["Division"].ToString(), Session["SBU"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Monthly Attendance Report");
            //    CRV.Width = 10;
            //    ReportDoc.SetDataSource(objDS3);
            //    CRV.ReportSource = ReportDoc;
            //    break;

            //case "InvOT":
            //    //Report no 8 :Overtime Sheet
            //    ReportPath = Server.MapPath("~/CrystalReports/rptEmpWsOT.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_OverTimeReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
            //        Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["BranchId"].ToString(), Session["DivisionId"].ToString(),
            //        Session["EmpId"].ToString(), Session["isClosed"].ToString());
            //    //if (Session["Flag"].ToString() == "E")
            //    //{
            //    //    DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //    //    if (dtDivSbuDept.Rows.Count > 0)
            //    //    {
            //    //        foreach (DataRow tt in dtDivSbuDept.Rows)
            //    //        {
            //    //            this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Employee OT Report", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //    //        }
            //    //    }
            //    //    else
            //    //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Employee OT Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    //}
            //    //else
            //    //this.PassParameterDBBL1(Session["Branch"].ToString(), Session["Div"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Employee OT Report");

            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            //case "EWOS":
            //    //Report No 15 : Employee wise OT summery
            //    ReportPath = Server.MapPath("~/CrystalReports/rptEmpWiseOtSum.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_OtEmpWise(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["BranchId"].ToString(), Session["DivisionId"].ToString(),
            //        Session["isClosed"].ToString(), Session["EmpId"].ToString());
            //    //if (Session["Flag"].ToString() == "E")
            //    //{
            //    //    DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //    //    if (dtDivSbuDept.Rows.Count > 0)
            //    //    {
            //    //        foreach (DataRow tt in dtDivSbuDept.Rows)
            //    //        {
            //    //            this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Employee OT Summary Report", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //    //        }
            //    //    }
            //    //    else
            //    //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Employee OT Summary Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    //}
            //    //else
            //    //this.PassParameterDBBL1(Session["Branch"].ToString(), Session["Div"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Employee OT Summary Report");
            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;
            //    break;

            //case "SummOT":
            //    //Report no 9 :Department wise overtime summary

            //    ReportPath = Server.MapPath("~/CrystalReports/rptOverTimeSummary.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_OverTimeSummaryReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["DivisionId"].ToString(), Session["SbuId"].ToString(),
            //        Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["LocId"].ToString(), Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString());
            //    if (Session["Flag"].ToString() == "E")
            //    {
            //        DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //        if (dtDivSbuDept.Rows.Count > 0)
            //        {
            //            foreach (DataRow tt in dtDivSbuDept.Rows)
            //            {
            //                this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Department wise OT Summary Report", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //            }
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Department wise OT Summary Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    }
            //    else
            //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Department wise OT Summary Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;
            //    break;

            //------------------------Leave Report-------------------------------                
            //Report :Leave Balance
                string strEmpId = "";
            case "EmpLVBalance":
                //string strSubTypeStat = Session["EmpSubTypeStatus"].ToString();
                //if (Session["Flag"].ToString() == "E")
                //{
                //    DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
                //    if (dtDivSbuDept.Rows.Count > 0)
                //    {
                //        foreach (DataRow tt in dtDivSbuDept.Rows)
                //        {
                //            strSubTypeStat = tt["EST"].ToString().Trim();
                //        }
                //    }
                //    else
                //    {
                //        return;
                //    }
                //}
                ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveBalance.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.Get_EmpLeaveBalance(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
                    Session["BranchId"].ToString(), Session["DivisionId"].ToString(),
                     Session["EmpId"].ToString(), Session["isClosed"].ToString());

                dsEmployeeLeave dsEmp = new dsEmployeeLeave();
                strEmpId = "";
                foreach (DataRow sRow in MyDataTable.Rows)
                {
                    if (strEmpId != sRow["EMPID"].ToString().Trim())
                    {
                        strEmpId = sRow["EMPID"].ToString().Trim();
                        DataRow dRow = dsEmp.dtEmpLeave.NewRow();
                        dRow["EmpId"] = sRow["EmpId"];
                        dRow["Name"] = sRow["FullName"];
                        dRow["JobTitle"] = sRow["JobTitle"];
                        dRow["CLEntitled"] = 0;
                        dRow["CLEnjoyed"] = 0;
                        dRow["CLBalance"] = 0;
                        dRow["SLEntitled"] = 0;
                        dRow["SLEnjoyed"] = 0;
                        dRow["SLBalance"] = 0;

                        DataRow myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
                        Int32 strCountCLEntitled = CountLeaveEntitled("EmpId='" + sRow["EmpId"].ToString().Trim() + "' and LAbbrName='CL'", MyDataTable);
                        dRow["CLEntitled"] = strCountCLEntitled;
                        Int32 strCountCLEnjoyed = CountLeaveEnjoyed("EmpId='" + sRow["EmpId"].ToString().Trim() + "' and LAbbrName='CL'", MyDataTable);
                        dRow["CLEnjoyed"] = strCountCLEnjoyed;
                        Int32 strCountCLBal = CountLeaveBalance("EmpId='" + sRow["EmpId"].ToString().Trim() + "' and LAbbrName='CL'", MyDataTable);
                        dRow["CLBalance"] = strCountCLBal;

                        myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
                        Int32 strCountPLEntitled = CountLeaveEntitled("EmpId='" + sRow["EmpId"].ToString().Trim() + "' and LAbbrName='SL'", MyDataTable);
                        dRow["SLEntitled"] = strCountPLEntitled;
                        Int32 strCountPLEnjoyed = CountLeaveEnjoyed("EmpId='" + sRow["EmpId"].ToString().Trim() + "' and LAbbrName='SL'", MyDataTable);
                        dRow["SLEnjoyed"] = strCountPLEnjoyed;
                        Int32 strCountPLBal = CountLeaveBalance("EmpId='" + sRow["EmpId"].ToString().Trim() + "' and LAbbrName='SL'", MyDataTable);
                        dRow["SLBalance"] = strCountPLBal;

                        dsEmp.dtEmpLeave.Rows.Add(dRow);
                        dsEmp.dtEmpLeave.AcceptChanges();
                    }
                }
                //if (Session["Flag"].ToString() == "E")
                //{
                //    DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
                //    if (dtDivSbuDept.Rows.Count > 0)
                //    {
                //        foreach (DataRow tt in dtDivSbuDept.Rows)
                //        {
                //            this.PassParameterNew(tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
                //        }
                //    }
                //    else
                //        this.PassParameterNew(Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
                //}
                //else
                //this.PassParameterDBBL1(Session["Branch"].ToString(), Session["Div"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry");

                ReportDoc.SetDataSource(dsEmp);
                CRV.ReportSource = ReportDoc;
                break;

            //case "Shf":
            //    //Report NO 14 :Shift wise Employee  sum
            //    ReportPath = Server.MapPath("~/CrystalReports/rptShiftWiseEmpSum.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_ShiftWiseEmpSum(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //        Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["ShiftID"].ToString(), Session["isClosed"].ToString());
            //    if (Session["Flag"].ToString() == "E")
            //    {
            //        DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //        if (dtDivSbuDept.Rows.Count > 0)
            //        {
            //            foreach (DataRow tt in dtDivSbuDept.Rows)
            //            {
            //                this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Shift Wise Employee Sum for shift :" + Session["ShiftName"].ToString(), tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //            }
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Shift Wise Employee Sum for shift :" + Session["ShiftName"].ToString(), Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    }
            //    else
            //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Shift Wise Employee Sum for shift :" + Session["ShiftName"].ToString(), Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;

            //    break;
            
            //case "MSR0":
            //    // Report No 16 : Man Shift Report pre aprroval
            //    if (string.IsNullOrEmpty(Session["FromDate"].ToString()) == false)
            //    {
            //        strMon = Common.ReturnSeparateValueFromDate(Session["FromDate"].ToString(), "m");
            //        strYear = Common.ReturnSeparateValueFromDate(Session["FromDate"].ToString(), "y");
            //    }
            //    else
            //        return;
            //    ReportPath = Server.MapPath("~/CrystalReports/rptMainShiftReport.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_MainShiftReport0(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), strMon, strYear,
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //        Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());

            //    foreach (DataRow dRow in MyDataTable.Rows)
            //    {
            //        DataRow sRow = dsMSR.dtMainShftReport.NewRow();
            //        sRow["EmpId"] = dRow["EmpId"];
            //        sRow["FullName"] = dRow["FullName"];
            //        sRow["deptName"] = dRow["deptName"];
            //        sRow["cnt"] = dRow["cnt"];
            //        sRow["ew"] = dRow["ew"];
            //        dsMSR.dtMainShftReport.Rows.Add(sRow);
            //        dsMSR.dtMainShftReport.AcceptChanges();
            //    }
            //    if (Session["Flag"].ToString() == "E")
            //    {
            //        DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //        if (dtDivSbuDept.Rows.Count > 0)
            //        {
            //            foreach (DataRow tt in dtDivSbuDept.Rows)
            //            {
            //                this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Common.ReturnDate(Session["FromDate"].ToString()), Common.ReturnDate(Session["ToDate"].ToString()), "Man Shift Report", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //            }
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Common.ReturnDate(Session["FromDate"].ToString()), Common.ReturnDate(Session["ToDate"].ToString()), "Man Shift Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    }
            //    else
            //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Common.ReturnDate(Session["FromDate"].ToString()), Common.ReturnDate(Session["ToDate"].ToString()), "Man Shift Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

            //    MyDataTable1 = rptManager.Get_MainShiftReportPart2(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), strMon, strYear,
            //       Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //       Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());
                
            //    foreach (DataRow dRow in MyDataTable1.Rows)
            //    {
            //        DataRow myEditDataRow = dsMSR.dtMainShftReport.Rows.Find(dRow["EmpId"]);
            //        myEditDataRow["NDS"] = dRow["NDS"];
            //        dsMSR.dtMainShftReport.AcceptChanges();
            //    }
            //    ReportDoc.SetDataSource(dsMSR);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            //case "MSR":
            //    // Report No 17 : Man Shift Report post aprroval
            //    strEmpId = "";
            //    ReportPath = Server.MapPath("~/CrystalReports/rptMainShiftReport.rpt");
            //    ReportDoc.Load(ReportPath);
            //    DataTable dtAttDayCount = rptManager.Get_MainShiftReportAttDayCount(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //        Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());

            //    MyDataTable = rptManager.Get_MainShiftReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //        Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());

            //    DataRow[] foundMyDataTableRows;
            //    foreach (DataRow dRow in dtAttDayCount.Rows)
            //    {
            //        if (strEmpId != dRow["EMPID"].ToString().Trim())
            //        {
            //            strEmpId = dRow["EMPID"].ToString().Trim();
            //            double TotAttndday = 0;
            //            //double TotWeekHoliday = 0;                        
            //            DataRow sRow = dsMSR.dtMainShftReport.NewRow();
            //            sRow["EmpId"] = dRow["EmpId"];
            //            sRow["FullName"] = dRow["FullName"];
            //            sRow["deptName"] = dRow["deptName"];
            //            TotAttndday = Convert.ToDouble(CountStatusPresent(dRow["EmpId"].ToString().Trim(), dtAttDayCount));
            //            //TotWeekHoliday = Convert.ToDouble(CountAttndOnWeekend("W", dRow["EmpId"].ToString().Trim(), dtAttDayCount));
            //            sRow["cnt"] = Convert.ToString(TotAttndday);
            //            sRow["NDS"] = sRow["cnt"];

            //            foundMyDataTableRows = MyDataTable.Select("EMPID='" + dRow["EmpId"].ToString().Trim() + "'");
            //            if (foundMyDataTableRows.Length > 0)
            //                sRow["ew"] = foundMyDataTableRows[0]["ew"].ToString();
            //            else
            //                sRow["ew"] = "0";

            //            dsMSR.dtMainShftReport.Rows.Add(sRow);
            //            dsMSR.dtMainShftReport.AcceptChanges();
            //        }
            //    }
            //    //foreach (DataRow dRow in MyDataTable.Rows)
            //    //{
            //    //    DataRow sRow = dsMSR.dtMainShftReport.NewRow();
            //    //    sRow["EmpId"] = dRow["EmpId"];
            //    //    foundAttDayRows = dtAttDayCount.Select("EMPID='" + dRow["EmpId"].ToString().Trim() + "'");
            //    //    if (foundAttDayRows.Length > 0)
            //    //        sRow["cnt"] = foundAttDayRows[0]["cnt"].ToString();
            //    //    else
            //    //        sRow["cnt"] = "0";

            //    //    sRow["FullName"] = dRow["FullName"];
            //    //    sRow["deptName"] = dRow["deptName"];

            //    //    sRow["ew"] = dRow["ew"];
            //    //    dsMSR.dtMainShftReport.Rows.Add(sRow);
            //    //    dsMSR.dtMainShftReport.AcceptChanges();
            //    //}
            //    if (Session["Flag"].ToString() == "E")
            //    {
            //        DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //        if (dtDivSbuDept.Rows.Count > 0)
            //        {
            //            foreach (DataRow tt in dtDivSbuDept.Rows)
            //            {
            //                this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Man Shift Report", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //            }
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Man Shift Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    }
            //    else
            //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Man Shift Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

            //    //MyDataTable1 = rptManager.Get_MainShiftReportPart2(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), strMon, strYear,
            //    //   Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //    //   Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());

            //    //foreach (DataRow dRow in MyDataTable1.Rows)
            //    //{
            //    //    DataRow myEditDataRow = dsMSR.dtMainShftReport.Rows.Find(dRow["EmpId"]);
            //    //    myEditDataRow["NDS"] = dRow["NDS"];
            //    //    dsMSR.dtMainShftReport.AcceptChanges();
            //    //}
            //    ReportDoc.SetDataSource(dsMSR);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            //case "MSR":
            //    // Report No 17 : Man Shift Report post aprroval
            //    ReportPath = Server.MapPath("~/CrystalReports/rptMainShiftReport.rpt");
            //    ReportDoc.Load(ReportPath);
            //    DataTable dtAttDayCount = rptManager.Get_MainShiftReportAttDayCount(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //        Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());

            //    MyDataTable = rptManager.Get_MainShiftReport(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //        Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());

            //    DataRow[] foundMyDataTableRows;
            //    foreach (DataRow dRow in dtAttDayCount.Rows)
            //    {                
            //        DataRow sRow = dsMSR.dtMainShftReport.NewRow();
            //        sRow["EmpId"] = dRow["EmpId"];
            //        sRow["FullName"] = dRow["FullName"];
            //        sRow["deptName"] = dRow["deptName"];            
            //        sRow["cnt"]=dRow["cnt"];
            //        sRow["NDS"] = dRow["cnt"];
            //        foundMyDataTableRows = MyDataTable.Select("EMPID='" + dRow["EmpId"].ToString().Trim() + "'");
            //        if (foundMyDataTableRows.Length > 0)
            //            sRow["ew"] = foundMyDataTableRows[0]["ew"].ToString();
            //        else
            //            sRow["ew"] = "0";

            //        dsMSR.dtMainShftReport.Rows.Add(sRow);
            //        dsMSR.dtMainShftReport.AcceptChanges();
            //    }
            //    //foreach (DataRow dRow in MyDataTable.Rows)
            //    //{
            //    //    DataRow sRow = dsMSR.dtMainShftReport.NewRow();
            //    //    sRow["EmpId"] = dRow["EmpId"];
            //    //    foundAttDayRows = dtAttDayCount.Select("EMPID='" + dRow["EmpId"].ToString().Trim() + "'");
            //    //    if (foundAttDayRows.Length > 0)
            //    //        sRow["cnt"] = foundAttDayRows[0]["cnt"].ToString();
            //    //    else
            //    //        sRow["cnt"] = "0";

            //    //    sRow["FullName"] = dRow["FullName"];
            //    //    sRow["deptName"] = dRow["deptName"];
                              
            //    //    sRow["ew"] = dRow["ew"];
            //    //    dsMSR.dtMainShftReport.Rows.Add(sRow);
            //    //    dsMSR.dtMainShftReport.AcceptChanges();
            //    //}
            //    if (Session["Flag"].ToString() == "E")
            //    {
            //        DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //        if (dtDivSbuDept.Rows.Count > 0)
            //        {
            //            foreach (DataRow tt in dtDivSbuDept.Rows)
            //            {
            //                this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Man Shift Report", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //            }
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Man Shift Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    }
            //    else
            //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Man Shift Report", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

            //    //MyDataTable1 = rptManager.Get_MainShiftReportPart2(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), strMon, strYear,
            //    //   Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //    //   Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());

            //    //foreach (DataRow dRow in MyDataTable1.Rows)
            //    //{
            //    //    DataRow myEditDataRow = dsMSR.dtMainShftReport.Rows.Find(dRow["EmpId"]);
            //    //    myEditDataRow["NDS"] = dRow["NDS"];
            //    //    dsMSR.dtMainShftReport.AcceptChanges();
            //    //}
            //    ReportDoc.SetDataSource(dsMSR);
            //    CRV.ReportSource = ReportDoc;
            //    break;

            //case "Prm":
            //    //Report No 18: Employee Promotion

            //    ReportPath = Server.MapPath("~/CrystalReports/rptPromotion.rpt");
            //    ReportDoc.Load(ReportPath);
            //    MyDataTable = rptManager.Get_Promotionrpt(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["EmpId"].ToString(), Session["LocId"].ToString(),
            //        Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());
            //    if (Session["Flag"].ToString() == "E")
            //    {
            //        DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //        if (dtDivSbuDept.Rows.Count > 0)
            //        {
            //            foreach (DataRow tt in dtDivSbuDept.Rows)
            //            {
            //                this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Promotion", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //            }
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Promotion", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    }
            //    else
            //        this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Promotion", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //    ReportDoc.SetDataSource(MyDataTable);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            //case "EmpLVBalance":
            //    //Report no 19 :Leave Balance
            //    string strSubTypeStat = Session["EmpSubTypeStatus"].ToString();
            //    if (Session["Flag"].ToString() == "E")
            //    {
            //        DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //        if (dtDivSbuDept.Rows.Count > 0)
            //        {
            //            foreach (DataRow tt in dtDivSbuDept.Rows)
            //            {
            //                strSubTypeStat = tt["EST"].ToString().Trim();
            //            }

            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }
            //    if (strSubTypeStat == "MP" || strSubTypeStat == "MC" || strSubTypeStat == "NP")
            //    {
            //        ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveBalance.rpt");
            //        ReportDoc.Load(ReportPath);
            //        MyDataTable = rptManager.Get_EmpLeaveBalance(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
            //            Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["DivisionId"].ToString(), Session["SbuId"].ToString(),
            //            Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["LocId"].ToString(), Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["EmpId"].ToString(), Session["isClosed"].ToString());

            //        dsEmployeeLeave dsEmp = new dsEmployeeLeave();
            //        foreach (DataRow sRow in MyDataTable.Rows)
            //        {
            //            Int32 lngCount = CountRecord("EmpId='" + sRow["EmpId"].ToString() + "'", dsEmp.dtEmpLeave);
            //            if (lngCount == 0)
            //            {
            //                DataRow dRow = dsEmp.dtEmpLeave.NewRow();
            //                dRow["EmpId"] = sRow["EmpId"];
            //                dRow["Name"] = sRow["FullName"];
            //                dRow["Dept"] = sRow["DeptName"];
            //                dRow["CL"] = 0;
            //                dRow["SL"] = 0;
            //                dRow["EL"] = 0;
            //                if (sRow["LAbbrName"].ToString() == "CL")
            //                {
            //                    DataRow myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountCL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='CL'", MyDataTable);
            //                    dRow["CL"] = strCountCL;
            //                }
            //                if (sRow["LAbbrName"].ToString() == "SL")
            //                {
            //                    DataRow myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountSL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='SL'", MyDataTable);
            //                    dRow["SL"] = strCountSL;
            //                }
            //                if (sRow["LAbbrName"].ToString() == "EL")
            //                {
            //                    DataRow myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountSL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='EL'", MyDataTable);
            //                    dRow["EL"] = strCountSL;
            //                }
            //                dsEmp.dtEmpLeave.Rows.Add(dRow);
            //                dsEmp.dtEmpLeave.AcceptChanges();
            //            }
            //            else
            //            {
            //                DataRow[] foundRows = dsEmp.dtEmpLeave.Select("EmpId='" + sRow["EmpId"].ToString() + "'");
            //                if (sRow["LAbbrName"].ToString() == "CL")
            //                {
            //                    DataRow myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountCL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='CL'", MyDataTable);
            //                    foundRows[0]["CL"] = strCountCL;
            //                }
            //                if (sRow["LAbbrName"].ToString() == "SL")
            //                {
            //                    DataRow myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountSL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='SL'", MyDataTable);
            //                    foundRows[0]["SL"] = strCountSL;
            //                }
            //                if (sRow["LAbbrName"].ToString() == "EL")
            //                {
            //                    DataRow myEditDataRow = dsEmp.dtEmpLeave.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountSL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='EL'", MyDataTable);
            //                    foundRows[0]["EL"] = strCountSL;
            //                }
            //                dsEmp.dtEmpLeave.AcceptChanges();
            //            }
            //        }

            //        if (Session["Flag"].ToString() == "E")
            //        {
            //            DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //            if (dtDivSbuDept.Rows.Count > 0)
            //            {
            //                foreach (DataRow tt in dtDivSbuDept.Rows)
            //                {
            //                    this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //                }
            //            }
            //            else
            //                this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

            //        ReportDoc.SetDataSource(dsEmp);
            //        CRV.ReportSource = ReportDoc;
            //    }
            //    else if (strSubTypeStat == "NT")
            //    {
            //        ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveCL.rpt");
            //        ReportDoc.Load(ReportPath);

            //        //ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveGL.rpt");
            //        //ReportDoc.Load(ReportPath);
            //        MyDataTable = rptManager.Get_EmpLeaveBalance(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
            //            Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["DivisionId"].ToString(), Session["SbuId"].ToString(),
            //            Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["LocId"].ToString(), Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["EmpId"].ToString(), Session["isClosed"].ToString());

            //        dsEmpLeaveCL dsEmpCL = new dsEmpLeaveCL();
            //        foreach (DataRow sRow in MyDataTable.Rows)
            //        {
            //            Int32 lngCount = CountRecord("EmpId='" + sRow["EmpId"].ToString() + "'", dsEmpCL.dtEmpLeaveCL);
            //            if (lngCount == 0)
            //            {
            //                DataRow dRow = dsEmpCL.dtEmpLeaveCL.NewRow();
            //                dRow["EmpId"] = sRow["EmpId"];
            //                dRow["Name"] = sRow["FullName"];
            //                dRow["Dept"] = sRow["DeptName"];
            //                dRow["CL"] = 0;
            //                if (sRow["LAbbrName"].ToString() == "CL")
            //                {
            //                    // DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountCL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='CL'", MyDataTable);
            //                    dRow["CL"] = strCountCL;
            //                }

            //                dsEmpCL.dtEmpLeaveCL.Rows.Add(dRow);
            //                dsEmpCL.dtEmpLeaveCL.AcceptChanges();
            //            }
            //            else
            //            {
            //                DataRow[] foundRows = dsEmpCL.dtEmpLeaveCL.Select("EmpId='" + sRow["EmpId"].ToString() + "'");
            //                if (sRow["LAbbrName"].ToString() == "CL")
            //                {
            //                    //DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountCL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='CL'", MyDataTable);
            //                    foundRows[0]["CL"] = strCountCL;
            //                }

            //                dsEmpCL.dtEmpLeaveCL.AcceptChanges();
            //            }

            //        }


            //        if (Session["Flag"].ToString() == "E")
            //        {
            //            DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //            if (dtDivSbuDept.Rows.Count > 0)
            //            {
            //                foreach (DataRow tt in dtDivSbuDept.Rows)
            //                {
            //                    this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //                }
            //            }
            //            else
            //                this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

            //        ReportDoc.SetDataSource(dsEmpCL);
            //        CRV.ReportSource = ReportDoc;
            //    }
            //    else if (strSubTypeStat == "NC")
            //    {
            //        ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveGL.rpt");
            //        ReportDoc.Load(ReportPath);

            //        //ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveGL.rpt");
            //        //ReportDoc.Load(ReportPath);
            //        MyDataTable = rptManager.Get_EmpLeaveBalance(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
            //            Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["DivisionId"].ToString(), Session["SbuId"].ToString(),
            //            Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["LocId"].ToString(), Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["EmpId"].ToString(), Session["isClosed"].ToString());

            //        dsEmpLeaveGL dsEmpGL = new dsEmpLeaveGL();
            //        foreach (DataRow sRow in MyDataTable.Rows)
            //        {
            //            Int32 lngCount = CountRecord("EmpId='" + sRow["EmpId"].ToString() + "'", dsEmpGL.dtEmpLeaveGL);
            //            if (lngCount == 0)
            //            {
            //                DataRow dRow = dsEmpGL.dtEmpLeaveGL.NewRow();
            //                dRow["EmpId"] = sRow["EmpId"];
            //                dRow["Name"] = sRow["FullName"];
            //                dRow["Dept"] = sRow["DeptName"];
            //                dRow["GL"] = 0;
            //                if (sRow["LAbbrName"].ToString() == "GL")
            //                {
            //                    // DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountGL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='GL'", MyDataTable);
            //                    dRow["GL"] = strCountGL;
            //                }

            //                dsEmpGL.dtEmpLeaveGL.Rows.Add(dRow);
            //                dsEmpGL.dtEmpLeaveGL.AcceptChanges();
            //            }
            //            else
            //            {
            //                DataRow[] foundRows = dsEmpGL.dtEmpLeaveGL.Select("EmpId='" + sRow["EmpId"].ToString() + "'");
            //                if (sRow["LAbbrName"].ToString() == "GL")
            //                {
            //                    //DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
            //                    Int32 strCountGL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='GL'", MyDataTable);
            //                    foundRows[0]["GL"] = strCountGL;
            //                }

            //                dsEmpGL.dtEmpLeaveGL.AcceptChanges();
            //            }
            //        }


            //        if (Session["Flag"].ToString() == "E")
            //        {
            //            DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
            //            if (dtDivSbuDept.Rows.Count > 0)
            //            {
            //                foreach (DataRow tt in dtDivSbuDept.Rows)
            //                {
            //                    this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
            //                }
            //            }
            //            else
            //                this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
            //        }
            //        else
            //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

            //        ReportDoc.SetDataSource(dsEmpGL);
            //        CRV.ReportSource = ReportDoc;
            //    }
            //    break;
            //case "EmpStr":
            //    ReportPath = Server.MapPath("~/CrystalReports/rptEmpStrength.rpt");
            //    ReportDoc.Load(ReportPath);
            //    DataTable BaseDataTable = rptManager.Get_EmpStregth0();
            //    MyDataTable = rptManager.Get_EmpStregth(Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
            //        Session["DivisionId"].ToString(), Session["SbuId"].ToString(), Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["LocId"].ToString(), Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["isClosed"].ToString());
            //    if (MyDataTable == null)
            //        break;
            //    dsEmpStrength2 objEmpStrength2 = new dsEmpStrength2();
            //    foreach (DataRow dRow in BaseDataTable.Rows)
            //    {
            //        DataRow nRow = objEmpStrength2.dtEmpStrength2.NewRow();
            //        nRow["sId"] = dRow["sId"].ToString().Trim();
            //        nRow["sbuName"] = dRow["sbuName"].ToString().Trim();
            //        nRow["Department"] = dRow["Deptname"].ToString().Trim();
            //        objEmpStrength2.dtEmpStrength2.Rows.Add(nRow);
            //        objEmpStrength2.dtEmpStrength2.AcceptChanges();
            //    }
            //    foreach (DataRow eRow in objEmpStrength2.dtEmpStrength2.Rows)
            //    {
            //        DataRow fRow = objEmpStrength2.dtEmpStrength2.Rows.Find(eRow["sId"]);
            //        fRow["G-12"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "12", MyDataTable);
            //        fRow["G-11"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "11", MyDataTable);
            //        fRow["G-10"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "10", MyDataTable);
            //        fRow["G-09"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "9", MyDataTable);
            //        fRow["G-08"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "8", MyDataTable);
            //        fRow["G-07"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "7", MyDataTable);
            //        fRow["G-06"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "6", MyDataTable);
            //        fRow["G-05"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "5", MyDataTable);
            //        fRow["G-04"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "4", MyDataTable);
            //        fRow["G-03"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "3", MyDataTable);
            //        fRow["G-02"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "2", MyDataTable);
            //        fRow["G-01"] = CountStregth(fRow["sbuName"].ToString(), fRow["Department"].ToString(), "1", MyDataTable);
            //        fRow["Temp"] = CountStregthTemp(fRow["sbuName"].ToString(), fRow["Department"].ToString(), MyDataTable);
            //        fRow["Contractual"] = CountStregthContrac(fRow["sbuName"].ToString(), fRow["Department"].ToString(), MyDataTable);
            //        fRow["MgtTotal"] = CountStregthMan(fRow["sbuName"].ToString(), fRow["Department"].ToString(), MyDataTable);
            //        fRow["NonMgtTotal"] = CountStregthNonMan(fRow["sbuName"].ToString(), fRow["Department"].ToString(), MyDataTable);
            //        fRow["Total"] = CountStregthTotal(fRow["sbuName"].ToString(), fRow["Department"].ToString(), MyDataTable);
            //        objEmpStrength2.dtEmpStrength2.AcceptChanges();
            //    }
            //    ReportDoc.SetDataSource(objEmpStrength2);
            //    CRV.ReportSource = ReportDoc;
            //    break;
            
        //    case "LvCL":
        //        //Report no 19 :Leave Balance CL
        //        if (Session["EmpSubTypeStatus"].ToString() != "NT")
        //            return;
        //        ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveCL.rpt");
        //        ReportDoc.Load(ReportPath);

        //        //ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveGL.rpt");
        //        //ReportDoc.Load(ReportPath);
        //        MyDataTable = rptManager.Get_EmpLeaveBalance(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
        //            Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["DivisionId"].ToString(), Session["SbuId"].ToString(),
        //            Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["LocId"].ToString(), Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["EmpId"].ToString(), Session["isClosed"].ToString());

        //        dsEmpLeaveCL dsEmpCL = new dsEmpLeaveCL();
        //        foreach (DataRow sRow in MyDataTable.Rows)
        //        {
        //            Int32 lngCount = CountRecord("EmpId='" + sRow["EmpId"].ToString() + "'", dsEmpCL.dtEmpLeaveCL);
        //            if (lngCount == 0)
        //            {
        //                DataRow dRow = dsEmpCL.dtEmpLeaveCL.NewRow();
        //                dRow["EmpId"] = sRow["EmpId"];
        //                dRow["Name"] = sRow["FullName"];
        //                dRow["Dept"] = sRow["DeptName"];
        //                dRow["CL"] = 0;
        //                if (sRow["LAbbrName"].ToString() == "CL")
        //                {
        //                    // DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
        //                    Int32 strCountCL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='CL'", MyDataTable);
        //                    dRow["CL"] = strCountCL;
        //                }

        //                dsEmpCL.dtEmpLeaveCL.Rows.Add(dRow);
        //                dsEmpCL.dtEmpLeaveCL.AcceptChanges();
        //            }
        //            else
        //            {
        //                DataRow[] foundRows = dsEmpCL.dtEmpLeaveCL.Select("EmpId='" + sRow["EmpId"].ToString() + "'");
        //                if (sRow["LAbbrName"].ToString() == "CL")
        //                {
        //                    //DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
        //                    Int32 strCountCL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='CL'", MyDataTable);
        //                    foundRows[0]["CL"] = strCountCL;
        //                }

        //                dsEmpCL.dtEmpLeaveCL.AcceptChanges();
        //            }

        //        }


        //        if (Session["Flag"].ToString() == "E")
        //        {
        //            DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
        //            if (dtDivSbuDept.Rows.Count > 0)
        //            {
        //                foreach (DataRow tt in dtDivSbuDept.Rows)
        //                {
        //                    this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
        //                }
        //            }
        //            else
        //                this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
        //        }
        //        else
        //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

        //        ReportDoc.SetDataSource(dsEmpCL);
        //        CRV.ReportSource = ReportDoc;
        //        break;
        //    case "LvGL":
        //        //Report no 19 :Leave Balance GL
        //        ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveGL.rpt");
        //        ReportDoc.Load(ReportPath);

        //        //ReportPath = Server.MapPath("~/CrystalReports/rptEmpLeaveGL.rpt");
        //        //ReportDoc.Load(ReportPath);
        //        MyDataTable = rptManager.Get_EmpLeaveBalance(Session["Flag"].ToString(), Session["USERID"].ToString(), Session["ISADMIN"].ToString(),
        //            Session["FromDate"].ToString(), Session["ToDate"].ToString(), Session["DivisionId"].ToString(), Session["SbuId"].ToString(),
        //            Session["DeptId"].ToString(), Session["SectionId"].ToString(), Session["LocId"].ToString(), Session["EmpTypeStatus"].ToString(), Session["EmpSubTypeStatus"].ToString(), Session["EmpId"].ToString(), Session["isClosed"].ToString());

        //        dsEmpLeaveGL dsEmpGL = new dsEmpLeaveGL();
        //        foreach (DataRow sRow in MyDataTable.Rows)
        //        {
        //            Int32 lngCount = CountRecord("EmpId='" + sRow["EmpId"].ToString() + "'", dsEmpGL.dtEmpLeaveGL);
        //            if (lngCount == 0)
        //            {
        //                DataRow dRow = dsEmpGL.dtEmpLeaveGL.NewRow();
        //                dRow["EmpId"] = sRow["EmpId"];
        //                dRow["Name"] = sRow["FullName"];
        //                dRow["Dept"] = sRow["DeptName"];
        //                dRow["GL"] = 0;
        //                if (sRow["LAbbrName"].ToString() == "GL")
        //                {
        //                    // DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
        //                    Int32 strCountGL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='GL'", MyDataTable);
        //                    dRow["GL"] = strCountGL;
        //                }

        //                dsEmpGL.dtEmpLeaveGL.Rows.Add(dRow);
        //                dsEmpGL.dtEmpLeaveGL.AcceptChanges();
        //            }
        //            else
        //            {
        //                DataRow[] foundRows = dsEmpGL.dtEmpLeaveGL.Select("EmpId='" + sRow["EmpId"].ToString() + "'");
        //                if (sRow["LAbbrName"].ToString() == "GL")
        //                {
        //                    //DataRow myEditDataRow = dsEmpGL.dtEmpLeaveGL.Rows.Find(sRow["EmpId"]);
        //                    Int32 strCountGL = CountLeaveTypeRecord("EmpId='" + sRow["EmpId"].ToString() + "' and LAbbrName='GL'", MyDataTable);
        //                    foundRows[0]["GL"] = strCountGL;
        //                }

        //                dsEmpGL.dtEmpLeaveGL.AcceptChanges();
        //            }
        //        }


        //        if (Session["Flag"].ToString() == "E")
        //        {
        //            DataTable dtDivSbuDept = rptManager.Select_DivSbuDept(Session["EmpId"].ToString());
        //            if (dtDivSbuDept.Rows.Count > 0)
        //            {
        //                foreach (DataRow tt in dtDivSbuDept.Rows)
        //                {
        //                    this.PassParameter3Ts(tt["DivisionName"].ToString(), tt["SBUName"].ToString(), tt["DeptName"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", tt["TypeStatus"].ToString().Trim(), tt["EmpSubTypeStatus"].ToString().Trim());
        //                }
        //            }
        //            else
        //                this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());
        //        }
        //        else
        //            this.PassParameter3Ts(Session["Div"].ToString(), Session["Sbu"].ToString(), Session["Dep"].ToString().Trim(), Session["FromDate"].ToString(), Session["ToDate"].ToString(), "Leave Balance Sumamry", Session["EmpTypeStatusS"].ToString(), Session["EmpSubTypeStatusS"].ToString());

        //        ReportDoc.SetDataSource(dsEmpGL);
        //        CRV.ReportSource = ReportDoc;
        //        break;

        }
    }

    public void PassParameter(string div, string sbu, string dep)
    {
        //Generate ParameterFields 
        ParameterFields pFields = new ParameterFields();
        //Generate ParameterField
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSbu = new ParameterField();
        ParameterField pfDep = new ParameterField();
        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSbu = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSbu.Name = "pSBU";
        dvSbu.Value = sbu;
        pfSbu.CurrentValues.Add(dvSbu);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfDiv);
        pFields.Add(pfSbu);
        pFields.Add(pfDep);
        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;        
    }

    public void PassParameter3(string div, string sbu, string dep, string FromDate, string ToDate, string ReportName)
    {
        //Generate ParameterFields 
        ParameterFields pFields = new ParameterFields();
        //Generate ParameterField
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSbu = new ParameterField();
        ParameterField pfDep = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        ParameterField pfHeader = new ParameterField();


        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSbu = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSbu.Name = "pSBU";
        dvSbu.Value = sbu;
        pfSbu.CurrentValues.Add(dvSbu);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfDiv);
        pFields.Add(pfSbu);
        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);
        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }
    public void PassParameter3Ts(string div, string sbu, string dep, string FromDate, string ToDate, string ReportName,string empType,string empstatus)
    {
        //Generate ParameterFields 
        ParameterFields pFields = new ParameterFields();
        //Generate ParameterField
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSbu = new ParameterField();
        ParameterField pfDep = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        ParameterField pfHeader = new ParameterField();
        ParameterField pfEtype = new ParameterField();
        ParameterField pfEStatus = new ParameterField();

        if (empType == "")
            empType = "All";
        if (empstatus == "")
            empstatus = "All";

        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSbu = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEtype = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEStatus = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSbu.Name = "pSBU";
        dvSbu.Value = sbu;
        pfSbu.CurrentValues.Add(dvSbu);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfEtype.Name = "pEType";
        dvEtype.Value = empType;
        pfEtype.CurrentValues.Add(dvEtype);

        pfEStatus.Name = "pEStatus";
        dvEStatus.Value = empstatus;
        pfEStatus.CurrentValues.Add(dvEStatus);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfDiv);
        pFields.Add(pfSbu);
        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);
        pFields.Add(pfEtype);
        pFields.Add(pfEStatus);

        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }
    public void PassParameter3TsWD(string div, string sbu, string dep,  string ReportName, string empType, string empstatus)
    {
        //Generate ParameterFields 
        ParameterFields pFields = new ParameterFields();
        //Generate ParameterField
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSbu = new ParameterField();
        ParameterField pfDep = new ParameterField();
        
        ParameterField pfHeader = new ParameterField();
        ParameterField pfEtype = new ParameterField();
        ParameterField pfEStatus = new ParameterField();

        if (empType == "")
            empType = "All";
        if (empstatus == "")
            empstatus = "All";

        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSbu = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
       
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEtype = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEStatus = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSbu.Name = "pSBU";
        dvSbu.Value = sbu;
        pfSbu.CurrentValues.Add(dvSbu);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

      

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfEtype.Name = "pEType";
        dvEtype.Value = empType;
        pfEtype.CurrentValues.Add(dvEtype);

        pfEStatus.Name = "pEStatus";
        dvEStatus.Value = empstatus;
        pfEStatus.CurrentValues.Add(dvEStatus);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfDiv);
        pFields.Add(pfSbu);
        pFields.Add(pfDep);
       
        pFields.Add(pfHeader);
        pFields.Add(pfEtype);
        pFields.Add(pfEStatus);

        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }
    public void PassParameter4(string div, string sbu, string dep, string FromDate, string ToDate, string ReportName,string psrcsbu)
    {
       
        ParameterFields pFields = new ParameterFields();   
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSbu = new ParameterField();
        ParameterField pfDep = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        ParameterField pfHeader = new ParameterField();
        ParameterField pfpsrcsbu = new ParameterField();

        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSbu = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        ParameterDiscreteValue dvpsrcsbu = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSbu.Name = "pSBU";
        dvSbu.Value = sbu;
        pfSbu.CurrentValues.Add(dvSbu);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfpsrcsbu.Name = "psrcsbu";
        dvpsrcsbu.Value = psrcsbu;
        pfpsrcsbu.CurrentValues.Add(dvpsrcsbu);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfDiv);
        pFields.Add(pfSbu);
        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);
        pFields.Add(pfpsrcsbu);
        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }

    public void PassParameterNew(string dep, string FromDate, string ToDate, string ReportName, string empType, string empstatus)
    {

        ParameterFields pFields = new ParameterFields();

        ParameterField pfDep = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        ParameterField pfHeader = new ParameterField();

        ParameterField pfEtype = new ParameterField();
        ParameterField pfEStatus = new ParameterField();

        if (empType == "")
            empType = "All";
        if (empstatus == "")
            empstatus = "All";

        //Generate ParameterDiscreteValue

        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();

        ParameterDiscreteValue dvEtype = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEStatus = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfEtype.Name = "pEType";
        dvEtype.Value = empType;
        pfEtype.CurrentValues.Add(dvEtype);

        pfEStatus.Name = "pEStatus";
        dvEStatus.Value = empstatus;
        pfEStatus.CurrentValues.Add(dvEStatus);

        //Adding Parameters to ParameterFields 

        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);

        pFields.Add(pfEtype);
        pFields.Add(pfEStatus);
        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }

    //public void PassParameterPLAN(string Div, string SBU, string FromDate, string ToDate, string ReportName)
    //{

    //    ParameterFields pFields = new ParameterFields();
    //    ParameterField pfDiv = new ParameterField();
    //    ParameterField pfSBU = new ParameterField();
    //    ParameterField pfFromDate = new ParameterField();
    //    ParameterField pfToDate = new ParameterField();
    //    ParameterField pfHeader = new ParameterField();
    //    //ParameterField pfEtype = new ParameterField();

    //    //Generate ParameterDiscreteValue
    //    ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
    //    ParameterDiscreteValue dvSBU = new ParameterDiscreteValue();
    //    ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
    //    ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
    //    ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
    //    //ParameterDiscreteValue dvEtype = new ParameterDiscreteValue();

    //  //Adding ParameterDiscreteValue to ParameterField

    //    pfDiv.Name = "pDiv";
    //    dvDiv.Value = Div;
    //    pfDiv.CurrentValues.Add(dvDiv);

    //    pfSBU.Name = "pSBU";
    //    dvSBU.Value = SBU;
    //    pfSBU.CurrentValues.Add(dvSBU);
      
    //    pfFromDate.Name = "FromDate";
    //    dvFromDate.Value = FromDate;
    //    pfFromDate.CurrentValues.Add(dvFromDate);

    //    pfToDate.Name = "ToDate";
    //    dvToDate.Value = ToDate;
    //    pfToDate.CurrentValues.Add(dvToDate);

    //    pfHeader.Name = "pHeader";
    //    dvHeader.Value = ReportName;
    //    pfHeader.CurrentValues.Add(dvHeader);

    //    //pfEtype.Name = "pEType";
    //    //dvEtype.Value = empType;
    //    //pfEtype.CurrentValues.Add(dvEtype);
      
    //    //Adding Parameters to ParameterFields         
    //    pFields.Add(pfDiv);
    //    pFields.Add(pfSBU);
    //    pFields.Add(pfFromDate);
    //    pFields.Add(pfToDate);
    //    pFields.Add(pfHeader);
    //    //pFields.Add(pfEtype);

    //    //Passing ParameterFields to CrystalReportViewer
    //    CRV.ParameterFieldInfo = pFields;

    //}

    public void PassParameterPLAN(string Div, string SBU, string dep, string FromDate, string ToDate, string ReportName)
    {
        ParameterFields pFields = new ParameterFields();
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSBU = new ParameterField();
        ParameterField pfDep = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        ParameterField pfHeader = new ParameterField();
        //ParameterField pfEtype = new ParameterField();

        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSBU = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        //ParameterDiscreteValue dvEtype = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField

        pfDiv.Name = "pDiv";
        dvDiv.Value = Div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSBU.Name = "pSBU";
        dvSBU.Value = SBU;
        pfSBU.CurrentValues.Add(dvSBU);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        //pfEtype.Name = "pEType";
        //dvEtype.Value = empType;
        //pfEtype.CurrentValues.Add(dvEtype);

        //Adding Parameters to ParameterFields         
        pFields.Add(pfDiv);
        pFields.Add(pfSBU);
        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);
        //pFields.Add(pfEtype);

        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }

    public void PassParameter6(string div, string sbu, string dep, string FromDate, string ToDate, string ReportName, string psrcsbu,string empType,string empstatus)
    {

        ParameterFields pFields = new ParameterFields();
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSbu = new ParameterField();
        ParameterField pfDep = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        ParameterField pfHeader = new ParameterField();
        ParameterField pfpsrcsbu = new ParameterField();
        ParameterField pfEtype = new ParameterField();
        ParameterField pfEStatus = new ParameterField();

        if (empType == "")
            empType = "All";
        if (empstatus == "")
              empstatus = "All";
        
        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSbu = new ParameterDiscreteValue();

        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        ParameterDiscreteValue dvpsrcsbu = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEtype = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEStatus = new ParameterDiscreteValue();
       
        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSbu.Name = "pSBU";
        dvSbu.Value = sbu;
        pfSbu.CurrentValues.Add(dvSbu);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfpsrcsbu.Name = "psrcsbu";
        dvpsrcsbu.Value = psrcsbu;
        pfpsrcsbu.CurrentValues.Add(dvpsrcsbu);

        pfEtype.Name = "pEType";
        dvEtype.Value = empType;
        pfEtype.CurrentValues.Add(dvEtype);

        pfEStatus.Name = "pEStatus";
        dvEStatus.Value = empstatus;
        pfEStatus.CurrentValues.Add(dvEStatus);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfDiv);
        pFields.Add(pfSbu);
        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);
        pFields.Add(pfpsrcsbu);
        pFields.Add(pfEtype);
        pFields.Add(pfEStatus);
        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }

    private void PassDateParameter(string sDate, string eDate)
    {
        //Generate ParameterFields 
        ParameterFields pFields = new ParameterFields();
        //Generate ParameterField
        ParameterField pfSDATE = new ParameterField();
        ParameterField pfEDATE = new ParameterField();

        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvSDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEDate = new ParameterDiscreteValue();


        //Adding ParameterDiscreteValue to ParameterField
        pfSDATE.Name = "pSDATE";
        dvSDate.Value = Convert.ToDateTime(sDate);
        pfSDATE.CurrentValues.Add(dvSDate);

        pfEDATE.Name = "pEDATE";
        dvEDate.Value = Convert.ToDateTime(eDate);
        pfEDATE.CurrentValues.Add(dvEDate);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfSDATE);
        pFields.Add(pfEDATE);

        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;
    }

    public void PassParameterAttndEmpWisePLAN(string div, string SBU, string dep, string FromDate, string ToDate, string ReportName, string strPresent, string strAbsent, string strLeave, string strDelay, string strWeekend, string strHoliday)
    {
        //Generate ParameterFields 
        ParameterFields pFields = new ParameterFields();
        //Generate ParameterField        
        ParameterField pfDiv = new ParameterField();
        ParameterField pfSBU = new ParameterField();
        ParameterField pfDep = new ParameterField();
        ParameterField pfHeader = new ParameterField();
             
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        

        ParameterField pfP = new ParameterField();
        ParameterField pfA = new ParameterField();
        ParameterField pfL = new ParameterField();
        ParameterField pfD = new ParameterField();
        ParameterField pfW = new ParameterField();
        ParameterField pfH = new ParameterField();
        
        //Generate ParameterDiscreteValue        
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSBU = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        
        ParameterDiscreteValue dvP = new ParameterDiscreteValue();
        ParameterDiscreteValue dvA = new ParameterDiscreteValue();
        ParameterDiscreteValue dvL = new ParameterDiscreteValue();
        ParameterDiscreteValue dvD = new ParameterDiscreteValue();
        ParameterDiscreteValue dvW = new ParameterDiscreteValue();
        ParameterDiscreteValue dvH = new ParameterDiscreteValue();

        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSBU.Name = "pSBU";
        dvSBU.Value = SBU;
        pfSBU.CurrentValues.Add(dvSBU);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfP.Name = "pP";
        dvP.Value = strPresent;
        pfP.CurrentValues.Add(dvP);
        pfA.Name = "pA";
        dvA.Value = strAbsent;
        pfA.CurrentValues.Add(dvA);
        pfL.Name = "pL";
        dvL.Value = strLeave;
        pfL.CurrentValues.Add(dvL);
        pfD.Name = "pD";
        dvD.Value = strDelay;
        pfD.CurrentValues.Add(dvD);
        pfW.Name = "pW";
        dvW.Value = strWeekend;
        pfW.CurrentValues.Add(dvW);

        pfH.Name = "pH";
        dvH.Value = strHoliday;
        pfH.CurrentValues.Add(dvH);

        //Adding Parameters to ParameterFields     
        pFields.Add(pfDiv);
        pFields.Add(pfSBU);
        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);
        pFields.Add(pfP);
        pFields.Add(pfA);
        pFields.Add(pfL);
        pFields.Add(pfD);
        pFields.Add(pfW);
        pFields.Add(pfH);
        
        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }

    public void PassParameterAttndEmpWise(string div, string sbu, string dep, string FromDate, string ToDate, string ReportName, string strPresent, string strAbsent, string strLeave, string strDelay, string strWeekend, string strHoliday, string empType, string empstatus)
    {
        //Generate ParameterFields 
        ParameterFields pFields = new ParameterFields();
        //Generate ParameterField
        ParameterField pfDiv = new ParameterField();
        ParameterField pfHeader = new ParameterField();
        ParameterField pfSbu = new ParameterField();
        ParameterField pfDep = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();
        ParameterField pfEtype = new ParameterField();
        ParameterField pfEStatus = new ParameterField();

        ParameterField pfP = new ParameterField();
        ParameterField pfA = new ParameterField();
        ParameterField pfL = new ParameterField();
        ParameterField pfD = new ParameterField();
        ParameterField pfW = new ParameterField();
        ParameterField pfH = new ParameterField();


        //Generate ParameterDiscreteValue
        ParameterDiscreteValue dvDiv = new ParameterDiscreteValue();
        ParameterDiscreteValue dvSbu = new ParameterDiscreteValue();
        ParameterDiscreteValue dvDep = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEtype = new ParameterDiscreteValue();
        ParameterDiscreteValue dvEStatus = new ParameterDiscreteValue();

        ParameterDiscreteValue dvP = new ParameterDiscreteValue();
        ParameterDiscreteValue dvA = new ParameterDiscreteValue();
        ParameterDiscreteValue dvL = new ParameterDiscreteValue();
        ParameterDiscreteValue dvD = new ParameterDiscreteValue();
        ParameterDiscreteValue dvW = new ParameterDiscreteValue();
        ParameterDiscreteValue dvH = new ParameterDiscreteValue();
        if (empType == "")
            empType = "All";
        if (empstatus == "")
            empstatus = "All";
        //Adding ParameterDiscreteValue to ParameterField
        pfDiv.Name = "pDIV";
        dvDiv.Value = div;
        pfDiv.CurrentValues.Add(dvDiv);

        pfSbu.Name = "pSBU";
        dvSbu.Value = sbu;
        pfSbu.CurrentValues.Add(dvSbu);

        pfDep.Name = "pDEP";
        dvDep.Value = dep;
        pfDep.CurrentValues.Add(dvDep);

        pfFromDate.Name = "FromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "ToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfP.Name = "pP";
        dvP.Value = strPresent;
        pfP.CurrentValues.Add(dvP);
        pfA.Name = "pA";
        dvA.Value = strAbsent;
        pfA.CurrentValues.Add(dvA);
        pfL.Name = "pL";
        dvL.Value = strLeave;
        pfL.CurrentValues.Add(dvL);
        pfD.Name = "pD";
        dvD.Value = strDelay;
        pfD.CurrentValues.Add(dvD);
        pfW.Name = "pW";
        dvW.Value = strWeekend;
        pfW.CurrentValues.Add(dvW);

        pfH.Name = "pH";
        dvH.Value = strHoliday;
        pfH.CurrentValues.Add(dvH);

        pfEtype.Name = "pEType";
        dvEtype.Value = empType;
        pfEtype.CurrentValues.Add(dvEtype);

        pfEStatus.Name = "pEStatus";
        dvEStatus.Value = empstatus;
        pfEStatus.CurrentValues.Add(dvEStatus);

        //Adding Parameters to ParameterFields 
        pFields.Add(pfDiv);
        pFields.Add(pfSbu);
        pFields.Add(pfDep);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);
        pFields.Add(pfHeader);
        pFields.Add(pfP);
        pFields.Add(pfA);
        pFields.Add(pfL);
        pFields.Add(pfD);
        pFields.Add(pfW);
        pFields.Add(pfH);
        pFields.Add(pfEtype);
        pFields.Add(pfEStatus);

        //Passing ParameterFields to CrystalReportViewer
        CRV.ParameterFieldInfo = pFields;

    }

    //private void Fill_MST_Data(DataTable myDTMst)
    //{
    //    foreach (DataRow row in myDTMst.Rows)
    //    {
    //        DataRow mRow = dsMA.dtMST.NewRow();
    //        mRow["EmpId"] = row[0].ToString().Trim();
    //        mRow["Name"] = row[1];
    //        mRow["Designation"] = row[2];            
    //        dsMA.dtMST.Rows.Add(mRow);
    //        dsMA.dtMST.AcceptChanges();
    //    }
    //}

    //private void Fill_DET_Data(DataTable myDET, DataTable myMst)
    //{
    //    DataRow[] foundRows;
    //    DataRow[] foundAttnRow;
    //    string strExpr = "";
    //    string strOrder = "";
    //    DateTime dtAttnDate;
    //    string strAttnDate = "";      
    //    int i = 1;
    //    foreach (DataRow mRow in myMst.Rows)
    //    {
    //        strExpr = "empid='" + mRow["empid"].ToString().Trim() + "'";
    //        strOrder = "MDate ";
    //        foundRows = myDET.Select(strExpr, strOrder);
    //        dtAttnDate = Convert.ToDateTime(Session["FromDate"].ToString());
    //        dRowIn = dsMA.dtDET.NewRow();
    //        dRowOut = dsMA.dtDET.NewRow();
    //        if (foundRows.Length > 0)
    //        {
    //            i = 1;
    //            for (i = 1; i <= 31; i++)
    //            {
    //                dRowIn["empid"] = mRow["empid"].ToString().Trim();
    //                dRowOut["empid"] = mRow["empid"].ToString().Trim();
    //                strAttnDate = dtAttnDate.Year + "/" + dtAttnDate.Month + "/" + i.ToString();
    //                strExpr = "empid='" + mRow["empid"].ToString().Trim() + "' AND MDate='" + strAttnDate + "'";
    //                foundAttnRow = myDET.Select(strExpr);
    //                if (foundAttnRow.Length > 0)
    //                {
    //                    if (string.IsNullOrEmpty(foundAttnRow[0]["SignIn"].ToString()) == true)
    //                    {
    //                        if (string.IsNullOrEmpty(foundAttnRow[0]["SignOut"].ToString()) == true)
    //                        {
    //                            dRowIn[i] = foundAttnRow[0]["Status"];
    //                            dRowOut[i] = "";
    //                        }
    //                        else
    //                        {
    //                            dRowIn[i] = "";
    //                            dRowOut[i] = Common.DisplayTime24h(foundAttnRow[0]["SignOut"].ToString());
    //                        }
    //                    }
    //                    else
    //                    {
    //                        dRowIn[i] = Common.DisplayTime24h(foundAttnRow[0]["SignIn"].ToString());
    //                        if (string.IsNullOrEmpty(foundAttnRow[0]["SignOut"].ToString()) == true)
    //                            dRowOut[i] = "";
    //                        else
    //                            dRowOut[i] = Common.DisplayTime24h(foundAttnRow[0]["SignOut"].ToString());
    //                    }

    //                }
    //                else
    //                {
    //                    dRowIn[i] = "";
    //                    dRowOut[i] = "";
    //                }
    //            }
    //        }
    //        else
    //        {
    //            int j = 1;
    //            dRowIn["empid"] = mRow["empid"].ToString().Trim();
    //            dRowOut["empid"] = mRow["empid"].ToString().Trim();
    //            for (j = 1; j <= 31; j++)
    //            {
    //                dRowIn[j] = "";
    //                dRowOut[j] = "";
    //            }
    //        }
    //        dsMA.dtDET.Rows.Add(dRowIn);
    //        dsMA.dtDET.Rows.Add(dRowOut);
    //        dsMA.dtDET.AcceptChanges();
    //    }
    //}
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void CRV_Unload(object sender, EventArgs e)
    {
        ReportDoc.Close();
        ReportDoc.Dispose();
        ReportDoc = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    protected void CRV_BeforeRender(object source, CrystalDecisions.Web.HtmlReportRender.BeforeRenderEvent e)
    {
        Page.ClientScript.RegisterForEventValidation(CRV.UniqueID);
    }

    protected string CountStatus(string strStatus, DataTable dt)

    {
        //useless function
        string strExpr = "Status='" + strStatus + "'";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToString (foundRows.Length);
    }    
    protected string CountStatusPresent( string strEmpId,DataTable dt)
    {
        string strExpr = "Status in ('P','L','X') AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToString(foundRows.Length);
    }
    protected string CountAttndOnWeekend(string strStatus, string strEmpId, DataTable dt)
    {
        string strExpr = "Status in ('W','H') AND (SignInTime IS NOT NULL OR SignOutTime IS NOT NULL) AND SignInTime<>'1900-01-01' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToString(foundRows.Length);
    }
    
    private Int32 CountRecord(string strExpr, DataTable dt)
    {
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToInt32(foundRows.Length );
    }
    private Int32 CountLeaveTypeRecord(string strExpr, DataTable dt)
    {
        DataRow[] foundRows = dt.Select(strExpr);
        return (Convert.ToInt32(foundRows[0]["LCarryOverd"]==DBNull.Value ? "0":foundRows[0]["LCarryOverd"])
            + Convert.ToInt32(foundRows[0]["lvPrevYearCarry"] == DBNull.Value ? "0" : foundRows[0]["lvPrevYearCarry"])
            + Convert.ToInt32( foundRows[0]["LEntitled"]==DBNull.Value ? "0":foundRows[0]["LEntitled"])
            - Convert.ToInt32(foundRows[0]["LeaveEnjoyed"]==DBNull.Value ? "0":foundRows[0]["LeaveEnjoyed"])
            - Convert.ToInt32(foundRows[0]["lvOpening"]==DBNull.Value ? "0":foundRows[0]["lvOpening"] )
            );
    }
    protected string CountStatusEmpWise(string strStatus, string strEmpId, DataTable dt)
    {
        string strExpr = "Status='" + strStatus + "' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr); 
        return Convert.ToString(foundRows.Length);
    }
    protected string CountStatusEmpWiseleave(string strStatus, string strEmpId, DataTable dt)
    {
        string strExpr = "Status='LV' and LeaveFlag='" + strStatus + "' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToString(foundRows.Length);
    }
    protected Int32 CountStregth(string strsbuname, string strdeptname, string strGrade, DataTable dt)
    {
        string strExpr = "sbuname='" + strsbuname + "' AND Deptname='" + strdeptname + "' AND GradeId='" + strGrade + "'";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToInt32(foundRows.Length);
    }
    protected Int32 CountStregthTemp(string strsbuname, string strdeptname, DataTable dt)
    {
        string strExpr = "sbuname='" + strsbuname + "' AND Deptname='" + strdeptname + "' AND EmpStatus in('MT','NT')";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToInt32(foundRows.Length);
    }
    protected Int32 CountStregthContrac(string strsbuname, string strdeptname, DataTable dt)
    {
        string strExpr = "sbuname='" + strsbuname + "' AND Deptname='" + strdeptname + "' AND EmpStatus in('MC','NC')";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToInt32(foundRows.Length);
    }
    protected Int32 CountStregthMan(string strsbuname, string strdeptname, DataTable dt)
    {
        string strExpr = "sbuname='" + strsbuname + "' AND Deptname='" + strdeptname + "' AND Emptype in('M')";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToInt32(foundRows.Length);
    }
    protected Int32 CountStregthNonMan(string strsbuname, string strdeptname, DataTable dt)
    {
        string strExpr = "sbuname='" + strsbuname + "' AND Deptname='" + strdeptname + "' AND  Emptype in('N')";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToInt32(foundRows.Length);
    }

    protected Int32 CountStregthTotal(string strsbuname, string strdeptname, DataTable dt)
    {
        string strExpr = "sbuname='" + strsbuname + "' AND Deptname='" + strdeptname + "'";
        DataRow[] foundRows = dt.Select(strExpr);
        return Convert.ToInt32(foundRows.Length);
    }

    protected string GetTime(string FromDate, string strEmpId, DataTable dt, string InTime)
    {
        string strExpr = "AttanDate ='" + Common.ReturnDate(FromDate) + "' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);

        if (InTime == "Y" && foundRows.Length > 0)
        {
            if (foundRows[0]["InTime"].ToString() != "")
                return Convert.ToString(foundRows[0]["InTime"]);
            else
                return "";
        }
        else if (InTime == "N" && foundRows.Length > 0)
        {
            if (foundRows[0]["OutTime"].ToString() != "")
                return Convert.ToString(foundRows[0]["OutTime"]);
            else
                return "";
        }
        else
            return "";
    }

    protected string GetAttnStatus(string FromDate, string strEmpId, DataTable dt)
    {
        //DateTime dt1 = new DateTime();
        string strExpr = "AttanDate ='" + Common.ReturnDate(FromDate) + "' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);

        if (foundRows.Length > 0)
            return foundRows[0]["Status"].ToString();
        else
            return "";
    }
    protected string GetLocation(string FromDate, string strEmpId, DataTable dt, string InLoc)
    {
        string strExpr = "AttanDate ='" + Common.ReturnDate(FromDate) + "' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);

        if (InLoc == "Y" && foundRows.Length > 0)
        {
            if (foundRows[0]["InLocation"].ToString() != "")
                return foundRows[0]["InLocation"].ToString();
            else
                return "";
        }
        else if (InLoc == "N" && foundRows.Length > 0)
        {
            if (foundRows[0]["OutLocation"].ToString() != "")
                return foundRows[0]["OutLocation"].ToString();
            else
                return "";
        }
        else
            return "";
    }
    protected string GetLtHour(string FromDate, string strEmpId, DataTable dt)
    {
        //DateTime dt1 = new DateTime();
        string strExpr = "AttanDate ='" + Common.ReturnDate(FromDate) + "' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);

        if (foundRows.Length > 0)
            return foundRows[0]["LateHour"].ToString();
        else
            return "";
    }
    protected string GetIsManual(string FromDate, string strEmpId, DataTable dt)
    {
        //DateTime dt1 = new DateTime();
        string strExpr = "AttanDate ='" + Common.ReturnDate(FromDate) + "' AND EMPID='" + strEmpId + "'";
        DataRow[] foundRows = dt.Select(strExpr);

        if (foundRows.Length > 0 && foundRows[0]["Manual"].ToString() == "Y")

            return foundRows[0]["Manual"].ToString();
        else
            return "N";
    }
    private Int32 CountLeaveEntitled(string strExpr, DataTable dt)
    {
        DataRow[] foundRows = dt.Select(strExpr);
        if (foundRows.Length > 0)
            return (Convert.ToInt32(foundRows[0]["LCarryOverd"] == DBNull.Value ? "0" : foundRows[0]["LCarryOverd"])
                + Convert.ToInt32(foundRows[0]["lvPrevYearCarry"] == DBNull.Value ? "0" : foundRows[0]["lvPrevYearCarry"])
                + Convert.ToInt32(foundRows[0]["LEntitled"] == DBNull.Value ? "0" : foundRows[0]["LEntitled"]));
        else
            return 0;
    }
    private Int32 CountLeaveEnjoyed(string strExpr, DataTable dt)
    {
        DataRow[] foundRows = dt.Select(strExpr);
        if (foundRows.Length > 0)
            return (Convert.ToInt32(foundRows[0]["LeaveEnjoyed"] == DBNull.Value ? "0" : foundRows[0]["LeaveEnjoyed"])
                + Convert.ToInt32(foundRows[0]["lvOpening"] == DBNull.Value ? "0" : foundRows[0]["lvOpening"]));
        else
            return 0;
    }
    private Int32 CountLeaveBalance(string strExpr, DataTable dt)
    {
        DataRow[] foundRows = dt.Select(strExpr);
        if (foundRows.Length > 0)
            return (Convert.ToInt32(foundRows[0]["LCarryOverd"] == DBNull.Value ? "0" : foundRows[0]["LCarryOverd"])
                + Convert.ToInt32(foundRows[0]["lvPrevYearCarry"] == DBNull.Value ? "0" : foundRows[0]["lvPrevYearCarry"])
                + Convert.ToInt32(foundRows[0]["LEntitled"] == DBNull.Value ? "0" : foundRows[0]["LEntitled"])
                - Convert.ToInt32(foundRows[0]["LeaveEnjoyed"] == DBNull.Value ? "0" : foundRows[0]["LeaveEnjoyed"])
                - Convert.ToInt32(foundRows[0]["lvOpening"] == DBNull.Value ? "0" : foundRows[0]["lvOpening"])
                );
        else
            return 0;
    }




  
}
