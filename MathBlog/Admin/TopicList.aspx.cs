using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class TopicList : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listview_topicaktive.DataSource = dataModel.ListTopicAktive(false);
                listview_topicaktive.DataBind();
            }
            if (!IsPostBack)
            {
                listview_topicpassive.DataSource = dataModel.ListTopicPassive(true);
                listview_topicpassive.DataBind();
            }
        }

        protected void listview_topicaktive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int topicID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Aktive")
            {
                if (dataModel.AKtiveTopic(topicID))
                {
                    Response.Redirect("TopicList.aspx");
                }
            }
        }

        protected void listview_topicpassive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int topicID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Passive")
            {
                if(dataModel.PassiveTopic(topicID))
                {
                    Response.Redirect("TopicList.aspx");
                }
            }
        }
    }
}