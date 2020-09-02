using BO_Orderie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class tableorders : System.Web.UI.Page
    {
        private Tables tables;
        private BO_Orderie.Table currentTable;
        private BO_Orderie.Orders orders;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");

            if (!IsPostBack)
            {
                tables = BO_Orderie.Table.LoadAll();
                Session["tables"] = tables; // saves in session
            }
            else
            {
                tables = (Tables)Session["tables"];
            }

            currentTable = (BO_Orderie.Table)Session["table"];
            lblNr.Text = "Orders for " + currentTable.tableName;

            // Sets order count for table

            orders = BO_Orderie.Table.LoadOrdersForTable(currentTable);
            lblNr.Text += " (" + orders.Count +")";

            // If table has no orders
            if (orders.Count <= 0) lblNr.Text = currentTable.tableName + " has no active orders";

            lvOrders.DataSource = orders;
            lvOrders.DataBind();
        }


        /*
         * Sets order as paid and removes it
         * */
        protected void lvOrders_Select(object sender, ListViewSelectEventArgs e)
        {
            Order o = orders[e.NewSelectedIndex];
            o.UpdatePaid();
            Response.Redirect("TableOrders.aspx");
        }
    }
}