using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using System.Xml.Linq;

namespace BAGA
{
  partial class BAPOCOs
  {
//    partial void  SetEventHandlers()
//{
//  this.SavingChanges+=new System.EventHandler(BAPOCOs_SavingChanges);
//}
    enum BACustomerTypes
    {
      Standard = 1,
      Silver = 2,
      Gold = 3
    }

    //partial void OnContextCreated()
    //{
    //  this.SavingChanges += new System.EventHandler(BAEntities_SavingChanges);
    //  this.ObjectMaterialized += new ObjectMaterializedEventHandler(BAEntities_ObjectMaterialized);
    //}
    
    
    
    private void BAPOCOs_SavingChanges(object sender, System.EventArgs e)
    {
      var osm = this.ObjectStateManager;
      //get New or Modified entries;
      foreach (var entry in osm.GetObjectStateEntries
      (EntityState.Added | EntityState.Modified))
      {
        if (entry.Entity is Contact)
        {
          var con = (Contact)entry.Entity;
          con.ModifiedDate = DateTime.Now; //replace with a db trigger?
          if (con.AddDate == DateTime.MinValue)
          { con.AddDate = DateTime.Now; }
        }
      }
    }
    public bool IsQueryExecuting { get; set; }

    public new int SaveChanges(System.Data.Objects.SaveOptions options)
    {
      return base.SaveChanges(options);
    }
  }
}
