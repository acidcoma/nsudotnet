using System;
using System.Collections.Generic;
using System.Linq;
using lab4.model;
using Microsoft.EntityFrameworkCore;

namespace lab4.controller
{
    public class DbService
    {
        public void GetWorkerProjects(int Id)
        {
            using (Context db = new Context())
            {
                var worker = db.Workers
                    .Single(w => w.Id == Id);

                db.Entry(worker)
                    .Collection(w => w.Projects) //explicit
                    .Load();
            }
        }

        public List<Project> GetProjectsByWorkerId(int WorkerId)
        {
            using (Context db = new Context())
            {
                return db.Projects
                    .Where(p => p.Worker.Id == WorkerId) //Language-Integrated Query (LINQ)
                    .ToList();
            }
        }

        public void GetWorkerByProjects(int Id)
        {
            using (Context db = new Context())
            {
                var projects = db.Projects
                    .Single(p => p.Id == Id);
                
                db.Entry(projects)
                    .Reference(p => p.Worker)
                    .Load();
            }
        }
        
        public List<Worker> GetWorkers()
        {
            using (Context db = new Context())
            {
                var workers = db.Workers.ToList(); 

                foreach (Worker w in workers)
                {
                    Console.WriteLine($"{w.Id}.{w.FirstName} {w.LastName}");
                }

                return workers;
            }
        }

        public void AddWorker(Worker w)
        {
            using (Context db = new Context())
            {
                db.Workers.Add(w);
                db.SaveChanges();
            }
        }

        public void DeleteWorker(Worker w)
        {
            using (Context db = new Context())
            {
                if (w != null)
                {
                    //удаляем объект
                    db.Workers.Remove(w);
                    db.SaveChanges();
                }
            }
        }

        public Worker GetWorkerById(int Id)
        {
            using (Context db = new Context())
            {
                return db.Workers.Find(Id);
            }
        }

        public void EditWorker(Worker w)
        {
            using (Context db = new Context())
            {
                if (w != null)
                {
                    db.Workers.Update(w);
                    db.SaveChanges(); //UPDATE
                }
            }
        }
    }
}