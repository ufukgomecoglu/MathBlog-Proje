using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administrator"]!= null)
            {
                Administrator administrator = (Administrator)Session["administrator"];
                label_info.Text = $"Welcome {administrator.AuthorityName} {administrator.Name} {administrator.Surname}";
            }
            else
            {
                Response.Redirect("AdministratorEntry.aspx");
            }
        }

        protected void linkbutton_exit_Click(object sender, EventArgs e)
        {
            Session["administrator"] = null;
            Response.Redirect("AdministratorEntry.aspx");
        }
    }
}