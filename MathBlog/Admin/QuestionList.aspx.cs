using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class QuestionList : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                listview_questionaktive.DataSource = dataModel.ListQuestionAktive(false);
                listview_questionaktive.DataBind ();
            }
            if (!IsPostBack)
            {
                listview_questionpassive.DataSource = dataModel.ListQuestionPassive(true);
                listview_questionpassive.DataBind();
            }
        }

        protected void listview_questionaktive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int questionID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName=="Aktive")
            {
                if (dataModel.AktiveQuestion(questionID))
                {
                    Response.Redirect("QuestionList.aspx");
                }
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
        }
    }
}