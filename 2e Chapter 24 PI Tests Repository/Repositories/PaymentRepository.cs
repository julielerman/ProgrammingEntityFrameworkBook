using System;
using System.Collections.Generic;
using System.Linq;
using BAGA.Repository.Interfaces;

namespace BAGA.Repository.Repositories
{
  public class PaymentRepository: IEntityRepository<Payment>
  {

    private readonly IContext _context;

    public PaymentRepository(IContext context)
    {
      _context = context;
    }
    public PaymentRepository(UnitOfWork uow)
    {
      _context = uow.Context;
    }
    
    public Payment GetById(int id)
    {
        return _context.Payments
             .FirstOrDefault(r => r.PaymentID == id);
    }

    public void Add(Payment entity)
    {
        _context.Payments.AddObject(entity);
    }

    public void Delete(Payment entity)
    {
        _context.Payments.DeleteObject(entity);
    }

    public IList<Payment> All()
    {
        return _context.Payments.ToList();
    }

    public IList<Payment> GetPaymentsForReservation(int reservationId)
    {
      if (reservationId < 1)
      {
        throw new ArgumentOutOfRangeException();
      }
      return _context.Payments.
          Where(r => r.ReservationID == reservationId).ToList();
    }


    #region IEntityRepository<Payment> Members


    public void Attach(Payment entity)
    {
        _context.Payments.AddObject(entity);
    }

    #endregion
  }
}
