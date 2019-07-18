using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCWebApp.HelperClasses
{
    public static class DBHelper
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MVCWebAppTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string newConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public static int insertIntoStudents(StudentModel student)
        {
            int noOfRowsEffected;
            string sql = "INSERT INTO student (StudentID, FirstName, LastName, EmailAddress, Password) " +
                $"VALUES ('{student.StudentID}','{student.FirstName}','{student.LastName}','{student.EmailAddress}','{student.Password}') ;";


            using (SQLiteConnection connection = new SQLiteConnection(getConnectionString()))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection.Open();
                noOfRowsEffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return noOfRowsEffected;
        }


        public static String GetStudent(string emailAddress, string password)
        {
            String sql = $"SELECT * FROM Student WHERE emailAddress = '{emailAddress}' AND password = '{password}' ;";
            SQLiteCommand cmd = new SQLiteCommand(sql, new SQLiteConnection(getConnectionString()));
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                cmd.Connection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }

            SQLiteDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                sdr.Read();
                string nm = sdr["EmailAddress"].ToString();
                sdr.Close();
                return nm;
            }

            cmd.Connection.Close();
            cmd.Dispose();
            return null;
        }

        public static String getConnectionString(String FileName = "database.db")
        {
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;

            string sqlLiteConnectionString = string.Format(
              "data source=\"{0}\"",
              Path.Combine(baseFolder, FileName));
            return sqlLiteConnectionString;
        }
    }
}