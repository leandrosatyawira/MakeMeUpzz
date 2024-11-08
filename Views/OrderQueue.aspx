<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order Queue Page</h1>
    </div>
    <div style="margin-bottom:20px">
        <asp:Label ID="HandledLbl" runat="server" Text="Handled Transaction:"></asp:Label>
        <asp:GridView ID="HandledGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="User.Username" HeaderText="Username" SortExpression="User.Username"/>
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>

        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="UnhandledLbl" runat="server" Text="Unhandled Transaction:"></asp:Label>
        <asp:GridView ID="UnhandledGV" runat="server" AutoGenerateColumns="false" OnRowCommand="UnhandledGV_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="User.Username" HeaderText="Username" SortExpression="User.Username"/>
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:ButtonField ButtonType="Button" CommandName="Handle" HeaderText="Handle" ShowHeader="True" Text="Handle" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
