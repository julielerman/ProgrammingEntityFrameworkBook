Imports System.Data.Entity
Imports Model

Namespace DataAccess
  Public Class DropCreateBreakAwayWithSeedData
	  Inherits DropCreateDatabaseAlways(Of BreakAwayContext)
	Protected Overrides Sub Seed(ByVal context As BreakAwayContext)
	  context.Database.ExecuteSqlCommand("CREATE INDEX IX_Lodgings_Name ON Lodgings (Name)")

	  context.Destinations.Add(New Destination With {.Name = "Great Barrier Reef"})
	  context.Destinations.Add(New Destination With {.Name = "Grand Canyon"})
	End Sub
  End Class
End Namespace