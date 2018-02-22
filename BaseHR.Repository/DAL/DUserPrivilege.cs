using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseHR.DATA;

namespace BaseHR.Repository.DAL
{
    public class DUserPrivilege
    {
        private RDRS_RDRSEntities context = DBConnector.DbConnect.context;
        public bool AddUserPrivPages(List<UserPrivDTO> lstUserPrivs)
        {
            try
            {
                decimal maxId = context.UserPrivs.Select(uu => uu.ID).DefaultIfEmpty(0).Max();
                foreach (var priv in lstUserPrivs)
                {
                    UserPriv existPagepriv = this.GetExistUserPagePriv(priv.ID);
                    if (existPagepriv != null)
                    {
                        existPagepriv.AreaId = priv.AreaId;
                        existPagepriv.BranchId = priv.BranchId;
                        existPagepriv.CCOId = priv.CCOId;
                        existPagepriv.DeletePerm = priv.DeletePerm;
                        existPagepriv.DistrictId = priv.DistrictId;
                        existPagepriv.GradeId = priv.GradeId;
                        existPagepriv.HeadOfficeId = priv.HeadOfficeId;
                        existPagepriv.InsertPerm = priv.InsertPerm;
                        existPagepriv.InsertedBy = priv.InsertedBy;
                        existPagepriv.InsertedDate = priv.InsertedDate;
                        existPagepriv.InterventionId = priv.InterventionId;
                        existPagepriv.ProjectId = priv.ProjectId;
                        existPagepriv.SectorId = priv.SectorId;
                        existPagepriv.UnitId = priv.UnitId;
                        existPagepriv.UpazillaId = priv.UpazillaId;
                        existPagepriv.ViewPerm = priv.ViewPerm;
                        existPagepriv.ZoneId = priv.ZoneId;
                    }
                    else
                    {
                        priv.ID = ++maxId;
                        UserPriv target = new UserPriv();
                        priv.Mapper(target);
                        context.UserPrivs.Add(target);
                    }
                }
                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
        public UserPriv GetExistUserPagePriv(decimal ID)
        {
            var pagepriv=context.UserPrivs.Where(pp => pp.ID.Equals(ID)).FirstOrDefault();
            return pagepriv;
        }

        public List<UserPrivDTO> GetUserPrivPages(UserPrivDTO objPriv)
        {
            List<UserPriv> lstUserPriv = context.UserPrivs.Where(pp => pp.UserId.Equals(objPriv.UserId) && (objPriv.ViewId==-1 || pp.ViewId == objPriv.ViewId)).ToList();
            List<UserPrivDTO> userPrivs = (from priv in lstUserPriv
                             join view in context.ViewNames on priv.ViewId equals view.ViewId
                                        join interv in context.DivisionLists on priv.InterventionId equals interv.DivisionId into UserInt
                                        from intname in UserInt.DefaultIfEmpty()
                                        join headoff in context.OfficeLists on priv.HeadOfficeId equals headoff.OfficeID into userheadoff
                                        from headoffdef in userheadoff.DefaultIfEmpty()
                                        join cco in context.OfficeLists on priv.CCOId equals cco.OfficeID into Usercco
                                        from ccodef in Usercco.DefaultIfEmpty()
                                        join zone in context.OfficeLists on priv.ZoneId equals zone.OfficeID into Userzone
                                        from zonedef in Userzone.DefaultIfEmpty()
                                        join unit in context.OfficeLists on priv.UnitId equals unit.OfficeID into Userunit
                                        from unitdef in Userunit.DefaultIfEmpty()
                                        join area in context.OfficeLists on priv.AreaId equals area.OfficeID into Userarea
                                        from areadef in Userarea.DefaultIfEmpty()
                                        join bran in context.OfficeLists on priv.BranchId equals bran.OfficeID into Userbran
                                        from brandef in Userbran.DefaultIfEmpty()
                                        join dist in context.OfficeLists on priv.DistrictId equals dist.OfficeID into Userdist
                                        from distdef in Userdist.DefaultIfEmpty()
                                        join proj in context.ProjectLists on priv.ProjectId equals proj.ProjectId into Userproj
                                        from projdef in Userproj.DefaultIfEmpty()
                                        join grd in context.GradeLists on priv.GradeId equals grd.GradeId into Usergrd
                                        from grddef in Usergrd.DefaultIfEmpty()
                                        join sect in context.SectorLists on priv.SectorId equals sect.SectorId into Usersect
                                        from sectdef in Usersect.DefaultIfEmpty()

                             select new UserPrivDTO()
                             {
                                 ID = priv.ID,
                                 AreaId = priv.AreaId,
                                 BranchId = priv.BranchId,
                                 CCOId = priv.CCOId,
                                 DeletePerm = priv.DeletePerm,
                                 DistrictId = priv.DistrictId,
                                 GradeId = priv.GradeId,
                                 HeadOfficeId = priv.HeadOfficeId,
                                 InsertPerm = priv.InsertPerm,
                                 InterventionId = priv.InterventionId,
                                 InterventionName = intname == null ? "" : intname.DivisionName,
                                 HeadOfficeName = headoffdef == null ? "All" : headoffdef.OfficeTitle,
                                 CCOName = ccodef == null ? "All" : ccodef.OfficeTitle,
                                 ZoneName = zonedef == null ? "All" : zonedef.OfficeTitle,
                                 UnitName = unitdef == null ? "All" : unitdef.OfficeTitle,
                                 AreaName = areadef == null ? "All" : areadef.OfficeTitle,
                                 BranchName = brandef == null ? "All" : brandef.OfficeTitle,
                                 DistrictName = distdef == null ? "All" : distdef.OfficeTitle,
                                 ProjectName = projdef == null ? "All" : projdef.ProjectName,
                                 GradeName = grddef == null ? "All" : grddef.GradeName,
                                 SectorName = sectdef == null ? "All" : sectdef.SectorName,
                                 PageName = view.ViewName1,
                                 ProjectId = priv.ProjectId,
                                 SectorId = priv.SectorId,
                                 UnitId = priv.UnitId,
                                 UpazillaId = priv.UpazillaId,
                                 UserId = priv.UserId,
                                 ViewId = priv.ViewId,
                                 ViewPerm = priv.ViewPerm,
                                 ZoneId = priv.ZoneId
                             }).ToList();
            return userPrivs;
        }

        public bool RemovePrivilege(decimal selId)
        {
            try
            {
                var pagepriv = context.UserPrivs.Where(pp => pp.ID.Equals(selId)).FirstOrDefault();
                context.UserPrivs.Remove(pagepriv);
                int rm = context.SaveChanges();
                if (rm>0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public void ClearCache()
        {
            // check if data changes directly into table, then effect appears in the context

            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.ProjectLists);
            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.UserPrivs);
            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.ViewNames);
            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.UserInfoes);
            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.SectorLists);
            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.OfficeLists);
            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.GradeLists);
            //context.Refresh(System.Data.Objects.RefreshMode.ClientWins, context.DivisionLists);
            //context.SaveChanges();
        }
    }
}
