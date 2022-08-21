using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class AdminList : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listview_admin.DataSource = dataModel.ListAdmin(false);
                listview_admin.DataBind();
            }
            if (!IsPostBack)
            {
                listview_adminretunit.DataSource = dataModel.ListAdminReturnIt(true);
                listview_adminretunit.DataBind();
            }
        }

        protected void listview_admin_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int administratorID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                if (dataModel.DeleteAdmin(administratorID))
                {
                    Response.Redirect("AdminList.aspx");
                }
            }
        }

        protected void listview_adminretunit_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int administratorID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "returnit")
            {
                if (dataModel.ReturnItAdmin(administratorID))
                {
                    Response.Redirect("AdminList.aspx");
                }
            }
        }
    }
}