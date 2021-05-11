Imports System.Data.Entity.ModelConfiguration
Imports Model
Imports System.ComponentModel.DataAnnotations

Namespace DataAccess
  Public Class TripConfiguration
	  Inherits EntityTypeConfiguration(Of Trip)
	Public Sub New()
	  HasKey(Function(t) t.Identifier)

      Me.Property(Function(t) t.Identifier).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)

      Me.Property(Function(t) t.RowVersion).IsRowVersion()
	End Sub
  End Class
End Namespace
