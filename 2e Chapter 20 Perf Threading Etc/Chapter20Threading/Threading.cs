using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BAGA;
using Chapter20Threading;

namespace Chapter20Threading

{
  public class MyThreading
  {
    // Delegate that defines the signature for the callback method.
    public delegate void ContextCallback(List<Contact> contactList);
    private static List<Contact> _contacts;

    public static void Main()
    {
      ThreadingSampleOne();
      EmailThreadingSample();
    }

    private static void ThreadingSampleOne()
    {
      var occ =
        new ObjectContextClass(new ContextCallback(ResultCallback));
      var t = new Thread(occ.GetCustomers);
      t.Start();
      t.Join();
      Console.WriteLine("Retrieved: " + _contacts.Count.ToString());
      Console.WriteLine(_contacts[0].LastName + _contacts[0].ModifiedDate);
      _contacts[0].ModifiedDate = DateTime.Now;
      Console.WriteLine(_contacts[0].LastName + _contacts[0].ModifiedDate);
      t = new Thread(occ.SaveChanges);
      t.Start();
    }

    public static void ResultCallback(List<Contact> contactList)
    {
      _contacts = contactList;
    }

    public static void EmailThreadingSample()
    {
      var emailThread = new EmailThreadClass();
      using (var context = new BAEntities())
      {
        var custs =
            from cust in context.Contacts.OfType<Customer>()
             .Include("Reservations.Trip.Destination")
            select cust;
        foreach (var cust in custs)
        {
          if (cust.Reservations
              .Any(r => r.Trip.StartDate > DateTime.Today.AddDays(6)))
          {
            //new thread for upcoming trip emails
            var workerThread =
               new Thread(emailThread.UpcomingTripEmails);
            workerThread.Start(cust);
          }
          else if (cust.Reservations
            .Any(r => r.Trip.StartDate > DateTime.Today
                 & r.Trip.StartDate <= DateTime.Today.AddDays(6)))
          {
            //new thread for very soon trip emails
            var workerThread = new Thread(emailThread.NextWeek);
            workerThread.Start(cust);
          }
          else //no future trips
          {
            //new thread for no upcmoing trips emails
            var workerThread =
               new Thread(emailThread.ComeBackEmails);
            workerThread.Start(cust);
          }
        }
        Console.WriteLine("Complete...");
        Console.ReadKey();
      }
    }
  }
  }

  public class ObjectContextClass
  {
    private BAEntities _context;
    private List<Contact> _conList;
    // Delegate used to execute the callback method when the task is done.
    private readonly MyThreading.ContextCallback _callback;
    // The callback delegate is passed in to the constructor
    public ObjectContextClass(MyThreading.ContextCallback callbackDelegate)
    {
      _callback = callbackDelegate;
    }

    public void GetCustomers()
    {
      if (_context == null)
      {
        _context = new BAEntities();
      }
      //put a lock on the context during this operation;
      lock (_context)
      {
        var contactquery = from c in _context.Contacts
                           where c.LastName.StartsWith("S")
                           select c;
        _conList = contactquery.ToList();
      }
      if (_callback != null)
        _callback(_conList);
    }

    public void SaveChanges()
    {
      lock (_context)
      {
        _context.SaveChanges();
      }
    }
  }


