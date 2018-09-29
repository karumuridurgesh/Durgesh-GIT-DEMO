using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTKSSOAPI.Models
{
    public class GTKSSOMenu
    {
        public Int64 MENUID { get; set; }
        public string MENUFEATURE { get; set; }
        public string PARENTFEATURE { get; set; }
        public string URL { get; set; }
        public string MenuImgUrl { get; set; }
        public Int64 HASCHILDS { get; set; }
    }
}