using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
    class InventoryAdjSummaryProp
    {
        private string _iAdjNo;
        public string AdjustmentNo
        {
            get { return _iAdjNo; }
            set { _iAdjNo = value; }
        }
        private string _iDisplayValue;
        public string ReasonCode
        {
            get { return _iDisplayValue; }
            set { _iDisplayValue = value; }
        }
        private string _prt_code;
        public string PartCode
        {
            get { return _prt_code; }
            set { _prt_code = value; }
        }
        private string _iZoneLotNo;
        public string ZoneLotNo
        {
            get { return _iZoneLotNo; }
            set { _iZoneLotNo = value; }
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
