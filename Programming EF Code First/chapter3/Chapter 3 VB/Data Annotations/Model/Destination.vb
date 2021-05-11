Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class Destination
	Public Property DestinationId() As Integer
	<Required>
	Public Property Name() As String
	Public Property Country() As String
	<MaxLength(500)>
	Public Property Description() As String
	<Column(TypeName := "image")>
	Public Property Photo() As Byte()

	Public Property Lodgings() As List(Of Lodging)
  End Class
End Namespace