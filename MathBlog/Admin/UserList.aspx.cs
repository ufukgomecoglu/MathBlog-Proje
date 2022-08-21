using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listview_user.DataSource = dataModel.ListUser(false);
                listview_user.DataBind();
            }
            if (!IsPostBack)
            {
                listview_useraktive.DataSource = dataModel.ListUserPasive(true);
                listview_useraktive.DataBind();
            }
        }

        protected void listview_user_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int userID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Aktive")
            {
                if (dataModel.PasiveUser(userID))
                {
                    Response.Redirect("UserList.aspx");
                }
            }
            if (e.CommandName== "Delete")
            {
                if (dataModel.DeleteUser(userID))
                {
                    Response.Redirect("UserList.aspx");
                }
            }
        }

       

        protected void listview_useraktive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int userID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Passive")
            {
                if (dataModel.AktiveUser(userID))
                {
                    Response.Redirect("UserList.aspx");
                }
            }
            if (e.CommandName == "Delete")
            {
                if (dataModel.DeleteUser(userID))
                {
                    Response.Redirect("UserList.aspx");
                }
            }
        }
    }
}