using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01593039Assigment3.Models;
using System.Diagnostics;
using n01593039Assigment3.ViewModels;

namespace n01593039Assigment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List?SearchKey={value}
        //Go to Views/Teacher/List.cshtml
        //Browser open a teacher list page
        public ActionResult List(string SearchKey)
        {
            // we need to pass teacher information to the view
            //create an instance of the teacher data controller

            TeacherDataController Controller = new TeacherDataController();

            List<Teacher> Teachers = Controller.ListTeachers(SearchKey);
            

            return View(Teachers);
        }

        //GET Teacher/Show/{id}
        //Go to Views/Teacher/Show.cshtml
        //Browser open a teacher's information page.
        public ActionResult Show( int id)
        {
            // we want to show a particular teacher information to the view by given id
            TeacherDataController Controller = new TeacherDataController();

            List<Class> selectedTeacher = Controller.ViewTeacher(id);

            TeacherCourse teacherCourses = Controller.View(id);
            TeacherCourseViewModel vm = new TeacherCourseViewModel();
            vm.TeacherCourses = teacherCourses;
            vm.Classes = selectedTeacher;

            return View(vm);
        }
    }
}