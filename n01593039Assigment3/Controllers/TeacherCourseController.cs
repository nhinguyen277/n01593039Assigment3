using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using n01593039Assigment3.ViewModels;
using n01593039Assigment3.Models;
using System.Web.Mvc;
using Org.BouncyCastle.Crypto.Parameters;

namespace n01593039Assigment3.Controllers
{
    public class TeacherCourseController : Controller
    {
        // GET: TeacherCourse
        public ActionResult Show(int id)
        {
            TeacherDataController Controller = new TeacherDataController();

            List<Class> SelectedTeacher = Controller.ViewTeacher(id);
            TeacherCourse TeacherCourses = Controller.View(id);

            return View();
        }
    }
}