using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Security.Cryptography;

namespace BO_Orderie
{

    /*
     *  Orderie is a Gastronomy Administration Application
     *  The purpose of the application is to manage the tables and corresponding orders 
     *  and the maintenance of available products, tables and users (such as the staff) the  for use in restaurants, bars and cafés. 
     *  
     *  Scope of functions:
                            Create, edit, delete products
                            Create, edit, delete tables
                            Create, edit, delete users

                            Create orders with different products
                            Assign orders to specific tables
                            Overview of tables with corresponding open orders
                            Detail-view of order and function to finish the open order when payment is fulfilled

        purpose:            Easening of ordering complexity due to pre-defined product list
                            Keeping an overview of open orders
                            Avoiding payment conflicts
     */

    /*
     * object layer starter object
     * the Main class is responsible for processing general tasks such as the database connection and login functionality
     */

    public class Main
    {
        /*
         *  Access Database
         *  Link gets calculated via absolute App-Path and relative DB Position
         *  connection object
         */

        static internal SqlConnection GetConnection()
        {
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //remove last directory
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB\OrderieDB.mdf;Integrated Security=True;Connect Timeout=5";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }

        /*
         * check if user is allowed to login
         */

        public static Boolean login(String username, String pwd)            //contract (should remain this way)
        {
            Users us = BO_Orderie.User.LoadAll();                           //make a new instance of Users class for a list to save user objects into
            foreach (User u in us)
            {
                string pwdHashed = GetMD5Hash(pwd);                         //hash user-login input to compare with hashed pw in database
                if(u.username.Equals(username) && u.pwd.Equals(pwdHashed))
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * password encryption logic 
         * 
         * MD5 Hash is calculated from the input-string,
         */

        public static string GetMD5Hash(string TextToHash)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                //additional salt
                String salt = "lgmölkäwkräpokd+.";
                //the input string is broken up into bytes for the encryption
                //the result is processed back into a string

                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(TextToHash+salt);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


    }
}
