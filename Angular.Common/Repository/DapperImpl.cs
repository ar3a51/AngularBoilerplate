using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Angular.Common.Repository
{
  public class DapperImpl : IDatabase, IDisposable
  {
    private IDbConnection _connection;
   
    private int _connCounter = 0;

    public IDbTransaction Transaction { set; get; }

    public DapperImpl(IDbConnection connection) {
      _connection = connection;
    }


    public IDbConnection Connection {
      get {
        return _connection;
      }
    }

    public void CloseConnection()
    {
      _connCounter--;
      if (_connection.State == ConnectionState.Open && _connCounter == 0)
      {
        _connection.Close();
      }
    }

    public void Insert<T>(T obj) where T: ISQLMapper
    {
      OpenConnection();
      DynamicParameters param = Convert(obj.InsertStatement().Params.ToArray());
      int rowCount = _connection.Execute(obj.InsertStatement().Query, param,Transaction);

      if (rowCount > 0)
      {
        obj.Identity = param.Get<int>("@id");
      }
      CloseConnection();
    }

    public void OpenConnection()
    {
      _connCounter++;
      if (_connection.State == ConnectionState.Closed && _connCounter > 0)
      {
        _connection.Open();
      }
    }

    public IEnumerable<T> ExecuteQuery<T>(string sql, object param)
    {
      OpenConnection();
      IEnumerable<T> result = _connection.Query<T>(sql, param, Transaction);
      CloseConnection();

      return result;
    }

    public int Execute(string sql, object param)
    {
      OpenConnection();
      int result = _connection.Execute(sql, param, Transaction);
      CloseConnection();

      return result;
    }

    public void Update<T>(T obj) where T: ISQLMapper
    {
      DynamicParameters parameters = Convert(obj.UpdateStatement().Params.ToArray());
      Execute(obj.UpdateStatement().Query, parameters);

    }

    public void Dispose()
    {
      _connCounter = 0;
      if (_connection.State == ConnectionState.Open)
      {
        _connection.Close();
      }
    }

    private DynamicParameters Convert(IDbDataParameter[] parameters)
    {
      DynamicParameters dynParams = new DynamicParameters();
      foreach (IDbDataParameter parameter in parameters)
      {
        dynParams.Add(parameter.ParameterName.First().Equals("@") ? parameter.ParameterName : "@" + parameter.ParameterName,
          parameter.Value,
          parameter.DbType,
          parameter.Direction);
      }

       return dynParams;
    }
  }
}
