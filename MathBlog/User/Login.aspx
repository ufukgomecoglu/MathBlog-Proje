<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MathBlog.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="panel" style="margin-top: 50px">
            <br />
            <h3 style="font-size: 30pt; text-align: center">User Entry</h3>
            <hr style="color: #F7F7F7; margin-top: 15px;" />
            <asp:Panel runat="server" ID="panel_Info" Visible="false" CssClass=" error">
                <asp:Label Text="text" runat="server" ID="label_Message" />
            </asp:Panel>
            <div>
                <asp:TextBox ID="textbox_eposta" runat="server" CssClass=" textbox" Placeholder="E-mail"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="textbox_Password" runat="server" CssClass="textbox" Placeholder="Password" TextMode="Password"> </asp:TextBox>
                <div>
                    <input type="checkbox" onclick="myFunction()">
                    <label style="font-family: sans-serif; color: #FF652F">Show password</label>
                    <script>
                        function myFunction() {
                            var x = document.getElementById("ContentPlaceHolder1_textbox_Password");
                            if (x.type === "password") {
                                x.type = "text";
                            } else {
                                x.type = "password";
                            }
                        }
                    </script>
                </div>
            </div>
            <div style="margin-top: 10px; margin-left: auto; margin-right: auto; width: 5%">
                <asp:LinkButton ID="linkbutton_login" runat="server" CssClass="Button" Text="Login" OnClick="linkbutton_login_Click"></asp:LinkButton>
            </div>
            <br />
            <div style="text-align: center; width: 100%">
                <a href="IFotgotMyPassword.aspx" class="link">I forgot my password.</a>
            </div>

        </div>
    </div>
</asp:Content>
