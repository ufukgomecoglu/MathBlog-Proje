using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class AdminUpdate : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int adminId = Convert.ToInt32(Request.QueryString["ADAdministratorID"]);
                    Administrator administrator = dataModel.GetAdministrator(adminId);
                    if (administrator != null)
                    {
                        textbox_name.Text = administrator.Name;
                        textbox_secondname.Text = administrator.SecondName;
                        textbox_surname.Text = administrator.Surname;
                        textbox_username.Text = administrator.UserName;
                        textbox_eposta.Text = administrator.Eposta;
                        textbox_password.Text = administrator.Password;
                        textbox_mobilephone.Text = administrator.MobilePhone;
                        if (administrator.AuthorityID == 1)
                        {
                            radiobutton_admin.Checked = true;
                        }
                        else if (administrator.AuthorityID == 2)
                        {
                            radiobutton_mathteacher.Checked = true;
                        }
                        else
                        {
                            radiobutton_mathacademician.Checked = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("AdminList.aspx");
                    }

                }
            }
            else
            {
                Response.Redirect("AdminList.aspx");
            }
        }

        protected void linkbutton_add_Click(object sender, EventArgs e)
        {
            bool key = true;
            int adminId = Convert.ToInt32(Request.QueryString["ADAdministratorID"]);
            Administrator administrator = dataModel.GetAdministrator(adminId);
            if (dataModel.NullControl(textbox_name.Text)!=null)
            {
              
                administrator.Name = textbox_name.Text;
            }
            else
            {
                key = false;
                panel_info.Visible = true;
                label_message.Text = "Name cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_secondname.Text) != null)
            {
                administrator.SecondName = textbox_secondname.Text;
            }
            else
            {
                administrator.SecondName = "-";
            }
            if (dataModel.NullControl(textbox_surname.Text) != null)
            {
                administrator.Surname = textbox_surname.Text;
            }
            else
            {
                key = false;
                panel_info.Visible = true;
                label_message.Text = "Surname is not empty";
            }
            if (dataModel.NullControl(textbox_username.Text) != null)
            {
                administrator.UserName = textbox_username.Text;
            }
            else
            {
                key=false;
                panel_info.Visible = true;
                label_message.Text = "Username is not empty";
            }
            if (dataModel.NullControl(textbox_eposta.Text) != null)
            {
                if (dataModel.UniqueEposta(textbox_eposta.Text))
                {
                    administrator.Eposta = textbox_eposta.Text;
                }
                else
                {
                    key = false;
                    panel_info.Visible = true;
                    label_message.Text = "Such an e-mail address is registered in the system.";
                }
            }
            else
            {
                key = false;
                panel_info.Visible = true;
                label_message.Text = "E-mail cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_password.Text)!= null)
            {
                administrator.Password = textbox_password.Text;
            }
            else
            {
                key = false;
                panel_info.Visible = true;
                label_message.Text = "Password cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_mobilephone.Text) != null)
            {
                if (dataModel.NumberValidation(textbox_mobilephone.Text) != null)
                {
                    if (dataModel.ZeroAndDigit(textbox_mobilephone.Text) != null)
                    {
                        administrator.MobilePhone = textbox_mobilephone.Text;
                    }
                    else
                    {
                        key = false;
                        panel_info.Visible = true;
                        label_message.Text = "It has to be 0 and 5 and the mobile number must be 11 digits. Example 05** *** ** **.";
                    }
                }
                else
                {
                    key = false;
                    panel_info.Visible = true;
                    label_message.Text = "Only numbers can be entered.";
                }
            }
            else
            {
                key = false;
                panel_info.Visible = true;
                label_message.Text = "Mobile phone cannot be left blank.";
            }
            if (radiobutton_admin.Checked)
            {
                administrator.AuthorityID = 1;
            }
            else if (radiobutton_mathteacher.Checked)
            {
                administrator.AuthorityID = 2;
            }
            else
            {
                administrator.AuthorityID = 3;
            }
            if (key==true)
            {
                if (dataModel.UpdateAdmin(administrator))
                {
                    Response.Redirect("AdminList.aspx");
                }
                else
                {
                    panel_info.Visible = true;
                    label_message.Text = "Error occurred during registration.";
                }
            }
        }
    }
}