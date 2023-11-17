using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace n01593039Assigment3.Models
{
    public class SchoolDbContext
    {
        // These are read only "secret" properties.
        //Only the SchoolDbContext class can use.
        // Change these to match your own local school database.

        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        // ConnectionString is a series of credentials used to connect to the database.

        protected static string ConnectionString
        {
            get 
            {
                //convert zero datetime is a database connection setting which returns NULL if the date is 0000-00-00
                // this can allow c# to have an easier interpretation of date (no date instead of 0 BCE)
                return "server =" + Server
                + ";user = " + User
                + "; database = " + Database
                + "; port = " + Port
                + "; password = " + Password
                + "; convert zero datetime = True";

                  
            }
        }
        //This is the method we actually use to get the database!
        /// <summary>
        /// Returns a connection to the school database.
        /// </summary>
        /// <example>
        /// private SchoolDbContext School = new SchoolDbContext();
        /// MySqlConnection Conn = School.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }




    }
}