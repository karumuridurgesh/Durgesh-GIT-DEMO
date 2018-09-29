using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKUtilites.InterfaceLayer;
using GTKUtilites.HelpMethods;

namespace GTKUtilites.BusinessObjects
{
    public class GtkTxnDocStatus : IGTK<GtkTxnDocStatus>
    {
        public string StatusId { get; set; } //1
        public string EntityId { get; set; } //2
        public string TxnId { get; set; } //3
        public string StatusTypeId { get; set; } //4
        public string StatusCd { get; set; } //5
        public string StDtm { get; set; } //6
        public string StRef { get; set; } //7
        public string StComment { get; set; } //8
        public string CreatedBy { get; set; } //9
        public string CreatedDate { get; set; } //10
        public string ModifiedBy { get; set; } //11
        public string ModifiedDate { get; set; } //12

        #region IGTK<GtkTxnDocStatus> Members

        public string ParentNode
        {
            get { return "GtkTxnDocStatuss"; }
        }

        public string ChildNode
        {
            get { return "GtkTxnDocStatus"; }
        }

        public GtkTxnDocStatus GetNewRow()
        {
            throw new NotImplementedException();
        }

        public List<GtkTxnDocStatus> GetDetails(System.Data.DataTable dtDetails)
        {
            throw new NotImplementedException();
        }

        public void RemoveDetails(ref GtkTxnDocStatus type)
        {
            throw new NotImplementedException();
        }

        public string PrepareSaveXml(List<GtkTxnDocStatus> liValues)
        {
            return PrepareXML.GetXml<GtkTxnDocStatus>(liValues, ParentNode, ChildNode);
        }

        #endregion
    }
}
