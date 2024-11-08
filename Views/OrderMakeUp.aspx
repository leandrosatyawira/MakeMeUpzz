<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderMakeUp.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <h1>
            Order Make Up
        </h1>
    </header>
    <div>
        <asp:GridView ID="MakeupGV" runat="server" AutoGenerateColumns="False" OnRowCommand="MakeupGV_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblMakeupID" Text='<%# Eval("MakeupID") %>' runat="server" Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:TemplateField HeaderText="Weight">
                    <ItemTemplate>
                        <%# Eval("MakeupWeight") + "g" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupType.MakeupTypeName" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrand.MakeupBrandName" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                    </ItemTemplate>
                 </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" CommandName="Order" HeaderText="Order" ShowHeader="True" Text="Order" />
            </Columns>
        </asp:GridView>
        
        <asp:Label ID="Alert" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <br />
        <asp:Label ID="CartLabel" runat="server" Text="Cart"></asp:Label>
        <asp:GridView ID="CartGridview" runat="server">
            <Columns>
                <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Name" SortExpression="MakeupID.MakeupName" />
                <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Price" SortExpression="Makeup.MakeupPrice" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />

            </Columns>
        </asp:GridView>
        <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click"/>
        <asp:Button ID="CheckOutBtn" runat="server" Text="Checkout" OnClick="CheckOutBtn_Click"/>
    </div>
</asp:Content>
