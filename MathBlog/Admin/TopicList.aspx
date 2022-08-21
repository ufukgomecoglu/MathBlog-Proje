<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="MathBlog.Admin.TopicList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_topicaktive" runat="server" OnItemCommand="listview_topicaktive_ItemCommand">
        <LayoutTemplate>
            <table class=" table" cellspacing="0" style="width:50%">
                 <tr>
                    <th colspan="2">Aktive topics.</th>
                </tr>
               <tr>
                   <th>Topic name</th>
                   <th><img src="../Images/settings.png" style="width: 20%; height: auto"/></th>
               </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("TopicName") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("TopicID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="TopicUpdate.aspx?TopicID=<%# Eval("TopicID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("TopicName") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("TopicID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="TopicUpdate.aspx?TopicID=<%# Eval("TopicID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
             <table class=" table" cellspacing="0" style="width:50%">
                 <tr>
                    <th colspan="2">Aktive topics.</th>
                </tr>
               <tr>
                   <th>Topic name</th>
                   <th><img src="../Images/settings.png" style="width: 20%; height: auto"/></th>
               </tr>
                  <tr>
                    <td colspan="2">No topic has been added yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ListView ID="listview_topicpassive" runat="server" OnItemCommand="listview_topicpassive_ItemCommand">
        <LayoutTemplate>
            <table class=" table" cellspacing="0" style="width:50%">
                <tr>
                    <th colspan="2">Passive topics.</th>
                </tr>
               <tr>
                   <th>Topic name</th>
                   <th><img src="../Images/settings.png" style="width: 20%; height: auto"/></th>
               </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("TopicName") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("TopicID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                       <a href="TopicUpdate.aspx?TopicID=<%# Eval("TopicID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("TopicName") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("TopicID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                     <a href="TopicUpdate.aspx?TopicID=<%# Eval("TopicID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
             <table class=" table" cellspacing="0" style="width:50%">
                 <tr>
                    <th colspan="2">Passive topics.</th>
                </tr>
               <tr>
                   <th>Topic name</th>
                   <th><img src="../Images/settings.png" style="width: 20%; height: auto"/></th>
               </tr>
                  <tr>
                    <td colspan="2">No topic has been added yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
