Imports System.Data.Entity.ModelConfiguration
Imports Model
Imports System.ComponentModel.DataAnnotations

Namespace DataAccess
  Public Class PersonConfiguration
	  Inherits EntityTypeConfiguration(Of Person)
	Public Sub New()
      Me.Property(Function(p) p.SocialSecurityNumber).IsConcurrencyToken()
	End Sub
  End Class
End Namespace


