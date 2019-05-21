using System.Linq;
using lab4.model;
using Microsoft.AspNetCore.Mvc;

namespace lab4.controller
{
    public class HomeController : Controller
    {   
        public HomeController()
        {
        }
        
        public IActionResult Index() //использует представление index.cshtml
        {
            //return View(context.Workers.ToList());
            return View();
        }
    }
    
   // Представления напоминают html-страницы,
   // кроме собственно html они также содержат специальные инструкции,
   // которые предваряются символом @
   // Это инструкции синтаксиса Razor - специального движка представлений,
   // который позволяет использовать вместе с html  код на языке c#
}