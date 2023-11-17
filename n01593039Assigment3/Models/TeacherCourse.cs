using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01593039Assigment3.Models
{
    public class TeacherCourse
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
}