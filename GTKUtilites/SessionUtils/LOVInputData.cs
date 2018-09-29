using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;

namespace GTKUtilites.SessionUtils
{
    public class LOVInputData
    {

        //private static List<LOVInputData> _self;

        //private LOVInputData() { }

        //public static List<LOVInputData> obj
        //{
        //    get
        //    {
        //        if (_self == null)
        //        {
        //            _self = new List<LOVInputData>();

        //            for (int i = 0; i < SessionObjects.obj.GlobalPropertiesObject.LOVInputSize; i++)
        //            {
        //                _self.Add(new LOVInputData());
        //            }
        //        }

        //        return _self;
        //    }
        //}


        private string _UnId;
        public string UnId
        {
            get { return _UnId; }
            set { _UnId = value; }
        }

        private string _Mode;
        public string Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        private string _FteCode;
        public string FteCode
        {
            get { return _FteCode; }
            set { _FteCode = value; }
        }

        private string _Section;
        public string Section
        {
            get { return _Section; }
            set { _Section = value; }
        }

        private string _Field;
        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        private int _RecordsPerPage;
        public int RecordsPerPage
        {
            get { return _RecordsPerPage; }
            set { _RecordsPerPage = value; }
        }

        private int _PAGENUMBER;
        public int PAGENUMBER
        {
            get { return _PAGENUMBER; }
            set { _PAGENUMBER = value; }
        }

        private string _LOVOptions;
        public string LOVOptions
        {
            get { return _LOVOptions; }
            set { _LOVOptions = value; }
        }

        private int _TotRecords;
        public int TotRecords
        {
            get { return _TotRecords; }
            set { _TotRecords = value; }
        }

        private int _TotPages;
        public int TotPages
        {
            get { return _TotPages; }
            set { _TotPages = value; }
        }

        private string _LOVInputs;
        public string LOVInputs
        {
            get { return _LOVInputs; }
            set { _LOVInputs = value; }


        }

        Dictionary<string, string> _PopupParametersList = new Dictionary<string, string>();
        public Dictionary<string, string> PopupParametersList
        {
            get
            {
                return _PopupParametersList;
            }
            set
            {
                _PopupParametersList = value;
            }
        }

        Dictionary<string, string> _PopupFiltersList = new Dictionary<string, string>();
        public Dictionary<string, string> PopupFiltersList
        {
            get
            {
                return _PopupFiltersList;
            }
            set
            {
                _PopupFiltersList = value;
            }
        }

        public void DestroyObject()
        {
            try
            {
                //_self = null;
                SessionObjects.obj.LOVInputDataObject = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string _selectedValues;
        public string SelectedValues
        {
            get
            {
                return _selectedValues;
            }
            set
            {
                _selectedValues = value;
            }
        }

    }
}
