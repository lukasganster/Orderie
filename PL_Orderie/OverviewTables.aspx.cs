using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class OverviewTables : System.Web.UI.Page
    {
        private BO_Orderie.Tables allTables;        //one instance of all table objects saved in list

        protected void Page_Load(object sender, EventArgs e)
        {
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");
            // Check if user is manager
            if (Session["isManager"] == null) Response.Redirect("Overview.aspx");

            if (!IsPostBack)
            {
                // !! edit check ob das wirklich ALLE bringt
                allTables = BO_Orderie.Table.LoadAll();
                GVTables.DataSource = allTables;
                GVTables.DataBind();
            }
        }
        protected void editTable(object sender, ListViewSelectEventArgs e)
        {
            allTables = BO_Orderie.Table.LoadAll();
            BO_Orderie.Table table = allTables[e.NewSelectedIndex];
            Session["selectedTable"] = table;
            Response.Redirect("EditTable.aspx");
        }

        protected void deleteTable(object sender, ListViewDeleteEventArgs e)
        {
            allTables = BO_Orderie.Table.LoadAll();
            BO_Orderie.Table table = allTables[e.ItemIndex];
            table.Delete();
            allTables.Remove(table);
            GVTables.DataSource = allTables;
            GVTables.DataBind();
        }
        protected void addTable_Click(object sender, EventArgs e)
        {
            Session["selectedTable"] = null;
            Response.Redirect("EditTable.aspx");
        }
        protected void GVTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}