Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class Lodging
	Public Property LodgingId() As Integer
	<Required, MaxLength(200), MinLength(10)>
	Public Property Name() As String
	Public Property Owner() As String
	Public Property MilesFromNearestAirport() As Decimal

	<Column("destination_id")>
	Public Property DestinationId() As Integer
	Public Property Destination() As Destination
	Public Property InternetSpecials() As List(Of InternetSpecial)
	Public Property PrimaryContactId() As Integer?
	<InverseProperty("PrimaryContactFor"), ForeignKey("PrimaryContactId")>
	Public Property PrimaryContact() As Person
	Public Property SecondaryContactId() As Integer?
	<InverseProperty("SecondaryContactFor"), ForeignKey("SecondaryContactId")>
	Public Property SecondaryContact() As Person
  End Class
End Namespace