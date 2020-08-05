using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_Orderie
{
    public class User
    {
        public string userID { get; internal set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public bool isManager { get; set; }


        internal static Users LoadAll()
        {
            SqlCommand cmd = new SqlCommand("select userID, firstName, lastName, email, pwd, isManager from Users", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Users allUsers = new Users(); //initialisiere lehre Liste
            while (reader.Read())
            {
                User singleUser = fillUserFromSQLDataReader(reader);
                allUsers.Add(singleUser);
            }
            return allUsers;
        }

        private static User fillUserFromSQLDataReader(SqlDataReader reader)
        {
            User singleUser = new User();
            singleUser.userID = reader.GetString(0);
            singleUser.firstName = reader.GetString(1);
            singleUser.lastName = reader.GetString(2);
            singleUser.email = reader.GetString(3);
            singleUser.pwd = reader.GetString(4);
            singleUser.isManager = reader.GetBoolean(5);
            return singleUser;
        }

    }
}
