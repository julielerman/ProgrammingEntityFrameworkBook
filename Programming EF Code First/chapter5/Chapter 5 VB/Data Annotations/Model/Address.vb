Imports System.ComponentModel.DataAnnotations

Namespace Model
  <ComplexType>
  Public Class Address
	Public Property AddressId() As Integer
	<MaxLength(150), Column("StreetAddress")>
	Public Property StreetAddress() As String
	<Column("City")>
	Public Property City() As String
	<Column("State")>
	Public Property State() As String
	<Column("ZipCode")>
	Public Property ZipCode() As String
  End Class
End Namespace