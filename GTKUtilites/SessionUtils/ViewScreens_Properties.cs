using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GTKUtilites.SessionUtils
{
    public class ViewScreens_Properties
    {
        private int _iReqTypeId=0;
        public int ReqTypeId
        {
            get { return _iReqTypeId; }
            set { _iReqTypeId = value; }
        }

        private string _RequestType;
        public string RequestType
        {
            get { return _RequestType; }
            set { _RequestType = value; }
        }

        private string _ExtEntityType;
        public string ExtEntityType
        {
            get { return _ExtEntityType; }
            set { _ExtEntityType = value; }
        }

        private string _EntityName;
        public string EntityName
        {
            get { return _EntityName; }
            set { _EntityName = value; }
        }


        private int _iEntityId=0;
        public int EntityId
        {
            get { return _iEntityId; }
            set { _iEntityId = value; }
        }

        private int _iSolReqNo=0;
        public int SolReqNo
        {
            get { return _iSolReqNo; }
            set { _iSolReqNo = value; }
        }

        private int _iSolYear=0;
        public int SolYear
        {
            get { return _iSolYear; }
            set { _iSolYear = value; }
        }

        private string _SolReqDocNo;
        public string SolReqDocNo
        {
            get { return _SolReqDocNo; }
            set { _SolReqDocNo = value; }
        }
        private string _Direction;
        public string Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }
        private string _SolStatus;
        public string SolStatus
        {
            get { return _SolStatus; }
            set { _SolStatus = value; }
        }
        private DateTime _SolDate;
        public DateTime SolDate
        {
            get { return _SolDate; }
            set { _SolDate = value; }
        }
        private DateTime _SolDueDate;
        public DateTime SolDueDate
        {
            get { return _SolDueDate; }
            set { _SolDueDate = value; }
        }
    }
}
