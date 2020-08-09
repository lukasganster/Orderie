using System;
using System.Collections.Generic;
using System.IO;
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
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");

            if (!IsPostBack)
            {
                if (Session["selectedProduct"] == null)
                {
                    product = new BO_Orderie.Product();
                    id.Text = "At this point the product gets a unique ID";
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
                id.Text = "At this point the product gets a unique ID";
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

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/images/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    product.imagePath = "/images/" + filename;
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }

        }

    }
}