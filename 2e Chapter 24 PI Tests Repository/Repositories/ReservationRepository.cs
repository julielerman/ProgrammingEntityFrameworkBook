using System;
using System.Collections.Generic;
using System.Linq;
using BAGA.Repository.Interfaces;

namespace BAGA.Repository.Repositories
{
  public class ReservationRepository: IEntityRepository<Reservation>
  {

    private readonly IContext _context;

    public ReservationRepository(IContext context)
    {
      _context = context;
    }
    public ReservationRepository(UnitOfWork uow)
    {
      _context = uow.Context;
    }
    
    //public IContext Context
    //{
    //  get { return _context; }
    //}

    public Reservation GetById(int id)
    {
     return _context.Reservations
             .FirstOrDefault(r => r.ReservationID == id);
    }

    public void Add(Reservation entity)
    {
      _context.Reservations.AddObject(entity);
    }

    public void Delete(Reservation entity)
    {
      _context.Reservations.DeleteObject(entity);
    }

    public IList<Reservation> All()
    {
      return _context.Reservations.ToList();
    }

    public IList<Reservation> GetReservationsForCustomer(int? customerId)
    {
      if (!customerId.HasValue || customerId.Value < 1)
      {
        throw new ArgumentOutOfRangeException();
      }
      return _context.Reservations.Include("Trip.Destination")
          .Where(r => r.ContactID == customerId).ToList();
    }

    public IList<Reservation> GetReservationsWithPaymentsForCustomer(int customerId)
    {
        if (customerId < 1)
        {
            throw new ArgumentOutOfRangeException();
        }
        return _context.Reservations.Include("Payments")
            .Where(r => r.ContactID == customerId).ToList();
    }

    #region IEntityRepository<Reservation> Members


    public void Attach(Reservation entity)
    {
      _context.Reservations.AddObject(entity);
    }

    #endregion
  }
}
