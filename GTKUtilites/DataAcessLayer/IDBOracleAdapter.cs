using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;


namespace GTKUtilites.DataAccessLayer
{
    public class IDBOracleAdapter{
        OracleConnection Con;
        OracleCommand Cmd;
        public object[] ExecuteOracleNonQuery(IDBManager dbmanager, CommandType commandType, string commandText){
            try{
                string strconn = dbmanager.ConnectionString;
                Con = new OracleConnection(strconn);
                Cmd = new OracleCommand();
                Con.Open();
                Cmd.Connection = Con;
                Cmd.CommandText = commandText;
                Cmd.CommandType = commandType;
                int length = 0;
                foreach (IDataParameter parameter in dbmanager.Parameters){
                    if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input)
                    {
                        length++;
                    }
                }
                int[] outputIndexes = AssignParameters(Cmd, dbmanager,length);
                Cmd.ExecuteNonQuery();
                object[] returnObj = new object[length];
                for (int i = 0; i < outputIndexes.Length; i++) {
                    returnObj[i] = Cmd.Parameters[Convert.ToInt32(outputIndexes[i])].Value;
                }
                Cmd.Parameters.Clear();
                Con.Close();
                return returnObj;
            }
            catch (Exception ex){
                throw ex;
            }
        }
        private int[] AssignParameters(OracleCommand com, IDBManager dbmanager, int outputLength){
            try{
                int[] outputIndexes = new int[outputLength];
                if (dbmanager.Parameters != null){
                    int index = 0;
                    int length = 0;
                    foreach (IDataParameter parameter in dbmanager.Parameters){
                        com.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                        com.Parameters[parameter.ParameterName].Direction = parameter.Direction;
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            outputIndexes[length] = index;
                            length++;
                        }
                        index++;
                    }
                }
                return outputIndexes;
            }
            catch (Exception ex){
                throw ex;
            }
        }
     
        private void AssignParameters(OracleCommand com, IDBManager dbmanager,string[] cursors) {
            try{
                if (dbmanager.Parameters != null){
                    foreach (IDataParameter parameter in dbmanager.Parameters){
                        com.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                        com.Parameters[parameter.ParameterName].Direction = parameter.Direction;
                    }
                }
                for (int i = 0; i < cursors.Length; i++){
                    com.Parameters.Add(cursors[i], OracleType.Cursor);
                    com.Parameters[cursors[i]].Direction = ParameterDirection.Output;
                }
            }
            catch (Exception ex){
                throw ex;
            }
        }

        public object ExecuteOracleScalar(IDBManager dbmanager, CommandType commandType, string commandText){
            try{
                string strconn = dbmanager.ConnectionString;
                Con = new OracleConnection(strconn);
                Cmd = new OracleCommand();
                Con.Open();
                Cmd.Connection = Con;
                Cmd.CommandText = commandText;
                Cmd.CommandType = commandType;
                string[] cursors = new string[0];
                AssignParameters(Cmd, dbmanager,cursors);
                object returnValue = Cmd.ExecuteScalar();
                Cmd.Parameters.Clear();
                Con.Close();
                return returnValue;
            }
            catch (Exception ex){
                throw ex;
            }
        }

        public DataSet ExecuteOracleDataSet(IDBManager dbmanager, CommandType commandType, string
         commandText, string[] cursors){
             try{
                 string strconn = dbmanager.ConnectionString;
                 Con = new OracleConnection(strconn);
                 Cmd = new OracleCommand();
                 Con.Open();
                 Cmd.Connection = Con;
                 Cmd.CommandText = commandText;
                 Cmd.CommandType = commandType;
                 AssignParameters(Cmd, dbmanager,cursors);
                 DataSet ds = new DataSet();
                 OracleDataAdapter oda = new OracleDataAdapter(Cmd);
                 oda.Fill(ds);
                 Cmd.Parameters.Clear();
                 Con.Close();
                 return ds;
             }
             catch (Exception ex){
                 throw ex;
             }
        }

        public int ExecuteOracleNonQuery1(IDBManager dbmanager, CommandType commandType, string commandText)
        {
            try
            {
                string strconn = dbmanager.ConnectionString;
                int i = 0;
                Con = new OracleConnection(strconn);
                Cmd = new OracleCommand();
                Con.Open();
                Cmd.Connection = Con;
                Cmd.CommandText = commandText;
                Cmd.CommandType = commandType;
                int length = 0;
                foreach (IDataParameter parameter in dbmanager.Parameters)
                {
                    if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input)
                    {
                        length++;
                    }
                }
                AssignParameters(Cmd, dbmanager, length);
                //int[] outputIndexes = AssignParameters(Cmd, dbmanager, length);
                i=Cmd.ExecuteNonQuery();
                //object[] returnObj = new object[length];
                //for (int i = 0; i < outputIndexes.Length; i++)
                //{
                //    returnObj[i] = Cmd.Parameters[Convert.ToInt32(outputIndexes[i])].Value;
                //}
                Cmd.Parameters.Clear();
                Con.Close();
                //return returnObj;
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
