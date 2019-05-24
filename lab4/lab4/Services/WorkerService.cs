using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using lab4.model;

namespace lab4.service
{
    public class WorkerService
    {
        public Worker CreateWorker(Worker worker)
        {
            Worker newWorker;
            using (var db = new Context())
            {
                newWorker = db.Workers.Add(worker).Entity;
                db.SaveChanges();
            }

            return newWorker;
        }

        public Worker FindWorker(int id)
        {
            using (var db = new Context())
            {
                return db.Workers.Find(id);
            }
        }
        
        public List<Worker> GetAllWorkers()
        {
            using (var db = new Context())
            {
                return db.Workers.ToList();
                    
            }
        }

        public Worker FindWorkerBySurname(string surname)
        {
            using (var db = new Context())
            {
                return db.Workers.First(w => w.LastName.Equals(surname));
            }
        }

        public Worker FindWorkerByName(string name)
        {
            using (var db = new Context())
            {
                return db.Workers.First(w => w.FirstName.Equals(name));
            }
        }

        public Worker FindWorkerByFullName(string surname, string name)
        {
            using (var db = new Context())
            {
                return db.Workers.First(w => w.FirstName.Equals(name) && w.LastName.Equals(surname));
            }
        }

        public List<Project> GetWorkerProjects(int id)
        {
            using (var db = new Context())
            {
                return db.Workers
                    .Find(id)
                    .Projects
                    .OrderByDescending(p => p.Premium)
                    .ToList();
            }
        }

        public Worker UpdateWorker(Worker worker)
        {
            Worker newWorker;
            using (var db = new Context())
            {
                newWorker = db.Workers.Update(worker).Entity;
                db.SaveChanges();
            }

            return newWorker;
        }

        public void DeleteWorker(int id)
        {
            using (var db = new Context())
            {
                var worker = FindWorker(id);
                db.Workers.Remove(worker);
                db.SaveChanges();
            }
        }
    }
}