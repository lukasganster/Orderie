using BO_Orderie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{


    public partial class addproducttoorder : System.Web.UI.Page
    {

        private Products products;
        private Products selectedProducts;
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
                products = BO_Orderie.Product.LoadAll(); //hier stecken alle Tables als einzelne Objekte drin!
                Session["products"] = products; // die heb ich mir in der Session auf
                GVProductsAv.DataSource = products;
                GVProductsAv.DataBind(); //dadurch wirds angezeigt

                selectedProducts = (Products)Session["selectedProducts"];
                if (selectedProducts == null)
                {
                    selectedProducts = new Products();
                }

                //Response.Write("<script>alert("+ selectedProducts[0].productName +")</script>");
            }
            else
            {
                products = (Products)Session["products"];
                if (selectedProducts == null)
                    selectedProducts = new Products();
            }

            BO_Orderie.Table t = (BO_Orderie.Table)Session["selectedTable"];
            Response.Write("<script>alert('" + t.tableName + "')</script>");
        }

        protected void chooseFromProducts(object sender, ListViewSelectEventArgs e)
        {
            BO_Orderie.Product p = products[e.NewSelectedIndex];
            selectedProducts = (Products)Session["selectedProducts"];
            selectedProducts.Add(p);
            Session["selectedProducts"] = selectedProducts;
            Response.Redirect("addneworder.aspx");
        }
    }
}