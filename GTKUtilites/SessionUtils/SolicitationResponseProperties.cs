using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace GTKUtilites.SessionUtils
{
    public class SolicitationResponseProperties
    {

        #region Properties
        private int _iReqTypeId;
        public int ReqTypeId
        {
            get { return _iReqTypeId; }
            set { _iReqTypeId = value; }
        }

        private int _iSectionId = 0;
        public int SectionId
        {
            get { return _iSectionId; }
            set { _iSectionId = value; }
        }

        private int _iNextSectionId = 0;
        public int NextSectionId
        {
            get { return _iNextSectionId; }
            set { _iNextSectionId = value; }
        }

        private string _QShortName;
        public string QuestionName
        {
            get { return _QShortName; }
            set { _QShortName = value; }
        }

        private int _iSolreqHdrNo = 0;
        public int SolreqHdrNo
        {
            get { return _iSolreqHdrNo; }
            set { _iSolreqHdrNo = value; }
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

        private int _iQuestionId = 0;
        public int QuestionId
        {
            get { return _iQuestionId; }
            set { _iQuestionId = value; }
        }

        private string _Qtype = "";
        public string QType
        {
            get { return _Qtype; }
            set { _Qtype = value; }
        }
        private string _IsReadOnly = "";
        public string IsReadOnly
        {
            get { return _IsReadOnly; }
            set
            {
                _IsReadOnly = value;
               
            }
        }

        private string _IsMandatory = "";
        public string IsMandatory
        {
            get { return _IsMandatory; }
            set
            {
                _IsMandatory = value;
               
            }
        }


        private string _QViewType = "";
        public string QViewType
        {
            get { return _QViewType; }
            set { _QViewType = value; }
        }

        private DataTable dtResponseMetadata = new DataTable();
        public DataTable ResponseMetaData
        {
            get { return dtResponseMetadata; }
            set { dtResponseMetadata = value; }
        }

        private DataTable dtResponses = new DataTable();
        public DataTable Responses
        {
            get { return dtResponses; }
            set { dtResponses = value; }
        }
        private DataTable dtMarkedResponses = new DataTable();
        public DataTable MarkedResponses
        {
            get { return dtMarkedResponses; }
            set { dtMarkedResponses = value; }
        }
        private DataTable dtQuestions = new DataTable();
        public DataTable Questions
        {
            get { return dtQuestions; }
            set { dtQuestions = value; }
        }
        private DataTable dtAllQuestions = new DataTable();
        public DataTable AllQuestions
        {
            get { return dtAllQuestions; }
            set { dtAllQuestions = value; }
        }
        private DataTable dtAllResponses = new DataTable();
        public DataTable AllResponses
        {
            get { return dtAllResponses; }
            set { dtAllResponses = value; }
        }
        private DataTable dtQR = new DataTable();
        public DataTable QuestResp
        {
            get { return dtQR; }
            set { dtQR = value; }
        }

        private int _iSeqNo = 0;
        public int QuestSeqNo
        {
            get { return _iSeqNo; }
            set { _iSeqNo = value; }
        }

        private string _SolicitationDocNumber;
        public string SolicitationDocNumber
        {
            get { return _SolicitationDocNumber; }
            set { _SolicitationDocNumber = value; }
        }
      

        private string _OldSolReqDocNo;
        public string OldSolReqDocNo
        {
            get { return _OldSolReqDocNo; }
            set { _OldSolReqDocNo = value; }
        }

        private string _OldSolreqHdrNo;
        public string OldSolreqHdrNo
        {
            get { return _OldSolreqHdrNo; }
            set { _OldSolreqHdrNo = value; }
        }

        private string _EntityType;
        public string EntityType
        {
            get { return _EntityType; }
            set { _EntityType = value; }
        }

        private string _Supplier;
        public string Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        private string _direction;
        public string Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        private string _RequestType;
        public string RequestType
        {
            get { return _RequestType; }
            set { _RequestType = value; }
        }

        private string _RequestLevel;
        public string RequestLevel
        {
            get { return _RequestLevel; }
            set { _RequestLevel = value; }
        }


        private string _SectionType;
        public string SectionType
        {
            get { return _SectionType; }
            set { _SectionType = value; }
        }


        private int _PartKeyNo=0;
        public int PartKeyNo
        {
            get { return _PartKeyNo; }
            set { _PartKeyNo = value; }
        }


        private int _totalGridFields = 0;
        public int TotalGridFields
        {
            get { return _totalGridFields; }
            set { _totalGridFields = value; }
        }

        private int _totalEnteredGridFields = 0;
        public int TotalEnteredGridFields
        {
            get { return _totalEnteredGridFields; }
            set { _totalEnteredGridFields = value; }
        }

       

        #endregion

        #region Classes
        public class QuestionType
        {
            public const string Option = "OPT";
            public const string MultiSelect = "MULTISEL";
            public const string ShortText = "SHTXT";
            public const string MultiLineText = "LONGTXT";
            public const string YesNo = "YESNO";
            public const string YesNoNA = "YESNONA";
            public const string Date = "Date";

        }
        #endregion
    }
}
