using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using GTKUtilites.DataAccessLayer;

namespace GTKUtilites.DataAccessLayer
{
 public static  class CommonConnection
    {
        private static string m_globalVar = "";
        private static int userID;
        private static int orgID;
        private static string uesrName;
        private static string userTypeName;
        private static int userTypeId;

     # region Properties
        public static string GlobalVar
        {
            get { return m_globalVar; }
            set { m_globalVar = value; }
        }
        public static int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public static int OrgID
        {
            get { return orgID; }
            set { orgID = value; }
        }
        public static string UserName
        {
            get { return uesrName; }
            set { uesrName = value; }
        }
        public static string UserTypeName
        {
            get { return userTypeName; }
            set { userTypeName = value; }
        }
        public static int UserTypeID
        {
            get { return userTypeId; }
            set { userTypeId = value; }
        }

        #endregion

        public static IDBManager  Connectionstring(){
         IDBManager  dbManager = null;
         if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
         {
          dbManager = new DBManager(DataProvider.OleDb);
          //if (HttpContext.Current.Session == null || string.IsNullOrEmpty(SessionUtils.SessionObjects.obj.GTKOrgID))
          //    SessionUtils.SessionObjects.obj.GTKOrgID = "1";
          //dbManager.ConnectionString = ConfigurationSettings.AppSettings["ConnString" + SessionUtils.SessionObjects.obj.GTKOrgID];
          dbManager.ConnectionString = ConfigurationSettings.AppSettings["ConnString1"];
         }
         else
         {
          dbManager = new DBManager(DataProvider.Oracle);
          dbManager.ConnectionString = ConfigurationSettings.AppSettings["ConnString"];
         }
         return dbManager;
      }
    }
}
