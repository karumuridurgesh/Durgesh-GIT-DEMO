using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GTKSSOLibrary.DataAccessLayer;
using GTKSSOLibrary.BusinessObjects; 
using GTKonnect.DBHelper.DBConnecter;
using System.Configuration;
using System.Web;

namespace GTKSSOAPI.DataAccessLayer
{
    public class UserDAL
    {  
        public DataSet getLoginInfo(string UserCode, string Password)
        {
            GTKDBConnection dbManager = CommonConnection.GetGTKConnection();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "LoginUserCode", UserCode, ParameterDirection.Input);
                dbManager.AddParameters(1, "UserPassword", Password, ParameterDirection.Input);
                string spCall = dbManager.GetSPCall("getLoginInfo");
                DataSet ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "getLoginInfo");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbManager.Dispose();
            }

        }

        public DataSet getMenuDetails(string UserCode)
        {
            GTKDBConnection dbManager = CommonConnection.GetGTKConnection();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "UserCode", UserCode, ParameterDirection.Input);
                string spCall = dbManager.GetSPCall("dbo.GTKSSOMenuDtls");
                DataSet ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "dbo.GTKSSOMenuDtls");

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
        public DataSet getAllUserInfo( Int32 PageNumber, Int32 RowsPerPage,DataTable dtParams)
        {
            GTKDBConnection dbManager = CommonConnection.GetGTKConnection();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3); 
                dbManager.AddParameters(0, "@PageNumber", PageNumber, ParameterDirection.Input);
                dbManager.AddParameters(1, "@RowsPerPage", RowsPerPage, ParameterDirection.Input);
                dbManager.AddParameters(2, "@filterParams", dtParams, ParameterDirection.Input);
                string spCall = dbManager.GetSPCall("getAllUserInfo");
                DataSet ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "getAllUserInfo");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbManager.Dispose();
            }

        }

       
            public DataSet getGTKSSOUserAxn(int Menuid)
        {
            GTKDBConnection dbManager = CommonConnection.GetGTKConnection();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@Menuid", Menuid, ParameterDirection.Input); 
                string spCall = dbManager.GetSPCall("getGTKSSOUserAxn");
                DataSet ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "getGTKSSOUserAxn");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbManager.Dispose();
            }

        }

        public DataSet saveUserAction(  DataTable dtParams ,string usercode, string AxnCD)
        {
            GTKDBConnection dbManager = CommonConnection.GetGTKConnection();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);
                 
                dbManager.AddParameters(0, "@UserAxnParams", dtParams, ParameterDirection.Input);
                dbManager.AddParameters(1, "@loginusercode", usercode, ParameterDirection.Input);
                dbManager.AddParameters(2, "@AxnCD", AxnCD, ParameterDirection.Input);
                string spCall = dbManager.GetSPCall("saveUserAction");
                DataSet ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "saveUserAction");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbManager.Dispose();
            }

        }
        
          public DataSet saveChangePassword(string Usercode, string Oldpassword, string NewPassword)
        {
            GTKDBConnection dbManager = CommonConnection.GetGTKConnection();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(3);

                dbManager.AddParameters(0, "@Usercode", Usercode, ParameterDirection.Input);
                dbManager.AddParameters(1, "@Oldpassword", Oldpassword, ParameterDirection.Input);
                dbManager.AddParameters(2, "@NewPassword", NewPassword, ParameterDirection.Input);
                string spCall = dbManager.GetSPCall("saveChangePassword");
                DataSet ds = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "saveChangePassword");

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbManager.Dispose();
            }

        }
    }
}