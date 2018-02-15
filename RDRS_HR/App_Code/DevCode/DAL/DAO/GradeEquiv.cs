using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for GradeEquiv
/// </summary>
public class GradeEquiv
{
    private string _GradeID;

    public string GradeID
    {
        get { return _GradeID; }
        set { _GradeID = value; }
    }
    private string _GradeName;

    public string GradeName
    {
        get { return _GradeName; }
        set { _GradeName = value; }
    }
    private string _isDeleted;

    public string IsDeleted
    {
        get { return _isDeleted; }
        set { _isDeleted = value; }
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
    private string _UpdatedBy;

    public string UpdatedBy
    {
        get { return _UpdatedBy; }
        set { _UpdatedBy = value; }
    }
    private string _UpdatedDate;

    public string UpdatedDate
    {
        get { return _UpdatedDate; }
        set { _UpdatedDate = value; }
    }
    private string _LastUpdatedFrom;

    public string LastUpdatedFrom
    {
        get { return _LastUpdatedFrom; }
        set { _LastUpdatedFrom = value; }
    }
    private string _isUpdate;

    public string IsUpdate
    {
        get { return _isUpdate; }
        set { _isUpdate = value; }
    }
    private string _IsDelete;

    public string IsDelete
    {
        get { return _IsDelete; }
        set { _IsDelete = value; }
    }
    private string _IsActive;

    public string IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    private string _GradeType;

    public string GradeType
    {
        get { return _GradeType; }
        set { _GradeType = value; }
    }

    public GradeEquiv(string GradeID, string GradeName, string isDeleted, string InsertedBy, string InsertedDate, string UpdatedBy, string UpdatedDate, 
        string LastUpdatedFrom, string IsUpdate, string IsDelete, string IsActive,string sGradeType)
    {
        this.GradeID = GradeID;
        this.GradeName = GradeName;
        this.IsDeleted = isDeleted;
        this.InsertedBy = InsertedBy;
        this.InsertedDate = InsertedDate;
        this.UpdatedBy = UpdatedBy;
        this.UpdatedDate = UpdatedDate;
        this.LastUpdatedFrom = LastUpdatedFrom;
        this.IsUpdate = IsUpdate;
        this.IsDelete = IsDelete;
        this.IsActive = IsActive;
        this.GradeType = sGradeType;
    }
}
