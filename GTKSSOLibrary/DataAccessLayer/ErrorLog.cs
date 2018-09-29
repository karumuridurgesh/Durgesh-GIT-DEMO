using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using GTKUtilites;
using GTKUtilites.DataAccessLayer;


namespace GTKSSOLibrary.DataAccessLayer
{
    internal class ErrorLog
    {
        private static ErrorLog _instance = new ErrorLog();
        //IDBOracleAdapter da = new IDBOracleAdapter();
        public static ErrorLog Ins
        {
            get { return _instance; }
        }

        internal void LogError(string errorNameSpace, string eventName, string errorStack, string errorByUser)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    dbManager.AddParameters(0, "@ErrorNameSpace", errorNameSpace, ParameterDirection.Input);
                    dbManager.AddParameters(1, "@ErrorEvent", eventName, ParameterDirection.Input);
                    dbManager.AddParameters(2, "@ErrorStack", errorStack, ParameterDirection.Input);
                    dbManager.AddParameters(3, "@ErrorByUser", errorByUser, ParameterDirection.Input);
                    dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "SAVE_ERROR_LOG");
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
    }
}
