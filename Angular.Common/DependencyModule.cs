using Angular.Common.Repository;
using Autofac;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Angular.Common
{
  public class DependencyModule : Module
    {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register<IDbConnection>(db => new MySqlConnection("")).InstancePerRequest();

      builder.Register<IDatabase>(db => new DapperImpl(db.Resolve<IDbConnection>())).InstancePerLifetimeScope();
      builder.Register<ITransaction>(T => new TransactionImpl(T.Resolve<IDatabase>())).InstancePerLifetimeScope();
    }
  }
}
