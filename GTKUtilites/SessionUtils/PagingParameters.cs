using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GTKUtilites.SessionUtils
{
    public class PagingParameters
    {

        //private static List<PagingParameters> _self;

        //private PagingParameters() { }

        //public static List<PagingParameters> obj
        //{
        //    get
        //    {
        //        if (_self == null)
        //        {
        //            _self = new List<PagingParameters>();

        //            for (int i = 0; i < SessionObjects.obj.GlobalPropertiesObject.LOVInputSize; i++)
        //            {
        //                _self.Add(new PagingParameters());
        //            }
        //        }

        //        return _self;
        //    }
        //}


        private string _Mode;
        /// <summary>
        /// used for Paging property
        /// </summary>
        public string Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        private string _Section;
        public string Section
        {
            get { return _Section; }
            set { _Section = value; }
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


        private string _POptions;
        public string POptions
        {
            get { return _POptions; }
            set { _POptions = value; }
        }

        private string _PParams;
        public string PParams
        {
            get { return _PParams; }
            set { _PParams = value; }
        }

        private string _PMode;
        public string PMode
        {
            get { return _PMode; }
            set { _PMode = value; }
        }

        private string _PagingMode = "Q";
        public string PagingMode
        {
            get { return _PagingMode; }
            set { _PagingMode = value; }
        }

        private string _PUser;
        public string PUser
        {
            get { return _PUser; }
            set { _PUser = value; }
        }

        private string _ReturnProperty = "N";
        public string ReturnProperty
        {
            get { return _ReturnProperty; }
            set { _ReturnProperty = value; }
        }
        private string _FilterType;
        public string FilterType
        {
            get { return _FilterType; }
            set { _FilterType = value; }
        }

        private string _EntityPageFilter = "F";
        public string EntityPageFilter
        {
            get { return _EntityPageFilter; }
            set { _EntityPageFilter = value; }
        }
        private string _sFieldValue;
        public string FieldValue
        {
            get { return _sFieldValue; }
            set { _sFieldValue = value;  }
        }

        private int _iFieldNo;
        public int FieldNo
        {
            get { return _iFieldNo; }
            set { _iFieldNo = value;  }
        }
        private int _iEntityCurrentPageNo;
        public int EntityCurrentPageNo
        {
            get { return _iEntityCurrentPageNo; }
            set { _iEntityCurrentPageNo = value; }
        }
        private string _Controlname;
        public string Controlname
        {
            get { return _Controlname; }
            set { _Controlname = value; }
        }
        private int _iCommandTimeout = 30;
        public int CommandExecutionTimeOut
        {
            get { return _iCommandTimeout; }
            set { _iCommandTimeout = value; }
        }

        Dictionary<string, string> _PagingParametersList = new Dictionary<string, string>();
        public Dictionary<string, string> PagingParametersList
        {
            get
            {
                return _PagingParametersList;
            }
            set
            {
                _PagingParametersList = value;
            }
        }


        public void DestroyObject()
        {
            try
            {
                //_self = null;

                SessionObjects.obj.PagingParametersObject = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetQueryTimeOuts(DataTable dtQueryTimeOut)
        {
            if (SessionObjects.obj.PagingParametersObject != null)
            {
                foreach (PagingParameters PP in SessionObjects.obj.PagingParametersObject)
                {
                    DataRow[] dr = dtQueryTimeOut.Select("QType='Paging' and Qualifier='" + PP.POptions + "' and SectionName = '" + PP.Section + "'");
                    if (dr != null && dr.Count() > 0)
                    {
                        string sQryTimeOut = dr[0]["PropValue"].ToString();
                        if (!string.IsNullOrEmpty(sQryTimeOut))
                        {
                            PP.CommandExecutionTimeOut = Convert.ToInt32(sQryTimeOut);
                        }
                    }
                }
            }
        }
    }
}
