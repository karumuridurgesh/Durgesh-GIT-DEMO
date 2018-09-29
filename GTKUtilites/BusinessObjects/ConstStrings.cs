using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKUtilites.InterfaceLayer;

namespace GTKUtilites.BusinessObjects
{    
    public sealed class ConstStrings
    {
        
        public const string sModeXML = "<Root><Parameters><Parameter  id=\"Mode\" value=\"{0}\" /></Parameters></Root>";
        //     ConstStrings.sModeXML
        public const string sModfMode = "M";  //     ConstStrings.sModfMode

        public const string sVwMode = "V";   //     ConstStrings.sVwMode

        public const string sCreateMode = "C";  //     ConstStrings.sCreateMode

        public const string sUpdt = "Update";    //     ConstStrings.sUpdt

        public const string sClr = "Clear";   //     ConstStrings.sClr

        public const string sLst = "LST";   //     ConstStrings.sLst

        public const string sDtDescr = "DtTypeDescr";  //     ConstStrings.sDtDescr

        public const string sActnTxt = "AxnTxt";  //     ConstStrings.sActnTxt

        public const string sActnCd = "AxnCd";   //     ConstStrings.sActnCd

        public const string s12AM = " 12:00:00 AM";  //     ConstStrings.s12AM

        public const string s12PM = " 11:59:59 PM";    //     ConstStrings.s12PM

        public const string sModeQ = "Q";   //     ConstStrings.sModeQ

        public const string sFirst = "First";   //     ConstStrings.sFirst

        public const string sddlSelect = "--Select--";  //     ConstStrings.sddlSelect

        public const string sZero = "0";   //     ConstStrings.sZero

        public const string sDtMDY = "{0:MM/dd/yyyy hh:mm:ss tt}";   //     ConstStrings.sDtMDY

        public const string sDisp = "display";  //     ConstStrings.sDisp 

        public const string sNone = "none";     //     ConstStrings.sNone

        public const string sBlock = "block";    //     ConstStrings.sBlock
        public const string sDisplayValue = "DisplayValue";    //     ConstStrings.sDisplayValue
        public const string sStoredValue = "StoredValue";    //     ConstStrings.sStoredValue
        public const string EntityLockMessage = "{0} locked by ({1}) in another session. View only permitted until released or unlocked.";
        public const string EntityLockNoAccessMessage = "{0} locked by ({1}) in another session. No actions are permitted until unlocked or released.";  
        
    }
}
