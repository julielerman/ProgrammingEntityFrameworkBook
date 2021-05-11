using BAGA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace POCOEFTests
{
  
  [TestClass()]
  public class ReservationTest
  {


    private TestContext testContextInstance;

   
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

 
    [TestMethod()]
    public void PaymentStatus_Returns_UnPaid_When_There_Are_No_Payments()
    {
      //create a new reservation, new trip, new list of Payments
      var reservation = new Reservation();
      var trip =
        //bind the trip and payments to the reservation
      reservation.Trip = new Trip { TripCostUSD = 1000 };

      Assert.AreEqual(reservation.GetPaymentStatus(), Reservation.PaymentStatus.UnPaid);
    }

    [TestMethod()]
    public void PaymentStatus_Returns_PartiallyPaid_When_There_Are_Insufficient_Payments()
    {
      var reservation = new Reservation();
      reservation.Trip = new Trip { TripCostUSD = 1000 };
      reservation.Payments.Add(new Payment { Amount = 500 });
      Assert.AreEqual(reservation.GetPaymentStatus(),
                      Reservation.PaymentStatus.PartiallyPaid);

    }
  }
}
