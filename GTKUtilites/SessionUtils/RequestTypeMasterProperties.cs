using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GTKUtilites.SessionUtils
{
    public class RequestTypeMasterProperties
    {
        //private static RequestTypeMasterProperties _self = new RequestTypeMasterProperties();

        //public static RequestTypeMasterProperties obj
        //{
        //    get
        //    {
        //        return _self;
        //    }
        //}

        private string _sMode;
        private string _sAccessMode;
        private int _iReqTypeId;
        private string _iReqTypeName;
        private int _iPrimaryEntityId;
        private string _sReqType;
        private string _sDocTemplateName;
        private int _iDocTemplateId;
        private bool _bUseEntityInformation;
        private bool _bUseQuestions;
        private bool _bUseQuestionBank;
        private int _iThreadId;
        private int _iSectionId=0;
        private int _iRecordsPerPage;


        private DataSet _dsLeftNavigationLinks;
        private DataTable _dtDropdownsData;

        public string AccessMode
        {
            get { return _sAccessMode; }
            set { _sAccessMode = value; }
        }
        public string RequestMode
        {
            get { return _sMode; }
            set { _sMode = value; }
        }
        public int ReqTypeId
        {
            get { return _iReqTypeId; }
            set { _iReqTypeId = value; }
        }
        public int PrimaryEntityId
        {
            get { return _iPrimaryEntityId; }
            set { _iPrimaryEntityId = value; }
        }
        public string ReqTypeName
        {
            get { return _iReqTypeName; }
            set { _iReqTypeName = value; }
        }
        public int ThreadId
        {
            get { return _iThreadId; }
            set { _iThreadId = value; }
        }
        public int SectionId
        {
            get { return _iSectionId; }
            set { _iSectionId = value; }
        }
        public int RecordsPerPage
        {
            get { return _iRecordsPerPage; }
            set { _iRecordsPerPage = value; }
        }
        public string ReqType
        {
            get { return _sReqType; }
            set { _sReqType = value; }
        }

        private string _Section;
        public string Section
        {
            get { return _Section; }
            set { _Section = value; }
        }

        private string _Param2;
        public string Param2
        {
            get { return _Param2; }
            set { _Param2 = value; }
        }

        public string DocTemplateName
        {
            get { return _sDocTemplateName; }
            set { _sDocTemplateName = value; }
        }

        public int DocTemplateId
        {
            get { return _iDocTemplateId; }
            set { _iDocTemplateId = value; }
        }

        public bool UseEnityInformation
        {
            get { return _bUseEntityInformation; }
            set { _bUseEntityInformation = value; }
        }

        public bool UseQuestions
        {
            get { return _bUseQuestions; }
            set { _bUseQuestions = value; }
        }

        public bool UseQuestionBank
        {
            get { return _bUseQuestionBank; }
            set { _bUseQuestionBank = value; }
        }

        public DataSet LeftNavigationLinks
        {
            get { return _dsLeftNavigationLinks; }
            set
            {
                _dsLeftNavigationLinks = value;

                if (_dsLeftNavigationLinks != null)
                {
                    if (_dsLeftNavigationLinks.Tables.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow dr in _dsLeftNavigationLinks.Tables[0].Rows)
                        {
                            if (i != _dsLeftNavigationLinks.Tables.Count)
                                _dsLeftNavigationLinks.Tables[i].TableName = dr["TableName"].ToString();

                            i++;
                        }
                    }
                }

            }
        }

        public DataTable GetLeftSideMenuData(MenuType MenuType)
        {
            if (SessionObjects.obj.RequestTypeMasterPropertiesObject.LeftNavigationLinks != null)
            {
                return SessionObjects.obj.RequestTypeMasterPropertiesObject.LeftNavigationLinks.Tables[MenuType.ToString()];
            }
            else
                return null;

        }

        public DataTable GetStepWiseActions(Param1 sMode)
        {
            return SessionObjects.obj.RequestTypeMasterPropertiesObject.LeftNavigationLinks.Tables["Action"];
        }

        public DataTable DropDownData
        {
            get { return _dtDropdownsData; }
            set { _dtDropdownsData = value; }
        }

        public DataTable BindDropDown(string sSectionName, string sFieldName, Qualifier sQualifier)
        {
            try
            {
                DataView dvDropdown = new DataView(DropDownData, "SectionName = '" + sSectionName + "' and FieldName = '" + sFieldName + "' and Qualifier = '" + sQualifier.ToString() + "'", "SeqNo", DataViewRowState.OriginalRows);

                return dvDropdown.ToTable();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataSet _dsNQ;
        public DataSet DataSetNQ
        {
            get { return _dsNQ; }
            set
            {

                _dsNQ = value;
            }
        }
        private DataSet _dsNQT;
        public DataSet DataSetNQT
        {
            get { return _dsNQT; }
            set
            {

                _dsNQT = value;
            }
        }


        private string _tvXML;
        public string TreeViewXML
        {
            get { return _tvXML; }
            set { _tvXML = value; }
        }



        public enum Param1
        {
            ReqMaster = 1,
            Step1,
            Step2,
            Step3,
            Step4,
            Step5,
            Step5NQT,
            Step6,
            Step7,
            QBMST,
            QSTMST,
            QTHMST
        }

        public enum MenuType
        {
            QuestionBank = 1,
            Entity,
            Content,
            Section,
            Action,
            Menu
        }

        public enum Qualifier
        {
            Step1 = 1,
            Step2,
            Step3,
            Step4,
            Step5
        }

        public enum RTypeSectionNames
        {
            Attribute = 1,
            Content,
            NewQuestion,
            NewQuestionThread,
            QuestionBank,
            SectionView,
            Step2,
            Step4,
        }

        public enum RTypeFieldNames
        {
            ContentSource = 1,
            Default,
            NumberSequence,
            QuestionType,
            QuestionorThread,
            TextContentType,
            TypeofContent,

        }

        public class SectionName
        {
            public const string Attribute = "Attribute";
            public const string Content = "Content";
            public const string NewQuestion = "New Question";
            public const string NewQuestionThread = "New Question Thread";
            public const string QuestionBank = "Question Bank";
            public const string SectionView = "Section View";
            public const string Step2 = "Step2";
            public const string Step4 = "Step4";
            public const string RequestType = "RequestType";
            public const string Step3 = "Step3";
        }

        public class FieldName
        {
            public const string ContentSource = "Content Source";
            public const string Default = "Default";
            public const string NumberSequence = "NumberSequence";
            public const string QuestionType = "Question Type";
            public const string QuestionorThread = "Question/Thread";
            public const string TextContentType = "Text Content Type";
            public const string TypeofContent = "Type of Content";
            public const string EntityType = "EntityType";
            public const string RequestLevel = "RequestLevel";
            public const string PrimaryEntity = "PrimaryEntity";
            public const string SectionContentType = "Section Content Type";
        }


    }
}
