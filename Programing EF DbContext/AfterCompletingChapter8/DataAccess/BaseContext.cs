using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DataAccess
{
  public class BaseContext<TContext> : DbContext
    where TContext : DbContext
  {
    static BaseContext()
    {
      Database.SetInitializer<TContext>(null);
    }

    protected BaseContext()
      : base("name=breakaway")
    {
    }
  }
}
