using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Orderie
{
    public class Order
    {
        private string m_orderID = "";
        private string m_tableID;
        private bool m_paid;
        private int m_userID;
        private DateTime m_timeOrdered;
        private User m_user;
        private Products m_products;
        private Table m_table;

        public string orderID
        {
            get { return m_orderID;  }
            internal set { m_orderID = value;  }
        }
        public string tableID
        {
            get { return m_tableID;  }
            set { m_tableID = value; }
        }
        public bool paid
        {
            get { return m_paid;  }
            set { m_paid = value;  }
        }
        public int userID
        {
            get { return m_userID;  }
            set { m_userID = value;  }
        }

        public User user
        {
            get { return m_user; }
            set { m_user = value; }
        }

        public Products products
        {
            get { return m_products; }
            set { m_products = value; }
        }

        public Table table
        {
            get { return m_table; }
            set { m_table = value; }
        }

        public DateTime timeOrdered
        {
            get { return m_timeOrdered; }
            set { m_timeOrdered = value; }
        }

        public float priceSum
        {
            get {
                float i = 0;
                foreach(Product p in this.products)
                    {
                    i += p.price;
                    }
                return i;
            }
        }
        //save
        public bool SaveOrder()
        {
            string SQL = "insert into Orders (orderID, tableID, paid, userID,timeOrdered) values (@o_id, @o_tbID, @o_pd,@o_uID,CURRENT_TIMESTAMP)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();

            m_orderID = Guid.NewGuid().ToString();                                         //new construct of GUID structure
            cmd.Parameters.Add(new SqlParameter("o_id", this.m_orderID));
            cmd.Parameters.Add(new SqlParameter("o_tbID", this.table.tableID));
            cmd.Parameters.Add(new SqlParameter("o_pd", this.m_paid));
            cmd.Parameters.Add(new SqlParameter("o_uID", this.user.userID));
            //cmd.Parameters.Add(new SqlParameter("t", DateTime.Now.ToString()));

            foreach(Product p in this.products)
            {
                if (this.SaveProductToOrder(p))
                {
                                                                                            //if true, insert all products belonging to order
                }
            }

            return (cmd.ExecuteNonQuery() > 0);
        }

        public bool SaveProductToOrder(Product p)
        {
            string SQL = "insert into ProductsToOrder (orderID, productID) values (@o_id, @o_pID)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            
            cmd.Parameters.Add(new SqlParameter("o_id", this.m_orderID));
            cmd.Parameters.Add(new SqlParameter("o_pID", p.productID));
 
            return (cmd.ExecuteNonQuery() > 0);
        }

        public bool UpdatePaid()
        {
            string SQL = "update Orders set paid = 1 where orderID = @o_id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("o_id", this.orderID));
            return (cmd.ExecuteNonQuery() > 0);
        }
    }
}
