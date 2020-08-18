using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class EditUser : System.Web.UI.Page
    {
        BO_Orderie.User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Unobtrusive Validation allows taking already-existing validation attributes and use them client-side 
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");
            // Check if user is manager
            if (Session["isManager"] == null) Response.Redirect("Overview.aspx");

            if (!IsPostBack)
            {
                if (Session["selectedUser"] == null)
                {
                    user = new BO_Orderie.User();
                    id.Text = "At this point the user gets a unique ID";
                }
                else
                {
                    user = (BO_Orderie.User)Session["selectedUser"];
                    id.Text = user.userID;
                    username.Text = user.username;
                    firstname.Text = user.firstName;
                    lastname.Text = user.lastName;
                    password.Text = "";
                    if (user.isManager)
                    {
                        ddIsManager.SelectedValue = "Manager";
                        ddIsManager.DataTextField = "Manager";
                        ddIsManager.DataValueField = "Manager";
                    }
                    else
                    {
                        ddIsManager.SelectedValue = "Waiter";
                        ddIsManager.DataTextField = "Waiter";
                        ddIsManager.DataValueField = "Waiter";
                    }
                }
            }
        }

        protected void saveUser(object sender, EventArgs e)
        {
            user = (BO_Orderie.User)Session["selectedUser"];
            if (user == null)
            {
                user = new BO_Orderie.User();
                user.username = username.Text;
                user.firstName = firstname.Text;
                user.lastName = lastname.Text;
                if (ddIsManager.SelectedValue == "Manager") user.isManager = true;
                else user.isManager = false;
                user.pwd = password.Text;
                user.Save();
            }
            else
            {
                user.username = username.Text;
                user.firstName = firstname.Text;
                user.lastName = lastname.Text;
                if (ddIsManager.SelectedValue == "Manager") user.isManager = true;
                else user.isManager = false;
                user.Update();
                if (password.Text != "") {
                    user.pwd = password.Text;
                    String s = user.UpdatePassword();
                    labelPassword.Text = "Password changed: " + password.Text + " / " + s;

                }
            }
            Response.Redirect("OverviewUsers.aspx");
        }
    }
}