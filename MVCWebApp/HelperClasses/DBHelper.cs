﻿using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCWebApp.HelperClasses
{
    public class DBHelper
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MVCWebAppTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static int insertIntoStudents(StudentModel student)
        {
            int noOfRowsEffected;
            string sql = "INSERT INTO student (StudentID, FirstName, LastName, EmailAddress, Password) " +
                $"VALUES ('{student.StudentID}','{student.FirstName}','{student.LastName}','{student.EmailAddress}','{student.Password}') ;";
            SqlCommand cmd = new SqlCommand(sql, new SqlConnection(connectionString));
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection.Open();
            noOfRowsEffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Dispose();
            return noOfRowsEffected;
        }

    }
}