//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseHR.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class ViewName
    {
        public ViewName()
        {
            this.UserPrivs = new HashSet<UserPriv>();
        }
    
        public int ViewId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string ViewName1 { get; set; }
        public string ShowToPage { get; set; }
        public string PageName { get; set; }
        public Nullable<int> NodeLevel { get; set; }
    
        public virtual ICollection<UserPriv> UserPrivs { get; set; }
    }
}
