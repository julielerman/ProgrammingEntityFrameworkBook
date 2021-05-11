using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using BAGA;
using POCO.State;

namespace BAGA.Repository.Interfaces
{
  public interface IContext
  {
    IObjectSet<Contact> Contacts { get; }
    IQueryable<Customer> Customers { get; }
    IObjectSet<Trip> Trips { get; }
    IObjectSet<Reservation> Reservations { get; }
    IObjectSet<Payment> Payments { get; }
    IObjectSet<ProjectedCustomer> ProjectedCustomers { get; }
    IObjectSet<Address> Addresses { get; }


    //IEnumerable<Reservation> ManagedReservations { get; }
    //IEnumerable<Contact> ManagedContacts { get; }

    ////logic for enabling precompiled linq queries
    //bool CanPreCompile { get; }
    //ObjectContext Compiler { get; }

    //void DetectChanges(); //used for ObjectContext detect changes or mock's fix-up mechanism
    string Save();
    void UpdateTrackedEntity<T>(T modifiedEntity) where T : class;
    void ChangeState<T>(POCO.State.State state,T entity) where T: class;
    IEnumerable<T> ManagedEntities<T>();
    bool ValidateBeforeSave(out string validationErrors);
  }
}
