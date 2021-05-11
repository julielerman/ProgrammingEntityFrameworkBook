using System;
using System.Collections.Generic;
using System.Linq;
using BAGA.Repository.Interfaces;



namespace BAGA.Repository.Repositories
{
 public class ContactRepository: IEntityRepository<Contact>
  {
    private readonly IContext _context;

   
        public ContactRepository(IContext context)
        {
            _context = context;
        }
        public ContactRepository(UnitOfWork uow)
    {
      _context = uow.Context;
    }

        #region IEntityRepository<Contact> Members


        //public IContext Context
    //{
    //  get
    //  {
    //    return _context;
    //  }
      
    //}

        public Contact GetById(int id)
    {
      return _context.Contacts
             .FirstOrDefault(c => c.ContactID == id);
    }
    public Customer CustomerAndReservations(int id)
    {
      return _context.Customers.Include("Reservations")
             .FirstOrDefault(c => c.ContactID == id);
    }

    public void Add(Contact entity)
    {
     _context.Contacts.AddObject(entity);
    }
    public void Add(int id, string firstName,string lastName, DateTime addDate,byte[] rowVersion, String title)
    {
      var c = new NonCustomer
                {
                  ContactID=id,
                  FirstName=firstName,
                  LastName=lastName,
                  AddDate=addDate,
                  ModifiedDate=DateTime.Now,
                  RowVersion=rowVersion, 
                  Title=title
                };
      _context.Contacts.AddObject(c);
      
    }

    public void Delete(Contact entity)
    {
      _context.Contacts.DeleteObject(entity);
    }

    public IList<Contact> All()
    {
      return _context.Contacts.ToList();
    }

    #endregion

    #region IEntityRepository<Contact> Members


    public void Attach(Contact entity)
    {
      _context.Contacts.Attach(entity);
      _context.ChangeState<Contact>(POCO.State.State.Modified, entity);

    }

    #endregion
  }
}
