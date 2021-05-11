using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chapter12EDSv1
{
  public partial class EDSwithRelatedData : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void EntityDataSource1_ContextCreated(object sender, EntityDataSourceContextCreatedEventArgs e)
    {
      var c = e.Context;
    }
  }
}