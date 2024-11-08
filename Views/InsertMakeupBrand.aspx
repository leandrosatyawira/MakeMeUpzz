<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertMakeupBrand.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.InsertMakeupBrand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BackBtn" runat="server" Text="Back" Onclick="BackBtn_Click"/>
            <br />
            <br />
            <h1>Insert MakeupType Page</h1>
            <asp:Label ID="BrandNameLbl" runat="server" Text="Brand Name: "></asp:Label>
            <asp:TextBox ID="BrandNameTB" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="BrandRatingLbl" runat="server" Text="Brand Rating: "></asp:Label>
            <asp:TextBox ID="BrandRatingTb" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
            <br />
            <asp:Label ID="BrandErrorLbl" runat="server" Text="Error" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
