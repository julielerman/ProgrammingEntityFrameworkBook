<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BAGA.Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ContactID</div>
        <div class="display-field"><%= Html.Encode(Model.ContactID) %></div>
        
        <div class="display-label">FirstName</div>
        <div class="display-field"><%= Html.Encode(Model.FirstName) %></div>
        
        <div class="display-label">LastName</div>
        <div class="display-field"><%= Html.Encode(Model.LastName) %></div>
        
        <div class="display-label">Title</div>
        <div class="display-field"><%= Html.Encode(Model.Title) %></div>
        
        <div class="display-label">AddDate</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.AddDate)) %></div>
        
        <div class="display-label">ModifiedDate</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:g}", Model.ModifiedDate)) %></div>
        
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.ContactID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

