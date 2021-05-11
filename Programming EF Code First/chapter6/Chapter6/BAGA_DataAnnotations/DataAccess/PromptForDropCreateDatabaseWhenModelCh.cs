using System;
using System.Data.Entity;
namespace DataAccess
{
  public class PromptForDropCreateDatabaseWhenModelChages<TContext>
  : IDatabaseInitializer<TContext>
  where TContext : DbContext
  {
    public void InitializeDatabase(TContext context)
    {
      // If the database exists and matches the model
      // there is nothing to do
      var exists = context.Database.Exists();
      if (exists && context.Database.CompatibleWithModel(true))
      {
        return;
      }

      // If the database exists and doesn't match the model
      // then prompt for input
      if (exists)
      {
        Console.WriteLine
        ("Existing database doesn't match the model!");
        Console.Write
        ("Do you want to drop and create the database? (Y/N): ");
        var res = Console.ReadKey();
        Console.WriteLine();
        if (!String.Equals(
        "Y",
        res.KeyChar.ToString(),
        StringComparison.OrdinalIgnoreCase))
        {
          return;
        }
        context.Database.Delete();
      }

      // Database either didn't exist or it didn't match
      // the model and the user chose to delete it
      context.Database.Create();
    }
  }
}