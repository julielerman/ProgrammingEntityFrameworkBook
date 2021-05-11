using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Chapter8WindowsForm
{

  public partial class Form1 : Form
  {
    BAGA.BAEntities _context;
    List<BAGA.Activity> _activities;
    List<BAGA.Destination> _destinations;
    bool _adding;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      
      _context = new BAGA.BAEntities();
      //ORIGINAL query that gets changed later in the chapter
      //      List<BAGA.Customer> customers =
      //context.Customers.Include("Contact")
      //.Include("PrimaryActivity")
      //.Include("SecondaryActivity")
      //.Include("PrimaryDestination")
      //.Include("SecondaryDestination")
      //.Include("Reservations.Trip.Destination")
      //.ToList();
      _activities = _context.Activities.OrderBy(a => a.Name).ToList();
      _destinations = _context.Destinations.OrderBy(d => d.Name).ToList();
      activityBindingSource.DataSource = _activities;
      destinationBindingSource.DataSource = _destinations;
     List<BAGA.Customer> customers =
          _context.Customers.Include("Contact")
           .Include("Reservations.Trip").ToList();

      customerBindingSource.DataSource = customers;
      FillCombos();

    }

    private void reservationsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      {
        var gridView = (DataGridView)sender;
        foreach (DataGridViewRow row in gridView.Rows)
        {
          if (!row.IsNewRow)
          {
            var reservation = (BAGA.Reservation)(row.DataBoundItem);
            var trip = reservation.Trip;

            row.Cells[tripStartColumn.Index].Value = trip.StartDate.ToShortDateString();
            row.Cells[tripEndColumn.Index].Value = trip.EndDate.ToShortDateString();
            row.Cells[destinationColumn.Index].Value = trip.Destination.Name;
          }
        }
      }
    }


    private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
      //is EndEdit necessary any more? So far things are working well in my tests without it
      //customerBindingSource.EndEdit();
      _context.SaveChanges();
    }

    private void FillCombos()
    {
      activity1Combo.DisplayMember = "Name";
      activity1Combo.ValueMember = "ActivityID";
      activity1Combo.DataSource = _activities;
      activity1Combo.DataBindings.Add
       (new Binding("SelectedItem", customerBindingSource,
                   "PrimaryActivity", true));

      dest1Combo.DisplayMember = "Name";
      dest1Combo.ValueMember = "DestinationID";
      dest1Combo.DataSource = _destinations;
      dest1Combo.DataBindings.Add
       (new Binding("SelectedItem", customerBindingSource,
                   "PrimaryDestination", true));
    }

    private void customerBindingSource_AddingNew(object sender, AddingNewEventArgs e)
    {
      _adding = true;
    }

    private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
    {
      {
        if (_adding)
        {
          customerBindingSource.EndEdit();
          var newCust = (BAGA.Customer)customerBindingSource.Current;
          if (newCust.Contact == null)
          {
            newCust.Contact = new BAGA.Contact();
            newCust.Contact.ModifiedDate = DateTime.Now;
            newCust.Contact.AddDate = DateTime.Now;
          }
          newCust.InitialDate = DateTime.Now;
          //note that non-nullable CustomerTypeID is given a default value in the model definition
          _adding = false;
        }

      }
    }

    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
      throw new InvalidOperationException("Not Implemented");
    }
   
  }
}
