<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IFotgotMyPassword.aspx.cs" Inherits="MathBlog.Admin.IFotgotMyPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IFotgotMyPassword</title>
    <link href="../CSS/AdminLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel" style="min-height:80px">
             <asp:Panel ID="panel_Message" runat="server" CssClass="error" Visible="false">
                <asp:Label ID="label_Eror" runat="server" />
            </asp:Panel>
             <hr />
            <div>
                <asp:TextBox ID="textbox_eposta" runat="server" CssClass="textbox" Placeholder="E-mail Adress Entry" />
            </div>
            <div>
                <asp:TextBox ID="textbox_UserName" runat="server" CssClass="textbox" Placeholder="User Name Entry" />
            </div>
            <div>
                <asp:LinkButton ID="linkbutton_send" Text="Send" runat="server" CssClass="button" OnClick="linkbutton_send_Click" />
            </div>
        </div>
    </form>
</body>
</html>
