using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using System.Data;
using GTKSSOAPI.Models;
using GTKSSOAPI.BusinessLogicLayer;
using System.Web;
using GTKSSOLibrary.BusinessObjects;
using GTKonnect.CommonUtilites.Helpers;
 

namespace GTKSSOAPI.Controllers
{
    public class UserController : ApiController
    {
        UserBAL secBLLUser = new UserBAL();
        [HttpPost]
        public string getUserInfo([FromBody]string[] UserInfo)
        {
            DataSet ds = secBLLUser.getLoginInfo(UserInfo[0], UserInfo[1]);
            DataTable dt = ds.Tables[0];

            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                //GTKUserBaseData.obj.AvailableModuleObjectString = ds.Tables[0].Rows[0]["UserCode"].ToString();
                //HttpContext.Current.Session["UserName"] = ds.Tables[0].Rows[0]["UserFirstName"].ToString();
                //HttpContext.Current.Session["UserInfo"] = ds.Tables[0].Rows[0]["UserCode"].ToString();
                //HttpContext.Current.Session["UserInfoT"] = ds.Tables[0].Rows[0]["UserCode"].ToString();
                string id = HttpContext.Current.Session.SessionID;
                return "1";
            }
            else
                return "0";
        }

        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public string test()
        {
            //DataSet ds = secBLLUser.getLoginInfo(UserCode, Password );
            //DataTable dt = ds.Tables[0];
            //List<GTKUserInfo> UserInfo = dt.ConvertToList<GTKUserInfo>();
            return "lak";
        }

        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public  Response GetAllUserInfo(UserParams objUserParams)
        {
            var response = new Response();
            List<GtkMstFilterParam> listGtkMstFilterParam = new List<GtkMstFilterParam>();
            GtkMstFilterParam objGtkMstFilterParam;
            DataTable dtParams = new DataTable();
            if (objUserParams.filter != null)
            {
                foreach (var item in objUserParams.filter.filters)
                {
                    objGtkMstFilterParam = new GtkMstFilterParam();
                    objGtkMstFilterParam.Field = item.field;
                    objGtkMstFilterParam.Condition = item.@operator;
                    objGtkMstFilterParam.Value = item.value;
                    listGtkMstFilterParam.Add(objGtkMstFilterParam);
                }
            }
            dtParams = DataTableExtentions.ConvertToDataTable<GtkMstFilterParam>(listGtkMstFilterParam);
            DataSet ds = secBLLUser.getAllUserInfo( Convert.ToInt32(objUserParams.page), Convert.ToInt32(objUserParams.pageSize), dtParams);

            List<GTKUserInfo> UserInfo = new List<GTKUserInfo>();
            if (ds.Tables[0].Rows.Count > 0)
                UserInfo = ds.Tables[0].ConvertToList<GTKUserInfo>();
            

            response = new Response()
            {
                Data = UserInfo.ToArray(),
                Count = Convert.ToInt32(ds.Tables[1].Rows[0]["totalcount"])
            };
            return response;

            
             
        }
        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public List<GTKSSOUserAxn> getGTKSSOUserAxn(Usermenu objmenuParams)
        {
            var response = new Response();
            DataSet ds = secBLLUser.getGTKSSOUserAxn(Convert.ToInt32(objmenuParams.MenuId));
            List<GTKSSOUserAxn> UserAxn = new List<GTKSSOUserAxn>();
            UserAxn = ds.Tables[0].ConvertToList<GTKSSOUserAxn>();
            //return UserAxn;
        //    response = new Response()
        //    {
        //        Data = UserAxn.ToArray()

        //};
            return UserAxn;
        }
        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public DataSet ManageUser(GtkuserAction objuserAxnParams)
        {
            UnLockUsers objUnLockUsers;
            List<UnLockUsers> lstUnLockUsers = new List<UnLockUsers>();
            foreach (var item in objuserAxnParams.usercodes)
            {
                objUnLockUsers = new UnLockUsers();
                objUnLockUsers.usercode = item;
                lstUnLockUsers.Add(objUnLockUsers);
            }
            
            DataTable dtParams = new DataTable();
            dtParams = lstUnLockUsers.ConvertToDataTable();
            DataSet ds = secBLLUser.saveUserAction(dtParams, objuserAxnParams.Usercode, objuserAxnParams.AxnCD);
            return ds;
        }
        [HttpPost]
        [AcceptVerbs("GET", "Post")]
        public DataSet ChangePassword(ChanePwdParams objuserChgPwdParams)
        {
            DataSet ds = secBLLUser.saveChangePassword(objuserChgPwdParams.Usercode, objuserChgPwdParams.OldPassword,
            objuserChgPwdParams.NewPassword);
            return ds;
        }

    }
}