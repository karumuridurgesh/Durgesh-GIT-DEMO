using GTKSSOAPI.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GTKSSOAPI.BusinessLogicLayer
{
    public class UserBAL
    {
        UserDAL clsUserDAL = new UserDAL();
        public DataSet getLoginInfo(string userid, string passcode)
        {
            try
            {
                return clsUserDAL.getLoginInfo(userid, passcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getMenuDetails(string userid)
        {
            try
            {
                return clsUserDAL.getMenuDetails(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getAllUserInfo( Int32 PageNumber, Int32 RowsPerPage,DataTable dtParams)
        {
            try
            {
                return clsUserDAL.getAllUserInfo(   PageNumber,   RowsPerPage, dtParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getGTKSSOUserAxn(int Menuid)
        {
            try
            {
                return clsUserDAL.getGTKSSOUserAxn( Menuid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet saveUserAction(DataTable dtParams, string Usercode, string AxnCD)
        {
            try
            {
                return clsUserDAL.saveUserAction( dtParams,  Usercode,  AxnCD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet saveChangePassword(  string Usercode, string Oldpassword,string NewPassword )
        {
            try
            {
                return clsUserDAL.saveChangePassword(Usercode, Oldpassword, NewPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}