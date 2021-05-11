using System.Linq;
using Chapter13SimplePOCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace TestProject1
{



    [TestClass()]
    public class AddressTest
    {



        //try this with virtual address.Contact uncommented and other address.Contact commented 
        //then switch those and run again.
        [TestMethod()]
        public void ContactTest()
        {
            var context = new Entities();
            var address = context.CreateObject<Address>();
            //retrieve a random contact
            var contact = context.Contacts.FirstOrDefault();
            address.Contact = contact;
            context.DetectChanges();
            Assert.AreEqual(address.ContactID, contact.ContactID);
        }
    }
}

