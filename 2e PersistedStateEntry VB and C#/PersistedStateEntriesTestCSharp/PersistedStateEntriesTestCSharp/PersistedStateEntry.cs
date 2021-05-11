using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace PersistedStateEntriesTestCSharp
{
  public class PersistedStateEntry
  {
    public PersistedStateEntry(EntityKey ekey,
      System.Data.Common.DataRecordInfo recordInfo,
      IExtendedDataRecord origValues,
      object entity)
    {
    }
    public void AddRelationships(ObjectStateEntry relEntry)
    { }
    public object detachedEntity { get; set; }

    public System.Data.Objects.DataClasses.EntityObject NewEntityFromOrig(System.Data.Metadata.Edm.MetadataWorkspace mdw)
    {
      return null;
    }
  }
}
