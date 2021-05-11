Imports System.Data.Entity.ModelConfiguration
Imports Model
Imports System.ComponentModel.DataAnnotations

Namespace DataAccess
  Public Class PersonPhotoConfiguration
	  Inherits EntityTypeConfiguration(Of PersonPhoto)
	Public Sub New()
	  HasKey(Function(p) p.PersonId)

	  HasRequired(Function(p) p.PhotoOf).WithRequiredDependent(Function(p) p.Photo)
	End Sub
  End Class
End Namespace