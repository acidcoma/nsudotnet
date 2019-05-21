using lab4.model;
using lab4.service;

namespace lab4.controller
{
    public class WorkerCommandLineController : WorkerService
    {
        public string CreateWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 4)
            {
                return "Wrong command format: should be 4 args";
            }

            return CreateWorker(new Worker
            {
                LastName = args[0],
                FirstName = args[1],
                Patronimic = args[2],
                //Seniority = int.Parse(args[3])
            }).Id.ToString();
        }

        public string FindWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 1)
            {
                return "Wrong command format: should be 1 args";
            }

            var worker = FindWorker(int.Parse(args[0]));
            return
                worker.LastName + " " + worker.FirstName + " " + worker.Patronimic;
        }

        public string GetWorkerProjects(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 1)
            {
                return "Wrong command format: should be 1 args";
            }

            var list = GetWorkerProjects(int.Parse(args[0]));
            var strList = "";
            foreach (var project in list)
            {
                strList += project.ProjectName + " " + project.Premium + "\n";
            }

            return strList;
        }

        public string UpdateWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 5)
            {
                return "Wrong command format: should be 5 args";
            }

            UpdateWorker(new Worker
            {
                Id = int.Parse(args[0]),
                LastName = args[1],
                FirstName = args[2],
                Patronimic = args[3],
                //Seniority = int.Parse(args[4])
            });

            return "worker updated";
        }

        public string DeleteWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 1)
            {
                return "Wrong command format: should be 1 args";
            }

            DeleteWorker(int.Parse(args[0]));
            return "worker deleted";
        }
    }
}