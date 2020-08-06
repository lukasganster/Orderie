using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Orderie
{
    public class Product
    {
        private string m_productID;
        private string m_productCategory;
        private string m_productName;
        private float m_price;
        private string m_currency;

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

        public static Products LoadAll()
        {
            SqlCommand cmd = new SqlCommand("select p.productID,p.productCategory,p.productName,p.price,p.currency from Products p order by p.productCategory,p.productName;", Main.GetConnection());
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
            singleProduct.price = (float) reader.GetDouble(3); // GetFloat ging hier nicht, deswegen explizites Casting von double in float
            singleProduct.currency = reader.GetString(4);

            return singleProduct;
        }

        internal static Products LoadProductsForOrder(Order o)
        {
            SqlCommand cmd = new SqlCommand("select p.productID, p.productCategory, p.productName, p.price, p.currency from Orders o join ProductsToOrder po on o.orderID = po.orderID join Products p on po.productID = p.productID where o.orderID = @o_id", Main.GetConnection());
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


    }

}
