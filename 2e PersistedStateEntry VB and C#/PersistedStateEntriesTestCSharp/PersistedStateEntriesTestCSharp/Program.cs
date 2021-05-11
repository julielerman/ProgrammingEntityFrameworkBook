using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace PersistedStateEntriesTestCSharp
{
  class Program
  {
    List<PersistedStateEntry> _persistedEntriesList;
    static void Main(string[] args)
    {
    }
    private void SaveMyChanges(ObjectContext context)
    {
      if (_persistedEntriesList == null)
      {
        _persistedEntriesList = new List<PersistedStateEntry>();
        //be sure to destroy @this list when you are finished with it;
      }
      try
      {
        context.SaveChanges();
      }
      catch (OptimisticConcurrencyException ex)
      {
        var stateentries = ex.StateEntries;
        ObjectStateEntry conflictEntry = ex.StateEntries[0];

        if (!conflictEntry.IsRelationship)
        {
          //persist the entityentry
          var pEntry = new PersistedStateEntry
            (conflictEntry.EntityKey,
            conflictEntry.CurrentValues.DataRecordInfo,
            (IExtendedDataRecord)conflictEntry.OriginalValues,
             conflictEntry.Entity);

          pEntry.detachedEntity = conflictEntry.Entity;
          //store relationships before detaching entity;
          if (ex.StateEntries.Count > 1)
          {
            for (var i = 1; i < ex.StateEntries.Count; i++)
            {
              //ignore Unchanged relatoinship entries
              if (ex.StateEntries[i].State != EntityState.Unchanged)
                pEntry.AddRelationships(ex.StateEntries[i]);
            }
          }

          context.Detach(conflictEntry.Entity);
          _persistedEntriesList.Add(pEntry);

        }
        //then try again
        SaveMyChanges(context);
      }
      catch (Exception ex)
      {
        throw ex; //replace with proper exception handling 
      }
    }
  }
}
