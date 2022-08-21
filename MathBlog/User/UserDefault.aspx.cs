using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.User
{
    public partial class UserDefult : System.Web.UI.Page
    {
        DataModel dataModel= new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                if (!IsPostBack)
                {
                    List<Question> questions = dataModel.ListQuestionAktive(false);
                    List<Question> questionsorder = questions.OrderBy(o => o.LoadingDate).ToList();
                    listview_question.DataSource = questionsorder;
                    listview_question.DataBind();
                }
            }
            else
            {
                int topicID = Convert.ToInt32(Request.QueryString["TopicID"]);
                if (!IsPostBack)
                {
                    List<Question> questions = dataModel.GetQuestionByTopic(topicID);
                    List<Question> questionsorder = questions.OrderBy(o => o.LoadingDate).ToList();
                    listview_question.DataSource = questionsorder;
                    listview_question.DataBind();
                }
            }
        }
    }
}