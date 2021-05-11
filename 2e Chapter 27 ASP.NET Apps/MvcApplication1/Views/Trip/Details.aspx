<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BAGA.Trip>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">TripDetails</div>
        <div class="display-field"><%= Html.Encode(Model.TripDetails) %></div>
        
        <div class="display-label">TripID</div>
        <div class="display-field"><%= Html.Encode(Model.TripID) %></div>
        
        <div class="display-label">DestinationID</div>
        <div class="display-field"><%= Html.Encode(Model.DestinationID) %></div>
        
        <div class="display-label">LodgingID</div>
        <div class="display-field"><%= Html.Encode(Model.LodgingID) %></div>
        
        <div class="display-label">StartDate</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.StartDate)) %></div>
        
        <div class="display-label">EndDate</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.EndDate)) %></div>
        
        <div class="display-label">TripCostUSD</div>
        <div class="display-field"><%= Html.Encode(Model.TripCostUSD) %></div>
        
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.TripID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

