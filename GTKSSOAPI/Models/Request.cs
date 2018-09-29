using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GTKSSOAPI.Models
{
     
        public class Response
        {

            public Array Data { get; set; }
            public DataTable DtData { get; set; }
            public string screeningsLeft { get; set; }
            public int Count { get; set; }
            public string Errors { get; set; }
            public string data { get; set; }
            public string ID { get; set; }
            public Response(Array data, int count)
            {
                this.Data = data;
                this.Count = count;
            }
            public Response(DataTable data, int count)
            {
                this.DtData = data;
                this.Count = count;
            }

            public Response(string data, int count)
            {
                this.data = data;
                this.Count = count;
            }

            public Response(string errors)
            {
                this.Errors = errors;
            }

            public Response()
            {

            }
            

        }
    public class GtkMstFilterParam
    {
        public string Field { get; set; }
        public string Condition { get; set; }
        public string Value { get; set; }
    }

    public class UnLockUsers
    {
        public string usercode { get; set; }
    }
    public class GtkuserAction
    {
        public string[] usercodes { get; set; }
        public string Usercode { get; set; }
        public string AxnCD { get; set; } 
    }
    public class ChanePwdParams
    {
        public string Usercode { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

}