Namespace Model
  Public Class Reservation
	Public Property ReservationId() As Integer
	Public Property DateTimeMade() As Date
	Public Property Traveler() As Person
	Public Property Trip() As Trip
	Public Property PaidInFull() As Date
  End Class
End Namespace