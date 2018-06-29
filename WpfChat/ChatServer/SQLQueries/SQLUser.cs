using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;

namespace ChatServer.SQLQueries
{
    public static class SQLUser
    {
        public static bool CheckEmail(string pEmail, SqlConnection pSqlConnection)
        {
            string query = "select Email from UserLogin where Email = @email";
            SqlCommand cmd = new SqlCommand(query, pSqlConnection);
            cmd.Parameters.AddWithValue("@email", pEmail);

            SqlDataReader dataReader = cmd.ExecuteReader();
            bool hasRows = dataReader.HasRows;

            dataReader.Dispose();

            return hasRows;
        }

        public static bool RegisterUser(string pEmail, string pPassword, SqlConnection pSqlConnection)
        {
            string passHash = MD5Hash(pPassword);
            string query = @"insert into UserLogin (Email, Password, Created, LastAccess, UserState) 
            values (@email, @pass, GETDATE(), GETDATE(), @userstate)";
            SqlCommand cmd = new SqlCommand(query, pSqlConnection);
            cmd.Parameters.AddWithValue("@email", pEmail);
            cmd.Parameters.AddWithValue("@pass", passHash);
            cmd.Parameters.AddWithValue("@userstate", 1);

            int rows = cmd.ExecuteNonQuery();
            return rows == 1;
        }

        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}
