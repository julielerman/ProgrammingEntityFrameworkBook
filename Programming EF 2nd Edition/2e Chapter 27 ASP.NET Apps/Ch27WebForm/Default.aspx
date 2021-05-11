<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Ch25WebForm._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:DetailsView ID="CustomerDetailsView" runat="server" 
                AutoGenerateRows="False" BorderColor="Black" BorderStyle="Solid" 
                BorderWidth="1px" CellPadding="4" CssClass="newStyle1" DataKeyNames="ContactID" 
                Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" 
                onitemupdated="CustomerDetailsView_ItemUpdated" onitemupdating="CustomerDetailsView_ItemUpdating" 
                onmodechanging="CustomerDetailsView_ModeChanging" onprerender="CustomerDetailsView_PreRender" 
                Width="500px">
                <FooterStyle BackColor="#CCCCFF" Font-Bold="True" ForeColor="White" />
                <CommandRowStyle BackColor="#CCCCFF" Font-Bold="False" Font-Names="Arial Black" 
                    ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="Black" Width="350px" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <Fields>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                        SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" 
                        SortExpression="LastName" />
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" 
                        SortExpression="BirthDate" />
                    <asp:BoundField DataField="HeightInches" HeaderText="HeightInches" 
                        SortExpression="HeightInches" />
                    <asp:BoundField DataField="WeightPounds" HeaderText="WeightPounds" 
                        SortExpression="WeightPounds" />
                    <asp:BoundField DataField="DietaryRestrictions" 
                        HeaderText="DietaryRestrictions" SortExpression="DietaryRestrictions" />
                    <asp:TemplateField HeaderText="Favorite Activity">
                        <EditItemTemplate>
                            <asp:DropDownList ID="act1DDL" runat="server" EnableViewState="true">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem,"PrimaryActivityName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="2nd Favorite Activity">
                        <EditItemTemplate>
                            <asp:DropDownList ID="act2DDL" runat="server" EnableViewState="true">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelAct2" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem,"SecondaryActivityName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Favorite Destination">
                        <EditItemTemplate>
                            <asp:DropDownList ID="loc1DDL" runat="server" EnableViewState="true">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelDest1" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem,"PrimaryDestinationName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="2nd Favorite Dest">
                        <EditItemTemplate>
                            <asp:DropDownList ID="loc2DDL" runat="server" EnableViewState="true">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelDest2" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem,"SecondaryDestinationName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Notes" SortExpression="Notes">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" height="200" 
                                Text='<%# Bind("Notes") %>' TextMode="MultiLine" width="300"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Notes") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="scrolling" Height="50px" />
                    </asp:TemplateField>
                </Fields>
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                    Wrap="False" />
                <EditRowStyle BackColor="#999999" Width="350px" />
                <AlternatingRowStyle BackColor="White" ForeColor="Black" />
                
<FooterTemplate>

<asp:ImageButton CommandName="Edit" Visible='<%#CustomerDetailsView.CurrentMode==DetailsViewMode.ReadOnly?true:false%>' runat="server" ImageUrl="~/assets/EditTableHS.png" ID="editButton" />
<asp:ImageButton CommandName="Update" Visible='<%#CustomerDetailsView.CurrentMode==DetailsViewMode.Edit?true:false%>' ImageUrl="~/assets/SaveHS.png" ID="Button4" runat="server" />
<asp:ImageButton CommandName="Cancel" Visible='<%#CustomerDetailsView.CurrentMode==DetailsViewMode.Edit?true:false%>'  ImageUrl="~/assets/edit_UndoHS.png" ID="Button5" runat="server"  />

</FooterTemplate>
            </asp:DetailsView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ListView ID="ReservationsListView" runat="server">
                <ItemTemplate>
                    <tr style="background-color: #F7F6F3;color: #333333;">
                        <td>
                            <asp:Label ID="ReservationDateLabel" runat="server" 
                                Text='<%#string.Format("{0:d}",Eval("ReservationDate"))%>' />
                        </td>
                        <td style="width:400">
                            <asp:Label ID="TripDetailsLabel" runat="server" 
                                Text='<%#Eval("TripDetails")%>' />
                        </td>
                        <td>
                            <asp:Label ID="BalanceDueLabel" runat="server" 
                                Text='<%#string.Format("{0:C}",Eval("BalanceDue"))%>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF;color: #284775;">
                        <td>
                            <asp:Label ID="ReservationDateLabel" runat="server" 
                                Text='<%#string.Format("{0:d}",Eval("ReservationDate"))%>' />
                        </td>
                        <td>
                            <asp:Label ID="TripDetailsLabel" runat="server" Text='<%#Eval("TripDetails")%>' 
                                Width="400" />
                        </td>
                        <td>
                            <asp:Label ID="BalanceDueLabel" runat="server" 
                                Text='<%#string.Format("{0:C}",Eval("BalanceDue"))%>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>
                    <table ID="Table1" runat="server" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>
                                No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table ID="Table2" runat="server">
                        <tr ID="Tr1" runat="server">
                            <td ID="Td1" runat="server">
                                <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr ID="Tr2" runat="server" style="background-color: #CCCCFF;color: #333333;">
                                        <th ID="Th1" runat="server">
                                            Date</th>
                                        <th ID="Th2" runat="server" style="width:400">
                                            Trip</th>
                                        <th ID="Th3" runat="server">
                                            Balance Due</th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:ListView ID="AddressesListView" runat="server" DataKeyNames="addressID" 
                GroupItemCount="3" InsertItemPosition="LastItem" 
                onitemcanceling="AddressesListView_ItemCanceling" onitemcommand="AddressesListView_ItemCommand" 
                onitemediting="AddressesListView_ItemEditing" oniteminserting="AddressesListView_ItemInserting" 
                onitemupdating="AddressesListView_ItemUpdating" 
                onitemdeleting="AddressesListView_ItemDeleting">
                <EmptyItemTemplate>
            <td id="Td2" runat="server" />
                </EmptyItemTemplate>
                <ItemTemplate>
                    <td ID="Td3" runat="server" style="background-color: #EFF3FB;color: #333333;" 
                        width="350">
                 <%--   addressID:
                    <asp:Label ID="addressIDLabel" runat="server" Text='<%#Eval("addressID")%>' />
                    <br />--%>
                        Street1:
                        <asp:Label ID="Street1Label" runat="server" Text='<%#Eval("Street1")%>' />
                    <br />
                        Street2:
                        <asp:Label ID="Street2Label" runat="server" Text='<%#Eval("Street2")%>' />
                    <br />
                        City:
                        <asp:Label ID="CityLabel" runat="server" Text='<%#Eval("City")%>' />
                    <br />
                        StateProvince:
                        <asp:Label ID="StateProvinceLabel" runat="server" 
                            Text='<%#Eval("StateProvince")%>' />
                    <br />
                        CountryRegion:
                        <asp:Label ID="CountryRegionLabel" runat="server" 
                            Text='<%#Eval("CountryRegion")%>' />
                    <br />
                        PostalCode:
                        <asp:Label ID="PostalCodeLabel" runat="server" Text='<%#Eval("PostalCode")%>' />
                    <br />
                        AddressType:
                        <asp:Label ID="AddressTypeLabel" runat="server" 
                            Text='<%#Eval("AddressType")%>' />
                    <br />
                        ModifiedDate:
                        <asp:Label ID="ModifiedDateLabel" runat="server" 
                            Text='<%#Eval("ModifiedDate")%>' />
                    <br />

                    <%--<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" 
                            ImageUrl="~/assets/EditTableHS.png" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" 
                            ImageUrl="~/assets/DeleteHS.png" />
                    <br />
                    </td>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <td ID="Td4" runat="server" style="background-color: #FFFFFF;color: #284775;" 
                        width="350">
                <%--    addressID:
                    <asp:Label ID="addressIDLabel" runat="server" Text='<%#Eval("addressID")%>' />
                    <br />--%>
                        Street1:
                        <asp:Label ID="Street1Label" runat="server" Text='<%#Eval("Street1")%>' />
                    <br />
                        Street2:
                        <asp:Label ID="Street2Label" runat="server" Text='<%#Eval("Street2")%>' />
                    <br />
                        City:
                        <asp:Label ID="CityLabel" runat="server" Text='<%#Eval("City")%>' />
                    <br />
                        StateProvince:
                        <asp:Label ID="StateProvinceLabel" runat="server" 
                            Text='<%#Eval("StateProvince")%>' />
                    <br />
                        CountryRegion:
                        <asp:Label ID="CountryRegionLabel" runat="server" 
                            Text='<%#Eval("CountryRegion")%>' />
                    <br />
                        PostalCode:
                        <asp:Label ID="PostalCodeLabel" runat="server" Text='<%#Eval("PostalCode")%>' />
                    <br />
                        AddressType:
                        <asp:Label ID="AddressTypeLabel" runat="server" 
                            Text='<%#Eval("AddressType")%>' />
                    <br />
                        ModifiedDate:
                        <asp:Label ID="ModifiedDateLabel" runat="server" 
                            Text='<%#Eval("ModifiedDate")%>' />
                    <br />

<%--                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
--%>                                        
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" 
                            ImageUrl="~/assets/EditTableHS.png" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" 
                            ImageUrl="~/assets/DeleteHS.png" />

                    <br />
                    </td>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>
                    <table ID="Table3" runat="server" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>
                                No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <td ID="Td5" runat="server" class="newstyle1" width="350">
                        Street1:
                        <asp:TextBox ID="Street1TextBox" runat="server" Text='<%#Bind("Street1")%>' />
                    <br />
                        Street2:
                        <asp:TextBox ID="Street2TextBox" runat="server" Text='<%#Bind("Street2")%>' />
                    <br />
                        City:
                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%#Bind("City")%>' />
                    <br />
                        St/Prov:
                        <asp:TextBox ID="StateProvinceTextBox" runat="server" 
                            Text='<%#Bind("StateProvince")%>' width="50" />
                    <br />
                        Country:
                        <asp:TextBox ID="CountryRegionTextBox" runat="server" 
                            Text='<%#Bind("CountryRegion")%>' />
                    <br />
                        PostalCode:
                        <asp:TextBox ID="PostalCodeTextBox" runat="server" 
                            Text='<%#Bind("PostalCode")%>' />
                    <br />
                        Type:
                        <asp:TextBox ID="AddressTypeTextBox" runat="server" 
                            Text='<%#Bind("AddressType")%>' />
                    <br />

                    <%--<asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Insert" 
                            ImageUrl="~/assets/NewDocumentHS.png" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Cancel" 
                            ImageUrl="~/assets/edit_UndoHS.png" />

                    <br />
                    </td>
                </InsertItemTemplate>
                <LayoutTemplate>
                    <table ID="Table4" runat="server">
                        <tr ID="Tr3" runat="server">
                            <td ID="Td6" runat="server">
                                <table ID="groupPlaceholderContainer" runat="server" border="1" 
                                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr ID="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr ID="Tr4" runat="server">
                            <td ID="Td7" runat="server" 
                                style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <EditItemTemplate>
                    <td ID="Td8" runat="server" style="background-color: #ECF2BF;">
                        Street1:
                        <asp:TextBox ID="Street1TextBox" runat="server" Text='<%#Bind("Street1")%>' />
                    <br />
                        Street2:
                        <asp:TextBox ID="Street2TextBox" runat="server" Text='<%#Bind("Street2")%>' />
                    <br />
                        City:
                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%#Bind("City")%>' />
                    <br />
                        StateProvince:
                        <asp:TextBox ID="StateProvinceTextBox" runat="server" 
                            Text='<%#Bind("StateProvince")%>' />
                    <br />
                        CountryRegion:
                        <asp:TextBox ID="CountryRegionTextBox" runat="server" 
                            Text='<%#Bind("CountryRegion")%>' />
                    <br />
                        PostalCode:
                        <asp:TextBox ID="PostalCodeTextBox" runat="server" 
                            Text='<%#Bind("PostalCode")%>' />
                    <br />
                        AddressType:
                        <asp:TextBox ID="AddressTypeTextBox" runat="server" 
                            Text='<%#Bind("AddressType")%>' />
                    <br />
                        ModifiedDate:
                        <asp:Label ID="ModifiedDateLabel" runat="server" 
                            Text='<%#Eval("ModifiedDate")%>' />
                    <br />

                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" 
                            ImageUrl="~/assets/saveHS.png" />
                                       <%--<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />--%>
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Cancel" 
                            ImageUrl="~/assets/edit_UndoHS.png" />
                    <br />
                    </td>
                    --%&gt;
                </EditItemTemplate>
                <GroupTemplate>
                    <tr ID="itemPlaceholderContainer" runat="server">
                        <td ID="itemPlaceholder" runat="server">
                        </td>
                    </tr>
                </GroupTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </asp:Content>
