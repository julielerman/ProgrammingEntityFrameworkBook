<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<BAGA.Payment>>" %>
<script>
    function CollapseExpand() {
        if (ceLabel.innerHTML = "Collapse") {
            ResTable.style.display = "none";
            ceLabel.innerHTML = "Show";
        }
        else {
            ResTable.style.display = " ";
            ceLabel.innerHTML = "Collapse";
        }
    }
</script>
  <label id="ceLabel"  style="font-size:8pt; cursor:pointer; text-decoration:underline" onclick="CollapseExpand();">Collapse</label>
  <div id="ResTable">
    <table>
        <tr>
            <th></th>
            <th>
                PaymentDate
            </th>
            <th>
                Amount
            </th>
            <th>
                ModifiedDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new {  id=item.PaymentID  }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: String.Format("{0:d}", item.PaymentDate) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Amount) %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.ModifiedDate) %>
            </td>
        </tr>
    
    <% } %>

    </table>
        <div align="right" style="font-size:8pt"><%: Html.ActionLink("Create New", "Create") %></div>
    </div>


