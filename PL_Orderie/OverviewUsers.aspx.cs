using BO_Orderie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class OverviewUsers : System.Web.UI.Page
    {
        BO_Orderie.Users allUsers;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");
            // Check if user is manager
            if (Session["isManager"] == null) Response.Redirect("Overview.aspx");

            if (!IsPostBack)
            {
                allUsers = BO_Orderie.User.LoadAll();
                GVUsers.DataSource = allUsers;
                GVUsers.DataBind();
            }
        }

        protected void addUser_Click(object sender, EventArgs e)
        {
            Session["selectedUser"] = null;
            Response.Redirect("EditUser.aspx");
        }

        protected void editUser(object sender, ListViewSelectEventArgs e)
        {
            allUsers = BO_Orderie.User.LoadAll();
            User user = allUsers[e.NewSelectedIndex];
            Session["selectedUser"] = user;
            Response.Redirect("EditUser.aspx");
        }

        protected void deleteUser(object sender, ListViewDeleteEventArgs e)
        {
           allUsers = BO_Orderie.User.LoadAll();
           User user = allUsers[e.ItemIndex];
            allUsers.Remove(user);
            user.Delete();
           GVUsers.DataSource = allUsers;
           GVUsers.DataBind();
        }

        protected void GVUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}