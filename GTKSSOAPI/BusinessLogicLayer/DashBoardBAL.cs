using GTKSSOAPI.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GTKSSOAPI.BusinessLogicLayer
{
    public class DashBoardBAL
    {
        DashBoardDAL clsDashBoardDAL = new DashBoardDAL();
        public DataSet getDashBDtls(string userid, string AppType)
        {
            try
            {
                return clsDashBoardDAL.getDashBDtls(userid,  AppType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}