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
                ddTables.DataSource = tables;
                ddTables.DataBind();
                //selectTable();



                selectedProducts = (Products) Session["selectedProducts"];
                if (selectedProducts == null)
                {
                    selectedProducts = new Products();
                }

                BO_Orderie.Table t = (BO_Orderie.Table)Session["selectedTable"];
                if(t != null)
                    ddTables.SelectedValue = t.tableName;
                

                GVProducts.DataSource = selectedProducts;
                GVProducts.DataBind();

                Session["selectedProducts"] = selectedProducts;

                Response.Write("<script>alert('2here')</script>");    
            }
            else
            {
                tables = (Tables)Session["tables"];
                selectedProducts = (Products)Session["selectedProducts"];
                
            }
        }

        protected void addProduct_Click(object sender, EventArgs e)
        {
           
            selectTable();
            selectedProducts = (Products)Session["selectedProducts"];
            Response.Redirect("addproducttoorder.aspx");
        }

        protected void dropDownSelect(object sender, EventArgs e)
        {
            selectTable();
        }

        private void selectTable()
        {
            BO_Orderie.Table t = tables[ddTables.SelectedIndex];
            Session["selectedTable"] = t;
            Response.Write("<script>alert('" + t.tableName + "')</script>");
            
        }

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
            label.Text = o.table.tableName + " " + o.paid + " - " + o.user.userID + " ---" + o.products.Count;
            o.SaveOrder();
        }

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