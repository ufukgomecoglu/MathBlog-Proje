<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Answerlist.aspx.cs" Inherits="MathBlog.Admin.Answerlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_answeraktive" runat="server" OnItemCommand="listview_answeraktive_ItemCommand">
        <LayoutTemplate>
            <table class=" table" cellspacing="0">
                 <tr>
                    <th colspan="6">Aktive answers.</th>
                </tr>
                <tr>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Answer content</th>
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
                <td><%#Eval("AnswerContent") %></td>
                <td><%#Eval("AnswerDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("AnswerID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="AnswerUpdate.aspx?AnswerID=<%# Eval("AnswerID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="CommentAdd.aspx?AnswerID=<%# Eval("AnswerID") %>" class=" button">Comment</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
             <tr>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("AnswerContent") %></td>
                <td><%#Eval("AnswerDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("AnswerID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="AnswerUpdate.aspx?AnswerID=<%# Eval("AnswerID") %>"   >
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="CommentAdd.aspx?AnswerID=<%# Eval("AnswerID") %>" class=" button">Comment</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class=" table" cellspacing="0">
                 <tr>
                    <th colspan="6">Aktive answers.</th>
                </tr>
                <tr>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Answer content</th>
                    <th>Date</th>
                    <th>Is it on the air?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <tr>
                <td colspan="6">No answer has been added yet.</td>
            </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ListView ID="listview_answerpassive" runat="server" OnItemCommand="listview_answerpassive_ItemCommand">
         <LayoutTemplate>
            <table class=" table" cellspacing="0">
                 <tr>
                    <th colspan="6">Passsive answers.</th>
                </tr>
                <tr>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Answer content</th>
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
                <td><%#Eval("AnswerContent") %></td>
                <td><%#Eval("AnswerDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("AnswerID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                       <a href="AnswerUpdate.aspx?AnswerID=<%# Eval("AnswerID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="CommentAdd.aspx?AnswerID=<%# Eval("AnswerID") %>" class=" button">Comment</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("AnswerContent") %></td>
                <td><%#Eval("AnswerDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("AnswerID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                       <a href="AnswerUpdate.aspx?AnswerID=<%# Eval("AnswerID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="CommentAdd.aspx?AnswerID=<%# Eval("AnswerID") %>" class=" button">Comment</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class=" table" cellspacing="0">
                 <tr>
                    <th colspan="6">Passive answers.</th>
                </tr>
                <tr>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Answer content</th>
                    <th>Date</th>
                    <th>Is it on the air?</th>
                    <th><img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <tr>
                <td colspan="6">No answer has been added yet.</td>
            </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
