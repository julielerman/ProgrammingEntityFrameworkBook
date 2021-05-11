Imports System.Data.Entity
Imports Model

Namespace DataAccess
  Public Class BreakAwayContext
	  Inherits DbContext
	Public Property Destinations() As DbSet(Of Destination)
	Public Property Lodgings() As DbSet(Of Lodging)

	Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
	  modelBuilder.Configurations.Add(New DestinationConfiguration())
	  modelBuilder.Configurations.Add(New LodgingConfiguration())
	End Sub
  End Class
End Namespace