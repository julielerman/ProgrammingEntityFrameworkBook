﻿Imports System.Data.Entity.ModelConfiguration
Imports Model

Namespace DataAccess
  Public Class LodgingConfiguration
	  Inherits EntityTypeConfiguration(Of Lodging)
	Public Sub New()
      Me.Property(Function(l) l.Name).IsRequired().HasMaxLength(200)

      Me.Property(Function(l) l.Owner).IsUnicode(False)

      Me.Property(Function(l) l.MilesFromNearestAirport).HasPrecision(8, 1)

      Me.HasOptional(Function(l) l.PrimaryContact).WithMany(Function(p) p.PrimaryContactFor).HasForeignKey(Function(p) p.PrimaryContactId)

      Me.HasOptional(Function(l) l.SecondaryContact).WithMany(Function(p) p.SecondaryContactFor).HasForeignKey(Function(p) p.SecondaryContactId)

      Me.Property(Function(l) l.DestinationId).HasColumnName("destination_id")
	End Sub
  End Class
End Namespace