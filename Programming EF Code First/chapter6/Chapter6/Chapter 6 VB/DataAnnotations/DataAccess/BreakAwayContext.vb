Imports System.Data.Entity
Imports Model
Imports System.Data.Common

Namespace DataAccess
  Public Class BreakAwayContext
	  Inherits DbContext
	Public Sub New()
	End Sub

	Public Sub New(ByVal databaseName As String)
		MyBase.New(databaseName)
	End Sub

	Public Sub New(ByVal connection As DbConnection)
		MyBase.New(connection, contextOwnsConnection:= False)
	End Sub

	Public Property Destinations() As DbSet(Of Destination)
	Public Property Lodgings() As DbSet(Of Lodging)
	Public Property Trips() As DbSet(Of Trip)
	Public Property People() As DbSet(Of Person)
  End Class
End Namespace