using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace BO_Orderie
{
    public class Main
    {
        static internal SqlConnection GetConnection()
        {
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB\OrderieDB.mdf;Integrated Security=True;Connect Timeout=5";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }

        public static Boolean login(String username, String pwd)
        {
            Users us = BO_Orderie.User.LoadAll();
            foreach (User u in us)
            {
                if(u.username.Equals(username) && u.pwd.Equals(pwd))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
