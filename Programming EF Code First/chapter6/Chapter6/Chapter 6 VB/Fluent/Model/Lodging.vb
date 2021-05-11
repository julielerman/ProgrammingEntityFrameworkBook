Namespace Model
  Public Class Lodging
	Public Property LodgingId() As Integer
	Public Property Name() As String
	Public Property Owner() As String
	Public Property MilesFromNearestAirport() As Decimal

	Public Property DestinationId() As Integer
	Public Property Destination() As Destination
	Public Property InternetSpecials() As List(Of InternetSpecial)
	Public Property PrimaryContactId() As Integer?
	Public Property PrimaryContact() As Person
	Public Property SecondaryContactId() As Integer?
	Public Property SecondaryContact() As Person
  End Class
End Namespace