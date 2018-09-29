using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GTKSSOLibrary.BusinessLayer;
using GTKUtilites;
using System.Configuration;
using System.Web.UI;
using System.Data;
using System.Text;

namespace GTKSSO.UILayer.Security
{
    public class SecPage : System.Web.UI.Page
    {
        ErrorLog error = new ErrorLog();

        public void LogError(string nameSpace, string errEvent, string stack, string user, bool pageRedirect)
        {
            error.LogError(nameSpace, errEvent, stack, user);
            if (pageRedirect)
            {
                string sURL = ResolveUrl("~/UILayer/ErrorPage.aspx");
                HttpContext.Current.Response.Redirect(string.Format("{0}?ErrMsg={1}&Master={2}", sURL, stack, string.Empty));
            }
        }
    }
}