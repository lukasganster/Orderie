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
     *  The purpose of the application is to manage tables or orders for use in restaurants, bars and cafés. 
     *  
     *  Scope of functions:
                            Create, edit, delete products
                            Create orders with different products
                            Assign orders to specific tables
                            Create, edit, delete tables
                            View which orders have been paid or are still open



       edit Zweck der Klasse angeben 
     */

    public class Main
    {
        /*
         *  Access Database edit explain better using Kundenverwaltung
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

        public static Boolean login(String username, String pwd)
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




        /*
         * password encryption logic 
         * 
         * MD5 Hash is calculated from the input-string,
         * the input string is broken up into bytes for the encryption
         * the result is processed back into a string
         */

        public static string GetMD5Hash(string TextToHash)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                String salt = "lgmölkäwkräpokd+.";
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
