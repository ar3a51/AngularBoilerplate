using System;
using System.Collections.Generic;
using System.Text;

namespace Angular.Common.Repository
{
  public interface ISQLMapper
  {
    int Identity { set; }

    SQLQuery InsertStatement();
    SQLQuery UpdateStatement();
  }
}
