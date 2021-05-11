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

      Me.HasMany(Function(t) t.Activities).WithMany(Function(a) a.Trips).Map(Sub(c)
                                                                               c.ToTable("TripActivities")
                                                                               c.MapLeftKey("TripIdentifier")
                                                                               c.MapRightKey("ActivityId")
                                                                             End Sub)
	End Sub
  End Class
End Namespace