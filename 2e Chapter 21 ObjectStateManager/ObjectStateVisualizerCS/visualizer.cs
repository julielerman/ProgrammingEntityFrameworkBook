//Code Sample from Programming Entity Framework by Julia Lerman
//Chapter 20: Controlling Objects with ObjectStateManager and MetadataWorkspace
//ObjectStateEntry Visualizer Sample (CSharp)

using System;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Common;
using System.Windows.Forms;
using System.Data;
//using ExtensionMethods;

namespace EFExtensionMethods
{
  public static class Visualizer
  {

public static void VisualizeEntityState(this ObjectContext context,object entity)
{
  ObjectStateEntry ose = null;
  //If object is Detached, then there will be no Entry in the ObjectStateManager
  //new entities that are not attached will not even have an entitykey
  if (!context.ObjectStateManager.TryGetObjectStateEntry(entity, out ose))
    MessageBox.Show("Object is not currently being change tracked " +
      " and no ObjectStateEntry exists.",
      "ObjectState Visualizer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  else
  {
    var currentValues = ose.CurrentValues;
    //If Object is Added, there will be no Original values and it will throw an exception
    DbDataRecord originalValues = null;
    if (ose.State != EntityState.Added)
      originalValues = ose.OriginalValues;

    //walk through arrays to get the values
    var valueArray = new System.Collections.ArrayList();
    for (var i = 0; i < currentValues.FieldCount; i++)
    {

      //metadata provides field names
      var sName = currentValues.DataRecordInfo.FieldMetadata[i].FieldType.Name;
      bool isdbDataRecord = false;
      var sCurrVal = currentValues[i];
      object sOrigVal = null;

      //test for complex type
      if (currentValues[i] is DbDataRecord)
        isdbDataRecord = true;

      if (isdbDataRecord == false)
      {//normal scalar data
        sCurrVal = currentValues[i];
      }
      else
      {
        //complex type, anything else?
        sCurrVal = ComplexTypeString((DbDataRecord)currentValues[i]);
      }

      if (ose.State == EntityState.Added)
        sOrigVal = "n/a"; //this will be for Added entities
      else
        if (isdbDataRecord == false)
        {//normal scalar data
          sOrigVal = originalValues[i];
        }
        else
        {
          //complex type
          sOrigVal = ComplexTypeString((DbDataRecord)originalValues[i]);
        }
      string changedProp = (
              from prop in ose.GetModifiedProperties()
              where prop == sName
              select prop).FirstOrDefault();

      string propModified;

      if (changedProp == null)
        propModified = "";
      else
        propModified = "X";
      valueArray.Add(new {Index = i.ToString(), Property = sName,  
        Original = sOrigVal, Current = sCurrVal,ValueModified = propModified });
    }
    var form = new VisualizerForm();
    form.dataGridView1.DataSource = valueArray;
    form.lblState.Text = ose.State.ToString();
    form.lblType.Text = ose.Entity.ToString();
    form.ShowDialog();
  }
}

private static string ComplexTypeString(DbDataRecord item)
{
  var dbRecString = new StringBuilder();
  for (var i = 0; i < item.FieldCount; i++)
  {
    if (item[i] == DBNull.Value)
    {
      dbRecString.AppendLine("");
    }
    else
    {
      dbRecString.AppendLine((String)(item[i]));
    }
  }
  return dbRecString.ToString();
}


  }
}

