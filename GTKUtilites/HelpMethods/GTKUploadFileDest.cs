using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using GTKUtilites.BusinessLogicLayer;
using GTKUtilites.BusinessObjects;
using XSS = Microsoft.Security.Application;

namespace GTKUtilites.HelpMethods
{
    public class GTKUploadFileDest
    {
        //DocImgUploadProp clsDocImgUploadProp = 
        //new DocImgUploadProp();
        DocImgUploadBLL clsDocImgUploadBLL = new DocImgUploadBLL();
        private static GTKUploadFileDest _Ins = new GTKUploadFileDest();

        public static GTKUploadFileDest Ins
        {
            get
            {
                return _Ins;
            }
        }
        string ActualPath = string.Empty;
        string DUType = string.Empty;
        string InputPath = string.Empty;
        string BackupPath = string.Empty;
        string ErrorPath = string.Empty;
        string sSheetQuery = string.Empty;
        string filename = string.Empty;
        string FileDest = string.Empty;
        FileUpload sFile;

        public string SaveFileData(DataTable dtParams, FileUpload fuSCU, DocImgUploadProp clsDocImg)
        {
            //if (clsDocImg.sUserCode == string.Empty)
            //{
            //    return "N|UserCode";
            //}
            string sRetVal = string.Empty;
            if (dtParams.Rows.Count > 0)
            {
                DUType = dtParams.Rows[0]["DUType"].ToString();
                ActualPath = GetSingleValueFromDataTable(dtParams, "ParamCd", "FILES", "DefValue");
                InputPath = GetSingleValueFromDataTable(dtParams, "ParamCd", "Input", "DefValue");
                BackupPath = GetSingleValueFromDataTable(dtParams, "ParamCd", "Backup", "DefValue");
                ErrorPath = GetSingleValueFromDataTable(dtParams, "ParamCd", "Error", "DefValue");
                FileDest = GetSingleValueFromDataTable(dtParams, "ParamCd", "FileDest", "DefValue");
                if (FileDest == string.Empty)
                    FileDest = "FS";
                if (FileDest != string.Empty)
                {
                    if (FileDest.Trim().ToUpper() == "FS" && ActualPath != string.Empty)
                    {
                        if (!string.IsNullOrEmpty(fuSCU.FileName))
                        {
                            DataTable dtTempHeader = new DataTable();
                            sFile = fuSCU;
                            string filePath = ActualPath + XSS.Encoder.HtmlEncode(fuSCU.FileName);
                            if (File.Exists(filePath))
                                File.Delete(filePath);
                            //filePath = "D:\\WorkSPace\\Attrib.xls";                            
                            fuSCU.PostedFile.SaveAs(filePath);
                            string sReturnMessage = string.Empty;
                            // string Url = "SupplychainUpload.aspx";
                            //sReturnMessage = GetGTKMessages("FileUpld", null);                            
                            //ShowValidationAlert(sReturnMessage);                           
                        }
                        return string.Empty;
                    }
                    else if (FileDest.Trim().ToUpper() == "DB" && clsDocImg.sUserCode != string.Empty)
                    {
                        byte[] image;
                        Stream fStream = fuSCU.PostedFile.InputStream;
                        BinaryReader reader = new BinaryReader(fStream);
                        image = reader.ReadBytes((int)fStream.Length);
                        sRetVal = clsDocImgUploadBLL.Save_DocUpload(DUType, image, clsDocImg.sParam1, clsDocImg.sParam2, clsDocImg.sParam3, clsDocImg.sParam4, clsDocImg.sParam5, clsDocImg.sUserCode, fuSCU.FileName);
                    }

                }
            }
            return sRetVal;
        }

        public static string GetSingleValueFromDataTable(DataTable dt, string sFilter, string sFilterValue, string sSelectColumn)
        {
            try
            {
                string sReturnValue = "";

                if (dt.Select(sFilter + "='" + sFilterValue + "'").Count() > 0)
                    sReturnValue = dt.Select(sFilter + "='" + sFilterValue + "'")[0][sSelectColumn].ToString();

                return sReturnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

