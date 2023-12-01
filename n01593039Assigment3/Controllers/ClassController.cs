using n01593039Assigment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n01593039Assigment3.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class/List
        // Go to Views/Class/List.cshtml
        // Browser open classes list page
        public ActionResult List()
        {
            // we need to pass student information to the view
            //create an instance of the student data controller

            ClassDataController Controller = new ClassDataController();

            List<Class1> Classes = Controller.ListClasses();

            return View(Classes);
        }
        //GET Class/Show/{id}
        //Route to Views/Class/Show.cshtml
        public ActionResult Show(int id)
        {
            // display a class information through a given id
            ClassDataController Controller = new ClassDataController();
            Class1 SelectedClass = Controller.FindClass(id);

            return View(SelectedClass);
        }
    }
}