using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAGA
{
  partial class Address
  {
    public bool Validate(out string validationError)
    {
      ModifiedDate = DateTime.Now;
      validationError = "";
      return true;
    }
  }
}
