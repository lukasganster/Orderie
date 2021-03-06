﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Orderie
{
    public class Product
    {
        //internal variables
        private string m_productID;             //ID of product
        private string m_productCategory;       //product category: selection: already defined (hard coded) list in EditProduct PL
        private string m_productName;           //name of product
        private float m_price;                  //price of product (in decimals)
        private string m_currency;              //product currency: selection: already defined (hard coded) based on currency codes
        private string m_imagePath;             //display-image path

        //properties
        public string productID {
            get {  return m_productID; }
            internal set {  m_productID = value; }
        }
        public string productCategory {
            get {  return m_productCategory; }
            set {  m_productCategory = value; }
        }
        public string productName {
            get {  return m_productName; }
            set {  m_productName = value; }
        }
        public float price {
            get{  return m_price;  }
            set{  m_price = value; }
        }
        public string currency {
            get  {return m_currency;  }
            set  {m_currency = value;  } 
        }
        
        public string imagePath {
            get  {return m_imagePath;  }
            set  { m_imagePath = value;  } 
        }

        // METHODS **********************************************************************************************************

        /*
         * READ: static method for loading and returning all products that are active (not taken out of assortment)
         * (inactive products that were active during time of older order are excluded for new order)
         * the data gets retrieved with SQL Data Reader
         * returns "allRows" which holds all active products
         */

        public static Products LoadAll()
        {
            SqlCommand cmd = new SqlCommand("select p.productID,p.productCategory,p.productName,p.price,p.currency,p.imagePath from Products p where active = 1 order by p.productCategory,p.productName;", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader(); //reads the rows from database command
            Products allRows = new Products();          //empty initialization list for saving what the reader returns
            while (reader.Read())                       //call reader > access data
            {
                Product singleProduct = fillProductFromSQLDataReader(reader);
                allRows.Add(singleProduct);             //save the singleProduct object that SQL Reader returns
            }
            return allRows;
        }

        /*
         * READ: static method for loading products assigned to order via join with help table ProductsToOrder
         * returns allRows after filled with the singular Objects (variables filled with DataReader)
         */

        internal static Products LoadProductsForOrder(Order o)
        {
            SqlCommand cmd = new SqlCommand("select p.productID, p.productCategory, p.productName, p.price, p.currency,p.imagePath from Orders o join ProductsToOrder po on o.orderID = po.orderID join Products p on po.productID = p.productID where o.orderID = @o_id", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("o_id", o.orderID));
            SqlDataReader reader = cmd.ExecuteReader();
            Products allRows = new Products();      //empty initialization list
            while (reader.Read())
            {
                Product singleProduct = fillProductFromSQLDataReader(reader);
                allRows.Add(singleProduct);
            }
            return allRows;
        }
        private static Product fillProductFromSQLDataReader(SqlDataReader reader)
        {
            Product singleProduct = new Product();
            singleProduct.productID = reader.GetString(0);
            singleProduct.productCategory = reader.GetString(1);
            singleProduct.productName = reader.GetString(2);
            singleProduct.price = (float) reader.GetDouble(3); // explicit casting from double in float was necessary (GetFloat not working)
            singleProduct.currency = reader.GetString(4);
            singleProduct.imagePath = reader.GetString(5);

            return singleProduct;
        }

        /*
         * CREATE: inserting a new product into the database
         */

        public bool SaveProduct()
        {
            string sql = "insert into products (productID, productCategory, productName, price, currency,imagePath) values (@p_id, @p_ct,@p_pd,@p_pr,@p_cr,@p_i)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();

            m_productID = Guid.NewGuid().ToString();
            cmd.Parameters.Add(new SqlParameter("p_id", this.m_productID));
            cmd.Parameters.Add(new SqlParameter("p_ct", this.m_productCategory));
            cmd.Parameters.Add(new SqlParameter("p_pd", this.m_productName));
            cmd.Parameters.Add(new SqlParameter("p_pr", this.m_price));
            cmd.Parameters.Add(new SqlParameter("p_cr", this.m_currency));
            if(this.imagePath == null)
                cmd.Parameters.Add(new SqlParameter("p_i", "images/default.png"));
            else
                cmd.Parameters.Add(new SqlParameter("p_i", this.imagePath));

            return (cmd.ExecuteNonQuery() > 0);
        }

        /*
         * UPDATE: change product properties for Maintenance
         */

        public bool UpdateProduct()
        {
            string sql = "update Products set productCategory = @p_ct, productName = @p_pd, price = @p_pr, currency = @p_cr, imagePath = @p_im where productID = @p_id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
   
            cmd.Parameters.Add(new SqlParameter("p_id", this.m_productID));
            cmd.Parameters.Add(new SqlParameter("p_ct", this.m_productCategory));
            cmd.Parameters.Add(new SqlParameter("p_pd", this.m_productName));
            cmd.Parameters.Add(new SqlParameter("p_pr", this.m_price));
            cmd.Parameters.Add(new SqlParameter("p_cr", this.m_currency));
            cmd.Parameters.Add(new SqlParameter("p_im", this.m_imagePath));

            return (cmd.ExecuteNonQuery() > 0);
        }

        /*
         * "DELETE" > actually UPDATE
         * doesn't actually get deleted for avoidance of errors, since products can still be used in orders
         */

        public bool DeleteProduct()
        {
            //string SQL = "delete from Products where productID = @p_id";
            string SQL = "update Products set active = 0 where productID = @p_id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("p_id", this.m_productID));
            return (cmd.ExecuteNonQuery() > 0);
        }

    }

}
