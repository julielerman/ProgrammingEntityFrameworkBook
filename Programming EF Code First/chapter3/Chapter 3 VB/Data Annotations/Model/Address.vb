Imports System.ComponentModel.DataAnnotations

Namespace Model
  <ComplexType>
  Public Class Address
	Public Property AddressId() As Integer
	<MaxLength(150)>
	Public Property StreetAddress() As String
	Public Property City() As String
	Public Property State() As String
	Public Property ZipCode() As String
  End Class
End Namespace