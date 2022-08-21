<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="IFotgotMyPassword.aspx.cs" Inherits="MathBlog.User.IFotgotMyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <br />
            <div>
                <asp:LinkButton ID="linkbutton_send" Text="Send" runat="server" CssClass="Button" OnClick="linkbutton_send_Click" />
            </div>
        </div>
</asp:Content>
