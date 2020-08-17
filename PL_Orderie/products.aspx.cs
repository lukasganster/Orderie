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

        BO_Orderie.Products allProducts;                // edit also man lädt ein Object der Liste Products in die Variable allproducts oder? sorry nur dass ichs richtig kommentier
        protected void Page_Load(object sender, EventArgs e)
        {
            // edit also check if manager
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");

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
            product.DeleteProduct();
            allProducts.Remove(product);
            GVProducts.DataSource = allProducts;
            GVProducts.DataBind();
        }

        protected void GVProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}