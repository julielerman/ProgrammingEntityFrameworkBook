using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAGA.Repository.Repositories;
using BAGA;

namespace Ch25WebForm
{

  public class EntityManager
  {
    //uow exists only for a single page instance

    readonly UnitOfWork _uow = new UnitOfWork();
    CustomerRepository _cRep;


    internal ProjectedCustomer GetCustomer(int contactId)
    {

      var cust = HttpContext.Current.Session["ProjectedCust" + contactId] as ProjectedCustomer;
      if (cust == null)
      {
        RetrieveAndStoreCustomerGraph(contactId);
        cust = HttpContext.Current.Session["ProjectedCust" + contactId] as ProjectedCustomer;
      }
      return cust;
    }

    internal List<Address> GetCustomerAddresses(int contactId)
    {
      var addList = HttpContext.Current.Session["CustAddresses" + contactId]; // as List<Address>;
      if (addList == null)
      {
        RetrieveAndStoreCustomerGraph(contactId);
        addList = HttpContext.Current.Session["CustAddresses" + contactId]; // as List<Address>;
      }
      return addList as List<Address>;

    }


    internal List<Reservation> GetCustomerReservations(int contactId)
    {
      var resList = HttpContext.Current.Session["CustReservations" + contactId]; // as List<Reservation>;
      if (resList == null)
      {
        RetrieveAndStoreCustomerGraph(contactId);
        resList = HttpContext.Current.Session["CustReservations" + contactId]; // as List<Reservation>;
      }

      return resList as List<Reservation>;
    }


    private void RetrieveAndStoreCustomerGraph(int contactId)
    {
      _cRep = new CustomerRepository(_uow);
      var cust = _cRep.CustomerAndReservationsAndAddresses(contactId);
      //var cust = _cRep.GetById(contactId);
      HttpContext.Current.Session["Cust" + contactId] = cust;
      HttpContext.Current.Session["CustAddresses" + contactId] = cust.Addresses.ToList();
      HttpContext.Current.Session["CustReservations" + contactId] = cust.Reservations.ToList();
      var projectedCust = _cRep.GetProjectedCustomerById(contactId);
      HttpContext.Current.Session["ProjectedCust" + contactId] = projectedCust;
    }

internal List<Activity> GetActivityList()
{
  return Lists.UntrackedList<Activity>(a => a.Name);
}

internal List<Destination> GetDestinationList()
{
  return Lists.UntrackedList<Destination>(d => d.Name);
}
internal void UpdateCustomerProfile(int contactId, string title, string lastName,
  string firstName, DateTime birthday, int height, int weight,
  string restrictions, int primaryDestinationId, int primaryActivityId,
  int secondaryDestinationId, int secondaryActivityId)
    {
      _cRep = new CustomerRepository(_uow);
      var origCust = HttpContext.Current.Session["Cust" + contactId] as Customer;
      _cRep.Attach(origCust);
     
      //TODO: test for origCust==null and deal with it if necessary

      //update only non-null fields from client
      if (title != origCust.Title)
        origCust.Title = title;
      if (lastName.Trim() != origCust.LastName)
        origCust.LastName = lastName;
      if (firstName != origCust.FirstName)
        origCust.FirstName = firstName;
      if (birthday != origCust.BirthDate)
        origCust.BirthDate = birthday;
      if (weight != origCust.WeightPounds)
        origCust.WeightPounds = weight;
      if (height != origCust.HeightInches)
        origCust.HeightInches = height;
      if (restrictions != origCust.DietaryRestrictions)
        origCust.DietaryRestrictions = restrictions;
      if (primaryDestinationId != origCust.PrimaryDestinationID)
        origCust.PrimaryDestinationID = primaryDestinationId;
      if (primaryActivityId != origCust.PrimaryActivityID)
        origCust.PrimaryActivityID = primaryActivityId;
      if (secondaryDestinationId != origCust.SecondaryDestinationID)
        origCust.SecondaryDestinationID = secondaryDestinationId;
        if (secondaryActivityId != origCust.SecondaryActivityID)
          origCust.SecondaryActivityID = secondaryActivityId;
  
      _uow.Save();
      RetrieveAndStoreCustomerGraph(contactId);
    }



internal void UpdateAddress(int id, string street1, string street2, string city, string state, string country, string postal, string type, int contactId)
{
  var aRep = new AddressRepository(_uow);
  var addresses = GetCustomerAddresses(contactId);
  var origAddress = addresses.First(a => a.addressID == id);
  aRep.Attach(origAddress);
  if (origAddress == null) return;
  //update only changed fields
  if (street1 != origAddress.Street1)
    origAddress.Street1 = street1;
  if (origAddress.Street2 != street2)
    origAddress.Street2 = street2;
  if (country != origAddress.CountryRegion)
    origAddress.CountryRegion = country;
  if (state != origAddress.StateProvince)
    origAddress.StateProvince = state;
  _uow.Save();
}


internal void InsertAddress(string street1, string street2, string city, string state, string country, string postal, string type, int contactId)
{
  var aRep = new AddressRepository(_uow);
  var address = new Address
                  {
                    Street1 = street1,
                    Street2 = street2,
                    City = city,
                    StateProvince = state,
                    CountryRegion = country,
                    ContactID = contactId,
                    PostalCode = postal,
                    AddressType = type
                  };
  aRep.Add(address);
  _uow.Save();
  RetrieveAndStoreCustomerGraph(contactId);
}
internal void DeleteAddress(int id, int contactId)
{
  var aRep = new AddressRepository(_uow);
  var addresses = GetCustomerAddresses(contactId);
  var origAddress = addresses.First(a => a.addressID == id);
  aRep.Delete(origAddress);
  _uow.Save();
  RetrieveAndStoreCustomerGraph(contactId);
}
  }
}