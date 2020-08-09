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
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");
        }
        protected void buttonNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("neworder.aspx");
        }
        protected void buttonActive_Click(object sender, EventArgs e)
        {
            Response.Redirect("activeorders.aspx");
        }
        protected void buttonNew_Click1(object sender, EventArgs e)
        {
            Response.Redirect("addneworder.aspx");
        }

        protected void buttonMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("maintenance.aspx");
        }
    }
}