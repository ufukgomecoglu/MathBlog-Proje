using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.User
{
    public partial class MyProfil : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int userId = Convert.ToInt32(Request.QueryString["UserID"]);
                    DataAccessLayer_MathBlog.User user = dataModel.GetUser(userId);
                    if (user != null)
                    {
                        textbox_name.Text = user.Name;
                        textbox_secondname.Text = user.SecondName;
                        textbox_surname.Text = user.Surname;
                        textbox_username.Text = user.UserName;
                        textbox_birthdate.Text = user.Birthdate.ToString("yyyy-MM-dd");
                        textbox_mobilephone.Text = user.MobilePhone;
                        textbox_eposta.Text=user.Eposta;
                        textbox_password.Text = user.Password;
                        textbox_passwordagain.Text = user.Password;
                    }
                    else
                    {
                        Response.Redirect("UserDefault.aspx");
                    }

                }
            }
            else
            {
                Response.Redirect("UserDefault.aspx");
            }
        }

        protected void linkbutton_add_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Request.QueryString["UserID"]);
            DataAccessLayer_MathBlog.User user = dataModel.GetUser(userId);
            bool key = true;
            if (dataModel.NullControl(textbox_name.Text) != null)
            {
                user.Name = textbox_name.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Name cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_secondname.Text) == null)
            {
                user.SecondName = "-";
            }
            else
            {
                user.SecondName = textbox_secondname.Text;
            }
            if (dataModel.NullControl(textbox_surname.Text) != null)
            {
                user.Surname = textbox_surname.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Surname cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_username.Text) != null)
            {
                user.UserName = textbox_username.Text;
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Username cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_birthdate.Text) != null)
            {
                if (Convert.ToDateTime(textbox_birthdate.Text) < DateTime.Now)
                {
                    if (DateTime.Now.Year - Convert.ToDateTime(textbox_birthdate.Text).Year >= 10)
                    {
                        if (DateTime.Now.Year - Convert.ToDateTime(textbox_birthdate.Text).Year <= 100)
                        {
                            user.Birthdate = Convert.ToDateTime(textbox_birthdate.Text);
                        }
                        else
                        {
                            key = false;
                            panel_Info.Visible = true;
                            label_Message.Text = "I guess you're a little old for math.";
                        }
                    }
                    else
                    {
                        key = false;
                        panel_Info.Visible = true;
                        label_Message.Text = "You cannot register under the age of 10.";
                    }

                }
                else
                {
                    key = false;
                    panel_Info.Visible = true;
                    label_Message.Text = "The date of birth cannot be greater than today.";
                }
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Birthdate cannot be left blank.";
            }
            if (dataModel.NullControl(textbox_mobilephone.Text) != null)
            {
                if (dataModel.NumberValidation(textbox_mobilephone.Text) != null)
                {
                    if (dataModel.ZeroAndDigit(textbox_mobilephone.Text) != null)
                    {
                        user.MobilePhone = textbox_mobilephone.Text;
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
            if (dataModel.NullControl(textbox_eposta.Text) != null)
            {
                if (dataModel.ValidEposta(textbox_eposta.Text))
                {
                    if (dataModel.UniqueEposta(textbox_eposta.Text))
                    {
                        user.Eposta = textbox_eposta.Text;
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
                if (textbox_passwordagain.Text == textbox_password.Text)
                {
                    user.Password = textbox_password.Text;
                }
                else
                {
                    key = false;
                    panel_Info.Visible = true;
                    label_Message.Text = "You entered the wrong value.";
                }
            }
            else
            {
                key = false;
                panel_Info.Visible = true;
                label_Message.Text = "Password cannot be left blank.";
            }
            if (key == true)
            {
                if (dataModel.UpdateUser(user))
                {
                    Response.Redirect("UserDefault.aspx");
                }
                else
                {
                    panel_Info.Visible = true;
                    label_Message.Text = "Error occurred during registration.";
                    Response.Redirect($"MyProfil.aspx?UserID={user.UserID}");
                }
            }
        }
    }
}