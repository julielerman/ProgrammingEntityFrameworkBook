﻿Imports System.Data.Entity
Imports Model
Imports System.Data.Common

Namespace DataAccess
  Public Class BreakAwayContext
	  Inherits DbContext
	Public Sub New()
	End Sub

	Public Sub New(ByVal databaseName As String)
		MyBase.New(databaseName)
	End Sub

	Public Sub New(ByVal connection As DbConnection)
		MyBase.New(connection, contextOwnsConnection:= False)
	End Sub

	Public Property Destinations() As DbSet(Of Destination)
	Public Property Lodgings() As DbSet(Of Lodging)
	Public Property Trips() As DbSet(Of Trip)
	Public Property People() As DbSet(Of Person)

	Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
	  ' Entity Type Configuration
	  modelBuilder.Configurations.Add(New DestinationConfiguration())
	  modelBuilder.Configurations.Add(New LodgingConfiguration())
	  modelBuilder.Configurations.Add(New TripConfiguration())
	  modelBuilder.Configurations.Add(New PersonConfiguration())
	  modelBuilder.Configurations.Add(New InternetSpecialConfiguration())
	  modelBuilder.Configurations.Add(New ActivityConfiguration())
	  modelBuilder.Configurations.Add(New PersonPhotoConfiguration())
	  modelBuilder.Configurations.Add(New ReservationConfiguration())

	  ' Complex Type Configuration
	  modelBuilder.Configurations.Add(New AddressConfiguration())
	  modelBuilder.ComplexType(Of PersonalInfo)()
	End Sub
  End Class
End Namespace