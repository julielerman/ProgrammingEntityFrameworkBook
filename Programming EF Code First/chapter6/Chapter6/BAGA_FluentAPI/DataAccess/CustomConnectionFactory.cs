using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
  public class CustomConnectionFactory : IDbConnectionFactory
  {
    public DbConnection CreateConnection(string nameOrConnectionString)
    {
      var name = nameOrConnectionString
        .Split('.').Last()
        .Replace("Context", string.Empty);

      var builder = new SqlConnectionStringBuilder
      {
        DataSource = @".\SQLEXPRESS",
        InitialCatalog = name,
        IntegratedSecurity = true,
        MultipleActiveResultSets = true
      };

      return new SqlConnection(builder.ToString());
    }
  }
}