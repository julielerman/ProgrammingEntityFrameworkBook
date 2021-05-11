<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactsandCustomerInfo.aspx.cs" Inherits="Chapter12EDSv1.ContactsandCustomerInfo" %>

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
    
        Filter Contacts:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFilter" runat="server"></asp:TextBox>
    
        <asp:Button ID="Button1" runat="server" Text="Filter" />
    
    </div>
    <table class="style1">
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="ContactID" 
        DataSourceID="ContactDataSource" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="ContactID" HeaderText="ContactID" 
                SortExpression="ContactID" Visible="False" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="AddDate" DataFormatString="{0:d}" 
                HeaderText="AddDate" ReadOnly="True" SortExpression="AddDate" />
            <asp:BoundField DataField="ModifiedDate" DataFormatString="{0:d}" 
                HeaderText="ModifiedDate" ReadOnly="True" SortExpression="ModifiedDate" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
            </td>
            <td valign="top">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataSourceID="CustomerDataSource" Height="50px" Width="405px" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" DataKeyNames="ContactID">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            This contact is not a customer
        </EmptyDataTemplate>
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="ContactID" HeaderText="ContactID" 
                SortExpression="ContactID" Visible="False" ReadOnly="True" />
            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
            <asp:TemplateField HeaderText="Primary Dest" 
                SortExpression="PrimaryDestination">
                <EditItemTemplate>
                    <asp:DropDownList runat="server" id="dest1DDL"
                    DataSourceID="DestinationDataSource"
                    DataTextField="Name"
                    DataValueField="DestinationID"
                    SelectedValue=
                     '<%# Bind("PrimaryDestinationID") %>'>
  </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        Text='<%# Bind("PrimaryDestination.Name") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" 
                        Text='<%# Bind("PrimaryDestination.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Primary Activity" 
                SortExpression="PrimaryActivity">
                <EditItemTemplate>
                   <asp:DropDownList runat="server" id="act1DDL"
                    DataSourceID="ActivityDataSource"
                    DataTextField="Name"
                    DataValueField="ActivityID"
                    SelectedValue=
                     '<%# Bind("PrimaryActivityID") %>'>
  </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" 
                        Text='<%# Bind("PrimaryActivity.Name") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" 
                        Text='<%# Bind("PrimaryActivity.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="InitialDate" DataFormatString="{0:d}" 
                HeaderText="InitialDate" ReadOnly="True" SortExpression="InitialDate" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>
            </td>
        </tr>
    </table>
    <br />
    <asp:EntityDataSource ID="ContactDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Contacts">
    </asp:EntityDataSource>
    <asp:QueryExtender ID="QueryExtender1" runat="server" TargetControlID="ContactDataSource">
    <asp:SearchExpression SearchType="StartsWith" DataFields="LastName">
  <asp:ControlParameter ControlID="txtFilter" />
</asp:SearchExpression>
</asp:QueryExtender>
    <br />
    <asp:EntityDataSource ID="CustomerDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EnableUpdate="True" EntitySetName="Customers"
         AutoGenerateWhereClause=true Include="PrimaryActivity,PrimaryDestination">
           <WhereParameters>
    <asp:ControlParameter
        ControlID="GridView1"
        Name="ContactID"
        PropertyName="SelectedValue"
        DbType="Int32" />
    </WhereParameters>
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="ActivityDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EntitySetName="Activities">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="DestinationDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EntitySetName="Destinations">
    </asp:EntityDataSource>
    </form>
</body>
</html>
