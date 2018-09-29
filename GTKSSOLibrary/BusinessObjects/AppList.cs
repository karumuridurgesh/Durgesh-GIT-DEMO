using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using GTKUtilites.Extensions;

namespace GTKSSOLibrary.BusinessObjects
{
    public class AppList
    {
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string AppUrl { get; set; }
        public string APPIsActive { get; set; }
        public string Mode { get; set; }
        public string AppType { get; set; }
        public string DBName { get; set; }

        public string PrepareSaveXml(List<AppList> liValues)
        {
            return GetXml<AppList>(liValues, ParentNode, ChildNode);
        }

        public string ParentNode
        {
            get { return ("AppLists"); }
        }

        public string ChildNode
        {
            get { return ("AppLists"); }
        }


        public static string GetXml<T>(List<T> liValues, string parentRoot, string childRoot)
        {
            XDocument xDoc = new XDocument();
            var partentRoot = new XElement(parentRoot);

            foreach (T genType in liValues)
            {
                PropertyInfo[] propInfo = genType.GetType().GetProperties();
                var childroot = new XElement(childRoot);
                foreach (PropertyInfo prop in propInfo)
                {
                    if (prop.PropertyType.FullName.ToUpper() == typeof(System.String).ToString().ToUpper() || prop.PropertyType.FullName.ToUpper() == typeof(System.Int32).ToString().ToUpper() || prop.PropertyType.FullName.ToUpper() == typeof(System.Double).ToString().ToUpper())
                    {
                        if (prop.Name.ToLower() != "parentrootnode" && prop.Name.ToLower() != "parentnode" && prop.Name.ToLower() != "childnode")
                        {
                            if (!string.IsNullOrEmpty(string.Format("{0}", prop.GetValue(genType, null))))
                                childroot.SetAttributeValue(prop.Name, GTKString.ToEscapeSpecialChars(prop.GetValue(genType, null).ToString()));

                        }
                    }
                }
                partentRoot.Add(childroot);
            }
            xDoc.Add(partentRoot);
            return xDoc.ToString();
        }
    }
}
