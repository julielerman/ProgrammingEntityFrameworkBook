Imports System.Data.Common
Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient

Namespace DataAccess
  Public Class CustomConnectionFactory
	  Implements IDbConnectionFactory
    Public Function CreateConnection(ByVal nameOrConnectionString As String) As DbConnection Implements IDbConnectionFactory.CreateConnection
      Dim name = nameOrConnectionString.Split("."c).Last().Replace("Context", String.Empty)

      Dim builder = New SqlConnectionStringBuilder With {.DataSource = ".\SQLEXPRESS", .InitialCatalog = name, .IntegratedSecurity = True, .MultipleActiveResultSets = True}

      Return New SqlConnection(builder.ToString())
    End Function

  End Class
End Namespace