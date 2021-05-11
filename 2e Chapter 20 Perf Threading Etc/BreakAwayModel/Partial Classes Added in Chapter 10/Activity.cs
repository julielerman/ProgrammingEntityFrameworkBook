using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAGA
{
    partial class Activity
    {
        partial void OnNameChanging(string value)
        {
            if (value.Length > 50)
                throw new InvalidOperationException
                    ("Activity Name must be less than 50 characters");
        }
        partial void OnNameChanged()
        {
            //add desired logic here
        }
    }
}
