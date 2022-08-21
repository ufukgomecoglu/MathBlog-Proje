<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="SingUp.aspx.cs" Inherits="MathBlog.User.SingUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" formContainer">
        <div style="text-align:center">
             <asp:Panel runat="server" ID="panel_Info" Visible="false" CssClass=" error">
            <asp:Label Text="text" runat="server" ID="label_Message" />
        </asp:Panel>
        <br />
        <asp:TextBox ID="textbox_name" runat="server" CssClass=" textbox" Placeholder=" Name Entry" />
        <br />
        <asp:TextBox ID="textbox_secondname" runat="server" CssClass=" textbox" Placeholder=" Secondname Entry" />
        <br />
        <asp:TextBox ID="textbox_surname" runat="server" CssClass=" textbox" Placeholder=" Surname Entry" />
        <br />
        <asp:TextBox ID="textbox_username" runat="server" CssClass=" textbox" Placeholder=" Username Entry" />
        <br />
        <br />
        <label style="float: left; margin-left: 30%; ">Birthdate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
        <asp:TextBox ID="textbox_birthdate" runat="server" TextMode="Date" CssClass="textbox" ></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="textbox_mobilephone" runat="server" CssClass=" textbox" Placeholder=" Mobilephone Entry" />
        <br />
        <asp:TextBox ID="textbox_eposta" runat="server" CssClass=" textbox" Placeholder="E-mail Entry" />
        <br />
        <asp:TextBox ID="textbox_password" runat="server" CssClass=" textbox" TextMode="Password" Placeholder="Password Entry" />
        <br />
        <asp:TextBox ID="textbox_passwordagain" runat="server" CssClass=" textbox" TextMode="Password" Placeholder="Password Again Entry" />
        <br />
        <div style="margin-top:10px;margin-left:auto;margin-right:auto;width:5%">
             <asp:LinkButton ID="linkbutton_add" runat="server" OnClick="linkbutton_add_Click" Text="Send" CssClass="Button" ></asp:LinkButton>
        </div>
        <br />
        <br />
        <br />

        </div>
       
    </div>
</asp:Content>
