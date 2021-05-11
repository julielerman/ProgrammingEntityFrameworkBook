Imports System.Data.Entity.ModelConfiguration
Imports Model
Imports System.ComponentModel.DataAnnotations

Namespace DataAccess
  Public Class ActivityConfiguration
	  Inherits EntityTypeConfiguration(Of Activity)
	Public Sub New()
      Me.Property(Function(a) a.Name).IsRequired().HasMaxLength(50)
	End Sub
  End Class
End Namespace