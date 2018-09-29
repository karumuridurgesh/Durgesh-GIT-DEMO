using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace GTKUtilites.Extensions
{
   public static class GTKLINQ
    {
       /// <summary>
       /// Convert DataTable ToList
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="table"></param>
       /// <returns></returns>
        public static List<T> ConvertToList<T>(this DataTable table) where T : new()
        {
            Type t = typeof(T);

            // Create a list of the entities we want to return
            List<T> returnObject = new List<T>();

            // Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                // Convert each row into an entity object and add to the list
                T newRow = dr.ConvertToEntity<T>(false);
                returnObject.Add(newRow);
            }

            // Return the finished list
            return returnObject;
        }
        /// <summary>
        /// Convert DataTable ToList with same case
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this DataTable table,bool IsSameCaseData) where T : new()
        {
            Type t = typeof(T);

            // Create a list of the entities we want to return
            List<T> returnObject = new List<T>();

            // Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                // Convert each row into an entity object and add to the list
                T newRow = dr.ConvertToEntity<T>(IsSameCaseData);
                returnObject.Add(newRow);
            }

            // Return the finished list
            return returnObject;
        }
        /// <summary>
        /// GEt First Row 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static T GetFirstRow<T>(this DataTable table) where T : new()
        {
            Type t = typeof(T);

            // Create a list of the entities we want to return
            List<T> returnObject = new List<T>();

            // Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                // Convert each row into an entity object and add to the list
                T newRow = dr.ConvertToEntity<T>(false);
                returnObject.Add(newRow);
            }

            // Return the finished list
            return returnObject.FirstOrDefault();
        }


        public static List<T> GenericDeSerialize<T>(this String sXML) where T : new()
        {

            //Creating XmlSerializer for the object


           // var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Root"));
            XmlSerializer ser = new XmlSerializer(typeof(List<T>), new XmlRootAttribute() { ElementName = "Root" });


            //itemList = (List<T>)serializer.Deserialize(reader);
            //reader.Close();
            //XmlSerializer xs = new XmlSerializer(typeof(T));

            TextReader tr = new StringReader(sXML);

            List<T> b = (List<T>)ser.Deserialize(XmlReader.Create(tr));
           

            //XmlSerializer serializer = new XmlSerializer(typeof(List<T>));



            ////Geting XMl from the file.
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(sXML);
            
            //XmlTextReader xmlTr = new XmlTextReader(new StringReader(sXML));
            
            
            ////Deserialize back to object from XML

            //List<T> b = (List<T>)serializer.Deserialize(xmlTr);

            //xmlTr.Close();
            return b;
        }


        
       /// <summary>
       /// ConvertTo Entity
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="tableRow"></param>
       /// <returns></returns>
        public static T ConvertToEntity<T>(this DataRow tableRow,bool IsSameCase) where T : new()
        {
            // Create a new type of the entity I want
            Type t = typeof(T);
            T returnObject = new T();

            foreach (DataColumn col in tableRow.Table.Columns)
            {
                string colName = col.ColumnName;

                // Look for the object's property with the columns name, ignore case
                PropertyInfo pInfo = t.GetProperty(colName.ToUpper(),
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // did we find the property ?
                if (pInfo != null)
                {
                    object val = tableRow[colName];

                    // is this a Nullable<> type
                    bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
                    if (IsNullable)
                    {
                        if (val is System.DBNull)
                        {
                            val = null;
                        }
                        else
                        {
                            // Convert the db type into the T we have in our Nullable<T> type
                            val = Convert.ChangeType
                    (val, Nullable.GetUnderlyingType(pInfo.PropertyType));
                        }
                    }
                    else
                    {
                        // Convert the db type into the type of the property in our entity
                        val = Convert.ChangeType(val, pInfo.PropertyType);
                    }
                    // Set the value of the property with the value from the db
                    if (!IsSameCase)
                        pInfo.SetValue(returnObject, val.ToString().Trim().ToUpper(), null); 
                    else
                        pInfo.SetValue(returnObject, val.ToString().Trim(), null); 

                    //pInfo.SetValue(returnObject, val.ToString().ToUpper(), null);
                }
            }

            // return the entity object with values
            return returnObject;
        }
        /// <summary>
        /// Convert DataRow[]  ToList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this DataRow[] dtRows) where T : new()
        {
            Type t = typeof(T);

            // Create a list of the entities we want to return
            List<T> returnObject = new List<T>();

            // Iterate through the DataTable's rows
            foreach (DataRow dr in dtRows)
            {
                // Convert each row into an entity object and add to the list
                T newRow = dr.ConvertToEntity<T>(false);
                returnObject.Add(newRow);
            }

            // Return the finished list
            return returnObject;
        }
        public static List<EntityClass> ConvertGridEntity<T>(this List<T> liValues, int Pno, int RecPage, List<string> listr) where T : new()
        {

            Type t = typeof(T);
            Type Et = typeof(EntityClass);
            // Create a list of the entities we want to return
            List<EntityClass> returnObject = new List<EntityClass>();
            Type gType = typeof(T);
            int licount = liValues.Count;
            int StartInd = ((Pno) * RecPage + 1);
            int EndInd = Convert.ToInt32(((Pno + 1) * RecPage) > licount ? licount : ((Pno + 1) * RecPage));
            for (int ind = StartInd; ind <= EndInd; ind++)
            {
                T genType = liValues[ind - 1];
                EntityClass EC = new EntityClass();
                PropertyInfo[] EntitypropInfo = EC.GetType().GetProperties();
                //EntityClass E = new EntityClass();
                PropertyInfo[] propInfo = genType.GetType().GetProperties();




                Array.Sort(propInfo, new DeclarationOrderComparator());
    
                int j = 0;
                foreach (string str in listr)
                {
                    int i = Convert.ToInt32(str);
                    j = j + 1;
                    if (!string.IsNullOrEmpty(string.Format("{0}", propInfo[i].GetValue(genType, null))))//&&j<16
                    {
                        var value = propInfo[i].GetValue(genType, null).ToString().ToUpper();
                        // Look for the object's property with the columns name, ignore case
                     
                        PropertyInfo pInfo = Et.GetProperty("C" + j + "",
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                      
                        //pInfo.SetValue(genType, value, i);
                        pInfo.SetValue(EC, value, null);

                    }
                }
                //if (!string.IsNullOrEmpty(string.Format("{0}", genType.GetType().GetProperty("PAGINGID").GetValue(genType, null))))
                //{
                //    var value = genType.GetType().GetProperty("PAGINGID").GetValue(genType, null).ToString().ToUpper();
                //    // Look for the object's property with the columns name, ignore case

                //    PropertyInfo pInfo = Et.GetProperty("ID",
                //    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


                //    //pInfo.SetValue(genType, value, i);
                //    pInfo.SetValue(EC, value, null);

                //}
                //if (!string.IsNullOrEmpty(string.Format("{0}", genType.GetType().GetProperty("PAGINGORIGID").GetValue(genType, null))))
                //{
                //    var value = genType.GetType().GetProperty("PAGINGORIGID").GetValue(genType, null).ToString().ToUpper();
                //    // Look for the object's property with the columns name, ignore case

                //    PropertyInfo pInfo = Et.GetProperty("ORIGID",
                //    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


                //    //pInfo.SetValue(genType, value, i);
                //    pInfo.SetValue(EC, value, null);

                //}
                returnObject.Add(EC);
            }

            // Return the finished list
            return returnObject;
        }
        public static List<EntityClass> ConvertGridEntityPaginate<T>(this List<T> liValues, int Pno, int RecPage, List<string> listr) where T : new()
        {

            Type t = typeof(T);
            Type Et = typeof(EntityClass);
            // Create a list of the entities we want to return
            List<EntityClass> returnObject = new List<EntityClass>();
            Type gType = typeof(T);
            int licount = liValues.Count;
            int StartInd = ((Pno) * RecPage + 1);
            int EndInd = Convert.ToInt32(((Pno + 1) * RecPage) > licount ? licount : ((Pno + 1) * RecPage));
            for (int ind = StartInd; ind <= EndInd; ind++)
            {
                T genType = liValues[ind - 1];
                EntityClass EC = new EntityClass();
                PropertyInfo[] EntitypropInfo = EC.GetType().GetProperties();
                //EntityClass E = new EntityClass();
                PropertyInfo[] propInfo = genType.GetType().GetProperties();




                Array.Sort(propInfo, new DeclarationOrderComparator());

                int j = 0;

                foreach (string str in listr)
                {
                    int i = Convert.ToInt32(str);
                    j = j + 1;
                    if (!string.IsNullOrEmpty(string.Format("{0}", propInfo[i].GetValue(genType, null))) && j < 16)
                    {
                        var value = propInfo[i].GetValue(genType, null).ToString();
                        // Look for the object's property with the columns name, ignore case

                        PropertyInfo pInfo = Et.GetProperty("C" + j + "",
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


                        //pInfo.SetValue(genType, value, i);
                        pInfo.SetValue(EC, value, null);

                    }
                }
                int k = listr.Count+1;
                for (j = k; j < 16; j++)
                {
                    PropertyInfo pInfo = Et.GetProperty("C" + j + "",
                       BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


                    //pInfo.SetValue(genType, value, i);
                    pInfo.SetValue(EC, "", null);
                }

                    if (!string.IsNullOrEmpty(string.Format("{0}", genType.GetType().GetProperty("PAGINGID").GetValue(genType, null))))
                    {
                        var value = genType.GetType().GetProperty("PAGINGID").GetValue(genType, null).ToString().ToUpper();
                        // Look for the object's property with the columns name, ignore case

                        PropertyInfo pInfo = Et.GetProperty("ID",
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


                        //pInfo.SetValue(genType, value, i);
                        pInfo.SetValue(EC, value, null);

                    }
                if (!string.IsNullOrEmpty(string.Format("{0}", genType.GetType().GetProperty("PAGINGORIGID").GetValue(genType, null))))
                {
                    var value = genType.GetType().GetProperty("PAGINGORIGID").GetValue(genType, null).ToString().ToUpper();
                    // Look for the object's property with the columns name, ignore case

                    PropertyInfo pInfo = Et.GetProperty("ORIGID",
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


                    //pInfo.SetValue(genType, value, i);
                    pInfo.SetValue(EC, value, null);

                }
                returnObject.Add(EC);
            }

            // Return the finished list
            return returnObject;
        }

        /// <summary>
        /// Convert Entity List to DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
       
    }
   public class DeclarationOrderComparator : IComparer
   {
       int IComparer.Compare(Object x, Object y)
       {
           PropertyInfo first = x as PropertyInfo;
           PropertyInfo second = y as PropertyInfo;
           if (first.MetadataToken < second.MetadataToken)
               return -1;
           else if (first.MetadataToken > second.MetadataToken)
               return 1;

           return 0;
       }
   }
}
