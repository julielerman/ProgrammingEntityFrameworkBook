Imports System.Data.Entity.ModelConfiguration
Imports Model

Namespace DataAccess
  Public Class AddressConfiguration
	  Inherits ComplexTypeConfiguration(Of Address)
	Public Sub New()
      Me.Property(Function(a) a.StreetAddress).HasMaxLength(150)
	End Sub
  End Class
End Namespace