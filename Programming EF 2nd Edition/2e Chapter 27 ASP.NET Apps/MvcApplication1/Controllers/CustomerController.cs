using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAGA.Repository.Repositories;

namespace MvcApplication1.Controllers
{
    public class CustomerController : Controller
    {
      private readonly UnitOfWork _uow = new UnitOfWork();
      private CustomerRepository _cRepository;
      private ReservationRepository _rRepository;
      private PaymentRepository _pRespository;

      //
        // GET: /Customer/

        public ActionResult Index()
        {
            _cRepository = new CustomerRepository(_uow);
            return View(_cRepository.CustomersWithReservations());
        }

        public ActionResult Details(int id)
        {
            _cRepository = new CustomerRepository(_uow);
            return View(_cRepository.GetById(id));
            
        }

        public ActionResult Reservations(int customerId)
        {
            _rRepository = new ReservationRepository(_uow);
            return View(_rRepository.GetReservationsForCustomer(customerId));
        }

       
        public ActionResult ReservationPayments(int reservationId)
        {
            _pRespository = new PaymentRepository(_uow);
            return View(_pRespository.GetPaymentsForReservation(reservationId));

        }
        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Customer/Create

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
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5

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
    }
}
