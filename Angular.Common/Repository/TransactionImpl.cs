using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace Angular.Common.Repository
{
  public class TransactionImpl : ITransaction, IDisposable
  {
    private IDatabase _connection;
   
    
      public TransactionImpl(IDatabase connection)
      {
      _connection = connection;
      }

    public void BeginTransaction()
    {
      _connection.OpenConnection();

      if (_connection.Transaction == null)
        _connection.Transaction = _connection.Connection.BeginTransaction();
      

    }

    public void Commit()
    {
      if (_connection.Transaction != null)
        _connection.Transaction.Commit();

      _connection.CloseConnection();
      _connection.Transaction = null;
    }

    public void Rollback()
    {
      if (_connection.Transaction != null)
      {
        _connection.Transaction.Rollback();
      }

      _connection.Transaction = null;
    }

    public void Dispose()
    {
      _connection.Transaction = null;
    }
  }
}
