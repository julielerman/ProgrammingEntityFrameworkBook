Imports System.Data.Entity.ModelConfiguration
Imports Model
Imports System.ComponentModel.DataAnnotations

Namespace DataAccess
  Public Class PersonPhotoConfiguration
	  Inherits EntityTypeConfiguration(Of PersonPhoto)
	Public Sub New()
      Me.HasKey(Function(p) p.PersonId)

      Me.HasRequired(Function(p) p.PhotoOf).WithRequiredDependent(Function(p) p.Photo)

      Me.Property(Function(p) p.Photo).HasColumnType("image")

      Me.ToTable("People")
	End Sub
  End Class
End Namespace