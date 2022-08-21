using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class AdminDefult : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listview_questionpassive.DataSource = dataModel.ListQuestionCheck(true);
                listview_questionpassive.DataBind();
            }
            if (!IsPostBack)
            {
                listview_commentpassive.DataSource = dataModel.ListCommentCheck(true);
                listview_commentpassive.DataBind();
            }
        }

        protected void listview_questionpassive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int questionID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Passive")
            {
                if (dataModel.PassiveQuestion(questionID))
                {
                    Response.Redirect("QuestionList.aspx");
                }
            }
            if (e.CommandName == "Delete")
            {
                if (dataModel.DeleteQuestion(questionID))
                {
                    Response.Redirect("QuestionList.aspx");
                }
            }
        }

        protected void listview_commentpassive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int commentID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Passive")
            {
                if (dataModel.PassiveComment(commentID))
                {
                    Response.Redirect("CommentList.aspx");
                }
            }
            if (e.CommandName == "Delete")
            {
                if (dataModel.DeleteComment(commentID))
                {
                    Response.Redirect("CommentList.aspx");
                }
            }
        }
    }
}