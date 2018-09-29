using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
    public class ViewInventiryProperties
    {
        private string _iCmpny;
        public string Company
        {
            get { return _iCmpny; }
            set { _iCmpny = value; }
        }
        private string _iZnId;
        public string ZoneId
        {
            get { return _iZnId; }
            set { _iZnId = value; }
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

        private string _iPartCat;
        public string PartCategory
        {
            get { return _iPartCat; }
            set { _iPartCat = value; }
        }
        private string _iPart;
        public string Part
        {
            get { return _iPart; }
            set { _iPart = value; }
        }
        private string _iZnLotNo;
        public string ZoneLotNo
        {
            get { return _iZnLotNo; }
            set { _iZnLotNo = value; }
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
