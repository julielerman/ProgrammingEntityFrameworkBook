Imports System.ComponentModel.DataAnnotations

Namespace Model
  <Table("People")>
  Public Class PersonPhoto
	<Key, ForeignKey("PhotoOf")>
	Public Property PersonId() As Integer
	<Column(TypeName := "image")>
	Public Property Photo() As Byte()
	Public Property Caption() As String

	Public Property PhotoOf() As Person
  End Class
End Namespace