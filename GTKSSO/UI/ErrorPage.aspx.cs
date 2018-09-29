using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

namespace GTKSSO.UI
{
    public partial class ErrorPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string sErrMsg = "An unexpected error has occurred. Please contact the System Administrator.";
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["ErrMsg"] != null)
                {
                    //sErrMsg =string.Format("{0}<br/>Error:{1}",sErrMsg, Encoder.HtmlEncode(Convert.ToString(Request.QueryString["ErrMsg"])));
                    // sErrMsg = string.Format("{0}({1} {2})", Request.QueryString["ErrMsg"].ToString(), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                    sErrMsg = Request.QueryString["ErrMsg"].ToString();
                    divError.Attributes.Add("class", "ErrorImage");
                }

                if (Request.QueryString["ErrorType"] != null)
                {
                    sErrMsg = string.Empty;
                    //sErrMsg = string.Format("You do not have access to {0} feature", Request.QueryString["ErrMsg"]);
                    divError.Attributes.Add("class", "WarningImage");
                }


                lblError.Text = Encoder.HtmlEncode(sErrMsg);
            }
            else
            {
                lblError.Text = Encoder.HtmlEncode(sErrMsg);
            }

        }
    }
}