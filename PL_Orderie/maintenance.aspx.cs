using System;
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

        }

        protected void buttonEditProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }
    }
}