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


        //Save

        
        //Edit


        //Delete

        public static Tables LoadAll()
        {
            string query = "select distinct t.TableID,t.tableName,o.paid from Tables t left join Orders o on t.TableID=o.tableID where paid = 0 union select distinct t.TableID,t.tableName,o.paid from Tables t left join Orders o on t.TableID = o.tableID where t.TableID not in (select t1.TableID from Tables t1 left join Orders o on t1.TableID = o.tableID where paid = 0);";
            SqlCommand cmd = new SqlCommand(query, Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Tables allRows = new Tables(); //initialisiere leere Liste
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

            if(reader.IsDBNull(2) || reader.GetBoolean(2) == true) // wenn paid true ist, ist bestellung nicht mehr aktiv
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
        //view active orders with corresponding products for this table

        public static Orders LoadOrdersForTable(Table selectedTable)
        {
            SqlCommand cmd = new SqlCommand("select orderID,userId from Tables t join Orders o on t.tableID = o.tableID where t.TableID = @t_id and o.paid = 0", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("t_id", selectedTable.tableID));
            SqlDataReader reader = cmd.ExecuteReader();
            Orders allOrders = new Orders(); //new empty Orders List
            while (reader.Read())
            {
                Order oneOrder = new Order();
                oneOrder.orderID = reader.GetString(0);
                oneOrder.table = selectedTable;
                oneOrder.user = BO_Orderie.User.getUserById(reader.GetString(1));
                oneOrder.products = BO_Orderie.Product.LoadProductsForOrder(oneOrder);
                allOrders.Add(oneOrder);
            }
            return allOrders;
        }


    }
}
