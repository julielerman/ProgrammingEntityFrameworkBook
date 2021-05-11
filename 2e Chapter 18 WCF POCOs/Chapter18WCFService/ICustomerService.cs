using System.Collections.Generic;
using System.ServiceModel;
using BAGA;

namespace Chapter18WCFServicePOCO
{
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
    string SaveCustomer(Customer cust);
  
  }

}
