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

        protected void Page_Load(object sender, EventArgs e)
        {
            String u = "";
            String pw = "";
            if (Session["username"] != null && Session["password"] != null)
            {
                u = Session["username"].ToString();
                pw = Session["password"].ToString();
            }
            if (Session["loggedIn"] != null)
            {
            }
            else
            {
                Response.Redirect("index.aspx");
            }


            if (!IsPostBack)
            {
                tables = BO_Orderie.Table.LoadAll(); //hier stecken alle Tables als einzelne Objekte drin!
                Session["tables"] = tables; // die heb ich mir in der Session auf


            }
            else
            {
                tables = (Tables)Session["tables"];
            }

            currentTable = (BO_Orderie.Table)Session["table"];
            lblNr.Text = "Orders for " + currentTable.tableName;
        }
    }
}