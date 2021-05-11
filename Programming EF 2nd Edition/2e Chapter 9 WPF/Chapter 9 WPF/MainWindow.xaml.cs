using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BAGA;
using System.Linq;


namespace Chapter_9_WPF
{
    public partial class MainWindow : Window
    {

        private BAEntities context;
        private List<Activity> activities;
        private List<Destination> destinations;
        private List<Lodging> lodgings;
        //private List<Trip> trips;  //during the course of the chapter, we shifted from list to observablecollection
        private ObservableCollection<Trip> trips;


        enum SortAction
        {
            Add = 1,
            Delete = 2
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new BAEntities();
            activities = context.Activities.OrderBy(a => a.Name).ToList();
            destinations = context.Destinations.OrderBy(d => d.Name).ToList();
            lodgings = context.Lodgings.OrderBy(l => l.LodgingName).ToList();
            //trips = context.Trips.Include("Activities").OrderBy("it.Destination.Name").ToList();
            trips = new ObservableCollection<Trip>(
                  context.Trips.Include("Activities")
                               .OrderBy("it.Destination.Name"));

            System.Windows.Data.CollectionViewSource tripViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tripViewSource")));
            //// Load data by setting the CollectionViewSource.Source property:
            tripViewSource.Source = trips;
           
            System.Windows.Data.CollectionViewSource destinationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("destinationViewSource")));
            //// Load data by setting the CollectionViewSource.Source property:
            destinationViewSource.Source = destinations;

            System.Windows.Data.CollectionViewSource lodgingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lodgingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            lodgingViewSource.Source = lodgings;

            activityComboBox.ItemsSource = activities;
            EditSortDescriptions(SortAction.Add);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (validateNewTrips())
            {
              
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Changes not saved. You have one or more new trips that are not valid.");
            }
        }



        private void destinationComboBox_DropDownClosed(object sender, EventArgs e)
        {
            //note, this code is slightly more advanced than the example in the book.
            //you'll find a note by Example 9-18 in the book explaining it's purpose 
            EditSortDescriptions(SortAction.Delete);
            EditSortDescriptions(SortAction.Add);
        }

        private void EditSortDescriptions(SortAction a)
        {
            var sortDestination = (new SortDescription("Destination.Name", ListSortDirection.Ascending));
            var sortDate = (new SortDescription("StartDate", ListSortDirection.Descending));

            switch (a)
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

        private void btnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = activityComboBox.SelectedItem as Activity;
            if (selectedActivity != null)
            {
                var selectedTrip = tripListBox.SelectedItem as Trip;
                selectedTrip.Activities.Add(selectedActivity);
            }
        }

        private void btnNewTrip_Click(object sender, RoutedEventArgs e)
        {
            Trip newTrip = new Trip();

            newTrip.StartDate = DateTime.Today;
            newTrip.EndDate = DateTime.Today;

            //add to context for change tracking
            context.Trips.AddObject(newTrip);
            //add to observable collection of trips
            trips.Add(newTrip);
            tripListBox.SelectedItem = newTrip;

        }
        private bool validateNewTrips() //this is logic that should really be in a business layer. Remember this app is baby steps!
        {
            var newtrips = from t in trips.Where(t => t.TripID == 0) select t;
            foreach (var trip in newtrips)
            {
                if (trip.Lodging == null || trip.Destination==null)
                {
                    return false;
                }
                else if (trip.StartDate<DateTime.Today)
                {
                return false;
                }
                else if (trip.EndDate <trip.StartDate)
                {
                    return false;
                }
            }
            return true; //when new trips.COunt =0 or all trips validate
        }

    }




}

