<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="MathBlog.Admin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_user" runat="server" OnItemCommand="listview_user_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="7">Aktive users.</th>
                </tr>
                <tr>
                    <th>User Name</th>
                    <th>E-mail Adress</th>
                    <th>Age</th>
                    <th>Number of questions(Aktive)</th>
                    <th>Number of comments(Aktive)</th>
                    <th>Is It Active?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td><%#Eval("Age") %></td>
                <td><%#Eval("Commentnumber") %></td>
                <td><%#Eval("QuestionNumber") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td><%#Eval("Age") %></td>
                <td><%#Eval("Commentnumber") %></td>
                <td><%#Eval("QuestionNumber") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Delete" />
                </td>
            </tr>
        </AlternatingItemTemplate>
       <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="7">Aktive users.</th>
                </tr>
                <tr>
                    <th>User Name</th>
                    <th>E-mail Adress</th>
                    <th>Age</th>
                    <th>Number of questions(Aktive)</th>
                    <th>Number of comments(Aktive)</th>
                    <th>Is It Active?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <tr>
                    <td colspan="7">No user has been added yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ListView ID="listview_useraktive" runat="server" OnItemCommand="listview_useraktive_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="7">Passive users.</th>
                </tr>
                <tr>
                    <th>User Name</th>
                    <th>E-mail Adress</th>
                    <th>Age</th>
                    <th>Number of questions(Aktive)</th>
                    <th>Number of comments(Aktive)</th>
                    <th>Is It Active?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td><%#Eval("Age") %></td>
                <td><%#Eval("Commentnumber") %></td>
                <td><%#Eval("QuestionNumber") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td><%#Eval("Age") %></td>
                <td><%#Eval("Commentnumber") %></td>
                <td><%#Eval("QuestionNumber") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/delete_FILL1_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("UserID") %>' CommandName="Delete" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="7">Passive users.</th>
                </tr>
                <tr>
                    <th>User Name</th>
                    <th>E-mail Adress</th>
                    <th>Age</th>
                    <th>Number of questions(Aktive)</th>
                    <th>Number of comments(Aktive)</th>
                    <th>Is It Active?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <tr>
                    <td colspan="7">No user has been added yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
