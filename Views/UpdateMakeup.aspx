﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMakeup.aspx.cs" Inherits="MakeMeUpzz_UAS.Views.UpdateMakeup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click"/>

             <div>
                 <h1>Update Makeup Page</h1>
                 <h1>Makeup ID: <%=Request.QueryString["id"]%></h1>
                 <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
                 <asp:TextBox ID="NameTB" runat="server"></asp:TextBox><br />
                 <asp:Label ID="PriceLbl" runat="server" Text="Price"></asp:Label>
                 <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox><br />
                 <asp:Label ID="WeightLbl" runat="server" Text="Weight"></asp:Label>
                 <asp:TextBox ID="WeightTB" runat="server"></asp:TextBox><br />
                 <asp:Label ID="TypeLbl" runat="server" Text="TypeID:"></asp:Label>
                 <asp:DropDownList ID="TypeIdDropDown" runat="server"></asp:DropDownList><br />
                 <asp:Label ID="BrandLbl" runat="server" Text="BrandID:"></asp:Label>
                 <asp:DropDownList ID="BrandIdDropdown" runat="server"></asp:DropDownList><br />
             </div>
            <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click"/>
            <asp:Label ID="AlertLbl" runat="server" Text="" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>