using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GTKUtilites.InterfaceLayer;
using GTKUtilites.Extensions;
using GTKUtilites.HelpMethods;
using System.Data;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.ComponentModel;
using System.Reflection;
namespace GTKUtilites.Extensions
{
    [Serializable]


    public class EntityClass : IGTK<EntityClass>
    {
      
        
     
        public string C1 { get; set; }
        public string C2 { get; set; }
        public string C3 { get; set; }
        public string C4 { get; set; }
        public string C5 { get; set; }
        public string C6 { get; set; }
        public string C7 { get; set; }
        public string C8 { get; set; }
        public string C9 { get; set; }
        public string C10 { get; set; }
        public string C11 { get; set; }
        public string C12 { get; set; }
        public string C13 { get; set; }
        public string C14 { get; set; }
        public string C15 { get; set; }
        public string C16 { get; set; }
        public string STATUS { get; set; }
        public string CPK { get; set; }
        public string PNO { get; set; }
        public string ID { get; set; }
        public string ORIGID { get; set; }
        public string ParentNode
        {
            get { return "Root"; }
        }

        public string ChildNode
        {
            get { return "DML"; }
        }

        public EntityClass GetNewRow()
        {
            throw new NotImplementedException();
        }
       

        public List<EntityClass> GetDetails(DataTable dtDetails)
        {
            return GTKLINQ.ConvertToList<EntityClass>(dtDetails);
        }

        public void RemoveDetails(ref EntityClass type)
        {
            throw new NotImplementedException();
        }

        public string PrepareSaveXml(List<EntityClass> liValues)
        {
            return PrepareXML.GetXmlWithEmpty<EntityClass>(liValues, ParentNode, ChildNode);
        }

      

       
    }

   
}

