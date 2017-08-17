using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Angular.Common.Repository
{
   public interface IDatabase
    {
      IDbTransaction Transaction { set; get; }

      IDbConnection Connection { get; }
      void OpenConnection();
      void Insert<T>(T obj) where T:ISQLMapper;
      void Update<T>(T obj) where T:ISQLMapper;
      void CloseConnection();

    IEnumerable<T> ExecuteQuery<T>(string sql, object param);
    int Execute(string sql, object param);

    }
}
