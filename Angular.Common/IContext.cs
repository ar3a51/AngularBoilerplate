using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Angular.Common.Repository;

namespace Angular.Common
{
    public interface IContext
    {
        ITransaction Transaction { set; get; }

        void SetContainer(IContainer container);

        IContainer Container { get; }
    }
}
