using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoPlanning.WebUI.Models;

namespace ToDoPlanning.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}