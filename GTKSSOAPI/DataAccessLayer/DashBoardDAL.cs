using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using GTKonnect.DBHelper.DBConnecter;

namespace GTKSSOAPI.DataAccessLayer
{
    public class DashBoardDAL
    {
        public DataSet getDashBDtls(string UserCode, string AppType)
        {
            GTKDBConnection dbManager = CommonConnection.GetGTKConnection();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "UserCode", UserCode, ParameterDirection.Input);
                if (AppType != null && AppType != "")
                    dbManager.AddParameters(1, "AppType", AppType, ParameterDirection.Input);
                else
                    dbManager.AddParameters(1, "AppType", DBNull.Value, ParameterDirection.Input);
                string spCall = dbManager.GetSPCall("dbo.GTKSSODashBDtls");
                DataSet ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "dbo.GTKSSODashBDtls");
                return ds;
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