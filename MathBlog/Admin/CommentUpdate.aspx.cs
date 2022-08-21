using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class CommentUpdate : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int commentID = Convert.ToInt32(Request.QueryString["CommentID"]);
                    Comment comment = dataModel.GetCommentAdmin(commentID);
                    if (comment.AdministratorID==0)
                    {
                        comment = dataModel.GetCommentUser(commentID);
                    }
                    checkbox_comfirm.Checked = !comment.IsDeleted;
                    textbox_full.Text = comment.CommentContent;
                }
            }
            else
            {
                Response.Redirect("CommentList.aspx");
            }
        }

        protected void linkbutton_commentupdate_Click(object sender, EventArgs e)
        {
            bool key = true;
            int commentID = Convert.ToInt32(Request.QueryString["CommentID"]);
            Comment comment = dataModel.GetCommentAdmin(commentID);
            if (comment.AdministratorID == 0)
            {
                comment = dataModel.GetCommentUser(commentID);
            }
            comment.IsDeleted = !checkbox_comfirm.Checked;
            if (dataModel.NullControl(textbox_full.Text)!=null)
            {
                comment.CommentContent = textbox_full.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Full show cannot be left blank.";
            }
            if (key==true)
            {
                if (dataModel.UpddateComment(comment))
                {
                    Response.Redirect("CommentList.aspx");
                }
                else
                {
                    panel_Info.Visible = true;
                    label_Message.Text = "Error occurred during registration.";
                }
            }
        }
    }
}