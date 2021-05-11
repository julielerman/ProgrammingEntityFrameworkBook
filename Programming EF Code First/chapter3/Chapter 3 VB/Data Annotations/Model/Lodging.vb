Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class Lodging
	Public Property LodgingId() As Integer
	<Required, MaxLength(200), MinLength(10)>
	Public Property Name() As String
	Public Property Owner() As String
	Public Property IsResort() As Boolean
	Public Property MilesFromNearestAirport() As Decimal

	Public Property Destination() As Destination
  End Class
End Namespace