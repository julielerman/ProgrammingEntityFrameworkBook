using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using System.Xml.Linq;

namespace BAGA
{
  partial class BAEntities
  {
    enum BACustomerTypes  //just here to prove lack of enum support
    {
      Standard = 1,
      Silver = 2,
      Gold = 3
    }


    partial void OnContextCreated()
    {
      this.SavingChanges += BAEntities_SavingChanges;
      this.ObjectMaterialized += BAEntities_ObjectMaterialized;
    }

void BAEntities_ObjectMaterialized(object sender, ObjectMaterializedEventArgs args)
{
  if (args.Entity is Lodging)
  {
    Lodging lodging = (Lodging)args.Entity;
    lodging.Materialized();
  }
}
    public void BAEntities_SavingChanges(object sender, System.EventArgs e)
    {
      var osm = this.ObjectStateManager;
      //get Added | Modified entries;
      foreach (var entry in osm.GetObjectStateEntries
      (EntityState.Added | EntityState.Modified))
      {
        if (entry.Entity is Contact)
        {
          var con = (Contact)entry.Entity;
          con.ModifiedDate = DateTime.Now;
        }
        if (entry.Entity is Customer)
        {
          //following code would be used to set default FK if you are using entityobjects with no foreign keys as entity properties
          var cust = (Customer)entry.Entity;
          if (cust.CustomerTypeReference.EntityKey == null)
          {
            cust.CustomerTypeReference.EntityKey =
               new EntityKey("BAEntities.CustomerTypes", "CustomerTypeID", 1);  //enums not supported in EF

          }
        }
      }
    }
    public bool IsQueryExecuting { get; set; }

    //public override int SaveChanges(System.Data.Objects.SaveOptions options)
    //{
    //  return base.SaveChanges(options);
    //}
    public new int SaveChanges(System.Data.Objects.SaveOptions options)
    {
      return base.SaveChanges(options);
    }
  }
}
