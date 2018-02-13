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
using System.Collections.Generic;
using Base.Security;

public partial class index : System.Web.UI.Page
{
    string invalch = "";
    DBConnector objDB = new DBConnector();
    Payroll_MasterMgr objPayMgr = new Payroll_MasterMgr();
    MasterTablesManager objMasMgr = new MasterTablesManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //lblMsg.Text = DateTime.Now.ToString();
            invalch = Request.Params["inval"];
            Session["USERID"] = "";
            if (invalch != null)
            {
                if (invalch == "Y")
                {
                    lblMsg.Text = "Invalid User ID or Password.";
                }
                else if (invalch == "L")
                {
                    lblMsg.Text = "User has Logout.";
                }
                else
                {
                    lblMsg.Text = "";
                }
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strFiscalYear = "";
        string strFiscalStartDate = "";       
        string userid = txtuserid.Text.ToString();
        string password = txtpassword.Text.ToString();
        string strInputPwd = Common.getHashValue(password);
        DataTable dtUser = new DataTable();
        UserManager objUserMgr = new UserManager();
        Payroll_PaySlipOptionMgr objOptMgr = new Payroll_PaySlipOptionMgr();

        dtUser = objUserMgr.SelectUserInfo(userid, "Y");
        
        // Payroll Fiscal Year
        DataTable dtPayOpt = objOptMgr.SelectpaySlipOption("OC03");
        if (dtPayOpt.Rows.Count > 0)
        {
            strFiscalYear = dtPayOpt.Rows[0]["OPTVALUE"].ToString().Trim();
            strFiscalStartDate = dtPayOpt.Rows[0]["PAYROLLVALIDFROM"].ToString().Trim();
        }

        if (dtUser.Rows.Count > 0)
        {

            #region user view insert delete permission
            string sql= "Select distinct v.ViewId,v.ViewName,v.ShowToPage,v.ParentId,up.ViewPerm,up.InsertPerm,up.DeletePerm,up.InterventionId" +
      ",up.HeadOfficeId,up.CCOId,up.ZoneId,up.UnitId,up.AreaId,up.BranchId,up.DistrictId,up.UpazillaId,up.ProjectId,up.GradeId,up.SectorId from ViewName v, userprivs up," +
      "userinfo ui where v.ViewId=up.VIEWID AND ui.USERID=up.USERID AND up.ViewPerm='Y' AND v.VIEWID<>1 AND ui.Userid='"
      + userid.Trim() + "' order by viewid";
            DataTable dtUserPermisson = objUserMgr.Dbconnect.CreateDT(sql, "UserPermisson");

            ViewPermission viewPerm = null;
            List<ViewPermission> viewPermList = new List<ViewPermission>();
            UserAccess.Access.UserId = userid;
            foreach (DataRow arow in dtUserPermisson.Rows)
            {
                decimal currentPage = Convert.ToDecimal(arow["ViewId"].ToString());
                decimal curIntervention = Convert.ToDecimal(arow["InterventionId"]);
                decimal curHeadOffice = Convert.ToDecimal(arow["HeadOfficeId"]);
                decimal curCCO = Convert.ToDecimal(arow["CCOId"]);
                decimal curZone = Convert.ToDecimal(arow["ZoneId"]);
                decimal curUnit = Convert.ToDecimal(arow["UnitId"]);
                decimal curArea = Convert.ToDecimal(arow["AreaId"]);
                decimal curBranch = Convert.ToDecimal(arow["BranchId"]);
                decimal curDistrict = Convert.ToDecimal(arow["DistrictId"]);
                decimal curUpazilla = Convert.ToDecimal(arow["UpazillaId"]);
                decimal curProject = Convert.ToDecimal(arow["ProjectId"]);
                decimal curGrade = Convert.ToDecimal(arow["GradeId"]);
                decimal curSector = Convert.ToDecimal(arow["SectorId"]);
                viewPerm = viewPermList.Find(x => x.PageId == currentPage);
                if (viewPerm == null)
                {
                    viewPerm = new ViewPermission();
                    viewPerm.PageId = currentPage;
                    viewPerm.InsertPerm = arow["InsertPerm"].ToString();
                    viewPerm.DeletePerm = arow["DeletePerm"].ToString();
                    viewPerm.ViewPerm = arow["ViewPerm"].ToString();
                    viewPerm.InterventionIds = new List<decimal?>();
                    viewPerm.HeadOfficeIds = new List<decimal?>();
                    viewPerm.CCOIds = new List<decimal?>();
                    viewPerm.ZoneIds = new List<decimal?>();
                    viewPerm.UnitIds = new List<decimal?>();
                    viewPerm.AreaIds = new List<decimal?>();
                    viewPerm.BranchIds = new List<decimal?>();
                    viewPerm.DistrictIds = new List<decimal?>();
                    viewPerm.UpazillaIds = new List<decimal?>();
                    viewPerm.ProjectIds = new List<decimal?>();
                    viewPerm.GradeIds = new List<decimal?>();
                    viewPerm.SectorIds = new List<decimal?>();
                    viewPermList.Add(viewPerm);
                }
                if (!viewPerm.InterventionIds.Exists(ii => ii == curIntervention))
                {
                    viewPerm.InterventionIds.Add(curIntervention);
                }
                if (!viewPerm.HeadOfficeIds.Exists(ii => ii == curHeadOffice))
                {
                    viewPerm.HeadOfficeIds.Add(curHeadOffice);
                }
                if (!viewPerm.CCOIds.Exists(ii => ii == curCCO))
                {
                    viewPerm.CCOIds.Add(curCCO);
                }
                if (!viewPerm.ZoneIds.Exists(ii => ii == curZone))
                {
                    viewPerm.ZoneIds.Add(curZone);
                }
                if (!viewPerm.UnitIds.Exists(ii => ii == curUnit))
                {
                    viewPerm.UnitIds.Add(curUnit);
                }
                if (!viewPerm.AreaIds.Exists(ii => ii == curArea))
                {
                    viewPerm.AreaIds.Add(curArea);
                }
                if (!viewPerm.BranchIds.Exists(ii => ii == curBranch))
                {
                    viewPerm.BranchIds.Add(curBranch);
                }
                if (!viewPerm.DistrictIds.Exists(ii => ii == curDistrict))
                {
                    viewPerm.DistrictIds.Add(curDistrict);
                }
                if (!viewPerm.UpazillaIds.Exists(ii => ii == curUpazilla))
                {
                    viewPerm.UpazillaIds.Add(curUpazilla);
                }
                if (!viewPerm.ProjectIds.Exists(ii => ii == curProject))
                {
                    viewPerm.ProjectIds.Add(curProject);
                }
                if (!viewPerm.GradeIds.Exists(ii => ii == curGrade))
                {
                    viewPerm.GradeIds.Add(curGrade);
                }
                if (!viewPerm.SectorIds.Exists(ii => ii == curSector))
                {
                    viewPerm.SectorIds.Add(curSector);
                }
            }
            UserAccess.Access.viewPerms = viewPermList;
            #endregion

            Session["LOGINID"] = Common.getMaxId("UserInOutHistory", "LogInId");
            foreach (DataRow row in dtUser.Rows)
            {
                //if (strInputPwd != "")
                //{
                if (string.Compare(row["Password"].ToString().Trim(), strInputPwd) == 0)
                {
                    if (strInputPwd != "0")
                    {
                        Session["USERID"] = userid.ToString();
                        Session["USERNAME"] = row["FullName"].ToString();
                        Session["EMPID"] = row["EMPID"].ToString();
                        Session["EMAILID"] = row["OfficeEmail"].ToString();
                        Session["INTERVENIONNAME"] = row["DivisionName"].ToString();
                        Session["INTERVENIONID"] = row["DivisionId"].ToString();
                        Session["OFFICEID"] = row["OfficeId"].ToString();
                        Session["OFFICENAME"] = row["OfficeTitle"].ToString();
                        Session["SALARYLOC"] = row["SalLocId"].ToString();
                        Session["TEAM"] = row["DEPTNAME"].ToString();
                        Session["TEAMID"] = row["DEPTID"].ToString();
                        Session["EMPLOYEEID"] = row["EmpId"].ToString().Trim();
                        Session["ISADMIN"] = row["IsAdmin"].ToString().Trim();
                        Session["DESIGNATION"] = row["JobTitleName"].ToString().Trim();
                        Session["FISCALYRID"] = strFiscalYear;
                        Session["FISCALSTARTDATE"] = strFiscalStartDate;
                        Session["USDRATE"] = Convert.ToDouble(objPayMgr.SelectUSDRate());
                        objUserMgr.InsertUserInOutHistory(Session["LOGINID"].ToString(), Session["USERID"].ToString().Trim(), Common.SetDateTime(DateTime.Now.ToString()),
                                Common.SetDateTime(DateTime.Now.ToString()), "S", "N");
                        DataTable dtTaskPermission = objUserMgr.GetUserTaskPermission(Session["USERID"].ToString(), "1", "T103");
                        if (dtTaskPermission.Rows.Count > 0)
                            Response.Redirect("File/Home.aspx");
                        else
                            Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Session["USERID"] = "";
                        Session["USERNAME"] = "";
                        Session["EMPID"] = "";
                        Session["EMAILID"] = "";
                        Session["INTERVENIONNAME"] = "";
                        Session["INTERVENIONID"] = "";
                        Session["OFFICEID"] = "";
                        Session["OFFICENAME"] ="";
                        Session["SALARYLOC"] = "";
                        Session["TEAM"] = "";
                        Session["TEAM"] = "";
                        Session["EMPLOYEEID"] = "";
                        Session["ISADMIN"] = "";
                        Session["TEAMID"] = "";
                        Session["DESIGNATION"] = "";
                        Session["ISADMIN"] = "";
                        Session["FISCALYRID"] = "";
                        Session["FISCALSTARTDATE"] = "";
                        Session["USDRATE"] = "";
                        Response.Redirect("~/index.aspx?inval=Y");
                        lblMsg.Text = "";
                        objUserMgr.InsertUserInOutHistory(Session["LOGINID"].ToString(), Session["USERID"].ToString().Trim(), Common.SetDateTime(DateTime.Now.ToString()),
                                 Common.SetDateTime(DateTime.Now.ToString()), "U", "N");

                        this.FillOptionValue();  
                    }
                }
                else
                {
                    objUserMgr.InsertUserInOutHistory(Session["LOGINID"].ToString(), Session["USERID"].ToString().Trim(), Common.SetDateTime(DateTime.Now.ToString()),
                                Common.SetDateTime(DateTime.Now.ToString()), "U", "N");
                    lblMsg.Text = "Invalid User Id or Password.";
                }
            }
        }
        else
        {
            //Session["USERID"] = "";
            Session["USERNAME"] = "";
            Session["EMPID"] = "";
            Session["EMAILID"] = "";
            Session["COUNTRYDIRECTOR"] = "";
            Session["INTERVENIONNAME"] = "";
            Session["INTERVENIONID"] = "";
            Session["OFFICEID"] = "";
            Session["OFFICENAME"] = "";
            Session["SALARYLOC"] = "";
            Session["PROGRAM"] = "";
            Session["PROGRAMID"] = "";
            Session["TEAM"] = "";
            Session["TEAMID"] = "";
            Session["EMPLOYEEID"] = "";
            Session["ISADMIN"] = "";
            Session["ISSHIFTINCHR"] = "";
            Session["DESIGNATION"] = "";
            Session["LOCATION"] = "";
            // Payroll
            Session["FISCALYRID"] = "";
            Session["USERID"] = txtuserid.Text.Trim();
            objUserMgr.InsertUserInOutHistory(Session["LOGINID"].ToString(), Session["USERID"].ToString().Trim(), Common.SetDateTime(DateTime.Now.ToString()),
                               Common.SetDateTime(DateTime.Now.ToString()), "U", "N");
            Response.Redirect("~/index.aspx?inval=Y");
            lblMsg.Text = "";

        }
    }

    protected void FillOptionValue()
    {
        DataTable dtOpt = new DataTable();
        dtOpt = objMasMgr.SelectOptionBag("");
        if (dtOpt.Rows.Count > 0)
        {
            foreach (DataRow Row in dtOpt.Rows)
            {
                if (Row["OptId"].ToString() == "OC01".ToString())
                    Session["OptRetAge"] = Row["OptValue"].ToString();
                else if (Row["OptId"].ToString() == "OC02")
                    Session["OptBasicPercent"] = Convert.ToInt16(Row["OptValue"]);               
            }
        }
    }
    
}
