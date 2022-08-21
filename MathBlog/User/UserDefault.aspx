<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="UserDefault.aspx.cs" Inherits="MathBlog.User.UserDefult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="listview_question" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class=" Question">
                <div>
                    <br />
                    <label><%# Eval("AuthorityName") %>:</label>
                    <label><%# Eval("UserName") %></label>
                    <br />
                    <label>Published:<%# Eval("LoadingDate") %></label>
                    <br />
                    <label>Topic: <%# Eval("TopicName") %></label>
                    <br />
                    <hr />
                    <br />
                    <img src="../Images/<%#Eval("ThumbnailName")%>" style="  width: 10%; float: left;" />
                    <p style="float: right; width: 75%; " >
                        <%# Eval("Summary") %>&nbsp;
                    <a href='QuestionContent.aspx?QuestionID=<%# Eval("QuestionID") %>' style="text-decoration: none; color: #046380;">Contents..</a>
                    </p>
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
