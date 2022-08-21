using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class TopicUpdate : System.Web.UI.Page
    {
        DataModel datamodel= new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int topicId = Convert.ToInt32(Request.QueryString["TopicID"]);
                    Topic topic = datamodel.GetTopic(topicId);
                    if (topic != null)
                    {
                        textbox_name.Text = topic.TopicName;
                    }
                    else
                    {
                        Response.Redirect("TopicList.aspx");
                    }

                }
            }
            else
            {
                Response.Redirect("TopicList.aspx");
            }
        }

        protected void linkbutton_add_Click(object sender, EventArgs e)
        {
            int topicId = Convert.ToInt32(Request.QueryString["TopicID"]);
            Topic topic = datamodel.GetTopic  (topicId);
            if (datamodel.NullControl(textbox_name.Text) != null)
            {
                if (datamodel.UniqueTopic(textbox_name.Text))
                {
                    topic.TopicName = textbox_name.Text;
                    topic.IsDeleted = false;
                    if (datamodel.UpdateTopic(topic))
                    {
                        Response.Redirect("TopicList.aspx");
                    }
                    else
                    {
                        panel_info.Visible = true;
                        label_message.Text = "Can not add topic.";
                    }
                }
                else
                {
                    panel_info.Visible = true;
                    label_message.Text = "This topic name exists in the system.";
                }
            }
            else
            {
                panel_info.Visible = true;
                label_message.Text = "Topic name cannot be left blank.";
            }
        }
    }
}