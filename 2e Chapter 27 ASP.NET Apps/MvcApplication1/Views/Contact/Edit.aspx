<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BAGA.Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ContactID) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ContactID) %>
                <%= Html.ValidationMessageFor(model => model.ContactID) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.FirstName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.FirstName) %>
                <%= Html.ValidationMessageFor(model => model.FirstName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LastName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LastName) %>
                <%= Html.ValidationMessageFor(model => model.LastName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Title) %>
                <%= Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.AddDate) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.AddDate, String.Format("{0:g}", Model.AddDate)) %>
                <%= Html.ValidationMessageFor(model => model.AddDate) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ModifiedDate) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ModifiedDate, String.Format("{0:g}", Model.ModifiedDate)) %>
                <%= Html.ValidationMessageFor(model => model.ModifiedDate) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

