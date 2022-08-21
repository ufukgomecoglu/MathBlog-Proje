<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TopicAdd.aspx.cs" Inherits="MathBlog.Admin.TopicAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <asp:Panel ID="panel_info" runat="server" CssClass="info; error" visible="false" >
            <asp:Label ID="label_message" runat="server" />
        </asp:Panel>
        <br />
        <asp:TextBox ID="textbox_topicname" CssClass="textbox" runat="server" placeholder="Topic Name Entry" />
        <asp:LinkButton ID="linkbutton_addtopic" Text="Add Topic" runat="server" CssClass="formButton" OnClick="linkbutton_addtopic_Click" />
</div>
</asp:Content>

