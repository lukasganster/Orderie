using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Security.Cryptography;

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
                string pwdHashed = GetMD5Hash(pwd);
                if(u.username.Equals(username) && u.pwd.Equals(pwdHashed))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetMD5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            String salt = ".-+*1nvAD30mDkl?´ß1--";
            String passwordPre = "Orderie_";
            byte[] textToHash = System.Text.Encoding.Default.GetBytes(TextToHash+salt);
            byte[] outp = md5.ComputeHash(textToHash);
            return System.BitConverter.ToString(outp);
        }


    }
}
