using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BAGA;

namespace Chapter17WCFServices
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface ICustomerService
  {
    [OperationContract]
    List<CustomerNameAndID> GetCustomerPickList();

    [OperationContract]
    List<Trip> GetUpcomingTrips();

    [OperationContract]
    Customer GetCustomer(int customerId);

    [OperationContract]
    string UpdateCustomer(CustomerUpdate customerUpdate);

    [OperationContract]
    string InsertCustomer(Customer customer);

    [OperationContract]
    string DeleteCustomer(int customerId);

    //[OperationContract]
    //string HelloWorld();
   
  }


 [DataContract()]
public class CustomerUpdate
{
  //private Customer _customer;
  //private List<int> _reservationsToDelete;

  [DataMember()]
  public BAGA.Customer Customer{ get; set; }
  //{
  //  get  {  return _customer;  }
  //  set  {  _customer = value; }
  //}

  [DataMember()]
  public List<int> ReservationsToDelete { get; set; }
  //{
  //  get {   return _reservationsToDelete;  }
  //  set {   _reservationsToDelete = value; }
  //}
}

}
