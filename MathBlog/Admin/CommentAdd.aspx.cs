using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class CommentAdd : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void linkbutton_commentanswer_Click(object sender, EventArgs e)
        {
            bool key = true;
            Answer answer = new Answer();
            int answerID = Convert.ToInt32(Request.QueryString["AnswerID"]);
            Comment comment = new Comment();
            Administrator administrator = (Administrator)Session["administrator"];
            comment.AdministratorID = administrator.AdministratorID;
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
            comment.CommentDate = DateTime.Now;
            comment.IsDeleted = !checkbox_comfirm.Checked;
            comment.AnswerID = answerID;
            if (key==true)
            {
                if (dataModel.AddComment(comment))
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