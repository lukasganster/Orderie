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

        BO_Orderie.Products p;
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
                p = BO_Orderie.Product.LoadAll();
                GVProducts.DataSource = p;
                GVProducts.DataBind();
            }

        }

        protected void addProduct_Click(object sender, EventArgs e)
        {
            Session["selectedProduct"] = null;
            Response.Redirect("editproduct.aspx");
        }

        protected void editProduct(object sender, ListViewSelectEventArgs e)
        {
            p = BO_Orderie.Product.LoadAll();
            Product product = p[e.NewSelectedIndex];
            Session["selectedProduct"] = product;
            Response.Redirect("editproduct.aspx");
        }

        protected void deleteProduct(object sender, ListViewDeleteEventArgs e)
        {
            p = BO_Orderie.Product.LoadAll();
            Product product = p[e.ItemIndex];
            product.DeleteProduct();
            p.Remove(product);
            GVProducts.DataSource = p;
            GVProducts.DataBind();

        }
    }
}