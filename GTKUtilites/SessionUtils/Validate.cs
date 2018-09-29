using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security;
using System.Web.UI.WebControls;

namespace GTKUtilites.SessionUtils
{
    public class Validate
    {
        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private string _ColumnName;
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }
        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _ReturnColumnName;
        public string ReturnColumnName
        {
            get { return _ReturnColumnName; }
            set { _ReturnColumnName = value; }
        }
        private int _ReturnColumnValue;
        public int ReturnColumnValue
        {
            get { return _ReturnColumnValue; }
            set { _ReturnColumnValue = value; }
        }
    }
}
