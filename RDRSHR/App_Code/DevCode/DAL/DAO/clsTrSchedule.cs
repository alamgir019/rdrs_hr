﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsTrSchedule
/// </summary>
public class clsTrSchedule
{
	public clsTrSchedule(string ScheduleID,
	                     string TrainId,
	                     string SalLocId,
	                     string StrDate,
	                     string EndDate,
	                     string Duration,
	                     string NoofPerson,
	                     string CoordinatorName,
                         string FundType,
	                     string FundedBy,
                         string ProjectDonar,
                         string Residential, 
	                     string Status
	                    
	                    ){
                         this.ScheduleID    = ScheduleID;
	                     this.TrainId       = TrainId;
	                     this.SalLocId      = SalLocId;
	                     this.StrDate       = StrDate;
	                     this.EndDate       = EndDate;
	                     this.Duration      = Duration;
	                     this.NoofPerson    = NoofPerson;
	                     this.CoordinatorName=CoordinatorName;
	                     this.FundType=FundType;
	                     this.FundedBy=FundedBy;
                         this.ProjectDonar = ProjectDonar;
                         this.Residential = Residential;
	                     this.Status        = Status;
	                    
                        }

     private string _ScheduleID;
	 private string _TrainId;
	 private string _SalLocId;
	 private string _StrDate;
	 private string _EndDate;
	 private string _Duration;
	 private string _NoofPerson;
	 private string _CoordinatorName;
     private string _FundType;
	 private string _FundedBy;
     private string _ProjectDonar;
     private string _Residential;
	 private string _Status;
	 

     public string ScheduleID       { get { return _ScheduleID;     } set { _ScheduleID      = value; }}
	 public string TrainId          { get { return _TrainId;        } set { _TrainId         = value; }}
	 public string SalLocId         { get { return _SalLocId;       } set { _SalLocId        = value; }}
	 public string StrDate          { get { return _StrDate;        } set { _StrDate         = value; }}
	 public string EndDate          { get { return _EndDate;        } set { _EndDate         = value; }}
	 public string Duration         { get { return _Duration;       } set { _Duration        = value; }}
	 public string NoofPerson       { get { return _NoofPerson;     } set { _NoofPerson      = value; }}
	 public string CoordinatorName  { get { return _CoordinatorName;} set { _CoordinatorName = value; }}
     public string FundType         { get { return _FundType; } set { _FundType = value; } }
	 public string FundedBy         { get { return _FundedBy;       } set { _FundedBy        = value; }}
     public string ProjectDonar { get { return _ProjectDonar; } set { _ProjectDonar = value; } }
     public string Residential      { get { return _Residential;    } set { _Residential     = value; }}
	 public string Status           { get { return _Status;         } set { _Status          = value; }}
}