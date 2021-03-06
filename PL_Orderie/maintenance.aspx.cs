﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class maintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");
            // Check if user is manager
            if (Session["isManager"] == null) Response.Redirect("Overview.aspx");
        }

        protected void buttonEditProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("OverviewProducts.aspx");
        }

        protected void buttonEditTables_Click(object sender, EventArgs e)
        {
            Response.Redirect("OverviewTables.aspx");
        }

        protected void buttonEditUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("OverviewUsers.aspx");
        }
    }
}