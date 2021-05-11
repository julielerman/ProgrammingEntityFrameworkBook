Namespace Model
  Public Class Trip
	Public Property Identifier() As Guid
	Public Property StartDate() As Date
	Public Property EndDate() As Date
	Public Property CostUSD() As Decimal
	Public Property RowVersion() As Byte()
  End Class
End Namespace