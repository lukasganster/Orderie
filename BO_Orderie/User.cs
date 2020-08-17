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
        private string m_userID = "";               //ID of user (waiter/manager)
        private string m_firstName;
        private string m_lastName;
        private string m_username;                  //for login: username
        private string m_pwd;                       //for login: password
        private bool m_isManager;                   //manager-role grants access to modifications (EditProduct)
        
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

        // METHODS **********************************************************************************************************

        /*
         * inserting a new user into the database
         */
        public bool Save()
        {
            string SQL = "insert into Users (userID, firstName, lastName, username, password, isManager) values (@u_id, @u_fn, @u_ln,@u_un,@u_pw,@u_isMan)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            this.m_pwd = Main.GetMD5Hash(this.m_pwd);


            m_userID = Guid.NewGuid().ToString();                                           //new construct of GUID structure
            cmd.Parameters.Add(new SqlParameter("u_id", this.m_userID));
            cmd.Parameters.Add(new SqlParameter("u_fn", this.m_firstName));
            cmd.Parameters.Add(new SqlParameter("u_ln", this.m_lastName));
            cmd.Parameters.Add(new SqlParameter("u_un", this.m_username));
            cmd.Parameters.Add(new SqlParameter("u_pw", this.m_pwd));
            cmd.Parameters.Add(new SqlParameter("u_isMan", this.m_isManager));
            return (cmd.ExecuteNonQuery() > 0);
        }

        /*
         *  updating users from database
         * 
         * */

        public bool Update()
        {
            string SQL = "update Users set firstName = @u_fn, lastName = @u_ln, username = @u_un, isManager = @u_isMan where userID = @u_id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();                                       //new construct of GUID structure
            cmd.Parameters.Add(new SqlParameter("u_id", this.m_userID));
            cmd.Parameters.Add(new SqlParameter("u_fn", this.m_firstName));
            cmd.Parameters.Add(new SqlParameter("u_ln", this.m_lastName));
            cmd.Parameters.Add(new SqlParameter("u_un", this.m_username));
            cmd.Parameters.Add(new SqlParameter("u_isMan", this.m_isManager));
            return (cmd.ExecuteNonQuery() > 0);
        }

        /*
         *  updating user password from database
         * 
         * */

        public String UpdatePassword()
        {
            string SQL = "update Users set pwd = @u_pw where userID = @u_id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("u_id", this.m_userID));
            String pwd = Main.GetMD5Hash(this.m_pwd);
            cmd.Parameters.Add(new SqlParameter("u_pw", pwd));
            cmd.ExecuteNonQuery();
            return pwd;
            //return (cmd.ExecuteNonQuery() > 0);
        }

        /*
         * deleting users from database
         * 
         * edit da steht bei seiner Kundenapplikation dass da iwas nicht funktioniert, anschauen ob das eh so passt
         */

        public bool Delete() // !!!!!!!!!!!!! edit checken
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
                else return false; //e.g. there is nothing to delete
            }
            else return true;
        }

        /*
         * static method for loading all users
         */

        public static Users LoadAll()
        {
            SqlCommand cmd = new SqlCommand("select userID, firstName, lastName, username, pwd, isManager from Users", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Users allRows = new Users(); //initializing empty Users list object
            while (reader.Read())
            {
                User singleUser = fillUserFromSQLDataReader(reader);
                allRows.Add(singleUser);
            }
            return allRows;
        }

        /*
         * loading entire userinformation
         */

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

        /*
         * returning userinformation based on ID
         */

        public static User getUserById(string id)
        {
            Users us = BO_Orderie.User.LoadAll();
            foreach (User u in us)
            {
                if (u.userID.Equals(id))
                {
                    return u;
                }
            }
            return null;
        }

        /*
         * returning userinformation based on username
         */


// edit  is name okay for this bool?
/*
public static Boolean hasPermission(String username)
{
   Users us = BO_Orderie.User.LoadAll();
   foreach (User u in us)
   {
       string pwdHashed = GetMD5Hash(pwd); //hash user-login input to compare with hashed pw in database
       if(u.username.Equals(username) && u.pwd.Equals(pwdHashed))
       {
           return true;
       }
   }
   return false;
} 

    or? 

            if return of getbyusername.ismanager (is true) > permission granted
             
             */

public static User getUserByUsername(string username)
{
    Users us = BO_Orderie.User.LoadAll();
    foreach (User u in us)
    {
        if (u.username.Equals(username))
        {
            return u;
        }
    }
    return null;
}

}
}
