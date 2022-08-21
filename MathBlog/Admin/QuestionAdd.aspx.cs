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
    public partial class QuestionAdd : System.Web.UI.Page
    {
        DataModel dataModel= new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropdownlist_topic.DataSource = dataModel.ListTopic(false);
                dropdownlist_topic.DataBind();
            }
        }

        protected void linkbutton_addquestion_Click(object sender, EventArgs e)
        {
            bool key = true;
            Question question = new Question();
            question.TopicID = Convert.ToInt32(dropdownlist_topic.SelectedItem.Value);
            if (dataModel.NullControl(textbox_list.Text)!=null)
            {
                question.Summary = textbox_list.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "List show cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_full.Text)!=null)
            {
                question.FullContent = textbox_full.Text;
            }
            else
            {
                key=false;
                panel_Info.Visible = true;
                label_Message.Text = "Full show cannot be left blank.";
            }
            question.IsDeleted = !checkbox_comfirm.Checked;
            question.LoadingDate = DateTime.Now;
            Administrator administrator = (Administrator)Session["administrator"];
            question.AdministratorID = administrator.AdministratorID;
            if (fileupload_min.HasFile)
            {
                FileInfo fileInfo = new FileInfo(fileupload_min.FileName);  
                string fileName = Guid.NewGuid().ToString();    
                fileName +=fileInfo.Extension;
                fileupload_min.SaveAs(Server.MapPath("~/Images/"+fileName));
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
                if (dataModel.AddQuestionAdmin(question))
                {
                    Response.Redirect("QuestionList.aspx");
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