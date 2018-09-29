using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
    public class CTPATProperties
    {
        #region Properties
        #region TSPRegion

        private int _iRegionId = 0;
        public int RegionId
        {
            get { return _iRegionId; }
            set { _iRegionId = value; }
        }

        private string _RegionCode;
        public string RegionCode
        {
            get { return _RegionCode; }
            set { _RegionCode = value; }
        }


        private string _RegionName;
        public string RegionName
        {
            get { return _RegionName; }
            set { _RegionName = value; }
        }

        #endregion


        #region TSPAssess
        private int _TAssessId = 0;
        public int TAssessId
        {
            get { return _TAssessId; }
            set { _TAssessId = value; }
        }


        private int _pNoteId = 0;
        public int PNoteId
        {
            get { return _pNoteId; }
            set { _pNoteId = value; }
        }

        private string _companyCode;
        public string CompanyCode
        {
            get { return _companyCode; }
            set { _companyCode = value; }
        }
        #endregion

        #region TSPSupplyChain

        private string _SupplyChainName;
        public string SupplyChainName
        {
            get { return _SupplyChainName; }
            set { _SupplyChainName = value; }
        }

        private string _VariantCode;
        public string VariantCode
        {
            get { return _VariantCode; }
            set { _VariantCode = value; }
        }

        private string _VariantIsDefault;
        public string VariantIsDefault
        {
            get { return _VariantIsDefault; }
            set { _VariantIsDefault = value; }
        }

        private int _SupplyChainId;
        public int SupplyChainId
        {
            get { return _SupplyChainId; }
            set { _SupplyChainId = value; }
        }


        private string _TemplateName;
        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }

        private int _TemplateId;
        public int TemplateId
        {
            get { return _TemplateId; }
            set { _TemplateId = value; }
        }



        #endregion


        private string _PtnrType;
        public string PartnerType
        {
            get { return _PtnrType; }
            set { _PtnrType = value.ToUpper(); }
        }

        private string _PtnrCode;
        public string PartnerCode
        {
            get { return _PtnrCode; }
            set { _PtnrCode = value.ToUpper(); }
        }

        private string _Param1;
        public string Param1
        {
            get { return _Param1; }
            set { _Param1 = value.ToUpper(); }
        }
        
        private string _Param2;
        public string Param2
        {
            get { return _Param2; }
            set { _Param2 = value.ToUpper(); }
        }
        
        private string _RequestTypeId;
        public string RequestTypeId
        {
            get { return _RequestTypeId; }
            set { _RequestTypeId = value; }
        }

        private int _RecordsPerPage;
        public int RecordsPerPage
        {
            get { return _RecordsPerPage; }
            set { _RecordsPerPage = value; }
        }
        
        private string _Mode;
        public string Mode
        {
            get { return _Mode; }
            set { _Mode = value.ToUpper(); }
        }

        private int _AssessId;
        public int AssessId
        {
            get { return _AssessId; }
            set { _AssessId = value; }
        }
        private string _APCode;
        public string APCode
        {
            get { return _APCode; }
            set { _APCode = value.ToUpper(); }
        }

        private DateTime _AssessDt;
        public DateTime AssessDate
        {
            get { return _AssessDt; }
            set { _AssessDt = value; }
        }
        #endregion
    }
}
