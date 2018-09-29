using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GTKSSOLibrary.BusinessObjects
{
   public class GTKUserBaseData
    {
        private static GTKUserBaseData _self = new GTKUserBaseData();
        public static GTKUserBaseData obj
        {
            get
            {
                return _self;
            }
        }
        public string AvailableModuleObjectString
        {
            get
            {
                if (HttpContext.Current.Session["UserInfo"] == null)
                    return null;
                else
                    return HttpContext.Current.Session["UserInfo"].ToString();
            }
            set
            {
                HttpContext.Current.Session.Add("UserInfo", value);
            }
        }
    }
}
