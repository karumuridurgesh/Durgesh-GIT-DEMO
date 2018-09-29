using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKUtilites.HelpMethods;
using System.Configuration;
using GTKUtilites.DataAccessLayer;
using System.Data;
using GTKSSOLibrary.BusinessObjects;
using System.Globalization;

namespace GTKSSOLibrary.DataAccessLayer
{
    public class DALUser
    {
        internal DataSet Open_LoginInfo(string UserCode, string Password, string param)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "LoginUserCode", UserCode, ParameterDirection.Input);
                dbManager.AddParameters(1, "UserPassword", Password, ParameterDirection.Input);
                dbManager.AddParameters(2, "Param", param, ParameterDirection.Input);

                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Fetch_LoginInfo");

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Fetch_LoginInfo");
                }

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

        internal DataSet Fetch_LoginDtl(string UserCode, string Password, ref string sReturnMsg)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                dbManager.AddParameters(0, "LoginUserCode", UserCode, ParameterDirection.Input);
                dbManager.AddParameters(1, "UserPassword", Password, ParameterDirection.Input);
                dbManager.AddParameters(2, "@RetMsg", string.Empty, ParameterDirection.Output, 100);

                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Fetch_LoginDtl");

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Fetch_LoginDtl");
                }
                if (dbManager.Parameters[2] != null)
                {
                    sReturnMsg = dbManager.Parameters[2].Value.ToString();
                }
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

        internal DataSet Fetch_UserInfo(string Mode, string usercode)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "Mode", Mode, ParameterDirection.Input);
                dbManager.AddParameters(1, "UserCode", usercode, ParameterDirection.Input);

                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Fetch_Users");

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Fetch_Users");
                }

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

        internal int Save_UserInfo(UserList user)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            int results = 0;
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(8);
                dbManager.AddParameters(0, "UserFirstName", user.UserFirstName, ParameterDirection.Input);
                dbManager.AddParameters(1, "UserMidName", user.UserMidName, ParameterDirection.Input);
                dbManager.AddParameters(2, "UserLastName", user.UserLastName, ParameterDirection.Input);
                dbManager.AddParameters(3, "Email", user.UserEmail, ParameterDirection.Input);
                dbManager.AddParameters(4, "UserApps", user.UserApps, ParameterDirection.Input);
                dbManager.AddParameters(5, "Mode", user.Mode, ParameterDirection.Input);
                dbManager.AddParameters(6, "userCode", user.userCode, ParameterDirection.Input);
                dbManager.AddParameters(7, "eParam", user.EParm, ParameterDirection.Input);

                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Save_Users");

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Save_Users");
                    results = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                }

                return results;
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

        internal string Validate(string param, string Mode)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            string results = "";
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "params", param, ParameterDirection.Input);
                dbManager.AddParameters(1, "MODE", Mode, ParameterDirection.Input);
                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Validations");

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Validations");
                    results = Convert.ToString(ds.Tables[0].Rows[0][0]);
                }

                return results;
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


        internal int Save_NewApps(int appid, string AppName, string AppURL, string Status, string mode)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            int results = 0;
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "AppId", appid, ParameterDirection.Input);
                dbManager.AddParameters(1, "AppName", AppName, ParameterDirection.Input);
                dbManager.AddParameters(2, "AppURL", AppURL, ParameterDirection.Input);
                dbManager.AddParameters(3, "Status", Status, ParameterDirection.Input);
                dbManager.AddParameters(4, "mode", mode, ParameterDirection.Input);

                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Save_Apps");

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Save_Apps");
                    results = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                }

                return results;
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

        public int Save_UserInfox(string xml, string Mode)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            int results = 0;
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "xml", xml, ParameterDirection.Input);
                dbManager.AddParameters(1, "Mode", Mode, ParameterDirection.Input);
                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Save_UsersX");
                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Save_UsersX");
                    results = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {

            }
            return results;

        }

        internal int Save_NewAppsx(string xml, string Mode)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            int results = 0;
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "xml", xml, ParameterDirection.Input);
                dbManager.AddParameters(1, "Mode", Mode, ParameterDirection.Input);
                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Save_AppsX");
                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Save_AppsX");
                    results = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {

            }
            return results;
        }
        internal int SendResetPswdlink(string UserCode, string UserEmail, string EmlTmpl, string token, DateTimeOffset tokenDt)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            int MsgId = 0;
            DataSet ds = new DataSet();
            try
            {
                 
                const string dtFormat = "yyyy-MM-dd HH:mm:ss.fffffff zzz";
                string dtString2 = tokenDt.ToString(dtFormat, CultureInfo.InvariantCulture);
                dbManager.Open();
                dbManager.CreateParameters(5);
                dbManager.AddParameters(0, "UserCode", UserCode, ParameterDirection.Input);
                dbManager.AddParameters(1, "UserEmail", UserEmail, ParameterDirection.Input);
                dbManager.AddParameters(2, "EmlTmpl", EmlTmpl, ParameterDirection.Input);
                dbManager.AddParameters(3, "token", token, ParameterDirection.Input);
                dbManager.AddParameters(4, "tokenDt", dtString2, ParameterDirection.Input);

                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "SendResetPswdlink");
                ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "SendResetPswdlink");
                MsgId = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                return MsgId;
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
 
        internal int Save_UserPassword(string UserEmail,string userCode,string UsrPwd,string strToken)
        {
            IDBManager dbManager = CommonConnection.Connectionstring();
            int results = 0;
            DataSet ds = new DataSet();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(4);
                dbManager.AddParameters(0, "UserEmail", UserEmail, ParameterDirection.Input);
                dbManager.AddParameters(1, "userCode", userCode, ParameterDirection.Input);
                dbManager.AddParameters(2, "UsrPwd", UsrPwd, ParameterDirection.Input);
                dbManager.AddParameters(3, "strToken", strToken, ParameterDirection.Input);

                string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "Save_userPassword");

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "Save_userPassword");
                    results = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                }

                return results;
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