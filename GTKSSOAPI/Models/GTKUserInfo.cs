using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTKSSOAPI.Models
{
    public class GTKUserInfo
    {
        public Int64 Access_Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserMidName { get; set; }
        public string UserLastName { get; set; }
        public string UserCode { get; set; }
        public string UserEmail { get; set; }
        public int UserType { get; set; }
        public byte UserPwd { get; set; } 
        public byte EncryptUserPwd { get; set; } 
        public string UserTheme { get; set; }
        public int UserIsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public string UserActive { get; set; }
        public Int64 UserID { get; set; }
        public string CreatedDt { get; set; }
    }
    public class UserParams
    {
        private Filter _filter;
        public Filter filter
        {
            get { return _filter; }
            set { _filter = value; }
        }
        public string UserCode { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
    public class Filter
    {
        private List<Filter2> _filters = new List<Filter2>();
        public List<Filter2> filters { get; set; }
    }

    public class Filter2
    {
        public string field { get; set; }
        public string @operator { get; set; }
        public string value { get; set; }
        public string value2 { get; set; }
    }
    public class GTKSSOUserAxn
    {
        public Int64 AxnId { get; set; }
        public Int64 MenuId { get; set; }
        public string AxnCd { get; set; }
        public string AxnTxt { get; set; }
        public int Show { get; set; }
        public int SeqNo { get; set; }
    }
    public class Usermenu
    { 
        public string MenuId { get; set; }
        
    }
}