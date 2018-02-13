using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Base.Repository
{

    public sealed class UserAccess
    {   
        public List<ViewPermission> viewPerms { get; set; }
        private UserAccess()
        {
        }
        private static UserAccess access = null;

        public static UserAccess Access
        {
            get
            {
                if (access == null)
                {
                    access = new UserAccess();
                }
                return access;
            }
        }
        public string UserId { get; set; }
    }
}
