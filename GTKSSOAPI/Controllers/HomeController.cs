using GTKSSOAPI.BusinessLogicLayer;
using GTKSSOAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GTKonnect.CommonUtilites.Helpers;
using System.Web;
using GTKSSOLibrary.BusinessLayer;

namespace GTKSSOAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public IEnumerable<GTKSSOMenu> getMenuDetails([FromBody]string[] UserInfo)
        {
            List<GTKSSOMenu> lstGTKSSOMenu = new List<GTKSSOMenu>();
            try
            {
                UserBAL secBLLUser = new UserBAL();
                GTKSSOMenu objGTKSSOMenu = new GTKSSOMenu();
                DataSet ds = secBLLUser.getMenuDetails(UserInfo[0]);
                DataTable dt = ds.Tables[0];
                lstGTKSSOMenu = dt.ConvertToList<GTKSSOMenu>();
            }
            catch (Exception ex)
            {
                ErrorLog error = new ErrorLog();
                error.LogError("GTKSSOAPI.Controllers.HomeController", "getMenuDetails", ex.Message, UserInfo[0]);
            }
            return lstGTKSSOMenu;
        }
    }
}
