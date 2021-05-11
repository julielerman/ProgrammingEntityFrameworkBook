using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;

namespace Chapter13SimplePOCO
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //LazyLoading();
            //QueryPOCOS();
            //BuildRelationshipsPOCOS();
            //VerifyVirtualChangeTracking();
            ForeignKeyNavigationFixUp();
            ForeignKeyNavigationFixUpReverse();
            FKFixUp();
            //FKNewObjects();
            //ObjectStateEntriesforPOCOS();
        }

        private static void LazyLoading()
        {
            using (var context = new Entities())
            {
                IQueryable<Contact> query = from c in context.Contacts where c.Addresses.Any() select c;
                List<Contact> contactList = query.ToList();
                Contact firstContact = contactList.First();
                foreach (Address a in firstContact.Addresses)
                {
                    Console.WriteLine(a.City);
                }
            }
        }

        private static void QueryPOCOS()
        {
            using (var context = new Entities())
            {
                IQueryable<Contact> query = from c in context.Contacts.Include("Addresses") select c;
                List<Contact> contactList = query.ToList();
                int contactCount = contactList.Count;
                Contact firstContact = contactList.Where(c => c.Addresses.Any()).First();
                int addressCount = firstContact.Addresses.Count;
            }
        }

        private static void BuildRelationshipsPOCOS()
        {
            using (var context = new Entities())
            {
                IQueryable<Contact> query = from c in context.Contacts.Include("Addresses") select c;
                List<Contact> contactList = query.ToList();
                int contactCount = contactList.Count();
                Contact firstContact = contactList.Where(c => c.Addresses.Any()).First();
                int addressCount = firstContact.Addresses.Count();
                var newaddress = new Address
                                     {
                                         Street1 = "1 Main Street",
                                         City = "Mainville",
                                         StateProvince = "Maine",
                                         ModifiedDate = DateTime.Now
                                     };
                newaddress.Contact = firstContact;
                firstContact.Addresses.Add(newaddress);
                addressCount = firstContact.Addresses.Count();
                context.DetectChanges();
                Contact newaddressContact = newaddress.Contact;
            }
        }

        private static void CheckObjectSet()
        {
            using (var context = new Entities())
            {
                IQueryable<Contact> query = from c in context.Contacts select c;
                List<Contact> contacts = query.ToList();
            }
        }

        //example 11-10
        private static void VerifyVirtualChangeTracking()
        {
            using (var context = new Entities())
            {
                Contact contact = context.Contacts.First();
                contact.LastName = "Zappos";
                contact.FirstName = "Zelly";
                int modifiedEntities = context.ObjectStateManager.
                    GetObjectStateEntries(EntityState.Modified).Count();
                ICollection<Address> addresses = contact.Addresses;
                //verify that modifiedEntities is 1 and that addresses is not null
                context.SaveChanges();
            }
        }


        
        private static void ForeignKeyNavigationFixUp()
        {
            using (var context = new Entities())
            {
                var address = context.CreateObject<Address>();
                //retrieve a random contact
                Contact contact = context.Contacts.FirstOrDefault();
                address.Contact = contact;
                context.DetectChanges();
                //if all of Address properties are virtual and at least COntact.Addresses is virtual,
                //then address.ContactID will automatically be synched
            }
        }


        private static void FKNewObjects()
        {
            using (var context = new Entities())
            {
                var address = context.CreateObject<Address>();
                //retrieve a random contact
                var contact = context.CreateObject<Contact>();
                address.Contact = contact;
                context.DetectChanges();
                //if all of Address properties are virtual and at least COntact.Addresses is virtual,
                //then address.ContactID will automatically be synched
            }
        }

        private static void FKFixUp()
        {
            using (var context = new Entities())
            {
                //random address
                Address address = context.Addresses.Where(a => a.City == "Winnipeg").FirstOrDefault();
                //retrieve a random contact
                Contact contact = context.Contacts.FirstOrDefault();
                //join them 
                //address.Contact = contact; //virtual?? then FKs and 2-way relationship fixed up here
                contact.Addresses.Add(address);
                context.DetectChanges(); //not virtual? Then you need DetectChanges
            }
        }

        private static void ForeignKeyNavigationFixUpReverse()
        {
            using (var context = new Entities())
            {
                var address = context.CreateObject<Address>();
                //var address = new Address();
                //retrieve a random contact
                Contact contact = context.Contacts.FirstOrDefault();
                contact.Addresses.Add(address);
                context.DetectChanges();
                //if all of Address properties are virtual and at least COntact.Addresses is virtual,
                //then address.ContactID will automatically be synched
            }
        }

        private static void ObjectStateEntriesforPOCOS()
        {
            using (var context = new Entities())
            {
                var address = context.CreateObject<Address>();
                //var address = new Address();
                //retrieve a random contact
                Contact contact = context.Contacts.FirstOrDefault();
                contact.Addresses.Add(address);
                ObjectStateEntry ose = context.ObjectStateManager.GetObjectStateEntry(contact);
                context.DetectChanges();
                //if all of Address properties are virtual and at least COntact.Addresses is virtual,
                //then address.ContactID will automatically be synched
            }
        }
    }
}