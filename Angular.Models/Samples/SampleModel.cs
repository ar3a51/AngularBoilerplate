using System;
using System.Collections.Generic;
using Angular.Common.Repository;
using System.Data;
using System.Data.SqlClient;

namespace Angular.Models.Samples
{
  public class SampleModel : ISQLMapper
  {
    public string col1;
    public string col2;
    public string col3;

    public SQLQuery InsertStatement()
    {
      SQLQuery query = new SQLQuery();

      query.Query = @"
          INSERT INTO Sample
          VALUES (@col1, @col2, @col3);

          SELECT @ID = LAST_INSERT_ID(); 
      ";

      query.Params = new List<IDbDataParameter>() {
        new SqlParameter() { ParameterName = "@col1", Value = col1, DbType=DbType.String, Direction = ParameterDirection.Input },
        new SqlParameter() { ParameterName = "@col2", Value = col2, DbType=DbType.String, Direction = ParameterDirection.Input },
        new SqlParameter() { ParameterName = "@col3", Value = col3, DbType=DbType.String, Direction = ParameterDirection.Input },
        new SqlParameter() { ParameterName = "@ID", DbType = DbType.Int32, Direction = ParameterDirection.Output}
      };
      
      return query;
    }

    public SQLQuery UpdateStatement()
    {
      SQLQuery query = new SQLQuery();

      query.Query = @"";

      return query;
    }
  }
}
