Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class InternetSpecial
	Public Property InternetSpecialId() As Integer
	Public Property Nights() As Integer
	Public Property CostUSD() As Decimal
	Public Property FromDate() As Date
	Public Property ToDate() As Date

	<ForeignKey("Accommodation")>
	Public Property AccommodationId() As Integer
	Public Property Accommodation() As Lodging
  End Class
End Namespace