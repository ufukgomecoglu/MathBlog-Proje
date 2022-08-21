using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.User
{
    public partial class Login : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkbutton_login_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textbox_eposta.Text) && !String.IsNullOrEmpty(textbox_Password.Text))
            {
                if (dataModel.ValidEposta(textbox_eposta.Text))
                {
                    DataAccessLayer_MathBlog.User user = dataModel.LoginUser(textbox_eposta.Text, textbox_Password.Text);
                    if (user != null)
                    {
                        Session["User"] = user;
                        Response.Redirect("UserDefault.aspx");
                    }
                    else
                    {
                        panel_Info.Visible = true;
                        label_Message.Text = "You have entered incorrectly.";
                    }
                }
                else
                {
                    panel_Info.Visible = true;
                    label_Message.Text = "Must be @ and .com.";
                }
            }
            else
            {
                panel_Info.Visible = true;
                label_Message.Text = "Email and password cannot be left blank.";
            }
        }
    }
}