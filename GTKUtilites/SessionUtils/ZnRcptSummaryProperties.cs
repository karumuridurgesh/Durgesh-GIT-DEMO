using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
    public class ZnRcptSummaryProperties
    {
        private string _TranDt;
        public string TranDate
        {
            get { return _TranDt; }
            set { _TranDt = value; }
        }
        private string _TranType;
        public string TranType
        {
            get { return _TranType; }
            set { _TranType = value; }
        }
        private string _TranStatus;
        public string TranStatus
        {
            get { return _TranStatus; }
            set { _TranStatus = value; }
        }
        private string _TranLvl;
        public string TranLevel
        {
            get { return _TranLvl; }
            set { _TranLvl = value; }
        }

        private string _DocType;
        public string DocType
        {
            get { return _DocType; }
            set { _DocType = value; }
        }
        private string _DocId;
        public string DocID
        {
            get { return _DocId; }
            set { _DocId = value; }
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
