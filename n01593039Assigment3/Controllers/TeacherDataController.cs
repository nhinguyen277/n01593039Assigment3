using MySql.Data.MySqlClient;
using n01593039Assigment3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;
using System.Globalization;
using System.Web.Http.Cors;


namespace n01593039Assigment3.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our my sql database
        private SchoolDbContext School = new SchoolDbContext();
        //The controller will access the teacher table of our school database
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers with teacher name containing the search key
        /// </returns>
        /// <param name="SearchKey"">The search for teacher information</param>
        /// <example>
        /// GET: api/TeacherData/ListTeacher/alexander->
        ///{"TeacherFname":"Alexander"; "TeacherLname":" Bennet"}
        /// </example>

        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public List<Teacher> ListTeachers(string SearchKey = null)
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();
            // open a connection between server and database
            Conn.Open();
            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();
            // SQL query
            cmd.CommandText = "Select * from teachers where teacherfname like '%"+SearchKey+"%' " +
                "or teacherlname like '%"+SearchKey+"%' or hiredate like'%"+SearchKey+"%' " +
                "or salary like '%"+SearchKey+"%'";
            // Gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            // create a empty list of teacher names;
            List<Teacher> TeacherNames = new List<Teacher> { };

            // the loop through each row
            while (ResultSet.Read())
            {
                // get the teacher id
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                // get the teacher first name
                string TeacherFname = ResultSet["teacherfname"].ToString();
                //get the teacher last name
                string TeacherLname = ResultSet["teacherlname"].ToString();
                // get the teacher employee number
                string TeacherNumber = ResultSet["employeenumber"].ToString();
                //get teacher hire date
                string HireDate = ResultSet["hiredate"].ToString();
                var hdate = DateTime.Parse(HireDate);
                // get teacher salary
                decimal TeacherSalary = (decimal)ResultSet["salary"];
                //create a teacher object
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.TeacherNumber = TeacherNumber;
                NewTeacher.Hiredate = hdate;
                NewTeacher.TeacherSalary = TeacherSalary;
                //add teacher name to the list
                TeacherNames.Add(NewTeacher);

            }
            // close connection between MySql and server
            Conn.Close();

            return TeacherNames;
        }
        //GET: api/TeacherData/ViewTeacher/1
        //{"TeacherId": "1" ; "TeacherFname":"Alexander"; "TeacherLname":"Bennett";"TeacherNumber":"T378";
        //"HireDate":"2016-08-05 00:00:00"; "TeacherSalary": 55.30; "Classcode":"http5101";
        //"Classname":"Web Aplication Development"}

        /// <summary>
        /// view a teacher information by input teacher id
        /// </summary>
        /// <param name="TeacherId">the teacher id is primary key in the database</param>
        /// <returns> a teacher object</returns>
        /// <example>
        /// //GET: api/TeacherData/ViewTeacher/1
        ///{"TeacherId": "1" ; "TeacherFname":"Alexander"; "TeacherLname":"Bennett";"TeacherNumber":"T378";
        ///"HireDate":"2016-08-05 00:00:00"; "TeacherSalary": 55.30; "Classcode":"http5101";
        ///"Classname":"Web Aplication Development"}
        /// </example>

        [HttpGet]
        [Route("api/TeacherData/ViewTeacher/{TeacherId}")]
        public List<Class> ViewTeacher(int TeacherId)
        {
            //Create a connection

            MySqlConnection Conn = School.AccessDatabase();

            //open the connection
            Conn.Open();
            // create a command
            MySqlCommand cmd = Conn.CreateCommand();
            //set command text
            cmd.CommandText = "select t.teacherid, t.teacherfname, t.teacherlname, c.classcode, c.classname" +
                " from teachers t join classes c on t.teacherid = c.teacherid " +
                "where t.teacherid=" + TeacherId;
            //get result set
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Teacher TeacherN = new Teacher();
           List<Class> SelectedTeacher = new List<Class> { };
            while (ResultSet.Read())
            {
                // get the teacher first name
                string TeacherFname = ResultSet["teacherfname"].ToString();
                //get the teacher last name
                string TeacherLname = ResultSet["teacherlname"].ToString();
                //get the class code
                string Classcode = ResultSet["classcode"].ToString();
                // get the class name
                string Classname = ResultSet["classname"].ToString();
                Class TeacherIn = new Class();
                TeacherIn.TeacherFname = TeacherFname;
                TeacherIn.TeacherLname = TeacherLname;
                TeacherIn.Classcode = Classcode;
                TeacherIn.Classname = Classname;
                SelectedTeacher.Add(TeacherIn);

            }
            // close the connection
            Conn.Close();
            
            
            return SelectedTeacher;
        }

        [HttpGet]
        [Route("api/TeacherData/ViewTeacher/{TeacherId}")]
        public TeacherCourse View(int TeacherId)
        {
            //Create a connection

            MySqlConnection Conn = School.AccessDatabase();

            //open the connection
            Conn.Open();
            // create a command
            MySqlCommand cmd = Conn.CreateCommand();
            //set command text
            cmd.CommandText = "select * from teachers where teacherid=" + TeacherId;
            //get result set
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            TeacherCourse TeacherCourses = new TeacherCourse();
            while (ResultSet.Read())
            {
                // get the teacher id
                TeacherCourses.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                // get the teacher first name

                TeacherCourses.TeacherFname = ResultSet["teacherfname"].ToString();
                //get the teacher last name
                TeacherCourses.TeacherLname = ResultSet["teacherlname"].ToString();
                // get teacher employee number
                TeacherCourses.TeacherNumber = ResultSet["employeenumber"].ToString();
                //get hire date
                TeacherCourses.Hiredate = ResultSet["hiredate"].ToString();
                //string Hdate = ResultSet["hiredate"].ToString();
                //Debug.WriteLine(date);
                //var date1 = "2023-11-16 02:22:22 AM";
                DateTime datetime = DateTime.ParseExact(TeacherCourses.Hiredate,"yyyy-MM-dd hh:mm:ss tt",CultureInfo.InvariantCulture);
                //Debug.WriteLine(datetime);
                TeacherCourses.Hiredate = datetime.ToString("yyyy-MM-dd") ;

                //get salary
                TeacherCourses.TeacherSalary = (decimal)ResultSet["salary"];
            

            }
            // close the connection
            Conn.Close();


            return TeacherCourses;
        }

        //new method in the teacher data controller
        /// <summary>
        /// Receives a new teacher information and adds the teacher to the database
        /// </summary>
        /// <example>
        /// POST:api/TeacherData/AddTeacher
        /// 
        /// FORM DATA/ POST DATA:
        /// {
        /// "TeacherFname": "Jemi",
        /// "TeacherLname": "Choi",
        /// "EmployeeNumber": "T290",
        /// "Salary":"50,55"
        /// }
        /// </example>
        /// <returns></returns>
        /// After add, delete, we will focus on the API directly
        [HttpPost]
        [EnableCors(origins:"*",methods:"*",headers:"*")]
        public string AddTeacher(Teacher NewTeacher)
        {
            // assume that the information is received correctly
            //contact the database and execute a query
            //what kind of query that we need to include?
            // insert into teachers (teacherid, teacherfname, teacherlname, employeenumber,salary)
            // values(0,'Jemi','Choi','T290','2023-11-27','50.55')

            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();
            MySqlCommand CMD = Conn.CreateCommand();

            string query = "insert into teachers (teacherid, teacherfname, teacherlname, employeenumber,hiredate, salary) " +
                "values(0,@teacherfname,@teacherlname,@employeenumber,CURRENT_DATE(),@salary)";
            CMD.CommandText = query;
            CMD.Parameters.AddWithValue("@teacherfname",NewTeacher.TeacherFname);
            CMD.Parameters.AddWithValue("@teacherlname",NewTeacher.TeacherLname);
            CMD.Parameters.AddWithValue("@employeenumber",NewTeacher.TeacherNumber);
            CMD.Parameters.AddWithValue ("@salary",NewTeacher.TeacherSalary);

            CMD.Prepare();
            CMD.ExecuteNonQuery();
            Conn.Close();


            // how do i put the new teacher information to this query
            return "add";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <example>POST: /api/TeacherData/DeleteTeacher/3</example>
        // a new method for deleting a teacher
        [HttpPost]
        [Route("api/TeacherData/DeleteTeacher/{TeacherId}")]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void DeleteTeacher(int TeacherId)
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();
            // open the connection between database and server
            Conn.Open();
            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "DELETE teachers,classes FROM teachers JOIN classes ON teachers.teacherid=classes.teacherid " +
                "WHERE teachers.teacherid=@id and classes.teacherid=@id";
            cmd.Parameters.AddWithValue("@id",TeacherId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Conn.Close();
        }
    }
}