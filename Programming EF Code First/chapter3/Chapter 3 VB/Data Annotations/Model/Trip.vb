Imports System.ComponentModel.DataAnnotations

Namespace Model
  Public Class Trip
	<Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)>
	Public Property Identifier() As Guid
	Public Property StartDate() As Date
	Public Property EndDate() As Date
	Public Property CostUSD() As Decimal
	<Timestamp>
	Public Property RowVersion() As Byte()
  End Class
End Namespace