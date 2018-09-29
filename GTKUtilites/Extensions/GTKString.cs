using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace GTKUtilites.Extensions
{
    public class GTKString 
    {
        public static string ToEscapeSpecialChars(string sValue)
        {
             return SecurityElement.Escape(sValue.ToString().ToUpper());
        }

        public static string ToEscapeSpecialCharsNoCaseChange(string sValue)
        {
            return SecurityElement.Escape(sValue.ToString());
        }

    }
}
