//using GTKonnectLibrary.BusinessLayer;
//using GTKonnectLibrary.BusinessLogicLayer;
//using GTKonnectLibrary.BusinessObjects;
//using GTKUserControls.UILayer;
//using GTKUserControls.UILayer.CommonClasses.UtilityClasses;
//using GTKUtilites.SessionUtils;
using GTKUtilites.HelpMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
//using B = GTKCommonUtilities.BusinessObjects;

namespace GTKSSO.MasterPages
{
    public partial class GTKMst : System.Web.UI.MasterPage
    {
        //JavaScriptSerializer jss = new JavaScriptSerializer();
        //public string UserRoleID { get; set; }
        //GeneralBLL clsSecBLLjss = new GeneralBLL();
        //private string strModule;
        //SecBLLFlexFldSetting clsSecFlex = new SecBLLFlexFldSetting();
        //AvailableModule clsAvailableModule = new AvailableModule();
        //List<AvailableModule> liAvailableModule = new List<AvailableModule>();
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                // The code below helps to protect against XSRF attacks
                //First, check for the existence of the Anti-XSS cookie
                //var requestCookie = Request.Cookies[AntiXsrfTokenKey];
                //Guid requestCookieGuidValue;

                ////If the CSRF cookie is found, parse the token from the cookie.
                ////Then, set the global page variable and view state user
                ////key. The global variable will be used to validate that it matches in the view state form field in the Page.PreLoad
                ////method.
                //if (requestCookie != null
                //&& Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
                //{
                //    //Set the global token variable so the cookie value can be
                //    //validated against the value in the view state form field in
                //    //the Page.PreLoad method.
                //    _antiXsrfTokenValue = requestCookie.Value;

                //    //Set the view state user key, which will be validated by the
                //    //framework during each request
                //    Page.ViewStateUserKey = _antiXsrfTokenValue;
                //}
                ////If the CSRF cookie is not found, then this is a new session.
                //else
                //{
                //    //Generate a new Anti-XSRF token
                //    _antiXsrfTokenValue = Guid.NewGuid().ToString("N");

                //    //Set the view state user key, which will be validated by the
                //    //framework during each request
                //    Page.ViewStateUserKey = _antiXsrfTokenValue;

                //    //Create the non-persistent CSRF cookie
                //    var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                //    {
                //        //Set the HttpOnly property to prevent the cookie from
                //        //being accessed by client side script
                //        HttpOnly = true,

                //        //Add the Anti-XSRF token to the cookie value
                //        Value = _antiXsrfTokenValue
                //    };

                //    //If we are using SSL, the cookie should be set to secure to
                //    //prevent it from being sent over HTTP connections
                //    if (FormsAuthentication.RequireSSL &&
                //    Request.IsSecureConnection)
                //        responseCookie.Secure = true;

                //    //Add the CSRF cookie to the response
                //    Response.Cookies.Set(responseCookie);
                //}

                //Page.PreLoad += master_Page_PreLoad;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            //During the initial page load, add the Anti-XSRF token and user
            //name to the ViewState
            if (!IsPostBack)
            {
                //Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

                //If a user name is assigned, set the user name
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            //During all subsequent post backs to the page, the token value from
            //the cookie should be validated against the token in the view state
            //form field. Additionally user name should be compared to the
            //authenticated users name
            else
            {
                //Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                         || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of  Anti-XSRF token failed.");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GenericMethods.CheckXSRF(this.Page, CSRFToken);
            form1.Action = this.Page.Request.Url.Segments.Last();
            //if (!IsPostBack)
            //{
            //    try
            //    {
            //        if (GTKUserBaseData.obj.AvailableModuleObjectString == null)
            //        {
            //            if (GTKUserBaseData.obj.AvailableModuleObject != null && GTKUserBaseData.obj.AvailableModuleObject.Count > 0)
            //            {
            //                GetAvailableModulesJss();
            //                GetModulesJss();
            //            }
            //        }
            //        if (Session["GtModule"] != null && Session["GtModuleName"] != null && Session["GtModule"].ToString() != "" && Session["GtModuleName"].ToString() != "")
            //        {
            //            gtkmstmodeurl.InnerText = Session["GtModuleName"].ToString();
            //            gtkmstmodeurl.HRef = "~/UILayer/Security/SECDashBoard.aspx?Mod=" + Session["GtModule"];
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        SecBasePage.Ins.LogError("GTKUserControls.MasterPages.GTKMst", "Page_Load", ex.Message.ToString().Replace("\r\n", ""), SecBasePage.Ins.UserCode, true);
            //    }
            //}
        }

        //internal void GetModulesJss()
        //{
        //    var availableModuleList = jss.Deserialize<List<B.Modules>>(GTKUserBaseData.obj.AvailableModuleObjectString);
        //    DataTable dtGTMenu = new DataTable();
        //    if (!string.IsNullOrEmpty(HttpContext.Current.Session[SecBasePage.UserInfo].ToString()))
        //    {
        //        if (HttpContext.Current.Session["GTModule"] != null)
        //        {
        //            strModule = HttpContext.Current.Session["GTModule"].ToString();
        //        }
        //    }
        //    var objModule = liAvailableModule.Where(p => p.MODCODE == strModule).FirstOrDefault();
        //    if (objModule != null)
        //    {
        //        SessionData.obj.ModuleId = Convert.ToInt32(objModule.MODID);
        //        UserRoleID = GTKUserBaseData.obj.UserRoleId().ToString();
        //        string strModName = objModule.MODNAME;
        //        Session["GtModuleName"] = strModName;
        //        dtGTMenu = clsSecBLLjss.GetGTMenus(objModule.MODCODE, UserRoleID);

        //        int i = 1;
        //        var module = new B.Modules();
        //        module.ModuleName = objModule.MODNAME;
        //        module.MODCODE = objModule.MODCODE;
        //        module.URL = ((String.IsNullOrEmpty(objModule.EXTURL.ToString())) ? dtGTMenu.Select("HASCHILDS = 1901", "SEQNO ASC")[0]["URL"].ToString() : objModule.EXTURL.ToString());
        //        module.IsDefault = false;
        //        if (strModule == objModule.MODCODE)
        //            module.IsDefault = true;
        //        module.MenuItems = new List<B.Menu>();
        //        var menuItems = new List<B.Menu>();

        //        foreach (System.Data.DataRow dr in dtGTMenu.Rows)
        //        {
        //            if (dr["PARENTFEATURE"].ToString() == "")
        //            {
        //                var menuItem = new B.Menu();
        //                menuItem.ParentFeature = dr["MENUFEATURE"].ToString();

        //                DataTable dtChlds = new DataTable();
        //                int k = i + 1;
        //                if (dtGTMenu.Select("PARENTFEATURE='" + dr["MENUFEATURE"].ToString() + "'").Length > 0)
        //                {
        //                    dtChlds = dtGTMenu.Select("PARENTFEATURE='" + dr["MENUFEATURE"].ToString() + "'").CopyToDataTable();
        //                    if (dtChlds != null && dtChlds.Rows.Count > 0)
        //                    {
        //                        if (dtChlds.Select("HASCHILDS='1901'").Length > 0)
        //                        {
        //                            dtChlds = dtChlds.Select("HASCHILDS='1901'").CopyToDataTable();
        //                            var childItems = new List<B.MenuItems>();
        //                            foreach (DataRow drc in dtChlds.Rows)
        //                            {

        //                                childItems.Add(new B.MenuItems()
        //                                {
        //                                    ChildFeatureName = drc["MENUFEATURE"].ToString(),
        //                                    url = drc["URL"].ToString()
        //                                });


        //                                k++;
        //                            }
        //                            menuItem.ChildMenuItems = childItems;

        //                        }
        //                    }
        //                }
        //                menuItems.Add(menuItem);
        //                module.MenuItems = menuItems;
        //                availableModuleList.RemoveAll(x => x.ModuleName == strModName);
        //                availableModuleList.Add(new B.Modules()
        //                {
        //                    IsDefault = module.IsDefault,
        //                    URL = module.URL,
        //                    MODCODE = module.MODCODE,
        //                    ModuleName = strModName,
        //                    MenuItems = menuItems
        //                });
        //            }
        //            GTKUserBaseData.obj.AvailableModuleObjectString = jss.Serialize(availableModuleList);
        //            i++;
        //        }

        //        SessionData.obj.ModuleId = Convert.ToInt32(GTKUserBaseData.obj.GTKModuleDetailsByModCode(strModule).MODID);
        //        UserRoleID = GTKUserBaseData.obj.UserRoleId().ToString();
        //    }
        //    else
        //        Response.Redirect("~/UILayer/AccessForbidden.aspx");
        //}

        //private void GetAvailableModulesJss()
        //{
        //    string strImage; int UserRoleID = 0;
        //    StringBuilder strMenuHTML = new StringBuilder(); //added by siva
        //    if (HttpContext.Current.Session["UserInfo"] != null)
        //    {
        //        DataRow drUserInfo = (DataRow)HttpContext.Current.Session["UserInfo"];
        //        UserRoleID = Convert.ToInt32(drUserInfo["UserRole"].ToString());
        //    }

        //    if (GTKUserBaseData.obj.AvailableModuleObject != null && GTKUserBaseData.obj.AvailableModuleObject.Count > 0)
        //    {
        //        liAvailableModule = GTKUserBaseData.obj.AvailableModuleObject; // GTKUserBaseData.obj.AvailableModuleObject.Where(x => x.MTYPE == "UR").ToList();
        //        Session["Modules"] = liAvailableModule;
        //    }
        //    var availableModules = new List<B.Modules>();
        //    foreach (AvailableModule objAvailableModule in liAvailableModule)
        //    {
        //        var module = new B.Modules();
        //        module.ModuleName = objAvailableModule.MODNAME;
        //        module.MODCODE = objAvailableModule.MODCODE;
        //        availableModules.Add(module);
        //    }
        //    GTKUserBaseData.obj.AvailableModuleObjectString = jss.Serialize(availableModules).ToString();
        //}

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    SecBLLUser secBLLUser = new SecBLLUser();
        //    Session[SecBasePage.UserInfo] = null;
        //    Session["DES"] = null;
        //    if (HttpContext.Current.Session["LoggedInStatusID"] != null)
        //    {
        //        secBLLUser.UpdateLoginUserStatus(Convert.ToInt32(HttpContext.Current.Session["LoggedInStatusID"]), 1);
        //    }
        //    Session.Abandon();
        //    Session.Clear();
        //    HttpContext.Current.Session.Clear();

        //    string URL = Convert.ToString(ConfigurationManager.AppSettings["URLRedirect"]);
        //    if (!string.IsNullOrEmpty(URL))
        //    {
        //        Session["LoginError"] = "You have successfully logged out";
        //        Response.Redirect(URL);
        //    }
        //    else if (GTKUserBaseData.obj.HttpReferrersObject != null && GTKUserBaseData.obj.HttpReferrersObject.Where(x => x.AuthMethod == "GTK").Count() == 0)
        //    {
        //        Session["LoginError"] = "You have successfully logged out";
        //        Response.Redirect("AccessForbidden.aspx");
        //    }
        //    else
        //        Response.Redirect("~/UILayer/Login.aspx");
        //}
        protected void btnLogout_Click(object sender, EventArgs e)
        {
             
                Response.Redirect("~/UI/Login.aspx");
        }
    }
}