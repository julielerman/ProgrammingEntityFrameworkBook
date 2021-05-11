Imports System.Data.Entity
Namespace DataAccess
  Public Class PromptForDropCreateDatabaseWhenModelChages(Of TContext As DbContext)
	  Implements IDatabaseInitializer(Of TContext)
    Public Sub InitializeDatabase(ByVal context As TContext) Implements IDatabaseInitializer(Of TContext).InitializeDatabase
      ' If the database exists and matches the model
      ' there is nothing to do
      Dim exists = context.Database.Exists()
      If exists AndAlso context.Database.CompatibleWithModel(True) Then
        Return
      End If

      ' If the database exists and doesn't match the model
      ' then prompt for input
      If exists Then
        Console.WriteLine("Existing database doesn't match the model!")
        Console.Write("Do you want to drop and create the database? (Y/N): ")
        Dim res = Console.ReadKey()
        Console.WriteLine()
        If Not String.Equals("Y", res.KeyChar.ToString(), StringComparison.OrdinalIgnoreCase) Then
          Return
        End If
        context.Database.Delete()
      End If

      ' Database either didn't exist or it didn't match
      ' the model and the user chose to delete it
      context.Database.Create()
    End Sub

    
  End Class
End Namespace