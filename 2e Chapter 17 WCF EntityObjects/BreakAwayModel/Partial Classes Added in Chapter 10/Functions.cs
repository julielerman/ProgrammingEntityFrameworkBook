using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace BAGA
{
  public static class Functions
  {
    [EdmFunction("BAModel", "FullNameReverse")]
    public static string FullNameReverse(this Contact c)
    {
      throw new NotSupportedException
                ("This function can only be used in a query");
    }
    [EdmFunction("BAModel", "ufnLBtoKG")]
    public static int PoundToKilogram(Int32 pounds)
    {
      throw new NotSupportedException
                ("This function can only be used in a query");
    }
  }
}
