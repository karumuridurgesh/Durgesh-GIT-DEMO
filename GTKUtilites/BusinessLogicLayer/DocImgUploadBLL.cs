using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKUtilites.DataAccessLayer;
using System.Data;

namespace GTKUtilites.BusinessLogicLayer
{
    public class DocImgUploadBLL
    {
        DocImgUploadDAL clsDocImgUploadDAL = new DocImgUploadDAL();

        public string Save_DocUpload(string sDocType, byte[] DocImgThumb, string Param1, string Param2,
                    string Param3, string Param4, string Param5, string sUserCode, string sFileName)
        {
            try
            {
                return clsDocImgUploadDAL.Save_DocUpload(sDocType, DocImgThumb, Param1, Param2, Param3, Param4, Param5, sUserCode, sFileName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
