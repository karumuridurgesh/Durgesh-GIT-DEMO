using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GTKUtilites.SessionUtils
{
    public class ADHRepProperties
    {
        private string _Mode;
        /// <summary>
        /// used for Paging property
        /// </summary>
        public string Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
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


        private string _ADHREPCode;
        public string ADHREPCode
        {
            get { return _ADHREPCode; }
            set { _ADHREPCode = value; }
        }

        private string _ADHREPName;
        public string ADHREPName
        {
            get { return _ADHREPName; }
            set { _ADHREPName = value; }
        }

        private string _PParams;
        public string PParams
        {
            get { return _PParams; }
            set { _PParams = value; }
        }

        private string _FParams;
        public string FParams
        {
            get { return _FParams; }
            set { _FParams = value; }
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

        private string _ReturnAllData = "N";
        public string ReturnAllData
        {
            get { return _ReturnAllData; }
            set { _ReturnAllData = value; }
        }


        private string _RptOutPut;
        public string ReportOutput
        {
            get { return _RptOutPut; }
            set { _RptOutPut = value; }
        }
        private string _BatchSize;
        public string BatchSize
        {
            get { return _BatchSize; }
            set { _BatchSize = value; }
        }
        private DataTable _dtGridData = new DataTable();
        public DataTable GridData
        {
            get { return _dtGridData; }
            set { _dtGridData = value; }
        }
        private DataTable _dtGridPropertyData = new DataTable();
        public DataTable GridPropertyData
        {
            get { return _dtGridPropertyData; }
            set { _dtGridPropertyData = value; }
        }

        private DataTable _dtGrpData = new DataTable();
        public DataTable GrpData
        {
            get { return _dtGrpData; }
            set { _dtGrpData = value; }
        }


        private DataTable _dtFilterData = new DataTable();
        public DataTable FilterData
        {
            get { return _dtFilterData; }
            set { _dtFilterData = value; }
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

        private StringBuilder _sFiltersPreview;
        public StringBuilder sFiltersPreview
        {
            get { return _sFiltersPreview; }
            set { _sFiltersPreview = value; }
        }

        Dictionary<string, string> _FiltersApplied = new Dictionary<string, string>();
        public Dictionary<string, string> FiltersApplied
        {
            get
            {
                return _FiltersApplied;
            }
            set
            {
                _FiltersApplied = value;
            }
        }

        public void DestroyObject()
        {
            try
            {
                //_self = null;

               SessionObjects.obj.ADHRepPropertiesObject = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
