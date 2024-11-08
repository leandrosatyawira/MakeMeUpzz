<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.TransactionDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Transaction Detail Page</h1>
        </div>
        <div>
            <asp:GridView ID="TranDetailGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID" />
                    <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Makeup Name" SortExpression="Makeup.MakeupName" />
                    <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Makeups Price" SortExpression="Makeup.MakeupPrice" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click"/>
        </div>
    </form>
</body>
</html>
