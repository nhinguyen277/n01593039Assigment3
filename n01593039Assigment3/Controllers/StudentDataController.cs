using MySql.Data.MySqlClient;
using n01593039Assigment3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01593039Assigment3.Controllers
{
    public class StudentDataController : ApiController
    {
        // The database context class which allows us to access our my sql database
        private SchoolDbContext School = new SchoolDbContext();
        //The controller will access the Student table of our school database
        /// <summary>
        /// Returns a list of Students in the system
        /// </summary>
        /// <example>GET api/StudentData/ListStudents</example>
        /// <returns>
        /// A list of Students
        /// </returns>

        [HttpGet]
        [Route("api/StudentData/ListStudents")]
        public List<Student> ListStudents()
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();
            // open a connection between server and database
            Conn.Open();
            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();
            // SQL query
            cmd.CommandText = "Select * from students";
            // Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            // create a empty list of student names;
            List<Student> StudentIn = new List<Student> { };

            // the loop through each row
            while (ResultSet.Read())
            {
                // get the student id
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                // get the student first name
                string StudentFname = ResultSet["studentfname"].ToString();
                //get the student last name
                string StudentLname = ResultSet["studentlname"].ToString();
                // get the Student employee number
                string StudentNumber = ResultSet["studentnumber"].ToString();
                //get enroll date
                string EnrollDate = ResultSet["enroldate"].ToString();
                //create a Student object
                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.Enrolldate = EnrollDate;
                //add Student name to the list
                StudentIn.Add(NewStudent);

            }
            // close connection between MySql and server
            Conn.Close();

            return StudentIn;
        }

        [HttpGet]
        [Route("api/StudentData/FindStudent/{StudentId}")]
        public Student FindStudent(int StudentId)
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();
            // open a connection between server and database
            Conn.Open();
            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();
            // SQL query
            cmd.CommandText = "Select * from students where studentid="+StudentId;
            // Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            // create a empty list of student names;
            Student SelectedStudent = new Student();
            while (ResultSet.Read())
            {
                SelectedStudent.StudentId = Convert.ToInt32(ResultSet["studentid"]);
                SelectedStudent.StudentFname = ResultSet["studentfname"].ToString();
                SelectedStudent.StudentLname = ResultSet["studentlname"].ToString();
                SelectedStudent.StudentNumber = ResultSet["studentnumber"].ToString();
                string EnrolDate = ResultSet["enroldate"].ToString();
                DateTime date = DateTime.ParseExact(EnrolDate, "yyyy-MM-dd hh:mm:ss tt",CultureInfo.InvariantCulture);
                SelectedStudent.Enrolldate = date.ToString("yyyy-MM-dd");

            }
            //Close connection between server and browser
            Conn.Close();

            return SelectedStudent;
        }
    }
}
