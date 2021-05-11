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
    enum BACustomerTypes
    {
      Standard = 1,
      Silver = 2,
      Gold = 3
    }


    partial void OnContextCreated()
    {
      this.SavingChanges += new System.EventHandler(BAEntities_SavingChanges);
      this.ObjectMaterialized += new ObjectMaterializedEventHandler(BAEntities_ObjectMaterialized);
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
      var osm = ObjectStateManager;
      //get New or Modified entries;
      foreach (var entry in osm.GetObjectStateEntries
      (EntityState.Added | EntityState.Modified))
      {
        if (entry.Entity is Contact)
        {
          var con = (Contact) entry.Entity;
          con.ModifiedDate = DateTime.Now; //replace with a db trigger?
          if (con.AddDate == DateTime.MinValue)
          {
            con.AddDate = DateTime.Now;
          }
        }
        if (entry.Entity is Address)
        {
          string invalidReason;
          if (((Address)entry.Entity).ValidateAddressForSave(out invalidReason) == false)
          {
            //address is invalid, reason is contained in invalidReason
          }
        }
      }

    }
    public bool IsQueryExecuting { get; set; }
//    public override int SaveChanges(System.Data.Objects.SaveOptions options)
//{

//    foreach (ObjectStateEntry entry in
//        ObjectStateManager.GetObjectStateEntries(
//        EntityState.Added | EntityState.Modified))
//    {

         
//     }
//    return base.SaveChanges(options);
//}



  }
}
