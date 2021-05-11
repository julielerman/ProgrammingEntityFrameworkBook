Namespace Model
  Public Class Destination
	Public Property DestinationId() As Integer
	Public Property Name() As String
	Public Property Country() As String
	Public Property Description() As String
	Public Property Photo() As Byte()
	Public Property TravelWarnings() As String
	Public Property ClimateInfo() As String

	Public Property Lodgings() As List(Of Lodging)

	Private _todayForecast As String
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