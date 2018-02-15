using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BaseHR.DATA;

namespace BaseHR.Repository
{ 
    public sealed class DBConnector
    {
        #region database connection
        public RDRS_RDRSEntities context;
        #endregion

        private DBConnector()
        {
            context = new RDRS_RDRSEntities();
        }
        private static DBConnector dbConnect = null;

        public static DBConnector DbConnect
        {
            get
            {
                if (dbConnect == null)
                {
                    dbConnect = new DBConnector();
                }
                return dbConnect;
            }
        }

    }
}
