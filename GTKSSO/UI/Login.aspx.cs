using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GTKSSO.UILayer.Security;
using GTKSSOLibrary.BusinessLogicLayer;
using GTKUtilites.HelpMethods;

namespace GTKSSO.UI
{
    public partial class Login : System.Web.UI.Page     
    {
        BALUser secBLLUser = new BALUser();
        SecPage LError = new SecPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            GenericMethods.CheckXSRF(this.Page, CSRFToken);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUser.Value!=""  && txtPassword.Value!="")
                {
                    string sReturnMsg = string.Empty;
                    DataSet dsUsers = secBLLUser.Fetch_LoginDtl(txtUser.Value, txtPassword.Value, ref sReturnMsg);
                    if (sReturnMsg == string.Empty && dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                    {
                        if (dsUsers != null && dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                        {
                            Session["UserName"] = dsUsers.Tables[0].Rows[0]["UserFirstName"].ToString();
                            Session["UserInfo"] = dsUsers.Tables[0].Rows[0]["UserCode"].ToString();
                            Session["UserInfoT"] = dsUsers.Tables[0].Rows[0]["UserCode"].ToString();

                            Response.Redirect("~/UI/ssodashboard.aspx", false);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert();", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + sReturnMsg + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.UI.Login", "btnLogin_Click", ex.Message.ToString().Replace("\r\n", ""), Session["UserInfo"].ToString(), true);

            }
        }
    }
}