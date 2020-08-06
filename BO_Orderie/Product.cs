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
        public int productID { get; internal set; }
        public int productCategory { get; set; }
        public string productName { get; set; }
        public float price { get; set; }
        public string currency { get; set; }

        public static Products LoadAll()
        {
            SqlCommand cmd = new SqlCommand("select p.productID,p.productCategory,p.productName,p.price,p.currency from Products p;", Main.GetConnection());
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
            singleProduct.productID = reader.GetInt32(0);
            singleProduct.productCategory = reader.GetInt32(1);
            singleProduct.productName = reader.GetString(2);
            singleProduct.price = reader.GetFloat(3);
            singleProduct.currency = reader.GetString(4);

            return singleProduct;
        }
    }

}
