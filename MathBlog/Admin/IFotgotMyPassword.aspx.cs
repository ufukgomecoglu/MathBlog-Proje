using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class IFotgotMyPassword : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkbutton_send_Click(object sender, EventArgs e)
        {
            int adminID = 0;
            string eposta = "";
            bool key = true;
            if (!String.IsNullOrEmpty(textbox_eposta.Text) && !String.IsNullOrEmpty(textbox_UserName.Text))
            {
                if (dataModel.ValidEposta(textbox_eposta.Text))
                {
                    Administrator administrator = dataModel.IForgotMyPassword(textbox_eposta.Text, textbox_UserName.Text);
                    if (administrator != null)
                    {
                        adminID = administrator.AdministratorID;
                        eposta = administrator.Eposta;
                        key = true;
                    }
                    else
                    {
                        panel_Message.Visible = true;
                        label_Eror.Text = "You have entered incorrectly.";
                        key = false;
                    }
                }
                else
                {
                    panel_Message.Visible = true;
                    label_Eror.Text = "Must be @ and .com.";
                    key = false;
                }
            }
            else
            {
                panel_Message.Visible = true;
                label_Eror.Text = "Email and password cannot be left blank.";
                key= false; 
            }
            if (key==true)
            {
                Random generator = new Random();
                string otp = generator.Next(0, 1000000).ToString("D6");
                if (dataModel.UpdatePasswordAdmin(otp,adminID))
                {
                    if (dataModel.SendMailForgot(eposta, otp))
                    {
                        Response.Redirect("AdministratorEntry.aspx");
                    }
                     else
                    {
                        panel_Message.Visible = true;
                        label_Eror.Text = "create eror";
                    }
                    
                }
                else
                {
                    panel_Message.Visible = true;
                    label_Eror.Text = "create eror";
                }
            }
        }
    }
}