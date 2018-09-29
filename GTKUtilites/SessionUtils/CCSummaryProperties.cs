using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
   public class CCSummaryProperties
    {
        private string _iDescr;
        public string Description
        {
            get { return _iDescr; }
            set { _iDescr = value; }
        }
        private string _iStatus;
        public string Status
        {
            get { return _iStatus; }
            set { _iStatus = value; }
        }
        private string _StorageLvl;
        public string StorageLevel
        {
            get { return _StorageLvl; }
            set { _StorageLvl = value; }
        }
        private string _iLoc;
        public string Location
        {
            get { return _iLoc; }
            set { _iLoc = value; }
        }

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
    }
}
