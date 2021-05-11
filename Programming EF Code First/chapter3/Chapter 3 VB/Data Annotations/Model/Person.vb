Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class Person
	Public Sub New()
	  Address = New Address()
	  Info = New PersonalInfo With {.Weight = New Measurement(), .Height = New Measurement()}
	End Sub

	Public Property PersonId() As Integer
	<ConcurrencyCheck>
	Public Property SocialSecurityNumber() As Integer
	Public Property FirstName() As String
	Public Property LastName() As String
	Public Property Address() As Address
	Public Property Info() As PersonalInfo
  End Class
End Namespace
