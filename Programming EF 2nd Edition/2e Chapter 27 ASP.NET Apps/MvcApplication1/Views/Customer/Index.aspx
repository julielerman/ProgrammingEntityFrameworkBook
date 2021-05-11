<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BAGA.Customer>>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
 <script>
   
      $(function () {
         $('.list-item').click(function () {
             $("#detail"+ this.id).html(' ');
             $('#detail'+ this.id).load('<%= Url.Action("Reservations") %>', { CustomerId: this.id,name: "Julie" });
         });
     });
    </script>
    <style>
        .list-item { cursor: pointer; } 
    </style> 
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

 
 
    <h2>Index</h2>

    <table >
        <tr>
            <th></th>
            <th>
                First
            </th>
            <th>Last</th>
            <th>
                InitialDate
            </th>
                      <th>
                Notes
            </th>
          
            <th>
                ContactID
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
             <%= Html.ActionLink("Reservations", "../Reservation/Index", new {customerId=item.ContactID,name=item.LastName + ", " +item.FirstName})%>
                 <div id="<%= item.ContactID %>" href="#detail<%= item.ContactID %>" class="list-item">Res</div>
            </td>
            <td>
                  <div id="<%= item.ContactID %>x" href="#detail" class="list-item"><%= item.FirstName %></div>
            </td>
            <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.InitialDate)) %>
            </td>
              <td>
                <%= Html.Encode(item.Notes) %>
            </td>
            <td>
                <%= Html.Encode(item.ContactID) %>
            </td>
        </tr>
        <tr><th colspan="6" id="detail<%= item.ContactID %>"</th></tr>
    
    <% } %>

    </table>
  <div id="detail"></div>

    <p>

        <%= Html.ActionLink("Create New", "Create") %>
    </p>

    </form>

</asp:Content>

