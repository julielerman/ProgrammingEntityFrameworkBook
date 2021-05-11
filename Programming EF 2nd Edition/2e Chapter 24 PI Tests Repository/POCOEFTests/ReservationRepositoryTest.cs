using System.Linq;
using BAGA.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BAGA;
using System.Collections.Generic;


namespace POCOEFTests
{



  [TestClass()]
  public class ReservationRepositoryTest
  {



    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException),
                          "GetReservations for Customer allowed an ID<1")]
    public void Passing_ID_of_Zero_To_GetReservationsForCustomer_Throws()
    {
      var repository = new ReservationRepository(new FakeContext());
      int customerId = 0; //invalid id, should be >0
      repository.GetReservationsForCustomer(customerId);
    }

    [TestMethod()]
    public void Can_Pass_ID_Greater_Than_Zero_To_GetReservationsForCustomer()
    {
      var target = new ReservationRepository(new FakeContext());
      int customerId = 1; //valid id
      Assert.IsNotNull(target.GetReservationsForCustomer(customerId));
    }

    [TestMethod()]
    [DeploymentItem("Repositories.dll")]
    public void GetReservationsForCustomer_Method_Executes_with_Passed_In_Unit_of_Work()
    {
      var context = new FakeContext();
      var uow = new UnitOfWork(context);
      var target = new ReservationRepository(uow);
      int customerId = 20; //valid id
      IList<Reservation> actual = target.GetReservationsForCustomer(customerId);
      Assert.IsNotNull(actual);
    }

  

  }
}
