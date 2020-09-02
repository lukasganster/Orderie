using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_Orderie;

namespace PL_Orderie
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Unobtrusive Validation allows taking already-existing validation attributes and use them client-side 
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None; 
            labelHint.Style.Add("display", "none");
        }

        /*
         * login information gets sent to BO to check the username and corresponding encrypted password
         */

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            String username = textUsername.Text.ToString();
            String pwd = textPwd.Text.ToString();
            Boolean loginOk = BO_Orderie.Main.login(username, pwd); // Return value User object better solution?
            if (loginOk)
            {
                Session["username"] = username;
                Session["password"] = pwd;
                BO_Orderie.User user = BO_Orderie.User.getUserByUsername(username);
                Session["user"] = user;
                if (user.isManager) Session["isManager"] = true;
                Response.Redirect("Overview.aspx");
            }
            else
            {
                labelHint.Text = "False user/password combination";
                labelHint.Style.Add("display", "block");
            }
        }
    }
}