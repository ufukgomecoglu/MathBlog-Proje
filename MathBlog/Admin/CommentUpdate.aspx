<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CommentUpdate.aspx.cs" Inherits="MathBlog.Admin.CommentUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class=" formContainer">
         <div>
            <asp:Panel ID="panel_Info" runat="server" Visible="false" CssClass="error">
                <asp:Label ID="label_Message" runat="server" />
            </asp:Panel>
        </div>
         <div>
            <label style="color: #FF652F">Comment Confirmation</label>
            <asp:CheckBox ID="checkbox_comfirm" runat="server" Checked="false" Style="margin-left: 2%;" />
            <label style="color: #FF652F">Accept</label>
        </div>
        <br />
        <div>
            <label style="color: #FF652F">Full Show</label>
            <br />
            <asp:TextBox ID="textbox_full" runat="server" TextMode="MultiLine" CssClass="textbox" />

            <script>
                CKEDITOR.replace('ctl00$ContentPlaceHolder1$textbox_full');
            </script>
        </div>
        <br />
        <br />
        <div style="text-align: center">
            <asp:LinkButton ID="linkbutton_commentupdate" CssClass="formButton" Text="Update comment" runat="server" OnClick="linkbutton_commentupdate_Click" />
        </div>
    
    </div>
</asp:Content>
