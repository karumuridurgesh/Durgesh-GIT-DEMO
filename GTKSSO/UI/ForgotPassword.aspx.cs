using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GTKSSO.UILayer.Security;
using GTKSSOLibrary.BusinessLogicLayer;
using System.Globalization;

namespace GTKSSO.UI
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SecPage LError = new SecPage();
        BALUser secBLLUser = new BALUser();
        int MsgId = 0; string token = ""; string strResult = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (!String.IsNullOrEmpty(txtEmail.Value))
                {
                    DataSet dsUsers = secBLLUser.Open_LoginInfo(txtEmail.Value, "", "ForgotPSWD"); 
                    if (dsUsers != null && dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                    {

                        Session["UserEmail"] = dsUsers.Tables[0].Rows[0]["UserEmail"].ToString();
                        Session["UserInfo"] = dsUsers.Tables[0].Rows[0]["UserCode"].ToString();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "GetDate", "GetDate();", true); 
                    }
                    else
                    {
                        strResult = "Eval";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                        txtEmail.Focus();
                    }
                }
                else
                {
                    strResult = "Empty";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                    txtEmail.Focus();
                }
            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.UI.ForgotPassword", "btnNext_Click", ex.Message.ToString().Replace("\r\n", ""), Session["UserInfo"].ToString(), true);

            }
        }
        protected void btnCurrdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime datetimeoffset = DateTime.ParseExact(hfCurrdate.Value.Substring(0, 24), "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                token = Convert.ToBase64String(time.Concat(key).ToArray());

                MsgId = secBLLUser.SendResetPswdlink(Session["UserInfo"].ToString(), Session["UserEmail"].ToString(), "ResetPaswd", token, datetimeoffset);
                 strResult = "success";
                if (!String.IsNullOrEmpty(MsgId.ToString()) && MsgId > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                }
                else
                {
                    strResult = "error";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                }
            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.UI.ForgotPassword", "btnNext_Click", ex.Message.ToString().Replace("\r\n", ""), Session["UserInfo"].ToString(), true);

            }
        }

    }
}