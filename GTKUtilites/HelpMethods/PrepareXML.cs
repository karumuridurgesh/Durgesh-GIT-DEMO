using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using GTKUtilites.Extensions;
using System.Data;
using System.IO;
using System.Management;
using System.Configuration;



namespace GTKUtilites.HelpMethods
{
    public static class PrepareXML
    {
        /// <summary>
        /// Preparing Save XML string with GenericType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="liValues"></param>
        /// <param name="parentRoot"></param>
        /// <param name="childRoot"></param>
        /// <returns></returns>
        public static string GetXml<T>(List<T> liValues,string parentRoot,string childRoot)
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
        /// <summary>
        /// GetXmlNoCaseChange 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="liValues"></param>
        /// <param name="parentRoot"></param>
        /// <param name="childRoot"></param>
        /// <returns></returns>
        public static string GetXmlNoCaseChange<T>(List<T> liValues, string parentRoot, string childRoot)
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
                                childroot.SetAttributeValue(prop.Name, GTKString.ToEscapeSpecialCharsNoCaseChange(prop.GetValue(genType, null).ToString()));

                        }
                    }
                }
                partentRoot.Add(childroot);
            }
            xDoc.Add(partentRoot);
            return xDoc.ToString();
        }
        /// <summary>
        /// GetXmlWithEmpty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="liValues"></param>
        /// <param name="parentRoot"></param>
        /// <param name="childRoot"></param>
        /// <returns></returns>
        public static string GetXmlWithEmpty<T>(List<T> liValues, string parentRoot, string childRoot)
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
                            else
                                childroot.SetAttributeValue(prop.Name,"");
                        }
                    }
                }
                partentRoot.Add(childroot);
            }
            xDoc.Add(partentRoot);
            return xDoc.ToString();
        }
        /// <summary>
        /// GetEntityXml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="genClass"></param>
        /// <param name="RootNode"></param>
        /// <returns></returns>
        public static XElement GetEntityXml<T>(T genClass, string childRoot)
        {
            XDocument xDoc = new XDocument();
            PropertyInfo[] propInfo = genClass.GetType().GetProperties();
            var childroot = new XElement(childRoot);
            foreach (PropertyInfo prop in propInfo)
            {
                if (prop.Name.ToLower() != "parentrootnode" && prop.Name.ToLower() != "parentnode" && prop.Name.ToLower() != "childnode")
                {
                    if (!string.IsNullOrEmpty(string.Format("{0}", prop.GetValue(genClass, null))))
                        childroot.SetAttributeValue(prop.Name, GTKString.ToEscapeSpecialChars(prop.GetValue(genClass, null).ToString()));
                }
            }
//
            xDoc.Add(childroot);
            return childroot;
        }

        /// <summary>
        /// GetEntityXml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="genClass"></param>
        /// <param name="parentRoot"></param>
        /// <param name="childRoot"></param>
        /// <returns></returns>
        public static string GetEntityXml<T>(T genClass, string parentRoot, string childRoot)
        {
            XDocument xDoc = new XDocument();
            var partentRoot = new XElement(parentRoot);


            PropertyInfo[] propInfo = genClass.GetType().GetProperties();
            var childroot = new XElement(childRoot);
            foreach (PropertyInfo prop in propInfo)
            {
                if (prop.PropertyType.FullName.ToUpper() == typeof(System.String).ToString().ToUpper() || prop.PropertyType.FullName.ToUpper() == typeof(System.Int32).ToString().ToUpper() || prop.PropertyType.FullName.ToUpper() == typeof(System.Double).ToString().ToUpper())
                {
                    if (prop.Name.ToLower() != "parentrootnode" && prop.Name.ToLower() != "parentnode" && prop.Name.ToLower() != "childnode")
                    {
                        if (!string.IsNullOrEmpty(string.Format("{0}", prop.GetValue(genClass, null))))
                            childroot.SetAttributeValue(prop.Name, GTKString.ToEscapeSpecialChars(prop.GetValue(genClass, null).ToString()));

                    }
                }
            }
            partentRoot.Add(childroot);

            xDoc.Add(partentRoot);
            return xDoc.ToString();
        }
    }
    
}
