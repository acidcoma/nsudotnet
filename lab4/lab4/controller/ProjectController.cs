using Microsoft.AspNetCore.Mvc;
using lab4.service;

namespace lab4.controller
{
    public class ProjectController : Controller
    {

        private ProjectService ProjectService;

        public ProjectController()
        {
            this.ProjectService = new ProjectService();
        }

        public IActionResult Index() //использует представление index.cshtml
        {
            //return View(context.Workers.ToList());
            return View();
        }
    }
}