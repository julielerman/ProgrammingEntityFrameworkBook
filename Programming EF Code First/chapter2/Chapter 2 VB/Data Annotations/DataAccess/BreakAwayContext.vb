Imports System.Data.Entity
Imports Model

Namespace DataAccess
  Public Class BreakAwayContext
	  Inherits DbContext
	Public Property Destinations() As DbSet(Of Destination)
	Public Property Lodgings() As DbSet(Of Lodging)
  End Class
End Namespace