using GTKSSOAPI.BusinessLogicLayer;
using GTKSSOAPI.Models;
using RC4Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GTKonnect.CommonUtilites.Helpers;
using GTKSSOLibrary.BusinessLayer;

namespace GTKSSOAPI.Controllers
{
    public class DashBoardController : ApiController
    {
        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public IEnumerable<GTKSSOURLDetails> getURLDetails([FromBody]string[] UserInfo)
        {
            List<GTKSSOURLDetails> lstGTKSSOURLDetails = new List<GTKSSOURLDetails>();
            try
            {
                GTKSSOURLDetails objGTKSSOURLDetails = new GTKSSOURLDetails();
                object lStrKey = ConfigurationSettings.AppSettings["RC4Key"].ToString();
                ClsRc4 objRc4 = new ClsRc4();
                object objFN = UserInfo[0].ToString();
                object HexobjFN = objRc4.RC4(ref objFN, ref lStrKey);
                string usercode = objRc4.StringToHex(ref HexobjFN).ToString();

                string DBName = string.Empty;
                if (UserInfo.Length > 1)
                {
                    if (UserInfo[1] != null && UserInfo[1].ToString() != "")
                    {
                        object objDB = UserInfo[1].ToString();
                        object HexobjDB = objRc4.RC4(ref objDB, ref lStrKey);
                        DBName = objRc4.StringToHex(ref HexobjDB).ToString();
                    }
                }
                objGTKSSOURLDetails.UserCode = usercode;
                if (DBName != "")
                    objGTKSSOURLDetails.DBName = DBName;

                lstGTKSSOURLDetails.Add(objGTKSSOURLDetails);
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.LogError("GTKSSOAPI.Controllers.DashBoardController", "getURLDetails", ex.ToString(), UserInfo[0]);
            }
            return lstGTKSSOURLDetails;
        }

        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public IEnumerable<DBResult> getDashBDetails([FromBody]string[] UserInfo)
        {
            List<DBResult> lstDBResult = new List<DBResult>();
            try
            {
                DashBoardBAL objDashBoardBAL = new DashBoardBAL();
                DataSet ds = objDashBoardBAL.getDashBDtls(UserInfo[0], UserInfo[1]);
                List<ApplicationType> lstAppType = ds.Tables[0].ConvertToList<ApplicationType>();
                DataTable dtList = ds.Tables[1];
                List<DBLinks> lstDBLinksTotal = dtList.ConvertToList<DBLinks>();
                DashBoard objDashBoard;
                List<DashBoard> lstDashBoard = new List<DashBoard>();
                if (dtList.Rows.Count > 0)
                {
                    var distinctValues = dtList.AsEnumerable()
                                .Select(row => new
                                {
                                    AppHead = row.Field<string>("AppHead")
                                })
                                .Distinct();

                    DataTable dtChlds = new DataTable();
                    List<DBLinks> lstDBLinks;
                    foreach (var item in distinctValues.ToList())
                    {
                        if (item.AppHead != null && item.AppHead != "")
                        {
                            dtChlds = dtList.Select("AppHead='" + item.AppHead + "'").CopyToDataTable();
                            if (dtChlds != null && dtChlds.Rows.Count > 0)
                            {
                                lstDBLinks = new List<DBLinks>();
                                lstDBLinks = dtChlds.ConvertToList<DBLinks>();
                                objDashBoard = new DashBoard();
                                objDashBoard.head = item.AppHead;
                                objDashBoard.items = lstDBLinks;
                                lstDashBoard.Add(objDashBoard);
                            }
                        }
                    }
                }
                DBResult objDBResult = new DBResult();
                objDBResult.AppTypeList = lstAppType;
                objDBResult.DashBoardList = lstDashBoard;
                objDBResult.DBLinksList = lstDBLinksTotal;
                lstDBResult.Add(objDBResult);
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.LogError("GTKSSOAPI.Controllers.DashBoardController", "getDashBDetails", ex.ToString(), UserInfo[0]);
            }
            return lstDBResult;
        }

        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public IEnumerable<DBResult> getSrchDashBDetails(DBSrchInput objDBSrchInput)
        {
            List<DBResult> lstDBResult = new List<DBResult>();
            DataTable dtList = objDBSrchInput.DBLinksList.Where(x=>x.AppTag== objDBSrchInput.AppTag).FirstOrDefault().ConvertToDataTable();
            DashBoard objDashBoard;
            List<DashBoard> lstDashBoard = new List<DashBoard>();
            if (dtList.Rows.Count > 0)
            {
                var distinctValues = dtList.AsEnumerable()
                            .Select(row => new
                            {
                                AppHead = row.Field<string>("AppHead")
                            })
                            .Distinct();

                DataTable dtChlds = new DataTable();
                List<DBLinks> lstDBLinks;
                foreach (var item in distinctValues.ToList())
                {
                    if (item.AppHead != null && item.AppHead != "")
                    {
                        dtChlds = dtList.Select("AppHead='" + item.AppHead + "'").CopyToDataTable();
                        if (dtChlds != null && dtChlds.Rows.Count > 0)
                        {
                            lstDBLinks = new List<DBLinks>();
                            lstDBLinks = dtChlds.ConvertToList<DBLinks>();
                            objDashBoard = new DashBoard();
                            objDashBoard.head = item.AppHead;
                            objDashBoard.items = lstDBLinks;
                            lstDashBoard.Add(objDashBoard);
                        }
                    }
                }
            }
            DBResult objDBResult = new DBResult();
            objDBResult.DashBoardList = lstDashBoard;
            lstDBResult.Add(objDBResult);
            return lstDBResult;
        }
    }
}
