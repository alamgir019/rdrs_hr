using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsProject
/// </summary>
public class clsProject
{

    public clsProject(string strProjectId, string strProjectName,string strShortName, string strProjectCode, string strStartDate, string strEndDate, 
        //string strWeekEndID,string strIncrementType,string  strIncrementMonth,string strIncrementAfter,
        string strIsPF,string  strIsGratuity,
        //string strIsEOC,string strIsLE, string strIsInsurance, string strIsGSal, string strIsBSal, string strIsCore, string strIsProject,
        string strIsActive,string strIsDeleted,string strInsertedBy, string strInsertedDate,string strUpdatedBy, string strUpdatedDate,string strLastUpdatedFrom)
	        {
                this.ProjectId = strProjectId;
                this.ProjectName = strProjectName;
                this.ShortName = strShortName;
                this.ProjectCode = strProjectCode;
                this.StartDate = strStartDate;
                this.EndDate = strEndDate; 
             //   this.WeekEndID = strWeekEndID;
             //   this.IncrementType = strIncrementType;
             //   this.IncrementMonth = strIncrementMonth;
	            //this.IncrementAfter = strIncrementAfter;
                this.IsPF = strIsPF;
                this.IsGratuity = strIsGratuity;
                //this.IsEOC = strIsEOC;
                //this.IsLE = strIsLE;
                //this.IsInsurance = strIsInsurance;
                //this.IsGSal = strIsGSal;
                //this.IsBSal = strIsBSal;
                //this.IsCore = strIsCore;
                //this.IsProject = strIsProject;
                this.IsActive = strIsActive;
                this.IsDeleted = strIsDeleted;
                this.InsertedBy = strInsertedBy;
                this.InsertedDate = strInsertedDate;
                this.UpdatedBy = strUpdatedBy;
                this.UpdatedDate = strUpdatedDate;
                this.LastUpdatedFrom = strLastUpdatedFrom;
	        }

        private string _ProjectId;
        private string _ProjectName;
        private string _ShortName;
        private string _ProjectCode;
        private string _StartDate;
        private string _EndDate;
        //private string _WeekEndID;
        //private string _IncrementType;
        //private string _IncrementMonth;
        //private string _IncrementAfter;
        private string _IsPF;
        private string _IsGratuity;
        //private string _IsEOC;
        //private string _IsLE;
        //private string _IsInsurance;
        //private string _IsGSal;
        //private string _IsBSal;
        //private string _IsCore;
        //private string _IsProject;
        private string _IsActive;
        private string _IsDeleted;
        private string _InsertedBy;
        private string _InsertedDate;
        private string _LastUpdatedFrom;
        private string _UpdatedBy;
        private string _UpdatedDate;

        public string ProjectId { get { return _ProjectId; } set { _ProjectId = value; } }
        public string ProjectName { get { return _ProjectName; } set { _ProjectName = value; }}
        public string ShortName { get { return _ShortName; } set { _ShortName = value; } }
        public string ProjectCode { get { return _ProjectCode; } set { _ProjectCode = value; } }
        public string StartDate{get { return _StartDate; } set { _StartDate = value; } }
        public string EndDate{get { return _EndDate; } set { _EndDate = value; } }
        //public string WeekEndID{get { return _WeekEndID; } set { _WeekEndID = value; } }
        //public string IncrementType{get { return _IncrementType; } set { _IncrementType = value; } }
        //public string IncrementMonth{get { return _IncrementMonth; } set { _IncrementMonth = value; } }
        //public string IncrementAfter{get { return _IncrementAfter; } set { _IncrementAfter = value; } }
        public string IsPF{get { return _IsPF; } set { _IsPF = value; } }
        public string IsGratuity{get { return _IsGratuity; } set { _IsGratuity = value; } }
        //public string IsEOC{get { return _IsEOC; } set { _IsEOC = value; } }
        //public string IsLE{get { return _IsLE; } set { _IsLE = value; } }
        //public string IsInsurance{get { return _IsInsurance; } set { _IsInsurance= value; } }
        //public string IsGSal{get { return _IsGSal; } set { _IsGSal = value; } }
        //public string IsBSal{get { return _IsBSal; } set { _IsBSal = value; } }
        //public string IsCore{get { return _IsCore; } set { _IsCore = value; } }
        //public string IsProject{get { return _IsProject; } set { _IsProject = value; } }
        public string IsActive {get { return _IsActive; } set { _IsActive = value; }}
        public string IsDeleted { get { return _IsDeleted; }set { _IsDeleted = value; }}
        public string InsertedBy { get { return _InsertedBy; } set { _InsertedBy = value; } }
        public string InsertedDate {get { return _InsertedDate; } set { _InsertedDate = value; }}
        public string LastUpdatedFrom {get { return _LastUpdatedFrom; }set { _LastUpdatedFrom = value; } }
        public string UpdatedBy {get { return _UpdatedBy; }set { _UpdatedBy = value; }}
        public string UpdatedDate { get { return _UpdatedDate; } set { _UpdatedDate = value; } }

}