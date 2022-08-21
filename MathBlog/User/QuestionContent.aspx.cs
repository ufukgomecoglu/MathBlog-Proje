using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.User
{
    public partial class QuestionContent : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int questionId = Convert.ToInt32(Request.QueryString["QuestionID"]);
                if (!IsPostBack)
                {
                    Question question = dataModel.GetQuestionAdmin(questionId);
                    if (question.AdministratorID == 0)
                    {
                        question = dataModel.GetQuestionUser(questionId);
                    }
                    literal_writer.Text = question.UserName;
                    literal_topic.Text = question.TopicName;
                    literal_content.Text = question.FullContent;
                    image_full.ImageUrl = "/Images/" + question.FullPictureName;
;
                   
                }
                if (!IsPostBack)
                {
                    if (Session["User"] != null)
                    {
                        panel_loginanswer.Visible = true;
                        panel_logoutanswer.Visible = false;
                        listview_answer.DataSource = dataModel.ListAnswerAktive(false, questionId);
                        listview_answer.DataBind();
                    }
                    else
                    {
                        panel_loginanswer.Visible = false;
                        panel_logoutanswer.Visible = true;
                    }
                }
                if (!IsPostBack)
                {
                    List<Answer> answers = dataModel.ListAnswerAktive(false, questionId);
                    List<Comment> comments = new List<Comment>();
                    foreach (Answer answer in answers)
                    {
                        comments.AddRange(dataModel.ListCommentAktive(false, answer.AnswerID));
                    }
                    listview_comment.DataSource = comments;
                    listview_comment.DataBind();
                }
            }
            else
            {
                Response.Redirect("UserDefault.aspx");
            }
        }
        protected void listview_answer_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Answer answer = new Answer();
            bool key = true;
            int answerID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "send")
            {
                TextBox textBox = (TextBox)e.Item.FindControl("textbox_comment");
                Panel panelEror = (Panel)e.Item.FindControl("panel_Info");
                Label labelEror = (Label)e.Item.FindControl("label_messageerror");
                Label label = (Label)e.Item.FindControl("label_message");
                Comment comment = new Comment();
                DataAccessLayer_MathBlog.User user = (DataAccessLayer_MathBlog.User)Session["User"];
                comment.UserID = user.UserID;
                if (dataModel.NullControl(textBox.Text) != null)
                {
                    comment.CommentContent = textBox.Text;
                }
                else
                {
                    key = false;
                    panelEror.Visible = true;
                    labelEror.Text = "Full show cannot be left blank.";
                }
                comment.CommentDate = DateTime.Now;
                comment.IsDeleted = true;
                comment.AnswerID = answerID;
                if (key == true)
                {
                    if (dataModel.AddCommentUser(comment))
                    {
                        panelEror.Visible = false;
                        textBox.Text = "";
                        label.Text = "Waiting for approval";
                    }
                    else
                    {
                        panelEror.Visible = true;
                        labelEror.Text = "Error occurred during registration.";
                    }
                }
            }
        }

    }
}