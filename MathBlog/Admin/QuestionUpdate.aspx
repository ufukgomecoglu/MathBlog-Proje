<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="QuestionUpdate.aspx.cs" Inherits="MathBlog.Admin.QuestionUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class=" formContainer" style="min-height:760px">
        <div style="width: 45%; float: left">
            <asp:Panel ID="panel_info" runat="server" Visible="false" CssClass="error">
                <asp:Label ID="label_message" runat="server" />
            </asp:Panel>
           
            <div>
                <label style="color: #FF652F">Question Topic</label>
                <asp:DropDownList ID="dropdownlist_topic" DataTextField="TopicName" DataValueField="TopicID" runat="server" Style="margin-left: 5%">
                </asp:DropDownList>
            </div>
            <br />
            <div>
                <label style="color: #FF652F">List Image</label>
                <asp:Image ID="img_min" runat="server" Style="width: 80px;" />
                <asp:FileUpload ID="fileupload_min" runat="server" Style="margin-left: 5%"></asp:FileUpload>
            </div>
            <br />
            <div>
                <label style="color: #FF652F">Content Image</label>
                <asp:Image ID="img_max" runat="server" Style="width: 80px;" />
                <asp:FileUpload ID="fileupload_max" runat="server" Style="margin-left: 5%"></asp:FileUpload>
            </div>
            <br />
            <div>
                <label style="color: #FF652F">Question Confirmation</label>
                <asp:CheckBox ID="checkbox_comfirm" runat="server" Checked="false" Style="margin-left: 2%;" />
                <label style="color: #FF652F">Accept</label>
            </div>
            <br />
            <div>
                <asp:LinkButton ID="linkbutton_addquestion" CssClass="formButton" Text="Update Question" runat="server" OnClick="linkbutton_addquestion_Click" />
            </div>
        </div>
        <div style="width: 45%; float: right">
            <div >
                <label style="color: #FF652F">List Show</label>
                <br />
                <asp:TextBox ID="textbox_list" runat="server" TextMode="MultiLine" MaxLength="256" Style="min-height: 100px; width: 100%" />
            </div>
            <br />
            <div >
                <label style="color:#FF652F">Full Show</label>
                <br />
                <asp:TextBox ID="textbox_full" runat="server" TextMode="MultiLine" CssClass="textbox"/>
                
                <script>
                    CKEDITOR.replace('ctl00$ContentPlaceHolder1$textbox_full');
                </script>
                
            </div>
          
        </div>
    </div>
</asp:Content>
