using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTKSSO.UI
{
    public partial class SSODashboard : System.Web.UI.Page
    {
        public string UserCode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null && Session["UserInfo"].ToString() != "")
                UserCode = Session["UserInfo"].ToString();
            else
                Response.Redirect("~/UI/Login.aspx");
        }
    }
}