using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GTKSSOLibrary.DataAccessLayer;
using GTKSSOLibrary.BusinessObjects;

namespace GTKSSOLibrary.BusinessLogicLayer
{
    public class BALUser
    {
        DALUser clsUserDAL = new DALUser();
        public DataSet Open_LoginInfo(string userid, string passcode, string param)
        {
            try
            {
                return clsUserDAL.Open_LoginInfo(userid, passcode, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_LoginDtl(string userid, string passcode, ref string sReturnMsg)
        {
            try
            {
                return clsUserDAL.Fetch_LoginDtl(userid, passcode, ref sReturnMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_UserInfo(string Mode, string usercode)
        {
            try
            {
                return clsUserDAL.Fetch_UserInfo(Mode, usercode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Save_UserInfo(UserList user)
        {
            try
            {
                return clsUserDAL.Save_UserInfo(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save_UserInfox(string xml,string Mode)
        {
            try
            {
                return clsUserDAL.Save_UserInfox(xml,Mode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Validate(string param, string Mode)
        {
            try
            {
                return clsUserDAL.Validate(param, Mode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save_NewApps(int appid,string AppName, string AppURL, string Status,string mode)
        {
            return clsUserDAL.Save_NewApps(appid,AppName, AppURL, Status, mode);
        }

        public int Save_NewAppsx(string xml, string Mode)
        {
            try
            {
                return clsUserDAL.Save_NewAppsx(xml, Mode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SendResetPswdlink(string UserCode, string UserEmail, string EmlTmpl ,string token,DateTimeOffset tokenDt)
        {
            try
            {
                return clsUserDAL.SendResetPswdlink( UserCode,  UserEmail,  EmlTmpl, token, tokenDt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save_UserPassword(string UserEmail, string userCode, string UsrPwd ,string strToken)
        {
            try
            {
                return clsUserDAL.Save_UserPassword(UserEmail, userCode, UsrPwd, strToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}