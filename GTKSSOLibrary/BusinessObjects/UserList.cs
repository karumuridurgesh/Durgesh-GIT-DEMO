using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTKUtilites.Extensions;
using System.Reflection;
using System.Xml.Linq;

namespace GTKSSOLibrary.BusinessObjects
{
    public class UserList
    {
        public string UserFirstName { get; set; }
        public string UserMidName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserApps { get; set; }
        public string Mode { get; set; }
        public string userCode { get; set; }
        public string EParm { get; set; }

        public string PrepareSaveXml(List<UserList> liValues)
        {
            return GetXml<UserList>(liValues, ParentNode, ChildNode);
        }

        public string ParentNode
        {
            get { return ("UserLists"); }
        }

        public string ChildNode
        {
            get { return ("UserLists"); }
        }
            //firstname, string MidName, string LastName, string Email, string userapps, string Mode, string usercode

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
