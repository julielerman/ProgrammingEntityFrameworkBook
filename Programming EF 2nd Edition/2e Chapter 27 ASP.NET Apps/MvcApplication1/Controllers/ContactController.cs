using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAGA;
using BAGA.Repository.Repositories;

namespace MvcApplication1.Controllers
{
    public class ContactController : Controller
    {
      private readonly UnitOfWork _uow = new UnitOfWork();
      private ContactRepository _cRepository;
        //
        // GET: /Contact/

public ActionResult Index()
{
  _cRepository = new ContactRepository(_uow);
  return View(_cRepository.All());

  //var context = new BAGA.BAEntities();
  //return View(context.Contacts.ToList());
}

//
// GET: /Contact/Details/5

public ActionResult Details(int id)
{
  _cRepository = new ContactRepository(_uow);
  return View(_cRepository.GetById(id));
  //var context = new BAGA.BAEntities();
  //var contact = context.Contacts.SingleOrDefault(c => c.ContactID == id);

  //return View(contact);
  return null;
}

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Contact/Create

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
        // GET: /Contact/Edit/5
 
        public ActionResult Edit(int id)
        {
          _cRepository = new ContactRepository(_uow);
          return View(_cRepository.GetById(id)); 
        }

        //
        // POST: /Contact/Edit/5
[HttpPost]
public ActionResult Edit(int id, NonCustomer contact)
{
  try
  {
    _cRepository = new ContactRepository(_uow);
    _cRepository.Attach(contact);
    _uow.Save();
    return RedirectToAction("Index");
  }
  catch
  {
      return View(contact);
  }
}
        
      //[HttpPost]
        //public ActionResult Edit(int id, Customer contact)
        //{
        //    try
        //    {
        //      _cRepository = new ContactRepository(_uow);
        //      _cRepository.Add(contact);
        //      _uow.Save();
        //      return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(contact);
        //    }
        //}
        //[HttpPost]
        //public ActionResult Edit(int id, NonCustomer contact)
        //{
        //  try
        //  {
        //    _cRepository = new ContactRepository(_uow);
        //    _cRepository.Add(contact);
        //    _uow.Save();
        //    return RedirectToAction("Index");
        //  }
        //  catch
        //  {
        //    return View(contact);
        //  }
        //}
    }
}
