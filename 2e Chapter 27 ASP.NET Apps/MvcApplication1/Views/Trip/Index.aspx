<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BAGA.Trip>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                TripDetails
            </th>
            <th>
                TripID
            </th>
            <th>
                DestinationID
            </th>
            <th>
                LodgingID
            </th>
            <th>
                StartDate
            </th>
            <th>
                EndDate
            </th>
            <th>
                TripCostUSD
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.TripID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.TripID })%>
            </td>
            <td>
                <%= Html.Encode(item.TripDetails) %>
            </td>
            <td>
                <%= Html.Encode(item.TripID) %>
            </td>
            <td>
                <%= Html.Encode(item.DestinationID) %>
            </td>
            <td>
                <%= Html.Encode(item.LodgingID) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.StartDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.EndDate)) %>
            </td>
            <td>
                <%= Html.Encode(item.TripCostUSD) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

