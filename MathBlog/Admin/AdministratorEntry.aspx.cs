using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class AdministratorEntry : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkbutton_Login_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(textbox_UserName.Text) && !String.IsNullOrEmpty(textbox_Password.Text) )
            {
                if (dataModel.ValidEposta(textbox_UserName.Text))
                {
                    Administrator administrator = dataModel.Login(textbox_UserName.Text, textbox_Password.Text);
                    if (administrator != null)
                    {
                        Session["administrator"] = administrator;
                        Response.Redirect("AdminDefault.aspx");
                    }
                    else
                    {
                        panel_Message.Visible = true;
                        label_Eror.Text = "You have entered incorrectly.";
                    }
                }
                else
                {
                    panel_Message.Visible = true;
                    label_Eror.Text = "Must be @ and .com.";
                }
            }
            else
            {
                panel_Message.Visible = true;
                label_Eror.Text = "Email and password cannot be left blank.";
            }
        }

    }
}