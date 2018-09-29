using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKSSOLibrary.DataAccessLayer;
namespace GTKSSOLibrary.BusinessLayer
{
    public class ErrorLog
    {
        public void LogError(string errorNameSpace, string eventName, string errorStack, string errorByUser)
        {
            try
            {
                GTKSSOLibrary.DataAccessLayer.ErrorLog error = new GTKSSOLibrary.DataAccessLayer.ErrorLog();
                error.LogError(errorNameSpace, eventName, errorStack, errorByUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}