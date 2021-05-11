using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chapter12EDSv1
{
  public partial class HeierarchicalEDS : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ContactDataSource_Selected(object sender, EntityDataSourceSelectedEventArgs e)
    {
      var contact = e.Results.Cast<BAGA.Contact>();
      var res = contact.First().Customer.Reservations;
      if (res.Count > 0)
      {
        ListBox1.DataSource = res.ToList();
        ListBox1.DataTextField = "TripDetails";
        ListBox1.DataValueField = "ReservationID";
        ListBox1.DataBind();
        ListBox1.SelectedIndex = 0;
      }

    }

    protected void PaymentDataSource_Inserting(object sender, EntityDataSourceChangingEventArgs e)
    {
      var newPmnt = (BAGA.Payment)e.Entity;
      newPmnt.ReservationID = Convert.ToInt32(ListBox1.SelectedValue);

    }

    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}