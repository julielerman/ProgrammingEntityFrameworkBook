using System;
using System.Linq;
using BAGA;
using System.Threading;

namespace Chapter20Threading
{
  public class EmailThreadClass
  {
    public void UpcomingTripEmails(object customer)
    {
      var cust = (Customer)customer;
      var anytrip = cust.Reservations
       .Where(r => r.Trip.StartDate > DateTime.Today.AddDays(6))
       .First().Trip;

      Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("            Dear " + cust.FirstName.Trim() +
         ", Your trip to " + anytrip.Destination.Name.Trim() +
       " begins on " + anytrip.StartDate +
        ". We look forward to seeing you soon.");
      Console.WriteLine();
    }

    public void NextWeek(object customer)
    {
      var cust = (Customer)customer;
      var anytrip = cust.Reservations
       .Where(r => r.Trip.StartDate <= DateTime.Today.AddDays(6))
      .First().Trip;

      Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("            Dear " + cust.FirstName.Trim() +
        ",  Your trip to " + anytrip.Destination.Name.Trim() +
        " begins in only a few days. Please let us know if " +
        " you have any last minute questions.");
      Console.WriteLine();
    }

    public void ComeBackEmails(object customer)
    {
      var cust = (Customer)customer;

      Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("            Dear " + cust.FirstName.Trim() +
        ", We haven't seen you in a while. We hope you'll consider" +
        "  BreakAway Geek Adventures for your next vacation.");
      Console.WriteLine();
    }

  }
}
