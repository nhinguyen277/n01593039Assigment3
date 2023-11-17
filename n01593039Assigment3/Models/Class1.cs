using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01593039Assigment3.Models
{
    public class Class1
    {
        //classid
        public int ClassId { get; set; }
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

        // start date
        public string StartDate { get; set; }
        // finish date
        public string FinishDate { get; set; }
    }
}
