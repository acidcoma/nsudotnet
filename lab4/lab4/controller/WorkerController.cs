using System.Collections.Generic;
using System.Linq;
using lab4.dto;
using lab4.model;
using Microsoft.AspNetCore.Mvc;
using lab4.service;

namespace lab4.controller
{
    public class WorkerController : Controller
    {
        private WorkerService WorkerService;

        public WorkerController()
        {
            this.WorkerService = new WorkerService();
        }
        
        public IActionResult Index() //использует представление index.cshtml
        {
            List<Worker> workers = WorkerService.GetAllWorkers();
            List<WorkerDto> workerDtos = workers.Select(worker =>
            {
                IEnumerable<Project> projects = worker.Projects;
                var sumPremium = 0;
                if (projects != null)
                {
                    foreach (var project in projects)
                    {
                        sumPremium += project.Premium;
                    }
                }

                return new WorkerDto(worker, sumPremium);
            }).ToList();
            return View(workerDtos);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            return View(WorkerService.FindWorker(id));
        }
        
        [HttpGet]
        public IActionResult DeleteWorker(int id)
        {
            WorkerService.DeleteWorker(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id, string name)
        {
            var workerEdit = WorkerService.GetAllWorkers().Where(w => w.Id == id).FirstOrDefault();
            
            return View(workerEdit);
        }

        [HttpPost]
        public ActionResult Edit(Worker worker)
        {
            var id = worker.Id;
            var firstName = worker.FirstName;
            var lastName = worker.LastName;
           // var patonimic = worker.Patronimic;

            //update database here..

            return RedirectToAction("Index");
        }
       
    }
}