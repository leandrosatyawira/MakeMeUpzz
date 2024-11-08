<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMakeupBrand.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.UpdateMakeupBrand" %>

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
                <h1>Makeup Brand ID: <%=Request.QueryString["id"]%></h1>
            </div>
            <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click"/>
            <br />
            <asp:Label ID="BrandNameLbl" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="BrandNameTB" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="BrandRatingLbl" runat="server" Text="Rating: "></asp:Label>
            <asp:TextBox ID="BrandRatingTB" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="UpdateBrandBtn" runat="server" Text="Update" OnClick="UpdateBrandBtn_Click" />
            <asp:Label ID="UpdateErrorLbl" runat="server" Text="Error" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
