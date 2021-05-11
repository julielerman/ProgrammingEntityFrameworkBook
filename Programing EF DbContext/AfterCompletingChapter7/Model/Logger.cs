using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public abstract class Logger
  {
    public DateTime LastModifiedDate { get; set; }
    public DateTime AddedDate { get; set; }

    public void UpdateModificationLogValues(bool isAdded)
    {
      if (isAdded)
      {
        AddedDate = DateTime.Now;
      }

      LastModifiedDate = DateTime.Now;
    }
  }
}
