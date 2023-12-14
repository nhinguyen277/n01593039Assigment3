using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01593039Assigment3.Models;
using System.Diagnostics;
using n01593039Assigment3.ViewModels;
using System.Text.RegularExpressions;

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

        //GET: /Teacher/New
        //Route to Views/Teacher/New.cshtml
        public ActionResult New()
        {
            return View();
        }

        //GET : /Author/Ajax_New
        public ActionResult Ajax_New()
        {
            return View();
        }

        // POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher NewTeacher)
        {
            // Capture teacher information entered 
            Debug.WriteLine(NewTeacher.TeacherFname);
            // add teacher information to the system
            TeacherDataController Controller = new TeacherDataController();
            Controller.AddTeacher(NewTeacher);
            // go back to the page of teacher list
            // This redirects to the list teacher method
            return RedirectToAction("List");
        }

        //GET: /Teacher/DeleteConfirm/{teacherid}
        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController Controller = new TeacherDataController();
            /*List<Class> selectedTeacher = Controller.ViewTeacher(id);*/

            TeacherCourse teacherCourses = Controller.View(id);
            TeacherCourseViewModel vm = new TeacherCourseViewModel();
            vm.TeacherCourses = teacherCourses;
            //vm.Classes = selectedTeacher;
            return View(vm);
        }

        //POST: /Teacher/Delete/{teacherid}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController Controller = new TeacherDataController();
            Controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Routes to Views/Teacher/Update.cshtml
        /// </summary>
        /// <param name="id">Id of the Teacher</param>
        /// <returns>A dynamic "Update Teacher" webpage which provides the current information of the teacher and asks the user for new information as part of a form.</returns>
        /// <example>GET : /Teacher/Update/2</example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();


            TeacherCourse teacherCourses = controller.View(id);

            return View(teacherCourses);
        }
        public ActionResult Ajax_Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();


            TeacherCourse teacherCourses = controller.View(id);

            return View(teacherCourses);
        }

        /// <summary>
        /// Receives a POST request containing information about an existing Teacher in the system, with new values. Conveys this information to the API, and redirects to the "Teachers Show" page of our updated teacher.
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="TeacherFname">The updated first name of the Teacher</param>
        /// <param name="TeacherLname">The updated last name of the Teacher</param>
        /// <param name="TeacherNumber">The updated employee number of the Teacher.</param>
        /// <param name="TeacherSalary">The updated salary of the Teacher.</param>
        /// <param name="Hiredate">The updated hire date of the Teacher.</param>
        /// <returns>A dynamic webpage which provides the current information of the Teacher.</returns>
        /// <example>
        /// POST : /Teacher/Update/2
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Caitlin",
        ///	"TeacherLname":"Cummings",
        ///	"TeacherNumber":"T381"
        ///	"TeacherSalary":"62.77"
        ///	"Hiredate":"2014-06-10"
        /// }
        /// </example>
        [HttpPost]
        public ActionResult UpdateInfo(int id, TeacherCourse UpdatedTeacher)
        {
   
            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, UpdatedTeacher);

            return RedirectToAction("Show/" + id);
        }
    }
}