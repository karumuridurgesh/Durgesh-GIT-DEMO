using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKUtilites.DataAccessLayer;
using System.Data;
using System.Configuration;
using GTKUtilites.SessionUtils;

namespace GTKUtilites.DataAccessLayer
{
    class UtilityDAL
    {
        internal DataSet GetFilterConditions()
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);                
                DataSet dsFilterCond = new DataSet();
                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    if (SessionObjects.obj.GlobalPropertiesObject.FteCode != null && SessionObjects.obj.GlobalPropertiesObject.FteCode != "")
                        dbManager.AddParameters(0, "@FTECODE", SessionObjects.obj.GlobalPropertiesObject.FteCode, ParameterDirection.Input, 10);

                    else
                        dbManager.AddParameters(0, "@FTECODE", DBNull.Value, ParameterDirection.Input, 10);

                    if (SessionObjects.obj.GlobalPropertiesObject.UserCode != null && SessionObjects.obj.GlobalPropertiesObject.UserCode != "")
                        dbManager.AddParameters(1, "@UserCode", SessionObjects.obj.GlobalPropertiesObject.UserCode, ParameterDirection.Input, 100);
                    else
                        dbManager.AddParameters(1, "@UserCode", DBNull.Value, ParameterDirection.Input, 100);
                    dsFilterCond = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "GetFilterConditions");
                }
                 
                return dsFilterCond;
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
