<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pytest.aspx.cs" Inherits="UserFB.Web.Pytest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button"  OnClick ="Button1_Click"/>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" Height="373px"  />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
