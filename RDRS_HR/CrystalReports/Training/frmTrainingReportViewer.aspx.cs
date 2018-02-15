using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


public partial class frmTrainingReportViewer : System.Web.UI.Page
{
    private ReportDocument ReportDoc;
    private string ReportPath = "";
    private string LogoPath = System.Web.Configuration.WebConfigurationManager.AppSettings["LogoPath"];

    ReportManager rptManager = new ReportManager();
    DataTable MyDataTable = new DataTable();
   
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
        Page.ClientScript.RegisterForEventValidation(CRVT.UniqueID);
        base.Render(writer);
    }

    private void ConfigureCrystalReports()
    {
        ReportDoc = new ReportDocument();
        switch (Session["REPORTID"].ToString())
        {
            case "TLR":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptTrainingList.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetTrainingList(Session["FiscalYrId"].ToString(), Session["TrainingID"].ToString(), Session["LAreaId"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Training List ");
                CRVT.ReportSource = ReportDoc;
                break;
            case "TLPALAW":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptTrainingLstProgrmAndLearningAreaWise.rpt ");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetTrainingListProgramAndLearningAreaWise(Session["DeptId"].ToString(), Session["LAreaId"].ToString(), Session["TrainingID"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Training List Program And Learning Area Wise");
                CRVT.ReportSource = ReportDoc;
                break;
            case "MFPIT":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptMaleFemaleInTraining.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetMaleFemaleInTraining(Session["FiscalYrId"].ToString(),Session["TrainingID"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Male-Female Participation in Training");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "NTC":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptTrainingCriteria.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetTrainingCriteria(Session["EmpId"].ToString(), Session["FiscalYrId"].ToString(), Session["TrainingID"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "No Of Training Criteria:Team VS Individual Need");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "1":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptOrienTrainingReceivd.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetOrientationTraining(Session["REPORTID"].ToString(), Session["EmpStatus"].ToString(), Session["OTType"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Orientation Training Received");
                ReportDoc.SetParameterValue("pFromDate", Session["FromDate"].ToString());
                ReportDoc.SetParameterValue("pToDate", Session["ToDate"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "2":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptOrienTrainingReceivd.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetOrientationTraining(Session["REPORTID"].ToString(), Session["EmpStatus"].ToString(), Session["OTType"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Orientation Training Due");
                ReportDoc.SetParameterValue("pFromDate", Session["FromDate"].ToString());
                ReportDoc.SetParameterValue("pToDate", Session["ToDate"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "GWP":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptGradeWiseParticipants.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetGradeWiseParticipants(Session["FiscalYrId"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Grade Wise Participants");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;                
            case "MWTP":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptMonthWiseTrainingParticipants.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetMonthWiseTrainingParticipants(Session["FiscalYrId"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Month Wise Training Participants");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "IDP":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptIndividualDetailsOfParticipants.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetIndividualdetailsOfParticipants(Session["FiscalYrId"].ToString(), Session["EmpId"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Individual Details Of Participants");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;                
            case "LAWP":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptLearningAreaWiseParticipants.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetLearningAreaWiseParticipants(Session["LAreaId"].ToString(), Session["FiscalYrId"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Learning Area Wise Participants");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "TS":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptTrainingSlip.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetTrainingSlip(Session["FiscalYrId"].ToString(), Session["TrainingID"].ToString(), Session["EmpId"].ToString(), Session["DeptId"].ToString(), Session["TrainingType"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Training Slip");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "SWTI":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptTrainingSlip.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetTrainingSlip(Session["FiscalYrId"].ToString(), Session["TrainingID"].ToString(), Session["EmpId"].ToString(), Session["DeptId"].ToString(), Session["TrainingType"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", Session["PHeader"].ToString());
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "SWP":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptStateWiseParticipants.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetStateWiseParticipants(Session["FiscalYrId"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "No Of Participants: State Wise");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "QWP":
                ReportPath = Server.MapPath("~/CrystalReports/Training/rptQuarterWiseParticipants.rpt");
                ReportDoc.Load(ReportPath);
                MyDataTable = rptManager.GetQuarterWiseParticipants(Session["FiscalYrId"].ToString(), Session["EmpStatus"].ToString());
                ReportDoc.SetDataSource(MyDataTable);
                ReportDoc.SetParameterValue("pHeader", "Quarter Wise  Participants");
                ReportDoc.SetParameterValue("pFiscalYr", Session["FiscalYr"].ToString());
                CRVT.ReportSource = ReportDoc;
                break;
            case "ETD": 
                {
                    ReportPath = Server.MapPath("~/CrystalReports/Training/rptEmployeeTrainingDetails.rpt");
                    ReportDoc.Load(ReportPath);
                    MyDataTable = rptManager.GetEmployeeTrainingDetails(Session["TrainingID"].ToString(),Session["Intervension"].ToString(),Session["OfficeId"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString());
                    ReportDoc.SetDataSource(MyDataTable);
                    ReportDoc.SetParameterValue("PageHeader", "Employee Training Details");
                    ReportDoc.SetParameterValue("ComLogo", LogoPath);
                    CRVT.ReportSource = ReportDoc;
                    break;
                }
            case "TSI":
                {
                    ReportPath = Server.MapPath("~/CrystalReports/Training/rptTrainingScheduleDetails.rpt");
                    ReportDoc.Load(ReportPath);
                    MyDataTable = rptManager.GetTrainingScheduleDetails(Session["TrainingID"].ToString(),Session["Intervension"].ToString(),Session["OfficeId"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString());
                    ReportDoc.SetDataSource(MyDataTable);
                    ReportDoc.SetParameterValue("PageHeader", "Training Schedule Details");
                    ReportDoc.SetParameterValue("ComLogo", LogoPath);
                    CRVT.ReportSource = ReportDoc;
                    break;
                }
            case "DTR":
                {
                    ReportPath = Server.MapPath("~/CrystalReports/Training/rptDeptWiseTrainingDetails.rpt");
                    ReportDoc.Load(ReportPath);
                    MyDataTable = rptManager.GetDeptWiseTrainingDetails( Session["ProgDept"].ToString(),Session["TrainingID"].ToString(),Session["Intervension"].ToString(),Session["OfficeId"].ToString(), Session["FromDate"].ToString(), Session["ToDate"].ToString());
                    ReportDoc.SetDataSource(MyDataTable);
                    ReportDoc.SetParameterValue("PageHeader", "Department Wise Employee Training Details");
                    ReportDoc.SetParameterValue("ComLogo", LogoPath);
                    CRVT.ReportSource = ReportDoc;
                    break;
                }
            case "EER":
                {
                    ReportPath = Server.MapPath("~/CrystalReports/Training/rptEmpEligibleTrainDetails.rpt");
                    ReportDoc.Load(ReportPath);
                    MyDataTable = rptManager.proc_Get_EmpEligibleTrainDetails(Session["Intervension"].ToString(), Session["OfficeId"].ToString(), Session["EmployeeName"].ToString(), Session["TrainingID"].ToString());
                    ReportDoc.SetDataSource(MyDataTable);
                    ReportDoc.SetParameterValue("PageHeader", "Employee Training Eligible Details");
                    ReportDoc.SetParameterValue("ComLogo", LogoPath);
                    CRVT.ReportSource = ReportDoc;
                    break;
                }
        }
    }
   
    public void PassParameterHeader(string ReportName)
    {
        ParameterFields pFields = new ParameterFields();
        ParameterField pfHeader = new ParameterField();       
        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();        

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pFields.Add(pfHeader);       

        CRVT.ParameterFieldInfo = pFields;
    }   

    public void PassParameterHeader(string ReportName,string FiscalYr)
    {
        ParameterFields pFields = new ParameterFields();        
        ParameterField pfHeader = new ParameterField();
        ParameterField pfFiscalYr = new ParameterField();
             
         ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
         ParameterDiscreteValue dvFiscalYr = new ParameterDiscreteValue();

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfFiscalYr.Name = "pFiscalYr";
        dvFiscalYr.Value = FiscalYr;
        pfFiscalYr.CurrentValues.Add(dvFiscalYr);

         pFields.Add(pfHeader);
         pFields.Add(pfFiscalYr);

         CRVT.ParameterFieldInfo = pFields;
    }


    public void PassParameterHeader(string ReportName, string FromDate, string ToDate)
    {
        ParameterFields pFields = new ParameterFields();
        ParameterField pfHeader = new ParameterField();
        ParameterField pfFromDate = new ParameterField();
        ParameterField pfToDate = new ParameterField();

        ParameterDiscreteValue dvHeader = new ParameterDiscreteValue();
        ParameterDiscreteValue dvFromDate = new ParameterDiscreteValue();
        ParameterDiscreteValue dvToDate = new ParameterDiscreteValue();

        pfHeader.Name = "pHeader";
        dvHeader.Value = ReportName;
        pfHeader.CurrentValues.Add(dvHeader);

        pfFromDate.Name = "pFromDate";
        dvFromDate.Value = FromDate;
        pfFromDate.CurrentValues.Add(dvFromDate);

        pfToDate.Name = "pToDate";
        dvToDate.Value = ToDate;
        pfToDate.CurrentValues.Add(dvToDate);

        pFields.Add(pfHeader);
        pFields.Add(pfFromDate);
        pFields.Add(pfToDate);

        CRVT.ParameterFieldInfo = pFields;
    }   
       
    protected void CRVT_Unload(object sender, EventArgs e)
    {
        ReportDoc.Close();
        ReportDoc.Dispose();
        ReportDoc = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    protected void CRVT_BeforeRender(object source, CrystalDecisions.Web.HtmlReportRender.BeforeRenderEvent e)
    {
        Page.ClientScript.RegisterForEventValidation(CRVT.UniqueID);
    }
}
