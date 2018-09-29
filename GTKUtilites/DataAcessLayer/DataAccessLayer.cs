using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.OracleClient;

namespace GTKUtilites.DataAccessLayer
{
  public interface IDBManager
  {
    DataProvider ProviderType
    {
      get;
      set;
    }
 
    string ConnectionString
    {
      get;
      set;
    }
 
    IDbConnection Connection
    {
      get;
    }
    IDbTransaction Transaction
    {
      get;
    }
 
    IDataReader DataReader
    {
      get;
    }
    IDbCommand Command
    {
      get;
    }
 
    IDbDataParameter[]Parameters
    {
      get;
    }
 
    void Open();
    void BeginTransaction();
    void CommitTransaction();
    void CreateParameters(int paramsCount);
    void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection, int size);
    void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection);
    void AddParameters(int index, string paramName);
    IDataReader ExecuteReader(CommandType commandType, string
    commandText);
    DataSet ExecuteDataSet(CommandType commandType, string
    commandText);
    object ExecuteScalar(CommandType commandType, string commandText);
    int ExecuteNonQuery(CommandType commandType,string commandText);
    void CloseReader();
    void Close();
    void Dispose();
  }
}