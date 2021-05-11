using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter13SimplePOCO
{
    public class Address
    {

        public int addressID { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string CountryRegion { get; set; }

        public string PostalCode { get; set; }

        public string AddressType { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ContactID { get; set; }


#if false
        public virtual Contact Contact { get; set; }
#endif

#if true
        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set
            {
                _contact = value;
                //explicit relationship fixup
                _contact.AddAddress(this);
            }
        }
#endif

    }

}