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


    string Save();
    void UpdateTrackedEntity<T>(T modifiedEntity) where T : class;
    void ChangeState<T>(POCO.State.State state,T entity) where T: class;
    IEnumerable<T> ManagedEntities<T>();
    bool ValidateBeforeSave(out string validationErrors);
  }
}
