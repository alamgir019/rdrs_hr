using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Base.Security
{
    public class ViewPermission
    {
        public decimal PageId { get; set; }
        public string ViewPerm { get; set; }
        public string InsertPerm { get; set; }
        public string DeletePerm { get; set; }

        public List<decimal?> InterventionIds { get; set; }
        public List<decimal?> HeadOfficeIds { get; set; }
        public List<decimal?> CCOIds { get; set; }
        public List<decimal?> ZoneIds { get; set; }
        public List<decimal?> UnitIds { get; set; }
        public List<decimal?> AreaIds { get; set; }
        public List<decimal?> BranchIds { get; set; }
        public List<decimal?> DistrictIds { get; set; }
        public List<decimal?> UpazillaIds { get; set; }
        public List<decimal?> ProjectIds { get; set; }
        public List<decimal?> GradeIds { get; set; }
        public List<decimal?> SectorIds { get; set; }

        public enum SelectionList
        {
            Intervention,
            HeadOfficeId,
            CCOId,
            ZoneId,
            UnitId,
            AreaId,
            BranchId,
            DistrictId,
            UpazillaId,
            ProjectId,
            GradeId,
            SectorId
        }
        public DataTable ExistSelection(DataTable selections, Enum field, decimal pageid)
        {
            DataTable sublist = null;
            IEnumerable<DataRow> myBusinessObjectList = null;
            ViewPermission pageView = UserAccess.Access.viewPerms.Find(vv => vv.PageId == pageid);
            if (selections.Rows.Count == 0)
            {
                return selections;
            }
            if (field.Equals(SelectionList.Intervention))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from intvn in pageView.InterventionIds
                                        where ((intvn == -1) || (intvn == 99999) || (aselect.Field<decimal>("DivisionId") == intvn))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.HeadOfficeId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.HeadOfficeIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.CCOId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.CCOIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.ZoneId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.ZoneIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.UnitId))
            {
               myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.UnitIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }

            else if (field.Equals(SelectionList.ProjectId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.ProjectIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("ProjectId") == aid))
                                        select aselect).Distinct().ToList();
            }
            else if (field.Equals(SelectionList.SectorId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.SectorIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("SectorId") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.DistrictId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.DistrictIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.UpazillaId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.UpazillaIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.GradeId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.GradeIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("GradeID") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.BranchId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.BranchIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }
            else if (field.Equals(SelectionList.AreaId))
            {
                myBusinessObjectList = (from aselect in selections.AsEnumerable()
                                                             from aid in pageView.AreaIds
                                                             where ((aid == -1) || (aid==99999) || (aselect.Field<decimal>("OfficeID") == aid))
                                                             select aselect).ToList();
            }
            if (myBusinessObjectList.Count() > 0)
            {
                sublist = myBusinessObjectList.CopyToDataTable();
            }
            return sublist;
        }


        public bool GetExistPermission(DataRow dRow,int pageId)
        {
            ViewPermission curpareview = UserAccess.Access.viewPerms.Where(pp => pp.PageId == pageId).FirstOrDefault();
            if (curpareview != null)
            {
                var tt = dRow["ProjectId"];
                string pp = tt.ToString();
                var existInt = curpareview.InterventionIds.Where(ii => ii == -1 || ii == 99999 || string.IsNullOrEmpty(dRow["DivisionId"].ToString()) || ii == Convert.ToDecimal(dRow["DivisionId"])).FirstOrDefault();
                var existBrn = curpareview.BranchIds.Where(ii => ii == -1 || ii == 99999 || string.IsNullOrEmpty(dRow["OfficeId"].ToString()) || ii == Convert.ToDecimal(dRow["OfficeId"])).FirstOrDefault();
                var existPrj = curpareview.ProjectIds.Where(ii => ii == -1 || ii == 99999 || string.IsNullOrEmpty(dRow["ProjectId"].ToString()) || ii == Convert.ToDecimal(dRow["ProjectId"])).FirstOrDefault();
                var existSct = curpareview.SectorIds.Where(ii => ii == -1 || ii == 99999 || string.IsNullOrEmpty(dRow["SectorId"].ToString()) || ii == Convert.ToDecimal(dRow["SectorId"])).FirstOrDefault();
                var existGrd = curpareview.GradeIds.Where(ii => ii == -1 || ii == 99999 || string.IsNullOrEmpty(dRow["GradeId"].ToString()) || ii == Convert.ToDecimal(dRow["GradeId"])).FirstOrDefault();
                if (existInt == null)
                {
                    return false;
                }
                else if (existBrn == null)
                {
                    return false;
                }
                else if (existPrj == null)
                {
                    return false;
                }
                else if (existSct == null)
                {
                    return false;
                }
                else if (existGrd == null)
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }
    }
}
