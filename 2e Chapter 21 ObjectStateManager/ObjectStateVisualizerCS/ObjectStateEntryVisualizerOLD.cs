using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Data.Objects;
using System.Data.Common;
using System.Windows.Forms;
using System.Data;
using EFExtensionMethods;

namespace ExtensionMethods
{
  public static class VisualizerOLD
  {

    public static void VisualizeObjectStateEntryOLD(this EntityKey eKey, ObjectContext context)
    {
      ObjectStateEntry ose = null;
      //If object is Detached, then there will be on Entry in the ObjectStateManager

      if (!(context.ObjectStateManager.TryGetObjectStateEntry(eKey, out ose)))
        MessageBox.Show("Object is not currently being change tracked and no ObjectStateEntry exists.", "ObjectStateEntryVisualizer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
          var sCurrVal = currentValues[i];
          object sOrigVal = null;
          if (originalValues == null)
            sOrigVal = "n/a"; //this will be for Added entities
          else
            sOrigVal = originalValues[i];
          string changedProp = (
                  from prop in ose.GetModifiedProperties()
                  where prop == sName
                  select prop).FirstOrDefault();

          string propModified;

          if (changedProp == null)
            propModified = "";
          else
            propModified = "X";
          valueArray.Add(new { _Index = i.ToString(), _Property = sName, Current = sCurrVal, Original = sOrigVal, ValueModified = propModified });
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

