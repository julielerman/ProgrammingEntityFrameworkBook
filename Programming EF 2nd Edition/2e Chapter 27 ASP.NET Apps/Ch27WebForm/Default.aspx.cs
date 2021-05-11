using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BAGA;

namespace Ch25WebForm
{
  public partial class _Default : System.Web.UI.Page
  {
    private readonly EntityManager mgr = new EntityManager();
    private int currentID = 570;
    protected void Page_Load(object sender, EventArgs e)
    {

      if (!IsDataBound)
      {
        BindCustomer();
        BindAddressesAndReservations();
      }
    }

    public bool IsDataBound
    {
      get
      {
        object o = ViewState["IsDataBound"];
        if (o == null) return false;
        else return (bool) o;
      }
      set
      {
        ViewState["IsDataBound"] = value;
      }
    }

    private void BindAddressesAndReservations()
    {
      ReservationsListView.DataSource = mgr.GetCustomerReservations(currentID);
      ReservationsListView.DataBind();
      AddressesListView.DataSource = mgr.GetCustomerAddresses(currentID);
      AddressesListView.DataBind();
      IsDataBound = true;
    }
    private void BindCustomer()
    {
      var cust = mgr.GetCustomer(currentID);
      //returns customer and addresses and reservations
      CustomerDetailsView.DataSource = new List<ProjectedCustomer> { cust };
      CustomerDetailsView.DataBind();
      IsDataBound = true;
    }
    protected void CustomerDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
      CustomerDetailsView.ChangeMode(e.NewMode);
      if (e.NewMode != DetailsViewMode.Insert)
      {
        BindCustomer();
      }

    }

    protected void CustomerDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
      //only send changed
      var title = e.NewValues["Title"] as string;
      var lastName = e.NewValues["LastName"] as string;
      var firstName = e.NewValues["FirstName"] as string;
      var birthday = Convert.ToDateTime(e.NewValues["BirthDate"]);
      var height = Convert.ToInt32(e.NewValues["HeightInches"]);
      var weight = Convert.ToInt32(e.NewValues["WeightPounds"]);
      var restrictions = e.NewValues["DietaryRestrictions"] as string;
      var activityId = Convert.ToInt32(((DropDownList)CustomerDetailsView.FindControl("act1DDL")).SelectedValue);
      var destinationId = Convert.ToInt32(((DropDownList)(CustomerDetailsView.FindControl("loc1DDL"))).SelectedValue);
      var activity2Id = Convert.ToInt32(((DropDownList)CustomerDetailsView.FindControl("act2DDL")).SelectedValue);
      var destination2Id = Convert.ToInt32(((DropDownList)(CustomerDetailsView.FindControl("loc2DDL"))).SelectedValue);

      mgr.UpdateCustomerProfile((int)e.Keys["ContactID"], title, lastName, firstName, birthday, height, weight, restrictions,
                                destinationId, activityId, destination2Id, activity2Id);

      CustomerDetailsView.ChangeMode(DetailsViewMode.ReadOnly);
      BindCustomer();

    }


    protected void CustomerDetailsView_PreRender(object sender, EventArgs e)
    {
      //needs to be in prerender and only when edit mode
      if (CustomerDetailsView.CurrentMode == DetailsViewMode.Edit)
      {

        var actList = mgr.GetActivityList();
        var destList = mgr.GetDestinationList();
        var cust = CustomerDetailsView.DataItem as ProjectedCustomer;

        var ddlA1 = (DropDownList)(CustomerDetailsView.FindControl("act1DDL"));
        var ddlA2 = (DropDownList)(CustomerDetailsView.FindControl("act2DDL"));
        var ddlL1 = (DropDownList)(CustomerDetailsView.FindControl("loc1DDL"));
        var ddlL2 = (DropDownList)(CustomerDetailsView.FindControl("loc2DDL"));
        BindPickList(ddlA1, actList, cust.PrimaryActivityID.Value, "ActivityID", "Name");
        BindPickList(ddlA2, actList, cust.SecondaryActivityID.Value, "ActivityID", "Name");
        BindPickList(ddlL1, destList, cust.PrimaryDestinationID.Value, "DestinationID", "Name");
        BindPickList(ddlL2, destList, cust.SecondaryDestinationID.Value, "DestinationID", "Name");
      }
    }
    private static void BindPickList(DropDownList ddl, IList list, int ddlValue, string idProp, string DisplayProp)
    {
      ddl.DataSource = list;
      ddl.DataTextField = DisplayProp;
      ddl.DataValueField = idProp;
      ddl.DataBind();
      ddl.SelectedValue = ddlValue.ToString();
    }

    protected void CustomerDetailsView_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {


    }

    protected void AddressesListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {

    }

    protected void AddressesListView_ItemEditing(object sender, ListViewEditEventArgs e)
    {

      AddressesListView.EditIndex = e.NewEditIndex;
      AddressesListView.DataSource = mgr.GetCustomerAddresses(currentID);
      AddressesListView.DataBind();

    }

    protected void AddressesListView_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
      var contactId = (int)CustomerDetailsView.DataKey["ContactID"];
      var street1 = e.Values["Street1"] as string;
      var street2 = e.Values["Street2"] as string;
      var city = e.Values["City"] as string;
      var state = e.Values["StateProvince"] as string;
      var country = e.Values["CountryRegion"] as string;
      var postal = e.Values["PostalCode"] as string;
      var type = e.Values["AddressType"] as string;
      mgr.InsertAddress(street1 as string, street2, city, state, country, postal, type, contactId);
      AddressesListView.EditIndex = -1;
      AddressesListView.DataSource = mgr.GetCustomerAddresses(currentID);
      AddressesListView.DataBind();
    }

    protected void AddressesListView_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
      //only send changed
      var contactId = (int)CustomerDetailsView.DataKey["ContactID"];
      var id = (int)AddressesListView.DataKeys[0].Value;
      var street1 = e.NewValues["Street1"];
      //var street2 = e.NewValues["Street2"]!=null ? e.NewValues["Street2"].ToString() : null;
      var street2 = e.NewValues["Street2"] as string;
      var city = e.NewValues["City"] as string;
      var state = e.NewValues["StateProvince"] as string;
      var country = e.NewValues["CountryRegion"] as string;
      var postal = e.NewValues["PostalCode"] as string;
      var type = e.NewValues["AddressType"] as string;
      mgr.UpdateAddress(id, street1 as string, street2, city, state, country, postal, type, contactId);
      AddressesListView.EditIndex = -1;
      AddressesListView.DataSource = mgr.GetCustomerAddresses(currentID);
      AddressesListView.DataBind();
    }

    protected void AddressesListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
      AddressesListView.EditIndex = -1;
      AddressesListView.DataSource = mgr.GetCustomerAddresses(currentID);
      AddressesListView.DataBind();
    }

    protected void AddressesListView_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
      var contactId = (int)CustomerDetailsView.DataKey["ContactID"];
      var id = (int)AddressesListView.DataKeys[0].Value;
      mgr.DeleteAddress(id, contactId);
      AddressesListView.DataSource = mgr.GetCustomerAddresses(currentID);
      AddressesListView.DataBind();
    }




  }
}
