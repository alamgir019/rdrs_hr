using BaseHR.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseHR.Repository.DAL
{
    public class DComponent
    {
        private RDRS_RDRSEntities context = DBConnector.DbConnect.context;
        public List<ComponentListDTO> getComponents()
        {
            var cmplist = (from cmp in context.ComponentLists
                         select new ComponentListDTO
                         {
                             ComponentId = cmp.ComponentId,
                             ComponentName = cmp.ComponentName,
                             IsActive = cmp.IsActive,
                             IsDeleted=cmp.IsDeleted
                         }).ToList();
            return cmplist;
        }
        public int AddComponent(ComponentListDTO component)
        {
            try
            {
                // insert compoent
                if (component.ComponentId == 0)
                {
                    decimal maxId = context.ComponentLists.Select(mm => mm.ComponentId).DefaultIfEmpty(0).Max();
                    component.ComponentId = ++maxId;
                    ComponentList target = new ComponentList();
                    component.Mapper(target);
                    context.ComponentLists.Add(target);
                }
                else
                {
                    // update component
                    ComponentList exCmpList = context.ComponentLists.Where(ll => ll.ComponentId == component.ComponentId).FirstOrDefault();
                    exCmpList.ComponentName = component.ComponentName;
                    exCmpList.UpdatedBy = component.UpdatedBy;
                    exCmpList.UpdatedDate = component.UpdatedDate;
                    exCmpList.IsActive = component.IsActive;
                    exCmpList.IsDeleted = component.IsDeleted;
                }
                int cnt = context.SaveChanges();
                return cnt;
            }
            catch (Exception exc)
            {
                return 0;
            }
        }
    }
}
