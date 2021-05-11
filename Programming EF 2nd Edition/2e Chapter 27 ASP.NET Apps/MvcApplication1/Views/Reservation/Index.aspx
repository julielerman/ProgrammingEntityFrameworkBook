<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BAGA.Reservation>>" %>

<%@ Import Namespace="BAGA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
 <script>

     $(function () {
         $('.list-item').click(function () {
             $("#detail" + this.id).html(' ');
             $('#detail' + this.id).load('<%= Url.Action("ReservationPayments") %>', { ReservationId: this.id });
         });
     });
    </script>
    <style>
        .list-item { cursor: pointer; text-decoration: underline } 
    </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Reservations for: <%= Html.Encode(ViewData["custName"]) %></h2>
    <table>
        <tr>
            <th></th>
            <th>
                ReservationDate
            </th>
            <th>
                TripDetails
            </th>
        </tr>

    <% foreach (var item in ViewData["Model"] as List<Reservation>) { %>
    
        <tr>
            <td>
                 <div id="<%= item.ReservationID %>" href="#detail<%= item.ReservationID %>" class="list-item">Payments</div>
            </td>
            <td>
                <%: String.Format("{0:d}", item.ReservationDate) %>
            </td>
            <td>
                <%: item.TripDetails %>
            </td>
        </tr>
           <tr><th/><th colspan="5" id="detail<%= item.ReservationID %>"</th></tr>
    
    <% } %>

    </table>

    <p>
  
    </p>

</asp:Content>


