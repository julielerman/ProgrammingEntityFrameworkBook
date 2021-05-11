Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class Lodging
	Public Property LodgingId() As Integer
	<Required, MaxLength(200), MinLength(10)>
	Public Property Name() As String
	Public Property Owner() As String
	Public Property IsResort() As Boolean
	Public Property MilesFromNearestAirport() As Decimal

	Public Property DestinationId() As Integer
	Public Property Destination() As Destination
	Public Property InternetSpecials() As List(Of InternetSpecial)
	<InverseProperty("PrimaryContactFor")>
	Public Property PrimaryContact() As Person
	<InverseProperty("SecondaryContactFor")>
	Public Property SecondaryContact() As Person
  End Class
End Namespace