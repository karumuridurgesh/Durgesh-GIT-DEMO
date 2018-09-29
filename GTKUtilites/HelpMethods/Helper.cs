using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GTKUtilites.HelpMethods
{
    public class Helper
    {

        private static Helper _Ins = new Helper();

        public static Helper Ins
        {
            get
            {
                return _Ins;
            }
        }

        public string GetSPCall(IDbDataParameter[] dbParameters, string SpName)
        {
            try
            {
                StringBuilder spCall = new StringBuilder();

                spCall.Append("Exec " + SpName + " ");

                if (dbParameters != null)
                {
                    foreach (IDbDataParameter idbp in dbParameters)
                    {
                        if (idbp.Value != DBNull.Value)
                            spCall.Append("'" + idbp.Value + "',");
                        else
                            spCall.Append("null,");
                    }
                }

                return spCall.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetSPCall(SqlParameterCollection dbParameters, string SpName)
        {
            try
            {
                StringBuilder spCall = new StringBuilder();

                spCall.Append("Exec " + SpName + " ");
                if (dbParameters != null)
                {
                    foreach (SqlParameter idbp in dbParameters)
                    {
                        if (idbp.Value != DBNull.Value)
                            spCall.Append("'" + idbp.Value + "',");
                        else
                            spCall.Append("null,");
                    }
                }

                return spCall.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindDataTableNames(DataSet ds)
        {
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (i != ds.Tables.Count)
                            ds.Tables[i].TableName = dr["TableName"].ToString();

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
