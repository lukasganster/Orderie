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
            label.Text = BO_Orderie.Main.getUsers();
            Console.WriteLine(BO_Orderie.Main.getUsers());
        }
    }
}