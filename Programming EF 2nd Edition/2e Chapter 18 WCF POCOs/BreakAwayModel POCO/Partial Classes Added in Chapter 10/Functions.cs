using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace BAGA
{
  public static class Functions
  {
    [EdmFunction("BAPOCOModel", "FullNameReverse")]
    public static string FullNameReverse(Contact c)
    {
      throw new NotSupportedException
                ("This function can only be used in a query");
    }
  }
}
