Imports System.Data.Entity.ModelConfiguration
Imports Model

Namespace DataAccess
  Public Class DestinationConfiguration
	  Inherits EntityTypeConfiguration(Of Destination)
	Public Sub New()
      Me.Property(Function(d) d.Name).IsRequired()

      Me.Property(Function(d) d.Description).HasMaxLength(500)

      Me.Property(Function(d) d.Photo).HasColumnType("image")
	End Sub
  End Class
End Namespace