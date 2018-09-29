using System;
using System.Text;
using System.Data;
using GTKUtilites.DataAccessLayer;

namespace GTKUtilites.SessionUtils
{
    public class GlobalProperties
    {
        //private static GlobalProperties _self = new GlobalProperties();

        //public static GlobalProperties obj
        //{
        //    get
        //    {
        //        return _self;
        //    }
        //}


        private string _FteCode;
        public string FteCode
        {
            get { return _FteCode; }
            set { _FteCode = value; }
        }
        public string ExactFteCode { get; set; }
        private string _UserCode;
        public string UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value.ToUpper(); }
        }

        // Added by siva for ModuleCode
        private string _ModCode;
        public string ModCode
        {
            get { return _ModCode; }
            set { _ModCode = value; }
        }
        //end

        private string _UnId;
        public string UnId
        {
            get { return _UnId; }
            set { _UnId = value; }
        }

        // List length for LovInputData class
        private int _LOVInputSize = 5;
        public int LOVInputSize
        {
            get { return _LOVInputSize; }
            set { _LOVInputSize = value; }
        }

        // Current LovInputData class index
        private int _LOVIndex;
        public int LOVIndex
        {
            get { return _LOVIndex; }
            set { _LOVIndex = value; }
        }
        private string _LevelCode;
        public string LevelCode
        {
            get { return _LevelCode; }
            set { _LevelCode = value.ToUpper(); }
        }


        // List length for Paging Parmeter class
        private int _PagingInputSize = 5;
        public int PagingInputSize
        {
            get { return _PagingInputSize; }
            set { _PagingInputSize = value; }
        }

        //Current Paging Parameter index.
        private int _PagingIndex;
        public int PagingIndex
        {
            get { return _PagingIndex; }
            set { _PagingIndex = value; }
        }


        private string _SingleSelectGridCommandArgument;
        public string SingleSelectGridCommandArgument
        {
            get { return _SingleSelectGridCommandArgument; }
            set { _SingleSelectGridCommandArgument = value; }
        }
        private DateTime? _CurrentDate = null;
        public DateTime? CurrentDate
        {
            get { return _CurrentDate; }
            set { _CurrentDate = value; }
        }

        private int _CSESearchCount;
        public int CSESearchCount
        {
            get { return _CSESearchCount; }
            set { _CSESearchCount = value; }
        }

        /* ADH Report */
        private int _ADHREPInputSize = 5;
        public int ADHRepInputSize
        {
            get { return _ADHREPInputSize; }
            set { _ADHREPInputSize = value; }
        }

        //Current Paging Parameter index.
        private int _ADHREPIndex;
        public int ADHREPIndex
        {
            get { return _ADHREPIndex; }
            set { _ADHREPIndex = value; }
        }
        /* End */

        // List length for Paging Parmeter class
        private int _RPTInputSize = 5;
        public int RPTInputSize
        {
            get { return _RPTInputSize; }
            set { _RPTInputSize = value; }
        }


        //Current RPT Parameter index.
        private int _RPTIndex;
        public int RPTIndex
        {
            get { return _RPTIndex; }
            set { _RPTIndex = value; }
        }

        public class Mode
        {
            public const string Create = "C";
            public const string Update = "U";
            public const string Delete = "D";
            public const string Open = "O";
            public const string Assign = "A";
            public const string Remove = "R";
            public const string Finalize = "F";
        }


        public enum ValidationType
        {
            EXISTS = 1,
            UNIQUE,
            COUNT,

        }


        public void AssignTableNames(DataSet ds)
        {
            try
            {
                if (ds.Tables.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (i != ds.Tables.Count)
                            ds.Tables[i].TableName = dr["TableName"].ToString();

                        i++;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public string GetSPCall(IDbDataParameter[] dbManagerParameters, string SpName)
        {
            try
            {
                StringBuilder spCall = new StringBuilder();

                spCall.Append("Exec " + SpName + " ");

                foreach (IDbDataParameter idbp in dbManagerParameters)
                {
                    if (idbp.Value != DBNull.Value)
                        spCall.Append("'" + idbp.Value + "',");
                    else
                        spCall.Append("null,");
                }

                return spCall.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
