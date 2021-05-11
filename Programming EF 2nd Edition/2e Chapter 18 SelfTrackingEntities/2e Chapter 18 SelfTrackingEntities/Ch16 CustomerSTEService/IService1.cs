using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BAGA;

namespace Ch16_CustomerSTEService
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface ICustomerSTEService
  {

    [OperationContract]
    List<CustomerNameAndID> GetCustomerPickList();

    [OperationContract]
    List<Trip> GetUpcomingTrips();

    [OperationContract]
    Customer GetCustomer(int custID);

    [OperationContract]
    string SaveCustomer(Customer cust);
  }


 
}
