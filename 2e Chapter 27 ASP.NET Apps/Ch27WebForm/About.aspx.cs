using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch25WebForm
{
  public partial class About : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

      integTest();
    }

    private void integTest()
    {
      //var mgr = new EntityManager();
      //int contactId = 570;
      //var origCust = mgr.GetCustomer(contactId);
      //string origLastName = origCust.LastName;
      //origCust = null;
      //string title = null;
      //string lastName = null;
      //string firstName = null;
      //string birthday = null;
      //string height = null;
      //string weight = "226";
      //string restrictions = null;
      //string primDest=null;
      //string primActivity = "12";
      //mgr.UpdateCustomerProfile(contactId, title, lastName, firstName, birthday, height, weight, restrictions,primDest,primActivity);
      //var cust = mgr.GetCustomer(contactId);
    }
  }
}
