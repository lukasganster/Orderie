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
        public int tableID { get; internal set; }
        public string tableName { get; set; }
        public Boolean hasOrder { get; set; }

        public static Tables LoadAll()
        {
            SqlCommand cmd = new SqlCommand("select t.TableID,t.tableName,o.paid from Tables t left join Orders o on t.TableID=o.tableID;", Main.GetConnection());
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
            singleTable.tableID = reader.GetInt32(0);
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
    }
}
