using System.Collections.Generic;
using System.Linq;
using BAGA;
using BAGA.Repository.Interfaces;
using BAGA.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace POCOEFTests
{


  /// <summary>
  ///This is a test class for BAEntitiesTest and is intended
  ///to contain all BAEntitiesTest Unit Tests
  ///</summary>
  [TestClass()]
  public class BAEntitiesTest
  {


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
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

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion

 




    [TestMethod()]
public void Can_A_Contact_With_An_Address_EagerLoad()
{
  var context = new BAEntities();
  context.ContextOptions.LazyLoadingEnabled = false;
  var contact = context.Contacts.Include("Addresses").Where(c=>c.Addresses.Any()).FirstOrDefault();
  Assert.IsNotNull(contact);
  Assert.IsTrue(contact.Addresses.Count>0);
}

[TestMethod()]
[ExpectedException (typeof(ArgumentException),
                    "Last Name field is too long. Max length is 50.")]
 public void Setting_LastName_To_Greater_Than_50_Chars_Throws()
{
  new Customer {LastName = "x".PadLeft(51, '.')};
}

[TestMethod()]
public void Can_Set_LastName_to_50_Chars_or_Less()
{
  var expected = "x".PadLeft(40, '.');  //total length will be 40
  var item = new Customer { LastName = expected };
  Assert.AreEqual(expected, item.LastName);
}

    [TestMethod()]
public void UoW_with_Default_Context_Saves_To_and_Retrieves_from_Database()
{
  var uow = new UnitOfWork(); //defaults to BAEntities context
  var cRep = new CustomerRepository(uow);
  var rRep = new ReservationRepository(uow);
  var customer = cRep.GetById(20);
  var newNotes = DateTime.Now.ToString();
  customer.Notes = newNotes;
  var resCount = rRep.GetReservationsForCustomer(20).Count;
  var newRes = new Reservation
                 {
                   Customer = customer, TripID = 3, ReservationDate = new DateTime(2010, 10, 10)
                 };
  customer.Reservations.Add(newRes);
  uow.Save();
  uow = new UnitOfWork();
  cRep = new CustomerRepository(uow);
  rRep = new ReservationRepository(uow);
  customer = cRep.GetById(20);
  Assert.IsTrue(customer.Notes == newNotes);
  Assert.IsTrue(rRep.GetReservationsForCustomer(20).Count == resCount + 1);
}

[TestMethod()]
public void Validators_Return_True_and_Empty_ErrorString_With_Good_Data()
{
  var context = new FakeContext();
  string validationErrors = "";
  bool valid = context.ValidateBeforeSave(out validationErrors);
  Assert.IsTrue(valid);
  Assert.AreEqual(validationErrors, "");
}

[TestMethod()]
public void Validators_Return_False_and_NotEmpty_ErrorString_With_Bad_Data()
{
  var context = new FakeContextBadData();
  string validationErrors = "";
  bool valid = context.ValidateBeforeSave(out validationErrors);
  Assert.IsFalse(valid);
  Assert.AreNotEqual(validationErrors, "");
}
  }
}
