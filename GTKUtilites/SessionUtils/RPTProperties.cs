using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
    public class RPTProperties
    {

        private string _UnId;
        public string UnId
        {
            get { return _UnId; }
            set { _UnId = value; }
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

        private string _RPTQualifier;
        public string RPTQualifier
        {
            get { return _RPTQualifier; }
            set { _RPTQualifier = value; }
        }


        private string _PParams;
        public string PParams
        {
            get { return _PParams; }
            set { _PParams = value; }


        }

        private string _RPTFileName;
        public string RPTFileName
        {
            get { return _RPTFileName; }
            set { _RPTFileName = value; }


        }


        private string _RPTName;
        public string RPTName
        {
            get { return _RPTName; }
            set { _RPTName = value; }
        }




        Dictionary<string, string> _ReportParametersList = new Dictionary<string, string>();
        public Dictionary<string, string> ReportParametersList
        {
            get
            {
                return _ReportParametersList;
            }
            set
            {
                _ReportParametersList = value;
            }
        }

        public void DestroyObject()
        {
            try
            {
                //_self = null;
                SessionObjects.obj.RPTPropertiesObject = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
