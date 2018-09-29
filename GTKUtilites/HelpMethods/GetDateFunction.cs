using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTKUtilites.HelpMethods
{
    public class GetDateFunction
    {

        public void GetFunctionName(string Value1, string Value2, string Value3, out string First, out string Last, ref bool flag )
        {
            flag = false;
            if (Value3 != "" && Convert.ToInt32(Value2) != 0)
            {
                switch (Value1)
                {
                    case "YESTERDAY": flag = true;
                        if(Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','P','D',null))";
                            Last="";
                        }
                        else
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','P','D',null))";
                            Last="";
                        }
                        break;
                    case "TODAY": flag = true;
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','C','D',null))";
                            Last = "";
                        }
                        else
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','C','D',null))";
                            Last = "";
                        }
                        break;

                    case "TOMORROW": flag = true;
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','N','D',null))";
                            Last = "";
                        }
                        else
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','N','D',null))";
                            Last = "";
                        }
                        break;
                    case "NEXT BUSINESS DAY": flag = true;
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','B','D',null))";
                            Last = "";
                        }
                        else
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','B','D',null))";
                            Last = "";
                        }
                        break;
                    case "LAST 30 DAYS": flag = true;
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','T','D',null))";
                            Last = "";
                        }
                        else
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','T','D',null))";
                            Last = "";
                        }
                        break;
                    case "LAST 60 DAYS": flag = true;
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','S','D',null))";
                            Last = "";
                        }
                        else
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','S','D',null))";
                            Last = "";
                        }
                        break;
                    case "LAST 15 DAYS": flag = true;
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','F','D',null))";
                            Last = "";
                        }
                        else
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','F','D',null))";
                            Last = "";
                        }
                        break;

                    case "PREVIOUS MONTH":
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','P','M',null))";
                            Last = "DBO.GTK_SPECIALDATES('L','P','M',null)";
                        }
                        else
                        {
                            First = "DBO.GTK_SPECIALDATES('F','P','M',null)";
                            Last= "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','P','M',null))";
                        }
                        break;
                     
                    case "CURRENT MONTH":
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','C','M',null))";
                            Last = "DBO.GTK_SPECIALDATES('L','C','M',null)";
                        }
                        else
                        {
                            First = "DBO.GTK_SPECIALDATES('F','C','M',null)";
                            Last = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','C','M',null))";
                        }
                        break;
                    case "NEXT MONTH":
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','N','M',null))";
                            Last = "DBO.GTK_SPECIALDATES('L','N','M',null)";
                        }
                        else
                        {
                            First = "DBO.GTK_SPECIALDATES('F','N','M',null)";
                            Last = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','N','M',null))";
                        }
                        break;
                    case "PREVIOUS YEAR":
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','P','Y',null))";
                            Last = "DBO.GTK_SPECIALDATES('L','P','Y',null)";
                        }
                        else
                        {
                            First = "DBO.GTK_SPECIALDATES('F','P','Y',null)";
                            Last = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','P','Y',null))";
                        }
                        break;
                    case "CURRENT YEAR":
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','C','Y',null))";
                            Last = "DBO.GTK_SPECIALDATES('L','C','Y',null)";
                        }
                        else
                        {
                            First = "DBO.GTK_SPECIALDATES('F','C','Y',null)";
                            Last = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','C','Y',null))";
                        }
                        break;
                    case "NEXT YEAR":
                        if (Value2.Contains('-'))
                        {
                            First = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('F','N','Y',null))";
                            Last = "DBO.GTK_SPECIALDATES('L','N','Y',null)";
                        }
                        else
                        {
                            First = "DBO.GTK_SPECIALDATES('F','N','Y',null)";
                            Last = "DBO.GTK_ADDDATE('" + Value3 + "'," + Value2 + ",DBO.GTK_SPECIALDATES('L','N','Y',null))";
                        }
                        break;
                    default:
                        First = "";
                        Last = "";
                        break;
                }
            }
            else {

                switch (Value1)
                {
                    case "YESTERDAY": flag = true;
                        First = "DBO.GTK_SPECIALDATES('F','P','D',null)";
                        Last = "";
                        break;
                    case "TODAY": flag = true;
                        First = "DBO.GTK_SPECIALDATES('F','C','D',null)";
                        Last = "";
                        break;
                    case "TOMORROW": flag = true;
                        First = "DBO.GTK_SPECIALDATES('F','N','D',null)";
                        Last = "";
                        break;
                    case "NEXT BUSINESS DAY": flag = true;
                        First = "DBO.GTK_SPECIALDATES('F','B','D',null)";
                        Last = "";
                        break;
                    case "LAST 30 DAYS": flag = true;
                        First = "DBO.GTK_SPECIALDATES('F','T','D',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','T','D',null)";                        
                        break;
                    case "LAST 60 DAYS": flag = true;
                        First = "DBO.GTK_SPECIALDATES('F','S','D',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','S','D',null)";                        
                        break;
                    case "PREVIOUS MONTH":
                        First = "DBO.GTK_SPECIALDATES('F','P','M',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','P','M',null)";
                        break;
                    case "CURRENT MONTH":
                        First = "DBO.GTK_SPECIALDATES('F','C','M',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','C','M',null)";
                        break;
                    case "NEXT MONTH":
                        First = "DBO.GTK_SPECIALDATES('F','N','M',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','N','M',null)";
                        break;
                    case "PREVIOUS YEAR":
                        First = "DBO.GTK_SPECIALDATES('F','P','Y',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','P','Y',null)";
                        break;
                    case "CURRENT YEAR":
                        First = "DBO.GTK_SPECIALDATES('F','C','Y',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','C','Y',null)";
                        break;
                    case "NEXT YEAR":
                        First = "DBO.GTK_SPECIALDATES('F','N','Y',null)";
                        Last = "DBO.GTK_SPECIALDATES('L','N','Y',null)";
                        break;
                    default:
                        First = "";
                        Last = "";
                        break;
                }
            }
        }

        public string GetDDLDateValue(string Value)
        {
            switch (Value)
            {
                case "PD":
                    return "YESTERDAY";
                case "CD":
                    return "TODAY";
                case "ND":
                    return "TOMORROW";
                case "PM":
                    return "PREVIOUS MONTH";
                case "CM":
                    return "CURRENT MONTH";
                case "NM":
                    return "NEXT MONTH";
                case "PY":
                    return "PREVIOUS YEAR";
                case "CY":
                    return "CURRENT YEAR";
                case "NY":
                    return "NEXT YEAR";
                case "BD":
                    return "NEXT BUSINESS DAY";
                default:
                    return "";
            
            }
           
        }
    }
}
