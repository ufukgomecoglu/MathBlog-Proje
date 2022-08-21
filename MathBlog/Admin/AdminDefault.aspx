<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="MathBlog.Admin.AdminDefult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_questionpassive" runat="server" OnItemCommand="listview_questionpassive_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="8">Check User Questions</th>
                </tr>
                <tr>
                    <th>Preview</th>
                    <th>User Name</th>
                    <th>Authority Name</th>
                    <th>Topic Name</th>
                    <th>Question Content</th>
                    <th>Date</th>
                    <th>Is it on the air?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />

            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
            </tr>
            <tr>
                <td>
                    <img src="../Images/<%#Eval("ThumbnailName") %>" alt="Soru Görseli" style="width: 50px" /></td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("TopicName") %></td>
                <td><%#Eval("FullContent") %></td>
                <td><%#Eval("LoadingDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                      <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
            </tr>
            <tr>
                <td>
                    <img src="../Images/<%#Eval("ThumbnailName") %>" alt="Soru Görseli" style="width: 50px" /></td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("TopicName") %></td>
                <td><%#Eval("FullContent") %></td>
                <td><%#Eval("LoadingDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                      <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Delete" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="8">Check User Questions</th>
                </tr>
                <tr>
                    <th>Preview</th>
                    <th>User Name</th>
                    <th>Authority Name</th>
                    <th>Topic Name</th>
                    <th>Question Content</th>
                    <th>Date</th>
                    <th>Is it on the air?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <tr>
                    <td colspan="8">No question has been added yet.</td>
                </tr>
            </table>

        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ListView ID="listview_commentpassive" runat="server" OnItemCommand="listview_commentpassive_ItemCommand">
        <LayoutTemplate>
            <table class=" table" cellspacing="0">
                <tr>
                    <th colspan="6">Check User Comment</th>
                </tr>
                <tr>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Comment content</th>
                    <th>Date</th>
                    <th>Is it on the air?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
            </tr>
            <tr>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("CommentContent") %></td>
                <td><%#Eval("CommentDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                      <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
            </tr>
            <tr>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("CommentContent") %></td>
                <td><%#Eval("CommentDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                      <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Delete" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class=" table" cellspacing="0">
            <tr>
                <th colspan="6">Check User Comment</th>
            </tr>
            <tr>
                <th>Writter</th>
                <th>Authority Name</th>
                <th>Comment content</th>
                <th>Date</th>
                <th>Is it on the air?</th>
                <th>
                    <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
            </tr>
            <tr>
                <td colspan="6">No comment has been added yet.</td>
            </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>

