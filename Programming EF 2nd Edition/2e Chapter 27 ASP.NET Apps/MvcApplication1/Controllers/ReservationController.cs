using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAGA.Repository.Repositories;

namespace MvcApplication1.Controllers
{
  public class ReservationController : Controller
  {
    private readonly UnitOfWork _uow = new UnitOfWork();
    private ReservationRepository _rRepository;
    private PaymentRepository _pRespository;

    public ActionResult Index(int customerId, string name)
    {
      _rRepository = new ReservationRepository(_uow);
      ViewData.Add("custname", name);
      ViewData.Add("Model", _rRepository.GetReservationsForCustomer(customerId));

      return View();
    }

public ActionResult ReservationPayments(int reservationId)
{
  _pRespository = new PaymentRepository(_uow);
  return View(_pRespository.GetPaymentsForReservation(reservationId));
}

    //
    // GET: /Reservation/Create

    public ActionResult Create()
    {
      return View();
    }

    //
    // POST: /Reservation/Create

    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Reservation/Edit/5

    public ActionResult Edit(int id)
    {
      return View();
    }

    //
    // POST: /Reservation/Edit/5

    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Reservation/Delete/5

    public ActionResult Delete(int id)
    {
      return View();
    }

    //
    // POST: /Reservation/Delete/5

    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}
