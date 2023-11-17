using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01593039Assigment3.Models
{
    public class Teacher
    {
        //teacher_id
        public int TeacherId { get; set; }

        // teacher first name
        public string TeacherFname { get; set; }
        // teacher last name
        public string TeacherLname { get; set; }
        // teacher number
        public string TeacherNumber { get; set; }
        // Teacher hire day
        public string Hiredate { get; set; }
        // teacher salary
        public decimal TeacherSalary { get; set; }

    }
    public class Class
    {
        //teacher_id
        public int TeacherId { get; set; }

        // teacher first name
        public string TeacherFname { get; set; }
        // teacher last name
        public string TeacherLname { get; set; }
        // class code
        public string Classcode { get; set; }
        // class name
        public string Classname { get; set; }
    }
}