<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="MathBlog.Admin.QuestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_questionaktive" runat="server" OnItemCommand="listview_questionaktive_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                 <tr>
                    <th colspan="7">Aktive question.</th>
                </tr>
                <tr>
                    <th>Preview</th>
                    <th>User Name</th>
                    <th>Authority Name</th>
                    <th>Topic Name</th>
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
                <td><img src="../Images/<%#Eval("ThumbnailName") %>" alt="Soru Görseli" style="width:50px"/></td>
                <td><%#Eval("UserName") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("TopicName") %></td>
                <td><%#Eval("LoadingDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="QuestionUpdate.aspx?QuestionID=<%# Eval("QuestionID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="AnswerAdd.aspx?QuestionID=<%# Eval("QuestionID") %>" class=" button">Answer</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><img src="../Images/<%#Eval("ThumbnailName") %>" alt="Soru Görseli" style="width:50px"/></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("TopicName") %></td>
                <td><%#Eval("LoadingDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/close_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Aktive" />
                    &nbsp;&nbsp;
                       <a href="QuestionUpdate.aspx?QuestionID=<%# Eval("QuestionID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="AnswerAdd.aspx?QuestionID=<%# Eval("QuestionID") %>" class=" button">Answer</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="7">Aktive question.</th>
                </tr>
                <tr>
                    <th>Preview</th>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Topic Name</th>
                    <th>Date</th>
                    <th>Is it on the air?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <tr>
                <td colspan="7">No question has been added yet.</td>
            </tr>
            </table>
            
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ListView ID="listview_questionpassive" runat="server" OnItemCommand="listview_questionpassive_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th colspan="7">Passive question.</th>
                </tr>
                <tr>
                    <th>Preview</th>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Topic Name</th>
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
                <td><img src="../Images/<%#Eval("ThumbnailName") %>" alt="Soru Görseli" style="width:50px"/></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("TopicName") %></td>
                <td><%#Eval("LoadingDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_passive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                       <a href="QuestionUpdate.aspx?QuestionID=<%# Eval("QuestionID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="AnswerAdd.aspx?QuestionID=<%# Eval("QuestionID") %>" class=" button">Answer</a>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><img src="../Images/<%#Eval("ThumbnailName") %>" alt="soru Görseli" style="width:50px"/></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("AuthorityName") %></td>
                <td><%#Eval("TopicName") %></td>
                <td><%#Eval("LoadingDate") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yes" :"No"%></td>
                <td>
                    <asp:ImageButton ID="imagebutton_aktive" ImageUrl="../Icon/check_FILL0_wght400_GRAD0_opsz48.png" runat="server" CommandArgument='<%# Eval("QuestionID") %>' CommandName="Passive" />
                    &nbsp;&nbsp;
                       <a href="QuestionUpdate.aspx?QuestionID=<%# Eval("QuestionID") %>">
                           <img src="../Icon/update_FILL1_wght400_GRAD0_opsz48.png" /></a>
                    &nbsp;&nbsp;
                      <a href="AnswerAdd.aspx?QuestionID=<%# Eval("QuestionID") %>" class=" button">Answer</a>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
             <table class="table" cellspacing="0">
                 <tr>
                    <th colspan="7">Passive question.</th>
                </tr>
                <tr>
                    <th>Preview</th>
                    <th>Writter</th>
                    <th>Authority Name</th>
                    <th>Topic Name</th>
                    <th>Date</th>
                    <th>Is it on the air?</th>
                    <th>
                        <img src="../Images/settings.png" style="width: 20%; height: auto" /></th>
                </tr>
                <tr>
                <td colspan="7">No question has been added yet.</td>
            </tr>
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
