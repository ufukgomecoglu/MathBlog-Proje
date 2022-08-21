using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.User
{
    public partial class UserMasterPage : System.Web.UI.MasterPage
    {
        DataModel dataModel= new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"]==null)
            {
                panel_logout.Visible = true;
                panel_login.Visible = false;
            }
            else
            {
                panel_logout.Visible = false;
                panel_login.Visible = true;
                DataAccessLayer_MathBlog.User user = (DataAccessLayer_MathBlog.User)Session["User"];
                label_user.Text = $"Welcome {user.UserName}";
            }
            repeater_topic.DataSource = dataModel.ListTopic(false);
            repeater_topic.DataBind();
        }

        protected void linkbutton_profil_Click(object sender, EventArgs e)
        {
            DataAccessLayer_MathBlog.User user = (DataAccessLayer_MathBlog.User)Session["User"];
            Response.Redirect($"MyProfil.aspx?UserID={user.UserID}");
        }

        protected void linkbutton_exit_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("UserDefault.aspx");
        }
    }
}