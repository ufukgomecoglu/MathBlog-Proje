using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class Answerlist : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listview_answeraktive.DataSource = dataModel.ListAnswerAktive(false);
                listview_answeraktive.DataBind();
            }
            if (!IsPostBack)
            {
                listview_answerpassive.DataSource = dataModel.ListAnswerPassive(true);
                listview_answerpassive.DataBind();
            }
        }

        protected void listview_answeraktive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int answerID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Aktive")
            {
                if (dataModel.AktiveAnswer(answerID))
                {
                    Response.Redirect("AnswerList.aspx");
                }
            }
        }

        protected void listview_answerpassive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            int answerID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Passive")
            {
                if (dataModel.PassiveAnswer(answerID))
                {
                    Response.Redirect("AnswerList.aspx");
                }
            }
        }
    }
}