using n01593039Assigment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n01593039Assigment3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/List
        // Go to Views/Student/List.cshtml
        // Browser open a student list page
        public ActionResult List()
        {
            // we need to pass student information to the view
            //create an instance of the student data controller

            StudentDataController Controller = new StudentDataController();

            List<Student> Students = Controller.ListStudents();

            return View(Students);
        }
        //GET Student/Show/{id}
        //Route to Views/Student/Show.cshtml
        public ActionResult Show(int id)
        {
            // display a student information through a given id
            StudentDataController Controller = new StudentDataController();
            Student SelectedStudent = Controller.FindStudent(id);

            return View(SelectedStudent);
        }
    }
}