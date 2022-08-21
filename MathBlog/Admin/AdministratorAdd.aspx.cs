using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class AdministratorAdd : System.Web.UI.Page
    {
        DataModel dataModel= new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkbutton_add_Click(object sender, EventArgs e)
        {
            Administrator administrator=new Administrator();
            bool key = true;
            if (dataModel.NullControl(textbox_name.Text)!= null)
            {
                administrator.Name=textbox_name.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Name cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_secondname.Text) == null)
            {
                administrator.SecondName = "-";
            }
            else
            {
                administrator.SecondName = textbox_secondname.Text;
            }
            if (dataModel.NullControl(textbox_surname.Text) != null)
            {
                administrator.Surname = textbox_surname.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Surname cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_username.Text) != null)
            {
                administrator.UserName = textbox_username.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Username cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_mobilephone.Text)!=null)
            {
                if (dataModel.NumberValidation(textbox_mobilephone.Text) != null)
                {
                    if (dataModel.ZeroAndDigit(textbox_mobilephone.Text)!=null)
                    {
                        administrator.MobilePhone = textbox_mobilephone.Text;
                    }
                    else
                    {
                        key = false;
                        panel_Info.Visible = true;
                        label_Message.Text = "It has to be 0 and 5 and the mobile number must be 11 digits. Example 05** *** ** **.";
                    }
                }
                else
                {
                    key = false;
                    panel_Info.Visible = true;
                    label_Message.Text = "Only numbers can be entered.";
                }
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Mobile phone cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_eposta.Text)!=null)
            {
                if (dataModel.ValidEposta(textbox_eposta.Text))
                {
                    if (dataModel.UniqueEposta(textbox_eposta.Text))
                    {
                        administrator.Eposta = textbox_eposta.Text;
                    }
                    else
                    {
                        key = false;
                        panel_Info.Visible = true;
                        label_Message.Text = "Such an e-mail address is registered in the system.";
                    }
                }
                else
                {
                    key = false;
                    panel_Info.Visible = true;
                    label_Message.Text = "Must be @ and .com.";
                }
                
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "E-mail cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_password.Text) != null)
            {
                administrator.Password = textbox_password.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Password cannot be left blank.";
            }
            if (radiobutton_administrator.Checked)
            {
                administrator.AuthorityID = 1;
            }
            else if (radiobutton_mathteacher.Checked)
            {
                administrator.AuthorityID = 2;
            }
            else if(radiobutton_mathacademician.Checked)
            {
                administrator.AuthorityID = 3;
            }
            else
            {
                key=false;
                panel_Info.Visible = true;
                label_Message.Text = "You must tick one of the 3.";
            }
            if (key==true)
            {
                if (dataModel.AddAdministrator(administrator))
                {
                    Response.Redirect("AdminDefault.aspx");
                }
                else
                {
                    panel_Info.Visible = true;
                    label_Message.Text = "Error occurred during registration.";
                }
            }
        }
    }
}