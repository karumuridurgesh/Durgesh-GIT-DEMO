using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKUtilites.DataAccessLayer;
using System.Data;
using System.Configuration;
using GTKUtilites.HelpMethods;

namespace GTKUtilites.DataAccessLayer
{
    public class DocImgUploadDAL
    {

        internal string Save_DocUpload(string sDocType, byte[] DocImgThumb, string Param1, string Param2,
                    string Param3, string Param4, string Param5, string sUserCode, string sFileName)
        {

            IDBManager dbManager = CommonConnection.Connectionstring();
            try
            {
                string sReqNo = string.Empty;
                DataSet ds = new DataSet();
                dbManager.Open();
                dbManager.CreateParameters(10);
                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {

                    dbManager.AddParameters(0, "@DocType", sDocType, ParameterDirection.Input);
                    if (DocImgThumb != null)
                        dbManager.AddParameters(1, "@DocImg", DocImgThumb, ParameterDirection.Input);

                    else
                        dbManager.AddParameters(1, "@DocImg", DBNull.Value, ParameterDirection.Input);
                    dbManager.AddParameters(2, "@UserCode", sUserCode, ParameterDirection.Input);
                    dbManager.AddParameters(3, "@FileName", sFileName, ParameterDirection.Input);
                    dbManager.AddParameters(4, "@Param1", Param1, ParameterDirection.Input);
                    dbManager.AddParameters(5, "@Param2", Param2, ParameterDirection.Input);
                    dbManager.AddParameters(6, "@Param3", Param3, ParameterDirection.Input);
                    dbManager.AddParameters(7, "@Param4", Param4, ParameterDirection.Input);
                    dbManager.AddParameters(8, "@Param5", Param5, ParameterDirection.Input);
                    dbManager.AddParameters(9, "@ReqNo", string.Empty, ParameterDirection.Output, 50);
                    string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "DataImport.GTK_Upld");
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "DataImport.GTK_Upld");

                }
                else
                {

                }
                sReqNo = dbManager.Parameters[9].Value.ToString();
                return sReqNo;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                dbManager.Dispose();
            }
        }
    }
}
