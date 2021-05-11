<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<BAGA.Reservation>>" %>
 <script>

     function CollapseTable() {
         if (showhide.innerHTML=="hide")
         {
                  resTable.style.display = 'none';
                  showhide.innerHTML="show";
                  }
                  else{
                  resTable.style.display = '';
                  showhide.innerHTML="hide";
                  
                  }


     }
    </script>
<a id="showhide" onclick="CollapseTable();" >hide</a><br />
    <div id="resTable">
    <table >
        <tr>
            <th></th>
            <th>
                ReservationDate
            </th>
            <th>
                TripDetails
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
           
            <td>
                <%: String.Format("{0:d}", item.ReservationDate) %>
            </td>
          
            <td>
                <%: item.TripDetails %>
            </td>
        </tr>
    
    <% } %>

    </table>
    </div>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>


