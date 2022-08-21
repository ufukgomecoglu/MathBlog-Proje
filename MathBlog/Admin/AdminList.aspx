<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="MathBlog.Admin.AdminList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_admin" runat="server" OnItemCommand="listview_admin_ItemCommand">
        <LayoutTemplate>
            <table class=" table" cellspacing="0">
                <tr>
                    <th colspan="7">Active administrators.</th>
                </tr>
                <tr>
                    <th>Authority Name</th>
                    <th>Name</th>
                    <th>Second Name</th>
                    <th>Surname</th>
                    <th>User Name</th>
                    <th>E-mail</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("SecondName") %></td>
                <td><%#Eval("Surname") %></td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server"  CommandArgument='<%# Eval("AdministratorID") %>' CommandName="Delete" />
                    &nbsp;&nbsp;
               <a href="AdminUpdate.aspx?ADAdministratorID=<%# Eval("AdministratorID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("SecondName") %></td>
                <td><%#Eval("Surname") %></td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_delete" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server"  CommandArgument='<%# Eval("AdministratorID") %>' CommandName="Delete" />
                    &nbsp;&nbsp; 
               <a href="AdminUpdate.aspx?ADAdministratorID=<%# Eval("AdministratorID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class=" table" cellspacing="0">
                <tr>
                    <th colspan="7">Passive administrators.</th>
                </tr>
                <tr>
                    <th>Authority Name</th>
                    <th>Name</th>
                    <th>Second Name</th>
                    <th>Surname</th>
                    <th>User Name</th>
                    <th>E-mail</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" />
                    </th>
                </tr>
                <tr>
                    <td colspan="7">No admin has been added yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
     <asp:ListView ID="listview_adminretunit" runat="server"  OnItemCommand="listview_adminretunit_ItemCommand">
        <LayoutTemplate>
            <table class=" table" cellspacing="0">
                <tr>
                    <th colspan="7">Passive administrators.</th>
                </tr>
                <tr>
                    <th>Authority Name</th>
                    <th>Name</th>
                    <th>Second Name</th>
                    <th>Surname</th>
                    <th>User Name</th>
                    <th>E-mail</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("SecondName") %></td>
                <td><%#Eval("Surname") %></td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_returnit" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server"  CommandArgument='<%# Eval("AdministratorID") %>' CommandName="returnit" />
                    &nbsp;&nbsp; 
               <a href="AdminUpdate.aspx?ADAdministratorID=<%# Eval("AdministratorID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("SecondName") %></td>
                <td><%#Eval("Surname") %></td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("Eposta") %></td>
                <td>
                    <asp:ImageButton ID="imagebutton_returnit" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server"  CommandArgument='<%# Eval("AdministratorID") %>' CommandName="returnit" />
                    &nbsp;&nbsp; 
               <a href="AdminUpdate.aspx?ADAdministratorID=<%# Eval("AdministratorID") %>">
                   <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class=" table" cellspacing="0">
                <tr>
                    <th colspan="7">Passive administrators.</th>
                </tr>
                <tr>
                    <th>Authority Name</th>
                    <th>Name</th>
                    <th>Second Name</th>
                    <th>Surname</th>
                    <th>User Name</th>
                    <th>E-mail</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" />
                    </th>
                </tr>
                <tr>
                    <td colspan="7">No admin has been added yet.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
