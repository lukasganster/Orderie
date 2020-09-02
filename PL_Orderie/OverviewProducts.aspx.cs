using BO_Orderie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class products : System.Web.UI.Page
    {

        BO_Orderie.Products allProducts; //saves all products as variable
        protected void Page_Load(object sender, EventArgs e)
        {
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");
            // Check if user is manager
            if (Session["isManager"] == null) Response.Redirect("Overview.aspx");

            if (!IsPostBack)
            {
                allProducts = BO_Orderie.Product.LoadAll();
                GVProducts.DataSource = allProducts;
                GVProducts.DataBind();
            }
        }

        protected void addProduct_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = null;
            Response.Redirect("EditProduct.aspx");
        }

        protected void editProduct(object sender, ListViewSelectEventArgs e)
        {
            allProducts = BO_Orderie.Product.LoadAll();
            Product product = allProducts[e.NewSelectedIndex];
            Session["selectedProduct"] = product;
            Response.Redirect("EditProduct.aspx");
        }

        protected void deleteProduct(object sender, ListViewDeleteEventArgs e)
        {
            allProducts = BO_Orderie.Product.LoadAll();
            Product product = allProducts[e.ItemIndex];
            product.DeleteProduct(); // Sets product inactive in db instead of deleting. To keep it for existing orders
            allProducts.Remove(product); // Removes product in view
            GVProducts.DataSource = allProducts;
            GVProducts.DataBind();
        }

        protected void GVProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}