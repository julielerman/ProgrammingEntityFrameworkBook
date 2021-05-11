<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HeierarchicalEDS.aspx.cs" Inherits="Chapter12EDSv1.HeierarchicalEDS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <br />
    <table class="style1">
        <tr>
            <td style="font-family: Calibri" valign="top">
    
                <strong>Select a Customer</strong><br />
    
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="CustomerDataSource" DataTextField="Name" 
        DataValueField="ContactID" Height="20px" Width="226px" Font-Names="Calibri" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    
                <br />
                <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataSourceID="ContactDataSource" Height="50px" Width="230px" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Calibri" 
                    onpageindexchanging="DetailsView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="ContactID" HeaderText="ContactID" 
                SortExpression="ContactID" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="AddDate" HeaderText="AddDate" 
                SortExpression="AddDate" DataFormatString="{0:d}" />
            <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" 
                SortExpression="ModifiedDate" DataFormatString="{0:d}" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>
    
            </td>
            <td style="font-family: Calibri">
                <strong>Customer&#39;s Reservations<br />
                </strong>
    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="86px" Width="388px"></asp:ListBox>
                <br />
                <br />
                <br />
                <strong>Payments for Selected Reservation</strong><asp:ListView ID="ListView1" 
                    runat="server" DataKeyNames="PaymentID"
              DataSourceID="PaymentDataSource"
              InsertItemPosition="LastItem" Style="font-size: small" EnableTheming="True">
  <ItemTemplate>
    <tr style="">
     
      <td>
        <asp:Label ID="PaymentDateLabel" runat="server"
                   Text='<%# Eval("PaymentDate","{0:d}") %>' />
      </td>
      <td>
        <asp:Label ID="AmountLabel" runat="server"
                   Text='<%# Eval("Amount","{0:c}") %>' />
      </td> <td></td>
    </tr>
  </ItemTemplate>
  <InsertItemTemplate>
    <tr style="">
      
      <td>
        <asp:TextBox ID="PaymentDateTextBox" runat="server"
                     Text='<%# Bind("PaymentDate") %>' />
      </td>
      <td>
        <asp:TextBox ID="AmountTextBox" runat="server"
                     Text='<%# Bind("Amount") %>' />
      </td>
      <td>
        <asp:Button ID="InsertButton" runat="server"
                    CommandName="Insert" Text="Insert" />
        <asp:Button ID="CancelButton" runat="server"
                    CommandName="Cancel" Text="Clear" />
      </td>
    </tr>
  </InsertItemTemplate>
  <LayoutTemplate>
    <table id="Table1" runat="server">
      <tr id="Tr1" runat="server">
        <td id="Td1" runat="server">
          <table id="itemPlaceholderContainer" runat="server"
                 border="0" style="">
            <tr id="Tr2" runat="server" style="">
           
              <th id="Th2" runat="server">PaymentDate</th>
              <th id="Th3" runat="server">Amount</th>
                 <th id="Th1" runat="server"></th>
            </tr>
            <tr id="itemPlaceholder" runat="server"></tr>
          </table>
        </td>
      </tr>
      <tr id="Tr3" runat="server">
        <td id="Td2" runat="server" style=""></td>
      </tr>
    </table>
  </LayoutTemplate>
</asp:ListView>

            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:EntityDataSource ID="CustomerDataSource" runat="server" CommandText="SELECT  c.ContactID, TRIM(c.LastName) + &quot;, &quot; + c.FirstName AS Name
FROM BAEntities.Contacts AS c
WHERE c.Customer IS NOT NULL
ORDER BY Name" ConnectionString="name=BAEntities" 
        DefaultContainerName="BAEntities" EnableFlattening="False">
    </asp:EntityDataSource>
    <br />
    <asp:EntityDataSource ID="ContactDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EntitySetName="Contacts" 
        AutoGenerateWhereClause="true" Include="Customer.Reservations.Trip.Destination" 
        onselected="ContactDataSource_Selected">
      <WhereParameters>
    <asp:ControlParameter ControlID="DropDownList1" Name="ContactID"
        PropertyName="SelectedValue" DbType="Int32" />
  </WhereParameters>

    </asp:EntityDataSource>
    <br />

    <asp:EntityDataSource ID="PaymentDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EnableInsert="True" EntitySetName="Payments" 
        AutoGenerateWhereClause="True" oninserting="PaymentDataSource_Inserting">
        <WhereParameters>
   <asp:ControlParameter Name="ReservationID"
     ControlID="ListBox1" PropertyName="SelectedValue"
     DbType="Int32"
     DefaultValue="0" />
</WhereParameters>

    </asp:EntityDataSource>
    <br />
    <br />
    </form>
</body>
</html>
