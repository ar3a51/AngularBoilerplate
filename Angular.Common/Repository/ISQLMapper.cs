using System;
using System.Collections.Generic;
using System.Text;

namespace Angular.Common.Repository
{
  public interface ISQLMapper
  {
    SQLQuery InsertStatement();
    SQLQuery UpdateStatement();
  }
}
