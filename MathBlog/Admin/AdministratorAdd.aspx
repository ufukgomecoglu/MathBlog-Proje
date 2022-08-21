<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdministratorAdd.aspx.cs" Inherits="MathBlog.Admin.AdministratorAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel runat="server" ID="panel_Info" Visible="False" CssClass=" error">
            <asp:Label Text="text" runat="server" ID="label_Message" />
        </asp:Panel>
        <div >
            <table class=" table">
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_name" runat="server" CssClass=" textbox" Placeholder="Administrator Name Entry" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_secondname" runat="server" CssClass=" textbox" Placeholder="Administrator Secondname Entry" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_surname" runat="server" CssClass=" textbox" Placeholder="Administrator Surname Entry" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="textbox_username" runat="server" CssClass=" textbox" Placeholder="Administrator Username Entry"   />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="textbox_mobilephone" runat="server" CssClass=" textbox" Placeholder="Administrator Mobilephone Entry"   />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="textbox_eposta" runat="server" CssClass=" textbox" Placeholder="E-mail Entry" />
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:TextBox ID="textbox_password" runat="server" CssClass=" textbox" Textmode="Password" Placeholder="Password Entry"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="radiobutton_administrator" Text="Admin" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                            <asp:RadioButton ID="radiobutton_mathteacher" Text="Math teacher" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                         <asp:RadioButton ID="radiobutton_mathacademician" Text="Math Academician" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        <asp:LinkButton ID="linkbutton_add" runat="server" onclick="linkbutton_add_Click" Text="Add administrator" CssClass="formButton"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

