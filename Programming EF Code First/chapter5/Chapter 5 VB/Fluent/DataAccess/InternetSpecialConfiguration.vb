Imports System.Data.Entity.ModelConfiguration
Imports Model
Imports System.ComponentModel.DataAnnotations

Namespace DataAccess
  Public Class InternetSpecialConfiguration
	  Inherits EntityTypeConfiguration(Of InternetSpecial)
	Public Sub New()
	  HasRequired(Function(s) s.Accommodation).WithMany(Function(l) l.InternetSpecials).HasForeignKey(Function(s) s.AccommodationId)
	End Sub
  End Class
End Namespace