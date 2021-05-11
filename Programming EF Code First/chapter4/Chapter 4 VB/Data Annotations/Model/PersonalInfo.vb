Imports System.ComponentModel.DataAnnotations

Namespace Model
  <ComplexType>
  Public Class PersonalInfo
	Public Property Weight() As Measurement
	Public Property Height() As Measurement
	Public Property DietryRestrictions() As String
  End Class
End Namespace