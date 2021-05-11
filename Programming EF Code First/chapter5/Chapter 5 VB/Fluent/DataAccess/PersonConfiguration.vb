Imports System.Data.Entity.ModelConfiguration
Imports Model
Imports System.ComponentModel.DataAnnotations

Namespace DataAccess
  Public Class PersonConfiguration
	  Inherits EntityTypeConfiguration(Of Person)
	Public Sub New()
      Me.Property(Function(p) p.SocialSecurityNumber).IsConcurrencyToken()

      Me.Property(Function(p) p.Address.StreetAddress).HasColumnName("StreetAddress")

      Me.Property(Function(p) p.Address.City).HasColumnName("City")

      Me.Property(Function(p) p.Address.State).HasColumnName("State")

      Me.Property(Function(p) p.Address.ZipCode).HasColumnName("ZipCode")

      Me.ToTable("People")
	End Sub
  End Class
End Namespace