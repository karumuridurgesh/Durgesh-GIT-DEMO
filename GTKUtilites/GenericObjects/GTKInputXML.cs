using System;
using System.Collections.Generic;
using GTKUtilites.HelpMethods;
namespace GTKUtilites.GenericObjects
{
    
    [Serializable]
    public class GTKInputXML
    {
        public string PKVal1 { get; set; }
        public string PKVal2 { get; set; }
        public string PKVal3 { get; set; }
        public string PKVal4 { get; set; }
        public string PKVal5 { get; set; }
        public string PKVal6 { get; set; }
        public string PKVal7 { get; set; }
        public string PKVal8 { get; set; }
        public string PKVal9 { get; set; }
        public string PKVal10 { get; set; }
        

        public string ParentNode
        {
            get { return "GTKInputXMLs"; }
        }

        public string ChildNode
        {
            get { return "GTKInputXML"; }
        }

        
        public string PrepareSaveXml(List<GTKInputXML> liValues)
        {
            return PrepareXML.GetXml<GTKInputXML>(liValues, ParentNode, ChildNode);
        }        
    }
}
