using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Angular.Common.Repository
{
    public class SQLQuery
    {
      public string Query;
      public List<IDbDataParameter> Params;
    }
}
