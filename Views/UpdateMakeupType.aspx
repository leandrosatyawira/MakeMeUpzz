<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMakeupType.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.UpdateMakeupType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>Update Makeup Brand Page</h1>
                <h1>Makeup Type ID: <%=Request.QueryString["id"]%></h1>
            </div>
            <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
            <br />
            <asp:Label ID="TypeNameLbl" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="TypeNameTB" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
            <br />
            <asp:Label ID="UpdateErrorLbl" runat="server" Text="Error" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
