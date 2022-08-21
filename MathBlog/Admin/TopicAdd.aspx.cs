using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class TopicAdd : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();  
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkbutton_addtopic_Click(object sender, EventArgs e)
        {
            if (dataModel.NullControl(textbox_topicname.Text)!=null)
            {
                if (dataModel.UniqueTopic(textbox_topicname.Text))
                {
                    Topic topic = new Topic();
                    topic.TopicName = textbox_topicname.Text;
                    topic.IsDeleted = false;
                    if (dataModel.AddTopic(topic))
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