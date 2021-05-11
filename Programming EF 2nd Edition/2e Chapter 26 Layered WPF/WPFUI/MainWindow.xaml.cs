using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using BAGA;
using BAGA.DataLayer;
//using BAGA.Wrappers;



namespace BAGA.UI
{
public partial class MainWindow : Window
{
  private List<Trip> _trips;
  //private Trip _trip;
  private readonly DataBridge2 _bridge = new DataBridge2();
  private IEnumerable<Activity> _activities;
  private IEnumerable<Destination> _destinations;
  private IEnumerable<Lodging> _lodgings;

  public MainWindow()
  {
    InitializeComponent();
  }

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {

   
    ViewSource(ViewSources.tripViewSource).Source = _bridge.ObservableTrips;


    _destinations = _bridge.GetUntrackedList<Destination>(d => d.Name);
    ViewSource(ViewSources.destinationViewSource).Source = _destinations;
   
    _lodgings = _bridge.GetUntrackedList<Lodging>(l => l.LodgingName);
    ViewSource(ViewSources.lodgingViewSource).Source = _lodgings;

    _activities = _bridge.GetUntrackedList<Activity>(a => a.Name);
    activityComboBox.ItemsSource = _activities;
    
    EditSortDescriptions(SortAction.Add);

  }

  private void button1_Click(object sender, RoutedEventArgs e)
  {
    string saveMessages;
    if (!_bridge.SaveChanges(out saveMessages))
    {
      MessageBox.Show(saveMessages);
    }
  }
  private void btnAddActivity_Click(object sender, RoutedEventArgs e)
  {
    var selectedActivity = activityComboBox.SelectedItem as Activity;
    if (selectedActivity != null)
    {
      _bridge.TripBridge.AddActivity(selectedActivity);
      activitiesListBox.ItemsSource = _bridge.TripBridge.CurrentActivities; 
      // _bridge.AddTripActivity(_trip, selectedActivity);
    }
  }

  private void btnNewTrip_Click(object sender, RoutedEventArgs e)
  {
    Trip newTrip = _bridge.GetNewTrip();
    ViewSource(ViewSources.tripViewSource).Source = _bridge.ObservableTrips;       //shouldn't have to rebind an observable...
    tripListBox.SelectedItem = newTrip;
  }

  private void tripListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
  {
    //note removed Activities list box auto bindingfrom XAML
    //(ItemsSource="{Binding Source={StaticResource tripActivitiesViewSource}}" )
    //because i need to be sure the trip is attached to context before lazy loading kicks in
    //otherwise, lazy loaded activities will be no tracking entities and create issues later
    if (_trips == null)
    { _trips = _bridge.Trips; }

//    _bridge.TripBridge.CurrentTrip = (Trip)e.AddedItems[0];
    _bridge.TripBridge.TrackCurrent((Trip)e.AddedItems[0]);
    activitiesListBox.ItemsSource = _bridge.TripBridge.CurrentActivities;
   //_trip = (Trip)e.AddedItems[0];
   // _bridge.TrackChanges(_trip);
  }

enum SortAction
{
  Add = 1,
  Delete = 2
}
private void destinationComboBox_DropDownClosed(object sender, EventArgs e)
{
  //note, this code is slightly more advanced than the example in the book.
  //you'll find a note by Example 9-18 in the book explaining it's purpose 
  EditSortDescriptions(SortAction.Delete);
  EditSortDescriptions(SortAction.Add);
}

private void EditSortDescriptions(SortAction sortAction)
{
  var sortDestination = (new SortDescription("TripDetails", ListSortDirection.Ascending));
  var sortDate = (new SortDescription("StartDate", ListSortDirection.Descending));

  switch (sortAction)
  {
    case SortAction.Add:
      tripListBox.Items.SortDescriptions.Add(sortDestination);
      tripListBox.Items.SortDescriptions.Add(sortDate);
      break;
    case SortAction.Delete:
      if (tripListBox.Items.SortDescriptions.Contains(sortDate))
      {
        tripListBox.Items.SortDescriptions.Remove(sortDestination);
        tripListBox.Items.SortDescriptions.Remove(sortDate);
      }
      break;
    default:
      break;
  }
}

  private CollectionViewSource ViewSource(ViewSources source)
  {
    return FindResource(source.ToString()) as CollectionViewSource; 
  }


  private enum ViewSources
  {
    //enums named with lower case to match control names
    tripViewSource,
    destinationViewSource,
    lodgingViewSource
  }

  private void destinationComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
  {
   if (e.AddedItems.Count>0)
   { _bridge.TripBridge.SetCurrentDestination(e.AddedItems[0] as Destination); }

  }


}




}

