Imports System.ComponentModel.DataAnnotations

Namespace Model
  <Table("Locations", Schema := "baga")>
  Public Class Destination
	<Column("LocationID")>
	Public Property DestinationId() As Integer
	<Required, Column("LocationName"), MaxLength(200)>
	Public Property Name() As String
	Public Property Country() As String
	<MaxLength(500)>
	Public Property Description() As String
	<Column(TypeName := "image")>
	Public Property Photo() As Byte()
	Public Property TravelWarnings() As String
	Public Property ClimateInfo() As String

	Public Property Lodgings() As List(Of Lodging)

	Private _todayForecast As String
	<NotMapped>
	Public Property TodayForecast() As String
	  Get
		  Return _todayForecast
	  End Get
	  Set(ByVal value As String)
		  _todayForecast = value
	  End Set
	End Property
  End Class
End Namespace