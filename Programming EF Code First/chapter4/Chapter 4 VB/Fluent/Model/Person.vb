Namespace Model
  Public Class Person
	Public Sub New()
	  Address = New Address()
	  Info = New PersonalInfo With {.Weight = New Measurement(), .Height = New Measurement()}
	End Sub

	Public Property PersonId() As Integer
	Public Property SocialSecurityNumber() As Integer
	Public Property FirstName() As String
	Public Property LastName() As String
	Public Property Address() As Address
	Public Property Info() As PersonalInfo

	Public Property PrimaryContactFor() As List(Of Lodging)
	Public Property SecondaryContactFor() As List(Of Lodging)
	Public Property Photo() As PersonPhoto
  End Class
End Namespace
