Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class Activity
	Public Property ActivityId() As Integer
	<Required, MaxLength(50)>
	Public Property Name() As String
	Public Property Trips() As List(Of Trip)
  End Class
End Namespace