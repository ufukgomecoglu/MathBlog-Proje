<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="CommentList.aspx.cs" Inherits="MathBlog.Admin.CommentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_commentaktive" runat="server" OnItemCommand="listview_commentaktive_ItemCommand">
        <LayoutTemplate>
            <table class=" table" cellspacing="0">
                 <tr>
                    <th colspan="6">Aktive comments.</th>
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
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("CommentContent") %></td>
                <td><%#Eval("CommentDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="CommentUpdate.aspx?CommentID=<%# Eval("CommentID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
             <tr>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("CommentContent") %></td>
                <td><%#Eval("CommentDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="CommentUpdate.aspx?CommentID=<%# Eval("CommentID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class=" table" cellspacing="0">
                 <tr>
                    <th colspan="6">Aktive comments.</th>
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
    <asp:ListView ID="listview_commentpassive" runat="server" OnItemCommand="listview_commentpassive_ItemCommand">
        <LayoutTemplate>
             <table class=" table" cellspacing="0">
                  <tr>
                    <th colspan="6">Passive comments.</th>
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
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("CommentContent") %></td>
                <td><%#Eval("CommentDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                       <a href="CommentUpdate.aspx?CommentID=<%# Eval("CommentID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            tr>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("CommentContent") %></td>
                <td><%#Eval("CommentDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("CommentID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                       <a href="CommenttUpdate.aspx?CommentID=<%# Eval("CommentID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
             <table class=" table" cellspacing="0">
                  <tr>
                    <th colspan="6">Passive comments.</th>
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
