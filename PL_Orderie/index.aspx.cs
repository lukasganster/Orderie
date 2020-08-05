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

        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            String username = textUsername.Text.ToString();
            String pwd = textPwd.Text.ToString();
            Boolean loginOk = BO_Orderie.Main.login(username, pwd);
            if (loginOk)
            {
                labelHint.Text = "true";
                Session["username"] = username;
                Session["pwd"] = pwd;
                Response.Redirect("overview.aspx");
            }
            else
            {
                labelHint.Text = "false";
            }
        }
    }
}