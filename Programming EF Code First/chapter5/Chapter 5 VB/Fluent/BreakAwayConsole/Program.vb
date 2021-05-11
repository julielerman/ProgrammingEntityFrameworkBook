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
	  Dim destination = New Destination With {.Country = "Indonesia", .Description = "EcoTourism at its best in exquisite Bali", .Name = "Bali"}

	  Using context = New BreakAwayContext()
		context.Destinations.Add(destination)
		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub InsertTrip()
	  Dim trip = New Trip With {.CostUSD = 800, .StartDate = New Date(2011, 9, 1), .EndDate = New Date(2011, 9, 14)}

	  Using context = New BreakAwayContext()
		context.Trips.Add(trip)
		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub InsertPerson()
	  Dim person = New Person With {.FirstName = "Rowan", .LastName = "Miller", .SocialSecurityNumber = 12345678, .Photo = New PersonPhoto With {.Photo = New Byte() { 0 }}}

	  Using context = New BreakAwayContext()
		context.People.Add(person)
		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub UpdateTrip()
	  Using context = New BreakAwayContext()
		Dim trip = context.Trips.FirstOrDefault()
		trip.CostUSD = 750
		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub UpdatePerson()
	  Using context = New BreakAwayContext()
		Dim person = context.People.Include("Photo").FirstOrDefault()
		person.FirstName = "Rowena"
		If person.Photo Is Nothing Then
		  person.Photo = New PersonPhoto With {.Photo = New Byte() { 0 }}
		End If

		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub DeleteDestinationInMemoryAndDbCascade()
	  Dim destinationId As Integer
	  Using context = New BreakAwayContext()
		Dim destination = New Destination With {.Name = "Sample Destination", .Lodgings = New List(Of Lodging) From {
			New Lodging With {.Name = "Lodging One"},
			New Lodging With {.Name = "Lodging Two"}}}

		context.Destinations.Add(destination)
		context.SaveChanges()
		destinationId = destination.DestinationId
	  End Using

	  Using context = New BreakAwayContext()
		Dim destination = context.Destinations.Single(Function(d) d.DestinationId = destinationId)

		context.Destinations.Remove(destination)
		context.SaveChanges()
	  End Using

	  Using context = New BreakAwayContext()
		Dim lodgings = context.Lodgings.Where(Function(l) l.DestinationId = destinationId).ToList()

		Console.WriteLine("Lodgings: {0}", lodgings.Count)
	  End Using
	End Sub

	Private Shared Sub InsertLodging()
	  Dim lodging = New Lodging With {.Name = "Rainy Day Motel", .Destination = New Destination With {.Name = "Seattle, Washington", .Country = "USA"}}

	  Using context = New BreakAwayContext()
		context.Lodgings.Add(lodging)
		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub InsertResort()
	  Dim resort = New Resort With {.Name = "Top Notch Resort and Spa", .MilesFromNearestAirport = 30, .Activities = "Spa, Hiking, Skiing, Ballooning", .Destination = New Destination With {.Name = "Stowe, Vermont", .Country = "USA"}}

	  Using context = New BreakAwayContext()
		context.Lodgings.Add(resort)
		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub InsertHostel()
	  Dim hostel = New Hostel With {.Name = "AAA Budget Youth Hostel", .MilesFromNearestAirport = 25, .PrivateRoomsAvailable = False, .Destination = New Destination With {.Name = "Hanksville, Vermont", .Country = "USA"}}
	  Using context = New BreakAwayContext()
		context.Lodgings.Add(hostel)
		context.SaveChanges()
	  End Using
	End Sub

	Private Shared Sub GetAllLodgings()
	  Dim context = New BreakAwayContext()
	  Dim lodgings = context.Lodgings.ToList()

	  For Each lodging In lodgings
		Console.WriteLine("Name: {0} Type: {1}", lodging.Name, lodging.GetType().ToString())
	  Next lodging
    End Sub

    Private Shared Sub UpdateDeleteDestination()
      Using context = New BreakAwayContext
        Dim destinations = context.Destinations.ToList()
        Dim destination = destinations(0)
        destination.Description += "Trust us, you'll love it!"
        context.SaveChanges()
        context.Destinations.Remove(destination)
        context.SaveChanges()
      End Using
    End Sub

  End Class
End Namespace
