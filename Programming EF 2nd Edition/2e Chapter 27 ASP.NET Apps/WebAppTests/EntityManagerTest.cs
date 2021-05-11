using Ch25WebForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace WebAppTests
{
    
    
    /// <summary>
    ///This is a test class for EntityManagerTest and is intended
    ///to contain all EntityManagerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class EntityManagerTest
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


    /// <summary>
    ///A test for UpdateCustomerProfile
    ///</summary>
    // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    // whether you are testing a page, web service, or a WCF service.
    [TestMethod()]
    [HostType("ASP.NET")]
    [AspNetDevelopmentServerHost("F:\\LCTP3Work\\Book Samples Second Edition\\Chapter 25\\Chapter25\\Ch25WebForm", "/")]
    [UrlToTest("http://localhost:18347/About.aspx")]
    [DeploymentItem("Ch25WebForm.dll")]
    public void UpdateCustomerProfileTest()
    {
      EntityManager_Accessor mgr = new EntityManager_Accessor(); // TODO: Initialize to an appropriate value
      int contactId = 570;
      var origCust=mgr.GetCustomer(contactId);
      string origLastName = origCust.LastName;
      var origActivityId = origCust.PrimaryActivityID;
      var origWeight = origCust.WeightPounds;
      origCust=null;
      string title = null;
      string lastName = null;
      string firstName = null;
      string birthday = null;
      string height = null;
      string weight = "215";
      string restrictions = null;
      string activityId = "15";
      string destinationId = null;
      mgr.UpdateCustomerProfile(contactId, title, lastName, firstName, birthday, height, weight, restrictions, destinationId, activityId,null,null);
      var cust = mgr.GetCustomer(contactId);
      Assert.AreEqual(cust.WeightPounds.ToString(), weight);
      Assert.AreEqual(cust.PrimaryActivityID.ToString(), activityId);
      Assert.AreEqual(cust.LastName, origLastName); //not edited
    }
  }
}
