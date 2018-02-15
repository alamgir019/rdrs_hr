using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


//Created by Murad
//17.10.2011
/// <summary>
/// Summary description for clsEmpTransition
/// </summary>
public class clsEmpTransition
{

    private string _TransId;
    public string TransId
    {
        get { return _TransId; }
        set { _TransId = value; }
    }
    private string _EmpID;
    public string EmpID
    {
        get { return _EmpID; }
        set { _EmpID = value; }
    }

    private string _EntryDate;
    public string EntryDate
    {
        get { return _EntryDate; }
        set { _EntryDate = value; }
    }

    private string _TransType;
    public string TransType
    {
        get { return _TransType; }
        set { _TransType = value; }
    }

    private string _ActionId;
    public string ActionId
    {
        get { return _ActionId; }
        set { _ActionId = value; }
    }

    private string _DivisionId;
    public string DivisionId
    {
        get { return _DivisionId; }
        set { _DivisionId = value; }
    }

    private string _OfficeId;
    public string OfficeId
    {
        get { return _OfficeId; }
        set { _OfficeId = value; }
    }
    private string _DesigId;
    public string DesigId
    {
        get { return _DesigId; }
        set { _DesigId = value; }
    }

    private string _JobTitleId;
    public string JobTitleId
    {
        get { return _JobTitleId; }
        set { _JobTitleId = value; }
    }

    private string _SectorId;
    public string SectorId
    {
        get { return _SectorId; }
        set { _SectorId = value; }
    }

    private string _DeptId;
    public string DeptId
    {
        get { return _DeptId; }
        set { _DeptId = value; }
    }

    private string _UnitId;
    public string UnitId
    {
        get { return _UnitId; }
        set { _UnitId = value; }
    }

    private string _GradeId;
    public string GradeId
    {
        get { return _GradeId; }
        set { _GradeId = value; }
    }

    private string _GradeLevelId;
    public string GradeLevelId
    {
        get { return _GradeLevelId; }
        set { _GradeLevelId = value; }
    }

    private string _PostingDivId;
    public string PostingDivId
    {
        get { return _PostingDivId; }
        set { _PostingDivId = value; }
    }

    private string _PostingDistId;
    public string PostingDistId
    {
        get { return _PostingDistId; }
        set { _PostingDistId = value; }
    }

    private string _SalLocId;
    public string SalLocId
    {
        get { return _SalLocId; }
        set { _SalLocId = value; }
    }

    private string _SalSubLocId;
    public string SalSubLocId
    {
        get { return _SalSubLocId; }
        set { _SalSubLocId = value; }
    }
    private string _PostingPlaceId;
    public string PostingPlaceId
    {
        get { return _PostingPlaceId; }
        set { _PostingPlaceId = value; }
    }
    private string _EffDate;
    public string EffDate
    {
        get { return _EffDate; }
        set { _EffDate = value; }
    }

    private string _BasicSal;
    public string BasicSal
    {
        get { return _BasicSal; }
        set { _BasicSal = value; }
    }

    private string _GrossSalary;
    public string GrossSalary
    {
        get { return _GrossSalary; }
        set { _GrossSalary = value; }
    }

    private string _NextIncDate;
    public string NextIncDate
    {
        get { return _NextIncDate; }
        set { _NextIncDate = value; }
    }

    private string _IsNew;
    public string IsNew
    {
        get { return _IsNew; }
        set { _IsNew = value; }
    }

    private string _Remarks;
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }

    private string _InsertedBy;
    public string InsertedBy
    {
        get { return _InsertedBy; }
        set { _InsertedBy = value; }
    }

    private string _InsertedDate;
    public string InsertedDate
    {
        get { return _InsertedDate; }
        set { _InsertedDate = value; }
    }

    private string _PosFuncId;
    public string PosFuncId
    {
        get { return _PosFuncId; }
        set { _PosFuncId = value; }
    }

    private string _GradeChangeDate;
    public string GradeChangeDate
    {
        get { return _GradeChangeDate; }
        set { _GradeChangeDate = value; }
    }

    private string _ProjectId;
    public string ProjectId
    {
        get { return _ProjectId; }
        set { _ProjectId = value; }
    }

    private string _SuperId;
    public string SuperId
    {
        get { return _SuperId; }
        set { _SuperId = value; }
    }

    private string _BankAccNo;
    public string BankAccNo
    {
        get { return _BankAccNo; }
        set { _BankAccNo = value; }
    }

    public clsEmpTransition(string TransId, string EmpId, string EntryDate, string TransType, string ActionId, string DivisionId, string OfficeId, string DesigId, string JobTitleId,
        string SectorId, string DeptId, string UnitId, string GradeId, string GradeLevelId, string PostingDivId, string PostingDistId, string SalLocId, string SalSubLocId,
        string PostingPlaceId, string BasicSal, string GrossSalary,string EffDate, string NextIncDate, string IsNew, string Remarks, string InsBy, string InsDate, string PosFuncId, 
        string GradeChangeDate,string sProjectId,string sSuperId,string sBankAccNo)
    {
        this.TransId = TransId;
        this.EmpID = EmpId;
        this.EntryDate = EntryDate;
        this.TransType = TransType;
        this.ActionId = ActionId;
        this.DivisionId = DivisionId;
        this.OfficeId = OfficeId;
        this.DesigId = DesigId;
        this.JobTitleId = JobTitleId;
        this.SectorId = SectorId;
        this.DeptId = DeptId;
        this.UnitId = UnitId;
        this.GradeId = GradeId;
        this.GradeLevelId = GradeLevelId;
        this.PostingDivId = PostingDivId;
        this.PostingDistId = PostingDistId;
        this.PostingPlaceId = PostingPlaceId;
        this.SalLocId = SalLocId;
        this.SalSubLocId = SalSubLocId;
        this.BasicSal = BasicSal;
        this.GrossSalary = GrossSalary;
        this.EffDate = EffDate;
        this.NextIncDate = NextIncDate;
        this.IsNew = IsNew;
        this.Remarks = Remarks;
        this.InsertedBy = InsBy;
        this.InsertedDate = InsDate;
        this.PosFuncId = PosFuncId;
        this.GradeChangeDate = GradeChangeDate;
        this.ProjectId = sProjectId ;
        this.SuperId = sSuperId ;
        this.BankAccNo = sBankAccNo ;
    }
}
