using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
    public class PropertiesObject
    {
        private string _Param1;
        public string Param1
        {
            get { return _Param1; }
            set { _Param1 = value; }
        }

        private string _Param2;
        public string Param2
        {
            get { return _Param2; }
            set { _Param2 = value; }
        }

        private string _ParamXml = "";
        public string ParamXml
        {
            get { return _ParamXml; }
            set { _ParamXml = value; }
        }
        private string _PQualifier = "";
        public string PQualifier
        {
            get { return _PQualifier; }
            set { _PQualifier = value; }

        }

    }
}
