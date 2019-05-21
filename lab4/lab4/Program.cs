using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

//using System;
//using lab4.controller;
//
//class Program
//{
//    static void Main(string[] args)
//    {
//        var projectController = new ProjectController();
//        var workerController = new WorkerCommandLineController();
//
//        while (true)
//        {
//            //Console.Write("");
//            string line = Console.ReadLine();
//            string resultingLine;
//            if (line == null || line.Equals("exit"))
//            {
//                break;
//            }
//
//            try
//            {
//                if (line.StartsWith("create"))
//                {
//                    if (line.Contains("worker"))
//                    {
//                        resultingLine = workerController.CreateWorker(line.Substring("create worker ".Length));
//                    }
//                    else if (line.Contains("project"))
//                    {
//                        resultingLine = projectController.CreateProject(line.Substring("create project ".Length));
//                    }
//                    else
//                    {
//                        resultingLine = "Unknown command";
//                    }
//                }
//                else if (line.StartsWith("get"))
//                {
//                    if (line.Contains("worker"))
//                    {
//                        if (line.Contains("projects"))
//                        {
//                            resultingLine =
//                                workerController.GetWorkerProjects(line.Substring("get worker project ".Length));
//                        }
//                        else
//                        {
//                            resultingLine = workerController.FindWorker(line.Substring("get worker ".Length));
//                        }
//                    }
//                    else if (line.Contains("project"))
//                    {
//                        resultingLine = projectController.FindProject(line.Substring("get project ".Length));
//                    }
//                    else
//                    {
//                        resultingLine = "Unknown command";
//                    }
//                }
//                else if (line.StartsWith("update"))
//                {
//                    if (line.Contains("worker"))
//                    {
//                        resultingLine = workerController.UpdateWorker(line.Substring("update worker ".Length));
//                    }
//                    else if (line.Contains("project"))
//                    {
//                        resultingLine = projectController.UpdateProject(line.Substring("update project ".Length));
//                    }
//                    else
//                    {
//                        resultingLine = "Unknown command";
//                    }
//                }
//                else if (line.StartsWith("delete"))
//                {
//                    if (line.Contains("worker"))
//                    {
//                        resultingLine = workerController.DeleteWorker(line.Substring("delete worker ".Length));
//                    }
//                    else if (line.Contains("project"))
//                    {
//                        resultingLine = projectController.DeleteProject(line.Substring("delete project ".Length));
//                    }
//                    else
//                    {
//                        resultingLine = "Unknown command";
//                    }
//                }
//                else
//                {
//                    resultingLine = "Unknown command";
//                }
//
//                Console.WriteLine(resultingLine);
//            }
//            catch (Exception exception)
//            {
//                Console.Error.WriteLine("Wrong command format");
//            }
//        }
//    }
//}