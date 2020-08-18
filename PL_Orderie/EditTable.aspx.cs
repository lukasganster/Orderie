using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class EditTable : System.Web.UI.Page
    {

        BO_Orderie.Table table;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Unobtrusive Validation allows taking already-existing validation attributes and use them client-side 
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");
            // Check if user is manager
            if (Session["isManager"] == null) Response.Redirect("Overview.aspx");

            if (!IsPostBack)
            {
                if (Session["selectedTable"] == null)
                {
                    table = new BO_Orderie.Table();
                    id.Text = "At this point the product gets a unique ID";
                }
                else
                {
                    table = (BO_Orderie.Table)Session["selectedTable"];
                    id.Text = table.tableID;
                    name.Text = table.tableName;
                }
            }
        }

        protected void saveTable(object sender, EventArgs e)
        {
            table = (BO_Orderie.Table)Session["selectedTable"];
            if (table == null)
            {
                table = new BO_Orderie.Table();
                table.tableName = name.Text;
                table.SaveTable();
                id.Text = "At this point the table gets a unique ID";
            }
            else
            {
                table.tableName = name.Text;
                table.UpdateTable();
            }
            Response.Redirect("OverviewTables.aspx");
        }

    }
}