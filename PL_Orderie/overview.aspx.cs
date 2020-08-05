using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String u = "";
            String pw = "";
            if (Session["username"] != null && Session["password"] != null)
            {
                u = Session["username"].ToString();
                pw = Session["password"].ToString();
            }
            if( (bool) Session["loggedIn"] == true)
            {
                Console.WriteLine("ok");
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}