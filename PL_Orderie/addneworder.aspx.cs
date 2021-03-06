﻿using BO_Orderie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Orderie
{
    public partial class addneworder : System.Web.UI.Page
    {
        private Tables tables;
        private Products selectedProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Guard clause for login purposes
            if (Session["username"] == null || Session["password"] == null) Response.Redirect("Index.aspx");

            if (!IsPostBack)                    //when loading the page for the first time
            {
                tables = BO_Orderie.Table.LoadAll();
                Session["tables"] = tables;
                ddTables.DataSource = tables;
                ddTables.DataBind();

                selectedProducts = (Products) Session["selectedProducts"];
                if (selectedProducts == null) selectedProducts = new Products();

                BO_Orderie.Table t = (BO_Orderie.Table)Session["selectedTable"];

                if(t != null) ddTables.SelectedValue = t.tableName;
                
                GVProducts.DataSource = selectedProducts;
                GVProducts.DataBind();

                Session["selectedProducts"] = selectedProducts;

            }
            else                                //when order information already selected, but order not placed
            {
                tables = (Tables)Session["tables"];
                selectedProducts = (Products)Session["selectedProducts"];
            }
        }

        /*
         * Adding a new product redirects to select products page
         */

        protected void addProduct_Click(object sender, EventArgs e)
        {
            selectTable();
            selectedProducts = (Products)Session["selectedProducts"];         
            Response.Redirect("addproducttoorder.aspx");
        }

        /*
         * 
         */

        protected void dropDownSelect(object sender, EventArgs e)
        {
            selectTable();
        }

        /*
         * saving selected Table into session
         */

        private void selectTable()
        {
            BO_Orderie.Table t = tables[ddTables.SelectedIndex];
            Session["selectedTable"] = t;
        }

        /*
         * sending information for placing the order in the BO
         */

        protected void finishOrder_Click(object sender, EventArgs e)
        {
            User u = (User)Session["user"];
            Order o = new Order
            {
                table = (BO_Orderie.Table)Session["selectedTable"],
                paid = false,
                products = (Products)Session["selectedProducts"],
                user = u
            };
            o.SaveOrder();
            Session["selectedProducts"] = null;
            Response.Redirect("ActiveOrders.aspx");     //after order is placed > redirection to active orders page
        }

        /*
         * deleting unwanted products from order
         */

        protected void deleteFromOrder(object sender, ListViewDeleteEventArgs e)
        {
            selectedProducts = (Products)Session["selectedProducts"];
            Product p = selectedProducts[e.ItemIndex];
            selectedProducts.Remove(p);
            GVProducts.DataSource = selectedProducts;
            GVProducts.DataBind();
            Session["selectedProducts"] = selectedProducts;
        }
    }
}