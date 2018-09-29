using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using GTKSSO.UILayer.Security;
using XSS = Microsoft.Security.Application;

namespace GTKSSO
{
    public partial class SECMaster : System.Web.UI.MasterPage
    {
        SecPage LError = new SecPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string s = this.Page.Request.Url.Query;
                form1.Action = this.Page.Request.Url.Segments.Last();

                if (!IsPostBack)
                {
                    HttpContext.Current.Session["TimeZone"] = "GREENWICH STANDARD TIME";
                    HttpContext.Current.Session["LanguageCode"] = "English";
                    lblLanguageCode.Text = XSS.Encoder.HtmlEncode(HttpContext.Current.Session["LanguageCode"].ToString()); //Session["UserInfo"]
                    lblUserCode.Text = XSS.Encoder.HtmlEncode(HttpContext.Current.Session["UserName"].ToString());
                }
            }
            catch(Exception ex)
            {
                LError.LogError("GTKSSO.SECMaster", "Page_Load", ex.Message.ToString().Replace("\r\n", ""), Session["UserInfo"].ToString(), true);
                
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session["UserInfo"] = null;
                Session.Abandon();
                Session.Clear();
                HttpContext.Current.Session.Clear();
                Response.Redirect("~/UILayer/Login.aspx",false);
            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.SECMaster", "btnLogout_Click", ex.Message.ToString().Replace("\r\n", ""), Session["UserInfo"].ToString(), true);
            }
        }

        protected void Page_PreInit(EventArgs e)
        {
            try
            {
                if (System.Configuration.ConfigurationSettings.AppSettings["Theme"].ToString() != null)
                {
                    this.Page.Theme = System.Configuration.ConfigurationSettings.AppSettings["Theme"].ToString();
                }
                if (Session["UserInfo"] == null || Convert.ToString(Session["UserInfo"]) == "")
                {
                    Response.Redirect("~/UILayer/ErrorPage.aspx", false);
                }
            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.SECMaster", "Page_PreInit", ex.Message.ToString().Replace("\r\n", ""), Session["UserInfo"].ToString(), true);
            }
        }
    }
}