using BO_Orderie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class activeorders : System.Web.UI.Page
    {

        private Tables tables;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");


            if (!IsPostBack)
            {
                tables = BO_Orderie.Table.LoadAll(); //hier stecken alle Tables als einzelne Objekte drin!
                Session["tables"] = tables; // die heb ich mir in der Session auf
                LVtables.DataSource = tables;
                LVtables.DataBind(); //dadurch wirds angezeigt
            }
            else tables = (Tables)Session["tables"];
        }

        protected void GVtables_SelectedIndexChanged(object sender, ListViewSelectEventArgs e)
        {
            LVtables.SelectedIndex = e.NewSelectedIndex;  
            Session["table"] = (BO_Orderie.Table)tables[e.NewSelectedIndex];
            Response.Redirect("TableOrders.aspx");
        }
    }
}