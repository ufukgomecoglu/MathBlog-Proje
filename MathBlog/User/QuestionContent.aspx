<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="QuestionContent.aspx.cs" Inherits="MathBlog.User.QuestionContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" Question">
        <br />
        <div>
            <div style="float: left">
                <label>Writer : </label>
                <asp:Literal ID="literal_writer" runat="server"></asp:Literal>
            </div>
            <div style="text-align: center">
                <label style="margin-left: auto; margin-right: auto">Topic : </label>
                <asp:Literal ID="literal_topic" runat="server"></asp:Literal>
            </div>
        </div>
        <hr />
        <br />
        <asp:Image ID="image_full" runat="server" Style="width: 800px; max-height: 300px; border-radius: 0px !important;" />
        <hr />
        <br />
        <asp:Literal ID="literal_content" runat="server"></asp:Literal>
        <br />
        <hr />
    </div>

    <div class=" Question" style="min-height: max-content">
        <h2 style="text-align: center">Answers</h2>
        <hr />
        <br />
        <asp:Panel ID="panel_logoutanswer" runat="server" Visible="false">
            Please  <a href="Login.aspx" style="text-decoration: none; color: orangered; font-size: 16pt;">login </a>&nbsp;to answer.
        </asp:Panel>
        <asp:Panel ID="panel_loginanswer" runat="server" Visible="false">
            <asp:ListView ID="listview_answer" runat="server" OnItemCommand="listview_answer_ItemCommand">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>

                    <div class=" Question" style="min-height: max-content">
                        <div>
                            <div style="float: left">
                                <label>Authority Name: </label>
                                <%# Eval("AuthorityName") %>
                            </div>
                            <div style="text-align: center">
                                <label>Name:</label>
                                <%# Eval("Name") %>
                            </div>
                        </div>
                        <hr />
                        <br />
                        <%# Eval("AnswerContent") %>
                        <div>

                            <asp:Panel runat="server" ID="panel_Info" Visible="false" CssClass=" error">
                                <asp:Label Text="text" runat="server" ID="label_messageerror" />
                            </asp:Panel>
                            <asp:Label ID="label_message" runat="server"></asp:Label>
                            <div style="text-align: center">
                                <asp:TextBox ID="textbox_comment" runat="server" TextMode="MultiLine" CssClass=" TextBox2"></asp:TextBox>
                            </div>
                            <br />
                            <br />
                            <div style="text-align: center">
                                <asp:LinkButton ID="linkbutton_send" Text="Send" runat="server" CommandArgument='<%# Eval("AnswerID") %>' CommandName="send" CssClass=" Button" />
                            </div>
                            <br />
                            <hr />
                            <br />
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <label style="text-align: center">No answer yet.</label>
                    <br />
                </EmptyDataTemplate>
            </asp:ListView>
        </asp:Panel>
    </div>
    <div class=" Question" style="min-height: max-content">
        <h2 style="text-align: center">Comments</h2>
        <hr />
        <br />
        <asp:ListView ID="listview_comment" runat="server">
            <LayoutTemplate>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <label>User Name : </label>
                &nbsp:&nbsp<%# Eval("Name") %>
                <br />
                <hr />
                <%# Eval("CommentContent") %>
                <br />
                <hr />
                <br />
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
