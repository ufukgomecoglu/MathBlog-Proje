using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class AnswerAdd : System.Web.UI.Page
    {
        DataModel datamodel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int adminID = 0;
                    Question question = new Question();
                    int questionID = Convert.ToInt32(Request.QueryString["QuestionID"]);
                    List<Question> questions = datamodel.ShowQuestionAdmin(questionID);
                    listview_question.DataSource = questions;
                    foreach (Question item in questions)
                    {
                        adminID = item.AdministratorID;
                    }
                    if (adminID==0)
                    {
                        listview_question.DataSource = datamodel.ShowQuestionUser(questionID);
                    }
                    listview_question.DataBind();
                }
                if (!IsPostBack)
                {
                    int adminID = 0;
                    Question question = new Question();
                    int questionID = Convert.ToInt32(Request.QueryString["QuestionID"]);
                    List<Question> questions = datamodel.ShowQuestionAdmin(questionID);
                    listview_questionpicture.DataSource = questions;
                    foreach (Question item in questions)
                    {
                        adminID = item.AdministratorID;
                    }
                    if (adminID == 0)
                    {
                        listview_questionpicture.DataSource = datamodel.ShowQuestionUser(questionID);
                    }
                    listview_questionpicture.DataBind();
                }
            }
            else
            {
                Response.Redirect("AnswerList.aspx");
            }
        }
        protected void linkbutton_addanswer_Click(object sender, EventArgs e)
        {
            bool key = true;
            int questionID = Convert.ToInt32(Request.QueryString["QuestionID"]);
            Answer answer = new Answer();
            answer.QuestionID = questionID;
            Administrator administrator = (Administrator)Session["administrator"];
            answer.AdministratorID=administrator.AdministratorID;
            answer.AnswerDate = DateTime.Now;
            answer.QuestionID= questionID;
            if (datamodel.NullControl(textbox_full.Text)!=null)
            {
                answer.AnswerContent = textbox_full.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Full show cannot be left blank.";
            }
            answer.IsDeleted = !checkbox_comfirm.Checked;
            if (key==true)
            {
                if (datamodel.AddAnswer(answer))
                {
                    Response.Redirect("AnswerList.aspx");
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