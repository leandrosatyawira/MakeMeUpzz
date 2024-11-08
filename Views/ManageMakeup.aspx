<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.ManageMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <asp:Label runat="server" Text="MakeUps Table"></asp:Label>
        <asp:GridView ID="MakeupGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupGV_RowDeleting" OnRowEditing="MakeupGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="MakeUpID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeID" HeaderText="MakeUpType" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrand.MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrand.MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>

        <br />
        <asp:Label runat="server" Text="MakeUpType Table"></asp:Label>
        <asp:GridView ID="MakeupTypeGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupTypeGV_RowDeleting" OnRowEditing="MakeupTypeGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="MakeupTypeID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="MakeupTypeName" SortExpression="MakeupTypeName" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>

        <br />
        <asp:Label runat="server" Text="MakeUpBrands Table"></asp:Label>
        <asp:GridView ID="MakeupBrandGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupBrandGV_RowDeleting" OnRowEditing="MakeupBrandGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="MakeupBrandID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>

        </asp:GridView>

    </div>
    <div>
        <br />
        <asp:Button ID="InsertMakeupBtn" runat="server" Text="Insert Makeup" OnClick="InsertMakeupBtn_Click"/>
        <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert Makeup Type" OnClick="InsertMakeupTypeBtn_Click"/>
        <asp:Button ID="InsertmakeupBrandBtn" runat="server" Text="Insert Makeup Brand" OnClick="InsertmakeupBrandBtn_Click"/>
    </div>
</asp:Content>
