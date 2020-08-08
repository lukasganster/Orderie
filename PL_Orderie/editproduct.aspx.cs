using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class editproduct : System.Web.UI.Page
    {

        BO_Orderie.Product product;
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

                if (Session["selectedProduct"] == null)
                {
                    product = new BO_Orderie.Product();
                    label.Text = "new";
                }
                else
                {
                    product = (BO_Orderie.Product)Session["selectedProduct"];
                    id.Text = product.productID;
                    name.Text = product.productName;
                    ddCategories.SelectedValue = product.productCategory;
                    ddCategories.DataTextField = product.productCategory;
                    ddCategories.DataValueField = product.productCategory;
                    price.Text = product.price.ToString();
                    ddCurrencies.SelectedValue = product.currency;
                    ddCurrencies.DataTextField = product.currency;
                    ddCurrencies.DataValueField = product.currency;

                }
            }
        }

        protected void categorySelect(object sender, EventArgs e)
        {
            String s = ddCategories.SelectedValue;
            
        }

        protected void ddCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = ddCurrencies.SelectedValue;
        }

        protected void saveProduct(object sender, EventArgs e)
        {
            product = (BO_Orderie.Product)Session["selectedProduct"];
            if (product == null)
            {
                product = new BO_Orderie.Product();
                product.productName = name.Text;
                product.productCategory = ddCategories.SelectedValue;
                float f = float.Parse(price.Text);
                product.price = f;
                product.currency = ddCurrencies.SelectedValue;
                product.SaveProduct();
            }
            else
            {
                product.productName = name.Text;
                product.productCategory = ddCategories.SelectedValue;
                float f = float.Parse(price.Text);
                product.price = f;
                product.currency = ddCurrencies.SelectedValue;
                product.UpdateProduct();
            }
        }
    }
}