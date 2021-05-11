Namespace Model
  Public Class Destination
	Public Property DestinationId() As Integer
	Public Property Name() As String
	Public Property Country() As String
	Public Property Description() As String
	Public Property Photo() As Byte()
	Public Property Lodgings() As List(Of Lodging)
  End Class
End Namespace