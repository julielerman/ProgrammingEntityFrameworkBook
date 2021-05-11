
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Runtime.CompilerServices
Imports System.Data.Metadata.Edm
Public Class PersistedStateEntry
  Private _eKey As EntityKey
  Private _detachedEntity As Object
  Private _origValues As Dictionary(Of String, Object)
  'string is property name, object is the value
  Private _RelationShips As List(Of RelationshipEnds)
  Private _message As String


  Public Sub New(ByVal ekey As EntityKey, _
                 ByVal recordInfo As Common.DataRecordInfo, _
                 ByVal origValues As IExtendedDataRecord, _
                 ByVal entity As Object, _
                 ByVal errorMessage As String)
    _eKey = ekey
    _detachedEntity = entity
    _origValues = New Dictionary(Of String, Object)
    _message = errorMessage
    For i = 0 To origValues.FieldCount - 1
      _origValues.Add(recordInfo.FieldMetadata.Item(i).FieldType.Name, _
                      origValues(i))
    Next
    _RelationShips = New List(Of RelationshipEnds)

  End Sub

  Public ReadOnly Property detachedEntity() As Object
    Get
      Return _detachedEntity
    End Get

  End Property

  Public Function NewEntityFromOrig(ByVal mdw As MetadataWorkspace) As EntityObject
    Dim newEntity = Activator.CreateInstance(_detachedEntity.GetType)
    Dim newEntityObj = CType(newEntity, DataClasses.EntityObject)
    newEntityObj.EntityKey = _eKey
    'use metadata and Reflection to populate entity 
    Dim etype = newEntity.GetType
    For Each p In etype.GetProperties
      'find the correct property in origvalues
      Dim origPropertyValue As New Object
      If _origValues.TryGetValue(p.Name, origPropertyValue) Then
        p.SetValue(newEntity, origPropertyValue, Nothing)
      Else

        If p.PropertyType.Name.StartsWith("EntityReference") Then
          'there is a "'1" in the propertytype.name
          Dim lastReference = p.Name.LastIndexOf("Reference")
          Dim entName = p.Name.Remove(lastReference)
          Dim entitySetName = mdw.GetEntitySetName(entName)
          Dim eref = CType(p.GetValue(newEntity, Nothing), EntityReference)

          'be sure that a deleted relationship is added before an added relationship
          For Each rel In _RelationShips
            If rel.CurrentEndA.EntitySetName = entitySetName Then
              'this is the entitykey we want, 
              'but we need to set entityreference.entitykey
              eref.EntityKey = rel.CurrentEndA
            ElseIf rel.CurrentEndB.EntitySetName = entitySetName Then
              eref.EntityKey = rel.CurrentEndB
            End If
          Next
          'find entitykey 
        End If
      End If

    Next
    'after this, the calling code needs to attach to context,
    ' then apply property changes using the detached entity
    Return CType(newEntity, DataClasses.EntityObject)

  End Function
  Public ReadOnly Property EntitySetName() As String
    Get
      Return _eKey.EntitySetName
    End Get
  End Property

  Public Sub AddRelationships(ByVal relEntry As ObjectStateEntry)
    Dim rEnds As New RelationshipEnds
    With rEnds
      .CurrentEndA = CType(relEntry.CurrentValues(0), EntityKey)
      .CurrentEndB = CType(relEntry.CurrentValues(1), EntityKey)
    End With
    _RelationShips.Add(rEnds)
  End Sub
  Private Structure RelationshipEnds
    Public CurrentEndA As EntityKey
    Public CurrentEndB As EntityKey
  End Structure


End Class
Module Extensions
  <Extension()> _
    Public Function GetEntitySetName(ByVal mdw As MetadataWorkspace, _
                                     ByVal entityName As String) As String
    'getting entity set name in order to use context.addobject
    Dim entContainer = mdw.GetItems(Of EntityContainer)(DataSpace.CSpace).First
    Dim entsets = From eset In entContainer.BaseEntitySets _
                  Where eset.ElementType.Name = entityName
    Return entsets.First.Name
  End Function
End Module