using System;
using System.Collections.Generic;
using System.Linq;
using BAGA.Repository.Interfaces;



namespace BAGA.Repository.Repositories
{
 public class AddressRepository: IEntityRepository<Address>
  {
    private readonly IContext _context;

   
        public AddressRepository(IContext context)
        {
            _context = context;
        }
        public AddressRepository(UnitOfWork uow)
    {
      _context = uow.Context;
    }

        #region IEntityRepository<Address> Members


     

        public Address GetById(int id)
    {
      return _context.Addresses
             .FirstOrDefault(a=>a.addressID == id);
    }
    public Customer CustomerAndReservations(int id)
    {
      return _context.Customers.Include("Reservations")
             .FirstOrDefault(c => c.ContactID == id);
    }

    public void Add(Address entity)
    {
      _context.Addresses.AddObject(entity);
    }
   

    public void Delete(Address entity)
    {
      var mgdEntity = _context.ManagedEntities<Address>().Where(e => e.addressID == entity.addressID).FirstOrDefault();
      if (mgdEntity==null)
      {
        _context.Addresses.Attach(entity); }
      _context.Addresses.DeleteObject(entity);
    }

    public IList<Address> All()
    {
      return _context.Addresses.ToList();
    }


    public void Attach(Address entity)
    {
      _context.Addresses.Attach(entity);
      _context.ChangeState<Address>(POCO.State.State.Modified, entity);

    }

    #endregion
  }
}
