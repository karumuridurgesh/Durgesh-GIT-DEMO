using GTKSSO.UILayer.Security;
using GTKSSOLibrary.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTKSSO.UI
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        string strToken = ""; int NoOfmin = 0;
        BALUser secBLLUser = new BALUser();
        SecPage LError = new SecPage();
        DataSet dsUsers = null; string strResult = ""; string usercode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["AuthCd"] != null)
                        {
                            strToken = Convert.ToString(Request.QueryString["AuthCd"]);
                            Open(strToken);
                            hfresetToken.Value = strToken;
                            ViewState["dsusers"] = dsUsers;
                        }
                        else
                        {
                            strResult = "URL";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                        }
                    }
                    else
                    {
                        strResult = "URL";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                    }
                }
                else
                {
                    dsUsers = (DataSet)ViewState["dsusers"];
                    strToken = Convert.ToString(Request.QueryString["AuthCd"]);
                    if (dsUsers != null)
                    {
                        if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0] != null && dsUsers.Tables[0].Rows.Count > 0)
                        {
                            usercode = dsUsers.Tables[0].Rows[0]["UserCode"].ToString();
                            NoOfmin = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["NOOfMin"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.UI.ResetPassword", "Load", ex.Message.ToString().Replace("\r\n", ""), usercode, true);

            }
        }
     
        private void Open(string Code)
        {
            try
            {
                 dsUsers = secBLLUser.Open_LoginInfo(Code, "", "Token");
                
                if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0] != null && dsUsers.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "GetDate", "GetDate();", true);
                    
                }
                else
                {
                    //Token is invalid.
                    strResult = "INV";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                }

            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.UI.ResetPassword", "open", ex.Message.ToString().Replace("\r\n", ""), usercode, true);
            }
        }
        protected void btnCurrdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0] != null && dsUsers.Tables[0].Rows.Count > 0)
                {
                      usercode = dsUsers.Tables[0].Rows[0]["UserCode"].ToString();
                     NoOfmin = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["NOOfMin"].ToString());
                    DateTimeOffset dt = DateTimeOffset.Parse(dsUsers.Tables[0].Rows[0]["tokengendate"].ToString(), CultureInfo.InvariantCulture);
                    string dtString = dt.ToString("ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);
               
                    DateTime CurrentDate = DateTime.ParseExact(hfCurrdate.Value.Substring(0, 24), "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime LinkDate = DateTime.ParseExact(dtString.ToString(), "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    if (CurrentDate <= LinkDate.AddMinutes(NoOfmin))
                    {
                        txtEmail.Value = dsUsers.Tables[0].Rows[0]["UserEmail"].ToString();
                        //txtNewPassword.Focus();
                        txtNewPassword.Value = "";
                        txtConfirmPassword.Value = "";
                    }
                    else
                    {
                        strResult = "EXP";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                    }
                }
               
              
            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.UI.ResetPassword", "btnCurrdate_Click", ex.Message.ToString().Replace("\r\n", ""), usercode, true);

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Value != "")
                {
                    if (txtNewPassword.Value != "" && txtConfirmPassword.Value != "")
                    {
                        if (txtNewPassword.Value == txtConfirmPassword.Value)
                        {
                            int success = secBLLUser.Save_UserPassword(txtEmail.Value, usercode, txtNewPassword.Value, strToken);
                            if (success > 0)
                            {
                                strResult = "SUC";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                            }
                            else
                            {
                                strResult = "ERR";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                            }
                        }
                    }
                }
                else
                {
                    strResult = "Email";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "GetAlert('" + strResult + "');", true);
                }


            }
            catch (Exception ex)
            {
                LError.LogError("GTKSSO.UI.ResetPassword", "btnSubmit_Click", ex.Message.ToString().Replace("\r\n", ""), usercode, true);

            }
        }


    //    [WebMethod]
    //    public static string ValidateToken(string clientDate,string tokenCode)
    //    {
    //        string email = "";
    //        try
    //        {
    //            DataSet dsUsers1 = new DataSet();
    //            BALUser secBLLUser1 = new BALUser();
                 
    //            dsUsers1 = secBLLUser1.Open_LoginInfo(tokenCode, "", "Token");
    //            if (dsUsers1.Tables.Count > 0 && dsUsers1.Tables[0] != null && dsUsers1.Tables[0].Rows.Count > 0)
    //            {
    //               string usercode1 = dsUsers1.Tables[0].Rows[0]["UserCode"].ToString();
    //               int  NoOfmin1 = Convert.ToInt32(dsUsers1.Tables[0].Rows[0]["NOOfMin"].ToString());
    //                DateTimeOffset dt = DateTimeOffset.Parse(dsUsers1.Tables[0].Rows[0]["tokengendate"].ToString(), CultureInfo.InvariantCulture);
    //                string dtString = dt.ToString("ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);

    //                DateTime CurrentDate = DateTime.ParseExact(clientDate.Substring(0, 24), "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);
    //                DateTime LinkDate = DateTime.ParseExact(dtString.ToString().Substring(0, 24), "ddd MMM d yyyy HH:mm:ss", CultureInfo.InvariantCulture);

    //                if (CurrentDate <= LinkDate.AddMinutes(NoOfmin1))
    //                {
    //                    email = dsUsers1.Tables[0].Rows[0]["UserEmail"].ToString();
                         
    //                }
    //                else
    //                {
    //                    email = "";
    //                }
    //            }

    //            return email;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;

    //        }
    //    }
    }
}