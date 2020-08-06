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
        //internal variables
        private string m_userID = "";
        private string m_firstName;
        private string m_lastName;
        private string m_username;
        private string m_pwd;
        private bool m_isManager;
        
        //properties
        public string userID { 
            get { return m_userID; } 
            internal set { m_userID = value; } 
            }

        public string firstName {
            get  { return m_firstName;  }
            set  { m_firstName = value; }
            }

        public string lastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
            }

        public string username
        {
            get { return m_username; }
            set { m_username = value; }
        }

        public string pwd
        {
            get { return m_pwd; }
            set { m_pwd = value; }
        }
        public bool isManager
        {
            get { return m_isManager; }
            set { m_isManager = value; }
        }

        //check if saveable?


        //save
        public bool Save()
        {
            string SQL = "insert into Users (userID, firstName, lastName, username, password, isManager) values (@u_id, @u_fn, @u_ln,@u_un,@u_pw,@u_isMan)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();

            m_userID = Guid.NewGuid().ToString();                                           //new construct of GUID structure
            cmd.Parameters.Add(new SqlParameter("u_id", this.m_userID));
            cmd.Parameters.Add(new SqlParameter("u_fn", this.m_firstName));
            cmd.Parameters.Add(new SqlParameter("u_ln", this.m_lastName));
            cmd.Parameters.Add(new SqlParameter("u_un", this.m_username));
            cmd.Parameters.Add(new SqlParameter("u_pw", this.m_pwd));
            cmd.Parameters.Add(new SqlParameter("u_isMan", this.m_isManager));
            return (cmd.ExecuteNonQuery() > 0);
        }

        //delete
        public bool Delete()                                                                //checken ob das so passt
        {
            if (m_userID != "")
            {
                SqlCommand cmd = new SqlCommand("delete User where userID = @u_id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("userID", m_userID));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    m_userID = "";
                    return true;
                }
                else return false;                                                          //e.g. there is nothing to delete
            }
            else return true;
        }

        //all users
        internal static Users LoadAll()
        {
            SqlCommand cmd = new SqlCommand("select userID, firstName, lastName, username, pwd, isManager from Users", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Users allRows = new Users(); //initialisiere leere Liste
            while (reader.Read())
            {
                User singleUser = fillUserFromSQLDataReader(reader);
                allRows.Add(singleUser);
            }
            return allRows;
        }

        //load entire userinformation
        private static User fillUserFromSQLDataReader(SqlDataReader reader)
        {
            User singleUser = new User();
            singleUser.userID = reader.GetString(0);
            singleUser.firstName = reader.GetString(1);
            singleUser.lastName = reader.GetString(2);
            singleUser.username = reader.GetString(3);
            singleUser.pwd = reader.GetString(4);
            singleUser.isManager = reader.GetBoolean(5);
            return singleUser;
        }

    }
}
