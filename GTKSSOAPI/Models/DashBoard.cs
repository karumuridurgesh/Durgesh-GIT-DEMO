using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTKSSOAPI.Models
{
    public class DashBoard
    {
        public string head { get; set; }
        public List<DBLinks> items { get; set; }
    }

    public class DBLinks
    {
        public Int64 APPId { get; set; }
        public string APPNAME { get; set; }
        public string URL { get; set; }
        public string AppType { get; set; }
        public string DBName { get; set; }
        public string AppImg { get; set; }
        public string AppTag { get; set; }
        public string ClientName { get; set; }
        public string AppHead { get; set; }
    }

    public class ApplicationType
    {
        public Int64 RowNumber { get; set; }
        public string AppType { get; set; }
    }

    public class DBResult
    {
        public List<ApplicationType> AppTypeList { get; set; }
        public List<DashBoard> DashBoardList { get; set; }
        public List<DBLinks> DBLinksList { get; set; }
    }

    public class DBSrchInput
    {
        public string AppTag { get; set; }
        public List<DBLinks> DBLinksList { get; set; }
    }

    public class GTKSSOURLDetails
    {
        public string UserCode { get; set; }
        public string DBName { get; set; }
    }
}