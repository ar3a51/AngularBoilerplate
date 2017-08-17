using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Angular.Common.Repository
{
   public interface ITransaction
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
