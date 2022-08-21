<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TopicUpdate.aspx.cs" Inherits="MathBlog.Admin.TopicUpdate" %>
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
                        <asp:TextBox ID="textbox_name" runat="server" CssClass="textbox" placeholder="Topic name entry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="linkbutton_add" runat="server"  OnClick="linkbutton_add_Click" Text="Admin Update" CssClass="formButton"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
