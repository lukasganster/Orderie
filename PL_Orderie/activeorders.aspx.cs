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
                tables = BO_Orderie.Table.LoadAll();        //tables contains all tables as singular objects
                Session["tables"] = tables;                 //saving the tables in the session
                LVtables.DataSource = tables;
                LVtables.DataBind();                        //binding the data to the corresponding placeholders > view
            }
            else tables = (Tables)Session["tables"];
        }

        /*
         * 
         * displaying the table that corresponds to the selected index in the dropdown
         */

        protected void GVtables_SelectedIndexChanged(object sender, ListViewSelectEventArgs e)
        {
            LVtables.SelectedIndex = e.NewSelectedIndex;  
            Session["table"] = (BO_Orderie.Table)tables[e.NewSelectedIndex];
            Response.Redirect("TableOrders.aspx");
        }
    }
}