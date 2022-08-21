<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdate.aspx.cs" Inherits="MathBlog.Admin.AdminUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel runat="server" ID="panel_info" Visible="false" CssClass=" error">
            <asp:Label runat="server" ID="label_message"></asp:Label>
        </asp:Panel>
        <div>
            <table class="table">
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_name" runat="server" CssClass="textbox" placeholder="Admin name entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_secondname" runat="server" CssClass="textbox" placeholder="Admin second name entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_surname" runat="server" CssClass="textbox" placeholder="Admin surname entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_username" runat="server" CssClass="textbox" placeholder="Admin username entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_eposta" runat="server" CssClass="textbox" placeholder="Admin eposta entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_password" runat="server" CssClass="textbox" TextMode="Password" placeholder="Admin password entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="textbox_mobilephone" runat="server" CssClass="textbox" placeholder="Admin mobilephone entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="radiobutton_admin" Text="Yonetici" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                            <asp:RadioButton ID="radiobutton_mathteacher" Text="Math Teacher" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                        <asp:RadioButton ID="radiobutton_mathacademician" Text="Math Academician" runat="server" GroupName="authority" Style="opacity: 0.9;" />
                        <asp:LinkButton ID="linkbutton_add" runat="server" OnClick="linkbutton_add_Click" Text="Admin Update" CssClass="formButton"></asp:LinkButton>
                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>
