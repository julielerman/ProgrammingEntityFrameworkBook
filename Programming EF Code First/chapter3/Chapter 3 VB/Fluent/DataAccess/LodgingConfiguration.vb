Imports System.Data.Entity.ModelConfiguration
Imports Model

Namespace DataAccess
  Public Class LodgingConfiguration
	  Inherits EntityTypeConfiguration(Of Lodging)
	Public Sub New()
      Me.Property(Function(l) l.Name).IsRequired().HasMaxLength(200)

      Me.Property(Function(l) l.Owner).IsUnicode(False)

      Me.Property(Function(l) l.MilesFromNearestAirport).HasPrecision(8, 1)
	End Sub
  End Class
End Namespace