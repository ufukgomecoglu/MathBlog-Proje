using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class QuestionUpdate : System.Web.UI.Page
    {
        DataModel datamodel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    dropdownlist_topic.DataSource = datamodel.ListTopic(false);
                    dropdownlist_topic.DataBind();
                    int questionID= Convert.ToInt32(Request.QueryString["QuestionID"]);
                    Question question = datamodel.GetQuestionAdmin(questionID);
                    if (question.AdministratorID==0)
                    {
                         question = datamodel.GetQuestionUser(questionID);
                    }
                    textbox_list.Text = question.Summary;
                    textbox_full.Text = question.FullContent;
                    checkbox_comfirm.Checked = !question.IsDeleted;
                    dropdownlist_topic.SelectedValue = question.TopicID.ToString();
                    img_max.ImageUrl = "../Images/" + question.FullPictureName;
                    img_min.ImageUrl = "../Images/" + question.ThumbnailName;
                }
            }
            else
            {
                Response.Redirect("QuestionList.aspx");
            }
        }

        protected void linkbutton_addquestion_Click(object sender, EventArgs e)
        {
            bool key = true;
            int questionID = Convert.ToInt32(Request.QueryString["QuestionID"]);
            Question question = datamodel.GetQuestionAdmin(questionID);
            if (question.AdministratorID == 0)
            {
                question = datamodel.GetQuestionUser(questionID);
            }
            question.TopicID = Convert.ToInt32(dropdownlist_topic.SelectedItem.Value);
            if (datamodel.NullControl(textbox_list.Text)!=null)
            {
                question.Summary = textbox_list.Text;
            }
            else
            {
                key = false;
                panel_info.Visible = true;
                label_message.Text = "List show cannot be left blank.";
            }
            if (datamodel.NullControl(textbox_full.Text)!=null)
            {
                question.FullContent = textbox_full.Text;
            }
            else
            {
                key = false;
                panel_info.Visible = true;
                label_message.Text = "List full cannot be left blank.";
            }
            question.IsDeleted = !checkbox_comfirm.Checked;
            if (fileupload_min.HasFile)
            {
                FileInfo fileInfo = new FileInfo(fileupload_min.FileName);
                string fileName = Guid.NewGuid().ToString();
                fileName +=fileInfo.Extension;
                fileupload_min.SaveAs(Server.MapPath("~/Images/" + fileName));
                question.ThumbnailName = fileName;
            }
            else
            {
                question.ThumbnailName = "noimage.png";
            }
            if (fileupload_max.HasFile)
            {
                FileInfo fileInfo = new FileInfo(fileupload_max.FileName);
                string fileName = Guid.NewGuid().ToString();
                fileName += fileInfo.Extension;
                fileupload_max.SaveAs(Server.MapPath("~/Images/" + fileName));
                question.FullPictureName = fileName;
            }
            else
            {
                question.FullPictureName = "noimage.png";
            }
            if (key==true)
            {
                if (datamodel.UpdateQuestion(question))
                {
                    Response.Redirect("QuestionList.aspx");
                }
                else
                {
                    panel_info.Visible = true;
                    label_message.Text = "Error occurred during registration.";
                }
            }
        }
    }
}