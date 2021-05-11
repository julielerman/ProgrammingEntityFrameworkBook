<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EDSwithRelatedData.aspx.cs" Inherits="Chapter12EDSv1.EDSwithRelatedData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="EntityDataSource1" 
            DataKeyNames="ContactID">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="ContactID" HeaderText="ContactID" 
                    SortExpression="ContactID" />
                <asp:BoundField DataField="InitialDate" HeaderText="InitialDate" 
                    SortExpression="InitialDate" />
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
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Bind("PrimaryActivity.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("Contact.FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Contact.FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("Contact.LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Contact.LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Notes" 
                    HeaderText="Notes" SortExpression="Notes" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
            EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
            EnableUpdate="True" EntitySetName="Customers" Include="PrimaryActivity,Contact" 
            oncontextcreated="EntityDataSource1_ContextCreated"
            >
              
        </asp:EntityDataSource>
    
    </div>
    <asp:EntityDataSource ID="ActivityDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EntitySetName="Activities" OrderBy="it.Name">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="ContactDataSource" runat="server" 
        ConnectionString="name=BAEntities" DefaultContainerName="BAEntities" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Contacts" AutoGenerateWhereClause=true >
          <WhereParameters>
    <asp:ControlParameter
        ControlID="GridView1"
        Name="ContactID"
        PropertyName="SelectedValue"
        DbType="Int32" />
    </WhereParameters>

    </asp:EntityDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" 
        DataSourceID="ContactDataSource" Height="50px" Width="125px">
        <Fields>
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
    </form>
</body>
</html>
