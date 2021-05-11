Imports System.Data.Entity.ModelConfiguration
Imports Model

Namespace DataAccess
  Public Class DestinationConfiguration
	  Inherits EntityTypeConfiguration(Of Destination)
	Public Sub New()
      Me.Property(Function(d) d.DestinationId).HasColumnName("LocationID")

      Me.Property(Function(d) d.Name).IsRequired().HasColumnName("LocationName")

      Me.Property(Function(d) d.Description).HasMaxLength(500)

      Me.Property(Function(d) d.Photo).HasColumnType("image")

      Me.ToTable("Locations", "baga")

      Me.Ignore(Function(d) d.TodayForecast)
	End Sub
  End Class
End Namespace