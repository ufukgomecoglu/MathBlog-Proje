<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministratorEntry.aspx.cs" Inherits="MathBlog.Admin.AdministratorEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdministratorEntry</title>
    <link href="../CSS/AdminLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel">
            <img src="../Images/logo1.png" class=" responsive" />
            <h3 style="font-size: 150%; color: #FF652F">Administrator Entry</h3>
            <hr />
            <asp:Panel ID="panel_Message" runat="server" CssClass="error" Visible="false">
                <asp:Label ID="label_Eror" runat="server" />
            </asp:Panel>
            <hr />
            <div>
                <asp:TextBox ID="textbox_UserName" runat="server" CssClass="textbox" Placeholder="E-mail Adress" />
            </div>
            <div>
                <asp:TextBox ID="textbox_Password" runat="server" CssClass="textbox" Placeholder="Password" TextMode="Password" />
                
                <input type="checkbox" onclick="myFunction()" /> 
                <label style="font-family:sans-serif; color:#FF652F">Show password</label>
                <script>
                    function myFunction() {
                        var x = document.getElementById("textbox_Password");
                        if (x.type === "password") {
                            x.type = "text";
                        } else {
                            x.type = "password";
                        }
                    }
                </script>

            </div>
           
            <hr style="border: 2px solid #272727;" />
            <div>
                <asp:LinkButton ID="linkbutton_Login" Text="Login" runat="server" CssClass="button" OnClick="linkbutton_Login_Click" />
            </div>
            <div>
                <a href="IFotgotMyPassword.aspx" class="link">I forgot my password.</a>
            </div>
        </div>
    </form>
</body>
</html>
