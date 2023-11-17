using MySql.Data.MySqlClient;
using n01593039Assigment3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01593039Assigment3.Controllers
{
    public class ClassDataController : ApiController
    {
        // The database context class which allows us to access our my sql database
        private SchoolDbContext School = new SchoolDbContext();
        //The controller will access the Classes table of our school database
        /// <summary>
        /// Returns a list of Classes in the system
        /// </summary>
        /// <example>GET api/ClassData/ListClases</example>
        /// <returns>
        /// A list of Classes
        /// </returns>

        [HttpGet]
        [Route("api/ClassData/ListClasses")]
        public List<Class1> ListClasses()
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();
            // open a connection between server and database
            Conn.Open();
            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();
            // SQL query
            cmd.CommandText = "Select * from classes";
            // Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            // create a empty list of student names;
            List<Class1> ClassIn = new List<Class1> { };

            // the loop through each row
            while (ResultSet.Read())
            {
                // get the student id
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                // get the Class name
                string Classname = ResultSet["classname"].ToString();

                //create a Class object
                Class1 NewClass = new Class1();
                NewClass.ClassId = ClassId;
                NewClass.Classname = Classname;

                //add Class name to the list
                ClassIn.Add(NewClass);

            }
            // close connection between MySql and server
            Conn.Close();

            return ClassIn;
        }

        [HttpGet]
        [Route("api/ClassData/FindClass/{ClassId}")]
        public Class1 FindClass(int ClassId)
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();
            // open a connection between server and database
            Conn.Open();
            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();
            // SQL query
            cmd.CommandText = "Select c.*, t.teacherfname,t.teacherlname from classes c " +
                "join teachers t on c.teacherid = t.teacherid where " +
                "classid=" + ClassId;
            // Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            // create a empty list of Class names;
            Class1 SelectedClass = new Class1();
            while (ResultSet.Read())
            {
                SelectedClass.ClassId = Convert.ToInt32(ResultSet["classid"]);
                SelectedClass.Classname = ResultSet["classname"].ToString();
                SelectedClass.Classcode = ResultSet["classcode"].ToString();
                SelectedClass.TeacherFname = ResultSet["teacherfname"].ToString();
                SelectedClass.TeacherLname = ResultSet["teacherlname"].ToString();
                //SelectedClass.StartDate = ResultSet["startdate"].ToString();
                string Sdate = ResultSet["startdate"].ToString();
                DateTime date = DateTime.ParseExact(Sdate, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture);
                SelectedClass.StartDate = date.ToString("yyyy-MM-dd");
                string Fdate = ResultSet["finishdate"].ToString();
                DateTime date1 = DateTime.ParseExact(Fdate,"yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture);
                SelectedClass.FinishDate = date1.ToString("yyyy-MM-dd");

            }
            //Close connection between server and browser
            Conn.Close();

            return SelectedClass;
        }
    }
}
