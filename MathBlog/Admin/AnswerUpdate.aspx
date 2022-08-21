<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AnswerUpdate.aspx.cs" Inherits="MathBlog.Admin.AnswerUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ListView ID="listview_question" runat="server">
        <LayoutTemplate>
             <button type="button" class=" collapsible" style="width: 100%; border: solid">
                Open Question
            </button>
            <div class="colsible">
                <table class="table" cellspacing="0">
                    <tr>
                        <th style="width: 15%">Topic Name</th>
                        <th style="width: 85%">Question</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("TopicName") %></td>
                <td><%#Eval("FullContent") %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <asp:ListView ID="listview_questionpicture" runat="server">
        <LayoutTemplate>
            <button type="button" class=" collapsible" style="width: 100%; border: solid">
                Open İmage
            </button>
            <div class="colsible">
                <table class="table" cellspacing="0">
                    <tr>
                        <th style="width: 15%">Small Image</th>
                        <th style="width: 85%">Content Image</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <img src="../Images/<%#Eval("ThumbnailName") %>" alt="Soru Görseli" /></td>
                <td>
                    <img src="../Images/<%#Eval("FullPictureName") %>" alt="Soru Görseli" /></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <br />
    <br />
    <div class="formContainer">
        <div>
            <asp:Panel ID="panel_Info" runat="server" Visible="false" CssClass="error">
                <asp:Label ID="label_Message" runat="server" />
            </asp:Panel>
        </div>
        <br />
        <div>
            <label style="color: #FF652F">Answer Confirmation</label>
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
            <asp:LinkButton ID="linkbutton_updateanswer" CssClass="formButton" Text="Update Answer" runat="server" OnClick="linkbutton_updateanswer_Click" />
        </div>
    </div>
     <script>
         var coll = document.getElementsByClassName("collapsible");
         var i;

         for (i = 0; i < coll.length; i++) {
             coll[i].addEventListener("click", function () {
                 this.classList.toggle("active");
                 var content = this.nextElementSibling;
                 if (content.style.display === "block") {
                     content.style.display = "none";
                 } else {
                     content.style.display = "block";
                 }
             });
         }
     </script>
</asp:Content>
