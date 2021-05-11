using System.Collections.Generic;
using System.Linq;
using BAGA.Repository.Interfaces;



namespace BAGA.Repository.Repositories
{
 public class CustomerRepository: IEntityRepository<Customer>
  {
    private readonly IContext _context;

   
        public CustomerRepository(IContext context)
        {
            _context = context;
        }
    public CustomerRepository(UnitOfWork uow)
    {
      _context = uow.Context;
    }

    #region IEntityRepository<Customer> Members

    
    //public IContext Context
    //{
    //  get
    //  {
    //    return _context;
    //  }
      
    //}

    public Customer GetById(int id)
    {
      return _context.Customers
             .FirstOrDefault(c => c.ContactID == id);
    }
    public Customer CustomerAndReservations(int id)
    {
      return _context.Customers.Include("Reservations")
             .FirstOrDefault(c => c.ContactID == id);
    }
    public Customer CustomerAndReservationsAndAddresses(int id)
    {
      return _context.Customers.Include("Reservations.Trip.Destination").Include("Reservations.Payments").Include("Addresses")
             .FirstOrDefault(c => c.ContactID == id); //.Include("PrimaryDestination").Include("PrimaryActivity").Include("SecondaryDestination").Include("SecondaryActivity")
    }
public ProjectedCustomer GetProjectedCustomerById(int id)
{
  return _context.ProjectedCustomers.FirstOrDefault(c => c.ContactID == id);
}

   public void Add(Customer entity)
    {
     _context.Contacts.AddObject(entity);
    }

    public void Delete(Customer entity)
    {
      _context.Contacts.DeleteObject(entity);
    }

    public IList<Customer> All()
    {
      return _context.Customers.ToList();
    }
   public IList<Customer> CustomersWithReservations()
 {
   return _context.Customers.Where(c => c.Reservations.Where(r=>r.Payments.Any()).Any()).ToList();
 }

    #endregion

    #region IEntityRepository<Customer> Members


    public void Attach(Customer entity)
    {
      _context.Contacts.Attach(entity);
    }

    #endregion
   public void Update(Customer originalEntity,Customer modifiedEntity)
   {
     _context.Contacts.Attach(originalEntity);
     _context.UpdateTrackedEntity<Customer>(modifiedEntity);
    
   }
  }
}
