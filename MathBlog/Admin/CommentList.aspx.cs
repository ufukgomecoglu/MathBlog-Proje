using DataAccessLayer_MathBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MathBlog.Admin
{
    public partial class CommentList : System.Web.UI.Page
    {
        DataModel dataModel = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listview_commentaktive.DataSource = dataModel.ListCommentAktive(false);
                listview_commentaktive.DataBind();
            }
            if (!IsPostBack)
            {
                listview_commentpassive.DataSource = dataModel.ListCommentPassive(true);
                listview_commentpassive.DataBind();
            }
        }

        protected void listview_commentaktive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int commentID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Aktive")
            {
                if (dataModel.AktiveComment(commentID))
                {
                    Response.Redirect("CommentList.aspx");
                }
            }
        }

        protected void listview_commentpassive_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int commentID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Passive")
            {
                if (dataModel.PassiveComment(commentID))
                {
                    Response.Redirect("CommentList.aspx");
                }
            }
        }
    }
}