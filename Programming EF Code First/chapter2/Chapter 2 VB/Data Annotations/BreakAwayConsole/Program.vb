Imports System.Text
Imports Model
Imports DataAccess
Imports System.Data.Entity

Namespace BreakAwayConsole
  Friend Class Program
	Shared Sub Main(ByVal args() As String)
	  Database.SetInitializer(New DropCreateDatabaseIfModelChanges(Of BreakAwayContext)())

	  InsertDestination()
	End Sub

	Private Shared Sub InsertDestination()
      Dim destination = New Destination With {
        .Country = "Indonesia",
        .Description = "EcoTourism at its best in exquisite Bali",
        .Name = "Bali"}

	  Using context = New BreakAwayContext()
		context.Destinations.Add(destination)
		context.SaveChanges()
	  End Using
	End Sub
  End Class
End Namespace
