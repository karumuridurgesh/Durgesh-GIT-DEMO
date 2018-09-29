using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Security;
using System.Web.UI.WebControls;
using GTKUtilites.DataAccessLayer;

namespace GTKUtilites.SessionUtils
{
    public class FilterProperties
    {
        private string _InputType;
        public string InputType
        {
            get { return _InputType; }
            set { _InputType = value; }
        }

        private string _FilterId;
        public string FilterId
        {
            get { return _FilterId; }
            set { _FilterId = value; }
        }

        private string _ListCode;
        public string ListCode
        {
            get { return _ListCode; }
            set { _ListCode = value; }
        }

        private string _FieldName;
        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }

        private string _SectionName;
        public string SectionName
        {
            get { return _SectionName; }
            set { _SectionName = value; }
        }



        private DataTable _dtFilters;
        public DataTable dtFilters
        {
            get { return _dtFilters; }
            set { _dtFilters = value; }
        }


        private DataTable _dtListValues;
        public DataTable dtListValues
        {
            get { return _dtListValues; }
            set { _dtListValues = value; }
        }

        private DataTable _dtFilterCaptions;
        public DataTable dtFilterCaptions
        {
            get { return _dtFilterCaptions; }
            set { _dtFilterCaptions = value; }
        }

        private DataTable _dtFilterShowValues;
        public DataTable dtFilterShowValues
        {
            get { return _dtFilterShowValues; }
            set { _dtFilterShowValues = value; }
        }


        public void BindFilterShownValues()
        {
            try
            {
                if (dtFilters != null && dtFilters.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtFilters, "IsDefault = 'Y'", "FilterSeqNo", DataViewRowState.OriginalRows);

                    dtFilterShowValues = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindSearchFilters()
        {
            try
            {
                if (dtFilters != null && dtFilters.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtFilters, "IsDefault = 'N'", "FilterSeqNo", DataViewRowState.OriginalRows);

                    foreach (DataRow dr in dv.ToTable().Rows)
                    {
                        DataRow drFSV = dtFilterShowValues.NewRow();
                        drFSV.ItemArray = dr.ItemArray;

                        dtFilterShowValues.Rows.Add(drFSV);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetFilterDetailsByFieldName()
        {
            try
            {
                if (dtFilters != null && dtFilters.Rows.Count > 0)
                {
                    DataRow[] drs = dtFilters.Select("Caption ='" + FieldName + "'");

                    return GetJSONFormat(drs, new string[] { "InputType", "Condition", "DefaultValue1", "DefaultValue2", "Show", "IsReadOnly", "FilterId", "FilterSeqNo", "SeqNo", "ListCode", "IsDefault", "Caption", "IsValidate", "ForceCondition", "IsMandatory" });
                }
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetFilterValuesByFieldName()
        {
            try
            {
                if (dtListValues != null && dtListValues.Rows.Count > 0)
                {
                    DataRow[] drs = dtListValues.Select("SectionName='Filter' and FieldName ='" + FieldName + "'");

                    return GetJSONFormat(drs, new string[] { "DisplayValue", "StoredValue" });
                }
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private string GetJSONFormat(DataRow[] drs, string[] ColumnNames)
        {
            try
            {
                StringBuilder strFilter = new StringBuilder();

                strFilter.Append("[");
                strFilter.AppendLine();

                int rowCount = 0;
                foreach (DataRow dr in drs)
                {
                    strFilter.Append("{");
                    int columnCount = 0;
                    foreach (string Column in ColumnNames)
                    {
                        strFilter.Append("\"" + Column + "\":\"" + dr[Column] + "\"");

                        if (columnCount != (ColumnNames.Count() - 1))
                        {
                            strFilter.Append(",");
                        }

                        columnCount++;
                    }
                    strFilter.Append("}");

                    // strFilter.Append("{ \"DisplayValue\":\"" + dr["DisplayValue"] + "\", \"StoredValue\":\"" + dr["StoredValue"] + "\"}");

                    if (rowCount != (drs.Count() - 1))
                    {
                        strFilter.Append(",");
                        strFilter.AppendLine();
                    }


                    rowCount++;
                }

                strFilter.AppendLine();
                strFilter.Append("]");

                return strFilter.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateFilterXML(bool IsRootNodeRequired)
        {
            try
            {
                StringBuilder strXML = new StringBuilder();

                bool sContinue = true;
                strXML.AppendLine("<Root>");
                strXML.AppendLine("<Filters>");
                foreach (DataRow dr in dtFilterShowValues.Rows)
                {
                    strXML.Append("<Filter ");

                    foreach (DataColumn dc in dtFilterShowValues.Columns)
                    {

                        if (dr[dc].ToString() != "" && dr[dc].ToString().Trim() != string.Empty && dr[dc].ToString() != "--Select--")
                                strXML.Append(dc.ColumnName + " = \"" + SecurityElement.Escape(dr[dc].ToString()) + "\" ");
                       
                    }

                    strXML.Append(" > </Filter>");

                    strXML.AppendLine();
                }


                strXML.AppendLine("</Filters>");
                strXML.AppendLine("</Root>");


                return strXML.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void BindFilterCaptions(DropDownList ddl)
        {
            try
            {
                if (dtFilterCaptions != null && dtFilterCaptions.Rows.Count > 0)
                {
                    ddl.DataSource = dtFilterCaptions;
                    ddl.DataTextField = "Caption";
                    ddl.DataValueField = "Caption";
                    ddl.DataBind();

                    ddl.Items.Insert(0, new ListItem("--Select--", "Select"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindFilterOperators(DropDownList ddl)
        {
            try
            {
                ddl.Items.Clear();

                //ddl.Items.Add(new ListItem("Equals", "="));

                //ddl.Items.Add(new ListItem("GreaterThanOrEqualTo", ">="));

                //ddl.Items.Add(new ListItem("LessThanOrEqualTo", "<="));

                //ddl.Items.Add(new ListItem("Between", ">= and <="));

                //ddl.Items.Add(new ListItem("IsGreaterThan", ">"));

                //ddl.Items.Add(new ListItem("IsLessthan", "<"));

                //ddl.Items.Add(new ListItem("NotEqualTo", "!="));
                //ddl.Items.Add(new ListItem("IsEmpty", "IS NULL"));
                //ddl.Items.Add(new ListItem("IsNotEmpty", "IS NOT NULL"));
                UtilityDAL obj = new UtilityDAL();
                DataSet ds = new DataSet();
                ds = obj.GetFilterConditions();
                if (ds.Tables.Count > 0)
                {
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataTextField = ds.Tables[0].Columns["CondText"].ToString();
                    ddl.DataValueField = ds.Tables[0].Columns["CondSymbol"].ToString();
                    ddl.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet BindFilterOperators()
        {
            try
            {
                UtilityDAL obj = new UtilityDAL();
                DataSet ds = new DataSet();
                ds = obj.GetFilterConditions();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindFilterDropDownValues(DropDownList ddl, string sFieldName)
        {
            try
            {

                if (dtListValues != null && dtListValues.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtListValues, "SectionName='Filter' and FieldName ='" + sFieldName + "'", "ListSortSeq", DataViewRowState.OriginalRows);

                    ddl.DataSource = dv.ToTable();
                    ddl.DataTextField = "DisplayValue";
                    ddl.DataValueField = "StoredValue";
                    ddl.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region Enums
        public enum InputTypeCodes
        {
            DT = 1,
            H,
            L,
            LOV,
            MLOV,
            U,
            B,
            DTM
        }

        public class FilterOperators
        {
            public const string Equals = "=";
            public const string GreaterThanOrEqualTo = ">=";
            public const string LessThanOrEqualTo = "<=";
            //public const string Between = "between";
            public const string Between = ">= and <=";
            public const string BetweenText = "between";
            public const string GTETAndLTET = ">= and <=";
            public const string GreaterThan = ">";
            public const string LessThan = "<";
        }

        #endregion


    }
}
