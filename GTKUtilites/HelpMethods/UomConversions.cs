using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Web;
using System.Data;
using GTKUtilites.DataAccessLayer;
using System.Configuration;
using GTKUtilites.SessionUtils;

namespace GTKUtilites.HelpMethods
{
    /// <summary>
    /// Created Date: 09-July-2015
    /// Author: Krishna
    /// Description: Class UomConversions used to convert the values from one UOM to another UOM.
    /// Example: If Invoice UOM is NO or PCS or EA and HTS UOM is DOZ then we should not multiple Invoiceqty * qty factor.
    /// Instead we should divide qty/12. This class will handle these kind of conversions.
    /// Now this will handle only above mentioned scenario.
    /// Need to extend this to work with other scenarios.
    /// Usage: ConvertedValue("PCS", "DOZ", 10, 10, "KG")
    /// </summary>
    public class UomConversions
    {
        //Default constructor for class
        public UomConversions(string FrUOM1, string ToUOM1, double FrQty1, double ValFct1, double WT1, string WTUOM1)
        {
            FrUOM = FrUOM1;
            ToUOM = ToUOM1;
            FrQty = FrQty1;
            ValFct = ValFct1;
            WT = WT1;
            WTUOM = WTUOM1;
        }

        public static string xmlUrl { get; set; }   //To save the url of the xml file
        public static int count = 0;

        //Private properties to get and set the values
        private static string FrUOM { get; set; }   //From UOM
        private static string ToUOM { get; set; }   //To UOM
        private static double FrQty { get; set; }   //From Quantity
        private static double ValFct { get; set; }   //Value Factor
        private static double WT { get; set; }      //Weight
        private static string WTUOM { get; set; }   //Weight UOM
        private static double CnvQty { get; set; }  //Converted Quantity
              
        //Private static variables to hold the values for the UOM
        private static double DOZ { get; set; }
        private static double PR { get; set; }
        private static double NO { get; set; }
        private static double EA { get; set; }
        private static double PCS { get; set; }
        private static double DPR { get; set; }
        private static double KG { get; set; }
        private static double LBS { get; set; }

        //This method will return the converted value by comparing the UOMs from XML File.
        public static double ConvertedValue(string FrUOM, string ToUOM, double FrQty, double ValFct, double WT, string WTUOM)
        {
            try
            {
                //Asign values to properties
                UomConversions cls = new UomConversions(FrUOM, ToUOM, FrQty, ValFct, WT, WTUOM);                
                if (count == 0)
                {
                    xmlUrl = HttpContext.Current.Server.MapPath(@"~\UILayer\Documents\FTZ\XmlFiles\UOMConversion.xml");
                    ParseByXMLDocument();   //calling static method from static contructor to load the xml only once.
                    count = 1;
                }

                //Check the invoice UOM with HTS UOM, If Invoice UOM is NO or PCS or EA and HTS UOM is DOZ then divide qty/12 and return the value
                if ((FrUOM == "NO" || FrUOM == "PCS" || FrUOM == "EA") == (ToUOM == "DOZ"))
                    UomConversions.CnvQty = UomConversions.FrQty / UomConversions.DOZ;
                else
                    UomConversions.CnvQty = UomConversions.FrQty * UomConversions.ValFct;

                return UomConversions.CnvQty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //This method will return the converted value by comparing the UOMs from DB.
        public static double UomCnvVal(string FrUOM, string ToUOM, double FrQty, double ValFct, double WT, string WTUOM)
        {            
            IDBManager dbManager = CommonConnection.Connectionstring();
            try
            {
                double sRetVal = default(double);
                dbManager.Open();
                dbManager.CreateParameters(7);
                DataSet dsVal = new DataSet();

                //Asign values to properties
                UomConversions cls = new UomConversions(FrUOM, ToUOM, FrQty, ValFct, WT, WTUOM);

                if (ConfigurationSettings.AppSettings["DataB"] == "SQL")
                {
                    dbManager.AddParameters(0, "@FrUOM", UomConversions.FrUOM, ParameterDirection.Input);
                    dbManager.AddParameters(1, "@ToUOM", UomConversions.ToUOM, ParameterDirection.Input);
                    dbManager.AddParameters(2, "@FrQty", UomConversions.FrQty, ParameterDirection.Input);
                    dbManager.AddParameters(3, "@ValFct", UomConversions.ValFct, ParameterDirection.Input);
                    dbManager.AddParameters(4, "@WT", UomConversions.WT, ParameterDirection.Input);
                    dbManager.AddParameters(5, "@WTUOM", UomConversions.WTUOM, ParameterDirection.Input);
                    dbManager.AddParameters(6, "@CnvQty", 0, ParameterDirection.Output);

                    string spCall = Helper.Ins.GetSPCall(dbManager.Parameters, "ObjUom_Convert");
                    dsVal = dbManager.ExecuteDataSet(CommandType.StoredProcedure, "ObjUom_Convert");
                }                
                if (dbManager.Parameters[6].Value.ToString() != "")
                    sRetVal = double.Parse(dbManager.Parameters[6].Value.ToString());
                return sRetVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        // Parse the xml using XMLDocument class.
        private static void ParseByXMLDocument()
        {
            try
            {
                if (!string.IsNullOrEmpty(xmlUrl))
                {
                    if (File.Exists(xmlUrl))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(xmlUrl);
                        XmlNode StudentListNode = doc.SelectSingleNode("/UOMConversions/UOMS");
                        XmlNodeList StudentNodeList = StudentListNode.SelectNodes("UOM");
                        foreach (XmlNode node in StudentNodeList)
                        {
                            UomConversions.DOZ = Convert.ToDouble(node.Attributes.GetNamedItem("DOZ").Value);
                            UomConversions.PR = Convert.ToDouble(node.Attributes.GetNamedItem("PR").Value);
                            UomConversions.NO = Convert.ToDouble(node.Attributes.GetNamedItem("NO").Value);
                            UomConversions.EA = Convert.ToDouble(node.Attributes.GetNamedItem("EA").Value);
                            UomConversions.PCS = Convert.ToDouble(node.Attributes.GetNamedItem("PCS").Value);
                            UomConversions.DPR = Convert.ToDouble(node.Attributes.GetNamedItem("DPR").Value);
                            UomConversions.KG = Convert.ToDouble(node.Attributes.GetNamedItem("KG").Value);
                            UomConversions.LBS = Convert.ToDouble(node.Attributes.GetNamedItem("LBS").Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //This method to return the Converted values
        public static double UomCnvertedVal(string FromUom, string ToUom, double Qty, double VlFact, DataTable dtUomConv)
        {            
            try
            {
                //Asign values to properties
                UomConversions cls = new UomConversions(FromUom, ToUom, Qty, VlFact, default(double), string.Empty);                                
                DataRow[] dr;                
                if (dtUomConv.Columns.Contains("FromUom") && dtUomConv.Columns.Contains("ToUom"))
                {
                    dr = dtUomConv.Select("FromUom='" + UomConversions.FrUOM + "' and ToUom='" + UomConversions.ToUOM + "'");
                    if (dr != null && dr.Count() > 0)                                            
                        UomConversions.CnvQty = UomConversions.FrQty * (Convert.ToDouble(dr[0]["Numenator"]) / Convert.ToDouble(dr[0]["Denominator"]));                                            
                    else
                        UomConversions.CnvQty = UomConversions.FrQty * UomConversions.ValFct;
                }
                else
                    UomConversions.CnvQty = UomConversions.FrQty * UomConversions.ValFct;

                return Math.Round(UomConversions.CnvQty, 4);                
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
