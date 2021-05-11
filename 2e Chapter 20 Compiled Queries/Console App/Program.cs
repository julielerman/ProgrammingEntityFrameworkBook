using System;
using System.Data.Objects;
using System.Linq;
using BAGA;


namespace Chapter20Console
{
  class Program
  {
    //when used in a service or web app, the static Func will be available across
    //different users as long as the service/web app is running.
    //In this console app, it will get run for each application process but you can
    //see the pattern
    static Func<BAEntities, string, IQueryable<Customer>> _customersFromCountry;

    static void Main()
    {
      InvokePreCompiledQuery();

    }



    private static void InvokePreCompiledQuery()
    {
      //only compile the query if it hasn't already been compiled. When it's been
      //compiled, the Func (_customersFromCountry) will NOT be null
      
      if (_customersFromCountry == null)
      {
        _customersFromCountry=CompiledQuery.Compile<BAEntities, string, IQueryable<Customer>>
                      ((BAEntities ctx, string dest) =>
                             from Customer c in ctx.Contacts.OfType<Customer>()
                             where c.Reservations.FirstOrDefault().Trip.Destination.Name == dest
                             select c);
      }
      
      var context = new BAEntities();
      var loc = "Malta";
      IQueryable<Customer> custs = _customersFromCountry.Invoke(context, loc);
      var custlist = custs.ToList();
      Console.WriteLine("{0} Customer Count = {1}", loc, custlist.Count);

      loc = "Vermont";
      custs = _customersFromCountry.Invoke(context, loc);
      custlist = custs.ToList();
      Console.WriteLine("{0} Customer Count = {1}", loc, custlist.Count);

      loc = "Australia";
      custs = _customersFromCountry.Invoke(context, loc);
      custlist = custs.ToList();
      Console.WriteLine("{0} Customer Count = {1}", loc, custlist.Count);

      Console.WriteLine("Press any key to continue....");
      Console.ReadKey();
    }


  }
}
