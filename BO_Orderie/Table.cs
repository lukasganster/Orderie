using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Orderie
{
    public class Table
    {
        //internal variables
        private string m_tableID;
        private string m_tableName;
        private bool m_hasOrder;

               
        public string tableID {
            get  {return m_tableID;  }
            internal set  {m_tableID = value;  } 
        }
        public string tableName {
            get  {return m_tableName;  }
            set  {m_tableName = value;  } 
        }
        public Boolean hasOrder {
            get {return m_hasOrder; }
            set {m_hasOrder = value; } 
        }

        // METHODS **********************************************************************************************************

        /*
         * READ: static method for loading each individual table corresponding to their current order status
         * returns allRows after filled with the singular Objects (variables filled with DataReader)
         */

        public static Tables LoadAll()
        {
            string query = "select distinct t.TableID,t.tableName,o.paid from Tables t left join Orders o on t.TableID=o.tableID where paid = 0 and t.active = 1 union select distinct t.TableID,t.tableName,o.paid from Tables t left join Orders o on t.TableID = o.tableID where t.active = 1 and t.TableID not in (select t1.TableID from Tables t1 left join Orders o on t1.TableID = o.tableID where paid = 0 and t1.active = 1) order by tableName;";
            SqlCommand cmd = new SqlCommand(query, Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Tables allRows = new Tables(); //initializing empty list
            while (reader.Read())
            {
                Table singleTable = fillTableFromSQLDataReader(reader);
                allRows.Add(singleTable);
            }
            return allRows;
        }

        private static Table fillTableFromSQLDataReader(SqlDataReader reader)
        {
            Table singleTable = new Table();
            singleTable.tableID = reader.GetString(0);
            singleTable.tableName = reader.GetString(1);

            if(reader.IsDBNull(2) || reader.GetBoolean(2) == true) // if paid =1 , the order is no longer active for this table
            {
                singleTable.hasOrder = false;
            }
            else
            {
                //singleTable.hasOrder = reader.GetBoolean(2);
                singleTable.hasOrder = true;
            }
            
            return singleTable;
        }

        /*
        /* READ: view active orders with corresponding products for this table
        */
        public static Orders LoadOrdersForTable(Table selectedTable)
        {
            SqlCommand cmd = new SqlCommand("select orderID,userId,o.timeOrdered from Tables t join Orders o on t.tableID = o.tableID where t.TableID = @t_id and o.paid = 0", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("t_id", selectedTable.tableID));
            SqlDataReader reader = cmd.ExecuteReader();
            Orders allOrders = new Orders(); //new empty Orders List
            while (reader.Read())
            {
                Order oneOrder = new Order();
                oneOrder.timeOrdered = reader.GetDateTime(2);
                oneOrder.orderID = reader.GetString(0);
                oneOrder.table = selectedTable;
                oneOrder.user = BO_Orderie.User.getUserById(reader.GetString(1));
                oneOrder.products = BO_Orderie.Product.LoadProductsForOrder(oneOrder);
                allOrders.Add(oneOrder);
            }
            return allOrders;
        }

        /*
         * DELETE: delete Table according to ID
         */

        public bool Delete()
        {
            string SQL = "update Tables set active = 0 where TableID = @p_id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("p_id", this.m_tableID));
            return (cmd.ExecuteNonQuery() > 0);
        }

        /*
         * CREATE: create new table
         */

        public bool SaveTable()
        {
            string sql = "insert into Tables (tableID, tableName, active) values (@p_id, @p_n,1)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();

            m_tableID = Guid.NewGuid().ToString();
            cmd.Parameters.Add(new SqlParameter("p_id", this.m_tableID));
            cmd.Parameters.Add(new SqlParameter("p_n", this.m_tableName));
            return (cmd.ExecuteNonQuery() > 0);
        }

        /*
         * UPDATE: updating table information via Maintenance
         */

        public bool UpdateTable()
        {
            string sql = "update Tables set tableName = @p_n where tableID = @p_id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();

            cmd.Parameters.Add(new SqlParameter("p_id", this.m_tableID));
            cmd.Parameters.Add(new SqlParameter("p_n", this.m_tableName));

            return (cmd.ExecuteNonQuery() > 0);
        }


    }
}
